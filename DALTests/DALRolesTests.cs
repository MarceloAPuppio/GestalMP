using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class DALRolesTests
    {
        [TestMethod()]
        public void ReadAllTest()
        {
            var DALR = new DALRoles();
            var actual = DALR.Read().ToArray()[0].Nombre;
            string expected = "administrador";
            Assert.AreEqual(actual, expected);
        }

    }
}


