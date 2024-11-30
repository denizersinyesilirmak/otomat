using System;

namespace otomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Fanta = 40;
            int Kola = 40;
            int Cikolata = 30;
            int bakiye = 0;

            Console.WriteLine($"Fiyatlarımız - Fanta: {Fanta} TL, Kola: {Kola} TL, Çikolata: {Cikolata} TL");

            while (true)
            {
                Console.WriteLine("Ne almak istersiniz? (1: Fanta, 2: Kola, 3: Çikolata, 0: Çıkış): ");
                string girdi = Console.ReadLine();

                if (girdi == "0") break;

                int secim = int.Parse(girdi);
                int fiyat;

                switch (secim)
                {
                    case 1:
                        fiyat = Fanta;
                        break;
                    case 2:
                        fiyat = Kola;
                        break;
                    default:
                        fiyat = Cikolata;
                        break;
                }

                Console.WriteLine($"{fiyat} TL");
                int yatırılanPara = ParaEkle(ref bakiye);

                if (yatırılanPara >= fiyat)
                {
                    Console.WriteLine("Afiyet olsun!");
                    if (yatırılanPara > fiyat)
                    {
                        int paraUstu = yatırılanPara - fiyat;
                        Console.WriteLine($"Para üstü: {paraUstu} TL alınız.");
                    }
                    bakiye -= fiyat;
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye");
                    Console.WriteLine("1- Para ekle / 2- Para iade");

                    string paraAz = Console.ReadLine();
                    if (paraAz == "1")
                    {
                        yatırılanPara = ParaEkle(ref bakiye);
                        if (yatırılanPara + bakiye >= fiyat)
                        {
                            Console.WriteLine("Afiyet olsun!");
                             bakiye -= fiyat;
                            if (yatırılanPara > fiyat)  // bakiye 0 yapamıyorum
                            {
                                int paraUstu = yatırılanPara - fiyat;
                                Console.WriteLine($"Para üstü: {paraUstu} TL alınız.");
                                bakiye = 0;

                            }
                        }
                    }
                    else if (paraAz == "2")
                    {
                        Console.WriteLine($"İade edilen miktar: {bakiye} TL");
                        bakiye = 0;
                    }
                }
            }
        }

        static int ParaEkle(ref int bakiye)
        {
            Console.Write("Yatırmak istediğiniz tutar: ");
            int miktar;
            string girdi = Console.ReadLine();
            miktar = int.Parse(girdi);

            if (miktar > 0)
            {
                bakiye += miktar;
                Console.WriteLine($"{miktar} TL yatırıldı. Yeni bakiye: {bakiye} TL");
            }
            else
            {
                Console.WriteLine("Geçersiz miktar. İşlem iptal edildi.");
                miktar = 0;
            }
            return miktar;
        }
    }
}