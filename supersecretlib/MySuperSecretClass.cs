using System;
using System.Diagnostics;
using System.Linq;

namespace supersecretlib
{
	//This is my super secret award-winning patented proprietary algorithm class
	public class MySuperSecretClass
	{
		public MySuperSecretClass()
		{
		}

		private string my_super_secret = "mysupersecret";



		/// <summary>
		/// This function will return the string member above
		/// but it does some extra garbage work because this programmer
		/// likes to bloat his code =).
		/// </summary>
		public string getMySecret()
		{

			//Some completely random logic
			//Just to see what gets IL stripped
			var randomz = "";
			for (var i = 0; i < 10; i++)
			{
				randomz = my_super_secret.ToCharArray().Reverse() + "woowwww magic";
			}

			var more_silliness = new[] { randomz, my_super_secret };

			return more_silliness.OrderBy(c => c.Length).FirstOrDefault(); 
			;
		}
	}
}

