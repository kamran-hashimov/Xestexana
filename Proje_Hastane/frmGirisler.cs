using System;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class frmGirisler : Form
    {
        public frmGirisler()
        {
            InitializeComponent();
        }
        private void btnHastaGirisi_Click(object sender, EventArgs e)
        {
            frmHastaGiris frm = new frmHastaGiris();
            frm.Show();
            this.Hide();
        }

        private void btnDoktorGirisi_Click(object sender, EventArgs e)
        {
            frmDoktorGiris frm = new frmDoktorGiris();
            frm.Show();
            this.Hide();
        }

        private void btnSekreterGirisi_Click(object sender, EventArgs e)
        {
            frmSekreter frm = new frmSekreter();
            frm.Show();
            this.Hide();
        }
    }
}
