using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmHastaGiris : Form
    {
        public frmHastaGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHastaKayit frm = new frmHastaKayit();
            frm.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar where HastaTc = @p1 and HastaSifre = @p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmHastaDetay fr = new frmHastaDetay();
                fr.TC = mskTcNo.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali TC ve ya sifre");
            }
            bgl.baglanti().Close();

        }
    }
}
