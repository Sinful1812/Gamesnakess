using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Player
    {
    public int STR { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public bool SkipNextTurn { get; set; }

    public Player(string name, int initialSTR)
    {
        Name = name;
        STR = initialSTR;
        Position = 0;
        SkipNextTurn = false;
    }
}
