using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Accout_Type (Account Type)
	/// </summary>
	public class ArrayAccout_type : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAccout_type _instance = new ArrayAccout_type();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAccout_type Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Cash
		/// </summary>
		public const string E_CA_1 = "CA";
		/// <summary>
		/// Checking Account
		/// </summary>
		public const string E_CH_2 = "CH";
		/// <summary>
		/// Savings Account
		/// </summary>
		public const string E_SA_3 = "SA";
		/// <summary>
		/// Retirement Plan
		/// </summary>
		public const string E_RE_4 = "RE";
		/// <summary>
		/// Loan
		/// </summary>
		public const string E_LO_5 = "LO";
		/// <summary>
		/// Credit Card
		/// </summary>
		public const string E_CR_6 = "CR";
		/// <summary>
		/// Digital Wallet
		/// </summary>
		public const string E_DI_7 = "DI";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAccout_type"/> class from being created.
		/// </summary>
		private ArrayAccout_type() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_CA_1, new ArrayElement() { ResourceId = "CASH27299", HelpId = "", Group = "" } },
				{ E_CH_2, new ArrayElement() { ResourceId = "CHECKING_ACCOUNT17850", HelpId = "", Group = "" } },
				{ E_SA_3, new ArrayElement() { ResourceId = "SAVINGS_ACCOUNT04205", HelpId = "", Group = "" } },
				{ E_RE_4, new ArrayElement() { ResourceId = "RETIREMENT_PLAN57267", HelpId = "", Group = "" } },
				{ E_LO_5, new ArrayElement() { ResourceId = "LOAN50644", HelpId = "", Group = "" } },
				{ E_CR_6, new ArrayElement() { ResourceId = "CREDIT_CARD46407", HelpId = "", Group = "" } },
				{ E_DI_7, new ArrayElement() { ResourceId = "DIGITAL_WALLET00561", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
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
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
