using Character_class;
using Enemy_class;
using Vendor_class;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;






namespace Program
{
    public class HelloWorld
    {
        public static void Main()
        {
            int redo = 0;
            int Width = 15;
            int height = 10;
            string color = "DarkRed";
            Character myBoi = new Character();
            Enemy myEnemy = new Enemy();
            Vendor Jack = new Vendor();
            myBoi.ChooseClass(myBoi);
            myBoi.ChooseName(myBoi);
            myEnemy.EChooseClass(myEnemy);
            myBoi.ToString();
            Console.WriteLine(myBoi.ToString());
            Console.WriteLine("Use arrows to move.");

            ConsoleKeyInfo KeyInfo;
            do
            {
                string text = System.IO.File.ReadAllText(@"C:\\Users\\mikiw\\source\\repos\\24.11.2022\\24.11.2022\\Map.txt");
                Console.BackgroundColor = ConsoleColor.Magenta;


                KeyInfo = Console.ReadKey(true);
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.WriteLine(text);

                Console.SetCursorPosition(22, 15);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write('E');
                Console.SetCursorPosition(30, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("SH");
                Console.SetCursorPosition(57, 17);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("E2");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(40, 17);
                Console.Write("G");
                Console.SetCursorPosition(5, 5);


                switch (KeyInfo.Key)

                {
                    case ConsoleKey.RightArrow:
                        Width++;
                        Console.SetCursorPosition(Width, height);
                        Console.Write("X");
                        break;
                    case ConsoleKey.LeftArrow:
                        Width--;
                        Console.SetCursorPosition(Width, height);
                        Console.Write("X");
                        break;
                    case ConsoleKey.UpArrow:
                        height--;
                        Console.SetCursorPosition(Width, height);
                        Console.Write("X");
                        break;
                    case ConsoleKey.DownArrow:
                        height++;
                        Console.SetCursorPosition(Width, height);
                        Console.Write("X");
                        break;
                }
                if (Width == 73)
                {
                    Width = 72;
                }
                if (height == 7)
                {
                    height = 8;
                }
                if (Width == 9)
                {
                    Width = 10;
                }
                if (height == 21)
                {
                    height = 20;
                }

                if (height == 15 && Width==22)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    while (myEnemy.Enemy_hp > 1 && myBoi.hp > 1)
                    {
                        //Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("\n\nWhat would you like to do?" + "\n Attack |" + " Powers"+"\n______________" + "\n   Use |" + "   Run  \n\n");
                        string what = Console.ReadLine();
                        int pu = 0;
                        Console.Clear();
                        Console.WriteLine(what);

                        if (what == "Attack" || what == "attack" || what == "a" || what == "1")
                        {
                            if (myBoi.agility >= myEnemy.Enemy_agility)
                            {
                                if (myBoi.mana > 0)
                                {
                                    Console.WriteLine("\n\n---------------------------------------------------");
                                    Console.WriteLine("Would you like to use mana? Yes or No.");
                                    myBoi.use = Console.ReadLine();
                                    if (myBoi.use == "Yes" && myBoi.use == "yes")
                                    {
                                        myBoi.ManaAttack(myEnemy);
                                        Console.WriteLine("---------------------------------------------------\n\n");
                                        myBoi.mana -= 20;
                                        Console.WriteLine("Your Turn:\n");
                                        Console.WriteLine(myBoi + "\n" + myBoi.name + " attacked for: " + (5 * myBoi.strength));
                                        if (myEnemy.Enemy_hp < 1)
                                        {
                                            Console.WriteLine("\n\nWell done! You defetead the monster! +200gold!");
                                            myBoi.gold += 200;

                                            break;
                                        }
                                        else
                                        {

                                            Console.WriteLine("\n==============================================" + "\n" + myEnemy.ToString());
                                            myEnemy.Attack(myBoi);
                                            Console.WriteLine("----------------------------------------------------\n\n");
                                            Console.WriteLine("Enemy's Turn:\n");
                                            Console.WriteLine(myEnemy + "\n" + myEnemy.Enemy_name + " attacked for: " + myEnemy.Enemy_strength);
                                        }


                                        if (myBoi.hp < 1)
                                        {
                                            Console.WriteLine("\n\nUgh! You lost. HAHAHAH");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + myBoi.ToString());

                                        }
                                    }
                                    else
                                    {
                                        myBoi.Attack(myEnemy);
                                        Console.WriteLine("---------------------------------------------------\n\n");
                                        Console.WriteLine("Your turn:\n");
                                        Console.WriteLine(myBoi + "\nYou attacked for: " + (3 * myBoi.strength));
                                        if (myEnemy.Enemy_hp < 1)
                                        {
                                            Console.WriteLine("\n\nWell done! You defetead the monster!");
                                            myBoi.gold += 200;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + "\n" + myEnemy.ToString());
                                            Console.WriteLine("---------------------------------------------------\n\n");
                                            Console.WriteLine("Enemy's turn:\n");
                                            Console.WriteLine(myEnemy + "\nEnemy attacked for: " + myEnemy.Enemy_strength);
                                            if (myBoi.hp < 1)
                                            {
                                                Console.WriteLine("\n\nUgh! You lost? HAHAHAH");
                                                break;
                                            }
                                            else
                                            {

                                                Console.WriteLine(myBoi.ToString());
                                            }
                                        }

                                    }
                                }

                            }
                            else
                            {
                                if (myBoi.mana > 0)
                                {
                                    Console.WriteLine("\n\n---------------------------------------------------");
                                    Console.WriteLine("Would you like to use mana? Yes or No.");
                                    myBoi.use = Console.ReadLine();
                                    if (myBoi.use == "Yes" || myBoi.use == "yes" || myBoi.use == "y" || myBoi.use == "Y")
                                    {
                                        myEnemy.Attack(myBoi);
                                        Console.WriteLine("---------------------------------------------------\n\n");
                                        Console.WriteLine("Enemy's Turn:\n");
                                        Console.WriteLine(myEnemy + "\n" + myEnemy.Enemy_name + " attacked for: " + myEnemy.Enemy_strength);
                                        if (myBoi.hp < 1)
                                        {
                                            Console.WriteLine("\n\nYou lost! Hhahahhaha! -200Social Credits!");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + "\n" + myBoi.ToString());
                                            myBoi.Attack(myEnemy);
                                            myBoi.mana -= 20;
                                            Console.WriteLine("----------------------------------------------------\n\n");
                                            Console.WriteLine("Your Turn:\n");
                                            Console.WriteLine(myBoi + "\n" + myBoi.name + " attacked for: " + (5 * myBoi.strength) / 2);
                                        }

                                        if (myEnemy.Enemy_hp < 1)
                                        {
                                            Console.WriteLine("\n\nWell done! You defetead the monster! You must be proud of yourself. ;3");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + "\n" + myEnemy.ToString());

                                        }
                                    }
                                    else
                                    {
                                        myEnemy.Attack(myBoi);
                                        Console.WriteLine("---------------------------------------------------\n\n");
                                        Console.WriteLine("Enemy's Turn:\n");
                                        Console.WriteLine(myEnemy + "\n" + myEnemy.Enemy_name + " attacked for: " + myEnemy.Enemy_strength);
                                        if (myBoi.hp < 1)
                                        {
                                            Console.WriteLine("\n\nYou lost! Hhahahhaha how did you even do that!");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n ==============================================" + "\n" + myBoi.ToString());
                                            myBoi.Attack(myEnemy);
                                            Console.WriteLine("----------------------------------------------------\n\n");
                                            Console.WriteLine("Your Turn:\n");
                                            Console.WriteLine(myBoi + "\n" + myBoi.name + " attacked for: " + myBoi.strength);
                                        }

                                        if (myEnemy.Enemy_hp < 1)
                                        {
                                            Console.WriteLine("\n\nWell done! That was plain boring. ;v");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + "\n" + myEnemy.ToString());

                                        }



                                    }
                                }
                            }
                        }

                        else if (what == "Use" || what == "use" || what == "u" || what == "2")
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("What would you like to use?" + "\n1. Health potion: " +
                                myBoi.healthpotion + "\n2. Mana potion: " + myBoi.manapotion + "\n3. NUKE: " + myBoi.NUKE);
                            string use = Console.ReadLine();
                            if (use == "Health Potion" || use == "health potion" || use == "HP" || use == "hp" || use == "1")
                            {
                                if (myBoi.healthpotion > 0)
                                {
                                    myBoi.hp += 500;
                                    myBoi.healthpotion -= 1;
                                    Console.WriteLine("\n\n----------------------------------------------------\n" + myBoi.ToString() + myBoi.healthpotion);
                                }
                                else
                                {
                                    Console.WriteLine("\n\n----------------------------------------------------\n" + "You don't have any potions. Go buy some or sth :3");
                                    break;
                                }
                            }
                            else if (use == "Mana Potion" || use == "mana potion" || use == "MP" || use == "mp" || use == "2")
                            {
                                if (myBoi.manapotion > 0)
                                {
                                    myBoi.mana += 150;
                                    myBoi.manapotion -= 1;

                                    Console.WriteLine("\n\n----------------------------------------------------\n" + myBoi.ToString() + myBoi.manapotion);
                                }
                                else
                                {
                                    Console.WriteLine("\n\n----------------------------------------------------\n" + "You don't have any potions. You poor soul:3");
                                    break;
                                }
                            }
                            else if (use == "NUKE" || use == "nuke" || use == "n" || use == "3")
                            {
                                if (myBoi.NUKE > 0)
                                {

                                    myBoi.hp = 0;
                                    myEnemy.Enemy_hp = 0;
                                    Console.WriteLine("\n\n----------------------------------------------------\n" + "You most likely obliterated most of the fauna and flora in 2km radious you savage. Good job :)." +
                                        "\n\n----------------------------------------------------\n" + myBoi.ToString() + "\n\n----------------------------------------------------\n" + myEnemy.ToString());

                                }
                                else
                                {
                                    Console.WriteLine("Why would you need it???");
                                    break;
                                }
                            }
                            Console.WriteLine("\nYour Health Potions: " + myBoi.healthpotion + "\nYour Mana Potions: " + myBoi.manapotion + "\nYour NUKES Potions: " + myBoi.NUKE);

                        }

                        else if (what == "Power" || what =="power" || what == "p" || what == "3")
                        {
                            if (pu == 0)
                            {
                                Console.WriteLine("Which power would you like to use?\n" + myBoi.power1 + "\n" + myBoi.power2 + "\n (one use per battle)");
                                if (Console.ReadLine() == myBoi.power1)
                                {
                                    if (myBoi.race == "Duck")
                                    {
                                        Console.WriteLine("You used Fly!");
                                        Console.WriteLine("\nYou attacked your enemy for 400");
                                        myEnemy.Enemy_hp -= 400;
                                    }
                                    else if (myBoi.race == "Demon")
                                    {
                                        Console.WriteLine("You used Confusion!");
                                        Console.WriteLine("\nYou lowered your enemy's agility for 20");
                                        myEnemy.Enemy_agility -= 20;
                                    }
                                    else if (myBoi.race == "Dwarf")
                                    {
                                        Console.WriteLine("You used Hamer HIT   !");
                                        Console.WriteLine("\nYou attacked your enemy for 500");
                                        myEnemy.Enemy_hp -= 400;
                                    }
                                    else if (myBoi.race == "Elf")
                                    {
                                        Console.WriteLine("You used Nature Call!");
                                        Console.WriteLine("\nYou attacked for 200,\n You lowered your enemy's agility for 10");
                                        myEnemy.Enemy_hp -= 200;
                                        myEnemy.Enemy_agility -= 10;
                                    }
                                    else if (myBoi.race == "Drunkard")
                                    {
                                        Console.WriteLine("You used Bottle Throw!");
                                        Console.WriteLine("\nYou attacked your enemy for 300");
                                        myEnemy.Enemy_hp -= 300;
                                    }
                                    else if (myBoi.race == "Mage")
                                    {
                                        Console.WriteLine("You used Fireball!");
                                        Console.WriteLine("\nYou attacked your enemy for 800");
                                        myEnemy.Enemy_hp -= 800;
                                    }
                                    else if (myBoi.race == "Berserk")
                                    {
                                        Console.WriteLine("You used Serious Punch!");
                                        Console.WriteLine("\nYou attacked your enemy for 700");
                                        myEnemy.Enemy_hp -= 700;
                                    }
                                    else if (myBoi.race == "Jew")
                                    {
                                        Console.WriteLine("You used First Deal!");
                                        Console.WriteLine("\nYou made a fair deal with Trader.");
                                        Jack.V_gold -= 1000;
                                        myBoi.gold += 1000;
                                    }
                                    else if (myBoi.race == "Witcher")
                                    {
                                        Console.WriteLine("You used Igni!");
                                        Console.WriteLine("\nYou attacked your enemy for 300");
                                        myEnemy.Enemy_hp -= 300;
                                        myEnemy.Enemy_strength -= 20;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You used Cry!");
                                        Console.WriteLine("\nYour enemy pitied you.");
                                        myBoi.hp += myEnemy.Enemy_strength;
                                    }
                                    myBoi.ToString();
                                    myEnemy.ToString();
                                    pu += 1;

                                }
                                if (Console.ReadLine() == myBoi.power2)
                                {
                                    if (myBoi.race == "Duck")
                                    {
                                        Console.WriteLine("You used Peck!");
                                        Console.WriteLine("\nYou pecked your enemy for 900hp");
                                        myEnemy.Enemy_hp -= 900;
                                    }
                                    else if (myBoi.race == "Demon")
                                    {
                                        Console.WriteLine("You used Paralisys!");
                                        Console.WriteLine("\nYou lowered your enemy's agility to 5");
                                        myEnemy.Enemy_agility = 5;
                                    }
                                    else if (myBoi.race == "Dwarf")
                                    {
                                        Console.WriteLine("You used Blacksmith's Pride!");
                                        Console.WriteLine("\nYou attacked your enemy's morals");
                                        myEnemy.Enemy_hp -= 100;
                                        myEnemy.Enemy_strength -= 20;
                                        myEnemy.Enemy_agility -= 20;
                                    }
                                    else if (myBoi.race == "Elf")
                                    {
                                        Console.WriteLine("You used Bow shot!");
                                        Console.WriteLine("\nYou attacked it's groin for 400hp");
                                        myEnemy.Enemy_hp -= 400;
                                    }
                                    else if (myBoi.race == "Drunkard")
                                    {
                                        Console.WriteLine("You used Vomit!");
                                        Console.WriteLine("\nYou Disgusting %@$#$");
                                        myEnemy.Enemy_hp -= 75;
                                        myEnemy.Enemy_strength -= 20;
                                        myEnemy.Enemy_agility -= 20;
                                    }
                                    else if (myBoi.race == "Mage")
                                    {
                                        Console.WriteLine("You used Plasma Arrow!");
                                        Console.WriteLine("\nYou made a hole in your enemy for 1000hp");
                                        myEnemy.Enemy_hp -= 1000;
                                    }
                                    else if (myBoi.race == "Berserk")
                                    {
                                        Console.WriteLine("You used Rage!");
                                        Console.WriteLine("\nYou buffed yourself");
                                        myBoi.strength += 50;
                                        myBoi.agility += 20;
                                        myBoi.mana += 100;
                                    }
                                    else if (myBoi.race == "Jew")
                                    {
                                        Console.WriteLine("You used Health Steal!");
                                        Console.WriteLine("\nYou stole enemy's hp.");
                                        myEnemy.Enemy_hp -= 400;
                                        myBoi.hp += 400;
                                    }
                                    else if (myBoi.race == "Witcher")
                                    {
                                        Console.WriteLine("You used Yrden!");
                                        Console.WriteLine("\nYou debuffed your enemy");
                                        myEnemy.Enemy_hp -= 100;
                                        myEnemy.Enemy_strength -= 20;
                                        myEnemy.Enemy_agility -= 20;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You used Luck!");
                                        Console.WriteLine("\n Meteorite hit your enemy.");
                                        myEnemy.Enemy_hp = 0;
                                    }
                                    myBoi.ToString();
                                    myEnemy.ToString();
                                    pu += 1;

                                }
                            }
                            else
                            {
                                Console.Write("You already used your power in this fight");
                            }
                        }
                    
                        else
                        {
                            Console.WriteLine("You ran away? Pffffsfsffsffs!");
                            break;
                        }
                    }
                    
                }

                if (height == 17 && Width == 57)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    int pu = 0;
                    while (myEnemy.Enemy_hp > 1 && myBoi.hp > 1)
                    {
                        //Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("\n\nWhat would you like to do?" + "\n Attack |" + " Powers" + "\n______________" + "\n   Use |" + "   Run  \n\n");
                        string what = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(what);

                        if (what == "Attack" || what == "attack" || what == "a" || what == "1")
                        {
                            if (myBoi.agility >= myEnemy.Enemy_agility)
                            {
                                if (myBoi.mana > 0)
                                {
                                    Console.WriteLine("\n\n---------------------------------------------------");
                                    Console.WriteLine("Would you like to use mana? Yes or No.");
                                    myBoi.use = Console.ReadLine();
                                    if (myBoi.use == "Yes" && myBoi.use == "yes")
                                    {
                                        myBoi.ManaAttack(myEnemy);
                                        Console.WriteLine("---------------------------------------------------\n\n");
                                        myBoi.mana -= 20;
                                        Console.WriteLine("Your Turn:\n");
                                        Console.WriteLine(myBoi + "\n" + myBoi.name + " attacked for: " + (5 * myBoi.strength));
                                        if (myEnemy.Enemy_hp < 1)
                                        {
                                            Console.WriteLine("\n\nWell done! You defetead the monster! +200gold!");
                                            myBoi.gold += 200;

                                            break;
                                        }
                                        else
                                        {

                                            Console.WriteLine("\n==============================================" + "\n" + myEnemy.ToString());
                                            myEnemy.Attack(myBoi);
                                            Console.WriteLine("----------------------------------------------------\n\n");
                                            Console.WriteLine("Enemy's Turn:\n");
                                            Console.WriteLine(myEnemy + "\n" + myEnemy.Enemy_name + " attacked for: " + myEnemy.Enemy_strength);
                                        }


                                        if (myBoi.hp < 1)
                                        {
                                            Console.WriteLine("\n\nUgh! You lost. HAHAHAH");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + myBoi.ToString());

                                        }
                                    }
                                    else
                                    {
                                        myBoi.Attack(myEnemy);
                                        Console.WriteLine("---------------------------------------------------\n\n");
                                        Console.WriteLine("Your turn:\n");
                                        Console.WriteLine(myBoi + "\nYou attacked for: " + (3 * myBoi.strength));
                                        if (myEnemy.Enemy_hp < 1)
                                        {
                                            Console.WriteLine("\n\nWell done! You defetead the monster!");
                                            myBoi.gold += 200;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + "\n" + myEnemy.ToString());
                                            Console.WriteLine("---------------------------------------------------\n\n");
                                            Console.WriteLine("Enemy's turn:\n");
                                            Console.WriteLine(myEnemy + "\nEnemy attacked for: " + myEnemy.Enemy_strength);
                                            if (myBoi.hp < 1)
                                            {
                                                Console.WriteLine("\n\nUgh! You lost? HAHAHAH");
                                                break;
                                            }
                                            else
                                            {

                                                Console.WriteLine(myBoi.ToString());
                                            }
                                        }

                                    }
                                }

                            }
                            else
                            {
                                if (myBoi.mana > 0)
                                {
                                    Console.WriteLine("\n\n---------------------------------------------------");
                                    Console.WriteLine("Would you like to use mana? Yes or No.");
                                    myBoi.use = Console.ReadLine();
                                    if (myBoi.use == "Yes" || myBoi.use == "yes" || myBoi.use == "y" || myBoi.use == "Y")
                                    {
                                        myEnemy.Attack(myBoi);
                                        Console.WriteLine("---------------------------------------------------\n\n");
                                        Console.WriteLine("Enemy's Turn:\n");
                                        Console.WriteLine(myEnemy + "\n" + myEnemy.Enemy_name + " attacked for: " + myEnemy.Enemy_strength);
                                        if (myBoi.hp < 1)
                                        {
                                            Console.WriteLine("\n\nYou lost! Hhahahhaha! -200Social Credits!");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + "\n" + myBoi.ToString());
                                            myBoi.Attack(myEnemy);
                                            myBoi.mana -= 20;
                                            Console.WriteLine("----------------------------------------------------\n\n");
                                            Console.WriteLine("Your Turn:\n");
                                            Console.WriteLine(myBoi + "\n" + myBoi.name + " attacked for: " + (5 * myBoi.strength) / 2);
                                        }

                                        if (myEnemy.Enemy_hp < 1)
                                        {
                                            Console.WriteLine("\n\nWell done! You defetead the monster! You must be proud of yourself. ;3");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + "\n" + myEnemy.ToString());

                                        }
                                    }
                                    else
                                    {
                                        myEnemy.Attack(myBoi);
                                        Console.WriteLine("---------------------------------------------------\n\n");
                                        Console.WriteLine("Enemy's Turn:\n");
                                        Console.WriteLine(myEnemy + "\n" + myEnemy.Enemy_name + " attacked for: " + myEnemy.Enemy_strength);
                                        if (myBoi.hp < 1)
                                        {
                                            Console.WriteLine("\n\nYou lost! Hhahahhaha how did you even do that!");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n ==============================================" + "\n" + myBoi.ToString());
                                            myBoi.Attack(myEnemy);
                                            Console.WriteLine("----------------------------------------------------\n\n");
                                            Console.WriteLine("Your Turn:\n");
                                            Console.WriteLine(myBoi + "\n" + myBoi.name + " attacked for: " + myBoi.strength);
                                        }

                                        if (myEnemy.Enemy_hp < 1)
                                        {
                                            Console.WriteLine("\n\nWell done! That was plain boring. ;v");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n==============================================" + "\n" + myEnemy.ToString());

                                        }



                                    }
                                }
                            }
                        }

                        else if (what == "Use" || what == "use" || what == "u" || what == "2")
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("What would you like to use?" + "\n1. Health potion: " +
                                myBoi.healthpotion + "\n2. Mana potion: " + myBoi.manapotion + "\n3. NUKE: " + myBoi.NUKE);
                            string use = Console.ReadLine();
                            if (use == "Health Potion" || use == "health potion" || use == "HP" || use == "hp" || use == "1")
                            {
                                if (myBoi.healthpotion > 0)
                                {
                                    myBoi.hp += 500;
                                    myBoi.healthpotion -= 1;
                                    Console.WriteLine("\n\n----------------------------------------------------\n" + myBoi.ToString() + myBoi.healthpotion);
                                }
                                else
                                {
                                    Console.WriteLine("\n\n----------------------------------------------------\n" + "You don't have any potions. Go buy some or sth :3");
                                    break;
                                }
                            }
                            else if (use == "Mana Potion" || use == "mana potion" || use == "MP" || use == "mp" || use == "2")
                            {
                                if (myBoi.manapotion > 0)
                                {
                                    myBoi.mana += 150;
                                    myBoi.manapotion -= 1;

                                    Console.WriteLine("\n\n----------------------------------------------------\n" + myBoi.ToString() + myBoi.manapotion);
                                }
                                else
                                {
                                    Console.WriteLine("\n\n----------------------------------------------------\n" + "You don't have any potions. You poor soul:3");
                                    break;
                                }
                            }
                            else if (use == "NUKE" || use == "nuke" || use == "n" || use == "3")
                            {
                                if (myBoi.NUKE > 0)
                                {

                                    myBoi.hp = 0;
                                    myEnemy.Enemy_hp = 0;
                                    Console.WriteLine("\n\n----------------------------------------------------\n" + "You most likely obliterated most of the fauna and flora in 2km radious you savage. Good job :)." +
                                        "\n\n----------------------------------------------------\n" + myBoi.ToString() + "\n\n----------------------------------------------------\n" + myEnemy.ToString());

                                }
                                else
                                {
                                    Console.WriteLine("Why would you need it???");
                                    break;
                                }
                            }
                            Console.WriteLine("\nYour Health Potions: " + myBoi.healthpotion + "\nYour Mana Potions: " + myBoi.manapotion + "\nYour NUKES Potions: " + myBoi.NUKE);

                        }

                        else if (what == "Power" || what == "power" || what == "p" || what == "3")
                        {
                            if (pu == 0)
                            {
                                Console.WriteLine("Which power would you like to use?\n" + myBoi.power1 + "\n" + myBoi.power2+"\n (one use per battle)");
                                if (Console.ReadLine() == myBoi.power1)
                                {
                                    if (myBoi.race == "Duck")
                                    {
                                        Console.WriteLine("You used Fly!");
                                        Console.WriteLine("\nYou attacked your enemy for 400");
                                        myEnemy.Enemy_hp -= 400;
                                    }
                                    else if (myBoi.race == "Demon")
                                    {
                                        Console.WriteLine("You used Confusion!");
                                        Console.WriteLine("\nYou lowered your enemy's agility for 20");
                                        myEnemy.Enemy_agility -= 20;
                                    }
                                    else if (myBoi.race == "Dwarf")
                                    {
                                        Console.WriteLine("You used Hamer HIT   !");
                                        Console.WriteLine("\nYou attacked your enemy for 500");
                                        myEnemy.Enemy_hp -= 400;
                                    }
                                    else if (myBoi.race == "Elf")
                                    {
                                        Console.WriteLine("You used Nature Call!");
                                        Console.WriteLine("\nYou attacked for 200,\n You lowered your enemy's agility for 10");
                                        myEnemy.Enemy_hp -= 200;
                                        myEnemy.Enemy_agility -= 10;
                                    }
                                    else if (myBoi.race == "Drunkard")
                                    {
                                        Console.WriteLine("You used Bottle Throw!");
                                        Console.WriteLine("\nYou attacked your enemy for 300");
                                        myEnemy.Enemy_hp -= 300;
                                    }
                                    else if (myBoi.race == "Mage")
                                    {
                                        Console.WriteLine("You used Fireball!");
                                        Console.WriteLine("\nYou attacked your enemy for 800");
                                        myEnemy.Enemy_hp -= 800;
                                    }
                                    else if (myBoi.race == "Berserk")
                                    {
                                        Console.WriteLine("You used Serious Punch!");
                                        Console.WriteLine("\nYou attacked your enemy for 700");
                                        myEnemy.Enemy_hp -= 700;
                                    }
                                    else if (myBoi.race == "Jew")
                                    {
                                        Console.WriteLine("You used First Deal!");
                                        Console.WriteLine("\nYou made a fair deal with Trader.");
                                        Jack.V_gold -= 1000;
                                        myBoi.gold += 1000;
                                    }
                                    else if (myBoi.race == "Witcher")
                                    {
                                        Console.WriteLine("You used Igni!");
                                        Console.WriteLine("\nYou attacked your enemy for 300");
                                        myEnemy.Enemy_hp -= 300;
                                        myEnemy.Enemy_strength -= 20;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You used Cry!");
                                        Console.WriteLine("\nYour enemy pitied you.");
                                        myBoi.hp += myEnemy.Enemy_strength;
                                    }
                                    myBoi.ToString();
                                    myEnemy.ToString();
                                    pu += 1;

                                }
                                if (Console.ReadLine() == myBoi.power2)
                                {
                                    if (myBoi.race == "Duck")
                                    {
                                        Console.WriteLine("You used Peck!");
                                        Console.WriteLine("\nYou pecked your enemy for 900hp");
                                        myEnemy.Enemy_hp -= 900;
                                    }
                                    else if (myBoi.race == "Demon")
                                    {
                                        Console.WriteLine("You used Paralisys!");
                                        Console.WriteLine("\nYou lowered your enemy's agility to 5");
                                        myEnemy.Enemy_agility = 5;
                                    }
                                    else if (myBoi.race == "Dwarf")
                                    {
                                        Console.WriteLine("You used Blacksmith's Pride!");
                                        Console.WriteLine("\nYou attacked your enemy's morals");
                                        myEnemy.Enemy_hp -= 100;
                                        myEnemy.Enemy_strength -= 20;
                                        myEnemy.Enemy_agility -= 20;
                                    }
                                    else if (myBoi.race == "Elf")
                                    {
                                        Console.WriteLine("You used Bow shot!");
                                        Console.WriteLine("\nYou attacked it's groin for 400hp");
                                        myEnemy.Enemy_hp -= 400;
                                    }
                                    else if (myBoi.race == "Drunkard")
                                    {
                                        Console.WriteLine("You used Vomit!");
                                        Console.WriteLine("\nYou Disgusting %@$#$");
                                        myEnemy.Enemy_hp -= 75;
                                        myEnemy.Enemy_strength -= 20;
                                        myEnemy.Enemy_agility -= 20;
                                    }
                                    else if (myBoi.race == "Mage")
                                    {
                                        Console.WriteLine("You used Plasma Arrow!");
                                        Console.WriteLine("\nYou made a hole in your enemy for 1000hp");
                                        myEnemy.Enemy_hp -= 1000;
                                    }
                                    else if (myBoi.race == "Berserk")
                                    {
                                        Console.WriteLine("You used Rage!");
                                        Console.WriteLine("\nYou buffed yourself");
                                        myBoi.strength += 50;
                                        myBoi.agility += 20;
                                        myBoi.mana += 100;
                                    }
                                    else if (myBoi.race == "Jew")
                                    {
                                        Console.WriteLine("You used Health Steal!");
                                        Console.WriteLine("\nYou stole enemy's hp.");
                                        myEnemy.Enemy_hp -= 400;
                                        myBoi.hp += 400;
                                    }
                                    else if (myBoi.race == "Witcher")
                                    {
                                        Console.WriteLine("You used Yrden!");
                                        Console.WriteLine("\nYou debuffed your enemy");
                                        myEnemy.Enemy_hp -= 100;
                                        myEnemy.Enemy_strength -= 20;
                                        myEnemy.Enemy_agility -= 20;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You used Luck!");
                                        Console.WriteLine("\n Meteorite hit your enemy.");
                                        myEnemy.Enemy_hp = 0;
                                    }
                                    myBoi.ToString();
                                    myEnemy.ToString();
                                    pu += 1;

                                }
                            }
                            else
                            {
                                Console.Write("You already used your power in this fight");
                            }
                            
                        }

                        else
                        {
                            Console.WriteLine("You ran away? Pffffsfsffsffs!");
                            break;
                        }
                    }

                }

                if (height == 10 && Width == 30)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("\n\n---------------------------------------------------");
                    Console.WriteLine("What would you like to buy: " + "\n\n1. Heal Potion - 250 gold" +
                        "\n---------------------------------------------------" +
                        "\n2. Mana Potion 200 gold" + "\n---------------------------------------------------" + "\n3. NUKE-10.000 gold" + "\n\n Your gold: " + myBoi.gold);
                    string buything = Console.ReadLine();
                    Console.WriteLine("How many would you like");
                    int how_many = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n---------------------------------------------------" + Jack.ToString());
                    if (buything == "Health Potion" || buything == "HP" || buything == "health potion" || buything == "hp" || buything == "1")
                    {
                        if (myBoi.gold > (how_many * 250))
                        {
                            Console.WriteLine("\nYou bought" + how_many + "Health Potion.");
                            myBoi.healthpotion += how_many;
                            myBoi.gold -= how_many * 250;
                            myBoi.spended += how_many * 250;

                        }
                        else
                        {
                            Console.WriteLine("\nYou're too poor hah");
                        }
                    }
                    if (buything == "Mana Potion" && buything == "MP" && buything == "mana potion" && buything == "mp" || buything == "2")
                    {
                        if (myBoi.gold > (how_many * 200))
                        {
                            Console.WriteLine(how_many + "siabadaba");
                            Console.WriteLine("\nYou bought" + how_many + " Mana Potion.");
                            myBoi.manapotion += how_many;
                            myBoi.gold -= how_many * 200;
                            myBoi.spended += how_many * 200;

                        }
                        else
                        {
                            Console.WriteLine("\nCosts too much??? Cheepskate");
                        }
                    }
                    if (buything == "NUKE" || buything == "N" || buything == "nuke" || buything == "3")
                    {
                        if (myBoi.gold > (how_many * 1000))
                        {
                            Console.WriteLine("\nYou bought " + how_many + " NUKE.(Oh Jesus)");
                            myBoi.NUKE += how_many;
                            myBoi.gold -= how_many * 1000;
                            myBoi.spended += how_many * 1000;


                        }

                        else
                        {
                            Console.WriteLine("\nNot enough? That may be better.");
                        }

                    }
                    myBoi.gold -= myBoi.spended;
                    Jack.V_gold += myBoi.spended;
                    myBoi.spended_total += myBoi.spended;
                    Console.WriteLine("\n" + Jack.ToString());
                    Console.WriteLine("Total spend: " + myBoi.spended_total);
                    Console.WriteLine("\nYour Health Potions: " + myBoi.healthpotion + "\nYour Mana Potions: " + myBoi.manapotion + "\nYour NUKES Potions: " + myBoi.NUKE);
                    myBoi.spended = 0;
                
            }

                if (height == 17 && Width == 40)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("Your gold: "+myBoi.gold+"\nWould you like to flip a coin?" );
                    if (Console.ReadLine() == "Yes")
                    {
                        Console.WriteLine("\nHow much would you like to bet?");
                        int bet = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nYou bet " + bet +"What are you betting at?\n\n"+"Heads |||  Tails");
                        myBoi.gold -= bet;
                        string side = Console.ReadLine();
                        string check = "";
                        Console.WriteLine("\nFlipping coin.");
                        Random rnd = new Random();
                        int coin = rnd.Next(1, 100);
                        if (coin >= 50)
                        {
                            check = "Heads";
                        }

                        else
                        {
                            side = "Tails";
                        }

                        if (side == check)
                        {
                            Console.WriteLine("\nYou won!!! You got " + bet * 2+"\n your gold: "+(myBoi.gold+bet*2));
                            myBoi.gold += bet * 2;
                        }
                        else
                        {
                            Console.WriteLine("\nYou lost!!! Haahahhahah \nYour gold " + myBoi.gold);

                        }
                    }

                }


            } while (redo == 0);
        }
    }   
}