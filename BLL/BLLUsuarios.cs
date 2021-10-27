using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MODELS;
using DAL;
namespace BLL
{
    public class BLLUsuarios : IReadOne<Usuario>, IRead<Usuario>, ICreate<Usuario>, IUpdate<Usuario>, IDelete
    {
        public readonly DALUsuarios  DALU;
        public readonly DALUsuariosRoles DALUR;

        public BLLUsuarios()
        {
            this.DALU = new DALUsuarios();
            this.DALUR = new DALUsuariosRoles();
        }

        public void Create(Usuario obj)
        {
            obj.ID=DALU.Create(obj);
        }

        public void Delete(int ID)
        {
            DALU.Delete(ID);
        }

        public List<Usuario> Read()
        {
            var users = DALU.Read();
            foreach (var user in users)
            {
                user.Roles = DALUR.ListRolesByUsuario(user);
            }
            return users;
        }

        public Usuario ReadOne(int ID)
        {
            var user = DALU.ReadOne(ID);
            user.Roles = DALUR.ListRolesByUsuario(user);
            return user;
        }

        public void Update(int Id, Usuario obj)
        {
            DALU.Update(Id, obj);
        }
    }
}
