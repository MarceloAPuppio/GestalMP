using System;
using System.Collections.Generic;
using DAL;
using MODELS;
using System.Text.Json;

namespace BLL
{
    public class BLLRoles
    {
        DALRoles DR = new DALRoles();
        public string Read()
        {
            return JsonSerializer.Serialize(DR.Read());
        }
        public void Create(Rol obj)
        {
            DR.Create(obj);
        }
    }
}
