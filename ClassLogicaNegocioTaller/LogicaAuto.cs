using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


using ClassAccesoDatos;
using ClassCapaEntidades;

namespace ClassLogicaNegocioTaller
{
    public class LogicaAuto
    {
        //Cadena de Conexión Mauro
        private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-10SGSAI\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");
        //private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-IK2MC2K0\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");

        //Cadena de Conexión David
        //private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-822RV6A8;Database=MiTaller2021;Integrated Security=true;");

        //Cadena de Conexión Juan
        //private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-FFJP8C6;Database=MiTaller2021;Integrated Security=true;");


        public List<Marca> getMarcas(ref string msgSalida)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from Marcas";

            cnTemp = db.AbrirConexion(ref msgSalida);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = db.ConsultarReader(query1, cnTemp, ref msgSalida);

            List<Marca> listSalida = new List<Marca>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Marca
                    {
                        idMarca = (int)atrapaDatos[0],
                        marca = (string)atrapaDatos[1]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return listSalida;
        }
        public Boolean InsertAuto(Auto nuevo, ref string result)
        {
            SqlParameter[] paramss = new SqlParameter[6];
            paramss[0] = new SqlParameter
            {
                ParameterName = "marc",
                SqlDbType = SqlDbType.NVarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.F_Marca
            };
            paramss[1] = new SqlParameter
            {
                ParameterName = "mode",
                SqlDbType = SqlDbType.NVarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.Modelo
            };
            paramss[2] = new SqlParameter
            {
                ParameterName = "año",
                Size = 90,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.año
            };
            paramss[3] = new SqlParameter
            {
                ParameterName = "colo",
                Size = 90,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.color
            };
            paramss[4] = new SqlParameter
            {
                ParameterName = "placa",
                SqlDbType = SqlDbType.NVarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.placas
            };
            paramss[5] = new SqlParameter
            {
                ParameterName = "dueñ",
                SqlDbType = SqlDbType.NVarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.dueño
            };


            string sentencia = "insert into Auto values(@marc, @mode, @año, @colo, @placa, @dueñ)";
            Boolean salida = false;

            salida = db.ModificiaParametros(sentencia, db.AbrirConexion(ref result), ref result, paramss);

            return salida;

        }

        public Boolean UpdateAuto(Auto nuevo, string id, ref string result)
        {
            SqlParameter[] paramss = new SqlParameter[4];
            paramss[0] = new SqlParameter
            {
                ParameterName = "mode",
                SqlDbType = SqlDbType.NVarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.Modelo
            };
            paramss[1] = new SqlParameter
            {
                ParameterName = "año",
                Size = 90,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.año
            };
            paramss[2] = new SqlParameter
            {
                ParameterName = "colo",
                Size = 90,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.color
            };
            paramss[3] = new SqlParameter
            {
                ParameterName = "placa",
                SqlDbType = SqlDbType.NVarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.placas
            };


            //string sentencia = "insert into Cliente values(@name, @apellidop, @apellidom, @celular, @telCorporativo, @correo, @correoCorporativo)";
            string sentencia1 = "UPDATE Auto SET Modelo = @mode, año = @año, color = @colo, placas = @placa WHERE Id_Auto = " + id + ";";
            Boolean salida = false;

            salida = db.ModificiaParametros(sentencia1, db.AbrirConexion(ref result), ref result, paramss);

            return salida;
        }


        public Boolean deleteAuto(string id, ref string result)
        {
            string sentencia = "delete from Auto where Id_Auto = " + id + ";";
            Boolean salida = false;
            salida = db.ModificaBDInsegura(sentencia, db.AbrirConexion(ref result), ref result);
            return salida;
        }

        public Auto getAutoId(string id, ref string msg)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from  Auto where Id_Auto = " + id;
            cnTemp = db.AbrirConexion(ref msg);
            SqlDataReader atrapaDatos = null;
            Auto salida = new Auto();

            atrapaDatos = db.ConsultarReader(query1, cnTemp, ref msg);

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    salida.F_Marca = (int)atrapaDatos[1];
                    salida.Modelo = (string)atrapaDatos[2];
                    salida.año = (string)atrapaDatos[3];
                    salida.color = (string)atrapaDatos[4];
                    salida.placas = (string)atrapaDatos[5];
                    salida.dueño = (int)atrapaDatos[6];
                }
            }
            else
            {
                salida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return salida;

        }

        public List<Auto> getAuto(ref string msgSalida)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from Auto";

            cnTemp = db.AbrirConexion(ref msgSalida);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = db.ConsultarReader(query1, cnTemp, ref msgSalida);

            List<Auto> listSalida = new List<Auto>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Auto
                    {
                        Id_Auto = (int)atrapaDatos[0],
                        F_Marca = (int)atrapaDatos[1],
                        Modelo = (string)atrapaDatos[2],
                        año = (string)atrapaDatos[3],
                        color = (string)atrapaDatos[4],
                        placas = (string)atrapaDatos[5],
                        dueño = (int)atrapaDatos[6]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return listSalida;
        }

        public int devuelveUltimoId(ref string msg)
        {
            int salida = 0;

            SqlConnection cnTemp = null;
            string query1 = "SELECT MAX(Id_Auto) AS id FROM Auto";

            cnTemp = db.AbrirConexion(ref msg);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = db.ConsultarReader(query1, cnTemp, ref msg);

            if (atrapaDatos!=null)
            {
                while (atrapaDatos.Read())
                {
                    salida = (int)atrapaDatos[0];
                }
            }
            else
            {
                salida = 0;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return salida; 
        }


        public DataTable getAutoDataSet(ref string msgSalida)
        {
            string query1 = "select Id_Auto, Marca, Modelo, año, color, placas,  Cliente.Nombre as Dueño from Auto " +
                "INNER JOIN Marcas ON Auto.F_Marca = Marcas.id_Marca " +
                "INNER JOIN Cliente ON Auto.dueño = Cliente.id_cliente";
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = db.ConsultaDS(query1, db.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }

        public DataTable getRevisionesAutoSet(string id, ref string msgSalida)
        {
            string query1 = "select id_Revision, Entrada, Falla, diagnostico, Modelo, placas, Mecanico.Nombre as Mecanico from Revision " +
                "INNER JOIN Auto ON Revision.Auto = Auto.Id_Auto " +
                "INNER JOIN Mecanico ON Revision.Mecanico = Mecanico.id_Tecnico WHERE Auto = "+id+" AND Revision.Autorizacion=0";
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = db.ConsultaDS(query1, db.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }

        //GET REPARACIONES AUTO //
        public DataTable getReparacionesAutoSet(string id, ref string msgSalida)
        {
            //INNER JOIN PARA VER MAS DETALLES DEL AUTO REPARADO Y SI TIENE REPARACIÓN HECHA, NOS MUESTRA LA INFORMACIÓN
            string query1 = " SELECT id_Reparacion, Detalles, Garantia, Salida, Modelo, placas, Mecanico.Nombre as Mecanico, Cliente.Nombre as Dueño from Reparacion " +
                            " INNER JOIN Revision as rev on rev.id_Revision = Reparacion.Fk_Revision " +
                            " INNER JOIN Auto as aut on aut.Id_Auto = rev.Auto " +
                            " INNER JOIN Mecanico on Mecanico.id_Tecnico = rev.Mecanico " +
                            " INNER JOIN Cliente on Cliente.id_cliente = aut.dueño " +
                            " where aut.Id_Auto = " + id + " and rev.Autorizacion = 1;";

            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = db.ConsultaDS(query1, db.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }


        //GET GARANTY
        //OBTENEMOS LOS MESES DE GARANTÍA QUE TIENE UNA REPARACIÓN
        public Reparacion getReparacionT(int idRep, ref string message)
        {
            Reparacion response = null;
            

            SqlConnection cnTemp = null;
            string query1 = "SELECT * FROM Reparacion Where id_Reparacion = " + idRep;

            cnTemp = db.AbrirConexion(ref message);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = db.ConsultarReader(query1, cnTemp, ref message);

            if (atrapaDatos != null)
            {
               
                while (atrapaDatos.Read())
                {
                    response = new Reparacion
                    {

                        Id_Reparacion = (int)atrapaDatos[0],
                        Detalles = (string)atrapaDatos[1],
                        Garantia = (string)atrapaDatos[2],
                        salida = (DateTime)atrapaDatos[3],
                        FK_Revision = (int)atrapaDatos[4]


                    };
                }
                
            }
            else
            {
                response = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return response;



        }

        

    }
}
