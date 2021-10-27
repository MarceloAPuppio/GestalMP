using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IDALUsuarios
    {
        MODELS.Usuario FindByMail(string Mail);
        bool MailExists(int ID, string Mail);
        bool DNIExists(int ID, int DNI);

    }
}
