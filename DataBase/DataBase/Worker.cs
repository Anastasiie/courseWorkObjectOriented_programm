using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class Worker
    {
        public string Surname { get; set; }    //зчитування, запис
        public string Name { get; set; }
        public string Patronymic { get; set; } //по-батькові
        public string Position { get; set; }   //посада
        public int ID { get; set; }
        public string SignSalary { get; set; } //по год- 1/фікс-2

        public virtual double Payment()
        {
            double payment = 0;
            return payment;
        }
    }
}