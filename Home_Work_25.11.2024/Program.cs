/*
Задание:

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
*/

public class Program
{
    public static void Main()
    {
        Account company = new Account(4500);
        List<User> users = new List<User>()
        { new User(0), new User(1), new User(2), new User(3), new User(4), new User(5),
        new User(6), new User(7), new User(8), new User(9) };
        Random rand = new Random();
        foreach (var user in users)
        {
            user.GetTaxi(company, rand.Next(500, 1001));
            Thread.Sleep(150);
        }
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

    public void GetTaxi(Account account, int price)
    {
        if (account.Balans <= 0 || account.Balans < price)
        {
            throw new Exception("Недостаточно средств на счете компании для заказа такси");
        }
        else
        {
            Thread myThread = new (() => Print(account, price));
            myThread.Start();
        }
    }
    public void Print (Account account, int price)
    {
        Console.WriteLine($"Сотрудник компании {Id} начал поездуку");
        Thread.Sleep(300);
        account.Balans -= price;
        Console.WriteLine($"Поезда сотрудника {Id} завершена, стоимость поездки составляет {price}");
        Console.WriteLine($"Баланс компании {account.Balans}");
    }
}