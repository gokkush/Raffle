using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dpuyzt
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Random rndm = new Random();
        sqlbaglanti baglan = new sqlbaglanti();
        public static List<int> katilimciid = new List<int>();
        int id,adet,kazanansayi;
        string kazanilanurun;
        int kazananid = 0;
        string kazananad = "";
        string kazanansoyad = "";
        string kazananemail = "";
        void datadoludur2()
        {
            try
            {
                SQLiteCommand komut = new SQLiteCommand("Select *from CEKILISSONUC", baglan.bgl());
                SQLiteDataAdapter da = new SQLiteDataAdapter(komut);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                dataGridView2.AutoResizeColumns();
                dataGridView2.Columns[0].Visible = false;
            }
            catch
            {
            }
        }
        void datadoldur()
        {
            try
            {
                SQLiteCommand komut = new SQLiteCommand("Select *from HEDIYE", baglan.bgl());
                SQLiteDataAdapter da = new SQLiteDataAdapter(komut);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.AutoResizeColumns();
                dataGridView1.Columns[0].Visible = false;
            }
            catch
            {
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            datadoldur();
            datadoludur2();
            button1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlbaglanti baglan = new sqlbaglanti();
            SQLiteCommand komut1 = new SQLiteCommand("Select ID from KATILIMCILAR", baglan.bgl());
            SQLiteDataReader oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                katilimciid.Add(Convert.ToInt32(oku["ID"]));
            }
            button2.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adet--;
            SQLiteCommand komut = new SQLiteCommand("update HEDIYE set ADET='" + adet + "' where ID='" + id + "'", baglan.bgl());
            komut.ExecuteNonQuery();
            try
            {
                SQLiteCommand komut2 = new SQLiteCommand("delete from HEDIYE where ADET like '0'", baglan.bgl());
                komut2.ExecuteNonQuery();
            }
            catch
            {
            }
            SQLiteCommand komut3 = new SQLiteCommand("insert into CEKILISSONUC (AD,SOYAD,EMAIL,KATILIMCIID,KAZANILAN) values ('" + kazananad.ToString() + "','" + kazanansoyad.ToString() + "','" + kazananemail.ToString() + "','" + kazananid + "','" + kazanilanurun.ToString() + "')", baglan.bgl());
            komut3.ExecuteNonQuery();
            datadoldur();
            datadoludur2();
            
            SQLiteCommand komut4 = new SQLiteCommand("delete from KATILIMCILAR where ID ='" + katilimciid[kazanansayi] + "'", baglan.bgl());
            komut4.ExecuteNonQuery();
            katilimciid.RemoveAt(kazanansayi);
            button1.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";

            kazanansayi = rndm.Next(0, katilimciid.Count);

            SQLiteCommand komut1 = new SQLiteCommand("Select *from KATILIMCILAR where ID like '" + katilimciid[kazanansayi] + "'", baglan.bgl());
            SQLiteDataReader oku = komut1.ExecuteReader();
            while(oku.Read())
            {
                kazananad = oku["AD"].ToString().ToUpper();
                kazanansoyad = oku["SOYAD"].ToString().ToUpper();
                kazananid = Convert.ToInt32(oku["ID"]);
                kazananemail = oku["EMAIL"].ToString();
            }
            label2.Text = "SAYIN " + kazananad.ToString() + " " + kazanansoyad.ToString() + " TEBRİKLER.";
            button1.Enabled = false;
            button1.Visible = false;
            button3.Visible = true;
            button4.Visible = true;



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
            button1.Visible = true;
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label3.Text = "" + dataGridView1.Rows[secilen].Cells[1].Value.ToString() + " ADLI HEDİYENİN ÇEKİLİŞİ HAZIR....";
            id = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
            adet= Convert.ToInt32(dataGridView1.Rows[secilen].Cells[2].Value.ToString());
            kazanilanurun = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            label2.Text = "";
            label3.Text = "";

        }
    }
}
