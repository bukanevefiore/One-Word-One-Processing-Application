using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using System.IO;






namespace sayıBulma
{
    public partial class HarfOyunuForm : Form
    {
        public HarfOyunuForm()
        {
            InitializeComponent();
        }

        
       



        char[] harfler = new char[9];  // random üretilen harfler veya girilen harfler buraya yazdırılır 
        Random rnd = new Random();
        int i = 0, d=0;
        string kelime="";         // random üretilen harfler veya girilen harfler buraya yazdırılır        
        int tpuan = 0;
        int sayac = 0;
        string[] txtdizi = new string[63733]; //dosyadaki kelimeler       
        int[] harflerinsayihali = new int[8];
        string üretilenkelime="";    // üretilen en uzun kelime


        //random harf üretme kısmı
        void randomharfüret()
        {
            // random 8 tane harf ürettik
            for (i = 0; i < 8; i++)
            {
                int kod = rnd.Next(97, 123);  // sayı üretiyoruz
                harflerinsayihali[i] = kod;
                char harf = Convert.ToChar(kod); // sayılara karşılık gelen harfler
                kelime += harf;   // harfleri kelime değişkenine atadık
                harfler[i] = harf;
               
            }

        }

        //dosyadaki kelimeleri diziye aktarma
        void aktarma()
        {

            FileStream oku = new FileStream(@"C:/Users/pc/Desktop/yazılım yapımı ödev/kelimeler.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            StreamReader yaz = new StreamReader(oku);


           
             
            while (yaz.EndOfStream != true)
            {
                
                txtdizi[d] = yaz.ReadLine();

                d = d + 1;

            }

          
        /*
            for (i = 0; i < 30; i++)
            {
                listBox1.Items.Add(txtdizi[i]);
            }
         */   
        }
        
        
            //dizideki kelimelerden uygun en uzun olaan kelimeyi bulmaya çalışıyoruz
          
        int j, k;
        int tutanharf = 0;  // kelime ile random harfler karşılaştırırken tutan harf sayısını burda arttırırız ki 
                                 //mevcut kelimemeizin tüm harflerinin random da bulunması kontrolünü yaparız
        string aranacak = "";
        string silkelime = "";
       


        void kelimebulma()
        {

            string geciciüretilen = "";
            for (i = 0; i < 63733; i++)
            {

                tutanharf = 0;
                aranacak = txtdizi[i];    // dosyadan karşılaştırılcak olan kelimeyi gecici bir değişkene atarız
                silkelime = kelime;   // karılık kelimemizi gecici bir değişkene atarız

                for (k = 0; k < aranacak.Length; k++)
                {

                    for (j = 0; j < silkelime.Length; j++)
                    {

                        if (Convert.ToString(silkelime[j]).Contains(aranacak[k]))
                        {
                            tutanharf++;

                            silkelime = silkelime.Remove(j, 1); // bulduğu harfi siler 
                            break;   //başka indekste aynı harfle karşılaşırsa harfi silinmemesini sağlar 
                            //yani ilk bulduğu harfi sildikten sonra durdurur bir sonraki harfi aramaya başlar
                        }
                    }


                }

                //  aranacak kelime uzunluğu tutan harf sayısıyla eşse veya tutan harf sayısı aranacak kelime 
                // uzunluğundan 1 eksikse bulunan mevcut kelime lisboxa yazdırırz.
                // aranacak.length -1  dememizin sebebi1 eksiği kadar harfin tutması durumunda da tutmayan 1 harfin
                // bonus harf olarak kullanılmasıdır.
                if (aranacak.Length == tutanharf || aranacak.Length - 1 == tutanharf)
                {

                    BulunanKelimeler.Items.Add(aranacak);
                    // anlık bulunan kelimenin daha önce bulunan kelimeden uzun olup olamdığına bakılarak 
                    // gecici üretilen değişkenine yeni değerini atarız.
                    if (geciciüretilen.Length <= aranacak.Length && aranacak.Length <= 9)
                    {
                        geciciüretilen = aranacak;

                    }

                }
            }

            // bulduğumuz en uzun kelimeyi üretilen kelime dğişkenine aktarırız
            üretilenkelime = geciciüretilen;
           
            //button2.Text = sillkelime;
        }

        // Puanlama yaptığımız kısım
        void puanlama()
        {
            kelimebulma();         
            if (üretilenkelime.Length == 2)
                {
                    tpuan += 3;
                }
                else if (üretilenkelime.Length == 3)
                {
                    tpuan += 4;
                }
                else if (üretilenkelime.Length == 4)
                {
                    tpuan += 7;
                }
                else if (üretilenkelime.Length == 5)
                {
                    tpuan += 9;
                }
                else if (üretilenkelime.Length == 6)
                {
                    tpuan += 11;
                }
                else if (üretilenkelime.Length == 8 )
                {
                    tpuan += 15;
                }
                else
                {
                    tpuan += 0;
                }
            button19.Text = Convert.ToString(tpuan);

            anlikistatistikdosyayolu();
           
            }

         void anlikistatistikdosyayolu()
        {
           
            string fileName = @"C:/Users/pc/Desktop/yazılım yapımı ödev/anlıkistatistikler.txt";

            string writeTarih = DateTime.Now.ToString(); // tarih ve saat;
            int writepuan = tpuan;

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            File.AppendAllText(fileName, Environment.NewLine + "*********KELİME OYUNU ANLIK İSTATİSLİK******" );
            File.AppendAllText(fileName, Environment.NewLine + "* " + writeTarih + "----" + "PUAN:" + writepuan);
        }

       

       
        



        private void button1_Click(object sender, EventArgs e)
        {
            //random harf üretme fonksiyonunu çağırıyoruz
            randomharfüret();
            // random harflerin yerleşeceği butonları aktif ederiz
            groupBox1.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            label12.Visible = true;
            button18.Visible = true;
            label10.Visible = true;
            button16.Visible = true;
            button2.Visible = true;
            label14.Visible = true;
            button17.Visible = true;
            button1.Visible = false;
            button3.Visible = false;


            aktarma();      //  dosyadaki kelimeleri diziye aktardığımız fonksiyonu çağırırız.

        }

        private void button2_Click(object sender, EventArgs e)
        {

           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            // harf giriş oyun bölümünün görünürlüğünü açarız
            groupBox2.Visible = true;
            label1.Visible = true; textBox1.Visible = true;
            label2.Visible = true; textBox2.Visible = true;
            label3.Visible = true; textBox3.Visible = true;
            label4.Visible = true; textBox4.Visible = true;
            label5.Visible = true; textBox5.Visible = true;
            label6.Visible = true; textBox6.Visible = true;
            label7.Visible = true; textBox7.Visible = true;
            label8.Visible = true; textBox8.Visible = true;
            button21.Visible = true;
            label11.Visible = true;textBox10.Visible = true;
            button4.Visible = true;
            label13.Visible = true;
            button20.Visible = true;
            label15.Visible = true;
            label9.Visible = true;
            button19.Visible = true;
            button1.Visible = false;



            aktarma();     //  dosyadaki kelimeleri diziye aktardığımız fonksiyonu çağırırız.

        }

        private void button4_Click(object sender, EventArgs e)
        {

            // girdiğimiz harfleri kelime değişkenine atadık

            kelime = textBox1.Text;
             harfler[0] = Convert.ToChar( textBox1.Text);
            kelime += textBox2.Text;
            harfler[1] = Convert.ToChar(textBox2.Text);
            kelime += textBox3.Text;
            harfler[2] = Convert.ToChar(textBox3.Text);
            kelime += textBox4.Text;
            harfler[3] = Convert.ToChar(textBox4.Text);
            kelime += textBox5.Text;
            harfler[4] = Convert.ToChar(textBox5.Text);
            kelime += textBox6.Text;
            harfler[5] = Convert.ToChar(textBox6.Text);
            kelime += textBox7.Text;
            harfler[6] = Convert.ToChar(textBox7.Text);
            kelime += textBox8.Text;
            harfler[7] = Convert.ToChar(textBox8.Text);

            // kullanıcının girdiği harfleri yazdırırız
            button20.Text = kelime;
            puanlama();
            button21.Text = üretilenkelime;
            //button19.Text = Convert.ToString(tpuan);
           
            
          
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void HarfOyunuForm_Load(object sender, EventArgs e)
        {


        }

        private void button15_Click(object sender, EventArgs e)
        {

           // üretilen random harfleri button tıklantıkça harf buttonlarına yazdırırz.
            sayac++;
                if (sayac == 1)
                {
                    button6.Text =Convert.ToString (harfler[0]);
                }
            else if (sayac == 2)
            {
                button7.Text = Convert.ToString(harfler[1]);
            }
            else if (sayac == 3)
            {
                button8.Text = Convert.ToString(harfler[2]);
            }
            else if (sayac == 4)
            {
                button9.Text = Convert.ToString(harfler[3]);
            }
            else if (sayac == 5)
            {
                button10.Text = Convert.ToString(harfler[4]);
            }
            else if (sayac == 6)
            {
                button11.Text = Convert.ToString(harfler[5]);
            }
            else if (sayac == 7)
            {
                button12.Text = Convert.ToString(harfler[6]);
            }
            else if (sayac == 8)
            {
                button13.Text = Convert.ToString(harfler[7]);
            }
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button16.Text = kelime;
            puanlama();
            button2.Text = üretilenkelime;
            button17.Text = Convert.ToString( tpuan);

           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Close();

        }

        private void button16_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
