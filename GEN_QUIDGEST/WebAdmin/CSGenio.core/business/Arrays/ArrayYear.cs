using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Year (Year)
	/// </summary>
	public class ArrayYear : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayYear _instance = new ArrayYear();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayYear Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// 2024
		/// </summary>
		public const decimal E_2024_1 = 2024M;
		/// <summary>
		/// 2025
		/// </summary>
		public const decimal E_2025_2 = 2025M;
		/// <summary>
		/// 2026
		/// </summary>
		public const decimal E_2026_3 = 2026M;
		/// <summary>
		/// 2027
		/// </summary>
		public const decimal E_2027_4 = 2027M;
		/// <summary>
		/// 2028
		/// </summary>
		public const decimal E_2028_5 = 2028M;
		/// <summary>
		/// 2029
		/// </summary>
		public const decimal E_2029_6 = 2029M;
		/// <summary>
		/// 2030
		/// </summary>
		public const decimal E_2030_7 = 2030M;
		/// <summary>
		/// 2031
		/// </summary>
		public const decimal E_2031_8 = 2031M;
		/// <summary>
		/// 2032
		/// </summary>
		public const decimal E_2032_9 = 2032M;
		/// <summary>
		/// 2033
		/// </summary>
		public const decimal E_2033_10 = 2033M;
		/// <summary>
		/// 2034
		/// </summary>
		public const decimal E_2034_11 = 2034M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayYear"/> class from being created.
		/// </summary>
		private ArrayYear() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_2024_1, new ArrayElement() { ResourceId = "_202400656", HelpId = "", Group = "" } },
				{ E_2025_2, new ArrayElement() { ResourceId = "_202532271", HelpId = "", Group = "" } },
				{ E_2026_3, new ArrayElement() { ResourceId = "_202632186", HelpId = "", Group = "" } },
				{ E_2027_4, new ArrayElement() { ResourceId = "_202700809", HelpId = "", Group = "" } },
				{ E_2028_5, new ArrayElement() { ResourceId = "_202807604", HelpId = "", Group = "" } },
				{ E_2029_6, new ArrayElement() { ResourceId = "_202907971", HelpId = "", Group = "" } },
				{ E_2030_7, new ArrayElement() { ResourceId = "_203048858", HelpId = "", Group = "" } },
				{ E_2031_8, new ArrayElement() { ResourceId = "_203116808", HelpId = "", Group = "" } },
				{ E_2032_9, new ArrayElement() { ResourceId = "_203216389", HelpId = "", Group = "" } },
				{ E_2033_10, new ArrayElement() { ResourceId = "_203316530", HelpId = "", Group = "" } },
				{ E_2034_11, new ArrayElement() { ResourceId = "_203450326", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(decimal cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<decimal> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(decimal.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<decimal, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(decimal.Parse(cod));
		}
	}
}
