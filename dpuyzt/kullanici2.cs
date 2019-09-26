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
    public partial class kullanici2 : Form
    {
        public kullanici2()
        {
            InitializeComponent();
        }

        private void kullanici2_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.sifre==textBox1.Text)
            {
                sqlbaglanti baglan = new sqlbaglanti();
                SQLiteCommand komut = new SQLiteCommand("update KULLANICI set SIFRE='" + textBox2.Text + "' where KULLANICIADI='" + Form1.kullanici + "'", baglan.bgl());
                komut.ExecuteNonQuery();
                MessageBox.Show("Şifre Değiştirildi.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Eski şifreniz uyuşmuyor.");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
