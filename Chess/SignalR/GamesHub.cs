using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Chess.Data.Repositories;
using Microsoft.AspNet.SignalR;

namespace Chess.SignalR
{
    public class GamesHub : Hub
    {
        private readonly GamesRepository _repository  = new GamesRepository();
        
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public void register()
        {
            _repository.RegisterPlayer(GameID(), Context.ConnectionId);            
        }

        public void move(string move, string currentPosition)
        {
            try
            {
                _repository.Move(GameID(), move, currentPosition);
            }
            catch (Exception ex)
            {
                Clients.Caller.showMessage(ex.Message);
            }
        }

        private string GameID()
        {
            var gameId = Clients.Caller.getGameId().ToString();
            return gameId;
        }

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    //MyUsers.TryRemove(Context.ConnectionId, out garbage);

        //    return base.OnDisconnected(stopCalled);
        //}
    }
}