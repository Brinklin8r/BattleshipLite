using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite.Library.Models {
    public class CoordinateModel : IEquatable<CoordinateModel> {
        public char RowChar { get; set; }
        public int ColumnInt { get; set; }
        public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;

        public bool Equals(CoordinateModel other) {
            if (this.RowChar == other.RowChar 
                && this.ColumnInt == other.ColumnInt
                && this.Status == other.Status) {
                return true;
            } else {
                return false;
            }
        }
    }
}
