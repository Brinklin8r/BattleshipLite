using BattleshipLite.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite.ConsoleUI {
    class Program {
        static void Main(string[] args) {
            DisplayLogic.DisplayWelcomeMessage();

            // Create Player 1
            // Create Player 2
            PlayerInfoModel activePlayer = DisplayLogic.GetPlayer("Player 1");
            PlayerInfoModel opponent = DisplayLogic.GetPlayer("Player 2");

            // Get Turn 

            // If win, display winner, else next player's turn

            Console.ReadLine();
        }
    }
}
