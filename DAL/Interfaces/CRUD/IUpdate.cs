using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IUpdate<T>
    {
        void Update(int ID, T obj);
    }
}
