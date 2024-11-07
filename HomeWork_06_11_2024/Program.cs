/*
ДЗ Словари (Добавить свой Exception)

Создайте Dictionary, который будет хранить информацию о пользователе: логин, почту, пароль, номер телефона, 
время последнего захода в сеть. Все значения храните в текстовом формате.

Разработайте следующие методы:

1) Аутентификация. Принимает две строки: логин и пароль. Возвращает true, если логин и пароль совпадают, и false в ином случае.
В случае успеха время последнего захода в сеть обновляется (DateTime.Now.ToString()).

2) Смена пароля. Принимает две строки: номер телефона и новый пароль. 
Если указанный номер телефона совпадает с тем, что указан в словаре, 
пароль в словаре меняется, и метод возвращает true.
Иначе метод возвращает false.

3) Добавление даты рождения. Принимает одну строку: дату рождения. 
Если в словаре нет даты рождения, она добавляется. Если дата рождения есть, 
выводится сообщение о том, что дата уже добавлена, а сама дата не обновляется.
*/

using System;

public class Program
{
    public static void Main()
    {

    }
}
// Методы

// Классы
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
    public DateTime Entry { get { return _entry; } }
    // конструктор
    public User(string login, string password, string email, string phone) 
    { 
        _login = login;
        _password = password;
        _email = email;
        _phone = phone;
        _entry = DateTime.Now;
    }
    // Методы

}

public class MyException : Exception // Свой класс Эксепшен
{
    public MyException() : base("Произошла ошибка в приложении!") { }
    public MyException(string message) : base(message) { }
    public MyException(string message,  Exception innerException) : base(message, innerException) { }
}