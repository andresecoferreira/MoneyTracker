
 
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
	/// View Category Month
	/// </summary>
	public class CSGenioAview_catmonth : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAview_catmonth(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL MNT CONSTRUTOR VIEW_CATMONTH]/
		}

		public CSGenioAview_catmonth(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codview_catmonth", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "category_type", FieldType.TEXT);
			Qfield.FieldDescription = "Category Type";
			Qfield.FieldSize =  30;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CATEGORY_TYPE34342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "month", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "Month";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MONTH46035";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNmonth";
            Qfield.ArrayClassName = "Month";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "year", FieldType.NUMERIC);
			Qfield.FieldDescription = "Year";
			Qfield.FieldSize =  4;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 4;
			Qfield.CavDesignation = "YEAR61794";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "total", FieldType.CURRENCY);
			Qfield.FieldDescription = "Total";
			Qfield.FieldSize =  12;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 9;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "TOTAL49307";

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
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(0);
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAview_catmonth()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="MNT";
			info.TableName="view_catmonth";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codview_catmonth";
			info.HumanKeyName="category_type,".TrimEnd(',');
			info.Alias="view_catmonth";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.View;
			info.AreaDesignation="View Category Month";
			info.AreaPluralDesignation="View Category Months";
			info.DescriptionCav="VIEW_CATEGORY_MONTH41151";

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
		public static FieldRef FldCodview_catmonth { get { return m_fldCodview_catmonth; } }
		private static FieldRef m_fldCodview_catmonth = new FieldRef("view_catmonth", "codview_catmonth");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodview_catmonth
		{
			get { return (string)returnValueField(FldCodview_catmonth); }
			set { insertNameValueField(FldCodview_catmonth, value); }
		}

		/// <summary>Field : "Category Type" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCategory_type { get { return m_fldCategory_type; } }
		private static FieldRef m_fldCategory_type = new FieldRef("view_catmonth", "category_type");

		/// <summary>Field : "Category Type" Tipo: "C" Formula:  ""</summary>
		public string ValCategory_type
		{
			get { return (string)returnValueField(FldCategory_type); }
			set { insertNameValueField(FldCategory_type, value); }
		}

		/// <summary>Field : "Month" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldMonth { get { return m_fldMonth; } }
		private static FieldRef m_fldMonth = new FieldRef("view_catmonth", "month");

		/// <summary>Field : "Month" Tipo: "AN" Formula:  ""</summary>
		public decimal ValMonth
		{
			get { return (decimal)returnValueField(FldMonth); }
			set { insertNameValueField(FldMonth, value); }
		}

		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldYear { get { return m_fldYear; } }
		private static FieldRef m_fldYear = new FieldRef("view_catmonth", "year");

		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		public decimal ValYear
		{
			get { return (decimal)returnValueField(FldYear); }
			set { insertNameValueField(FldYear, value); }
		}

		/// <summary>Field : "Total" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldTotal { get { return m_fldTotal; } }
		private static FieldRef m_fldTotal = new FieldRef("view_catmonth", "total");

		/// <summary>Field : "Total" Tipo: "$" Formula:  ""</summary>
		public decimal ValTotal
		{
			get { return (decimal)returnValueField(FldTotal); }
			set { insertNameValueField(FldTotal, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("view_catmonth", "zzstate");



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
        public static CSGenioAview_catmonth search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAview_catmonth area = new CSGenioAview_catmonth(user, user.CurrentModule);

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
        public static List<CSGenioAview_catmonth> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAview_catmonth>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAview_catmonth> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAview_catmonth>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL MNT TABAUX VIEW_CATMONTH]/

 
      

	}
}
