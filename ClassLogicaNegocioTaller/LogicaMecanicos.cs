using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassAccesoDatos;
using ClassCapaEntidades;

namespace ClassLogicaNegocioTaller
{
    public class LogicaMecanicos
    {
        //Cadena de Conexión Mauro
        //private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-10SGSAI\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");

        //Cadena de Conexión David
        private AccesoSQL db = new AccesoSQL(@"Server=LAPTOP-822RV6A8;Database=MiTaller2021;Integrated Security=true;");

        //Cadena de Conexión Juan
        //private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-FFJP8C6;Database=MiTaller2021;Integrated Security=true;");



        //INSERT MECHANIC IN BD//

        public Boolean InsertMechanic(Mecanico mechanic, ref string mssg)
        {
            //Variable local de salida y variable local para sentencia SQL y conexión
            Boolean band = false;
            string sentence = "";
            SqlConnection connection = null;

            //Validamos si viene vacío o no el objeto.
            if (mechanic != null)
            {
                //Inicialización de los parametros SQL
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter 
                { 
                    ParameterName = "Nombre", 
                    SqlDbType = System.Data.SqlDbType.NVarChar, 
                    Size = 120,
                    Direction = System.Data.ParameterDirection.Input, 
                    Value = mechanic.Nombre 
                };

                parameters[1] = new SqlParameter
                {
                    ParameterName = "App",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = mechanic.App
                };

                parameters[2] = new SqlParameter
                {
                    ParameterName = "Apm",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = mechanic.Apm
                };

                parameters[3] = new SqlParameter
                {
                    ParameterName = "Celular",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = mechanic.Celular
                };

                parameters[4] = new SqlParameter
                {
                    ParameterName = "correo",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 120,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = mechanic.correo
                };


                //Se abre conexión y se realiza la inserción en la tabla Mecanico
                connection = db.AbrirConexion(ref mssg);
                sentence = "Insert Into Mecanico Values(@Nombre, @App, @Apm, @Celular, @correo);";
                band =  db.ModificiaParametros(sentence, connection, ref mssg, parameters);
               

            }
            else
            {
                //En caso de que el objeto venga vacío
                band = false;
            }

            return band;
        
        }



        //GET MECHANIC BY ID//

        public Mecanico getMechanicID(string _id, ref string mssg_)
        {
            //Variables locales
            string QuerySQL = "";
            SqlConnection _connec = null;
            Mecanico _mech = null;
            SqlDataReader readerData = null;

        

            //Primera validación si el dato(ID) viene null
            if (_id != null)
            {
                _connec = db.AbrirConexion(ref mssg_);
                QuerySQL = "Select * From Mecanico where id_Tecnico = " + _id;
                readerData = db.ConsultarReader(QuerySQL, _connec, ref mssg_);
               
                //Verificamos que tenga datos el DataReader
                if (readerData != null)
                {
                    _mech = new Mecanico();
                    //Reccoremos DataReader para llenar nuestro objeto
                    while (readerData.Read())
                    {
                        _mech.Nombre = (string)readerData[1];
                        _mech.App = (string)readerData[2];
                        _mech.Apm = (string)readerData[3];
                        _mech.Celular = (string)readerData[4];
                        _mech.correo = (string)readerData[5];


                    }
                }
                else
                {
                    //Error o excepción si el DataReader no tiene datos
                    _mech = null;
                }

            }
            else
            {
                //Error o excepción si el dato(id) o bien parametro viene null
                _mech = null;
            }

            //Cerramos y destruimos la conexión a la BD
            _connec.Close();
            _connec.Dispose();

            return _mech;

        }


        //GET ALL MECHANICS FROM BD//

        public List<Mecanico> getAllMechanics(ref string output)
        {
            //Variables locales
            SqlConnection _conn = null;
            SqlDataReader _data = null;
            string QuerySQL_ = "";
            
            //Abrimos conexión con la BD, realizamos la consulta y asignamos al
            //DataReader la información recibida en base a la consulta SQL
            _conn = db.AbrirConexion(ref output);
            QuerySQL_ = "Select * From Mecanico";
            _data = db.ConsultarReader(QuerySQL_, _conn, ref output);

            //Creamos un List para la tabla Mecanico y toda la data que nos despliegue
            List<Mecanico> AllMech = new List<Mecanico>();

            //Validación: si no viene null podemos continuar y llenar el List
            if (_data != null)
            {
                while (_data.Read())
                {
                    AllMech.Add(new Mecanico
                    {
                        id_Tecnico = (int)_data[0],
                        Nombre = (string)_data[1],
                        App = (string)_data[2],
                        Apm = (string)_data[3],
                        Celular = (string)_data[4],
                        correo = (string)_data[5]

                    });
                }
            }
            //Validamos si el DataReader viene null, mandamos una lista vacía
            else
            {
                AllMech = null;
            }

            //Cerramos y destruimos la conexión
            _conn.Close();
            _conn.Dispose();

            return AllMech;
        
        }


        //GET MECHANICS DATASET//

        public DataTable getAllDataSet(ref string message)
        {
            //Variables locales
            string QuerySQL = "Select * From Mecanico";
            DataTable output = null;
            DataSet content = null;
            SqlConnection connectionSQL = null;

            //Abrimos la conexión
            connectionSQL = db.AbrirConexion(ref message);
            //Hacemos la consulta y asignamos lo que devuelva al DataSet
            content = db.ConsultaDS(QuerySQL, connectionSQL, ref message);
            //Validamos
            if (content != null)
            {
                output = content.Tables[0];
            }

            return output;
        }


        //UPDATE MECHANIC BD//
        public Boolean updateMechanic(Mecanico _mechanic, ref string mssg, string id_)
        {
            //Variables locales
            string sentence = "";
            Boolean flag = false;
            SqlConnection conn = null;
          

            //Validamos que no venga vacío el arreglo
            if (_mechanic != null && id_ != null)
            {
                //Inicialización de los parametros 
                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter
                {
                    ParameterName = "Nombre_",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 120,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = _mechanic.Nombre
                };

                parameters[1] = new SqlParameter
                {
                    ParameterName = "App_",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = _mechanic.App
                };

                parameters[2] = new SqlParameter
                {
                    ParameterName = "Apm_",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 100,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = _mechanic.Apm
                };

                parameters[3] = new SqlParameter
                {
                    ParameterName = "Celular_",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 20,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = _mechanic.Celular
                };

                parameters[4] = new SqlParameter
                {
                    ParameterName = "correo_",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 120,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = _mechanic.correo
                };


                //Parametro opcional para el ID, se crea para que sea más segura la sentencia
                parameters[5] = new SqlParameter
                {
                    ParameterName = "id_",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = id_
                };


                sentence = "Update Mecanico Set Nombre=@Nombre_, App = @App_, Apm = @Apm_, Celular = @Celular_, correo = @correo_ Where id_Tecnico = @id_";
                conn = db.AbrirConexion(ref mssg);
                flag = db.ModificiaParametros(sentence, conn, ref mssg, parameters);

            }
            else
            {
                flag = false;
            }

            return flag;
        }


        //DELETE MECHANIC BY ID //
        public Boolean deleteMechanic(string id, ref string message_)
        {
            //Variables locales
            string Sentence = "";
            Boolean output = false;

            SqlParameter[] paramID = new SqlParameter[1];
            paramID[0] = new SqlParameter()
            {
                ParameterName = "_id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = id
            };

            //Validación, ID es obligatorio
            if (id != null)
            {
                Sentence = "Delete From Mecanico where id_Tecnico = @_id";
                output = db.ModificiaParametros(Sentence, db.AbrirConexion(ref message_), ref message_, paramID);
            }
            else
            {
                output = false;
            }

            return output;
        }



    
        



    }
}
