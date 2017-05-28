using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Animals
{
    public class Bear : Animal
    {
        public Bear(string name)
        {
            KindAnim = KindAnim.Bear;
            Name = name;
            health = 6;
            State = StateAnim.Full;
            MaxHp = 6;
        }
    }
}