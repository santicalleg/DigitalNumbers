using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNumbers
{
    class BaseNumber : INumber
    {
        protected int _rows = 0;
        protected int _cols = 0;

        public BaseNumber() { }

        public BaseNumber(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
        }

        public virtual string[,] GenerateDigitalNumber()
        {
            throw new NotImplementedException();
        }
    }
}
