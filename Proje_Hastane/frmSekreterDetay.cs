using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmSekreterDetay : Form
    {
        public frmSekreterDetay()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTcNo.Text = TCno;

            //Ad Soyad tasima
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter where SekreterTc = @p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("p1", lblTcNo.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //branslari datagride aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da =new SqlDataAdapter("Select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;


            //Doktorlari  listeye aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' +  DoktorSoyad) as 'Doktorlar',DoktorBrans from Tbl_doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;


            //Bransi comboboxa aktarma
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values(@p1,@p2,@p3,@p4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@p1", mskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@p2", mskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu olusturuldu");
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            bgl.baglanti().Open();
            SqlCommand command = new SqlCommand("select Id from StaffDuties where Position = @p1 ",bgl.baglanti());
            command.Parameters.AddWithValue("@p1", cmbPosition.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt32(dr[0]);
            }
            command = new SqlCommand("Update Staffs set PositionId = " + id.ToString(), bgl.baglanti()); ;


            
            cmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans = @p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("p1", cmbBrans.Text);
            SqlDataReader dr = komut3.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0]+" "+dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", rchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru olusturuldu");
        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            frmDoktorPanel drp = new frmDoktorPanel();
            drp.Show();
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            frmBrans frm = new frmBrans();
            frm.Show();
        }

        private void btnRandevuPaneli_Click(object sender, EventArgs e)
        {
            frmRandevuListesi frm = new frmRandevuListesi();
            frm.Show();
        }

   
    }
}
