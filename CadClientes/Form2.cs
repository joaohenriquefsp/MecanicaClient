using CadClientes.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadClientes
{
    public partial class Form2 : Form
    {
        //atributo
        Form1 form1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            limparTela();
        }

        private void limparTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtVeiculo.Clear();
            txtMarca.Clear();
        }
        private bool verificarTela()
        {
            bool resposta = true;
            if (txtCodigo.Text.Trim().Length == 0)
                txtCodigo.Text = "0";
            if(txtNome.Text.Trim().Length == 0)
            {
                MessageBox.Show("Campo nome em branco. Verifique!",
                                "Nome aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                resposta = false;
            }

            if(txtVeiculo.Text.Trim().Length == 0 && resposta)
            {
                MessageBox.Show("Campo veiculo em branco. Verifique!",
                                "Nome aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                resposta = false;
            }

            if(txtMarca.Text.Trim().Length == 0 && resposta)
            {
                MessageBox.Show("Campo Marca em branco. Verifique!",
                                "Nome aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                resposta = false;                
            }
            return resposta;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparTela();
            txtCodigo.Text = "0";
            txtNome.Focus();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (verificarTela())
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = int.Parse(txtCodigo.Text);
                    cliente.Nome = txtNome.Text.Trim().ToUpper();
                    cliente.Veiculo = txtVeiculo.Text.Trim().ToUpper();
                    cliente.Marca = txtMarca.Text.Trim().ToUpper();
                    if (cliente.Gravar(form1.conexaoBD))
                    {
                        MessageBox.Show("Dados gravados com sucesso!",
                                    "Nome aplicação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        limparTela();
                    }
                    else
                    {
                        MessageBox.Show("Dados não gravados!",
                                    "Nome aplicação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Erro ao gravar dados: " +
                                    ex.Message,
                                    "Nome da aplicação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }
        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
                txtCodigo.Text = "0";
            try
            {
                Cliente cliente = new Cliente();
                cliente.buscar(form1.conexaoBD, int.Parse(txtCodigo.Text), 0);
                if(cliente.Codigo != 0)
                {
                    txtCodigo.Text = cliente.Codigo.ToString();
                    txtNome.Text = cliente.Nome;
                    txtVeiculo.Text = cliente.Veiculo;
                    txtMarca.Text = cliente.Marca;
                }
                else
                {
                    limparTela();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados (prox): " +
                                ex.Message,
                                "Nome da aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
                txtCodigo.Text = "0";
            try
            {
                Cliente cliente = new Cliente();
                cliente.buscar(form1.conexaoBD, int.Parse(txtCodigo.Text), 1);
                if (cliente.Codigo != 0)
                {
                    txtCodigo.Text = cliente.Codigo.ToString();
                    txtNome.Text = cliente.Nome;
                    txtVeiculo.Text = cliente.Veiculo;
                    txtMarca.Text = cliente.Marca;
                }
                else
                {
                    limparTela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados (ant): " +
                                ex.Message,
                                "Nome da aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text.Length != 0)
            {
                if(int.Parse(txtCodigo.Text) > 0)
                {
                    if(MessageBox.Show("Deseja realmente excluir " +
                        "o cliente " + txtNome.Text + "?",
                        "Nome da aplicação",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cliente cliente = new Cliente();
                        cliente.Codigo = int.Parse(txtCodigo.Text);
                        if (cliente.deletar(form1.conexaoBD))
                        {
                            MessageBox.Show("Dados deletados com sucesso!",
                                "Nome da aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            limparTela();
                        }
                        else
                        {
                            MessageBox.Show("Os dados não foram deletados!",
                                "Nome da aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
