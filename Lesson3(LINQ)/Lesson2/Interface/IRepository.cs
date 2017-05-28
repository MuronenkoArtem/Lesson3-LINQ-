using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    interface IRepository
    {
        void Create(string name, KindAnim kind);
        void Delete(string name);
        void Update();

        void ShowAllGroup();
        void ShowState(StateAnim state);
        void ShowIllTiger();
        void ShowElefant(string name);
        void ShowAnimalHungru();
        void ShowHealthiestAnimal();//здоровий
        void ShowDeadAnimal();
        void ShowWolfBear();//>3hp
        void ShowAnimalMaxMinHp();
        void ShowAverageHp();

    }
}
