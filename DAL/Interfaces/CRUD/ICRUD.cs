using System;
using System.Collections.Generic;
using System.Text;
using MODELS;

namespace DAL
{
    interface ICRUD<T>:ICreate<T>, IRead<T>, IReadOne<T>, IUpdate<T>, IDelete
    {

    }
}
