using BattleshipLite.Library;
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
            string shot = "";
            bool isHit = false;
            bool isWinner = false;

            //// Create Players
            PlayerInfoModel activePlayer = DisplayLogic.GetPlayer("Player 1");
            PlayerInfoModel opponent = DisplayLogic.GetPlayer("Player 2");

            //// Get Turn 
            do {
                // Display Player Name and Shot Grid
                DisplayLogic.DisplayShotGrid(activePlayer);
                // Get Shot
                shot = DisplayLogic.GetShot(activePlayer);
                // Check for hit
                isHit = GameLogic.CheckForHit(shot, activePlayer, opponent);
                if (isHit) {
                    Console.WriteLine($"That was a hit at {shot.ToUpper()}.");
                } else {
                    Console.WriteLine("That was a miss");
                }
                // Check for win
                isWinner = GameLogic.CheckForWinner(activePlayer);
                // If win, display winner, else next player's turn
                if (isWinner) {
                    Console.WriteLine();
                    Console.WriteLine($"{activePlayer.PlayerName} is the winner.");
                } else {
                    PlayerInfoModel temp = new PlayerInfoModel();
                    temp = activePlayer;
                    activePlayer = opponent;
                    opponent = temp;
                    Console.WriteLine($"Press Enter for {activePlayer.PlayerName}'s turn");
                    Console.ReadLine();
                }
            } while (isWinner == false);
            //// Display winner's stats.
            DisplayLogic.ShowWinnerStats(activePlayer);

            Console.ReadLine();
        }
    }
}
