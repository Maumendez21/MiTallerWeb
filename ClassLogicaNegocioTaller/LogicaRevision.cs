using ClassAccesoDatos;
using ClassCapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLogicaNegocioTaller
{
    public class LogicaRevision
    {
        //Cadena de Conexión Mauro
        //private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-10SGSAI\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");
        //private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-IK2MC2K0\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");


        //Cadena de Conexión David
        //private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-822RV6A8;Database=MiTaller2021;Integrated Security=true;");

        //Cadena de Conexión Juan
        private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-FFJP8C6;Database=MiTaller2021;Integrated Security=true;");

        public Boolean newRevision(Revision nuevo, ref string result)
        {
            SqlParameter[] paramss = new SqlParameter[6];
            paramss[0] = new SqlParameter
            {
                ParameterName = "entrada",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = nuevo.entrada
            };
            paramss[1] = new SqlParameter
            {
                ParameterName = "falla",
                Size = 300,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.falla
            };
            paramss[2] = new SqlParameter
            {
                ParameterName = "diagnostico",
                Size = 350,
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = nuevo.diagnostico
            };
            paramss[3] = new SqlParameter
            {
                ParameterName = "autorizacion",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = nuevo.autorizacion
            };
            paramss[4] = new SqlParameter
            {
                ParameterName = "auto",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.auto
            };
            paramss[5] = new SqlParameter
            {
                ParameterName = "mecanico",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.mecanico
            };


            string sentencia = "insert into Revision values(@entrada, @falla, @diagnostico, @autorizacion, @auto, @mecanico)";
            Boolean salida = false;

            salida = db.ModificiaParametros(sentencia, db.AbrirConexion(ref result), ref result, paramss);

            return salida;

        }

        public DataTable getRevisionDataSet(ref string msgSalida)
        {
            string query1 = "select id_Revision, Entrada, Falla, diagnostico, Modelo, placas, Mecanico.Nombre as Mecanico from Revision " +
                "INNER JOIN Auto ON Revision.Auto = Auto.Id_Auto " +
                "INNER JOIN Mecanico ON Revision.Mecanico = Mecanico.id_Tecnico WHERE Revision.Autorizacion = 0";
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = db.ConsultaDS(query1, db.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }

        public DataTable getAllDetailRev(ref string mssg, string id_)
        {
            //Variables locales
            DataTable output = null;
            DataSet content = null;

            //Consulta para obtener un detalle más amplio de la revision del auto seleccionado en el Index
            string QuerySQL = "select id_Revision, Entrada, Falla, diagnostico, Marca, Modelo, placas, Mecanico.Nombre as Mecanico_Asignado, Cliente.Nombre as Dueño from Revision" +
                " INNER JOIN Auto ON Revision.Auto = Auto.Id_Auto " +
                " INNER JOIN Mecanico ON Revision.Mecanico = Mecanico.id_Tecnico " +
                " INNER JOIN Cliente on Cliente.id_cliente = Auto.dueño " +
                " INNER JOIN Marcas on Marcas.id_Marca = Auto.F_Marca " +
                " Where id_Revision = " + id_;
            //Llenamos el DataSet con los datos solicitados
            content = db.ConsultaDS(QuerySQL, db.AbrirConexion(ref mssg),ref mssg);
            //Validamos para evitar posibles errores
            if (content != null)
            {
                output = content.Tables[0];
            }

            return output;
        }


        //Sirve para poder actualizar el estado de la autorización en caso de que el auto y su reparación ya esten 
        //dados(as) de alta
        public Boolean UpdateAuth(Boolean bit, ref string _mssg, string id_)
        {
            //Variables locales
            string sentence = "";
            Boolean flag = false;
            
            SqlConnection conn = null;


            //Validamos que no venga vacío el arreglo
            if (bit && id_ != null)
            {
                //Inicialización de los parametros 
                SqlParameter[] paramss = new SqlParameter[2];
               
               
                paramss[0] = new SqlParameter
                {
                    ParameterName = "autorizacion",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Input,
                    Value = bit
                };

                paramss[1] = new SqlParameter
                {
                    ParameterName = "id_",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = id_
                };



                sentence = "Update Revision Set Autorizacion = @autorizacion Where id_Revision = @id_";
                conn = db.AbrirConexion(ref _mssg);
                flag = db.ModificiaParametros(sentence, conn, ref _mssg, paramss);

            }
            else
            {
                flag = false;
            }

            return flag;

        }


       







    }
}
