
 
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
	/// Investment
	/// </summary>
	public class CSGenioAinvestment : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAinvestment(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL MNT CONSTRUTOR INVESTMENT]/
		}

		public CSGenioAinvestment(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codinvestment", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "investment_id", FieldType.NUMERIC);
			Qfield.FieldDescription = "Id";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "ID36840";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			argumentsListByArea = new List<ByAreaArguments>();
			Qfield.BlockWhen = new ConditionFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return true;
			});
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "investment_id");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "category_id", FieldType.KEY_INT);
			Qfield.FieldDescription = "Category";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CATEGORY18978";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "member_id", FieldType.KEY_INT);
			Qfield.FieldDescription = "Member";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MEMBER00534";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "source_id", FieldType.KEY_INT);
			Qfield.FieldDescription = "Account";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ACCOUNT64260";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "type_id", FieldType.KEY_INT);
			Qfield.FieldDescription = "Category Type";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CATEGORY_TYPE34342";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "value", FieldType.NUMERIC);
			Qfield.FieldDescription = "Value";
			Qfield.FieldSize =  12;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 12;
			Qfield.CavDesignation = "VALUE10285";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "description", FieldType.TEXT);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "date", FieldType.DATE);
			Qfield.FieldDescription = "Date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE18475";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "updated_at", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Updated At";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UPDATED_AT48366";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "created_at", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Created At";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CREATED_AT09073";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "created_by", FieldType.TEXT);
			Qfield.FieldDescription = "Created By";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CREATED_BY58035";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "updated_by", FieldType.TEXT);
			Qfield.FieldDescription = "Updated By";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UPDATED_AT48366";

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
			info.ParentTables.Add("category", new Relation("MNT", "mntinvestment", "investment", "codinvestment", "category_id", "MNT", "mntcategory", "category", "codcategory", "codcategory"));
			info.ParentTables.Add("category_type", new Relation("MNT", "mntinvestment", "investment", "codinvestment", "type_id", "MNT", "mntcategory_type", "category_type", "codcategory_type", "codcategory_type"));
			info.ParentTables.Add("member", new Relation("MNT", "mntinvestment", "investment", "codinvestment", "member_id", "MNT", "mntmember", "member", "codmember", "codmember"));
			info.ParentTables.Add("source", new Relation("MNT", "mntinvestment", "investment", "codinvestment", "source_id", "MNT", "mntsource", "source", "codsource", "codsource"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(5);
			info.Pathways.Add("category_type","category_type");
			info.Pathways.Add("category","category");
			info.Pathways.Add("member","member");
			info.Pathways.Add("source","source");
			info.Pathways.Add("group","member");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.SequentialDefaultValues = new string[] {
			 "investment_id"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAinvestment()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="MNT";
			info.TableName="mntinvestment";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codinvestment";
			info.HumanKeyName="investment_id,".TrimEnd(',');
			info.Alias="investment";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Investment";
			info.AreaPluralDesignation="Investments";
			info.DescriptionCav="INVESTMENT14761";

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
			info.StampFieldsIns = new string[] {
                "created_by","created_at"
			};

			info.StampFieldsAlt = new string[] {
                "updated_by","updated_at"
			};
            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

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
		public static FieldRef FldCodinvestment { get { return m_fldCodinvestment; } }
		private static FieldRef m_fldCodinvestment = new FieldRef("investment", "codinvestment");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodinvestment
		{
			get { return (string)returnValueField(FldCodinvestment); }
			set { insertNameValueField(FldCodinvestment, value); }
		}

		/// <summary>Field : "Id" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldInvestment_id { get { return m_fldInvestment_id; } }
		private static FieldRef m_fldInvestment_id = new FieldRef("investment", "investment_id");

		/// <summary>Field : "Id" Tipo: "N" Formula:  ""</summary>
		public decimal ValInvestment_id
		{
			get { return (decimal)returnValueField(FldInvestment_id); }
			set { insertNameValueField(FldInvestment_id, value); }
		}

		/// <summary>Field : "Category" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCategory_id { get { return m_fldCategory_id; } }
		private static FieldRef m_fldCategory_id = new FieldRef("investment", "category_id");

		/// <summary>Field : "Category" Tipo: "CE" Formula:  ""</summary>
		public string ValCategory_id
		{
			get { return (string)returnValueField(FldCategory_id); }
			set { insertNameValueField(FldCategory_id, value); }
		}

		/// <summary>Field : "Member" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldMember_id { get { return m_fldMember_id; } }
		private static FieldRef m_fldMember_id = new FieldRef("investment", "member_id");

		/// <summary>Field : "Member" Tipo: "CE" Formula:  ""</summary>
		public string ValMember_id
		{
			get { return (string)returnValueField(FldMember_id); }
			set { insertNameValueField(FldMember_id, value); }
		}

		/// <summary>Field : "Account" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldSource_id { get { return m_fldSource_id; } }
		private static FieldRef m_fldSource_id = new FieldRef("investment", "source_id");

		/// <summary>Field : "Account" Tipo: "CE" Formula:  ""</summary>
		public string ValSource_id
		{
			get { return (string)returnValueField(FldSource_id); }
			set { insertNameValueField(FldSource_id, value); }
		}

		/// <summary>Field : "Category Type" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldType_id { get { return m_fldType_id; } }
		private static FieldRef m_fldType_id = new FieldRef("investment", "type_id");

		/// <summary>Field : "Category Type" Tipo: "CE" Formula:  ""</summary>
		public string ValType_id
		{
			get { return (string)returnValueField(FldType_id); }
			set { insertNameValueField(FldType_id, value); }
		}

		/// <summary>Field : "Value" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldValue { get { return m_fldValue; } }
		private static FieldRef m_fldValue = new FieldRef("investment", "value");

		/// <summary>Field : "Value" Tipo: "N" Formula:  ""</summary>
		public decimal ValValue
		{
			get { return (decimal)returnValueField(FldValue); }
			set { insertNameValueField(FldValue, value); }
		}

		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDescription { get { return m_fldDescription; } }
		private static FieldRef m_fldDescription = new FieldRef("investment", "description");

		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public string ValDescription
		{
			get { return (string)returnValueField(FldDescription); }
			set { insertNameValueField(FldDescription, value); }
		}

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("investment", "date");

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}

		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		public static FieldRef FldUpdated_at { get { return m_fldUpdated_at; } }
		private static FieldRef m_fldUpdated_at = new FieldRef("investment", "updated_at");

		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		public DateTime ValUpdated_at
		{
			get { return (DateTime)returnValueField(FldUpdated_at); }
			set { insertNameValueField(FldUpdated_at, value); }
		}

		/// <summary>Field : "Created At" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreated_at { get { return m_fldCreated_at; } }
		private static FieldRef m_fldCreated_at = new FieldRef("investment", "created_at");

		/// <summary>Field : "Created At" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreated_at
		{
			get { return (DateTime)returnValueField(FldCreated_at); }
			set { insertNameValueField(FldCreated_at, value); }
		}

		/// <summary>Field : "Created By" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreated_by { get { return m_fldCreated_by; } }
		private static FieldRef m_fldCreated_by = new FieldRef("investment", "created_by");

		/// <summary>Field : "Created By" Tipo: "ON" Formula:  ""</summary>
		public string ValCreated_by
		{
			get { return (string)returnValueField(FldCreated_by); }
			set { insertNameValueField(FldCreated_by, value); }
		}

		/// <summary>Field : "Updated By" Tipo: "EN" Formula:  ""</summary>
		public static FieldRef FldUpdated_by { get { return m_fldUpdated_by; } }
		private static FieldRef m_fldUpdated_by = new FieldRef("investment", "updated_by");

		/// <summary>Field : "Updated By" Tipo: "EN" Formula:  ""</summary>
		public string ValUpdated_by
		{
			get { return (string)returnValueField(FldUpdated_by); }
			set { insertNameValueField(FldUpdated_by, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("investment", "zzstate");



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
        public static CSGenioAinvestment search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAinvestment area = new CSGenioAinvestment(user, user.CurrentModule);

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
        public static List<CSGenioAinvestment> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAinvestment>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAinvestment> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAinvestment>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL MNT TABAUX INVESTMENT]/

 
              

	}
}
