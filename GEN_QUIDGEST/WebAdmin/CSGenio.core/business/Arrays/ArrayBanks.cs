using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Banks (Banks)
	/// </summary>
	public class ArrayBanks : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayBanks _instance = new ArrayBanks();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayBanks Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Caixa Geral de Depósitos
		/// </summary>
		public const string E_CGD_1 = "CGD";
		/// <summary>
		/// Millennium BCP
		/// </summary>
		public const string E_BCP_2 = "BCP";
		/// <summary>
		/// Santander Totta
		/// </summary>
		public const string E_SAN_3 = "SAN";
		/// <summary>
		/// Novo Banco
		/// </summary>
		public const string E_NOV_4 = "NOV";
		/// <summary>
		/// Crédito Agrícola
		/// </summary>
		public const string E_AGR_5 = "AGR";
		/// <summary>
		/// Montepio
		/// </summary>
		public const string E_MON_6 = "MON";
		/// <summary>
		/// CTT
		/// </summary>
		public const string E_CTT_7 = "CTT";
		/// <summary>
		/// ActivoBank
		/// </summary>
		public const string E_ACT_8 = "ACT";
		/// <summary>
		/// Bankinter
		/// </summary>
		public const string E_BAN_9 = "BAN";
		/// <summary>
		/// BBVA
		/// </summary>
		public const string E_BBVA_10 = "BBVA";
		/// <summary>
		/// Barclays
		/// </summary>
		public const string E_BAR_11 = "BAR";
		/// <summary>
		/// Banco Invest
		/// </summary>
		public const string E_INV_12 = "INV";
		/// <summary>
		/// 
		/// </summary>
		public const string E_BANCOFINANT_13 = "Banco Finant";
		/// <summary>
		/// Other
		/// </summary>
		public const string E_OTH_14 = "OTH";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayBanks"/> class from being created.
		/// </summary>
		private ArrayBanks() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_CGD_1, new ArrayElement() { ResourceId = "CAIXA_GERAL_DE_DEPOS46856", HelpId = "", Group = "" } },
				{ E_BCP_2, new ArrayElement() { ResourceId = "MILLENNIUM_BCP40100", HelpId = "", Group = "" } },
				{ E_SAN_3, new ArrayElement() { ResourceId = "SANTANDER_TOTTA33421", HelpId = "", Group = "" } },
				{ E_NOV_4, new ArrayElement() { ResourceId = "NOVO_BANCO19183", HelpId = "", Group = "" } },
				{ E_AGR_5, new ArrayElement() { ResourceId = "CREDITO_AGRICOLA06541", HelpId = "", Group = "" } },
				{ E_MON_6, new ArrayElement() { ResourceId = "MONTEPIO14226", HelpId = "", Group = "" } },
				{ E_CTT_7, new ArrayElement() { ResourceId = "CTT12892", HelpId = "", Group = "" } },
				{ E_ACT_8, new ArrayElement() { ResourceId = "ACTIVOBANK40861", HelpId = "", Group = "" } },
				{ E_BAN_9, new ArrayElement() { ResourceId = "BANKINTER32282", HelpId = "", Group = "" } },
				{ E_BBVA_10, new ArrayElement() { ResourceId = "BBVA62372", HelpId = "", Group = "" } },
				{ E_BAR_11, new ArrayElement() { ResourceId = "BARCLAYS52239", HelpId = "", Group = "" } },
				{ E_INV_12, new ArrayElement() { ResourceId = "BANCO_INVEST63938", HelpId = "", Group = "" } },
				{ E_BANCOFINANT_13, new ArrayElement() { ResourceId = "", HelpId = "", Group = "" } },
				{ E_OTH_14, new ArrayElement() { ResourceId = "OTHER37293", HelpId = "", Group = "" } },
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
