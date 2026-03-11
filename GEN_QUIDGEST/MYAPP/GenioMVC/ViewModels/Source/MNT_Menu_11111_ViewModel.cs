using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Source
{
	public class MNT_Menu_11111_ViewModel : MenuListViewModel<Models.Source>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<MNT_Menu_11111_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "source";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "73be29a6-7d32-443f-8589-e93ac84b47d1";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();
				// Limitations

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioAmember.FldGroup_id, Navigation.GetValue("group"));
				conds.Equal(CSGenioAsource.FldMember_id, Navigation.GetValue("member"));

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL MNT LIST_LIMITS 11111]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("source", user, "MNT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML11111");
			conditions.Equal(CSGenioAsource.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAsource.FldCodsource, CSGenioAsource.FldZzstate, CSGenioAsource.FldAccount_number, CSGenioAsource.FldTitle, CSGenioAsource.FldMember_id, CSGenioAmember.FldCodmember, CSGenioAmember.FldName, CSGenioAsource.FldBank, CSGenioAsource.FldBalance, CSGenioAsource.FldType };

			ListingMVC<CSGenioAsource> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);

			if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaMEMBER.Alias))
				qs.Join(CSGenio.business.Area.AreaMEMBER, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAmember.FldCodmember, CSGenioAsource.FldMember_id));
			if (qs.FromTable.TableAlias != areaBase.Alias)
			{
				if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaSOURCE.Alias))
					qs.Join(CSGenio.business.Area.AreaSOURCE, TableJoinType.Cross).On(CriteriaSet.And().Equal(areaBase.PrimaryKeyName, areaBase.PrimaryKeyName));
			}
			else
			{
				if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaGROUP.Alias))
					qs.Join(CSGenio.business.Area.AreaGROUP, TableJoinType.Cross).On(CriteriaSet.And().Equal(areaBase.PrimaryKeyName, areaBase.PrimaryKeyName));
			}





			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public MNT_Menu_11111_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MNT_Menu_11111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public MNT_Menu_11111_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MNT_Menu_11111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public MNT_Menu_11111_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAsource.FldAccount_number, FieldType.TEXT, Resources.Resources.ACCOUNT_NUMBER58504, 20, 0, true),
				new Exports.QColumn(CSGenioAsource.FldTitle, FieldType.TEXT, Resources.Resources.TITLE21885, 30, 0, true),
				new Exports.QColumn(CSGenioAmember.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAsource.FldBank, FieldType.ARRAY_TEXT, Resources.Resources.BANK26563, 12, 0, true, "Banks"),
				new Exports.QColumn(CSGenioAsource.FldBalance, FieldType.NUMERIC, Resources.Resources.BALANCE13297, 15, 2, true),
				new Exports.QColumn(CSGenioAsource.FldType, FieldType.ARRAY_TEXT, Resources.Resources.TYPE00312, 2, 0, true, "Accout_Type"),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAsource> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAsource> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();

			Menu ??= new TablePartial<MNT_Menu_11111_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			// Limit "DB"
			crs.Equal(CSGenioAmember.FldGroup_id, Navigation.GetValue("group"));
			// Limit "DB"
			crs.Equal(CSGenioAsource.FldMember_id, Navigation.GetValue("member"));
			if (isToExport)
			{
				// EPH
				crs = Models.Source.AddEPH<CSGenioAsource>(ref u, crs, "ML11111");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAsource.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("SOURCE", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAsource.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_source");
				Navigation.DestroyEntry("QMVC_POS_RECORD_source");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Source.AddEPH<CSGenioAsource>(ref u, null, "ML11111"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAsource> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAsource> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAsource> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAsource> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<MNT_Menu_11111_RowViewModel>();

			CriteriaSet mnt_menu_11111Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("SOURCE.ACCOUNT_NUMBER", new OrderedDictionary());
			allSortOrders["SOURCE.ACCOUNT_NUMBER"].Add("SOURCE.ACCOUNT_NUMBER", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "source", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAsource.FldAccount_number), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAsource.FldCodsource, CSGenioAsource.FldZzstate, CSGenioAsource.FldAccount_number, CSGenioAsource.FldTitle, CSGenioAsource.FldMember_id, CSGenioAmember.FldCodmember, CSGenioAmember.FldName, CSGenioAsource.FldBank, CSGenioAsource.FldBalance, CSGenioAsource.FldType };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("source", "account_number");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAsource model_limit_area = new CSGenioAsource(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML11111");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 2 Limit(s) detected.
			// Limit origin: menu 

			//Limit type: "DB"
			//Current Area = "SOURCE"
			//1st Area Limit: "MEMBER"
			//1st Area Field: "GROUP_ID"
			//1st Area Value: "group"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DB;
				limit.NaoAplicaSeNulo = false;
				CSGenioAmember model_limit_area = new CSGenioAmember(m_userContext.User);
				string limit_field = "group_id", limit_field_value = "group";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}
			// Limit origin: menu 

			//Limit type: "DB"
			//Current Area = "SOURCE"
			//1st Area Limit: "MEMBER"
			//1st Area Field: "CODMEMBER"
			//1st Area Value: "member"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DB;
				limit.NaoAplicaSeNulo = false;
				CSGenioAmember model_limit_area = new CSGenioAmember(m_userContext.User);
				string limit_field = "codmember", limit_field_value = "member";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(mnt_menu_11111Conds);
			mnt_menu_11111Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL MNT OVERRQ 11111]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAsource>(m_userContext, false, ref mnt_menu_11111Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML11111", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL MNT OVERRQLSTEXP 11111]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL MNT OVERRQLIST 11111]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_source");
				Navigation.DestroyEntry("QMVC_POS_RECORD_source");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAsource.GetInformation(), QMVC_POS_RECORD, sorts, mnt_menu_11111Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAsource> listing = Models.ModelBase.Where<CSGenioAsource>(m_userContext, distinct, mnt_menu_11111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML11111", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapMNT_Menu_11111(listing);

				Menu.Identifier = "ML11111";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML11111";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

				// Set table totalizers
				if (listing.Totalizers != null && listing.Totalizers.Count > 0)
					Menu.SetTotalizers(listing.Totalizers);
			}

			// Set table limits display property
			FillTableLimitsDisplayData();

			// Store table configuration so it gets sent to the client-side to be processed
			CurrentTableConfig = tableConfig;

			// Load the user table configuration names and default name
			LoadUserTableConfigNameProperties();
		}

		private List<MNT_Menu_11111_RowViewModel> MapMNT_Menu_11111(ListingMVC<CSGenioAsource> Qlisting)
		{
			List<MNT_Menu_11111_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapMNT_Menu_11111(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAsource row
		/// to a MNT_Menu_11111_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private MNT_Menu_11111_RowViewModel MapMNT_Menu_11111(CSGenioAsource row)
		{
			var model = new MNT_Menu_11111_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "source":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "member":
						model.Member.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAsource> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Source m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Source m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM MNT_MENU_11111]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Source", "Source.ValCodsource", "Source.ValZzstate", "Source.ValAccount_number", "Source.ValTitle", "Member", "Member.ValName", "Source.ValBank", "Source.ValBalance", "Source.ValType", "Source.ValMember_id"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValAccount_number", CSGenioAsource.FldAccount_number, typeof(string)),
			new TableSearchColumn("ValTitle", CSGenioAsource.FldTitle, typeof(string), defaultSearch : true),
			new TableSearchColumn("Member_ValName", CSGenioAmember.FldName, typeof(string)),
			new TableSearchColumn("ValBank", CSGenioAsource.FldBank, typeof(string), array : "Banks"),
			new TableSearchColumn("ValBalance", CSGenioAsource.FldBalance, typeof(decimal?)),
			new TableSearchColumn("ValType", CSGenioAsource.FldType, typeof(string), array : "Accout_Type"),
		];
	}
}
