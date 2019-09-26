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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        sqlbaglanti baglan = new sqlbaglanti();
        int id;
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar)&&!char.IsPunctuation(e.KeyChar);
        }
        void datadoldur()
        {
            try
            {
                sqlbaglanti baglan = new sqlbaglanti();
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
        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            datadoldur();
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length>0&&textBox2.Text.Length>0)
            {
                sqlbaglanti baglan = new sqlbaglanti();
                SQLiteCommand komut = new SQLiteCommand("insert into HEDIYE (URUNADI,ADET,KIMDEN) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglan.bgl());
                komut.ExecuteNonQuery();
                datadoldur();
                MessageBox.Show("Hediye kaydedildi.");
                temizle();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                sqlbaglanti baglan = new sqlbaglanti();
                SQLiteCommand komut = new SQLiteCommand("update HEDIYE set URUNADI='" + textBox1.Text + "',ADET='" + textBox2.Text + "',KIMDEN='" + textBox3.Text + "' where ID='" + Convert.ToInt32(id) + "'", baglan.bgl());
                komut.ExecuteNonQuery();
                MessageBox.Show("Hediye düzenlendi.");
                datadoldur();
                temizle();
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            id = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                sqlbaglanti baglan = new sqlbaglanti();
                SQLiteCommand komut = new SQLiteCommand("delete from HEDIYE where ID='" + id + "'", baglan.bgl());
                komut.ExecuteNonQuery();
                MessageBox.Show("Hediye Silindi.");
                datadoldur();
                temizle();
                button4.Enabled = false;
                button5.Enabled = false;
            }
            catch
            {
            }
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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
