using System;
using System.Collections.Generic;
using System.Linq;

namespace Grokking_Algorithms
{
    #region Глава 1. Знакомство с алгоритмами. Простой(тупой) и бинарный поиск.
    public class Search
    {
        /// <summary>
        /// Простой поиск или же "тупой" поиск
        /// </summary>
        /// <param name="array">Массив с числами.</param>
        /// <param name="num">Число которое нужно найти.</param>
        /// <returns>Возвращает это число, если оно присутствует в массиве, иначе вернёт 0</returns>
        public int? Dumb(int[] array, int num)
        {
            foreach (var item in array)
            {
                if (item == num) { return item; }
            }
            return null;
        }

        /// <summary>
        /// Бинарный поиск
        /// </summary>
        /// <param name="array">Массив с числами</param>
        /// <param name="num">Число которое нужно найти</param>
        /// <returns></returns>
        public int? Binary(int[] array, int num)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int guess = array[mid];

                if (guess == num) { return guess; }

                else if (guess > num) { high = mid - 1; }
                else { low = mid + 1; }
            }
            return null;
        }
    }
    #endregion
    #region Глава 2. Сортировка выбором
    public class Sort
    {
        // Для того чтобы воспользоваться методом сортировки выбором, предварительно нужно найти наименьший элемент массива

        /// <summary>
        /// Метод для поиска наименьшего элемента массива
        /// </summary>
        /// <param name="arr">Входящий массив из метода сортировки</param>
        /// <returns>Индекс наименьшего массива</returns>
        private static int FindSmallest(int[] arr)
        {
            var smallest = arr[0];// Для хранения наименьшего значения
            var smallestIndex = 0;// Для хранения индекса наименьшего значения

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                    smallestIndex = i;
                }
            }
            return smallestIndex;
        }

        // Сам метод сортировки выбором
        /// <summary>
        /// Метод сортировки выбором
        /// </summary>
        /// <param name="arr">Входящий массив который нужно отсортировать</param>
        /// <returns>Отсортированный массив</returns>
        public static int[] SelectionSorting(int[] arr)
        {
            int[] newArr = new int[arr.Length];

            for (int i = 0; i < newArr.Length; i++)
            {
                int smallestIndex = FindSmallest(arr); // Находит индекс наименьшего элемента в массиве 
                newArr[i] = arr[smallestIndex];// Добавляет элемент в новый массив по наименьшему индексу

                // Изменяю входящий массив
                arr[smallestIndex] = arr[arr.Length - 1];// копирую последнее значения массива в индекс наименьшего элемента 
                Array.Resize(ref arr, arr.Length - 1);// сокращаю массив на 1 элемент с конца.

            }

            return newArr;
        }
    }
    #endregion
    #region Глава 3. Рекурсия

    public class Rekursion
    {
        /// <summary>
        /// Вычисление факториала
        /// </summary>
        /// <param name="n">Число возведенное в факториал</param>
        /// <returns>Результат</returns>
        public static int Factorial(int n)
        {
            if (n == 1) { return 1; }
            else { return n * Factorial(n - 1); }
        }
    }
    #endregion
    #region Глава 4. Быстрая сортировка
    #region Упражнения
    public class SumRekursion
    {
        #region Упражнение 4.1 Напишите код для функции sum()
        /// <summary>
        /// Находим сумму всех элементов с помощью рекурсии
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <returns>Результат суммы</returns>
        public static int Sum(int[] arr)
        {
            int total = 0;
            if (arr.Length == 0) { return 0; }// когда кол-во элементов в массиве будет = 0, то тогда будет выполняться условие выхода
            else
            {
                total = arr[arr.Length - 1];// присв последнее значение массива
                Array.Resize(ref arr, arr.Length - 1);// сокращаем массив на 1 элемент с конца
                return total + Sum(arr);// рекурсия 
            }
        }


        #endregion
        #region Упражнение 4.2 Напишите рекурсивную функцию для подсчета элементов в списке
        /// <summary>
        /// Метод находит количество элементов в массиве с помощью рекурсии. Тот же .Length
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int SumElements(int[] arr)
        {
            if (arr.Length == 0) { return 0; }// когда кол-во элементов в массиве будет = 0, то тогда будет выполняться условие выхода
            else
            {
                Array.Resize(ref arr, arr.Length - 1);// сокращаем массив на 1 элемент с конца
                return 1 + SumElements(arr);// рекурсия 
            }
        }

        #endregion
        #region Упражнение 4.3 Найдите наибольшее числов в списке
        public static int Max(int[] arr)
        {
            int[] temp = arr;
            int subMax;
            if (arr.Length == 2)
            {
                if (arr[0] > arr[1]) { return arr[0]; }
                else { return arr[1]; }
            }
            Array.Resize(ref temp, temp.Length - 1);
            subMax = Max(temp);
            if (arr[arr.Length - 1] > subMax) { return (arr[arr.Length - 1]); }
            else { return subMax; }
        }
        #endregion
    }
    #endregion
    #region Быстрая сортировка
    public class FastSort
    {
        /// <summary>
        /// Производим быструю сортировку
        /// </summary>
        /// <param name="list">Список который нужно отсортировать</param>
        /// <returns>сам список</returns>
        public static IEnumerable<int> QuickSotring(IEnumerable<int> list)
        {
            if (list.Count() < 2) { return list; }// Базовый случай: список с 0 и 1 элементом уже отсортированы
            else // Рекурсивный случай
            {
                var pivot = list.First(); // Первый элемент списка
                var less = list.Skip(1).Where(i => i <= pivot);// Подмассив всех элементов, меньших опорного
                var greater = list.Skip(1).Where(i => i > pivot);// Подмасив всех элементов, больших опорного
                return QuickSotring(less).Union(new List<int> { pivot }).Union(QuickSotring(greater)); // Объединение подмассивов
            }
        }


        #region Неудавшаяся попытка с массивом
        //public static int[] Quicksort(int[] mass)
        //{
        //    if (mass.Length < 2) { return mass; }
        //    else
        //    {
        //        int[] pivot = new int[] { }; pivot[0] = mass[0];
        //        int[] less = { }; int[] greater = { };

        //        foreach (var item in mass)
        //        {
        //            int i = 0; int j = 0;
        //            if (item <= pivot[0]) { less[item] = mass[i++]; }
        //            else { greater[item] = mass[j++]; }
        //        }

        //        return (Quicksort(less).Concat(pivot).ToArray()).Concat(Quicksort(greater)).ToArray();


        //    }
        //}
        #endregion

    }
    #endregion
    #endregion
    #region Глава 5. Хеш-таблицы
    public class HashTables
    {
        #region Исключение дубликатов
        /// <summary>
        /// Создаем статичное объект словаря(наша хеш-таблица) которое будет пополняться и проводится проверка на наличие
        /// Пока оно пустое. ()
        /// </summary>
        private static readonly Dictionary<string, bool> voted = new Dictionary<string, bool>();

        /// <summary>
        /// Проверка человека на то что он голосовал на выборах. Он не проголосует более 1 раза.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Реакция коммиссии</returns>
        public static string Check(string name)
        {
            if (voted.ContainsKey(name)) { return "Kick them out!!!"; }// если имя есть в хеш-таблице, его не допускают

            else //Если имя встретилось впервые, то его заносят в Хеш-таблицу, присваивают ему ключ "true" и позволяют проголосовать
            {
                voted.Add(name, true);
                return "Let them vote!";
            }
        }
        #endregion

    }
    #endregion
    #region Глава 6. Поиск в ширину
    public class BreadthFirstSearch
    {
        /// <summary>
        /// Создаем хеш-таблицу.
        /// В идеале мы должны бы были ее заполнить со всеми отношениями одного чела к массиву его друзей
        /// </summary>
        public Dictionary<string, string[]> graph = new Dictionary<string, string[]>();

        /// <summary>
        /// Метод по поиску в ширину
        /// </summary>
        /// <param name="name">с кого начинаем поиск</param>
        /// <returns>результат есть ли вообще продавец</returns>
        public bool Search(string name)
        {
            // создание новой очереди с добавлением всех соседей {name} с помощью хеш-таблицы graph[name]
            var searchQueue = new Queue<string>(graph[name]);

            // Этот список будет использоваться для отслеживания уже проверенных людей
            var searched = new List<string>();

            while (searchQueue.Any())// Пока очередь не пуста... .Any() Отвечает за присутствие кого-либо(LINQ)
            {
                var person = searchQueue.Dequeue();//Из очереди извлекается первый человек. 
                if (!searched.Contains(person))// Человек проверяется только в том случае, если он не проверялся ранее
                {
                    if (PersonIsSeller(person))// Проверяем, является ли этот человек продавцом манго
                    {
                        Console.WriteLine($"{person} is a mango seller");// Сообщаем что мы нашли продавца манго
                        return true;
                    }
                    else// Если он не является продавцом манго
                    {
                        //Все друзья этого человека добавляются в очередь поиска.
                        searchQueue = new Queue<string>(searchQueue.Concat(graph[person]));//.Concat (LINQ)
                        //Человек помечается как уже проверенный
                        searched.Add(person);
                    }
                }
            }
            // Если выполнение дошло до этой строк, значит, в очереди нет продавца манго
            return false;
        }

        /// <summary>
        /// Проверяем, является ли человек продавцом манго?
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool PersonIsSeller(string name)
        {
            return name.EndsWith("m");
            //String.EndsWith() Определяет, совпадает ли конец данного экземпляра строки с указанной строкой.
        }

    }
    #endregion



    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 2, 4, 1, 3 };
            //int[] newArr = Sort.SelectionSorting(arr);

            //Console.WriteLine(string.Join(Environment.NewLine, newArr));
            //int n = Convert.ToInt32(Console.ReadLine());
            //n = Rekursion.Factorial(n);
            //Console.WriteLine(n);
            //int[] arr = { 2, 4, 1, 10, 346, 3, 5 };
            //Console.WriteLine(SumRekursion.Sum(arr));

            //Console.WriteLine(SumRekursion.SumElements(arr));
            //Console.WriteLine(SumRekursion.Max(arr));
            //Console.WriteLine(FastSort.QuickSotring(arr));
            //Console.Write(string.Join(", ", FastSort.QuickSotring(arr)));// Join можно использовать без Environment.NewLine 
            #region 5 Check Voted
            //string str;
            //for (; ; )
            //{
            //    str = Console.ReadLine();
            //    if (str  == "q") { break; }
            //    Console.WriteLine(HashTables.Check(str));
            //}
            #endregion
        }
    }
}
