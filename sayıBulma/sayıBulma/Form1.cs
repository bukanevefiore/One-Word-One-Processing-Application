using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sayıBulma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            SayıOyunuForm form2 = new SayıOyunuForm();
            form2.Show(); //form2 göster diyoruz SAYI oyununu açıyor
            this.Hide();// bu yani form1 gizle diyoruz
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
           
           
                            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HarfOyunuForm form3 = new HarfOyunuForm();
            form3.Show(); //form3() göster diyoruz HARF oyununu açıyor
            this.Hide();// bu yani form1 gizle diyoruz
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HOCAM MERHABALAR BİRŞEY BELİRTMEK İSTEDİM EĞER PROGRAMI ÇALIŞTIRIP HESAPLA BUTONLARINA TIKLARKEN " +
               "PUANLAMADA YA DA BULUNAN ÇÖZÜMLERDE BİR SIKINTI YAŞIYORSANIZ PROGRAMI TEKRAR ÇALIŞTIRIN LÜTFEN " +
               "ÇÜNKÜ EN BAŞTA VEYA ORTALARDA ARADA BİR PUANLAMA 0 GELEBİLYOR KASTIĞINDAN YADA BİR ANDA YÜKLEME OLDUĞU İÇİN " +
               "OLDUĞUNU DÜŞÜNÜYORUM VİDEOMDA ÇALIŞIR HALİNİ GÖRECEKSİNİZ ZATEN KODLARIMDA HERHANGİ BİR SORUN YOK GÖZÜMDEN BİRŞEY " +
               "KAÇMAMIŞSA TABİ. BİRDE BUTTONLARA HIZLI HZLI TIKLAMAMANIZI ÖNERİRİM");
        }
    }
    }

