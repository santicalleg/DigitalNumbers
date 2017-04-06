using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNumbers.Business.Classes.Helpers
{
	static class Validator
	{
		public static void ValidateUserInputs(IEnumerable<string> userInput)
		{
			var errors = new List<string>();

			if (!userInput.Any())
				errors.Add("Please enter any value");

			foreach (var item in userInput)
			{
				var split = item.Split(',');

				if (!split.Any() || split.Length > 2)
					errors.Add(string.Format("The value {0} is incorrect", item));

				int rows = 0;
				int.TryParse(split[0], out rows);

				if (rows <= 0 || rows > 10)
					errors.Add(string.Format("The row number in the value {0} must be numeric and be between 1 and 10", item));

				int numbers = 0;
				int.TryParse(split[1], out numbers);

				if (numbers == 0)
					errors.Add(string.Format("The value {0} must has numeric values", item));
			}

			if (errors.Any())
				throw new Exception(string.Join(",", errors));
		}
	}
}
