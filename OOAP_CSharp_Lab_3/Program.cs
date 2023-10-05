using System;
using System.IO;

public abstract class Room
{
    public int Capacity { get; set; }
    public Occupant[] Occupants { get; set; }

    public abstract Room Clone();
}

public class Occupant
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Faculty { get; set; }
    public string Group { get; set; }
    public string EducationForm { get; set; }
    public double Rent { get; set; }
}

public class DoubleRoom : Room
{
    public DoubleRoom()
    {
        Capacity = 2;
        Occupants = new Occupant[2];
    }

    public override Room Clone()
    {
        return (Room)this.MemberwiseClone();
    }
}

public class TripleRoom : Room
{
    public TripleRoom()
    {
        Capacity = 3;
        Occupants = new Occupant[3];
    }

    public override Room Clone()
    {
        return (Room)this.MemberwiseClone();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Room room = null;

        Console.WriteLine("Введiть тип кiмнати (двомiсна, трьохмiсна):");
        string type = Console.ReadLine().ToLower();

        switch (type)
        {
            case "двомiсна":
                room = new DoubleRoom();
                break;
            case "трьохмiсна":
                room = new TripleRoom();
                break;
            default:
                Console.WriteLine("Невiдомий тип кiмнати");
                return;
        }

        for (int i = 0; i < room.Capacity; i++)
        {
            Console.WriteLine($"Введiть iнформацiю про мешканця {i + 1}:");

            Occupant occupant = new Occupant();

            Console.WriteLine("Введiть ПІБ:");
            occupant.Name = Console.ReadLine();

            Console.WriteLine("Введiть дату народження:");
            occupant.BirthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введiть факультет:");
            occupant.Faculty = Console.ReadLine();

            Console.WriteLine("Введiть групу:");
            occupant.Group = Console.ReadLine();

            Console.WriteLine("Введiть форму навчання:");
            occupant.EducationForm = Console.ReadLine();

            Console.WriteLine("Введiть квартплату:");
            occupant.Rent = double.Parse(Console.ReadLine());

            room.Occupants[i] = occupant;
        }

        Room clone = room.Clone();

        using (StreamWriter sw = new StreamWriter("report.txt"))
        {
            sw.WriteLine($"Тип кiмнати: {type}");
            sw.WriteLine($"Кiлькiсть мешканцiв: {clone.Capacity}");
            sw.WriteLine("Мешканцi:");

            foreach (Occupant occupant in clone.Occupants)
            {
                sw.WriteLine($"ПІБ: {occupant.Name}, Дата народження: {occupant.BirthDate.ToShortDateString()}, Факультет: {occupant.Faculty}, Група: {occupant.Group}, Форма навчання: {occupant.EducationForm}, Квартплата: {occupant.Rent}");
            }
        }

        Console.WriteLine("Звiт збережено в файлi report.txt");
    }
}
