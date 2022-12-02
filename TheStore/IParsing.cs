using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace TheStore
{
    internal interface IParsing<T>
    {
        T parse(string[] words);
    }
}