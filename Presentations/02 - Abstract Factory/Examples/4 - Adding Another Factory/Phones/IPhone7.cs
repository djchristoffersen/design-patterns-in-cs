﻿using System;

namespace Wincubate.AbstractFactoryExamples
{
    class Iphone7 : IMobilePhone
    {
        public int MemoryGb { get; }

        public Iphone7( int memoryGb )
        {
            MemoryGb = memoryGb;
        }

        public void Call( string who )
        {
            Console.WriteLine($"Calling {who} from an iPhone 6 with {MemoryGb} GB of memory");
        }
    }
}
