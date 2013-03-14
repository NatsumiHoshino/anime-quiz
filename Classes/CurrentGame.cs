﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anime_Quiz.Classes
{
    class CurrentGame
    {
        private static Game currentGame;
        public static Game getInstance()
        {
            return currentGame;
        }
        public static void setInstance(Game game)
        {
            CurrentGame.currentGame = game;
        }
    }
}
