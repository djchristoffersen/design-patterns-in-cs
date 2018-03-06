﻿using System.Collections.Generic;
using System.Dynamic;

namespace Library
{
    public abstract class PrettyPrinterBase : IPrettyPrinter
    {
        protected virtual void PrintPreamble() { }
        protected abstract void PrintBegin( string className );
        protected abstract void PrintEnd( string className );
        protected abstract void PrintProperty( string propertyName, object propertyValue );

        public void Print( ExpandoObject obj, string name = "Object" )
        {
            PrintPreamble();

            PrintBegin(name);

            foreach (KeyValuePair<string, object> kvp in obj as IDictionary<string, object>)
            {
                PrintProperty(kvp.Key, kvp.Value);
            }

            PrintEnd(name);
        }
    }
}
