using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islem
{
    partial class Islem
    {
        public static int isaret = 0;

        public string Cikar(string s1, string s2)
        {
            string sonuc = "";
            int VirgulVarmi = kontrolOndalikSayi(s1, s2);
            SifirEkleme(sayi1, sayi2);

            //Gelen iki sayidan büyük olan bulunur.
            string flag = "kucuk";
            for (int i = 0; i < sayi1.Length; i++)
            {
                if (Convert.ToInt32(sayi1[i]) > Convert.ToInt32(sayi2[i]))
                {
                    flag = "buyuk"; break;
                }
                else if (Convert.ToInt32(sayi1[i]) < Convert.ToInt32(sayi2[i]))
                {
                    break;
                }

            }
            // Sayi1 küçükse sayilar değiştirilir ve sayi1 büyük sayi yapılır.
            if (flag == "kucuk")
            {
                string temp = sayi1;
                sayi1 = sayi2;
                sayi2 = temp;
                isaret = 1;
            }

            int onluk = 0;
            for (int i = sayi1.Length - 1; i >= 0; i--)
            {
                int k1 = Convert.ToInt32(sayi1[i].ToString());
                int k2 = Convert.ToInt32(sayi2[i].ToString());

                if (onluk == 0) //Bir onceki yapılan işlemde onluk alınmadıysa buraya girer.
                {
                    if (k1 < k2)
                    {
                        k1 += 10;
                        onluk = 1;
                    }
                }
                else //Bir onceki yapılan işlemde onluk alındıysa buraya girer.
                {
                    k1 -= 1;
                    if (k1 < k2)
                    {
                        k1 += 10;
                        onluk = 1;
                    }
                    else
                    {
                        onluk = 0;
                    }
                }

                int k_sayi = k1 - k2;

                char deger = k_sayi.ToString()[k_sayi.ToString().Length - 1];

                sonuc = deger.ToString() + sonuc;
            }

            if (VirgulVarmi > 0)
            {
                sonuc = sonuc.Substring(0, sonuc.Length - VirgulVarmi) + VirgulAyrac + sonuc.Substring(sonuc.Length - VirgulVarmi);
            }

            sonuc = SifirSilme(sonuc);

            sayi1 = "";
            sayi2 = "";

            return sonuc;
        }
    }
}

