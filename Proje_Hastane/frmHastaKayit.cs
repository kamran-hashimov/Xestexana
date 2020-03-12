using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmHastaKayit : Form
    {
        public frmHastaKayit()
        {
            InitializeComponent();
        }
        
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd, HastaSoyad,HastaTc,HastaTelefon,HastaSifre,HastaCinsiyyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskKimlik.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefonNo.Text);
            komut.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbCinsiyyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayidiniz gerceklesmistir Sifreniz:" + txtSifre.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
