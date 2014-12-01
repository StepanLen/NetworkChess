using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Chess.Data.Services;

namespace Chess.Data.Repositories
{
    public class GamesRepository
    {
        private readonly GameService _service = new GameService(new ChessDBEntities());

        public Game Get(Int32 id)
        {
            return _service.Get(id);
        }

        public Game Get(Guid gameId)
        {
            return _service.Find(g => g.GameId.Equals(gameId));
        }

        public Game GenerateNewGame(string color)
        {
            var newGame = new Game
                          {
                              StartDate = DateTime.Now,
                              GameId = Guid.NewGuid(),
                              IsCreatorPlayWhite = color.Equals("White", StringComparison.InvariantCultureIgnoreCase)
                          };
            return Add(newGame);
        }

        public Game Add(Game game)
        {
            return _service.Add(game);
        }

        public Game Save(Game game)
        {
            return _service.Update(game, game.Id);
        }

        public void Move(string gameID, string move, string fen)
        {
            var game = Get(new Guid(gameID));
            if (game == null)
            {
                throw new Exception("can't find the game with ID: " + gameID);
            }

            game.FEN = fen;

            if (String.IsNullOrEmpty(game.History))
            {
                game.History = move;
            }
            else
            {
                game.History += "|" + move;
            }

            Save(game);
        }

        public void RegisterPlayer(string gameId, string connectionId)
        {
            var game = Get(new Guid(gameId));
            if (game == null)
            {
                throw new Exception("can't find the game with ID: " + gameId);
            }

            if (string.IsNullOrEmpty(game.CreatorId))
            {
                game.CreatorId = connectionId;
            }
            else if (string.IsNullOrEmpty(game.OpponentId))
            {
                game.OpponentId = connectionId;
            }
            else
            {
                throw new Exception("The game's creater and the opponent are already registered!");
            }

            Save(game);
        }
    }
}
