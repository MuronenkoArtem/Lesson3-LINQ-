using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Animals
{
    public class Fox : Animal
    {
        public Fox(string name)
        {
            KindAnim = KindAnim.Fox;
            Name = name;
            health = 3;
            State = StateAnim.Full;
            MaxHp = 3;
        }
    }
}