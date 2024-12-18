using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP7_1
{
    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public double Maas { get; set; }
        public string Pozisyon { get; set; }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}");
        }
    }

    class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazılım Dili: {YazilimDili}");
        }
    }

    class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }

    // Hayvanat Bahçesi Yönetim Sistemi
    class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Ses çıkarıyor...");
        }
    }

    class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine("Memeli bir ses çıkarıyor...");
        }
    }

    class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine("Kuş bir ses çıkarıyor...");
        }
    }

    // Banka Hesabı Yönetimi
    class Hesap
    {
        public string HesapNo { get; set; }
        public double Bakiye { get; set; }
        public string HesapSahibi { get; set; }

        public virtual void ParaYatir(double miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL");
        }

        public virtual void ParaCek(double miktar)
        {
            if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            else
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
            }
        }
    }

    class VadesizHesap : Hesap
    {
        public double EkHesapLimiti { get; set; }

        public override void ParaCek(double miktar)
        {
            if (miktar > (Bakiye + EkHesapLimiti))
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti.");
            }
            else
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
            }
        }
    }

    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; }
        public double FaizOrani { get; set; }

        public override void ParaCek(double miktar)
        {
            if (VadeSuresi > 0)
            {
                Console.WriteLine("Vade süresi dolmadan para çekemezsiniz.");
            }
            else
            {
                base.ParaCek(miktar);
            }
        }
    }

    // Program Başlangıcı
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hangi uygulamayı çalıştırmak istersiniz? (1: Çalışan Yönetimi, 2: Hayvanat Bahçesi, 3: Banka Hesabı)");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    CalisanYoneticisi();
                    break;
                case 2:
                    HayvanYoneticisi();
                    break;
                case 3:
                    BankaHesabiYoneticisi();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }

        static void CalisanYoneticisi()
        {
            Console.WriteLine("Çalışan türünü seçin (1: Yazılımcı, 2: Muhasebeci): ");
            int calisanSecim = int.Parse(Console.ReadLine());

            Calisan calisan;
            if (calisanSecim == 1)
            {
                calisan = new Yazilimci();
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.Maas = double.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                calisan.Pozisyon = Console.ReadLine();
                Console.Write("Yazılım Dili: ");
                ((Yazilimci)calisan).YazilimDili = Console.ReadLine();
            }
            else
            {
                calisan = new Muhasebeci();
                Console.Write("Ad: ");
                calisan.Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.Soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.Maas = double.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                calisan.Pozisyon = Console.ReadLine();
                Console.Write("Muhasebe Yazılımı: ");
                ((Muhasebeci)calisan).MuhasebeYazilimi = Console.ReadLine();
            }

            Console.WriteLine("Çalışan Bilgileri:");
            calisan.BilgiYazdir();
        }

        static void HayvanYoneticisi()
        {
            Console.WriteLine("Hayvan türünü seçin (1: Memeli, 2: Kuş): ");
            int hayvanSecim = int.Parse(Console.ReadLine());

            Hayvan hayvan;
            if (hayvanSecim == 1)
            {
                hayvan = new Memeli();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Tüy Rengi: ");
                ((Memeli)hayvan).TuyRengi = Console.ReadLine();
            }
            else
            {
                hayvan = new Kus();
                Console.Write("Ad: ");
                hayvan.Ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.Tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.Yas = int.Parse(Console.ReadLine());
                Console.Write("Kanat Genişliği: ");
                ((Kus)hayvan).KanatGenisligi = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Hayvan Bilgileri:");
            Console.WriteLine($"Ad: {hayvan.Ad}, Tür: {hayvan.Tur}, Yaş: {hayvan.Yas}");
            hayvan.SesCikar();
        }

        static void BankaHesabiYoneticisi()
        {
            Console.WriteLine("Hesap türünü seçin (1: Vadesiz Hesap, 2: Vadeli Hesap): ");
            int hesapSecim = int.Parse(Console.ReadLine());

            Hesap hesap;
            if (hesapSecim == 1)
            {
                hesap = new VadesizHesap();
                Console.Write("Hesap No: ");
                hesap.HesapNo = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                hesap.Bakiye = double.Parse(Console.ReadLine());
                Console.Write("Ek Hesap Limiti: ");
                ((VadesizHesap)hesap).EkHesapLimiti = double.Parse(Console.ReadLine());
            }
            else
            {
                hesap = new VadeliHesap();
                Console.Write("Hesap No: ");
                hesap.HesapNo = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                hesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                hesap.Bakiye = double.Parse(Console.ReadLine());
                Console.Write("Vade Süresi: ");
                ((VadeliHesap)hesap).VadeSuresi = int.Parse(Console.ReadLine());
                Console.Write("Faiz Oranı: ");
                ((VadeliHesap)hesap).FaizOrani = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("İşlem yapmak istiyor musunuz? (1: Para Yatır, 2: Para Çek, 3: Hesap Bilgileri Yazdır)");
            int islemSecim = int.Parse(Console.ReadLine());

            switch (islemSecim)
            {
                case 1:
                    Console.Write("Yatırılacak miktar: ");
                    double yatirilan = double.Parse(Console.ReadLine());
                    hesap.ParaYatir(yatirilan);
                    break;
                case 2:
                    Console.Write("Çekilecek miktar: ");
                    double cekilen = double.Parse(Console.ReadLine());
                    hesap.ParaCek(cekilen);
                    break;
                case 3:
                    Console.WriteLine($"Hesap No: {hesap.HesapNo}, Hesap Sahibi: {hesap.HesapSahibi}, Bakiye: {hesap.Bakiye} TL");
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem.");
                    break;
            }
        }
    }
}