using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNumbers.Numbers
{
    class FiveService : BaseNumber
    {
        public FiveService() { }
        public FiveService(int rows, int cols): base(rows, cols) { }

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
                    else if (i < ((_rows - 1) / 2))
                    {
                        result[i, 0] = "|";
                    }
                    else
                    {
                        result[i, _cols - 1] = "|";
                    }
                }
            }

            return result;
        }
    }
}
