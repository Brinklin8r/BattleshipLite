using BattleshipLite.Library;
using BattleshipLite.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
        internal static string GetShot(PlayerInfoModel activePlayer) {
            bool isValidShotPlacement = false;
            string shotCordinate = "";

            Console.Write($"{ activePlayer.PlayerName }, take your shot.  ");

            do {    
                shotCordinate = GetCoordinateFromUser();
                isValidShotPlacement =
                    GameLogic.ValidateSpot(shotCordinate, activePlayer.ShotGrid, GridSpotStatus.Empty);

                if (isValidShotPlacement != true) {
                    Console.WriteLine("Invalid shot location try again. ");
                }
            } while (isValidShotPlacement != true);

            return shotCordinate;
        }
        internal static void DisplayShotGrid(PlayerInfoModel activePlayer) {
            Console.Clear();
            Console.WriteLine($"It is { activePlayer.PlayerName }'s turn.");
            Console.WriteLine();

            char currentRow = 'A';

            foreach (var gridSpot in activePlayer.ShotGrid) {
                if (currentRow != gridSpot.RowChar) {
                    Console.WriteLine();
                }
                switch (gridSpot.Status) {
                    case GridSpotStatus.Empty:
                        Console.Write($" { gridSpot.RowChar }{ gridSpot.ColumnInt } ");
                        break;
                    case GridSpotStatus.Hit:
                        Console.Write(" XX ");
                        break;
                    case GridSpotStatus.Miss:
                        Console.Write(" OO ");
                        break;
                    default:
                        Console.Write(" ?? ");
                        break;
                }
                currentRow = gridSpot.RowChar;
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        internal static void ShowWinnerStats(PlayerInfoModel Player) {
            int shotCount = 0;
            
            foreach (var shot in Player.ShotGrid) {
                if (shot.Status != GridSpotStatus.Empty) {
                    shotCount++;
                }
            }

            Console.Clear();
            Console.WriteLine($"Congratulations {Player.PlayerName} you have won the game of BattleShip Lite!");
            Console.WriteLine();
            Console.WriteLine($"You beat you opponent in {shotCount} shots with only {shotCount-5} misses.");
        }
        internal static List<CoordinateModel> GetShipLocations() {
            List<CoordinateModel> output = new List<CoordinateModel>();
            int totalShips = GameLogic.GetNumberOfShips();

            do {
                Console.Write($"Where do you want to place ship number { output.Count() +1 }: ");
                string coordinate = GetCoordinateFromUser();

                bool isValidShipPlacement = 
                    GameLogic.ValidateSpot(coordinate, output, GridSpotStatus.Ship);

                if (isValidShipPlacement) {
                    Console.WriteLine("Ship placed.");
                } else {
                    Console.WriteLine("Invalid ship placement. ");
                }
            } while (output.Count() < totalShips);

            Console.WriteLine("Your ships are located:");
            foreach (var ship in output) {
                Console.Write($"{ship.RowChar}{ship.ColumnInt}  ");
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to Clear Screen.");
            Console.ReadLine();
            Console.Clear();

            return output;
        }      
        internal static string GetPlayerName(string PlayerDiscription) {
            Console.Write($"{ PlayerDiscription }, please enter you name: ");
            string output = Console.ReadLine();

            return output;
        }

        private static string GetCoordinateFromUser() {
            Console.Write($"Please enter a valid cordinate: ");
            string output = Console.ReadLine();

            return output;
        }
    }
}
