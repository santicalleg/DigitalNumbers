using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNumbers.Numbers
{
    class OneService : BaseNumber
    {
        public OneService() { }
        public OneService(int rows, int cols): base(rows, cols) { }

        public override string[,] GenerateDigitalNumber()
        {
            var result = new string[_rows, _cols];

            for (int i = 0; i < _rows; i++)
            {
                if (i != 0 && i != _rows - 1 && i != ((_rows - 1) / 2))
                {
                    result[i, _cols -1] = "|";
                }
            }

            return result;
        }
    }
}
