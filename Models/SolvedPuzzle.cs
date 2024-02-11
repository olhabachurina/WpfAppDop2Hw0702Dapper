using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDop2Hw0702Dapper.Models
{
    public class SolvedPuzzle
    {
        public int SolvedPuzzleID { get; set; }
        public int UserID { get; set; }
        public int PuzzleID { get; set; }
        public DateTime SolvedOn { get; set; }

        public string Username { get; set; }
        public string PuzzleText { get; set; }
    }
   
}
