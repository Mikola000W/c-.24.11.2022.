using System;

namespace Vendor_class
{
    public class Vendor
    {
        public string V_name = "Belzedup";
        public string V_race = "Jew";
        public int V_gold = 10000;
        public int V_healp = 25;
        public int V_manap = 25;
        public int V_nuke = 2;
        public override string ToString()
        {
            return "Character: " + V_name + "\nRace: " + V_race + "\nGold: " + V_gold;
        }
    }
}