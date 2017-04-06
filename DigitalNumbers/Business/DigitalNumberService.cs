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
        public IEnumerable<IEnumerable<string[,]>> 
            GenerateDigitalNumbers(IEnumerable<string> userInput)
        {
            var list = new List<IEnumerable<string[,]>>();
            var splitList = SplitList(userInput);

            foreach (var item in splitList)
            {
                int.TryParse(item[0], out int rows);

                var result = GetDigitalNumbers(rows, item[1]);

                list.Add(result);
            }

            return list;
        }

        private IEnumerable<string[]> SplitList(IEnumerable<string> userInput)
        {
            var list = new List<string[]>();
            foreach (var item in userInput)
            {
                list.Add(item.Split(','));
            }

            return list;
        }

        private IEnumerable<string[,]> GetDigitalNumbers(int userRows, string numbers)
        {
            int rows = (2 * userRows) + 3;
            int cols = 2 + userRows;

            var list = new List<string[,]>();

            INumber service;

            foreach (var item in numbers.ToArray())
            {
                int.TryParse(item.ToString(), out int number);
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
                list.Add(numberResult);
            }
            
            return list;
        }
    }
}
