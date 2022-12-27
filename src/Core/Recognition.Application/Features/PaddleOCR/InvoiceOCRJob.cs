using Recognition.Application.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Http.Json;
using System.Text.Json;
using Recognition.Domain.Entities;
using System.Text.RegularExpressions;

namespace Recognition.Application.Features.PaddleOCR
{
    public class InvoiceOCRJob : IInvoiceOCRJob
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        public InvoiceOCRJob(IApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        private string readBase64String(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, image.RawFormat);
                    byte[] imageBytes = memoryStream.ToArray();

                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public async Task Recognition(int id)
        {
            using (var client = _httpClientFactory.CreateClient("ocr"))
            {
                var invoice = _context.Invoices.Find(id);
                invoice.Status = "Processing";
                await _context.SaveChangesAsync();

                var imageFile = Path.Combine(Directory.GetCurrentDirectory(), invoice.AttachmentUrl);

                string base64String = readBase64String(imageFile);
                var response = client.PostAsJsonAsync<dynamic>("", new { images = new string[] { base64String } }).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var ocr_result = JsonSerializer.Deserialize<ocr_result>(result);
                    var ocr_status = "";
                    invoice.Status = "DOne";
                    invoice.Result = ocr_result.status;

                    if (ocr_result.status == "000")
                    {
                        foreach (var collection in ocr_result.results)
                        {
                            foreach (var item in collection)
                            {
                                var rawdata = new InvoiceRawData()
                                {
                                    Confidence = item.confidence,
                                    InvoiceId = id,
                                    Text = item.text,
                                    Text_Region = JsonSerializer.Serialize(item.text_region)
                                };
                                if ((item.text.Contains("发票号码") && item.text.Length > 12) || (item.text.Length == 10 || item.text.Length == 12))
                                {
                                    var regex = new Regex("\\d*$");
                                    var mc = regex.Match(item.text);
                                    if (mc.Success && mc.Value.Length >= 10)
                                    {
                                        invoice.InvoiceNo = mc.Value;
                                    }
                                }
                                if (item.text.Contains("开票日期") || (item.text.Contains("年") && item.text.Contains("月") && item.text.Contains("日")))
                                {
                                    var regex = new Regex("\\d{4}年\\d{2}月\\d{2}日");
                                    var mc = regex.Match(item.text);
                                    if (mc.Success)
                                    {
                                        invoice.InvoiceDate = Convert.ToDateTime(mc.Value.Replace("年", "/").Replace("月", "/").Replace("日", ""));
                                    }
                                }
                                if (item.text.Contains("%"))
                                {
                                    var regex = new Regex("^\\d*.\\d+");
                                    var mc = regex.Match(item.text);
                                    if (mc.Success)
                                    {
                                        invoice.TaxRate = decimal.Parse(mc.Value);
                                    }
                                }
                                if (item.text.Contains("￥"))
                                {
                                    var regex = new Regex("\\d.\\d*");
                                    var mc = regex.Match(item.text);
                                    if (mc.Success)
                                    {
                                        invoice.Amount = decimal.Parse(mc.Value);
                                    }
                                }
                                _context.InvoiceRawDatas.Add(rawdata);
                            }
                        }
                        ocr_status = ocr_result.status;
                    }
                    await _context.SaveChangesAsync();

                }
            }
            Console.WriteLine($"{id},completed");
        }
    }

    class result
    {
        public decimal confidence { get; set; }
        public string text { get; set; }
        public List<int[]> text_region { get; set; }
    }

    class ocr_result
    {
        public string msg { get; set; }
        public List<result[]> results { get; set; }
        public string status { get; set; }
    }
}
