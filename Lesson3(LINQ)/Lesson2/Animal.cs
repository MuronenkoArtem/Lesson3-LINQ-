using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class Animal
    {
        public KindAnim KindAnim { get; protected set; }
        public string Name { get; protected set; }
        public int health { get; set; }
        public StateAnim State { get; set; }
        public int MaxHp = 0;
    }
    public enum KindAnim
    {
        Lion,
        Tiger,
        Elefant,
        Bear,
        Wolf,
        Fox
    }
    public enum StateAnim
    {
        Full,
        Hungry,
        Ill,
        Dead
    }    
}