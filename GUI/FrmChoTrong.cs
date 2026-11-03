using BLL;

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
            dgvChoTrong.DataSource =
                bll.LayBaoCao();
        }

        private void btnTaiLai_Click(
            object sender,
            EventArgs e)
        {
            dgvChoTrong.DataSource =
                bll.LayBaoCao();
        }
    }
}
