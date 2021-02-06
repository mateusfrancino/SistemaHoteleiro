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

namespace SistemaHotel.Movimentacoes
{
    public partial class FrmPdv : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string idDetVenda;
        string idProduto;
        string totalVenda;
        string ultimoIdVenda;
        string formpagamento = "";
        string modpagamento = "";

        public FrmPdv()
        {
            InitializeComponent();
        }

        private void HabilitarCampos()
        {
            txtProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            txtHospede.Enabled = true;
            txtValorUnitario.Enabled = true;
            txtTotal.Enabled = true;
            btnSalvar.Enabled = true;

        }



        private void FrmPdv_Load(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnSalvar.Enabled = true;
            Program.chamadaProdutos = "";
            txtQuantidade.Text = "";
            Program.estoqueProduto = "";
            Program.chamadaHospedes = "";
            txtValorUnitario.Text = "";
            txtTotal.Text = "0";
            rbAvista.Checked = false;
            rbCartao.Checked = false;
            rbConvenio.Checked = false;
            rbDinheiro.Checked = false;
            rbReserva.Checked = false;
            totalVenda = "0";
        }

        private void FormatarDGDetalhesVendas()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Código Venda";
            grid.Columns[2].HeaderText = "Produto";
            grid.Columns[3].HeaderText = "Quantidade";
            grid.Columns[4].HeaderText = "Valor Unitário";
            grid.Columns[5].HeaderText = "Valor Total";
            grid.Columns[6].HeaderText = "Funcionário";
            grid.Columns[7].HeaderText = "Id Produto";

            //FORMATAR COLUNA PARA MOEDA
            grid.Columns[4].DefaultCellStyle.Format = "C2";
            grid.Columns[5].DefaultCellStyle.Format = "C2";

            grid.Columns[0].Visible = false;
            grid.Columns[1].Visible = false;
            grid.Columns[7].Visible = false;

        }

        private void ListarDetalhesVendas()
        {

            con.AbrirCon();
            sql = "SELECT * from detalhes_venda where id_venda = @id_venda and funcionario = @funcionario";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_venda", "0");
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDGDetalhesVendas();
            grid.Visible = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text == "0")
            {

                MessageBox.Show("É preciso inserir produtos para venda", "Venda Sem Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


            //CÓDIGO DO BOTÃO PARA SALVAR
            con.AbrirCon();
            sql = "INSERT INTO vendas (valor_total, funcionario, hospede, status, data) VALUES (@valor_total, @funcionario, @hospede, @status, curDate())";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@valor_total", Convert.ToDouble(totalVenda));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@hospede", Program.nomeHospede);
            cmd.Parameters.AddWithValue("@status", "Efetuada");


            cmd.ExecuteNonQuery();
            con.FecharCon();

            //RECUPERAR O ULTIMA ID DA VENDA
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;
            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT id FROM vendas order by id desc LIMIT 1", con.con);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    ultimoIdVenda = Convert.ToString(reader["id"]);

                }
            }


            //SALVAR VENDA NA TABELA DE MOVIMENTAÇÕES
            con.AbrirCon();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Venda");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(totalVenda));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdVenda);


            cmd.ExecuteNonQuery();
            con.FecharCon();


            //RELACIONAR OS ITENS COM A VENDA
            con.AbrirCon();
            sql = "UPDATE detalhes_venda SET id_venda = @id_venda where id_venda = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", "0");
            cmd.Parameters.AddWithValue("@id_venda", ultimoIdVenda);


            cmd.ExecuteNonQuery();
            con.FecharCon();


            MessageBox.Show("Venda Salva com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            txtProduto.Text = "";
            txtQuantidade.Text = "";
            txtEstoque.Text = "";
            txtHospede.Text = "";
            txtValorUnitario.Text = "";
            txtTotal.Text = "0";
            rbAvista.Checked = false;
            rbCartao.Checked = false;
            rbConvenio.Checked = false;
            rbDinheiro.Checked = false;
            rbReserva.Checked = false;
            //desabilitarCampos();
            HabilitarCampos();
            ListarDetalhesVendas();
            totalVenda = "0";
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            Program.chamadaProdutos = "estoque";
            Produtos.FrmProdutos form = new Produtos.FrmProdutos();
            form.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbDinheiro.Checked)
            {
                formpagamento = rbDinheiro.Text;
            }

            if (rbCartao.Checked)
            {
                formpagamento = rbCartao.Text;
            }

            if (rbConvenio.Checked)
            {
                formpagamento = rbConvenio.Text;
            }

            if (rbAvista.Checked)
            {
                modpagamento = rbAvista.Text;
            }

            if (rbReserva.Checked)
            {
                modpagamento = rbReserva.Text;
            }


            if (txtQuantidade.Text.ToString().Trim() == "")
            {

                MessageBox.Show("Preencha a Quantidade", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.Focus();
                return;
            }


            if (Convert.ToInt32(txtEstoque.Text) < Convert.ToInt32(txtQuantidade.Text))
            {

                MessageBox.Show("Não possui produtos suficiente em estoque", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA SALVAR
            con.AbrirCon();
            sql = "INSERT INTO detalhes_venda (id_venda, produto, quantidade, valor_unitario, valor_total, funcionario, id_produto, form_pagamento, mod_pagamento, hospede ) VALUES (@id_venda, @produto, @quantidade, @valor_unitario, @valor_total, @funcionario, @id_produto, @form_pagamento, @mod_pagamento, @hospede)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_venda", "0");
            cmd.Parameters.AddWithValue("@produto", txtProduto.Text);
            cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
            cmd.Parameters.AddWithValue("@valor_unitario", Convert.ToDouble(txtValorUnitario.Text));
            cmd.Parameters.AddWithValue("@valor_total", Convert.ToDouble(txtValorUnitario.Text) * Convert.ToDouble(txtQuantidade.Text)).ToString();
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_produto", Program.idProduto);
            cmd.Parameters.AddWithValue("@form_pagamento", formpagamento);
            cmd.Parameters.AddWithValue("@mod_pagamento", modpagamento);
            cmd.Parameters.AddWithValue("@hospede", Program.nomeHospede);

            cmd.ExecuteNonQuery();
            con.FecharCon();

            //ABATER QUANTIDADE DO ESTOQUE
            con.AbrirCon();
            sql = "UPDATE produtos SET estoque = @estoque where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", Program.idProduto);
            cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) - Convert.ToInt32(txtQuantidade.Text));


            cmd.ExecuteNonQuery();
            con.FecharCon();

            //MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //TOTALIZAR A VENDA
            double total;
            total = Convert.ToDouble(totalVenda) + Convert.ToDouble(txtValorUnitario.Text) * Convert.ToDouble(txtQuantidade.Text);
            totalVenda = total.ToString();
            txtTotal.Text = string.Format("{0:c2}", total);

            txtQuantidade.Text = "";
            txtProduto.Text = "";
            txtEstoque.Text = "0";
            txtValorUnitario.Text = "";
            idDetVenda = "";
            ListarDetalhesVendas();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            idDetVenda = grid.CurrentRow.Cells[0].Value.ToString();
            txtProduto.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtQuantidade.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtValorUnitario.Text = grid.CurrentRow.Cells[4].Value.ToString();
            idProduto = grid.CurrentRow.Cells[7].Value.ToString();

            //RECUPERAR O TOTAL DO ESTOQUE DO PRODUTO
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT * FROM produtos where id = @id", con.con);
            cmdVerificar.Parameters.AddWithValue("@id", idProduto);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA
                while (reader.Read())
                {
                    txtEstoque.Text = Convert.ToString(reader["estoque"]);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.chamadaHospedes = "Hospede";
            Cadastros.FrmHospedes form = new Cadastros.FrmHospedes();
            form.Show();
        }

        private void FrmPdv_Activated(object sender, EventArgs e)
        {
            txtValorUnitario.Text = Program.valorProduto;
            txtEstoque.Text = Program.estoqueProduto;
            txtProduto.Text = Program.nomeProduto;
            txtHospede.Text = Program.nomeHospede;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnSalvar.Enabled = true;
            txtProduto.Text = "";
            txtQuantidade.Text = "";
            txtEstoque.Text = "";
            txtHospede.Text = "";
            txtValorUnitario.Text = "";
            txtTotal.Text = "0";
            rbAvista.Checked = false;
            rbCartao.Checked = false;
            rbConvenio.Checked = false;
            rbDinheiro.Checked = false;
            rbReserva.Checked = false;
            totalVenda = "0";
            btnNovo.Visible = false;
        }
    }
}
