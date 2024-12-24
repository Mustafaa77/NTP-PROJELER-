using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP8_3
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int Payment { get; set; }

        public void Update()
        {
            Console.WriteLine("Müşteri bilgileri güncellendi.");
        }
    }

    // İşlem sınıfı
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }

        public void Update()
        {
            Console.WriteLine("İşlem güncellendi.");
        }
    }

    // Rezervasyon sınıfı
    public class Reservation
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string List { get; set; }

        public void Confirmation()
        {
            Console.WriteLine("Rezervasyon onaylandı.");
        }
    }

    // Kiralama Sahibi sınıfı
    public class RentingOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactNum { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void VerifyAccount()
        {
            Console.WriteLine("Hesap doğrulandı.");
        }
    }

    // Araç sınıfı
    public class Car
    {
        public int Id { get; set; }
        public int Details { get; set; }
        public string OrderType { get; set; }

        public void ProcessDebit()
        {
            Console.WriteLine("Ödeme işleme alındı.");
        }
    }

    // Ödeme sınıfı
    public class Payment
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string Amount { get; set; }

        public void Add()
        {
            Console.WriteLine("Ödeme eklendi.");
        }

        public void Update()
        {
            Console.WriteLine("Ödeme güncellendi.");
        }
    }

    // Kiralamalar sınıfı
    public class Rentals
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Price { get; set; }

        public void Add()
        {
            Console.WriteLine("Kiralama eklendi.");
        }

        public void Update()
        {
            Console.WriteLine("Kiralama güncellendi.");
        }
    }

    
        class Program
        {
            static void Main(string[] args)
            {
                // Bir müşteri oluştur
                Customer customer = new Customer
                {
                    Id = 1,
                    Name = "John Doe",
                    Contact = "123456789",
                    Address = "123 Ana Cadde",
                    Payment = 500
                };

                customer.Update();

                // Bir işlem oluştur
                Transaction transaction = new Transaction
                {
                    Id = 101,
                    Name = "Araç Kiralama",
                    Date = "2024-12-24",
                    Address = "123 Ana Cadde"
                };

                transaction.Update();

                // Bir rezervasyon oluştur
                Reservation reservation = new Reservation
                {
                    Id = 201,
                    Details = "SUV",
                    List = "Rezervasyon Listesi"
                };

                reservation.Confirmation();

                // Bir araç oluştur
                Car car = new Car
                {
                    Id = 301,
                    Details = 1234,
                    OrderType = "Otomatik"
                };

                car.ProcessDebit();

                // Bir ödeme oluştur
                Payment payment = new Payment
                {
                    Id = 401,
                    CardNumber = 123456789,
                    Amount = "$1000"
                };

                payment.Add();
                payment.Update();

                // Bir kiralama oluştur
                Rentals rentals = new Rentals
                {
                    Id = 501,
                    Names = "John'un Kiralaması",
                    Price = "$200"
                };

                rentals.Add();
                rentals.Update();

                // Kiralama Sahibi oluştur
                RentingOwner owner = new RentingOwner
                {
                    Id = 601,
                    Name = "Sahip1",
                    Age = 45,
                    ContactNum = "987654321",
                    Username = "sahip123",
                    Password = "guclusifre"
                };

                owner.VerifyAccount();
            Console.ReadLine();
            }
        }

    }

