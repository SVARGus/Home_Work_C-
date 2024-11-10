/*
ДЗ Словари (Добавить свой Exception)

Создайте Dictionary, который будет хранить информацию о пользователе: логин, почту, пароль, номер телефона, 
время последнего захода в сеть. Все значения храните в текстовом формате.

Разработайте следующие методы:

1) Аутентификация. Принимает две строки: логин и пароль. Возвращает true, если логин и пароль совпадают, и false в ином случае.
В случае успеха время последнего захода в сеть обновляется (DateTime.Now.ToString()).

2) Смена пароля. Принимает две строки: номер телефона и новый пароль. (для данного задания придется делать отдельный метод и отдельный Dictionary, где ключ уже будет номер телефона)
Если указанный номер телефона совпадает с тем, что указан в словаре, 
пароль в словаре меняется, и метод возвращает true.
Иначе метод возвращает false.

3) Добавление даты рождения. Принимает одну строку: дату рождения. 
Если в словаре нет даты рождения, она добавляется. Если дата рождения есть, 
выводится сообщение о том, что дата уже добавлена, а сама дата не обновляется.
// Для данного задания я переделал Эксепшен, чтобы выдавал Эксепшен, если при создании пользователя будет введена дата раньше 1900

Задание по Exception от 06.11.2024 
Создать собственные исключения: 
WrongPasseordException (генерируется при неправильном пароле)
WrongDateExeption (генерируется, если дата раньше 1900 года)
*/

using System;
using System.Collections.Generic;
using System.Net;

public class Program
{
    public static void Main()
    {
        DateTime birth = new DateTime(1989, 1, 24);
        User user1 = new User("Pavel", "Rt.2", "kuznetsovpn@mail.ru", "89219711279", birth);
        birth = new DateTime(1988, 3, 24);
        User user2 = new User("Ron", "FTr#54", "fggh@mail.ru", "89219711278", birth);
        birth = new DateTime(1990, 6, 10);
        User user3 = new User("Kail", "Rt&2", "kony@mail.ru", "89219711260", birth);
        // Тестовый пользователь для проверки
        //birth = new DateTime(1800, 6, 10);
        //User userTest = new User("Test", "test", "test@mail.ru", "89219711279", birth); // не верно задан пароль и выкидывает Эксепшен
        // Dictionary где ключ это логин
        Dictionary<string, User> UsersLogin = new Dictionary<string, User> { };
        UsersLogin.Add(user1.Login, user1);
        UsersLogin.Add(user2.Login, user2);
        UsersLogin.Add(user3.Login, user3);
        //UsersLogin.Add(userTest.Login, userTest);
        try
        {
            if (UsersLogin.ContainsKey("Pavel"))
            {
                Authorization("Pavel", UsersLogin);
            }
            else
            {
                Console.WriteLine("Данный пользователь отсуствует");
            }
        }
        catch (WrongPasswordException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Происзошла непредвиденная ошибка: {ex.Message}");
        }
        // Dictionary где ключ это телефон
        Dictionary<string, User> UsersPhone = new Dictionary<string, User> { };
        UsersPhone.Add(user1.Phone, user1);
        UsersPhone.Add(user2.Phone, user2);
        UsersPhone.Add(user3.Phone, user3);
        try
        {
            if (UsersPhone.ContainsKey("89219711279"))
            {
                UsersPhone["89219711279"].RePassword("Rt.2", "Henry45!");
            }
            else
            {
                Console.WriteLine("Данный пользователь отсуствует");
            }
        }
        catch (MyException ex)
        {

            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        Console.WriteLine($"Давайте сменим пароль в пользователе {user1.Login}");
        user1.RePassword(user1.Password, "RtT%23");
        birth = new DateTime(1890, 1, 24);
        try
        {
            User userError = new User("Pavel2", "Rt.2", "kuznetsovpn@mail.ru", "89219711299", birth);
        }
        catch (WrongDateExсeption ex)
        {
            Console.WriteLine($"Ошибка {ex.Message}");
        }
    }
    // Методы
    public static bool Authorization(string login, Dictionary<string, User> users)
    {
        Console.WriteLine("Введите пароль");
        string pasword = Console.ReadLine();
        if (users[login].Password == pasword)
        {
            users[login].Entry = DateTime.Now; // При успешном входе обновляет время последнего входа
            Console.WriteLine("Авторизация прошла успешно.");
            return true;
        }
        else
        {
            throw new WrongPasswordException();
        }
    }
    public static void RePassword(string phone, string pasword, Dictionary<string, User> users)
    {
        // метод реализовал в самом классе User
    }
}
// Методы

// Классы для 1 задания (Аутентификация)
public class User // все методы будут реализованы в отдельном классе, ключем для Dictionary будет логин
{
    private string _login {  get; set; }
    public string Login { get { return _login; } }
    private string _password { get; set; }
    public string Password { get { return _password; } }
    private string _email { get; set; }
    public string Email { get { return _email; } }
    private string _phone { get; set; }
    public string Phone { get { return _phone; } }
    private DateTime _entry {  get; set; }
    public DateTime Entry { get { return _entry; } set { _entry = value; } }
    private DateTime _birthday { get; set; }
    public DateTime Birthday { get { return _birthday; } }
    // конструктор
    public User(string login, string password, string email, string phone, DateTime birthday) 
    {
        _login = login;
        if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper) || !password.Any(ch => !char.IsLetterOrDigit(ch))) // Проверяем на наличие хотябы одной буквы в верхнем регистре, одной цифры и любого символа
        {
            throw new MyException("Ошибка установки пароля!!! Пароль должен содержать хотябы одну букву в верхнем регистре, одну цифру и специальный символ");
        }
        else
        {
            _password = password;
        }
        _email = email;
        _phone = phone;
        _entry = DateTime.Now;
        if (birthday.Year > 1900)
        {
            _birthday = birthday;
        }
        else
        {
            throw new WrongDateExсeption();
        }
    }
    // Методы
    public bool RePassword(string oldPassword, string newPassword)
    {
        if (oldPassword == _password)
        {
            if (!newPassword.Any(char.IsDigit) || !newPassword.Any(char.IsUpper) || !newPassword.Any(ch => !char.IsLetterOrDigit(ch))) // Проверяем на наличие хотябы одной буквы в верхнем регистре, одной цифры и любого символа
            {
                throw new WrongPasswordException("Ошибка установки пароля!!! Пароль должен содержать хотябы одну букву в верхнем регистре, одну цифру и специальный символ");
            }
            else
            {
                _password = newPassword;
            }
            return true;
        }
        else
        {
            throw new MyException("Не верно указан текуцщий пароль");
        }
    }
}
// Свой класс Ексепшен
public class MyException : Exception // Свой класс Эксепшен
{
    public MyException() : base("Произошла ошибка в приложении!") { }
    public MyException(string message) : base(message) { }
    public MyException(string message,  Exception innerException) : base(message, innerException) { }
}
// Ексепшены по ДЗ
public class WrongPasswordException : Exception
{
    public WrongPasswordException() : base("Неверный пароль.") { }
    public WrongPasswordException(string message) : base(message) { }
    public WrongPasswordException(string message, Exception innerException) : base(message, innerException) { }
}
public class WrongDateExсeption : Exception
{
    public WrongDateExсeption() : base("Дата не может быть ранее 1900 года.") { }
    public WrongDateExсeption(string message) : base(message) { }
    public WrongDateExсeption(string message, Exception innerException) : base(message, innerException) { }
}