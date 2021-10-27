using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class DALUsuariosRolesTests
    {
        [TestMethod()]
        public void ListRolesByUsuarioTest()
        {
            var DALUR = new DALUsuariosRoles();
            var user = new MODELS.Usuario() { ID = 1 };
            var roles = DALUR.ListRolesByUsuario(user);
            var expected = "administrador";
            var actual = roles.ToArray()[0].Nombre;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var DALUR = new DALUsuariosRoles();
            var expected = 4;
            var actual = DALUR.Create(new MODELS.UsuarioRol() { IDUsuario = 1, Rol = "alumno" });
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            var DALUR = new DALUsuariosRoles();
            DALUR.Delete(2);
        }

        [TestMethod()]
        public void DeleteByUsuarioAndRolTest()
        {
            var DALUR = new DALUsuariosRoles();
            DALUR.DeleteByUsuarioAndRol(1,"alumno");
        }
    }
}