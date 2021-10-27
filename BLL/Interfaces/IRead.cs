using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IRead<T>
    {
        List<T> Read();
    }
}
