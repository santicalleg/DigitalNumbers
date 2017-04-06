using DigitalNumbers.Business;
using DigitalNumbers.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the values");
            var input = Console.ReadLine();

            var userInputs = new List<string>
            {
                input
            };

            while (input != "0,0")
            {
                Console.WriteLine();
                input = Console.ReadLine();

                if (input != "0,0")
                    userInputs.Add(input);
            }

            var service = new DigitalNumberService();

            var result = service.GenerateDigitalNumbers(userInputs);

            foreach (var item in result)
            {
                foreach (var numberArray in item)
                {
                    for (int i = 0; i < numberArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < numberArray.GetLength(1); j++)
                        {
                            Console.Write(numberArray[i, j] ?? " ");
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("---------------------------");
            }       

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
