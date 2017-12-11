using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

struct Student : IComparable<Student>
{
    public string name;
    public string group;
    public int income;//доход
    public int averageScore;//средний балл
    public Student(string name, string group, int income, int averageScore)
    {
        this.name = name;
        this.group = group;
        this.income = income;
        this.averageScore = averageScore;
    }
    public int CompareTo(Student other)
    {
        if (this.averageScore < other.averageScore) return 1;
        if (this.averageScore > other.averageScore) return -1;
        else return 0;
    }
}
class Program
{
    static void Main(string[] args)
    {
        int minIncome = 4000;
        List<Student> students = new List<Student>();
        students.Add(new Student("Неглядейко", "Х-15", 7300, 7));
        students.Add(new Student("Боброва", "Х-15", 25000, 3));
        students.Add(new Student("Николаев", "П-9", 15000, 5));
        students.Add(new Student("Ленивцев", "Х-4", 5800, 16));
        students.Add(new Student("Корейчук", "Х-15", 3000, 4));
        students.Add(new Student("Лобанов", "Х-15", 10900, 12));

        List<Student> studentsFirstQueue = students.Cast<Student>().Where(x => x.income < minIncome * 2).ToList();
        studentsFirstQueue.Sort();
        List<Student> studentsSecondQueue = students.Cast<Student>().Where(x => x.income > minIncome * 2).ToList();
        studentsSecondQueue.Sort();
        students = studentsFirstQueue.Concat(studentsSecondQueue).ToList();

        Console.WriteLine("Очередь на получение студентами общежития:");
        int count = 1;
        foreach (Student s in students)
        {
            Console.WriteLine($"{count} {s.name}, группа {s.group}");
            count++;
        }
        Console.ReadLine();
    }


}
