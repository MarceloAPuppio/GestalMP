using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class DALUsuariosTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var DALU = new DALUsuarios();
            var actual = DALU.Create(new MODELS.Usuario()
            {
                Nombre = "Pepe",
                DNI = 34948411,
                Domicilio = "casadante",
                Estudios = "Dogtorado",
                FechadeNacimiento = DateTime.Parse("23-08-2012"),
                Mail = "Pepe@mail",
                Password = "Danulooo",
                Telefono = "1234",
                MateriasAdeudadas = "Ninguna",
                URL="images/usuarios/pepe.png"

            });

            int expected = 9;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void ReadTest()
        {
            var DALU = new DALUsuarios();
            var expected = "Dogtorado";
            var actual = DALU.Read().ToArray()[1].Estudios;
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void ReadOneTest()
        {
            var DALU = new DALUsuarios();
            MODELS.Usuario expected = null;
            var actual = DALU.ReadOne(3);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var DALU = new DALUsuarios();
            DALU.Update(2, new MODELS.Usuario()
            {
                Nombre = "Dante Chapuppio",
                DNI = 34948491,
                Domicilio = "casadante",
                Estudios = "Dogtorado",
                FechadeNacimiento = DateTime.Parse("23-08-2012"),
                Mail = "daten@mail",
                Password = "Dantulooo",
                Telefono = "123456",
                MateriasAdeudadas = "Ninguna"
            });
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var DALU = new DALUsuarios();
            DALU.Delete(2);
        }

        [TestMethod()]
        public void MailExistsTest()
        {
            var DALU = new DALUsuarios();
            var actual = DALU.MailExists(4, "daten@mail");
            var expected = true;
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void FindByMailTest()
        {
            var DALU = new DALUsuarios();
            var expected=4;
            var actual = DALU.FindByMail("daten@mail").ID;
            Assert.AreEqual(actual, expected);
        }
    }
}