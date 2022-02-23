using CadClientes.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadClientes.controller
{
    public class ConexaoBDMariaBD : InterfaceBD
    {
        //Atributos
        MySqlConnection conexaoMariaDB = new MySqlConnection();
        public DadosConexao dadosConexao { get; set; }

        //Métodos:
        public ConexaoBDMariaBD(DadosConexao dadosConexao)
        {
            this.dadosConexao = dadosConexao;
        }
        public bool conectar()
        {
            if(dadosConexao != null)
            {
                try
                {
                    string sql = "Data Source=" + dadosConexao.host + ";" +
                                 "Database=" + dadosConexao.dataBase + ";" +
                                 "User Id=" + dadosConexao.usuario + ";" +
                                 "Password=" + dadosConexao.senha + ";" +
                                 "Connection Timeout=900;" +
                                 "Port=" + dadosConexao.porta.ToString() + ";" +
                                 "SSL Mode=none";
                    conexaoMariaDB = new MySqlConnection(sql);
                    conexaoMariaDB.Open();
                    return true;
                }catch(Exception ex)
                {
                    MessageBox.Show("Erro ao conectar no banco de dados:\n" +
                                    ex.ToString(),
                                    "Título do app - MariaDB",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public MySqlConnection getConexao()
        {
            return conexaoMariaDB;
        }

        public bool desconectar()
        {
            try
            {
                if (conexaoMariaDB.State == System.Data.ConnectionState.Open)
                    conexaoMariaDB.Close();
                return true;
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao desconectar do banco de dados:\n" +
                                ex.ToString(),
                                "Título do app - MariaDB",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
