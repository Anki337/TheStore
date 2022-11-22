using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace TheStore
{
    internal interface IParse
    {
        Object parse(string[] words);

        string[] toStringArray(List<Object> list);
    }
}