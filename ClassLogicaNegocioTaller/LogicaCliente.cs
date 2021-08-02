using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//Librerias de clase creadas
using ClassAccesoDatos;
using ClassCapaEntidades;

namespace ClassLogicaNegocioTaller
{
    public class LogicaCliente
    {
        //Cadena de Conexión Mauro
        //private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-10SGSAI\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");

        //Cadena de Conexión David
        private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-822RV6A8;Database=MiTaller2021;Integrated Security=true;");

        //Cadena de Conexión Juan
        //private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-FFJP8C6;Database=MiTaller2021;Integrated Security=true;");

        public Boolean InsertClient(Cliente nuevo, ref string result)
        {
            SqlParameter[] paramss = new SqlParameter[7];
            paramss[0] = new SqlParameter
            {
                ParameterName = "name",
                SqlDbType = SqlDbType.NVarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.Nombre
            };
            paramss[1] = new SqlParameter
            {
                ParameterName = "apellidop",
                Size = 90,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.ApellidoP
            };
            paramss[2] = new SqlParameter
            {
                ParameterName = "apellidom",
                Size = 90,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.ApellidoM
            };
            paramss[3] = new SqlParameter
            {
                ParameterName = "celular",
                SqlDbType = SqlDbType.NVarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.Celular
            };
            paramss[4] = new SqlParameter
            {
                ParameterName = "telCorporativo",
                SqlDbType = SqlDbType.NVarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.TelOficina
            };
            paramss[5] = new SqlParameter
            {
                ParameterName = "correo",
                SqlDbType = SqlDbType.NVarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = nuevo.Correo
            };
            paramss[6] = new SqlParameter
            {
                ParameterName = "correoCorporativo",
                SqlDbType = SqlDbType.NVarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = nuevo.CorreoCorporativo
            };


            string sentencia = "insert into Cliente values(@name, @apellidop, @apellidom, @celular, @telCorporativo, @correo, @correoCorporativo)";
            Boolean salida = false;

            salida = db.ModificiaParametros(sentencia, db.AbrirConexion(ref result), ref result, paramss);

            return salida;

        }
        public Boolean UpdateClient(Cliente nuevo, string id, ref string result)
        {
            SqlParameter[] paramss = new SqlParameter[7];
            paramss[0] = new SqlParameter
            {
                ParameterName = "name",
                SqlDbType = SqlDbType.NVarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.Nombre
            };
            paramss[1] = new SqlParameter
            {
                ParameterName = "apellidop",
                Size = 90,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.ApellidoP
            };
            paramss[2] = new SqlParameter
            {
                ParameterName = "apellidom",
                Size = 90,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.ApellidoM
            };
            paramss[3] = new SqlParameter
            {
                ParameterName = "celular",
                SqlDbType = SqlDbType.NVarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.Celular
            };
            paramss[4] = new SqlParameter
            {
                ParameterName = "telCorporativo",
                SqlDbType = SqlDbType.NVarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.TelOficina
            };
            paramss[5] = new SqlParameter
            {
                ParameterName = "correo",
                SqlDbType = SqlDbType.NVarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = nuevo.Correo
            };
            paramss[6] = new SqlParameter
            {
                ParameterName = "correoCorporativo",
                SqlDbType = SqlDbType.NVarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = nuevo.CorreoCorporativo
            };


            //string sentencia = "insert into Cliente values(@name, @apellidop, @apellidom, @celular, @telCorporativo, @correo, @correoCorporativo)";
            string sentencia1 = "UPDATE Cliente SET Nombre = @name, App = @apellidop, ApM = @apellidom, Celular = @celular, TelOficina = @telCorporativo, correoPer = @correo, correoCorp = @correoCorporativo WHERE id_cliente = " + id + ";";
            Boolean salida = false;

            salida = db.ModificiaParametros(sentencia1, db.AbrirConexion(ref result), ref result, paramss);

            return salida;
        }

        public Boolean deleteClient(string id, ref string result)
        {
            string sentencia = "delete from Cliente where id_cliente = " + id + ";";
            Boolean salida = false;
            salida = db.ModificaBDInsegura(sentencia, db.AbrirConexion(ref result), ref result);
            return salida;
        }

        public Cliente getCLientId(string id, ref string msg)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from Cliente where id_cliente = " + id;
            cnTemp = db.AbrirConexion(ref msg);
            SqlDataReader atrapaDatos = null;
            Cliente salida = new Cliente();

            atrapaDatos = db.ConsultarReader(query1, cnTemp, ref msg);

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    salida.Nombre = (string)atrapaDatos[1];
                    salida.ApellidoP = (string)atrapaDatos[2];
                    salida.ApellidoM = (string)atrapaDatos[3];
                    salida.Celular = (string)atrapaDatos[4];
                    salida.TelOficina = (string)atrapaDatos[5];
                    salida.Correo = (string)atrapaDatos[6];
                    salida.CorreoCorporativo = (string)atrapaDatos[7];
                }
            }else
            {
                salida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return salida;

        }

        public List<Cliente> getClients(ref string msgSalida)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from Cliente";

            cnTemp = db.AbrirConexion(ref msgSalida);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = db.ConsultarReader(query1, cnTemp, ref msgSalida);

            List<Cliente> listSalida = new List<Cliente>();

            if (atrapaDatos!=null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Cliente
                    {
                        id_cliente = (int)atrapaDatos[0],
                        Nombre = (string)atrapaDatos[1],
                        ApellidoP = (string)atrapaDatos[2],
                        ApellidoM = (string)atrapaDatos[3],
                        Celular = (string)atrapaDatos[4],
                        TelOficina = (string)atrapaDatos[5],
                        Correo = (string)atrapaDatos[6],
                        CorreoCorporativo = (string)atrapaDatos[7]
                    });
                }
                
            }else
            {
                listSalida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return listSalida;
        }


        public DataTable getClientsDataSet(ref string msgSalida)
        {
            string query1 = "Select * from Cliente";
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = db.ConsultaDS(query1, db.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor!=null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }
    }
}
