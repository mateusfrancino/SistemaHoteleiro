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
    public partial class FrmRelHospedes : Form
    {
        public FrmRelHospedes()
        {
            InitializeComponent();
        }

        private void FrmRelHospedes_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hotelDataSet.hospedesRel'. Você pode movê-la ou removê-la conforme necessário.
            this.hospedesRelTableAdapter.Fill(this.hotelDataSet.hospedesRel);

            this.reportViewer1.RefreshReport();
        }
    }
}
