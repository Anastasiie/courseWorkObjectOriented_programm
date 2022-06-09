using System;
using System.Collections.Generic; //list
using System.Threading.Tasks;
using System.IO;                  //input output string
using System.Linq;
using System.Text;                //кодировка текста

namespace DataBase
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;

            string nameproject = "\t\t\t\tБаза працівників супермаркету";
            int codeOperation;
            do
            {
                Console.Clear();
                //Console.BackgroundColor = ConsoleColor.White; //цвет фона консоли(маркер)
                //Console.ForegroundColor = ConsoleColor.Green; //цвет текста консоли
                //Console.ResetColor();

                Console.WriteLine(nameproject);
                Console.WriteLine("\t\t" + "○▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬○");

                Console.WriteLine(" Привіт, натисни клавішу для виконання операції: " +
                        "\n\t" + " 1. Додавання працівників до бази даних " +
                        "\n\t" + " 2. Сортування бази даних" +
                        "\n\t" + " 3. Зчитування існуючої бази даних" +
                        "\n\t" + " 4. Працівники з погодинною оплатою" +
                        "\n\t" + " 5. Знаходження всіх касирів та їх зарплат" +
                        "\n\t" + " 6. Працівники з фіксованою оплатою (оклад)" +
                        "\n\t" + " 7. Співробітники з певною заробітною платою" +
                        "\n\t" + " 8. Видалення співробітників" +
                        "\n\t" + " 9. Редагування даних співробітників" +
                        "\n\t" + " 0. Вихід");

                Console.Write("\n Вкажіть код операції: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                string operation = Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
                if (int.TryParse(operation, out codeOperation))
                {
                    codeOperation = Convert.ToInt32(operation);
                    switch (codeOperation)
                    {
                        case 1:
                            Console.WriteLine(nameproject);
                            AddWorker();
                            break;
                        case 2:
                            Console.WriteLine(nameproject);
                            SortDescending();
                            break;
                        case 3:
                            Console.WriteLine(nameproject);
                            ReadFile();
                            break;
                        case 4:
                            Console.WriteLine(nameproject);
                            houremployer();
                            break;
                        case 5:
                            Console.WriteLine(nameproject);
                            cashier();
                            break;
                        case 6:
                            Console.WriteLine(nameproject);
                            fixemployer();
                            break;
                        case 7:
                            Console.WriteLine(nameproject);
                            EmployeCertainSalary();
                            break;
                        case 8:
                            Console.WriteLine(nameproject);
                            DeleteEmployer();
                            break;
                        case 9:
                            Console.WriteLine(nameproject);
                            Edit();
                            break;
                        case 0:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Blinker("Ви натиснули вихід.");
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t" + "Помилка. Неправильно введена операція. Спробуйте ще.");
                            Console.ResetColor();
                            Console.ReadLine();
                            break;
                    }
                }
                else if (String.IsNullOrEmpty(operation))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка. Неправильно введені дані.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            } while (codeOperation != 0);
        }
        public static void AddWorker()
        {
            //Додавання працівників супермаркету
            List<hourPayment> hourlist = new List<hourPayment>();                   //динам структура
            List<fixPayment> fixlist = new List<fixPayment>();

            Console.Write(" Введіть кількість робітників, яких бажаєте додати: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string str = Console.ReadLine();
            Console.ResetColor();
            if (String.IsNullOrEmpty(str))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Помилка. Рядок пустий або дорівнює нулю.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (!int.TryParse(str, out int n))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t Введіть число!");
                Console.ResetColor();
                Console.ReadKey();                                   // очищення консолі
            }
            else if (Convert.ToInt32(str) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t Неможливо додати 0 робітників");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                using (FileStream fs = new FileStream("InputFile.txt", FileMode.Append))//, FileAccess.ReadWrite
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine(" Введіть через пропуск. ");
                            Console.Write(" Прізвище, Ім'я, По-батькові: ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            string workman = Console.ReadLine();
                            if (String.IsNullOrEmpty(workman))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                                Console.ReadKey();
                                Console.ResetColor();
                                break;
                            }
                            else if (int.TryParse(workman, out int nu))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\tВведіть словa!");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.ResetColor();
                                string[] workmanss = workman.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                Console.Clear();
                                Console.Write(" Код посади (1-Касир, 2-Продавець, 3-Вантажник, 4- Прибиральниця,\n 5-Менеджер, 6-Директор, 7-Бухгалтер):");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                string codeposition = Console.ReadLine();
                                if (String.IsNullOrEmpty(codeposition))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                    break;
                                }
                                else if (!int.TryParse(codeposition, out int num))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\tВведіть число!");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else if (Convert.ToInt32(codeposition) == 0 || Convert.ToInt32(codeposition) == 8 || Convert.ToInt32(codeposition) == 9 || Convert.ToInt32(codeposition) == 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\tТакого коду посади не існує");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.ResetColor();
                                    Console.Clear();
                                    Console.Write(" Введіть через пропуск:\n Код ознаки зарплати (Погодинна- 1, Фіксована-2), Зарплата (кількість годин/фіксований оклад) \n ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    string pay = Console.ReadLine();
                                    Console.ResetColor();
                                    if (String.IsNullOrEmpty(pay))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                                        Console.ReadKey();
                                        Console.ResetColor();
                                        break;
                                    }
                                    else
                                    {
                                        string[] payed = pay.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                        Console.Clear();
                                        if (int.Parse(payed[0]) == 1)                               // погодинна
                                        {
                                            int costOfOneHour = 0;                                  //ціна 1 години
                                            switch (int.Parse(codeposition))
                                            {
                                                case 1:
                                                    codeposition = "Касир";
                                                    costOfOneHour = 50;
                                                    break;
                                                case 2:
                                                    codeposition = "Продавець";
                                                    costOfOneHour = 85;
                                                    break;
                                                case 3:
                                                    codeposition = "Вантажник";
                                                    costOfOneHour = 100;
                                                    break;
                                                case 4:
                                                    codeposition = "Прибиральниця";
                                                    costOfOneHour = 30;
                                                    break;
                                                default:
                                                    Console.Write(" Некоректні данні");
                                                    break;
                                            }
                                            payed[0] = "Погодинна";
                                            string line = workmanss[0] + ' ' + workmanss[1] + ' ' + workmanss[2] + ' ' + codeposition + ' ' + payed[1] + ' ' + costOfOneHour + ' ' + payed[0];
                                            hourlist.Add(new hourPayment(line) { });
                                        }
                                        else if (int.Parse(payed[0]) == 2)                          // фіксована
                                        {
                                            switch (int.Parse(codeposition))
                                            {
                                                case 5:
                                                    codeposition = "Менеджер";
                                                    break;
                                                case 6:
                                                    codeposition = "Директор";
                                                    break;
                                                case 7:
                                                    codeposition = "Бухгалтер";
                                                    break;
                                                default:
                                                    Console.Write("Некоректні данні");
                                                    break;
                                            }
                                            payed[0] = "Фіксована";
                                            string line = workmanss[0] + ' ' + workmanss[1] + ' ' + workmanss[2] + ' ' + codeposition + ' ' + payed[1] + ' ' + payed[0];
                                            fixlist.Add(new fixPayment(line) { });
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("Помилка введення данних");
                                            Console.ResetColor();
                                            Console.ReadLine();
                                        }
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < hourlist.Count; i++)
                        {
                            sw.WriteLine(hourlist[i].Surname + "\t" + hourlist[i].Name + "\t" + hourlist[i].Patronymic + "\t" + hourlist[i].Position + "\t" + hourlist[i].Payment() + "\t" + hourlist[i].SignSalary); //+ "\t\t" + hourlist[i].NumberOfHours
                        }
                        for (int i = 0; i < fixlist.Count; i++)
                        {
                            sw.WriteLine(fixlist[i].Surname + "\t" + fixlist[i].Name + "\t" + fixlist[i].Patronymic + "\t" + fixlist[i].Position + "\t" + fixlist[i].Payment() + "\t" + fixlist[i].SignSalary);
                        }
                    }
                }
            }
        }
        public static void ReadFile()
        {
            List<string> Read = new List<string>();
            FileStream fs = new FileStream("InputFile.txt", FileMode.Open, FileAccess.Read);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Прізвище".PadRight(13) + "Ім'я".PadRight(11) + "По-батькові".PadRight(16) + "Посадa".PadRight(15) + "Зарплатa".PadRight(11) + "Ознака зарплати");
            Console.ResetColor();

            using (StreamReader sr = new StreamReader(fs, Encoding.Default))
            {
                string temp = string.Empty;
                while (sr.Peek() != -1)             //Повертає об'єкт на вершину стека, не видаляючи його.
                {
                    temp = sr.ReadLine();
                    Read.Add(temp);
                }
                Read = Read.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                string Surname, Name, Patronymic, Position, Payment, SignSalary;
                foreach (string s in Read)
                {
                    string[] split = s.Split(new Char[] { '\t' });
                    Surname = split[0].Trim();
                    Name = split[1].Trim();
                    Patronymic = split[2].Trim();
                    Position = split[3].Trim();
                    Payment = split[4].Trim();
                    SignSalary = split[5].Trim();
                    //Console.WritmeLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
                    Console.WriteLine(Surname.PadRight(13) + Name.PadRight(11) + Patronymic.PadRight(16) + Position.PadRight(15) + Payment.PadRight(11) + SignSalary);
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nНатисніть Enter для продовження");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void SortDescending()
        {
            List<string> Read = new List<string>();
            FileStream fs = new FileStream("InputFile.txt", FileMode.Open, FileAccess.Read);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t\t\tСортування бази даних: ");
            Console.ResetColor();
            string Surname, Name, Patronymic, Position, Payment, SignSalary;
            using (StreamReader sr = new StreamReader(fs, Encoding.Default))
            {
                string temp = string.Empty;
                while (sr.Peek() != -1)             //Повертає об'єкт на вершину стека, не видаляючи його.
                {
                    temp = sr.ReadLine();
                    Read.Add(temp);
                    Read.Sort();                    //сортировка
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("ID  " + "Прізвище\t" + " Ім'я\t" + "    По-батькові\t" + "    Посадa\t" + "   Зарплатa" + "   Ознака зарплати");
                Console.ResetColor();
                int ID = 1;
                Read = Read.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                foreach (string s in Read)
                {
                    string[] split = s.Split(new Char[] { '\t' });
                    Surname = split[0].Trim();
                    Name = split[1].Trim();
                    Patronymic = split[2].Trim();
                    Position = split[3].Trim();
                    Payment = split[4].Trim();
                    SignSalary = split[5].Trim();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
                    Console.WriteLine(Convert.ToString(ID).PadRight(4) + Surname.PadRight(13) + Name.PadRight(11) + Patronymic.PadRight(16) + Position.PadRight(15) + Payment.PadRight(11) + SignSalary);
                    ID++;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nНатисніть Enter для продовження");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void houremployer()
        {
            // Працівники з погодинною оплатою
            string[] readText = File.ReadAllLines("InputFile.txt");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t\tПрацівники з погодинною оплатою: ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Прізвище".PadRight(13) + "Ім'я".PadRight(11) + "По-батькові".PadRight(16) + "Посадa".PadRight(15) + "Зарплатa".PadRight(11) + "Ознака зарплати");
            Console.ResetColor();
            readText = readText.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string Surname, Name, Patronymic, Position, Payment, SignSalary;
            try
            {
                foreach (string str in readText)
                {
                    string[] split = str.Split(new Char[] { '\t' });
                    Surname = split[0].Trim();
                    Name = split[1].Trim();
                    Patronymic = split[2].Trim();
                    Position = split[3].Trim();
                    Payment = split[4].Trim();
                    SignSalary = split[5].Trim();
                    if (str.Contains("Погодинна"))
                    {
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
                        Console.WriteLine(Surname.PadRight(13) + Name.PadRight(11) + Patronymic.PadRight(16) + Position.PadRight(15) + Payment.PadRight(11) + SignSalary);
                    }
                }   
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Не існує в базі данних");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nНатисніть Enter для продовження");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void cashier()
        {
            string[] readText = File.ReadAllLines("InputFile.txt");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t\t\t\tКасири: ");
            Console.ResetColor();
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Прізвище".PadRight(13) + "Ім'я".PadRight(13) + "По-батькові".PadRight(16) + "Посадa".PadRight(15) + "Зарплатa".PadRight(11) + "Ознака зарплати");
                Console.ResetColor();
                foreach (string str in readText)
                {
                    string Surname, Name, Patronymic, Position, Payment, SignSalary;
                    string[] split = str.Split(new Char[] { '\t' });
                    Surname = split[0].Trim();
                    Name = split[1].Trim();
                    Patronymic = split[2].Trim();
                    Position = split[3].Trim();
                    Payment = split[4].Trim();
                    SignSalary = split[5].Trim();
                    if (str.Contains("Касир"))
                    {
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
                        Console.WriteLine(Surname.PadRight(13) + Name.PadRight(13) + Patronymic.PadRight(16) + Position.PadRight(15) + Payment.PadRight(11) + SignSalary);
                    }//else Console.WriteLine("Не існує в базі данних");
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Не існує в базі данних");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nНатисніть Enter для продовження");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void fixemployer()
        {
            //Працівники з фіксованою оплатою (оклад)
            string[] readText = File.ReadAllLines("InputFile.txt");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t\tПрацівники з фіксованою оплатою (оклад): ");
            Console.ResetColor();
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Прізвище".PadRight(13) + "Ім'я".PadRight(11) + "По-батькові".PadRight(16) + "Посадa".PadRight(15) + "Зарплатa".PadRight(11) + "Ознака зарплати");
                Console.ResetColor();
                foreach (string str in readText)
                {
                    string Surname, Name, Patronymic, Position, Payment, SignSalary;
                    string[] split = str.Split(new Char[] { '\t' });
                    Surname = split[0].Trim();
                    Name = split[1].Trim();
                    Patronymic = split[2].Trim();
                    Position = split[3].Trim();
                    Payment = split[4].Trim();
                    SignSalary = split[5].Trim();
                    if (str.Contains("Фіксована"))
                    {
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
                        Console.WriteLine(Surname.PadRight(13) + Name.PadRight(11) + Patronymic.PadRight(16) + Position.PadRight(15) + Payment.PadRight(11) + SignSalary);
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Не існує в базі данних");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nНатисніть Enter для продовження");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void EmployeCertainSalary()
        {
            //Співробітники з певною заробітною платою
            string[] readText = File.ReadAllLines("InputFile.txt");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t\tСпівробітники з певною заробітною платою ");
            Console.ResetColor();

            Console.Write("Введіть заробітну плату: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string wantedSalery = Console.ReadLine();
            Console.ResetColor();
            if (String.IsNullOrEmpty(wantedSalery))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                Console.ResetColor();
            }
            else if (!int.TryParse(wantedSalery, out int num))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tВведіть число!");
                Console.ResetColor();
            }
            else if (Convert.ToInt32(wantedSalery) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tНе існує в базі данних");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Прізвище".PadRight(13) + "Ім'я".PadRight(11) + "По-батькові".PadRight(16) + "Посадa".PadRight(15) + "Зарплатa".PadRight(11) + "Ознака зарплати");
                Console.ResetColor();
                foreach (string str in readText)
                {
                    string Surname, Name, Patronymic, Position, Payment, SignSalary;
                    string[] split = str.Split(new Char[] { '\t' });
                    Surname = split[0].Trim();
                    Name = split[1].Trim();
                    Patronymic = split[2].Trim();
                    Position = split[3].Trim();
                    Payment = split[4].Trim();
                    SignSalary = split[5].Trim();
                    if (Convert.ToDouble(Payment) > Convert.ToDouble(wantedSalery))
                    {
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*");
                        Console.WriteLine(Surname.PadRight(13) + Name.PadRight(11) + Patronymic.PadRight(16) + Position.PadRight(15) + Payment.PadRight(11) + SignSalary);
                    }
                    //else
                    //{Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Зарплати більше ніж введена не існує");
                    //    Console.ResetColor();}
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nНатисніть Enter для продовження");
            Console.ResetColor();
            Console.ReadLine();
        }
        static void DeleteEmployer()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\t\t\tВидалення Співробітників ");
            Console.ResetColor();
            Console.Write("Скільки працівників бажаєте видалити? ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string del = Console.ReadLine();
            Console.ResetColor();
            if (String.IsNullOrEmpty(del))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                Console.ResetColor();
            }
            else if (!int.TryParse(del, out int numo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tВведіть число!");
                Console.ResetColor();
            }
            else
            {
                int count = Convert.ToInt32(del);
                Console.Clear();
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("Для видалення з бази даних введіть фамілію працівника: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string delete = Console.ReadLine();
                        Console.ResetColor();
                        if (String.IsNullOrEmpty(delete))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                            Console.ResetColor();
                        }
                        else if (int.TryParse(delete, out int numio))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tВведіть слово!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Ви впевнені що бажаєте видалити? (Так/Ні)");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string answer = Console.ReadLine();
                            Console.ResetColor();
                            if (String.IsNullOrEmpty(delete))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                                Console.ResetColor();
                            }
                            else if (int.TryParse(delete, out int nump))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\tВведіть слово!");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (answer == "Так" || answer == "Да" || answer == "так" || answer == "да" || answer == "Д" || answer == "д"
                                    || answer == "т" || answer == "Т" || answer == "y" || answer == "yes" || answer == "Y" || answer == "Yes")
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Успішно видалено!");
                                    Console.ResetColor();
                                    var readod = File.ReadAllLines("InputFile.txt", Encoding.Default).Where(s => !s.Contains(delete));

                                    File.WriteAllLines("InputFile.txt", readod, Encoding.Default);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Blinker("Відмова операції!");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Blinker("Відмова операції!");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nНатисніть Enter для продовження");
            Console.ResetColor();
            Console.ReadKey();
        }
        static void Edit()
        {
            string[] R = File.ReadAllLines("InputFile.txt");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t\tРедагування даних співробітників");
            Console.ResetColor();

            string Surname, Name, Patronymic, Position, Payment, SignSalary;
            int ID = 0;

            Console.Write("Введіть номер співробітника, якого бажаєте редагувати: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string numb = Console.ReadLine();
            Console.ResetColor();
            if (String.IsNullOrEmpty(numb))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (!int.TryParse(numb, out int numo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tВведіть число!");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                int number = Convert.ToInt32(numb);
                number = number - 1;            //с нуля 

                if ((number > 0) || (number < R.Length))
                {
                    foreach (string s in R)
                    {
                        string[] split = s.Split(new Char[] { '\t' });
                        Surname = split[0].Trim();
                        Name = split[1].Trim();
                        Patronymic = split[2].Trim();
                        Position = split[3].Trim();
                        Payment = split[4].Trim();
                        SignSalary = split[5].Trim();
                        if (ID == number)
                        {
                            Console.WriteLine("Що бажаєте редагувати? ");
                            Console.WriteLine("1 - Прізвище, 2 - Ім'я, 3 - По-батькові, 4 - Нічого. Вихід");//,\n 4 - Посада, 5 - Зарплата 6 - Ознака зарплати
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            string wh_tediT = Console.ReadLine();
                            Console.ResetColor();
                            if (String.IsNullOrEmpty(wh_tediT))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Помилка. Рядок пустий або дорівнює нулю.");
                                Console.ResetColor();
                            }
                            else if (!int.TryParse(wh_tediT, out int nummo))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\tВведіть число!");
                                Console.ResetColor();
                            }
                            else
                            {
                                switch (Convert.ToInt32(wh_tediT))
                                {
                                    case 1:
                                        Console.WriteLine("Введіть нове прізвище: ");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        string surname = Console.ReadLine();
                                        Console.ResetColor();
                                        Surname = surname;
                                        break;
                                    case 2:
                                        Console.WriteLine("Введіть нове ім'я: ");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        string name = Console.ReadLine();
                                        Console.ResetColor();
                                        Name = name;
                                        break;
                                    case 3:
                                        Console.WriteLine("Введіть нове по-батькові: ");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        string patronymic = Console.ReadLine();
                                        Console.ResetColor();
                                        Patronymic = patronymic;
                                        break;
                                    case 4:
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("Ви натиснули вихід ");
                                        Console.ResetColor();
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\n\t" + "Помилка. Неправильно введена операція.");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                        break;
                                }
                                string line = Surname + "\t" + Name + "\t" + Patronymic + "\t" + Position + "\t" + Payment + "\t" + SignSalary;
                                R[number] = line;
                                File.WriteAllLines("InputFile.txt", R);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Успішно виконано!");
                                Console.ResetColor();
                            }
                        }
                        ID++;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такого номеру не існує");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\nНатисніть Enter для продовження");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
        static void Blinker(string text)//, int milliseconds
        {
            Console.Clear();
            //string name = "Your Text";
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(text);
                Thread.Sleep(100); //Break, milliseconds
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
}
