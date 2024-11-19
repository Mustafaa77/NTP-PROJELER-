using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP5_2
{
    class Doktor
    {
        public string Ad { get; set; }
        public string Brans { get; set; }
        public List<Hasta> Hastalar { get; set; }

        // Constructor
        public Doktor(string ad, string brans)
        {
            Ad = ad;
            Brans = brans;
            Hastalar = new List<Hasta>();
        }

        // Hasta ekleme metodu
        public void HastaEkle(Hasta hasta)
        {
            Hastalar.Add(hasta);
            hasta.DoktorAtama(this); // Çift yönlü ilişkiyi sağlar.
        }
    }

    class Hasta
    {
        public string Ad { get; set; }
        public string TCNo { get; set; }
        public Doktor Doktor { get; set; }

        // Constructor
        public Hasta(string ad, string tcNo)
        {
            Ad = ad;
            TCNo = tcNo;
        }

        // Doktor atama metodu
        public void DoktorAtama(Doktor doktor)
        {
            Doktor = doktor;
            if (!doktor.Hastalar.Contains(this))
            {
                doktor.HastaEkle(this); // Doktor listesine eklenmeyi sağlar.
            }
        }
    }
    class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        // Constructor
        public Yazar(string ad, string ulke)
        {
            Ad = ad;
            Ulke = ulke;
            Kitaplar = new List<Kitap>();
        }

        // Kitap ekleme metodu
        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            kitap.YazarAtama(this); // Çift yönlü ilişkiyi sağlar.
        }
    }

    class Kitap
    {
        public string Baslik { get; set; }
        public DateTime YayinTarihi { get; set; }
        public Yazar Yazar { get; set; }

        // Constructor
        public Kitap(string baslik, DateTime yayinTarihi)
        {
            Baslik = baslik;
            YayinTarihi = yayinTarihi;
        }

        // Yazar atama metodu
        public void YazarAtama(Yazar yazar)
        {
            Yazar = yazar;
            if (!yazar.Kitaplar.Contains(this))
            {
                yazar.KitapEkle(this); // Yazar listesine eklenmeyi sağlar.
            }
        }
    }

    class Sirket
    {
        public string Ad { get; set; }
        public string Konum { get; set; }
        public List<Calisan> Calisanlar { get; set; }

        // Constructor
        public Sirket(string ad, string konum)
        {
            Ad = ad;
            Konum = konum;
            Calisanlar = new List<Calisan>();
        }

        // Çalışan ekleme metodu
        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
            calisan.SirketAtama(this); // Çift yönlü ilişkiyi sağlar.
        }
    }

    class Calisan
    {
        public string Ad { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public Sirket Sirket { get; set; }

        // Constructor
        public Calisan(string ad, DateTime iseGirisTarihi)
        {
            Ad = ad;
            IseGirisTarihi = iseGirisTarihi;
        }

        // Şirket atama metodu
        public void SirketAtama(Sirket sirket)
        {
            Sirket = sirket;
            if (!sirket.Calisanlar.Contains(this))
            {
                sirket.CalisanEkle(this); // Şirket listesine eklenmeyi sağlar.
            }
        }
    }

    class Ebeveyn
    {
        public string Ad { get; set; }
        public List<Cocuk> Cocuklar { get; set; }

        // Constructor
        public Ebeveyn(string ad)
        {
            Ad = ad;
            Cocuklar = new List<Cocuk>();
        }

        // Çocuk ekleme metodu
        public void CocukEkle(Cocuk cocuk)
        {
            Cocuklar.Add(cocuk);
            cocuk.EbeveynAtama(this); // Çift yönlü ilişkiyi sağlar.
        }
    }

    class Cocuk
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public Ebeveyn Ebeveyn { get; set; }

        // Constructor
        public Cocuk(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        // Ebeveyn atama metodu
        public void EbeveynAtama(Ebeveyn ebeveyn)
        {
            Ebeveyn = ebeveyn;
            if (!ebeveyn.Cocuklar.Contains(this))
            {
                ebeveyn.CocukEkle(this); // Ebeveyn listesine eklenmeyi sağlar.
            }
        }
    }

}
