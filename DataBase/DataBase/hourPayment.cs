using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class hourPayment : Worker
    {
        public double NumberOfHours { get; set; }
        public double CostOfOneHour { get; set; }

        public hourPayment(string sur, string nam, string patr, string pos, string siSal, double numOfHr, double costOneHr) //конструктор
        {
            Surname = sur;
            Name = nam;
            Patronymic = patr;
            Position = pos;
            NumberOfHours = numOfHr;
            CostOfOneHour = costOneHr;
            SignSalary = siSal;

        }
        public hourPayment(string line)
        {
            string[] split = line.Split(new Char[] { ' ' });
            Surname = split[0].Trim();
            Name = split[1].Trim();
            Patronymic = split[2].Trim();
            Position = split[3].Trim();
            NumberOfHours = Convert.ToDouble(split[4].Trim());
            CostOfOneHour = Convert.ToDouble(split[5].Trim());
            SignSalary = split[6].Trim();
        }
        public override double Payment()
        {
            return NumberOfHours * CostOfOneHour;
        }
    }
}
