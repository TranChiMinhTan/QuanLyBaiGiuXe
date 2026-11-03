using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmVeThang : Form
    {
        private VeThangBLL bll =
            new VeThangBLL();

        public FrmVeThang()
        {
            InitializeComponent();
        }

        private void FrmVeThang_Load(
            object sender,
            EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvVeThang.DataSource =
                    bll.GetAll();
            }
            catch (
