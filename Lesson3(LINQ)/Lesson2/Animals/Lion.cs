using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Animals
{
    public class Lion : Animal
    {
        public Lion(string name)
        {
            KindAnim = KindAnim.Lion;
            Name = name;
            health = 5;
            State = StateAnim.Full;
            MaxHp = 5;
        }
    }
}