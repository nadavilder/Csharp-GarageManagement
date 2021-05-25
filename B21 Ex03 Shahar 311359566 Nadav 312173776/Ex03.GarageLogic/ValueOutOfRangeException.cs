using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException:Exception
    {
        public ValueOutOfRangeException() { }

        public ValueOutOfRangeException(string message)
            : base(message) { }

        public ValueOutOfRangeException(string message, Exception inner)
            : base(message, inner) { }
    }
}

