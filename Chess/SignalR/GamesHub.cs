using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Chess.Data;
using Chess.Data.Repositories;
using Microsoft.AspNet.SignalR;

namespace Chess.SignalR
{
    public class GamesHub : Hub
    {
        private readonly GamesRepository _repository  = new GamesRepository();

        public void register(string gameID)
        {
            _repository.RegisterPlayer(gameID, Context.ConnectionId);            
        }

        public void onMove(string gameID, string oldPosition, string currentPosition)
        {
            try
            {
                _repository.Move(gameID, oldPosition, currentPosition);
                setPosition(gameID, Context.ConnectionId, currentPosition);
            }
            catch (Exception ex)
            {
                Clients.Caller.showMessage(ex.Message);
            }
        }

        public void setPosition(string gameID, string callerID, string position)
        {
            var opponentID = _repository.GetOpponentID(gameID, callerID);

            if (!String.IsNullOrEmpty(opponentID))
            {
                var opponent = Clients.Client(opponentID);
                if (opponent != null)
                {
                    opponent.setPosition(position);
                }
            }
        }

    }
}