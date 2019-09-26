using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace dpuyzt
{
    class sqlbaglanti
    {
        public SQLiteConnection bgl()
        {
            SQLiteConnection baglan = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\dpuyzt.db; Version=3;ReadOnly=False;");
            baglan.Open();
            return baglan;
        }
    }
}
