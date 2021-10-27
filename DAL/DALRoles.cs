using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MODELS;

namespace DAL
{
    public class DALRoles : IRead<Rol>,ICreate<Rol>
    {
        public int Create(Rol obj)
        {
            using var DB = new SqlConnection(ConfigKeys.ConnectionString);
            using var Command = new SqlCommand();
            Command.Parameters.AddWithValue("@nombre", obj.Nombre);
            Command.CommandText = "insert into roles (nombre) values (@nombre)";
            return Command.ExecuteNonQuery();

        }

        public List<Rol> Read()
        {
            List<Rol> Roles = new List<Rol>();
            using var DB = new SqlConnection(ConfigKeys.ConnectionString);
                using var Command = new SqlCommand("select * from roles", DB);
                DB.Open();
                using var DataReader = Command.ExecuteReader();
            while (DataReader.Read()) { Roles.Add(new Rol() { Nombre = DataReader["nombre"].ToString() }); }
            return Roles;

        }

    }
}
