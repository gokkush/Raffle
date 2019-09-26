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
    public partial class Katilimci : Form
    {
        public Katilimci()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Katilimci_FormClosing(object sender, FormClosingEventArgs e)
        {  
        }
        public void datadoldur()
        {
            sqlbaglanti baglan = new sqlbaglanti();
            SQLiteCommand komut = new SQLiteCommand("Select *from KATILIMCILAR", baglan.bgl());
            SQLiteDataAdapter da = new SQLiteDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
          //  dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
        }
        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                sqlbaglanti baglan = new sqlbaglanti();
                SQLiteCommand komut = new SQLiteCommand("insert into KATILIMCILAR (AD,SOYAD,TC,OKULNO,BOLUM,SINIF,TELEFON,ADRES,EMAIL) values ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','"+textBox10.Text+"')", baglan.bgl());
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı.");
                datadoldur();
                temizle();
            }
            catch
            {
                MessageBox.Show("Kaydedilirken hata oluştu.");
            }
        }

        private void Katilimci_Load(object sender, EventArgs e)
        {
            datadoldur();
        }



        private void Katilimci_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                temizle();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlbaglanti baglan = new sqlbaglanti();
            SQLiteCommand komut = new SQLiteCommand("Select * from KATILIMCILAR where AD like '%" + textBox9.Text + "%' or SOYAD like '%" + textBox9.Text + "%' or TC like '%" + textBox9.Text + "%'", baglan.bgl());
            SQLiteDataAdapter da = new SQLiteDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].Visible = false;
            textBox9.Focus();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
                        
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sqlbaglanti baglan = new sqlbaglanti();
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Form2 frm = new Form2();
            Form2.a1 = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            Form2.a2 = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            Form2.a3 = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            Form2.a4 = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            Form2.a5 = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            Form2.a6 = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            Form2.a7 = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            Form2.a8 = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            Form2.a9 = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            Form2.id = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
            frm.ShowDialog();

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
    }
}
