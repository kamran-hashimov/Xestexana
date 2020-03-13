using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmRandevuListesi : Form
    {
        public frmRandevuListesi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();


        
        private void frmRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        frmSekreterDetay frm = new frmSekreterDetay();
        public int secilen; 
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            frm.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            frm.Tarih = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            frm.Saat = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            frm.Brans = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            frm.Doktor = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            frm.Tc = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            
            this.Hide();
            frm.Show();
        }

     
    }
}
