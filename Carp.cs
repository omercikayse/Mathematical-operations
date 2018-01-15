using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islem
{
    partial class Islem
    {
        public string Carp(string s1, string s2)
        {
            string sonuc = "";

            int VirgulVarmi = kontrolOndalikSayi(s1, s2);

            List<string> dizi = new List<string>();

            int elde = 0;
            int BasamakKaydirma = 0;

            for (int i = sayi1.Length - 1; i >= 0; i--)
            {
                for (int j = sayi2.Length - 1; j >= 0; j--)
                {
                    int k0 = Convert.ToInt32(sayi1[i].ToString());
                    int k1 = Convert.ToInt32(sayi2[j].ToString());

                    int k_sayi = k0 * k1;

                    if (k_sayi < 10)
                    {
                        if (elde != 0)
                        {
                            k_sayi += elde;
                            elde = 0;
                        }

                        if (j == 0)
                        {
                            sonuc = k_sayi.ToString() + sonuc;
                        }

                        else
                        {
                            if (k_sayi.ToString().Length == 1)
                            {

                                sonuc = k_sayi.ToString() + sonuc;
                            }
                            else
                            {
                                string c_sayi = k_sayi.ToString();

                                char son_deger = c_sayi[c_sayi.Length - 1];
                                elde = Convert.ToInt32(c_sayi[c_sayi.Length - 2].ToString());

                                sonuc = son_deger.ToString() + sonuc;
                            }
                        }
                    }
                    else
                    {
                        if (elde != 0)
                        {
                            k_sayi += elde;
                        }

                        if (j == 0)
                        {
                            sonuc = k_sayi.ToString() + sonuc;
                        }
                        else
                        {
                            string c_sayi = k_sayi.ToString();

                            char son_deger = c_sayi[c_sayi.Length - 1];
                            elde = Convert.ToInt32(c_sayi[c_sayi.Length - 2].ToString());

                            sonuc = son_deger.ToString() + sonuc;
                        }
                    }
                }

                for (int p = 0; p < BasamakKaydirma; p++)
                {
                    sonuc += "0";
                }
                BasamakKaydirma += 1;

                dizi.Add(sonuc);
                elde = 0;
                sonuc = "";
            }

            if (dizi.Count == 1)
            {
                sonuc = dizi[0].ToString();
                return sonuc;
            }
            else
            {
                sonuc = Topla(dizi[0], dizi[1]);

                for (int n = 2; n <= dizi.Count - 1; n++)
                {
                    sonuc = Topla(sonuc, dizi[n]);
                }
            }

            if (VirgulVarmi > 0)
            {
                sonuc = sonuc.Insert(sonuc.Length - (sayi1_Virgul + sayi2_Virgul), ",");
            }

            sonuc = SifirSilme(sonuc);

            sayi1 = "";
            sayi2 = "";

            return sonuc;
        }
    }
}
