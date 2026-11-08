using BLL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmChoTrong : Form
    {
        private ChoTrongBLL bll =
            new ChoTrongBLL();

        public FrmChoTrong()
        {
            InitializeComponent();
        }

        private void FrmChoTrong_Load(
            object sender,
            EventArgs e)
        {
            TaiDuLieu();
        }

        private void btnTaiLai_Click(
            object sender,
            EventArgs e)
        {
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            try
            {
                dgvChoTrong.DataSource =
                    bll.LayBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}
