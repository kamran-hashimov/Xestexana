using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmDoktorGiris : Form
    {
        public frmDoktorGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTc=@p1 and DoktorSifre = @p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mstxtKimlikNo.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmDoktorDetay frm = new frmDoktorDetay();
                frm.Tc = mstxtKimlikNo.Text;
                frm.Ad = dr[1] + " " + dr[2];
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tc ve ya sifre yanlis");
            }
            bgl.baglanti().Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmGirisler frm = new frmGirisler();
            frm.Show();
            this.Close();
        }
    }
}
