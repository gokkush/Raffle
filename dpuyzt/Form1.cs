using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace dpuyzt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string kullanici, sifre;
        void oku()
        {
            Anamenu frm = new Anamenu();
            sqlbaglanti baglan = new sqlbaglanti();
            SQLiteCommand komut = new SQLiteCommand("Select *from KULLANICI where KULLANICIADI like '"+textBox1.Text+"'", baglan.bgl());
            SQLiteDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                kullanici = oku["KULLANICIADI"].ToString();
                sifre = oku["SIFRE"].ToString();
                Anamenu.admin = Convert.ToBoolean(oku["STATU"]);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oku();
            Anamenu frm = new Anamenu();
            if (textBox1.Text.Length>0&&textBox2.Text.Length>0)
            {
                if (kullanici == textBox1.Text && sifre == textBox2.Text)
                {
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Boş Olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
