using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public interface IStrategy
    {
        void Algorithm(string name, IEnumerable<Animal> animal);
    }
}
