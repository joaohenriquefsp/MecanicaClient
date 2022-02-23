using CadClientes.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadClientes.controller
{
    public interface InterfaceBD
    {
        public MySqlConnection getConexao();
        public bool conectar();
        public bool desconectar();
    }
}
