using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo anim = new Zoo(new Feed());
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, anim, 0, 50000);
            do
            {                              
                Console.WriteLine("Select an action\n1 - Add Animal\n2 - Feed Animal\n3 - Cure Annimal\n4 - Delete Animal\n5 - Show all animals\n6 - Query\n7- Clear console");
                string command = Console.ReadLine();
                Console.WriteLine(command);
                switch (command)
                {
                    case "1":
                        Console.WriteLine("Enter kind of animal\n1 - Lion\n2 - Tiger\n3 - Bear\n4 - Elefant\n5 - Wolf\n6 - Fox");
                        switch (Console.ReadLine())
                        {
                            case "1": anim.Create(Console.ReadLine(),KindAnim.Lion); break; ;
                            case "2": anim.Create(Console.ReadLine(), KindAnim.Tiger); break; ;
                            case "3": anim.Create(Console.ReadLine(), KindAnim.Bear); break; ;
                            case "4": anim.Create(Console.ReadLine(), KindAnim.Elefant); break; ;
                            case "5": anim.Create(Console.ReadLine(), KindAnim.Wolf); break; ;
                            case "6": anim.Create(Console.ReadLine(), KindAnim.Fox); break; ;
                            default:
                                break;
                        }break;                        
                    case "2": Console.WriteLine("Enter name animal: "); anim.Algorithm(Console.ReadLine()) ; break;
                    case "3": Console.WriteLine("Enter name animal: "); anim.Strategy = new Cure(); anim.Algorithm(Console.ReadLine()); break;
                    case "4": Console.WriteLine("Enter name animal: "); anim.Delete(Console.ReadLine());  break;
                    case "5": anim.ShowAll(); break;
                    case "6": Console.WriteLine("Select an query \n1 - Show all animals sorted by type\n2 - Show animals by state\n3 - Show all ill tiger\n4 - Show elefant\n5 - Show all hungry animals\n6 - Show the healthiest animals of each species\n7 - Show the number of dead animals of each species\n8 - Show all wolves and bears who have health above 3\n9 - Show an animal with maximum health and an animal with minimal health\n10 - Show the average health of animals in the zoo");
                        switch (Console.ReadLine())
                        {
                            case "1": anim.ShowAllGroup(); break;
                            case "2":
                                Console.WriteLine("Select state\n1 - Full\n2 - Hungry\n3 - Ill\n4 - Dead");
                                switch (Console.ReadLine())
                                {
                                    case "1": anim.ShowState(StateAnim.Full); break;
                                    case "2": anim.ShowState(StateAnim.Hungry); break;
                                    case "3": anim.ShowState(StateAnim.Ill); break;
                                    case "4": anim.ShowState(StateAnim.Dead); break;
                                    default:
                                        break;
                                }break;
                            case "3": anim.ShowIllTiger(); break;
                            case "4": Console.WriteLine("Enter name of elefant: "); anim.ShowElefant(Console.ReadLine()); break;
                            case "5": anim.ShowAnimalHungru(); break;
                            case "6": anim.ShowHealthiestAnimal(); break;
                            case "7": anim.ShowDeadAnimal(); break;
                            case "8": anim.ShowWolfBear(); break;
                            case "9": anim.ShowAnimalMaxMinHp(); break;
                            case "10": anim.ShowAverageHp(); break;
                            default:
                                break;
                        }
                        break;
                    case "7": Console.Clear(); break;
                    default:
                        break;
                }                    
            }
            while (anim.Exit());            
            Console.ReadKey();
        }
        public static void Count(object obj)
        {
            Zoo anim = (Zoo)obj;
            anim.Update();
        }
    }
}
