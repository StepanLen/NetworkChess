using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace Chess.Models
{
    public class Game
    {
        public Guid ID { get; set; }
        public String Link { get; set; }
        //public Boolean IsNextMoveWhite { get; set; }
    }
}