using System;
using lr12;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Numerics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace programmingCs
{
    class Program
    {
        private static List<company> workers = new List<company>();
        public static int num;
        public static void AddWorker() //Функция добавления нового работника
        {
            string fullName, gender;
            int salary, incSalary, percent, norm;
            int group;
            //company worker;

            Console.Write("\nВыберите тип работника:\n" +
                "'1' - Почасовой\n'2' - Комиссионный\n" +
                "'Другой вариант' - Вернуться назад\nВВОД: ");
            group = Convert.ToInt32(Console.ReadLine());
            if (group != 1 && group != 2) return;
            Console.Write("Введите ФИО работника: ");


            fullName = Console.ReadLine();
            Console.Write("Введите пол работника: ");
            gender = Console.ReadLine();

            switch (group)
            {
                case 1:
                    Console.Write("Введите ставку за час: ");
                    salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите повышенную ставку за час: ");
                    incSalary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите норму часов: ");
                    norm = Convert.ToInt32(Console.ReadLine());
                    workers.Add(new hourly(fullName, gender, salary, incSalary, norm));
                    num++;
                    break;
                case 2:
                    Console.Write("Введите фиксированный оклад: ");
                    salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите процент за каждую продажу: ");
                    percent = Convert.ToInt32(Console.ReadLine());
                    workers.Add(new comission(fullName, gender, salary, percent));
                    num++;
                    break;
            }
        }

        public static void Dismiss() //Функция увольнения
        {
            int worker;
            while (true)
            {
                Console.Write("\nВведите номер работника ('0' - Вернуться назад): ");
                worker = Convert.ToInt32(Console.ReadLine());
                if (worker == 0) return;
                workers.RemoveAt(worker);
                Console.Write("Работник успешно уволен\n");
                break;
            }
        }

        public static void SimulateWork(int day, int num)
        {

            Console.WriteLine("\nСИМУЛЯЦИЯ НАЧАЛАСЬ\n");
            for (int i = 1; i <= day; i++)
            {
                Console.WriteLine("День " + i);
                for (int j = 0; j < num; ++j)
                {
                    workers[j].Work(1 + 6);
                    if (i % 15 == 0)
                    {
                        Console.WriteLine("ДЕНЬ РАСЧЕТА ЗАРПЛАТЫ\n" + workers[j].fullName);
                        workers[j].CalculateSalary();
                        Console.WriteLine(workers[j].salary + "rub");
                    }
                    Console.WriteLine(workers[j].fullName);
                }
                //for (auto* it : workers) cout << *it;
            }
        }

        public static void PutList() //Функция вывода вектора
        {
            for (int i = 0; i < num; ++i)
                Console.WriteLine(i + 1 + ". " + workers[i].fullName);
        }

        public static void Serialize()

        {

            FieldInfo[] fields = typeof(List<company>).GetFields(BindingFlags.Static | BindingFlags.NonPublic);

            object[,] a = new object[fields.Length, 2];

            int i = 0;

            foreach (FieldInfo field in fields)

            {

                a[i, 0] = field.Name;

               

                i++;

            };

            Stream f = File.Open("serialize.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(f, a);

            f.Close();
        }
        public static void Deserialize()

        {

            FieldInfo[] fields = typeof(List<company>).GetFields(BindingFlags.Static | BindingFlags.NonPublic);

            object[,] a;

            Stream f = File.Open("serialize.dat", FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            a = formatter.Deserialize(f) as object[,];

            f.Close();

            int i = 0;

            foreach (FieldInfo field in fields)

            {

                if (field.Name == (a[i, 0] as string))

                    field.SetValue(null, a[i, 1]);

                i++;

            };

        }

        

        static void Menu()
        {
            int ans;
            while (true)
            {
                Console.Write("\nСИСТЕМА РАСЧЁТА ЗАРПЛАТЫ\n\n" +
                    "Введите:\n" +
                    "'1' - Чтобы добавить работника\n" +
                    "'2' - Чтобы вывести список работников\n" +
                    "'3' - Чтобы уволить работника\n" +
                    "'4' - Чтобы смоделировать работу\n" +
                    "'5' - Чтобы провести сериализация.\n" +
                    "'6' - Чтобы провести десиреализацию\n" +
                    "'0' - Чтобы выйти из программы\n" +
                    "ВВОД: ");

                ans = Convert.ToInt32(Console.ReadLine());

                switch (ans)
                {
                    case 1:
                        AddWorker();
                        break;
                    case 2:
                        PutList();
                        break;
                    case 3:
                        Dismiss();
                        break;
                    case 4:
                        Console.WriteLine("Введите количество дней");
                        int days;
                        days = Convert.ToInt32(Console.ReadLine());
                        SimulateWork(days, num);
                        break;
                    case 5:
                        Serialize(); //Функция сериализации
                        Console.WriteLine("Сериализация проведена успешно");
                        break;
                    case 6:
                        Deserialize(); //Функция десериализации
                        Console.WriteLine("Десериализация проведена успешно");
                        break;
                    case 0:
                        System.Environment.Exit(0); //Функция выхода из программы
                        break;
                    default:
                        Console.Write("\nВыбран неверный вариант. Попробуйте ещё раз\n");
                        break;
                }
            }
        }
        static void Main()
        {

            Menu();
        }
    }
}

