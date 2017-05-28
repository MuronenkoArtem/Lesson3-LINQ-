using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using Lesson2.Animals;

namespace Lesson2
{    
    
    class Feed : IStrategy
    {
        public void Algorithm(string name, IEnumerable<Animal> animal)
        {
            foreach (var item in animal.Where(p => p.Name == name))
            {
                item.State = StateAnim.Full;
            }            
        }
    }
    class Cure : IStrategy
    {
        public void Algorithm(string name, IEnumerable<Animal> animal)
        {
            foreach (var item in animal.Where(p => p.Name == name && p.health < p.MaxHp))
            {
                item.health++;
                Console.WriteLine("You cure {0} now his health = {1}", name,item.health);
            }
                
        }
    }

    public class Zoo : IRepository
    {
        public bool exit = true;

        public List<Animal> Animals { get; private set; }
        
        public IStrategy Strategy { private get; set; }
        public Zoo(IStrategy strategy)
        {
            Animals = new List<Animal>() { new Lion("Leo"), new Tiger("Sherhan"), new Elefant("Meny"), new Bear("Boog"), new Wolf("Alfa"), new Fox("Nick") };
            Strategy = strategy;
        }    

        public void ShowAll()
        {
            foreach (var item in Animals)
            {
                Console.WriteLine("Kind: {0} Name: {1} Health: {2} State: {3}",item.KindAnim,item.Name,item.health,item.State);
            }
            
        }    
        public void Algorithm(string name)
        {
            Strategy.Algorithm(name,Animals);
        }

        public void Create(string name, KindAnim kind)
        {
            Animal AddAnim = null;
            switch (kind)
            {
                case KindAnim.Lion: AddAnim = new Lion(name); break;
                case KindAnim.Tiger: AddAnim = new Tiger(name); break;
                case KindAnim.Elefant: AddAnim = new Elefant(name); break;
                case KindAnim.Bear: AddAnim = new Bear(name); break;
                case KindAnim.Wolf: AddAnim = new Wolf(name); break;
                case KindAnim.Fox: AddAnim = new Fox(name); break;
            }
            Animals.Add(AddAnim);
        }
        public void Delete(string name)
        {
            if (Animals.Remove(Animals.Find(p => p.Name == name && p.health == 0)))
                Console.WriteLine("You delete {0}", name);
            Animals.Remove(Animals.Find(p => p.Name == name && p.health == 0));
                       
        }

        public void Update()
        {
            Random rand = new Random();
            int i = rand.Next(0, Animals.Count);

            if (Animals[i].health > 0 && Animals[i].State != StateAnim.Ill
                )
            {
                int state = (int)Animals[i].State;               
                Animals[i].State = (StateAnim)state + 1;
            }
            else if (Animals[i].State == StateAnim.Ill && Animals[i].health != 0)
            {
                Animals[i].health--;
            }
            else 
            {
                Animals[i].State = StateAnim.Dead;               
            }
            if(Animals[i].health == 0) Animals[i].State = StateAnim.Dead;                
        }
        public bool Exit()
        {
            int end = 0;
            foreach (var item in Animals.Where(p => p.State == StateAnim.Dead))
            {
                end++;
                if (end == Animals.Count) exit = false;
            }
            return exit;
        }
        
        public void ShowAllGroup()
        {
            var showall = Animals.OrderBy(x => x.KindAnim);
            
            foreach (var item in showall)
            {
                Console.WriteLine("Kind: {0} Name: {1} Health: {2} State: {3}", item.KindAnim, item.Name, item.health, item.State);
            }
        }
        public void ShowState(StateAnim state)
        {
            var selectedState = Animals.Where(t => t.State == state);

            foreach (var item in selectedState)
            {
                Console.WriteLine("Kind: {0} Name: {1} Health: {2} State: {3}", item.KindAnim, item.Name, item.health, item.State);
            }
        }
        public void ShowIllTiger()
        {
            var selectedIlltiger = Animals.Where(x => x.KindAnim == KindAnim.Tiger && x.State == StateAnim.Ill);

            foreach (var item in selectedIlltiger)
            {
                Console.WriteLine("Kind: {0} Name: {1} Health: {2} State: {3}", item.KindAnim, item.Name, item.health, item.State);
            }
        }
        public void ShowElefant(string name)
        {
            var selectedIElefant = Animals.Where(x => x.KindAnim == KindAnim.Elefant && x.Name == name);

            foreach (var item in selectedIElefant)
            {
                Console.WriteLine("Kind: {0} Name: {1} Health: {2} State: {3}", item.KindAnim, item.Name, item.health, item.State);
            }
        }
        public void ShowAnimalHungru()
        {
            var hungry = Animals.Where(x => x.State == StateAnim.Hungry);
            
            foreach (var item in hungry)
            {
                Console.WriteLine("Name of hungry animal: {0} ", item.Name);
            }
        }
        public void ShowHealthiestAnimal()
        {            
            var query = Animals.GroupBy(n => n.KindAnim ,(key, values) => new { Notice = key, Count = values.Max(x => x.health),list = values});
            
            foreach (var item in query)
            {
                foreach (var it in item.list.DistinctBy(x => x.KindAnim))
                {
                    Console.WriteLine(item.Notice + " " + it.Name + " " + item.Count);
                }
                
            }
        }
        public void ShowDeadAnimal()
        {
            var deadAnimals = Animals.Where(x => x.State == StateAnim.Dead);
            var query = deadAnimals.GroupBy(n => n.KindAnim,
                (key, values) => new { Notice = key, Count = values.Count() });
                                  
            foreach (var item in query)
            {                
                Console.WriteLine(item.Notice + " " + item.Count);
            }
        }        
        public void ShowWolfBear()
        {
            var wolfbear = Animals.Where(x => x.KindAnim == KindAnim.Wolf || x.KindAnim == KindAnim.Bear && x.health > 3);

            foreach (var item in wolfbear)
            {
                Console.WriteLine("Kind: {0} Name:{1} Health: {2}", item.KindAnim, item.Name,item.health);
            }
        }
        public void ShowAnimalMaxMinHp()
        {
            
            var selectedMaxMin = Animals.Where(x => x.health == Animals.Max(y => y.health) || x.health == Animals.Min(y => y.health)).DistinctBy(x => x.KindAnim);
              
            foreach (var item in selectedMaxMin.DistinctBy(x => x.KindAnim))
            {
                Console.WriteLine("Name: {0} kind {1} health {2}", item.Name,item.KindAnim,item.health);
            }
        }
        public void ShowAverageHp()
        {
            var aver = Animals.Average(x => x.health);            
            Console.WriteLine(aver);
        }
    }
}