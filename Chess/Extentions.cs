using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chess.Data;

namespace Chess
{
    public static class Extentions
    {
        public static string Orientation(this Game game)
        {

            if (String.IsNullOrEmpty(game.CreatorId))
            {
                return game.IsCreatorPlayWhite ? "white" : "black";
            }
            else
            {
                return game.IsCreatorPlayWhite ? "black" : "white";
            }

        }
    }
}