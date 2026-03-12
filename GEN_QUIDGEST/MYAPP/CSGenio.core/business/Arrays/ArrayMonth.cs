using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Month (Month)
	/// </summary>
	public class ArrayMonth : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayMonth _instance = new ArrayMonth();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayMonth Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Janeiro
		/// </summary>
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// Fevereiro
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// Março
		/// </summary>
		public const decimal E_3_3 = 3M;
		/// <summary>
		/// Abril
		/// </summary>
		public const decimal E_4_4 = 4M;
		/// <summary>
		/// Maio
		/// </summary>
		public const decimal E_5_5 = 5M;
		/// <summary>
		/// Junho
		/// </summary>
		public const decimal E_6_6 = 6M;
		/// <summary>
		/// Julho
		/// </summary>
		public const decimal E_7_7 = 7M;
		/// <summary>
		/// Agosto
		/// </summary>
		public const decimal E_8_8 = 8M;
		/// <summary>
		/// Setembro
		/// </summary>
		public const decimal E_9_9 = 9M;
		/// <summary>
		/// Outubro
		/// </summary>
		public const decimal E_10_10 = 10M;
		/// <summary>
		/// Novembro
		/// </summary>
		public const decimal E_11_11 = 11M;
		/// <summary>
		/// Dezembro
		/// </summary>
		public const decimal E_12_12 = 12M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayMonth"/> class from being created.
		/// </summary>
		private ArrayMonth() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "JANEIRO25316", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "FEVEREIRO25443", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "MARCO22234", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "ABRIL58220", HelpId = "", Group = "" } },
				{ E_5_5, new ArrayElement() { ResourceId = "MAIO10443", HelpId = "", Group = "" } },
				{ E_6_6, new ArrayElement() { ResourceId = "JUNHO15214", HelpId = "", Group = "" } },
				{ E_7_7, new ArrayElement() { ResourceId = "JULHO20764", HelpId = "", Group = "" } },
				{ E_8_8, new ArrayElement() { ResourceId = "AGOSTO05568", HelpId = "", Group = "" } },
				{ E_9_9, new ArrayElement() { ResourceId = "SETEMBRO19956", HelpId = "", Group = "" } },
				{ E_10_10, new ArrayElement() { ResourceId = "OUTUBRO17690", HelpId = "", Group = "" } },
				{ E_11_11, new ArrayElement() { ResourceId = "NOVEMBRO18614", HelpId = "", Group = "" } },
				{ E_12_12, new ArrayElement() { ResourceId = "DEZEMBRO01950", HelpId = "", Group = "" } },
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
