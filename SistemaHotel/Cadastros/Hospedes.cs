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

namespace SistemaHotel.Cadastros
{
    public partial class FrmHospedes : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;


        public FrmHospedes()
        {
            InitializeComponent();
        }


       
        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "";
            grid.Columns[1].HeaderText = "Nome";
            grid.Columns[2].HeaderText = "Data Nasc";
            grid.Columns[3].HeaderText = "Idade";
            grid.Columns[4].HeaderText = "Profissão";
            grid.Columns[5].HeaderText = "Nacionalidade";
            grid.Columns[6].HeaderText = "Sexo";
            grid.Columns[7].HeaderText = "Cpf";
            grid.Columns[8].HeaderText = "Identidade";
            grid.Columns[9].HeaderText = "Org Expeditor";
            grid.Columns[10].HeaderText = "UF";
            grid.Columns[11].HeaderText = "Endereço";
            grid.Columns[12].HeaderText = "Cep";
            grid.Columns[13].HeaderText = "Cidade";
            grid.Columns[14].HeaderText = "UF";
            grid.Columns[15].HeaderText = "Email";
            grid.Columns[16].HeaderText = "Celular";
            grid.Columns[17].HeaderText = "Telefone";


            grid.Columns[0].Visible = false;
        }

        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM hospedes order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();
            FormatarDG();
        }


        private void BuscarNome()
        {
            con.AbrirCon();
            sql = "SELECT * FROM hospedes where nome LIKE @nome order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }



        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtDataNascimento.Enabled = true;
            txtIdade.Enabled = true;
            txtEndereco.Enabled = true;
            cbNacionalidade.Enabled = true;
            txtCidade.Enabled = true;
            cbUf.Enabled = true;
            txtEmail.Enabled = true;
            cbSexo.Enabled = true;
            txtTelefone.Enabled = true;
            txtCelular.Enabled = true;
            txtProfissao.Enabled = true;
            txtCpf.Enabled = true;
            txtIdentidade.Enabled = true;
            cbOrgaoEmissor.Enabled = true;
            cbUfIdentidade.Enabled = true;
            txtCep.Enabled = true;

        }

        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtDataNascimento.Enabled = false;
            txtIdade.Enabled = false;
            txtEndereco.Enabled = false;
            cbNacionalidade.Enabled = false;
            txtCidade.Enabled = false;
            cbUf.Enabled = false;
            txtEmail.Enabled = false;
            cbSexo.Enabled = false;
            txtTelefone.Enabled = false;
            txtCelular.Enabled = false;
            txtProfissao.Enabled = false;
            txtCpf.Enabled = false;
            txtIdentidade.Enabled = false;
            cbOrgaoEmissor.Enabled = false;
            cbUfIdentidade.Enabled = false;
            txtCep.Enabled = false;

        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtDataNascimento.Text = "";
            txtIdade.Text = "";
            txtEndereco.Text = "";
            cbNacionalidade.Text = "";
            txtCidade.Text = "";
            cbUf.Text = "";
            txtEmail.Text = "";
            cbSexo.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtProfissao.Text = "";
            txtCpf.Text = "";
            txtIdentidade.Text = "";
            cbOrgaoEmissor.Text = "";
            cbUfIdentidade.Text = "";
            txtCep.Text = "";

        }




        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            desabilitarCampos();
            Listar();
            txtBuscarNome.Enabled = true;
        }



        private void BtnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnSalvar.Enabled = true;
            txtNome.Focus();
            limparCampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }

            if (txtCpf.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpf.Text = "";
                txtCpf.Focus();
                return;
            }


            //CODIGO DO BOTÃO SALVAR
            con.AbrirCon();
            sql = "INSERT INTO hospedes (nome, data_nascimento, idade, profissao, nacionalidade, sexo, cpf, identidade, orgao_expeditor, uf_identidade, endereco, cep, cidade, uf, email, celular, telefone) VALUES (@nome, @data_nascimento, @idade, @profissao, @nacionalidade, @sexo, @cpf, @identidade, @orgao_expeditor, @uf_identidade, @endereco, @cep, @cidade, @uf, @email, @celular, @telefone)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@data_nascimento", txtDataNascimento.Text);
            cmd.Parameters.AddWithValue("@idade", txtIdade.Text);
            cmd.Parameters.AddWithValue("@profissao", txtProfissao.Text);
            cmd.Parameters.AddWithValue("@nacionalidade", cbNacionalidade.Text);
            cmd.Parameters.AddWithValue("@sexo", cbSexo.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
            cmd.Parameters.AddWithValue("@identidade", txtIdentidade.Text);
            cmd.Parameters.AddWithValue("@orgao_expeditor", cbOrgaoEmissor.Text);
            cmd.Parameters.AddWithValue("@uf_identidade", cbUfIdentidade.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@cep", txtCep.Text);
            cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
            cmd.Parameters.AddWithValue("@uf", cbUf.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);

            //VERIFICAÇÃO SE EXISTE HOSPEDE CADASTRADO!
            MySqlCommand cmdVerificar;
            cmdVerificar = new MySqlCommand("SELECT * FROM hospedes where cpf = @cpf", con.con);
            cmdVerificar.Parameters.AddWithValue("@cpf", txtCpf.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Já Existe Um Hóspede Com Este CPF", "Dados Iguais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpf.Text = "";
                txtCpf.Focus();
                return;
            }


            //LINHA DE EXCUÇÃO LOGO ABAIXO

            cmd.ExecuteNonQuery();
            con.FecharCon();

            MessageBox.Show("Hóspede Salvo Com Sucesso", "Dados Salvos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            cbNacionalidade.Text = "";
            cbOrgaoEmissor.Text = "";
            cbSexo.Text = "";
            cbUf.Text = "";
            cbUfIdentidade.Text = "";
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }

            if (txtCpf.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpf.Text = "";
                txtCpf.Focus();
                return;
            }


            //CODIGO PARA O BOTÃO EDITAR

            con.AbrirCon();
            sql = "UPDATE hospedes SET nome = @nome, data_nascimento = @data_nascimento, idade = @idade, profissao = @profissao, nacionalidade = @nacionalidade, sexo = @sexo, cpf = @cpf, identidade = @identidade, orgao_expeditor = @orgao_expeditor, uf_identidade = @uf_identidade, endereco = @endereco, cep = @cep, cidade = @cidade, uf = @uf, email = @email, celular = @celular, telefone = @telefone where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@data_nascimento", txtDataNascimento.Text);
            cmd.Parameters.AddWithValue("@idade", txtIdade.Text);
            cmd.Parameters.AddWithValue("@profissao", txtProfissao.Text);
            cmd.Parameters.AddWithValue("@nacionalidade", cbNacionalidade.Text);
            cmd.Parameters.AddWithValue("@sexo", cbSexo.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
            cmd.Parameters.AddWithValue("@identidade", txtIdentidade.Text);
            cmd.Parameters.AddWithValue("@orgao_expeditor", cbOrgaoEmissor.Text);
            cmd.Parameters.AddWithValue("@uf_identidade", cbUfIdentidade.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@cep", txtCep.Text);
            cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
            cmd.Parameters.AddWithValue("@uf", cbUf.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@id", id);

            //VERIFICAÇÃO SE EXISTE HOSPEDE CADASTRADO!
            MySqlCommand cmdVerificar;
            cmdVerificar = new MySqlCommand("SELECT * FROM hospedes where cpf = @cpf", con.con);
            cmdVerificar.Parameters.AddWithValue("@cpf", txtCpf.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Já Existe Um Hóspede Com Este CPF", "Dados Iguais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpf.Text = "";
                txtCpf.Focus();
                return;
            }


            //LINHA DE EXCUÇÃO LOGO ABAIXO

            cmd.ExecuteNonQuery();
            con.FecharCon();

            MessageBox.Show("Dados Editados Com Sucesso", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //CODIGO BOTAO EXCLUIR
                con.AbrirCon();
                sql = "DELETE FROM hospedes where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharCon();

                MessageBox.Show("Hóspede Excluido Com Sucesso", "Dados Excluidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnNovo.Enabled = true;
                limparCampos();
                desabilitarCampos();
                Listar();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            HabilitarCampos();

            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtDataNascimento.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtIdade.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtProfissao.Text = grid.CurrentRow.Cells[4].Value.ToString();
            cbNacionalidade.Text = grid.CurrentRow.Cells[5].Value.ToString();
            cbSexo.Text = grid.CurrentRow.Cells[6].Value.ToString();
            txtCpf.Text = grid.CurrentRow.Cells[7].Value.ToString();
            txtIdentidade.Text = grid.CurrentRow.Cells[8].Value.ToString();
            cbOrgaoEmissor.Text = grid.CurrentRow.Cells[9].Value.ToString();
            cbUfIdentidade.Text = grid.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = grid.CurrentRow.Cells[11].Value.ToString();
            txtCep.Text = grid.CurrentRow.Cells[12].Value.ToString();
            txtCidade.Text = grid.CurrentRow.Cells[13].Value.ToString();
            cbUf.Text = grid.CurrentRow.Cells[14].Value.ToString();
            txtEmail.Text = grid.CurrentRow.Cells[15].Value.ToString();
            txtCelular.Text = grid.CurrentRow.Cells[16].Value.ToString();
            txtTelefone.Text = grid.CurrentRow.Cells[17].Value.ToString();
        }



        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void Grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.chamadaHospedes == "Hospede")
            {
                Program.nomeHospede = grid.CurrentRow.Cells[1].Value.ToString();
                //Program. = grid.CurrentRow.Cells[0].Value.ToString();
                Close();
            }

            if (Program.chamadaHospedes == "hospedes")
            {
                Program.nomeHospede = grid.CurrentRow.Cells[1].Value.ToString();

                Close();
            }
        }

        private void txtBuscarNome_TextChanged_1(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (Program.chamadaHospedes == "Hospede")
                {
                    Program.nomeHospede = grid.CurrentRow.Cells[1].Value.ToString();
                    //Program. = grid.CurrentRow.Cells[0].Value.ToString();
                    Close();
                }

                if (Program.chamadaHospedes == "hospedes")
                {
                    Program.nomeHospede = grid.CurrentRow.Cells[1].Value.ToString();

                    Close();
                }
            }
        }
    }
}
