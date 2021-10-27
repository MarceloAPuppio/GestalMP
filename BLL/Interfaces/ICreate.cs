using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface ICreate<T>
    {
        void Create(T obj);
    }
}
