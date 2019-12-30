using System;
using System.Collections.Generic;
using System.Text;

namespace FortBot2.Config.Models
{
    public class FNStatsDTO
    {
        public double kills { get; set; }
        public double wins { get; set; }
        public double kd { get; set; }
        public string winP { get; set; }
    }
}

// url = "https://api.fortnitetracker.com/v1/profile/{pc}/{ninja}"