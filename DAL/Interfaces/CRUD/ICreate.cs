using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface ICreate<T>
    {
        int Create(T obj);
    }
}
