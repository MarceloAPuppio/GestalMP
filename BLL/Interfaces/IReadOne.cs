using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IReadOne<T>
    {
        T ReadOne(int ID);
    }
}
