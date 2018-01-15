using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islem
{
    partial class Islem
    {
        public static string sayi1;
        public static string sayi2;

        public static int sayi1_Virgul;
        public static int sayi2_Virgul;

        public static char VirgulAyrac = ',';

        //Sayıları virgülden kurtarmak için 
        int kontrolOndalikSayi(string s1, string s2)
        {
            sayi1 = s1;
            sayi2 = s2;

            //Gelen herk iki sayıdan herhangi biri virgül olunce içine girip kurtarıyor.
            if (s1.IndexOf(VirgulAyrac) > 0 || s2.IndexOf(VirgulAyrac) > 0)
            {
                string sayi1_virgül_oncesi = "";
                string sayi2_virgül_oncesi = "";
                sayi1_Virgul = 0;
                sayi2_Virgul = 0;

                if (s1.IndexOf(VirgulAyrac) > 0)
                {
                    string[] p1 = s1.Split(VirgulAyrac);
                    sayi1_virgül_oncesi = p1[1];
                    sayi1 = p1[0] + p1[1];
                    sayi1_Virgul = p1[1].Length;
                }
                if (s2.IndexOf(VirgulAyrac) > 0)
                {
                    string[] p2 = s2.Split(VirgulAyrac);
                    sayi2_virgül_oncesi = p2[1];
                    sayi2 = p2[0] + p2[1];
                    sayi2_Virgul = p2[1].Length;
                }

                //Virgülden sonraki uzunluk eşit değilse küçük olanın sonuna sıfır ekliyor sayıları eşitlemek için.
                if (sayi1_virgül_oncesi.Length != sayi2_virgül_oncesi.Length)
                {
                    int fark = Math.Abs(sayi1_virgül_oncesi.Length - sayi2_virgül_oncesi.Length);

                    if (sayi1_virgül_oncesi.Length < sayi2_virgül_oncesi.Length)
                    {
                        for (int i = 0; i < fark; i++)
                        {
                            sayi1 = sayi1 + 0;
                        }

                        sayi1_Virgul += fark; //Çarpma için kullanılıyor.
                        return sayi2_virgül_oncesi.Length;
                    }
                    if (sayi1_virgül_oncesi.Length > sayi2_virgül_oncesi.Length)
                    {
                        for (int i = 0; i < fark; i++)
                        {
                            sayi2 = sayi2 + 0;
                        }

                        sayi2_Virgul += fark; //Çarpma için kullanılıyor.
                        return sayi1_virgül_oncesi.Length;
                    }
                }
                return sayi1_virgül_oncesi.Length;
            }
            return 0;
        }

        //Sayıların uzunluklarını eşitlemek için.
        void SifirEkleme(string s1, string s2)
        {
            if (s1.Length != s2.Length) // İki string ifadenin uzunluklarının eşit olup olmadığına bakılır.
            {
                int fark = Math.Abs(s1.Length - s2.Length);

                if (s1.Length < s2.Length)
                {
                    for (int i = 0; i < fark; i++)
                    {
                        sayi1 = "0" + sayi1;
                    }
                }

                if (s1.Length > s2.Length)
                {
                    for (int i = 0; i < fark; i++)
                    {
                        sayi2 = "0" + sayi2;
                    }
                }
            }
        }

        //Sayının değerinin değiştirmeyen sıfırları siler.
        string SifirSilme(string sonuc)
        {
            char OndalikAyrac = ',';
            int sayac = 0;
            int sifir = 0;

            for (int i = 0; i < sonuc.Length; i++)
            {
                if (sonuc[i].ToString() != "0")
                {
                    sifir = 1;
                    break;
                }
                sayac++;
            }

            if (sifir == 0) //Sonuc 000 gibi bi ifade olursa diye kontrol yapılıyor.
            {
                sonuc = "0";
            }
            else
            {
                sonuc = sonuc.Substring(sayac, sonuc.Length - sayac);
                sayac = 0;
            }

            if (sonuc[0] == ',')
            {
                sonuc = "0" + sonuc;
            }

            if (sonuc.IndexOf(OndalikAyrac) > 0) // Sonucta virgül varsa bakılıyor.
            {
                for (int i = sonuc.Length - 1; i >= 0; i--)
                {
                    if (sonuc[i].ToString() != "0")
                    {
                        break;
                    }
                    sayac++;
                }

                sonuc = sonuc.Substring(0, sonuc.Length - sayac);
                sayac = 0;
            }

            if (sonuc[0] == ',')
            {
                sonuc = "0" + sonuc;
            }

            if (sonuc[sonuc.Length - 1] == ',') //Gereksiz sıfırlar atıldıktan sonra sayının sonunda , kalırsa oda atılıyor.
            {
                sonuc = sonuc.Substring(0, sonuc.Length - 1);
            }

            return sonuc;
        }

        //İki sayıyı karşılaştırır var büyük olanı bulur.
        bool Karsilastirma(string s1, string s2)
        {
            int VirgulVarmi = kontrolOndalikSayi(s1, s2);
            SifirEkleme(sayi1, sayi2);

            for (int i = 0; i < sayi1.Length; i++)
            {
                if (Convert.ToInt32(sayi1[i]) > Convert.ToInt32(sayi2[i]))
                {
                    return true;
                }
                else if (Convert.ToInt32(sayi1[i]) < Convert.ToInt32(sayi2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // Bölünen sayı içerisinde kaç tane bölen sayı olduğuna bakar.
        int CarpanBulma(string s1, string s2)
        {
            // s1 : bölünen sayi
            // s2 : bölen sayi
            string Carpan = "";

            for (int i = 1; i <= 10; i++)
            {
                Carpan = this.Carp(s2, i.ToString());

                if (this.Karsilastirma(Carpan, s1)) //Carpan bölünen sayidan büyükse içine gir.
                {
                    if (this.Karsilastirma("0", this.Cikar(Carpan, s1))) //Carpan ile bölünen sayi eşitmi diye bakılır. İki sayi cikarmaya gönderilerek sonuc sıfırsa eşittir.
                    {
                        return i;
                    }
                    else
                    {
                        return i - 1;
                    }
                }
            }
            return 0;
        }
    }
}
