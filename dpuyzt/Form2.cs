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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static string a1, a2, a3, a4, a5, a6, a7, a8, a9;

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        public static int id;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlbaglanti baglan = new sqlbaglanti();
                SQLiteCommand komut = new SQLiteCommand("delete from KATILIMCILAR where ID='" + Convert.ToInt32(id) + "'", baglan.bgl());
                komut.ExecuteNonQuery();
                Katilimci frm = (Katilimci)Application.OpenForms["Katilimci"];
                frm.datadoldur();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hata...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlbaglanti baglan = new sqlbaglanti();
                SQLiteCommand komut = new SQLiteCommand("update KATILIMCILAR set TC='" + textBox3.Text + "', OKULNO='" + textBox4.Text + "', AD='" + textBox1.Text + "', SOYAD='" + textBox2.Text + "', BOLUM='" + textBox5.Text + "', SINIF='" + textBox6.Text + "', TELEFON='" + textBox7.Text + "', ADRES='" + textBox8.Text + "', EMAIL='"+textBox10.Text+"' where ID='" + Convert.ToInt32(id) + "'", baglan.bgl());
                komut.ExecuteNonQuery();
                MessageBox.Show("Başarıyla Güncellendi");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hata...");
            }
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = a1.ToString();
            textBox2.Text = a2.ToString();
            textBox3.Text = a3.ToString();
            textBox4.Text = a4.ToString();
            textBox5.Text = a5.ToString();
            textBox6.Text = a6.ToString();
            textBox7.Text = a7.ToString();
            textBox8.Text = a8.ToString();
            textBox10.Text = a9.ToString();
        }
    }
}
