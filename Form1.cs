using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Islem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Islem i = new Islem();

        private void btnTopla_Click(object sender, EventArgs e)
        {
            string s1 = txtSayi1.Text;
            string s2 = txtSayi2.Text;

            if (s1 == "" || s2 == "")
            {
                XtraMessageBox.Show("Sayi1 ve Sayi2 boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Regex reg = new Regex(@"^-?[0-9]*,?[0-9]*?$");

                if ((reg.IsMatch(s1)) && reg.IsMatch(s2))
                {
                    IsaretBulma(s1, s2);

                    if (sayi1_isaret == 1 && sayi2_isaret == 1)
                    {
                        txtSonuc.Text = "-" + i.Topla(sayi1, sayi2);
                        sayi1_isaret = 0;
                        sayi2_isaret = 0;
                    }
                    else if (sayi1_isaret == 0 && sayi2_isaret == 1)
                    {
                        string s = i.Cikar(sayi1, sayi2);

                        if (Islem.isaret == 1)
                        {
                            if (s == "0")
                            {
                                txtSonuc.Text = s;
                            }
                            else
                            {
                                txtSonuc.Text = "-" + s;
                            }
                            Islem.isaret = 0;
                        }
                        else
                        {
                            txtSonuc.Text = s;
                        }

                        sayi1_isaret = 0;
                        sayi2_isaret = 0;
                    }
                    else if (sayi1_isaret == 1 && sayi2_isaret == 0)
                    {
                        string s = i.Cikar(sayi2, sayi1);

                        if (Islem.isaret == 1)
                        {
                            if (s == "0")
                            {
                                txtSonuc.Text = s;
                            }
                            else
                            {
                                txtSonuc.Text = "-" + s;
                            }
                            Islem.isaret = 0;
                        }
                        else
                        {
                            txtSonuc.Text = s;
                        }

                        sayi1_isaret = 0;
                        sayi2_isaret = 0;
                    }
                    else
                    {
                        txtSonuc.Text = i.Topla(sayi1, sayi2);
                    }

                }
                else
                {
                    MessageBox.Show("Gecerli değil.");
                }

            }
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            string s1 = txtSayi1.Text;
            string s2 = txtSayi2.Text;

            if (s1 == "" || s2 == "")
            {
                XtraMessageBox.Show("Sayi1 ve Sayi2 boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Regex reg = new Regex(@"^-?[0-9]*,?[0-9]*?$");

                if ((reg.IsMatch(s1)) && reg.IsMatch(s2))
                {
                    int isaretVarmi = IsaretBulma(s1, s2);

                    if (sayi1_isaret == 1 && sayi2_isaret == 1)
                    {
                        string s = i.Cikar(sayi1, sayi2);

                        if (Islem.isaret == 1)
                        {
                            if (s == "0")
                            {
                                txtSonuc.Text = s;
                            }
                            else
                            {
                                if (isaretVarmi == 1)
                                {
                                    txtSonuc.Text = s;
                                }
                                else
                                {
                                    txtSonuc.Text = "-" + s;
                                }
                            }
                            Islem.isaret = 0;
                        }
                        else
                        {
                            txtSonuc.Text = "-" + s;
                        }

                        sayi1_isaret = 0;
                        sayi2_isaret = 0;
                    }

                    else if (sayi1_isaret == 0 && sayi2_isaret == 1)
                    {
                        txtSonuc.Text = i.Topla(sayi1, sayi2);
                        sayi1_isaret = 0;
                        sayi2_isaret = 0;
                    }

                    else if (sayi1_isaret == 1 && sayi2_isaret == 0)
                    {
                        txtSonuc.Text = "-" + i.Topla(sayi1, sayi2);
                        sayi1_isaret = 0;
                        sayi2_isaret = 0;
                    }
                    else
                    {
                        string s = i.Cikar(sayi1, sayi2);

                        if (Islem.isaret == 1)
                        {
                            if (s == "0")
                            {
                                txtSonuc.Text = s;
                            }
                            else
                            {
                                txtSonuc.Text = "-" + s;
                            }
                            Islem.isaret = 0;
                        }
                        else
                        {
                            txtSonuc.Text = s;
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Gecerli değil.");
                }
            }
        }

        private void btnCarp_Click(object sender, EventArgs e)
        {
            string s1 = txtSayi1.Text;
            string s2 = txtSayi2.Text;

            if (s1 == "" || s2 == "")
            {
                XtraMessageBox.Show("Sayi1 ve Sayi2 boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Regex reg = new Regex(@"^-?[0-9]*,?[0-9]*?$");

                if ((reg.IsMatch(s1)) && reg.IsMatch(s2))
                {
                    int isaretVarmi = IsaretBulma(s1, s2);
                    string s = i.Carp(sayi1, sayi2);

                    if (isaretVarmi == 1)
                    {
                        if (sayi1_isaret == 1 && sayi2_isaret == 1)
                        {
                            txtSonuc.Text = s;
                            sayi1_isaret = 0;
                            sayi2_isaret = 0;
                        }
                        else
                        {
                            txtSonuc.Text = "-" + s;
                            sayi1_isaret = 0;
                            sayi2_isaret = 0;
                        }
                    }
                    else
                    {
                        txtSonuc.Text = s;
                    }
                }
                else
                {
                    MessageBox.Show("Gecerli değil.");
                }
            }
        }

        private void btnBol_Click(object sender, EventArgs e)
        {
            string s1 = txtSayi1.Text;
            string s2 = txtSayi2.Text;

            if (s1 == "" || s2 == "")
            {
                XtraMessageBox.Show("Sayi1 ve Sayi2 boş bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Regex reg = new Regex(@"^-?[0-9]*,?[0-9]*?$");

                if ((reg.IsMatch(s1)) && reg.IsMatch(s2))
                {
                    int isaretVarmi = IsaretBulma(s1, s2);
                    string s = i.Bol(sayi1, sayi2);

                    if (isaretVarmi == 1)
                    {
                        if (sayi1_isaret == 1 && sayi2_isaret == 1)
                        {
                            txtSonuc.Text = s;
                            sayi1_isaret = 0;
                            sayi2_isaret = 0;
                        }
                        else
                        {
                            txtSonuc.Text = "-" + s;
                            sayi1_isaret = 0;
                            sayi2_isaret = 0;
                        }
                    }
                    else
                    {
                        txtSonuc.Text = s;
                    }
                }
                else
                {
                    MessageBox.Show("Gecerli değil.");
                }
            }
            Islem.isaret = 0;
        }

        public static int sayi1_isaret = 0;
        public static int sayi2_isaret = 0;

        public static string sayi1;
        public static string sayi2;

        public int IsaretBulma(string s1, string s2)
        {
            sayi1 = s1;
            sayi2 = s2;

            if (s1[0].ToString() == "-" || s2[0].ToString() == "-")
            {
                if (s1[0].ToString() == "-")
                {
                    sayi1 = s1.Substring(1, s1.Length - 1);
                    sayi1_isaret = 1;
                }

                if (s2[0].ToString() == "-")
                {
                    sayi2 = s2.Substring(1, s2.Length - 1);
                    sayi2_isaret = 1;
                }
                return 1;
            }
            return 0;
        }
    }
}
