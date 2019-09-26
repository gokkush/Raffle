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

    public partial class Anamenu : Form
    {
        public Anamenu()
        {
            InitializeComponent();
        }
        public static bool admin;
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Katilimci frm = new Katilimci();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (admin==true)
            {
                Kullanici frm = new Kullanici();
                frm.Show();
                button5.Visible = true;
            }
            else
            {
                kullanici2 frm = new kullanici2();
                frm.Show();
                button5.Visible = false;
            }
        }

        private void Anamenu_Load(object sender, EventArgs e)
        {
            if (admin == true)
            {
                button2.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
            }
            else
            {
                button2.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                
            }
        }

        private void Anamenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sqlbaglanti baglan = new sqlbaglanti();
            SQLiteCommand komut = new SQLiteCommand("delete from CEKILISSONUC", baglan.bgl());
            komut.ExecuteNonQuery();    
        }
    }
}
