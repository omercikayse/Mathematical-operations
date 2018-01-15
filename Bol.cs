using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islem
{
    partial class Islem
    {
        public string Bol(string s1, string s2)
        {
            string TempBolunen = "";
            string TempTamCarpan = "";
            string TempKalan = "";
            string sonuc = "";
            int DonenCarpan = 0;

            int VirgulVarmi = kontrolOndalikSayi(s1, s2);

            s1 = sayi1;
            s2 = sayi2;

            TempKalan = s1;
            foreach (char Bolunen in s1)
            {
                TempBolunen += Bolunen;

                if (this.Karsilastirma(TempBolunen, s2))
                {
                    DonenCarpan = this.CarpanBulma(TempBolunen, s2);
                    TempTamCarpan = this.Carp(s2, DonenCarpan.ToString());
                    TempKalan = this.Cikar(TempBolunen, TempTamCarpan);
                    sonuc += DonenCarpan;
                }
                else
                {
                    sonuc += "0";
                }

                if (DonenCarpan != 0)
                {
                    TempBolunen = TempKalan;
                    DonenCarpan = 0;
                }

            }
            //Sonucun vırgulle devam etmesi durumu. 
            sonuc += VirgulAyrac;
            for (int i = 0; i < 40; i++)
            {
                TempBolunen = this.Carp(TempKalan, "10");
                if (this.Karsilastirma(TempBolunen, s2))
                {
                    DonenCarpan = this.CarpanBulma(TempBolunen, s2);
                    TempTamCarpan = this.Carp(s2, DonenCarpan.ToString());
                    TempKalan = this.Cikar(TempBolunen, TempTamCarpan);
                    sonuc += DonenCarpan;
                }
                else
                {
                    sonuc += "0";
                    TempKalan = this.Carp(TempKalan, "10");
                }
            }

            sonuc = SifirSilme(sonuc);
            return sonuc;
        }
    }
}
