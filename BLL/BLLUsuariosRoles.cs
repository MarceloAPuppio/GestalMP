using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using MODELS;
using DAL;

namespace BLL
{
    public class BLLUsuariosRoles : ICreate<UsuarioRol>
    {   private readonly DALUsuariosRoles DALUR;
        public BLLUsuariosRoles()
        {
            this.DALUR = new DALUsuariosRoles();
        }
        public void Create(UsuarioRol obj)
        {
            DALUR.Create(obj);
        }
    }
}
