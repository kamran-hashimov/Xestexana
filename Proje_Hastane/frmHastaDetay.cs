using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{

    public partial class frmHastaDetay : Form
    {
        public frmHastaDetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TC;

        private void frmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTcNo.Text = TC;
            

            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTcNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();



            //Randevu gecmisi
            DataTable dt = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter("Select * from Tbl_Randevular where HastaTc = " + TC ,bgl.baglanti());
            data.Fill(dt);
            dataGridView1.DataSource = dt;


            //Branslari cekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans = @p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans = '" + cmbBrans.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBilgiDuzenle fr = new frmBilgiDuzenle();
            fr.TCno = lblTcNo.Text;
            fr.Show();
        }
    }
}
