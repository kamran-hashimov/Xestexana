using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmDoktorDetay : Form
    {
        public frmDoktorDetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public string Tc;
        public string Ad;
        private void frmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTcNo.Text = Tc;
            lblAdSoyad.Text = Ad;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuDoktor = '" + lblAdSoyad.Text +"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void btnBilgiDuzenle_Click(object sender, EventArgs e)
        {
            frmDoktorBilgiDuzenle frm = new frmDoktorBilgiDuzenle();
            frm.TC = lblTcNo.Text;
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            frmDoktorGiris frm = new frmDoktorGiris();
            frm.Show();
            this.Close();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            frmDuyurular frm = new frmDuyurular();
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
