using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Animals
{
    public class Tiger : Animal
    {
        public Tiger(string name)
        {
            KindAnim = KindAnim.Tiger;
            Name = name;
            health = 4;
            State = StateAnim.Full;
            MaxHp = 4;
        }
    }
}