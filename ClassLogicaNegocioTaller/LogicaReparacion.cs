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
    public class LogicaReparacion
    {
        //Cadena de Conexión Mauro
        private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-10SGSAI\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");
        //private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-IK2MC2K0\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");


        //Cadena de Conexión David
        //private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-822RV6A8;Database=MiTaller2021;Integrated Security=true;");

        //Cadena de Conexión Juan
        //private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-FFJP8C6;Database=MiTaller2021;Integrated Security=true;");



        public Boolean InsertFixCar(Reparacion fix, ref string mssg)
        {
            //Variable local de salida y variable local para sentencia SQL y conexión
            Boolean flag = false;
            string sentence = "";
            SqlConnection connection = null;

            //Validamos si viene vacío o no el objeto.
            if (fix != null)
            {
                //Inicialización de los parametros SQL
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter
                {
                    ParameterName = "Detalles",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 120,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = fix.Detalles
                };

                parameters[1] = new SqlParameter
                {
                    ParameterName = "Garantia",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = fix.Garantia
                };

                parameters[2] = new SqlParameter
                {
                    ParameterName = "salida",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = fix.salida
                };

                parameters[3] = new SqlParameter
                {
                    ParameterName = "FK_Revision",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = fix.FK_Revision
                };

               


                //Se abre conexión y se realiza la inserción en la tabla Reparacion
                connection = db.AbrirConexion(ref mssg);
                sentence = "Insert Into Reparacion Values(@Detalles, @Garantia, @salida, @FK_Revision);";
                flag = db.ModificiaParametros(sentence, connection, ref mssg, parameters);


            }
            else
            {
                //En caso de que el objeto venga vacío
                flag = false;
            }

            return flag;

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
        public DataTable getReparacion(ref string msgSalida)
        {
            string query1 = "SELECT id_Reparacion, Detalles, Garantia, Salida, Modelo, placas, Mecanico.Nombre as Mecanico, Cliente.Nombre as Dueño from Reparacion " +
                            " INNER JOIN Revision as rev on rev.id_Revision = Reparacion.Fk_Revision " +
                            " INNER JOIN Auto as aut on aut.Id_Auto = rev.Auto " +
                            " INNER JOIN Mecanico on Mecanico.id_Tecnico = rev.Mecanico " +
                            " INNER JOIN Cliente on Cliente.id_cliente = aut.dueño " +
                            " where rev.Autorizacion = 1"; 
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = db.ConsultaDS(query1, db.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }

    }
}
