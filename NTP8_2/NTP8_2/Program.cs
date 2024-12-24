using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP8_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // Tanımlanabilir protokolü
    public interface IIdentifiable
    {
        Guid Id { get; }
    }

    // Deneyimli protokolü
    public interface IExperienced
    {
        void Train();
    }

    // Aşı sınıfı
    public class Vaccine
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    // Hayvan sınıfı
    public class Animal
    {
        public string Type { get; set; }
        public string Breed { get; set; }
        public bool Carnivore { get; set; }
    }

    // Evcil hayvan bilgisi sınıfı
    public class PetInformation
    {
        public List<string> Traits { get; set; }
        public List<Vaccine> Vaccines { get; set; }

        public PetInformation()
        {
            Traits = new List<string>();
            Vaccines = new List<Vaccine>();
        }
    }

    // Sahip sınıfı
    public class Owner : IExperienced
    {
        public string Name { get; set; }

        public void Train()
        {
            Console.WriteLine("Sahip eğitim veriyor.");
        }
    }

    // Evcil hayvan sınıfı
    public class Pet : IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Owner Owner { get; set; }
        public Animal Type { get; set; }
        public PetInformation PetInfo { get; set; }

        public Pet()
        {
            Id = Guid.NewGuid();
        }

        public void Feed()
        {
            Console.WriteLine($"{Name} besleniyor.");
        }

        public bool IsHerbivore()
        {
            return !Type.Carnivore;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Sahip oluştur
            Owner owner = new Owner { Name = "Ali" };

            // Hayvan türü oluştur
            Animal animal = new Animal
            {
                Type = "Kedi",
                Breed = "Van Kedisi",
                Carnivore = true
            };

            // Evcil hayvan bilgisi oluştur
            PetInformation petInfo = new PetInformation
            {
                Traits = new List<string> { "Sevimli", "Oyuncu" },
                Vaccines = new List<Vaccine>
            {
                new Vaccine { Name = "Kuduz", Type = "Zorunlu" },
                new Vaccine { Name = "Parazit", Type = "Opsiyonel" }
            }
            };

            // Evcil hayvan oluştur
            Pet pet = new Pet
            {
                Name = "Pamuk",
                Age = 3,
                Owner = owner,
                Type = animal,
                PetInfo = petInfo
            };

            // Evcil hayvan bilgilerini yazdır
            Console.WriteLine($"Evcil Hayvan Adı: {pet.Name}");
            Console.WriteLine($"Yaşı: {pet.Age}");
            Console.WriteLine($"Türü: {pet.Type.Type}, Cinsi: {pet.Type.Breed}");
            Console.WriteLine($"Sahibi: {pet.Owner.Name}");
            Console.WriteLine($"Otçul mu?: {(pet.IsHerbivore() ? "Evet" : "Hayır")}");

            Console.WriteLine("Özellikler:");
            foreach (var trait in pet.PetInfo.Traits)
            {
                Console.WriteLine($"- {trait}");
            }

            Console.WriteLine("Aşılar:");
            foreach (var vaccine in pet.PetInfo.Vaccines)
            {
                Console.WriteLine($"- {vaccine.Name} ({vaccine.Type})");
            }

            // Sahibi eğitimi
            pet.Owner.Train();

            // Evcil hayvanı besle
            pet.Feed();
            Console.ReadLine();
        }
    }

}
    