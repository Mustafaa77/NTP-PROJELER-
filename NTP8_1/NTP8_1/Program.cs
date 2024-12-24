using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int PostalCode { get; set; }
    public string Country { get; set; }

    public bool Validate()
    {
        // Adres doğrulama mantığı
        return !string.IsNullOrWhiteSpace(Street) && !string.IsNullOrWhiteSpace(City) && PostalCode > 0;
    }

    public string OutputAsLabel()
    {
        return $"{Street}, {City}, {State}, {Country} - {PostalCode}";
    }
}

public abstract class Person
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public Address LivesAt { get; set; }

    public void PurchaseParkingPass()
    {
        Console.WriteLine($"{Name} bir otopark kartı satın aldı.");
    }
}

public class Student : Person
{
    public int StudentNumber { get; set; }
    public int AverageMark { get; set; }

    public bool IsEligibleToEnroll(string course)
    {
        // Ders kayıt uygunluğu kontrolü
        Console.WriteLine($"Ders kayıt uygunluğu kontrol ediliyor: {course}");
        return AverageMark >= 50;
    }

    public int GetSeminarsTaken()
    {
        // Seminer sayısını hesaplayan örnek bir metod
        return new Random().Next(1, 10);
    }
}

public class Professor : Person
{
    public int Salary { get; set; }
    protected int StaffNumber { get; set; }
    protected int YearsOfService { get; set; }
    protected int NumberOfClasses { get; set; }

    public Professor(int staffNumber, int yearsOfService, int numberOfClasses)
    {
        StaffNumber = staffNumber;
        YearsOfService = yearsOfService;
        NumberOfClasses = numberOfClasses;
    }

    public void SuperviseStudent(Student student)
    {
        Console.WriteLine($"{Name}, {student.Name} adlı öğrenciyi denetliyor.");
    }
}

namespace NTP8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address
            {
                Street = "456 Yedek Sokak",
                City = "Kadıköy",
                State = "İstanbul",
                PostalCode = 34700,
                Country = "Türkiye"
            };

            Student student = new Student
            {
                Name = "Mehmet Demir",
                PhoneNumber = "555-123-4567",
                EmailAddress = "mehmet.demir@ornek.com",
                StudentNumber = 2002,
                AverageMark = 85,
                LivesAt = address
            };

            Professor professor = new Professor(3002, 15, 8)
            {
                Name = "Prof. Dr. Ayşe Gül",
                PhoneNumber = "444-987-6543",
                EmailAddress = "ayse.gul@ornek.com",
                Salary = 120000,
                LivesAt = address
            };

            Console.WriteLine(student.IsEligibleToEnroll("Fizik 202") ?
                "Öğrenci bu derse kaydolmaya uygun." :
                "Öğrenci bu derse kaydolmaya uygun değil.");
            professor.SuperviseStudent(student);
            Console.ReadLine();
        }
    }
}
