using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dapper;
using System.Data.SqlClient;
using Dapper;

namespace dapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //string connectionString = "Data Source=216-15\\SQLEXPRESS;Initial Catalog=Musteriler;User ID=sa; Password=Fbu123456";
        //string connectionString1 = "Data Source = 216-15\\SQLEXPRESS;Initial Catalog = Musteriler; User ID = sa Password=Fbu123456";
        
        SqlConnection SqlCon = new SqlConnection("Data Source=216-15\\SQLEXPRESS;Initial Catalog=Musteriler;User ID=sa; Password=Fbu123456");

        int id = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void FillDataGridView()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Aramametni", search.Text.Trim());
            List<MusteriBilgileri> list = SqlCon.Query<MusteriBilgileri>("MusteriArama", param, commandType: CommandType.StoredProcedure).ToList<MusteriBilgileri>();
            dgvmusteri.DataSource = list;
            dgvmusteri.Columns[0].Visible= false;

        }
        void clear()
        {

        }

        class MusteriBilgileri
        {
            public int id { get; set; }
            public string Adı { get; set; }
            public string Soyadı { get; set; }
            public bool sil { get; set; }
            public string Adres { get; set; }

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
