using System;
using System.Runtime.Intrinsics.Arm;
using static Student;
public class Program
{
    public static void Main()
    {
        var pavel = new Student("Кузнецов", "Павел", "Николаевич", "БВ311");
        // Тестовое заполнение и вывод на Экран
        Random random = new Random();
        int volume = 0; // рандомно считает количество оценок которые добавим в предмет
        int grade = 0; // оценка для генерации и добавления
        foreach (Subject subject in Enum.GetValues(typeof(Subject)))
        {
            volume = random.Next(3, 8);
            for (int i = 0; i < volume; ++i)
            {
                grade = random.Next(8, 12);
                pavel.AddRatSub(subject, grade);
            }
        }
        Console.WriteLine("Группа {1}, Студент {0}", pavel.Fio, pavel.Group);
        foreach (Subject subject in Enum.GetValues(typeof(Subject)))
        {
            Console.WriteLine("Предмет {0}.", subject.ToString());
            Console.Write("Оценки: ");
            if (pavel.GetGradesForSubject(subject).Count > 0)
            {
                Console.Write("Оценки: ");
                Console.WriteLine(string.Join(", ", pavel.GetGradesForSubject(subject)));
                Console.WriteLine("Средняя оценка по предмету {0} равняется {1}", subject.ToString(), pavel.AverageRatSubject(subject));
            }
            else
            {
                Console.WriteLine("Оценок нету!");
            }
        }
        Console.WriteLine("Общая средняя оценка = " + pavel.AverageRat());
    }
}
class Student
{
    public enum Subject { Informatics, LanguageC, LanguageCPP, LanguageHTMLCSS, Pattern, LanguageCSharp, DataBase }
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
            _fio = String.Concat(_latName," ", _firstName, " ", _middleName);
        } 
    }
    private string _fio {  get; set; } 
    public string Fio { get { return _fio; } }
    private string _group { get; set; } // Можно дополнительно реализовать класс группа и сдесь записать ссылку на определенную группу
    public string Group { get { return _group; } set { _group = value; } } // при реализации класса группы в сеттере можно реализовать метод смены группы
    
    private Dictionary<Subject, List<int>> _listGrades { get; set; } = new Dictionary<Subject, List<int>>();
    //public Dictionary<Subject, List<int>> ListGrades { get { return _listGrades; } }
    public Student(string latName, string firstName, string middleName, string group)
    {
        _latName = latName;
        _firstName = firstName;
        _middleName = middleName;
        _fio = String.Concat(_latName, " ", _firstName, " ", _middleName);
        _group = group;
    }
    // Методы
    public void TransferGroup (string group)
    {
        // при наличии отдельного класса группы, производится перемещение студента
        // до реализации вызывается обычный метод смены названия
        Group = group;
    }
    public double AverageRatSubject (Subject subject) // средний бал по конкретному предмету
    {
        if (_listGrades.ContainsKey(subject) && _listGrades[subject].Count > 0)
        {
            return (double)_listGrades[subject].Average();
        }
        return 0;
    }
    public double AverageRat() // общий средний бал по  студенту
    {
        double average = 0;
        int sum = 0;
        int count = 0;
        foreach (var list in _listGrades)
        {
            sum += list.Value.Sum();
            count += list.Value.Count();
        }
        if (count != 0)
            average = (double)sum / count;
        return average;
    }
    public void AddRatSub(Subject subject, int rat) // добавление оценки в конкретный предмет
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
    public List<int> GetGradesForSubject(Subject subject) // доп метод для вывода на экран
    {
        if (_listGrades.ContainsKey(subject))
        {
            return _listGrades[subject];
        }
        return new List<int>();
    }
}
