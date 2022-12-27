using Recognition.Application.Hubs.Constants;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Hubs
{
    public class SignalRHub
    {

        //private static readonly ConcurrentDictionary<string, bool> _onlineUsers = new ConcurrentDictionary<string, bool>();
        //   // private readonly ICurrentUserService _currentUserService;
        //   // private readonly IIdentityService _identityService;


        //    public SignalRHub(
        //        //ICurrentUserService currentUserService,
        //       // IIdentityService identityService

        //        )
        //    {
        //       // _currentUserService = currentUserService;
        //        //_identityService = identityService;

        //    }
        //    public override async Task OnConnectedAsync()
        //    {
        //      //  var userId = _currentUserService.UserId;
        //        if (userId is not null)
        //        {
        //            if (_onlineUsers.TryAdd(userId, true))
        //            {
        //                var result = await _identityService.UpdateLiveStatus(userId, true);
        //                if (result != string.Empty)
        //                {

        //                    await Clients.All.SendAsync(SignalR.ConnectUser, new { userId, displayName = result });
        //                }

        //            }

        //            await UpdateOnlineUsers();
        //        }

        //        await base.OnConnectedAsync();
        //    }

        //    public override async Task OnDisconnectedAsync(Exception exception)
        //    {
        //        var userId = _currentUserService.UserId;
        //        if (userId is not null)
        //        {
        //            //try to remove key from dictionary
        //            if (!_onlineUsers.TryRemove(userId, out _))
        //            {
        //                //if not possible to remove key from dictionary, then try to mark key as not existing in cache
        //                _onlineUsers.TryUpdate(userId, false, true);
        //            }
        //            else
        //            {
        //                var result = await _identityService.UpdateLiveStatus(userId, true);
        //                if (result != string.Empty)
        //                {

        //                    await Clients.All.SendAsync(SignalR.DisconnectUser, new { userId, displayName = result });
        //                }
        //            }

        //            await UpdateOnlineUsers();
        //        }

        //        await base.OnDisconnectedAsync(exception);
        //    }

        //    private Task UpdateOnlineUsers()
        //    {
        //        var count = GetOnlineUsersCount();
        //        return Clients.All.SendAsync("UpdateOnlineUsers", count);
        //    }

        //    public static int GetOnlineUsersCount()
        //    {
        //        return _onlineUsers.Count(p => p.Value);
        //    }
        //}
    }
}
