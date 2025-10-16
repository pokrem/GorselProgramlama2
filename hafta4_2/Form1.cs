using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace hafta4
{
    public partial class Form1 : Form
    {
        private const int BUTON_ADEDI = 10;
        private Random rastgele = new Random();

        private int kalanSure = 60;
        private bool oyunBitti = false;

        private int toplamCiftSayiAdedi = 0;
        private int toplananCiftSayiAdedi = 0;

        public Form1()
        {
            InitializeComponent();
            lblSure.Text = "SÜRE\n" + kalanSure.ToString("D2") + " sn";
            btnOyunuBitir.Enabled = false;

        }

        private void btnOyunaBasla_Click(object sender, EventArgs e)
        {
            OyunuBaslat();
        }

        private void btnOyunuBitir_Click(object sender, EventArgs e)
        {
            OyunuBitir(false); 
        }

        private void timerHareket_Tick(object sender, EventArgs e)
        {
            if (oyunBitti) return;

            kalanSure--;
            lblSure.Text = "SÜRE\n" + kalanSure.ToString("D2") + " sn";

            if (kalanSure <= 0)
            {
                OyunuBitir(true);
                MessageBox.Show("SÜRE DOLDU! Tüm çift sayılara tıklayarak bitiremediniz.", "Oyun Bitti - Zaman Doldu");
                return;
            }

            foreach (Control control in pnlOyunAlani.Controls)
            {
                if (control is Button btn)
                {
                    KonumGuncelle(btn);
                }
            }
        }

        private void OyunuBaslat()
        {
            pnlOyunAlani.Controls.Clear();
            lbxCiftSayilar.Items.Clear();

            toplamCiftSayiAdedi = 0;
            toplananCiftSayiAdedi = 0;

            kalanSure = 60;
            lblSure.Text = "SÜRE\n" + kalanSure.ToString("D2") + " sn";
            oyunBitti = false;

            for (int i = 0; i < BUTON_ADEDI; i++)
            {
                Button btn = new Button();
                btn.Width = 50;
                btn.Height = 30;

                int sayi = rastgele.Next(1, 101);
                btn.Text = sayi.ToString();

                if (sayi % 2 == 0)
                {
                    toplamCiftSayiAdedi++;
                }

                btn.Click += new EventHandler(Buton_Click);

                pnlOyunAlani.Controls.Add(btn);
                KonumGuncelle(btn);
            }

            timerHareket.Start();

            btnOyunuBitir.Enabled = true;
            btnOyunaBasla.Enabled = false;
        }

        private void Buton_Click(object sender, EventArgs e)
        {
            if (oyunBitti) return;

            Button tiklananButon = (Button)sender;
            int sayi = int.Parse(tiklananButon.Text);

            if (sayi % 2 == 0)
            {
                pnlOyunAlani.Controls.Remove(tiklananButon);
                tiklananButon.Dispose();

                lbxCiftSayilar.Items.Add(sayi);

                toplananCiftSayiAdedi++;

                if (toplananCiftSayiAdedi == toplamCiftSayiAdedi)
                {
                    OyunuBitir(false);
                   
                }
            }
            else
            {
              
                MessageBox.Show("Yanlış! Sadece ÇİFT sayılara tıklamalısın. Buton silinmedi.", "Hata");
            }
        }

        private void KonumGuncelle(Button btn)
        {
            int maxX = pnlOyunAlani.Width - btn.Width;
            int maxY = pnlOyunAlani.Height - btn.Height;

            if (maxX > 0 && maxY > 0)
            {
                int yeniX = rastgele.Next(0, maxX);
                int yeniY = rastgele.Next(0, maxY);
                btn.Location = new Point(yeniX, yeniY);
            }
        }

        private void OyunuBitir(bool isTimeUp)
        {
            if (oyunBitti) return;

            timerHareket.Stop();
            oyunBitti = true;

            if (!isTimeUp)
            {
                bool siralamaDogruMu = SiralamaYap(); 

                if (siralamaDogruMu)
                {
                    
                    MessageBox.Show(kalanSure + " Saniye Kala Oyunu Başarıyla Bitirdin! Çift sayılar küçükten büyüğe sıralandı.", "Tebrikler!");
                }
                else
                {
                  
                    MessageBox.Show("Sıralama Yanlış Hatası! Çift sayılar ListBox'a eklendi ancak sıralama doğru değildi. Lütfen ListBox'a eklerken sıraya dikkat edin.", "Hata");
                }
            }

            btnOyunaBasla.Enabled = true;
            btnOyunuBitir.Enabled = false;
        }


        private bool SiralamaYap()
        {
          
            List<int> mevcutSiralama = new List<int>();
            foreach (var item in lbxCiftSayilar.Items)
            {
                if (int.TryParse(item.ToString(), out int sayi))
                {
                    mevcutSiralama.Add(sayi);
                }
            }

            
            if (mevcutSiralama.Count == 0)
            {
               
                lbxCiftSayilar.Items.Clear();
               
                return false;
            }

           
            List<int> dogruSiralama = new List<int>(mevcutSiralama);
            dogruSiralama.Sort(); 


            bool siralamaDogruMu = true;
            for (int i = 0; i < mevcutSiralama.Count; i++)
            {
                if (mevcutSiralama[i] != dogruSiralama[i])
                {
                    siralamaDogruMu = false;
                    break;
                }
            }

            lbxCiftSayilar.Items.Clear();
            foreach (int sayi in dogruSiralama)
            {
                lbxCiftSayilar.Items.Add(sayi);
            }

            return siralamaDogruMu;
        }


    }
}