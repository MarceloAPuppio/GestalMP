﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IRead<T>
    {
        List<T> Read();
    }
}
