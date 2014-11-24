using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Data.Repositories;

namespace Chess.Data.Services
{
    public class GameService : BaseService<Game>
    {
        public GameService(ChessDBEntities context) : base(context)
        {
            
        }
    }
}
