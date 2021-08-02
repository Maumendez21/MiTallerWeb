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
        private AccesoSQL db = new AccesoSQL(@"Server=DESKTOP-10SGSAI\SQLEXPRESS;Database=MiTaller2021;Integrated Security=true;");

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
            string query1 = "select id_Revision, Entrada, Falla, diagnostico, Modelo, placas, Nombre from Revision " +
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
    }
}
