using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MODELS;

namespace DAL
{
    public class DALUsuarios : ICRUD<Usuario>, IDALUsuarios
    {
        #region CRUD
        public int Create(Usuario obj)
        {

            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                  using (var Command = new SqlCommand("usuarios_insert", DB) ) 
                  { 
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("nombre", obj.Nombre);
                    Command.Parameters.AddWithValue("dni", obj.DNI);
                    Command.Parameters.AddWithValue("domicilio", obj.Domicilio);
                    Command.Parameters.AddWithValue("telefono", obj.Telefono);
                    Command.Parameters.AddWithValue("mail", obj.Mail);
                    Command.Parameters.AddWithValue("fechanac", obj.FechadeNacimiento.Date);
                    //TODO para cambiar el password no debería hacerlo desde aquí...
                    Command.Parameters.AddWithValue("password", obj.Password);
                    Command.Parameters.AddWithValue("estudios", obj.Estudios);
                    Command.Parameters.AddWithValue("materiasadeudadas", obj.MateriasAdeudadas);
                    Command.Parameters.AddWithValue("url", obj.URL?? "images/usuarios/default.png");

                    DB.Open();
                    //Devuelve el ID, que es el dato de la primera columna de la consulta que devuelve el identity
                    return int.Parse(Command.ExecuteScalar().ToString());

                }
            }
            
;
        }
        public List<Usuario> Read()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuarios_list", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    DB.Open();
                    using (var DataReader = Command.ExecuteReader())
                    {
                        while (DataReader.Read()) usuarios.Add(new Usuario()
                        {
                            Nombre = DataReader["nombre"].ToString(),
                            ID = int.Parse(DataReader["id"].ToString()),
                            DNI = int.Parse(DataReader["dni"].ToString()),
                            Domicilio = DataReader["domicilio"].ToString(),
                            Telefono = DataReader["telefono"].ToString(),
                            Mail = DataReader["mail"].ToString(),
                            FechadeNacimiento = DateTime.Parse(DataReader["fechanac"].ToString()),
                            Password = DataReader["password"].ToString(),
                            Estudios = DataReader["estudios"].ToString(),
                            MateriasAdeudadas = DataReader["materiasadeudadas"].ToString(),
                            URL=DataReader["url"].ToString()
                        });
                        return usuarios;
                    }

                }
            }
         }
        public Usuario ReadOne(int ID)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuarios_find", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("id", ID);
                    DB.Open();
                    using (var DataReader = Command.ExecuteReader())
                    {
                        if (DataReader.Read()) return new Usuario()
                        {
                            Nombre = DataReader["nombre"].ToString(),
                            ID = int.Parse(DataReader["id"].ToString()),
                            DNI = int.Parse(DataReader["dni"].ToString()),
                            Domicilio = DataReader["domicilio"].ToString(),
                            Telefono = DataReader["telefono"].ToString(),
                            Mail = DataReader["mail"].ToString(),
                            FechadeNacimiento = DateTime.Parse(DataReader["fechanac"].ToString()),
                            Password = DataReader["password"].ToString(),
                            Estudios = DataReader["estudios"].ToString(),
                            MateriasAdeudadas = DataReader["materiasadeudadas"].ToString(),
                            URL = DataReader["url"].ToString()

                        };
                        else return default;
                    }

                }
            }
        }
        public void Update(int ID, Usuario obj)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuarios_update", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("id", ID);
                    Command.Parameters.AddWithValue("nombre", obj.Nombre);
                    Command.Parameters.AddWithValue("dni", obj.DNI);
                    Command.Parameters.AddWithValue("domicilio", obj.Domicilio);
                    Command.Parameters.AddWithValue("telefono", obj.Telefono);
                    Command.Parameters.AddWithValue("mail", obj.Mail);
                    Command.Parameters.AddWithValue("fechanac", obj.FechadeNacimiento.Date);
                    Command.Parameters.AddWithValue("password", obj.Password);
                    Command.Parameters.AddWithValue("estudios", obj.Estudios);
                    Command.Parameters.AddWithValue("materiasadeudadas", obj.MateriasAdeudadas);
                    Command.Parameters.AddWithValue("url", obj.URL);
                    DB.Open();
                    //Devuelve el ID, que es el dato de la primera columna de la consulta que devuelve el identity
                    Command.ExecuteNonQuery();

                }
            }
        }
        public void Delete(int ID)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuarios_delete", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("id", ID);
                    DB.Open();
                    Command.ExecuteNonQuery();

                }
            }
        }
        #endregion
        public Usuario FindByMail(string Mail)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuarios_findbymail", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("mail", Mail);
                    DB.Open();
                    using (var DataReader = Command.ExecuteReader())
                    {
                        if (DataReader.Read()) return new Usuario()
                        {
                            Nombre = DataReader["nombre"].ToString(),
                            ID = int.Parse(DataReader["id"].ToString()),
                            DNI = int.Parse(DataReader["dni"].ToString()),
                            Domicilio = DataReader["domicilio"].ToString(),
                            Telefono = DataReader["telefono"].ToString(),
                            Mail = DataReader["mail"].ToString(),
                            FechadeNacimiento = DateTime.Parse(DataReader["fechanac"].ToString()),
                            Password = DataReader["password"].ToString(),
                            Estudios = DataReader["estudios"].ToString(),
                            MateriasAdeudadas = DataReader["materiasadeudadas"].ToString()
                        };
                        else return default;
                    }

                }
            };
        }

        public bool MailExists(int ID, string Mail)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuarios_mailexists", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@id", ID);
                    Command.Parameters.AddWithValue("@mail", Mail);

                    DB.Open();
                    return int.Parse(Command.ExecuteScalar().ToString())>0;

                }
            }
        }

        public bool DNIExists(int ID, int DNI)
        {
            using (var DB = new SqlConnection(ConfigKeys.ConnectionString))
            {
                using (var Command = new SqlCommand("usuarios_dniexists", DB))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@id", ID);
                    Command.Parameters.AddWithValue("@mail", DNI);

                    DB.Open();
                    return int.Parse(Command.ExecuteScalar().ToString()) > 0;

                }
            }
        }
    }
}
