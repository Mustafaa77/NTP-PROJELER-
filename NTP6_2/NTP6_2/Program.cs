using System;

namespace NTP6_2
{
    // 1. Zaman İşlemleri
    struct Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public Time(int hour, int minute)
        {
            if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
            {
                Hour = 0;
                Minute = 0;
            }
            else
            {
                Hour = hour;
                Minute = minute;
            }
        }

        public int TotalMinutes()
        {
            return Hour * 60 + Minute;
        }

        public static int Difference(Time t1, Time t2)
        {
            return Math.Abs(t1.TotalMinutes() - t2.TotalMinutes());
        }
    }

    // 2. Karmaşık Sayı Hesaplama
    struct ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }

    // 3. GPS Konum Mesafesi
    struct GPSLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GPSLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static double HaversineDistance(GPSLocation loc1, GPSLocation loc2)
        {
            const double EarthRadiusKm = 6371.0;

            double dLat = DegreesToRadians(loc2.Latitude - loc1.Latitude);
            double dLon = DegreesToRadians(loc2.Longitude - loc1.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreesToRadians(loc1.Latitude)) * Math.Cos(DegreesToRadians(loc2.Latitude)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Zaman İşlemleri
                Console.WriteLine("1. Zaman İşlemleri:");
                Time time1 = new Time(14, 30);
                Time time2 = new Time(10, 15);
                Console.WriteLine($"Time 1: {time1.Hour}:{time1.Minute}");
                Console.WriteLine($"Time 2: {time2.Hour}:{time2.Minute}");
                Console.WriteLine($"Time 1 Toplam Dakika: {time1.TotalMinutes()}");
                Console.WriteLine($"İki zaman arasındaki fark: {Time.Difference(time1, time2)} dakika");

                // 2. Karmaşık Sayı Hesaplama
                Console.WriteLine("\n2. Karmaşık Sayı Hesaplama:");
                ComplexNumber c1 = new ComplexNumber(3, 4);
                ComplexNumber c2 = new ComplexNumber(1, 2);
                ComplexNumber sum = c1.Add(c2);
                ComplexNumber diff = c1.Subtract(c2);
                Console.WriteLine($"C1: {c1}");
                Console.WriteLine($"C2: {c2}");
                Console.WriteLine($"Toplam: {sum}");
                Console.WriteLine($"Fark: {diff}");

                // 3. GPS Konum Mesafesi
                Console.WriteLine("\n3. GPS Konum Mesafesi:");
                GPSLocation loc1 = new GPSLocation(41.0082, 28.9784); // İstanbul
                GPSLocation loc2 = new GPSLocation(39.9208, 32.8541); // Ankara
                double distance = GPSLocation.HaversineDistance(loc1, loc2);
                Console.WriteLine($"İstanbul ve Ankara arasındaki mesafe: {distance:F2} km");
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
