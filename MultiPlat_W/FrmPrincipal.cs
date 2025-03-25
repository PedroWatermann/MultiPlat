using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiPlat_W
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            dgvPessoas.DataSource = new Pessoa().Listar();

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            this.txtNome.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Preencha o campo Id!");
                return;
            }

            int id = Convert.ToInt32(txtId.Text);

            Pessoa p = new Pessoa();
            p.Localizar(id);

            txtNome.Text = p.nome;
            txtCidade.Text = p.cidade;
            txtCelular.Text = p.cidade;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtCidade.Text) || string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            Pessoa p = new Pessoa()
            {
                nome = txtNome.Text,
                cidade = txtCidade.Text,
                celular = txtCelular.Text
            };            

            if (p.RegistroRepetido(p.nome, p.celular))
            {
                MessageBox.Show("Este registro já existe em nossa base de dados!");
                return;
            }

            p.Inserir(p);

            MessageBox.Show("Registro inserido com sucesso!");
            
            dgvPessoas.DataSource = new Pessoa().Listar();

            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtCelular.Text = string.Empty;

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtCidade.Text) || string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            Pessoa p = new Pessoa()
            {
                id_pessoa = Convert.ToInt32(txtId.Text),
                nome = txtNome.Text,
                cidade = txtCidade.Text,
                celular = txtCelular.Text
            };
            
            p.Atualizar(p);

            MessageBox.Show("Registro atualizado com sucesso!");

            dgvPessoas.DataSource = new Pessoa().Listar();

            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtCelular.Text = string.Empty;

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Preencha o campo Id!");
                return;
            }

            if (!(MessageBox.Show("Deseja excluir este registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                return;
            }

            new Pessoa().Excluir(Convert.ToInt32(txtId.Text));

            MessageBox.Show("Registro excluído com sucesso!");

            dgvPessoas.DataSource = new Pessoa().Listar();

            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtCelular.Text = string.Empty;

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void dgvPessoas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;

                DataGridViewRow row = this.dgvPessoas.Rows[e.RowIndex];
                row.Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtCidade.Text = row.Cells[2].Value.ToString();
                txtCelular.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
