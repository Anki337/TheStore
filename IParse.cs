using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace TheStore
{
    internal interface IParse<T>
    {
        T parse(string[] words);
    }
}