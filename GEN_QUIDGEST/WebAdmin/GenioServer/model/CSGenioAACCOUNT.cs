
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Account
	/// </summary>
	public class CSGenioAaccount : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAaccount(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL MNT CONSTRUTOR ACCOUNT]/
		}

		public CSGenioAaccount(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codaccount", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "type", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Type";
			Qfield.FieldSize =  2;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TYPE00312";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCaccout_type";
            Qfield.ArrayClassName = "Accout_type";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "title", FieldType.TEXT);
			Qfield.FieldDescription = "Title";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TITLE21885";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "balance", FieldType.NUMERIC);
			Qfield.FieldDescription = "Balance";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 12;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "BALANCE13297";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "bank", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Bank";
			Qfield.FieldSize =  12;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BANK26563";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"type"}, new int[] {0}, "account", "codaccount"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])!="CA";
			});
            Qfield.ArrayName = "dbo.GetValArrayCbanks";
            Qfield.ArrayClassName = "Banks";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "account_number", FieldType.TEXT);
			Qfield.FieldDescription = "Account Number";
			Qfield.FieldSize =  20;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ACCOUNT_NUMBER58504";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"type"}, new int[] {0}, "account", "codaccount"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])!="CA";
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "member_id", FieldType.KEY_INT);
			Qfield.FieldDescription = "Owner";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OWNER09558";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("member", new Relation("MNT", "mntaccount", "account", "codaccount", "member_id", "MNT", "mntmember", "member", "codmember", "codmember"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("member","member");
			info.Pathways.Add("group","member");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.DefaultValues = new string[] {
			 "balance"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAaccount()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="MNT";
			info.TableName="mntaccount";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codaccount";
			info.HumanKeyName="title,".TrimEnd(',');
			info.Alias="account";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Account";
			info.AreaPluralDesignation="Accounts";
			info.DescriptionCav="ACCOUNT64260";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------

            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();
			EPHField[] camposEPH;
						camposEPH = new EPHField[1];
			camposEPH[0] = new EPHField("MEMBERPSW", "member", "codmember", "=", false);
			info.Ephs.Add(new Par("MNT", "50"), camposEPH);

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodaccount { get { return m_fldCodaccount; } }
		private static FieldRef m_fldCodaccount = new FieldRef("account", "codaccount");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodaccount
		{
			get { return (string)returnValueField(FldCodaccount); }
			set { insertNameValueField(FldCodaccount, value); }
		}

		/// <summary>Field : "Type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldType { get { return m_fldType; } }
		private static FieldRef m_fldType = new FieldRef("account", "type");

		/// <summary>Field : "Type" Tipo: "AC" Formula:  ""</summary>
		public string ValType
		{
			get { return (string)returnValueField(FldType); }
			set { insertNameValueField(FldType, value); }
		}

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTitle { get { return m_fldTitle; } }
		private static FieldRef m_fldTitle = new FieldRef("account", "title");

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle
		{
			get { return (string)returnValueField(FldTitle); }
			set { insertNameValueField(FldTitle, value); }
		}

		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldBalance { get { return m_fldBalance; } }
		private static FieldRef m_fldBalance = new FieldRef("account", "balance");

		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		public decimal ValBalance
		{
			get { return (decimal)returnValueField(FldBalance); }
			set { insertNameValueField(FldBalance, value); }
		}

		/// <summary>Field : "Bank" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldBank { get { return m_fldBank; } }
		private static FieldRef m_fldBank = new FieldRef("account", "bank");

		/// <summary>Field : "Bank" Tipo: "AC" Formula:  ""</summary>
		public string ValBank
		{
			get { return (string)returnValueField(FldBank); }
			set { insertNameValueField(FldBank, value); }
		}

		/// <summary>Field : "Account Number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAccount_number { get { return m_fldAccount_number; } }
		private static FieldRef m_fldAccount_number = new FieldRef("account", "account_number");

		/// <summary>Field : "Account Number" Tipo: "C" Formula:  ""</summary>
		public string ValAccount_number
		{
			get { return (string)returnValueField(FldAccount_number); }
			set { insertNameValueField(FldAccount_number, value); }
		}

		/// <summary>Field : "Owner" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldMember_id { get { return m_fldMember_id; } }
		private static FieldRef m_fldMember_id = new FieldRef("account", "member_id");

		/// <summary>Field : "Owner" Tipo: "CE" Formula:  ""</summary>
		public string ValMember_id
		{
			get { return (string)returnValueField(FldMember_id); }
			set { insertNameValueField(FldMember_id, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("account", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAaccount search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAaccount area = new CSGenioAaccount(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields, forUpdate))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAaccount> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAaccount>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAaccount> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAaccount>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL MNT TABAUX ACCOUNT]/

 
        

	}
}
