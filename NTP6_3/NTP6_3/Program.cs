using System;

namespace NTP6_3
{
    // 1. Trafik Işığı Durumu Enum ve Sınıf
    public enum TrafficLight
    {
        Red,
        Yellow,
        Green
    }

    public class TrafficLightController
    {
        public string GetAction(TrafficLight light)
        {
            switch (light)
            {
                case TrafficLight.Red:
                    return "Dur!";
                case TrafficLight.Yellow:
                    return "Hazırlan!";
                case TrafficLight.Green:
                    return "Geç!";
                default:
                    return "Bilinmeyen durum.";
            }
        }
    }

    // 2. Hava Durumu Tahmini Enum ve Sınıf
    public enum WeatherCondition
    {
        Sunny,
        Rainy,
        Cloudy,
        Stormy
    }

    public class WeatherAdvisor
    {
        public string GetAdvice(WeatherCondition condition)
        {
            switch (condition)
            {
                case WeatherCondition.Sunny:
                    return "Güneş gözlüğü takmayı unutma!";
                case WeatherCondition.Rainy:
                    return "Şemsiyeni al!";
                case WeatherCondition.Cloudy:
                    return "Hava serin olabilir, ince bir mont al.";
                case WeatherCondition.Stormy:
                    return "Dışarı çıkma, evde kal!";
                default:
                    return "Bilinmeyen hava durumu.";
            }
        }
    }

    // 3. Çalışan Rolleri ve Maaş Hesaplama Enum ve Sınıf
    public enum EmployeeRole
    {
        Manager,
        Developer,
        Designer,
        Tester
    }

    public class SalaryCalculator
    {
        public double GetSalary(EmployeeRole role)
        {
            switch (role)
            {
                case EmployeeRole.Manager:
                    return 15000.0;
                case EmployeeRole.Developer:
                    return 12000.0;
                case EmployeeRole.Designer:
                    return 10000.0;
                case EmployeeRole.Tester:
                    return 8000.0;
                default:
                    return 0.0;
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Trafik Işığı Durumu
            TrafficLightController trafficLightController = new TrafficLightController();
            Console.WriteLine("Trafik Işığı (Red): " + trafficLightController.GetAction(TrafficLight.Red));
            Console.WriteLine("Trafik Işığı (Yellow): " + trafficLightController.GetAction(TrafficLight.Yellow));
            Console.WriteLine("Trafik Işığı (Green): " + trafficLightController.GetAction(TrafficLight.Green));

            // 2. Hava Durumu Tahmini
            WeatherAdvisor weatherAdvisor = new WeatherAdvisor();
            Console.WriteLine("\nHava Durumu (Sunny): " + weatherAdvisor.GetAdvice(WeatherCondition.Sunny));
            Console.WriteLine("Hava Durumu (Rainy): " + weatherAdvisor.GetAdvice(WeatherCondition.Rainy));
            Console.WriteLine("Hava Durumu (Cloudy): " + weatherAdvisor.GetAdvice(WeatherCondition.Cloudy));
            Console.WriteLine("Hava Durumu (Stormy): " + weatherAdvisor.GetAdvice(WeatherCondition.Stormy));

            // 3. Çalışan Rolleri ve Maaş Hesaplama
            SalaryCalculator salaryCalculator = new SalaryCalculator();
            Console.WriteLine("\nMaaş (Manager): " + salaryCalculator.GetSalary(EmployeeRole.Manager));
            Console.WriteLine("Maaş (Developer): " + salaryCalculator.GetSalary(EmployeeRole.Developer));
            Console.WriteLine("Maaş (Designer): " + salaryCalculator.GetSalary(EmployeeRole.Designer));
            Console.WriteLine("Maaş (Tester): " + salaryCalculator.GetSalary(EmployeeRole.Tester));
            // Program açık kalsın
            Console.WriteLine("\nProgram sonlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
