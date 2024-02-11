using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDop2Hw0702Dapper.Models
{
    public class Puzzle
    {
        public int PuzzleID { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
