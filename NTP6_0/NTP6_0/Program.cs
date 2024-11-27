using System;
using System.Linq;

namespace NTP6_0
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Matematiksel İşlemler
                Console.WriteLine("1. Matematiksel İşlemler:");
                Console.WriteLine("İki sayının toplamı: " + Topla(3, 5)); // İki tam sayı
                Console.WriteLine("Üç sayının toplamı: " + Topla(1, 2, 3)); // Üç tam sayı
                Console.WriteLine("Dizinin elemanlarının toplamı: " + Topla(new int[] { 4, 5, 6, 7 })); // Dizi

                // 2. Farklı Şekillerin Alanı
                Console.WriteLine("\n2. Farklı Şekillerin Alanları:");
                Console.WriteLine("Karenin alanı: " + Alan(5)); // Kare
                Console.WriteLine("Dikdörtgenin alanı: " + Alan(4, 6)); // Dikdörtgen
                Console.WriteLine("Dairenin alanı: " + Alan(3.5)); // Daire

                // 3. Zaman Farkı Hesaplama
                Console.WriteLine("\n3. Zaman Farkı Hesaplama:");
                DateTime tarih1 = new DateTime(2024, 11, 27);
                DateTime tarih2 = new DateTime(2023, 11, 27);

                Console.WriteLine("Gün farkı: " + ZamanFarki(tarih1, tarih2)); // Gün cinsinden fark
                Console.WriteLine("Saat farkı: " + ZamanFarki(tarih1, tarih2, "saat")); // Saat cinsinden fark
                Console.WriteLine("Yıl farkı: " + ZamanFarki(tarih1, tarih2, "yıl")); // Yıl cinsinden fark
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            // Çıktının açık kalması için
            Console.WriteLine("\nProgram sonlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        // 1. Matematiksel İşlemler
        static int Topla(int a, int b) => a + b;

        static int Topla(int a, int b, int c) => a + b + c;

        static int Topla(int[] sayilar)
        {
            if (sayilar == null || sayilar.Length == 0)
                throw new ArgumentException("Dizi boş olamaz.");
            return sayilar.Sum();
        }

        // 2. Farklı Şekillerin Alanı
        static int Alan(int kenar) => kenar * kenar; // Karenin alanı

        static int Alan(int uzunKenar, int kisaKenar) => uzunKenar * kisaKenar; // Dikdörtgenin alanı

        static double Alan(double yaricap)
        {
            if (yaricap <= 0)
                throw new ArgumentException("Yarıçap sıfırdan büyük olmalıdır.");
            return Math.PI * yaricap * yaricap; // Dairenin alanı
        }

        // 3. Zaman Farkı Hesaplama
        static double ZamanFarki(DateTime tarih1, DateTime tarih2, string format = "gün")
        {
            TimeSpan fark = tarih1 - tarih2;

            switch (format.ToLower())
            {
                case "gün":
                    return fark.TotalDays;
                case "saat":
                    return fark.TotalHours;
                case "yıl":
                    return fark.TotalDays / 365;
                default:
                    throw new ArgumentException("Geçersiz format. 'gün', 'saat' veya 'yıl' olmalıdır.");
            }
        }
    }
}
