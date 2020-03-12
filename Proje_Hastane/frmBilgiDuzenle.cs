using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmBilgiDuzenle : Form
    {
        public frmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTCNo.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar where HastaTc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTCNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTelefonNo.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyyet.Text = dr[6].ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1,HastaSoyad = @p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyyet = @p5 where HastaTc=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTelefonNo.Text);
            komut2.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut2.Parameters.AddWithValue("p5", cmbCinsiyyet.Text);
            komut2.Parameters.AddWithValue("@p6", mskTCNo.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz guncellendi","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
