﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DocumentFun
{
    class Document : IEnumerable<DocumentElement>, IElement
    {
        private readonly List<DocumentElement> _elements;

        public Document( params DocumentElement[] elements ) : this(elements.AsEnumerable())
        {
        }

        public Document( IEnumerable<DocumentElement> elements )
        {
            _elements = elements.ToList();
        }

        public void Accept( IVisitor visitor )
        {
            foreach (IElement element in _elements)
            {
                element.Accept(visitor);
            }
        }

        public IEnumerator<DocumentElement> GetEnumerator() => _elements.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
