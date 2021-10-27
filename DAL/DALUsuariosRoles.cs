using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MODELS;

namespace DAL
{
    public class DALUsuariosRoles : ICRUD<UsuarioRol>
    {
        #region CRUD 👻
        public int Create(UsuarioRol obj)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuariosroles_insert", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("idusuario", obj.IDUsuario);
                    Command.Parameters.AddWithValue("rol", obj.Rol);
                    DB.Open();
                    //Devuelve el ID, que es el dato de la primera columna de la consulta que devuelve el identity
                    return int.Parse(Command.ExecuteScalar().ToString());
                }
            }
        }

        public void Delete(int ID)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuariosroles_delete", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("id", ID);
                    DB.Open();
                    Command.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioRol> Read()
        {
            throw new NotImplementedException();
        }

        public UsuarioRol ReadOne(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(int ID, UsuarioRol obj)
        {
            throw new NotImplementedException();
        }
        #endregion 
        public List<Rol> ListRolesByUsuario(Usuario obj)
        {
            List<Rol> Roles = new List<Rol>();
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuariosroles_listrolesbyusuario", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@idusuario", obj.ID);
                    DB.Open();
                    using (var DataReader = Command.ExecuteReader())
                    {
                        while (DataReader.Read()) Roles.Add(new Rol()
                        {
                            Nombre = DataReader["rol"].ToString(),

                        });
                        return Roles;
                    }

                }
            }
        }
        public void DeleteByUsuarioAndRol(int IDUsuario, string Rol)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuariosroles_deletebyuserandrol", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("idusuario", IDUsuario);
                    Command.Parameters.AddWithValue("rol",Rol);
                    DB.Open();
                    Command.ExecuteNonQuery();
                }
            }
        }
    }
}
