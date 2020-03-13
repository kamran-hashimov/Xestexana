using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmDoktorBilgiDuzenle : Form
    {
        public frmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TC;
        private void frmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTcNo.Text = TC;
            SqlCommand komut1 = new SqlCommand("Select BransAd from Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                cmbBrans.Items.Add(dr1[0].ToString());
            }
            bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTcNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set DoktorAd = @p1 , DoktorSoyad = @p2, DoktorBrans = @p3, DoktorSifre = @p4 where DoktorTc = @p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskTcNo.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Guncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
