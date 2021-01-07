using BattleshipLite.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite.Library {
    public class GameLogic {
        private static readonly int _maxRows = 5;     // 26 max (A..Z)
        private static readonly int _maxColumns = 5;  //  9 max (1..9)
        private static readonly int _numberOfShips = 5;

        private static bool ValidateCoordinates(char row, int column) {
            bool output = false;

            if (column != 0 && row != Char.MinValue) {
                if ((column > 0 && column <= _maxColumns) &&
                     (row >= 'A' && row <= Convert.ToChar(_maxRows + 64))) {
                    output = true;
                }
            }
            return output;
        }
        private static (char, int) SplitShotIntoRowColumn(string shotCordinate) {
            char row = Char.MinValue;
            int column = 0;

            if (shotCordinate?.Length == 2 && shotCordinate != "") {
                char[] shotArray = shotCordinate.ToUpper().ToArray();

                row = shotArray[0];
                if (int.TryParse(shotArray[1].ToString(), out column)) {
                }
            }

            return (row, column);
        }

        public static bool CheckForWinner(PlayerInfoModel Player) {
            bool output = false;
            int hitCounter = 0;

            foreach (var spot in Player.ShotGrid) {
                if (spot.Status == GridSpotStatus.Hit) {
                    hitCounter++;
                }
            }
            if (hitCounter == 5) {
                output = true;
            }

            return output;
        }
        public static List<CoordinateModel> InitializeShotGrid() {
            List<CoordinateModel> output = new List<CoordinateModel>();

            for (int rowCounter = 1; rowCounter <= _maxRows; rowCounter++) {
                for (int columnCounter = 1; columnCounter <= _maxColumns; columnCounter++) {
                    output.Add(new CoordinateModel {
                        RowChar = Convert.ToChar(rowCounter + 64),
                        // ASCII 'A' = 65, 'B' = 66, 'C' = 67 ....
                        ColumnInt = columnCounter,
                        Status = GridSpotStatus.Empty
                    });
                    ;
                }
            }

            return output;
        }
        public static bool CheckForHit(string shot, PlayerInfoModel player, PlayerInfoModel opponent) {
            bool output = false;
            GridSpotStatus hit = GridSpotStatus.Miss;

            (char row, int column) = SplitShotIntoRowColumn(shot);

            foreach (var gridSpot in opponent.ShipLocations) {
                if (gridSpot.RowChar == row && gridSpot.ColumnInt == column) {
                    hit = GridSpotStatus.Hit;
                    output = true;
                }
            }
            foreach (var shotSpot in player.ShotGrid) {
                if (shotSpot.RowChar == row && shotSpot.ColumnInt == column) {
                    shotSpot.Status = hit;
                }
            }

            return output;
        }
        public static int GetNumberOfShips() {
            return _numberOfShips;
        }
        public static bool ValidateSpot(string coordinate, List<CoordinateModel> coordinatesList, GridSpotStatus status) {
            bool output = false;
            
            (char row, int column) = SplitShotIntoRowColumn(coordinate);
            bool isValidCoordinate = ValidateCoordinates(row, column);

            if (isValidCoordinate == true ) {
                CoordinateModel spot = new CoordinateModel {
                    RowChar = row,
                    ColumnInt = column,
                    Status = status
                };

                if (coordinatesList.Contains(spot) == false && status == GridSpotStatus.Ship) {
                    coordinatesList.Add(spot);
                    output = true;
                }

                if (coordinatesList.Contains(spot) == true && status == GridSpotStatus.Empty) {
                    output = true;
                }
            }

            return output;
        }
    }
}
