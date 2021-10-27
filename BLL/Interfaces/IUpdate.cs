using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IUpdate<T>
    {
        void Update(int Id, T obj);
    }
}
