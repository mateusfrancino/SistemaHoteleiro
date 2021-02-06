using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelDiarioF : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        public FrmRelDiarioF()
        {
            InitializeComponent();
        }

        private void FrmRelDiarioF_Load(object sender, EventArgs e)
        {
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            //cbTipo.SelectedIndex = 1;
            BuscarData();
            CarregarCombobox();
            this.movimentacoesPorFuncionarioPagamentoTableAdapter.Fill(this.hotelDataSet.movimentacoesPorFuncionarioPagamento, Convert.ToDateTime(dtInicial.Text), Convert.ToDateTime(dtFinal.Text), cbTipo.Text);
            
        }

        private void BuscarData()
        {

            this.movimentacoesPorFuncionarioPagamentoTableAdapter.Fill(this.hotelDataSet.movimentacoesPorFuncionarioPagamento, Convert.ToDateTime(dtInicial.Text), Convert.ToDateTime(dtFinal.Text), cbTipo.Text);

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", dtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", dtFinal.Text));
            //this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("tipo", cbTipo.Text));
            this.reportViewer1.RefreshReport();
        }

        private void CarregarCombobox()
        {
            con.AbrirCon();
            sql = "SELECT * FROM usuarios order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbTipo.DataSource = dt;
            cbTipo.ValueMember = "id";
            cbTipo.DisplayMember = "nome";

            con.FecharCon();
        }

        private void dtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void dtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
