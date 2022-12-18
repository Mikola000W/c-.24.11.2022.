using System;
using Character_class;

namespace Enemy_class
{
    public class Enemy
    {
        public int Enemy_hp = 20000;
        public int Enemy_mana = 0;
        public int Enemy_strength = 3;
        public int Enemy_agility = 25;
        public string Enemy_name = "Nameless";
        public string Enemy_race = "Raceless";
        public int Enemy_class_id = 0;
        public int random = 0;

        public override string ToString()
        {
            return "Character: " + Enemy_name + "\nRace: " + Enemy_race + "\nHealth Points: " + Enemy_hp;
        }

        public Enemy EChooseClass(Enemy choose)
        {
            Random rnd = new Random();
            this.Enemy_class_id = rnd.Next(1, 9);


            if (Enemy_class_id == 1)
            {
                Enemy_hp = 1500;
                Enemy_agility = 50;
                Enemy_race = "Wolf";
            }

            else if (Enemy_class_id == 2)
            {
                Enemy_hp = 1000;
                Enemy_agility = 50;
                Enemy_race = "Goblin";
            }

            else if (Enemy_class_id == 3)
            {
                Enemy_hp = 1400;
                Enemy_mana = 200;
                Enemy_agility = 30;
                Enemy_race = "Lich";
            }

            else if (Enemy_class_id == 4)
            {
                Enemy_hp = 1750;
                Enemy_agility = 20;
                Enemy_race = "Alien";
            }

            else if (Enemy_class_id == 5)
            {
                Enemy_hp = 1900;
                Enemy_agility = 80;
                Enemy_race = "Ghoul";
            }

            else if (Enemy_class_id == 6)
            {
                Enemy_hp = 3500;
                Enemy_agility = 25;
                Enemy_race = "T-Rex";
            }

            else if (Enemy_class_id == 7)
            {
                Enemy_hp = 1250;
                Enemy_agility = 75;
                Enemy_race = "Monkey AK-47";
            }

            else if (Enemy_class_id == 8)
            {
                Enemy_hp = 4500;
                Enemy_agility = 75;
                Enemy_race = "Jaca";
            }

            else if (Enemy_class_id == 9)
            {
                Enemy_hp = 3500;
                Enemy_agility = 25;
                Enemy_race = "Goth Women";
            }


            return null;

        }
        public Character Attack(Character character_to_kill)
        {

            Random rnd = new Random();
            if (Enemy_class_id == 1)
            {
                Enemy_strength = rnd.Next(20, 35);
            }

            else if (Enemy_class_id == 2)
            {
                Enemy_strength = rnd.Next(15, 20);
            }

            else if (Enemy_class_id == 3)
            {
                Enemy_strength = rnd.Next(40, 75);
            }

            else if (Enemy_class_id == 4)
            {
                Enemy_strength = rnd.Next(35, 65);
            }

            else if (Enemy_class_id == 5)
            {
                Enemy_strength = rnd.Next(25, 40);
            }

            else if (Enemy_class_id == 6)
            {
                Enemy_strength = rnd.Next(35, 70);
            }

            else if (Enemy_class_id == 7)
            {
                Enemy_strength = rnd.Next(5, 90);
            }

            else if (Enemy_class_id == 8)
            {
                Enemy_strength = rnd.Next(1, 100);
            }

            else
            {
                Enemy_strength = rnd.Next(40, 80);
            }


            character_to_kill.hp -= Enemy_strength;
            return character_to_kill;
        }
    }

}