using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ClassAccesoDatos;
using ClassCapaEntidades;

namespace ClassLogicaNegocioTaller
{
    public class LogicaReparacion
    {
        //Cadena de Conexión Mauro
        //private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-10SGSAI\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");
        //private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-IK2MC2K0\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");


        //Cadena de Conexión David
        private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-822RV6A8;Database=MiTaller2021;Integrated Security=true;");

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

    }
}
