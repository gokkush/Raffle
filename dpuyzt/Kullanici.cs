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
    public partial class Kullanici : Form
    {
        public Kullanici()
        {
            InitializeComponent();
        }
        bool yetki;
        int id;
        string kullanici = 0.ToString();
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = 1;
        }
        void datadoldur()
        {
            sqlbaglanti baglan = new sqlbaglanti();
            SQLiteCommand komut = new SQLiteCommand("Select *from KULLANICI", baglan.bgl());
            SQLiteDataAdapter da = new SQLiteDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].Visible = false;
        }
        private void Kullanici_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button5.Enabled = false;
            temizle();
            datadoldur();
            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                yetki = true;
            }
            else
            {
                yetki = false;
            }
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0&&textBox3.Text!=0.ToString())
            {
                sqlbaglanti baglan = new sqlbaglanti();
                if (textBox4.Text.Length>3)
                {
                    try
                    {
                        SQLiteCommand komut2 = new SQLiteCommand("Select KULLANICIADI from KULLANICI where KULLANICIADI like '" + textBox3.Text + "'", baglan.bgl());
                        SQLiteDataReader oku = komut2.ExecuteReader();
                        while (oku.Read())
                        {
                            kullanici = oku["KULLANICIADI"].ToString();
                        }
                    }
                    catch
                    {
                        
                    }
                    if (textBox3.Text.ToString()!=kullanici.ToString())
                    {
                        SQLiteCommand komut = new SQLiteCommand("insert into KULLANICI (AD,SOYAD,KULLANICIADI,SIFRE,STATU) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + yetki + "')", baglan.bgl());
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı.");
                        datadoldur();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Bu kullanıcı adı daha önce kullanılmıştır.Lütfen başka kullanıcı adı giriniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Şifre en az 4 haneli olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show("Girilen alanları kontrol ediniz. Boş olamazlar.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            id = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
            if (Convert.ToBoolean(dataGridView1.Rows[secilen].Cells[5].Value) == true)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }

            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                if (textBox4.Text.Length > 3)
                {
                    sqlbaglanti baglan = new sqlbaglanti();
                    SQLiteCommand komut = new SQLiteCommand("update KULLANICI set AD='" + textBox1.Text + "', SOYAD='" + textBox2.Text + "',KULLANICIADI='" + textBox3.Text + "',SIFRE='" + textBox4.Text + "' where ID='" + id + "'", baglan.bgl());
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme Başarılı.");
                    datadoldur();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Şifre en az 4 haneli olmalıdır.");
                }
            }
            else
            {
                MessageBox.Show("Girilen alanları kontrol ediniz. Boş olamazlar.");
            }
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                sqlbaglanti baglan = new sqlbaglanti();
                SQLiteCommand komut = new SQLiteCommand("delete from KULLANICI where ID='" + id + "'", baglan.bgl());
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı silindi.");
                datadoldur();
                temizle();
            }
            catch
            {
            }
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void Kullanici_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
