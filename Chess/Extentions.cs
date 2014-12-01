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
            if (game.IsCreatorPlayWhite)
            {
                if (String.IsNullOrEmpty(game.OpponentId))
                {
                    return "white";
                }
                else
                {
                    return "black";
                }
            }
            else
            {
                if (String.IsNullOrEmpty(game.OpponentId))
                {
                    return "black";
                }
                else
                {
                    return "white";
                }
            }
        }
    }
}