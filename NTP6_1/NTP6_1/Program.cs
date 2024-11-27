using System;
using System.Collections.Generic;

namespace NTP6_1
{
    // 1. Özel Bir Kütüphane Yönetim Sistemi
    class Library
    {
        private string[] books;

        public Library(int capacity)
        {
            books = new string[capacity];
            for (int i = 0; i < capacity; i++)
            {
                books[i] = $"Kitap-{i + 1}";
            }
        }

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Geçersiz indeks.");
                return books[index];
            }
            set
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Geçersiz indeks.");
                books[index] = value;
            }
        }
    }

    // 2. Bir Öğrenci Not Sistemi
    class GradeSystem
    {
        private Dictionary<string, double> grades = new Dictionary<string, double>();

        public double this[string subject]
        {
            get
            {
                if (!grades.ContainsKey(subject))
                    throw new KeyNotFoundException("Ders bulunamadı.");
                return grades[subject];
            }
            set
            {
                grades[subject] = value;
            }
        }
    }

    // 3. Bir Satranç Tahtası Durumu
    class ChessBoard
    {
        private string[,] board = new string[8, 8];

        public string this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= 8 || col < 0 || col >= 8)
                    throw new IndexOutOfRangeException("Geçersiz kare.");
                return board[row, col] ?? "Boş";
            }
            set
            {
                if (row < 0 || row >= 8 || col < 0 || col >= 8)
                    throw new IndexOutOfRangeException("Geçersiz kare.");
                board[row, col] = value;
            }
        }
    }

    // 4. Çok Katmanlı Bir Otopark Sistemi
    class ParkingLot
    {
        private string[,] parkingSpots;

        public ParkingLot(int floors, int spotsPerFloor)
        {
            parkingSpots = new string[floors, spotsPerFloor];
        }

        public string this[int floor, int spot]
        {
            get
            {
                if (floor < 0 || floor >= parkingSpots.GetLength(0) || spot < 0 || spot >= parkingSpots.GetLength(1))
                    throw new IndexOutOfRangeException("Geçersiz park yeri.");
                return parkingSpots[floor, spot] ?? "Empty";
            }
            set
            {
                if (floor < 0 || floor >= parkingSpots.GetLength(0) || spot < 0 || spot >= parkingSpots.GetLength(1))
                    throw new IndexOutOfRangeException("Geçersiz park yeri.");
                parkingSpots[floor, spot] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Özel Bir Kütüphane Yönetim Sistemi
                Console.WriteLine("1. Kütüphane Yönetim Sistemi:");
                Library library = new Library(5);
                Console.WriteLine("1. Kitap: " + library[0]); // İlk kitap
                library[0] = "Yeni Kitap";
                Console.WriteLine("1. Kitap (güncellenmiş): " + library[0]);

                // 2. Öğrenci Not Sistemi
                Console.WriteLine("\n2. Öğrenci Not Sistemi:");
                GradeSystem grades = new GradeSystem();
                grades["Matematik"] = 95.5;
                grades["Fizik"] = 89.3;
                Console.WriteLine("Matematik Notu: " + grades["Matematik"]);
                Console.WriteLine("Fizik Notu: " + grades["Fizik"]);

                // 3. Satranç Tahtası
                Console.WriteLine("\n3. Satranç Tahtası:");
                ChessBoard chessBoard = new ChessBoard();
                chessBoard[0, 0] = "Kale";
                chessBoard[7, 7] = "Şah";
                Console.WriteLine("0,0 karesi: " + chessBoard[0, 0]);
                Console.WriteLine("7,7 karesi: " + chessBoard[7, 7]);
                Console.WriteLine("4,4 karesi: " + chessBoard[4, 4]); // Boş kare

                // 4. Çok Katmanlı Bir Otopark Sistemi
                Console.WriteLine("\n4. Çok Katmanlı Otopark Sistemi:");
                ParkingLot parkingLot = new ParkingLot(3, 5); // 3 katlı, her katta 5 park yeri
                parkingLot[1, 2] = "34ABC123";
                Console.WriteLine("1. kat, 2. park yeri: " + parkingLot[1, 2]);
                Console.WriteLine("2. kat, 3. park yeri: " + parkingLot[2, 3]); // Boş park yeri
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            // Program açık kalsın
            Console.WriteLine("\nProgram sonlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
