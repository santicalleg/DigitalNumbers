using DigitalNumbers.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNumbers.Business
{
    class DigitalNumberService
    {
		public IEnumerable<string[,]>
			GenerateDigitalNumbers(IEnumerable<string> userInput)
		{
			var list = new List<string[,]>();
			var splitList = SplitList(userInput);

			foreach (var item in splitList)
			{
				int rows = 0;
				int.TryParse(item[0], out rows);

				var result = GetDigitalNumbers(rows, item[1]);

				list.Add(result);
			}

			return list;
		}

		//Separar los datos enviados por los usuarios, tomando el primer parámetro como
		//la cantidad de filas y líneas y como segundo parámetro los números a imprimir
		private IEnumerable<string[]> SplitList(IEnumerable<string> userInput)
        {
            var list = new List<string[]>();
            foreach (var item in userInput)
            {
                list.Add(item.Split(','));
            }

            return list;
        }
		
		//Recorrer la lista de números y generar el número digitalmente en un array
		//Devuelve un array con todos los números digitalizados concatenados
		private string[,] GetDigitalNumbers(int userRows, string numbers)
		{
			int rows = (2 * userRows) + 3;
			int cols = 2 + userRows;
			int numberCount = numbers.ToArray().Length;
			var array = new string[rows, cols * numberCount];

			INumber service;
			var colIndex = 0;
			foreach (var item in numbers.ToArray())
			{
				int number = 0;
				int.TryParse(item.ToString(), out number);
				switch (number)
				{
					case 1:
						service = new OneService(rows, cols);
						break;
					case 2:
						service = new TwoService(rows, cols);
						break;
					case 3:
						service = new ThreeService(rows, cols);
						break;
					case 4:
						service = new FourService(rows, cols);
						break;
					case 5:
						service = new FiveService(rows, cols);
						break;
					case 6:
						service = new SixService(rows, cols);
						break;
					case 7:
						service = new SevenService(rows, cols);
						break;
					case 8:
						service = new EightService(rows, cols);
						break;
					case 9:
						service = new NineService(rows, cols);
						break;
					default:
						service = new ZeroService(rows, cols);
						break;
				}

				var numberResult = service.GenerateDigitalNumber();
				int colsArray = colIndex;
				for (int i = 0; i < numberResult.GetLength(0); i++)
				{
					for (int j = 0; j < numberResult.GetLength(1); j++)
					{
						array[i, colsArray] = numberResult[i, j];
						colsArray++;
					}
					colsArray = colIndex;
				}

				colIndex += cols;
			}

			return array;
		}
	}
}
