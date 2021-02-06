﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel
{
    class Conexao
    {
        //CONEXAO COM O BANCO DE DADOS REMOTO DIGITAL OCEAN
        //public string conec = "SERVER=localhost:888; DATABASE=hotel; UID=root; PWD=; PORT=;";

        //CONEXAO COM O BANCO DE DADOS LOCAL
        public string conec = "SERVER=localhost; DATABASE=hotel; UID=root; PWD=; PORT=;";


        public MySqlConnection con = null;

        public void AbrirCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro na conexão com o Banco! " + ex.Message);
            }

            
        }


        public void FecharCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
                con.Dispose();
                con.ClearAllPoolsAsync();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro na conexão com o Banco! " + ex.Message);
            }
        }


        
        

    }


}
