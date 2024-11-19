using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP5_1
{

            class Yazar
        {
            public string Ad { get; set; }
            public string Ülke { get; set; }
            public List<Kitap> Kitaplar { get; set; }

            // Constructor
            public Yazar(string ad, string ülke)
            {
                Ad = ad; // 'this' kullanımı gerekli değil, parametre isimleri farklı.
                Ülke = ülke;
                Kitaplar = new List<Kitap>(); // Liste başlatılıyor.
            }

            // Kitap ekleme metodu
            public void KitapEkle(Kitap kitap)
            {
                Kitaplar.Add(kitap); // Listeye kitap ekleniyor.
            }
        }

        class Kitap
        {
            public string Başlık { get; set; }
            public string ISBN { get; set; }

            // Constructor
            public Kitap(string başlık, string isbn)
            {
                Başlık = başlık;
                ISBN = isbn;
            }
        }
    class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Departman Departman { get; set; }

        // Constructor
        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        // Departman atama metodu
        public void DepartmanAtama(Departman departman)
        {
            Departman = departman;
        }
    }

    class Departman
    {
        public string Ad { get; set; }
        public string Lokasyon { get; set; }

        // Constructor
        public Departman(string ad, string lokasyon)
        {
            Ad = ad;
            Lokasyon = lokasyon;
        }
    }
    class Urun
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }

        // Constructor
        public Urun(string ad, int fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        // Ürün bilgisi metodu
        public string UrunBilgisi()
        {
            return $"Ürün Adı: {Ad}, Fiyat: {Fiyat} TL";
        }
    }

    class Siparis
    {
        public DateTime Tarih { get; set; }
        public decimal Toplam { get; set; }
        public List<Urun> Urunler { get; set; }

        // Constructor
        public Siparis(DateTime tarih)
        {
            Tarih = tarih;
            Urunler = new List<Urun>();
        }

        // Ürün ekleme metodu
        public void UrunEkle(Urun urun)
        {
            Urunler.Add(urun);
            Toplam += urun.Fiyat;
        }
    }
    class Musteri
    {
        public string Ad { get; set; }
        public List<Siparis> Siparisler { get; set; }

        // Constructor
        public Musteri(string ad)
        {
            Ad = ad;
            Siparisler = new List<Siparis>();
        }

        // Sipariş verme metodu
        public void SiparisVer(Siparis siparis)
        {
            Siparisler.Add(siparis);
        }
    }

    class siparis
    {
        public DateTime Tarih { get; set; }
        public string Durum { get; set; }

        // Constructor
        public siparis(DateTime tarih, string durum)
        {
            Tarih = tarih;
            Durum = durum;
        }
    }



}


