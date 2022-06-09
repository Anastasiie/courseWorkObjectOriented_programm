namespace DataBase
{
    class fixPayment : Worker
    {
        public double Fixpayment { get; set; }
        public fixPayment(string sur, string nam, string patr, string pos, string siSal, double fixPay)                     //конструктор
        {
            Surname = sur;
            Name = nam;
            Patronymic = patr;
            Position = pos;
            SignSalary = siSal;
            Fixpayment = fixPay;
        }
        public fixPayment(string line)
        {
            string[] split = line.Split(new Char[] { ' ' });
            Surname = split[0].Trim();
            Name = split[1].Trim();
            Patronymic = split[2].Trim();
            Position = split[3].Trim();
            Fixpayment = Convert.ToDouble(split[4].Trim());
            SignSalary = split[5].Trim();
        }
        public override double Payment()
        {
            return Fixpayment + ((Fixpayment * 5) / 100);
        }
    }
}