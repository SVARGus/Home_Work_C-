/*
Задание 1 (с урока - доделано):

Вы разрабатываете систему для корпоративного такси.

В системе есть:
Один корпоративный аккаунт с единым для всех балансом.

Класс Account с полем Balance.
Сотрудники, которые могут заказывать такси и списывать деньги с корпоративного счета.

Класс User с полем Id и методом GetTaxi().
Метод GetTaxi() должен выполнять:
Проверять, что баланс не отрицателен. Если он меньше 0, выбрасывать исключение.
Проверять, что баланса хватает для поездки. Если нет, завершать метод сразу.
Если денег хватает, начинать имитацию поездки (через Thread.Sleep(300)).
После завершения поездки списывать деньги с баланса.
Требования:
Создать 10 сотрудников и запустить вызов такси для каждого в потоке.
После запуска вызова для каждого сотрудника останавливать выполнение потока на 150 мс.
Реализовать логику так, чтобы не допустить отрицательного баланса.
Совет:
Сначала реализуйте логику без учета многопоточности. Добавьте потоки уже после того, как основные алгоритмы списания денег будут реализованы.

Задание 2
Сгенерируйте три списка int (в каждом списке должно быть не менее 50 элементов).
Запустите сортировку всех трех списков в разных потоках.
В двух из трех потоков перед каждой сортировкой добавьте Thread.Sleep(n), при этом в обоих случаях n должен быть разным.
Объедините отсортированные списки и выведите результат на экран.
*/

using System.Threading;

public class Program
{
    public static void Main()
    {
        // Задание 1
        Account company = new Account(4500);
        List<User> users = new List<User>()
        { new User(0), new User(1), new User(2), new User(3), new User(4), new User(5),
        new User(6), new User(7), new User(8), new User(9) };
        Random rand = new Random();
        List<Thread> threads = new List<Thread>();
        object locker = new(); // заглушка
        foreach (var user in users)
        {
            Thread userThread = new Thread(() => user.GetTaxi(company, rand.Next(500, 1001), locker));
            threads.Add(userThread);
            userThread.Start();
            Thread.Sleep(150);
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }
        Console.WriteLine();
        Console.WriteLine();

        // Задание 2
        Random rand1 = new Random();
        List<int> list1 = Enumerable.Range(0, 50).Select(_ => rand1.Next(1, 101)).ToList();
        Console.Write("Тестовый вывод списка чисел №1: ");
        list1.ForEach(num => Console.Write($"{num} "));
        Console.WriteLine();
        List<int> list2 = Enumerable.Range(0, 50).Select(_ => rand1.Next(1, 101)).ToList();
        Console.Write("Тестовый вывод списка чисел №2: ");
        list2.ForEach(num => Console.Write($"{num} "));
        Console.WriteLine();
        List<int> list3 = Enumerable.Range(0, 50).Select(_ => rand1.Next(1, 101)).ToList();
        Console.Write("Тестовый вывод списка чисел №3: ");
        list3.ForEach(num => Console.Write($"{num} "));
        Console.WriteLine();
        Thread threadList1 = new Thread(() =>
        {
            Console.WriteLine("Начало сортировки списка #1");
            Thread.Sleep(0);
            list1.Sort();
            Console.WriteLine("Завершена сортировка Списка #1");
        });
        Thread threadList2 = new Thread(() =>
        {
            Console.WriteLine("Начало сортировки списка #2");
            Thread.Sleep(1500);
            list2.Sort();
            Console.WriteLine("Завершена сортировка Списка #2");
        });
        Thread threadList3 = new Thread(() =>
        {
            Console.WriteLine("Начало сортировки списка #3");
            Thread.Sleep(1200);
            list3.Sort();
            Console.WriteLine("Завершена сортировка Списка #3");
        });
        List<Thread> threadLists = new List<Thread>();
        threadLists.Add(threadList1);
        threadLists.Add(threadList2);
        threadLists.Add(threadList3);
        foreach(var thread in threadLists)
        {
            thread.Start();
        }
        foreach (var thread in threadLists)
        {
            thread.Join();
        }
        Console.Write("Тестовый вывод списка чисел №1: ");
        list1.ForEach(num => Console.Write($"{num} "));
        Console.WriteLine();
        Console.Write("Тестовый вывод списка чисел №2: ");
        list2.ForEach(num => Console.Write($"{num} "));
        Console.WriteLine();
        Console.Write("Тестовый вывод списка чисел №3: ");
        list3.ForEach(num => Console.Write($"{num} "));
        Console.WriteLine();
        Console.WriteLine();
        List<int> listUnited = list1.Concat(list2).Concat(list3).ToList();
        Console.Write("Тестовый вывод объединенного списка чисел: ");
        listUnited.ForEach(num => Console.Write($"{num} "));
        Console.WriteLine();

    }
}
public class Account
{
    public int Balans { get; set; }
    public Account(int balans)
    {
        Balans = balans;
    }
}
public class User
{
    public int Id { get; set; }
    public User(int id)
    {
        Id = id;
    }

    public void GetTaxi(Account account, int price, object locker)
    {
        lock(locker)
        {
            if (account.Balans <= 0 || account.Balans < price)
            {
                Console.WriteLine($"Недостаточно средств на счете компании для заказа такси для сотрудника компании {Id}. Стоимость поездки = {price}");
            }
            else
            {
                Console.WriteLine($"Сотрудник компании {Id} начал поездуку");
                Thread.Sleep(300);
                account.Balans -= price;
                Console.WriteLine($"Поезда сотрудника {Id} завершена, стоимость поездки составляет {price} \nБаланс компании {account.Balans}");
                //Console.WriteLine($"Баланс компании {account.Balans}");
            }
        }
    }
}