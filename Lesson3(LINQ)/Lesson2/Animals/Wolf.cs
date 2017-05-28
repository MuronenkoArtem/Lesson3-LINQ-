using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Animals
{
    public class Wolf : Animal
    {
        public Wolf(string name)
        {
            KindAnim = KindAnim.Wolf;
            Name = name;
            health = 4;
            State = StateAnim.Full;
            MaxHp = 4;
        }
    }
}