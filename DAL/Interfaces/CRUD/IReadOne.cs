using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IReadOne<T>
    {
        T ReadOne(int ID);
    }
}
