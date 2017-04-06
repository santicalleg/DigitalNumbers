using DigitalNumbers.Business;
using System;
using System.Collections.Generic;

namespace DigitalNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please enter the values. For example: 1,1234 2,3456 0,0");
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

			try
			{
				var result = service.GenerateDigitalNumbers(userInputs);

				foreach (var item in result)
				{
					for (int i = 0; i < item.GetLength(0); i++)
					{
						for (int j = 0; j < item.GetLength(1); j++)
						{
							Console.Write(item[i, j] ?? " ");
						}
						Console.WriteLine();
					}

					Console.WriteLine();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}
	}
}
