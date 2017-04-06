using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNumbers.Numbers
{
    class EightService : BaseNumber
    {
        public EightService() { }
        public EightService(int rows, int cols): base(rows, cols) { }

        public override string[,] GenerateDigitalNumber()
        {
            var result = new string[_rows, _cols];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (i == 0 || i == _rows - 1 || i == ((_rows - 1) / 2))
                    {
                        if (j != 0 && j != _cols - 1)
                        {
                            result[i, j] = "-";
                        }
                    }
                    else if ((i > 0 && i < _rows -1 && 
                        i != ((_rows - 1) / 2) && (j == 0 || j == _cols - 1)))
                    {
                        result[i, j] = "|";
                    }
                }
            }

            return result;
        }
    }
}
