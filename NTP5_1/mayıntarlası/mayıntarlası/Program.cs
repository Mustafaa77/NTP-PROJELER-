using System;

namespace mayintarlasi
{
    class MayinTarlasi
    {
        const int boyut = 20;  // tahta boyutu 20x20 olarak ayarlandı
        const int mayinSayisi = 10;  // toplam mayın sayısı
        static int[,] tahta = new int[boyut, boyut];  // tahta bilgilerini tutan dizi
        static bool[,] acildiMi = new bool[boyut, boyut];  // hücrelerin açılıp açılmadığını kontrol eden dizi
        static int acilanHucresayisi = 0;  // açılmış hücre sayısı (kazanma kontrolü için)

        static void Main()
        {
            MayinlariOlustur();  // mayınları yerleştir
            TahtayiYazdir();  // tahtayı ekrana yazdır

            while (true)
            {
                Console.WriteLine("Koordinat giriniz (örnek: satir sutun): ");

                if (!int.TryParse(Console.ReadLine(), out int x) || !int.TryParse(Console.ReadLine(), out int y))
                {
                    Console.WriteLine("Geçersiz giriş! Lütfen sayısal bir değer girin.");  // giriş hatası mesajı
                    continue;
                }

                if (x < 0 || x >= boyut || y < 0 || y >= boyut)
                {
                    Console.WriteLine("Geçersiz koordinatlar! Lütfen 0 ile 19 arasında bir değer girin.");  // geçersiz koordinat uyarısı
                    continue;
                }

                if (acildiMi[x, y])
                {
                    Console.WriteLine("Bu hücre zaten açılmış!");  // açılmış hücreye uyarı
                    continue;
                }

                if (tahta[x, y] == -1)
                {
                    Console.WriteLine("Mayına bastınız! Oyun bitti.");  // mayına basıldığında oyun bitiş mesajı
                    TahtayiGoster();
                    Console.WriteLine("Bir tuşa basarak çıkabilirsiniz...");  // oyunu kapatmadan önce kullanıcıya bekleme mesajı
                    Console.ReadKey();
                    break;
                }
                else
                {
                    BolgeyiAc(x, y);  // mayınsız bölgeyi aç
                    TahtayiYazdir();  // tahtayı güncel haliyle yazdır

                    // Kazanma kontrolü
                    if (acilanHucresayisi == (boyut * boyut - mayinSayisi))
                    {
                        Console.WriteLine("Tebrikler! Tüm hücreleri açtınız ve oyunu kazandınız!");
                        TahtayiGoster();
                        Console.WriteLine("Bir tuşa basarak çıkabilirsiniz...");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }

        static void MayinlariOlustur()
        {
            Random rnd = new Random();  // rastgele sayılar için
            for (int i = 0; i < mayinSayisi; i++)
            {
                int x, y;
                do
                {
                    x = rnd.Next(boyut);
                    y = rnd.Next(boyut);
                } while (tahta[x, y] == -1);  // zaten mayın varsa başka koordinat dene

                tahta[x, y] = -1;  // mayını yerleştir

                // etrafındaki hücrelere 1 ekle
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = x + dx;
                        int ny = y + dy;
                        if (nx >= 0 && nx < boyut && ny >= 0 && ny < boyut && tahta[nx, ny] != -1)
                        {
                            tahta[nx, ny]++;
                        }
                    }
                }
            }
        }

        static void TahtayiYazdir()
        {
            Console.Clear();  // ekranı temizle

            // sütun numaralarını elle yazdırma
            Console.Write("    0 1 2 3 4 5 6 7 8 9 10111213141516171819");  // satır numaralarının hizalanması için ilk boşluk

            Console.WriteLine();

            // oyun tahtasını yazdır
            for (int i = 0; i < boyut; i++)
            {
                Console.Write(i.ToString("D2") + "  ");  // satır numarasını yazdır ve boşluk ekle
                for (int j = 0; j < boyut; j++)
                {
                    if (!acildiMi[i, j])
                        Console.Write("? ");  // açılmamış hücreler için ? simgesi
                    else if (tahta[i, j] == -1)
                        Console.Write("* ");  // mayın olan hücre için * simgesi
                    else
                        Console.Write($"{tahta[i, j]} ");  // mayın olmayan hücrelerdeki sayı
                }
                Console.WriteLine();
            }
        }

        static void TahtayiGoster()
        {
            Console.Write("    ");
            for (int j = 0; j < boyut; j++)
            {
                Console.Write($"{j:D2} ");
            }
            Console.WriteLine();

            for (int i = 0; i < boyut; i++)
            {
                Console.Write($"{i:D2}  ");
                for (int j = 0; j < boyut; j++)
                {
                    if (tahta[i, j] == -1)
                        Console.Write("* ");
                    else
                        Console.Write($"{tahta[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void BolgeyiAc(int x, int y)
        {
            if (x < 0 || x >= boyut || y < 0 || y >= boyut || acildiMi[x, y])
                return;  // geçersiz koordinat veya açılmış hücre ise dön

            acildiMi[x, y] = true;  // hücreyi aç
            acilanHucresayisi++;  // açılan hücre sayısını artır

            if (tahta[x, y] == 0)
            {
                // etraftaki 0'ları açma
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx != 0 || dy != 0)
                        {
                            BolgeyiAc(x + dx, y + dy);  // komşuları da aç
                        }
                    }
                }
            }
        }
    }
}
