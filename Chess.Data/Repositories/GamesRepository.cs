using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
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

        public Game Add(Game game)
        {
            return _service.Add(game);
        }

        public Game Save(Game game)
        {
            return _service.Update(game, game.Id);
        }
    }
}
