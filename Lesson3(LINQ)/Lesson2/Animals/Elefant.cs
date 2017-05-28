using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Animals
{
    public class Elefant : Animal
    {
        public Elefant(string name)
        {
            KindAnim = KindAnim.Elefant;
            Name = name;
            health = 7;
            State = StateAnim.Full;
            MaxHp = 7;
        }
    }
}