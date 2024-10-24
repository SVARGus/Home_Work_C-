using System;
using System.Runtime.Intrinsics.Arm;
public class Program
{
    public static void Main()
    {

    }
}
class Student
{
    enum Subject { Informatics, LanguageC, LanguageCPP, LanguageHTMLCSS, Pattern, LanguageCSharp, DataBase }
    private string _latName { get; set; }
    public string LastName 
    { 
        get { return _latName; } 
        set 
        { 
            _latName = value;
            _fio = String.Concat(_latName, _firstName, _middleName);
        }
    }
    private string _firstName { get; set; }
    public string FirstName 
    { 
        get { return _firstName; } 
        set 
        { 
            _firstName = value;
            _fio = String.Concat(_latName, _firstName, _middleName);
        }
    }
    private string _middleName { get; set; } 
    public string MiddleName 
    { 
        get { return _middleName; } 
        set 
        { 
            _middleName = value;
            _fio = String.Concat(_latName, _firstName, _middleName);
        } 
    }
    private string _fio {  get; set; } 
    public string Fio { get { return _fio; } }
    private string _group { get; set; } // Можно дополнительно реализовать класс группа и сдесь записать ссылку на определенную группу
    public string Group { get { return _group; } set { _group = value; } } // при реализации класса группы в сеттере можно реализовать метод смены группы
    private Dictionary<Subject, List<int>> _listGrades { get; set; }
    // Методы
    void TransferGroup (string group)
    {
        // при наличии отдельного класса группы, производится перемещение студента
        // до реализации вызывается обычный метод смены названия
        Group = group;
    }
    double AverageRatSubject (Subject subject) // средний бал по конкретному предмету
    {
        double average = 0;
        // реализация
        return average;
    }
    double AverageRat() // общий средний бал по  студенту
    {
        double average = 0;
        int sum = 0;
        int count = 0;
        foreach (Subject subject in Enum.GetValues(typeof(Subject)))
        {
            if (_listGrades.ContainsKey(subject))
            {
                sum += _listGrades[subject].Sum();
                count += _listGrades[subject].Count();
            }
        }
        average = (double)sum / count; // проверка на ноль не сделана!!
        return average;
    }
    void AddRatSub(Subject subject, int rat)
    {
        if (_listGrades.ContainsKey(subject))
        {
            _listGrades[subject].Add(rat);
        }
        else
        {
            _listGrades[subject] = new List<int> { rat };
        }
    }
}
