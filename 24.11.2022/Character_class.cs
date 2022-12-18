using System;
using Vendor_class;
using Enemy_class;
using System.Diagnostics.CodeAnalysis;

namespace Character_class
    {

    public class Character
    {
        public string name = "NAMELESS";
        public string race = "RACELESS";
        public string power1 = "NOT";
        public string power2 = "NOT";
        public int hp = 1;
        public int mana = 1;
        public int strength = 1;
        public int agility = 1;
        public int gold = 1;
        public int healthpotion = 3;
        public int manapotion = 3;
        public int NUKE = 1;
        public string class_id = "CLASS";
        public string use = "USE";
        public int random = 0;
        public int spended = 0;
        public int spended_total = 0;



        public override string ToString()
        {
            return "Character: " + name + "\nRace: " + race + "\nHealth Points: " + hp + "\nMana amount: " + mana + "\nGold: " + gold;
        }

        public Character ChooseName(Character c_name)
        {
            Console.WriteLine("\n\n---------------------------------------------------");
            Console.WriteLine("Insert name of your character: ");
            this.name = Console.ReadLine();
            return null;
        }



        public Character ChooseClass(Character choose)
        {
            Console.WriteLine("Write Demon to become Demon." + "\nWrite Dwarf to become Dwarf." +
                "\nWrite Elf to become Elf." + "\nWrite Drunkard to become Drunkard." + "\nWrite Mage to become Mage." +
                "\nWrite Berserk to become Berserk." + "\nWrite Jew to become Jew." + "\nWrite Witcher to become Witcher." + "\nWrite Human to become Human.");
            string class_id = Console.ReadLine();
            race = class_id;
            Random rnd = new Random();

            while (class_id != "Duck" && class_id != "Demon" && class_id != "Dwarf" && class_id != "Elf" && class_id != "Drunkard" &&
            class_id != "Mage" && class_id != "Berserk" && class_id != "Jew" && class_id != "Witcher" && class_id != "Human")
            {
                Console.WriteLine("You chose sth else :/. Try again ;3");
                class_id =  Console.ReadLine();
                race = class_id; 

            }

            if (class_id == "Duck" || class_id == "1")
            {
                hp = 15000;
                mana = 300;
                agility = 50;
                gold = 10000;
                power1 = "Fly";
                power2 = "Peck";
                race = "Duck";
            }

            else if (class_id == "Demon" || class_id == "2")
            {
                hp = 1500;
                mana = 125;
                agility = 30;
                gold = 1000;
                power1 = "Confusion";
                power2 = "Paralisys";
                race = "Demon";

            }

            else if (class_id == "Dwarf" || class_id == "3")
            {
                hp = 1750;
                mana = 75;
                agility = 15;
                gold = 1250;
                power1 = "HammerHIT";
                power2 = "Blacksmith'sPride";
                race = "Dwarf";
            }

            else if (class_id == "Elf" || class_id == "4")
            {
                hp = 1250;
                mana = 150;
                agility = 50;
                gold = 1200;
                power1 = "Nature Call";
                power2 = "BowShot";
                race = "Elf";
            }

            else if (class_id == "Drunkard" || class_id == "5")
            {
                hp = 2000;
                mana = 50;
                agility = 10;
                gold = 100;
                power1 = "BottleThrow";
                power2 = "Vomit";
                race = "Drunkard";

            }

            else if (class_id == "Mage" || class_id == "6")
            {
                hp = 1000;
                mana = 200;
                agility = 25;
                gold = 1750;
                power1 = "Fireball";
                power2 = "PlasmaArrow";
                race = "Mage";

            }

            else if (class_id == "Berserk" || class_id == "7")
            {
                hp = 2000;
                mana = 65;
                agility = 35;
                gold = 550;
                power1 = "SeriousPunch";
                power2 = "Rage";
                race = "Berserk";

            }

            else if (class_id == "Jew" || class_id == "8")
            {
                hp = 1250;
                mana = 100;
                agility = 30;
                gold = 2500;
                power1 = "FairDeal";
                power2 = "HealthSteal";
                race = "Jew";

            }

            else if (class_id == "Witcher" || class_id == "9")
            {
                hp = 1750;
                mana = 85;
                agility = 35;
                gold = 1000;
                power1 = "Igni";
                power2 = "Yrden";
                race = "Witcher";
            }

            else
            {
                hp = 1000;
                mana = 100;
                agility = 30;
                gold = 2500;
                power1 = "Cry";
                power2 = "Luck";
                race = "Human";
            }

            return null;
            


        }
        public Enemy Attack(Enemy enemy_to_kill)
        {

            string class_id = race;

            Random rnd = new Random();

            if (class_id == "Demon")
            {
                strength = rnd.Next(70, 140);
            }

            else if (class_id == "Dwarf")
            {
                strength = rnd.Next(90, 140);
            }

            else if (class_id == "Elf")
            {
                strength = rnd.Next(80, 110);
            }

            else if (class_id == "Drunkard")
            {
                strength = rnd.Next(20, 200);
            }

            else if (class_id == "Mage")
            {
                strength = rnd.Next(70, 80);
            }

            else if (class_id == "Berserk")
            {
                strength = rnd.Next(50, 150);
            }

            else if (class_id == "Jew")
            {
                strength = rnd.Next(70, 120);
            }

            else if (class_id == "Duck")
            {
                strength = rnd.Next(20, 1200);
            }

            else if (class_id == "Witcher")
            {
                strength = rnd.Next(90, 120);
            }

            else if (class_id == "Human")
            {
                strength = rnd.Next(30, 150);
            }

            enemy_to_kill.Enemy_hp -= 4 * strength;
            return enemy_to_kill;



        }

        public Enemy ManaAttack(Enemy enemy_to_kill)
        {
            Random rnd = new Random();
            if (class_id == "Demon")
            {
                strength = 3 * (rnd.Next(70, 140));
            }
            else if (class_id == "Dwarf")
            {
                strength = 3 * (rnd.Next(90, 140));
            }
            else if (class_id == "ELf")
            {
                strength = 3 * (rnd.Next(80, 110));
            }
            else if (class_id == "Drunkard")
            {
                strength = 3 * (rnd.Next(20, 200));
            }
            else if (class_id == "Mage")
            {
                strength = 3 * (rnd.Next(70, 80));
            }
            else if (class_id == "Berserk")
            {
                strength = 3 * (rnd.Next(50, 150));
            }
            else if (class_id == "Jew")
            {
                strength = 3 * (rnd.Next(70, 120));
            }
            else if (class_id == "Duck")
            {
                strength = 3 * (rnd.Next(20, 1200));
            }
            else if (class_id == "Witcher")
            {
                strength = 3 * (rnd.Next(90, 120));
            }
            else if (class_id == "Human")
            {
                strength = 3 * (rnd.Next(40, 140));
            }
            return enemy_to_kill;
        }

        public Vendor trade(Vendor gold_to_trade)
        {
            gold_to_trade.V_gold += 500;
            gold -= 500;
            return gold_to_trade;
        }

    }


}
