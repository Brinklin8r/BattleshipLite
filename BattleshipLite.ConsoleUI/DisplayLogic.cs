using BattleshipLite.Library;
using BattleshipLite.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite.ConsoleUI {
    public static class DisplayLogic {
        internal static void DisplayWelcomeMessage() {
            Console.WriteLine("Welcome to Battleship Lite.");
            Console.WriteLine("By Brink");
            Console.WriteLine();
        }

        internal static PlayerInfoModel GetPlayer(string PlayerDiscription) {
            PlayerInfoModel output = new PlayerInfoModel {
                PlayerName = GetPlayerName(PlayerDiscription),
                ShotGrid = GameLogic.InitializeShotGrid(),
                ShipLocations = GetShipLocations()
            };

            return output;
        }

        private static List<CoordinateModel> GetShipLocations() {
            List<CoordinateModel> output = new List<CoordinateModel> {
                new CoordinateModel {
                    RowChar = 'A',
                    ColumnInt = 1,
                    Status = GridSpotStatus.Ship
                }
            };

            return output;
        }

        private static string GetPlayerName(string PlayerDiscription) {
            Console.Write($"{ PlayerDiscription }, please enter you name: ");
            string output = Console.ReadLine();

            return output;
        }
    }


}
