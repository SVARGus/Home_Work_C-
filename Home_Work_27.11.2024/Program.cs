/*
Разработать классы:

User. Имеет Id и асинхронный метод ReadMessage
Возвращает отчет о прочтении формата "Сообщение прочитано {userId} {текст сообщения}"

UserDatabse. Имеет коллекцию пользователей и асинхронный метод GetUserById, 
возвращающий пользователя по его Id

MailServer, который имеет асинхронный метод SendMessageToUser.
Метод принимает сообщение и id пользователя и возвращает сообщение от пользователя 
Метод достает из UserDatabse пользователя и "заставляет" его читать сообщение.

С помощью MailServer запустите отправку сообщений пяти пользователям
В каждом случае получите отчет о прочтении и выведете его на экран

*/
public class Program
{
    public static async Task Main()
    {
        List<User> users = new List<User>
        {
            new User(1), new User(2), new User(3), new User(4), new User(5), new User(6), new User(7), new User(8), new User(9), new User(10), new User(11), new User(12), new User(13), new User(14), new User(15), new User(16),
            new User(17), new User(18), new User(19), new User(20), new User(21), new User(22), new User(23), new User(24), new User(25), new User(26), new User(27), new User(28), new User(29), new User(30)

        };
        UserDatabase userDatabase = new UserDatabase(users);
        MailServer mailServer = new MailServer();
        var tasks = new List<Task>();
        for (int i = 1; i < 35; i++)
        {
            tasks.Add(mailServer.SendMessageToUser("Тестовая проверка подписки", i, userDatabase));
        }
        await Task.WhenAll(tasks);
        Console.WriteLine("Все сообщения отправлены");
    }
}
public class User
{
    public int Id { get; set; }
    public async Task<string> ReadMessage(string message)
    {
        await Task.Delay(100);
        string report = $"Сообщение прочитано пользователем {Id}: {message}";
        Console.WriteLine(report);
        return report;
    }
    public User(int id)
    {
        Id = id;
    }
}
public class UserDatabase
{
    public List<User> Users { get; set; } = new List<User>();
    public async Task<User> GetUserById(int searchId)
    {
        await Task.Delay(70);
        return Users.Find(user => user.Id == searchId);
    }
    public UserDatabase(List<User> users)
    {
        Users = users;
    }
}
public class MailServer
{
    public async Task SendMessageToUser(string message, int userId, UserDatabase userDatabase)
    {
        var userInstance = await userDatabase.GetUserById(userId);
        if (userInstance != null)
        {
            await userInstance.ReadMessage(message);
        }
        else 
        {
            Console.WriteLine($"Пользователь с ID {userId} не найден.");
        }
    }
}