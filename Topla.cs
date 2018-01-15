using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islem
{
    partial class Islem
    {
        public string Topla(string s1, string s2)
        {
            string sonuc = "";

            int VirgulVarmi = kontrolOndalikSayi(s1, s2);
            SifirEkleme(sayi1, sayi2);

            int elde = 0;

            for (int i = sayi1.Length - 1; i >= 0; i--)
            {
                int k1 = Convert.ToInt32(sayi1[i].ToString());
                int k2 = Convert.ToInt32(sayi2[i].ToString());

                int k_sayi = k1 + k2;

                if (k_sayi < 10)
                {
                    //Elde varsa olan sayıyı ekle
                    if (elde == 1)
                    {
                        k_sayi += 1;
                        elde = 0;
                    }
                    // Ilk sayı yı özelle olarak topla
                    if (i == 0)
                    {
                        sonuc = k_sayi.ToString() + sonuc;
                    }

                    else
                    {   //Sayi iki basamaklı değilse sonuca eklenir.
                        if (k_sayi.ToString().Length == 1)
                        {

                            sonuc = k_sayi.ToString() + sonuc;
                        }
                        else //İki basamaklıysa elde varmış gibi işlem yapılır.
                        {
                            char deger = k_sayi.ToString()[k_sayi.ToString().Length - 1];

                            sonuc = deger.ToString() + sonuc;

                            elde = 1;
                        }
                    }
                }
                else // Ara toplam 10 dan buyukse
                {
                    if (elde == 1)
                    {
                        k_sayi += 1;
                        elde = 0;
                    }

                    if (i == 0)
                    {
                        sonuc = k_sayi.ToString() + sonuc;
                    }
                    else
                    {
                        char deger = k_sayi.ToString()[k_sayi.ToString().Length - 1];

                        sonuc = deger.ToString() + sonuc;

                        elde = 1;
                    }
                }
            }

            if (VirgulVarmi > 0)
            {
                sonuc = sonuc.Substring(0, sonuc.Length - VirgulVarmi) + VirgulAyrac + sonuc.Substring(sonuc.Length - VirgulVarmi);
            }

            sonuc = SifirSilme(sonuc); // Sayının başında ve sonunda olan gereksiz sıfırlar atılır.

            sayi1 = "";
            sayi2 = "";

            return sonuc;
        }
    }
}
