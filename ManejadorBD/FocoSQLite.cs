using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;

namespace ManejadorBD
{
    class FocoSQLite
    {
        private String miCadenaConexion;
        public FocoSQLite(String cadenaConexion)
        {
            //miCadenaConexion = @"Data Source=" + dirDB + ";Version=3;";
            miCadenaConexion = cadenaConexion;
        }
        public void EjecutarComando(String comando)
        {
            using (SQLiteConnection miConexion = new SQLiteConnection(miCadenaConexion))
            {
                miConexion.Open();
                if (miConexion.State == System.Data.ConnectionState.Open)
                {
                    SQLiteCommand miComando = new SQLiteCommand(comando, miConexion);
                    miComando.ExecuteNonQuery();
                    miConexion.Close();
                }
            }
        }
        public List<String> EjecutarLectura(String comando)
        {
            using (SQLiteConnection miConexion = new SQLiteConnection(miCadenaConexion))
            {
                miConexion.Open();
                List<String> miLista = new List<String>();
                if (miConexion.State == System.Data.ConnectionState.Open)
                {
                    SQLiteCommand miComando = new SQLiteCommand(comando, miConexion);
                    SQLiteDataReader miLector = miComando.ExecuteReader();
                    while(miLector.Read())
                    {
                        miLista.Add(miLector.ToString());
                    }
                    miConexion.Close();
                }
                return miLista;
            }
        }
    }
}
