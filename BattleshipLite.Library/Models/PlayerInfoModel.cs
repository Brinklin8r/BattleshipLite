using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite.Library.Models {
    public class PlayerInfoModel {
        public string PlayerName { get; set; }
        public List<CoordinateModel> ShotGrid { get; set; } = new List<CoordinateModel>();
        public List<CoordinateModel> ShipLocations { get; set; } =  new List<CoordinateModel>();
    }
}
