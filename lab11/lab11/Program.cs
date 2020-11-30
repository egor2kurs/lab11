using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            List<Car> CarList = new List<Car>();//2
            int[][] marks = new int[3][];
            marks[0] = new int[4] { 3, 2, 4, 6 };
            marks[1] = new int[4] { 6, 7, 8, 7 };
            marks[2] = new int[4] { 9, 8, 9, 8 };
            Console.Write("Введите n: ");//1
            n = Convert.ToInt32(Console.ReadLine());
            string[] arr = new string[12] { "December", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November" };
            IEnumerable<string> months = from x in arr
                                         where x.Length < n
                                         select x;//линкью запрос
            foreach (string x in months)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("Зимние и летние месяцы:");
            IEnumerable<string> WinterAndSummer = arr
                .Take(3)
                .Concat(arr.Take(9).Skip(6));//пропустить 6,но взять 9
            foreach (string x in WinterAndSummer)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("В алфавитном порядке:");
            IEnumerable<string> AlphabetMonths = arr
                .OrderBy(s => s);//запрос сортировки
            foreach (string x in AlphabetMonths)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("Содержащие букву \"u\" и с динной больше 4-х символов:");
            IEnumerable<string> AnotherMonths = arr
                .Where(s => (s.Contains('u')) && (s.Length > 4));
            foreach (string x in AnotherMonths)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            CarList.Add(new Car("EBMW(bad)", "Car", marks[0]));//4
            CarList.Add(new Car("CVolvo(norm)", "Car", marks[1]));
            CarList.Add(new Car("BMazda(cool)", "Car", marks[2]));
            CarList.Add(new Car("ASRE1", "car 1", new int[4] { 6, 5, 4, 5 }));
            CarList.Add(new Car("DSRE2", "car 2", new int[4] { 7, 7, 6, 5 }));

            Console.WriteLine("Bad cars:");
            IEnumerable<Car> BadCar = from x in CarList
                                                  where x.getMin() < 4
                                                  select x;//сохраняем в бэдкар
            foreach (Car x in BadCar)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.Write("Сумма баллов выше заданной:\nВведите число: ");
            int sum = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Car> SumCar = from x in CarList
                                                     where x.getSum() > sum
                                                     select x;
            foreach (Car x in SumCar)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("Упорядоченные по алфавиту:");
            IEnumerable<Car> AlphabetCar = CarList
                .OrderBy(s => s.mark);//упорядочить по полю марки машины
                
            foreach (Car x in AlphabetCar)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("Три с самой низкой успеваемостью:");
            IEnumerable<Car> Badcars = CarList
                .OrderBy(s => s.getSre())
                .Take(3);
            foreach (Car x in Badcars)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("Свой запрос:");
            IEnumerable<string> cars = CarList
                .OrderBy(s => s.getSre())//осортировали по среднней оценке
                .Where(s => s.getMin() > 3)//оторбрали 
                .Skip(1)//пропустилои первый
                .Select(s => s.mark + " " + s.model)//соххранили
                .Concat(AlphabetCar.Select(s => s.mark + " " + s.model));
            foreach (string x in cars)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            string[] names = { "Никита", "Илья", "Димас", "Сеня" };
            int[] key = { 1, 4, 5, 7 };
            var sometype = names
            .Join(
            key, // внутренняя
            w => w.Length, // внешний ключ выбора длина имени
            q => q, // внутренний ключ выбора значения 4,5,7
            (w, q) => new // результат сравнивается
{
                id = w,
                name = string.Format("{0} ", q),
            });
            foreach (var item in sometype)
                Console.WriteLine(item);//каждый такой объект(пара) выводим на консоль

            Console.Read();
        }
    }
}
