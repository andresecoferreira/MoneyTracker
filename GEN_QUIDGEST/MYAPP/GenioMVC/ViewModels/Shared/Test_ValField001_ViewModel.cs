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

namespace GenioMVC.ViewModels
{
	public class Test_ValField001_ViewModel : MenuListViewModel<Models.Expense>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Test_ValField001_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "expense";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Test_ValField001";

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
// USE /[MANUAL MNT LIST_LIMITS TEST_PSEUDFIELD001]/

			return crs;
		}

		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public Test_ValField001_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Test_ValField001_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Test_ValField001_ViewModel(UserContext userContext) : base(userContext)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Test_ValField001_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Test_ValField001_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAcategory_type.FldName, FieldType.TEXT, Resources.Resources.CATEGORY18978, 20, 0, true),
				new Exports.QColumn(CSGenioAexpense.FldValue, FieldType.CURRENCY, Resources.Resources.VALUE10285, 12, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAexpense> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAexpense> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new TablePartial<Test_ValField001_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, true);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			if (!tableConfig.GroupFilters.ContainsKey("filter_ValField001_YEAR"))
			{
				string defaultValue = "";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_ValField001_YEAR", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_ValField001_YEAR_1 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValField001_YEAR"))
					filter_ValField001_YEAR_1 = tableConfig.GroupFilters["filter_ValField001_YEAR"].Contains("1");
				if (filter_ValField001_YEAR_1)
				{
					groupFilters.Equal(CSGenioAexpense.FldYear, 2024);

				}

				bool filter_ValField001_YEAR_2 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValField001_YEAR"))
					filter_ValField001_YEAR_2 = tableConfig.GroupFilters["filter_ValField001_YEAR"].Contains("2");
				if (filter_ValField001_YEAR_2)
				{
					groupFilters.Equal(CSGenioAexpense.FldYear, 2025);

				}

				bool filter_ValField001_YEAR_3 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValField001_YEAR"))
					filter_ValField001_YEAR_3 = tableConfig.GroupFilters["filter_ValField001_YEAR"].Contains("3");
				if (filter_ValField001_YEAR_3)
				{
					groupFilters.Equal(CSGenioAexpense.FldYear, 2026);

				}

				subfilters.SubSets.Add(groupFilters);
			}
			if (!tableConfig.GroupFilters.ContainsKey("filter_ValField001_MONTH"))
			{
				string defaultValue = "";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_ValField001_MONTH", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_ValField001_MONTH_1 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValField001_MONTH"))
					filter_ValField001_MONTH_1 = tableConfig.GroupFilters["filter_ValField001_MONTH"].Contains("1");
				if (filter_ValField001_MONTH_1)
				{
					groupFilters.Equal(CSGenioAexpense.FldMonth, 1);

				}

				bool filter_ValField001_MONTH_2 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValField001_MONTH"))
					filter_ValField001_MONTH_2 = tableConfig.GroupFilters["filter_ValField001_MONTH"].Contains("2");
				if (filter_ValField001_MONTH_2)
				{
					groupFilters.Equal(CSGenioAexpense.FldMonth, 2);

				}

				subfilters.SubSets.Add(groupFilters);
			}

			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Expense.AddEPH<CSGenioAexpense>(ref u, crs, "IBL_TEST____PSEUDFIELD001");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAexpense.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("EXPENSE", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAexpense.FldZzstate, CSGenioAexpense.FldCreated_by);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_expense");
				Navigation.DestroyEntry("QMVC_POS_RECORD_expense");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Expense.AddEPH<CSGenioAexpense>(ref u, null, "IBL_TEST____PSEUDFIELD001"));
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
			ListingMVC<CSGenioAexpense> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAexpense> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAexpense> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAexpense> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Test_ValField001_RowViewModel>();

			CriteriaSet test____pseudfield001Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "expense", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAexpense.FldCodexpense, CSGenioAexpense.FldZzstate, CSGenioAexpense.FldType_id, CSGenioAcategory_type.FldCodcategory_type, CSGenioAcategory_type.FldName, CSGenioAexpense.FldValue };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("category_type", "name");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAexpense model_limit_area = new CSGenioAexpense(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_TEST____PSEUDFIELD001");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(test____pseudfield001Conds);
			test____pseudfield001Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL MNT OVERRQ TEST_PSEUDFIELD001]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAexpense>(m_userContext, false, ref test____pseudfield001Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_TEST____PSEUDFIELD001", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL MNT OVERRQLSTEXP TEST_PSEUDFIELD001]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL MNT OVERRQLIST TEST_PSEUDFIELD001]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_expense");
				Navigation.DestroyEntry("QMVC_POS_RECORD_expense");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAexpense.GetInformation(), QMVC_POS_RECORD, sorts, test____pseudfield001Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAexpense> listing = Models.ModelBase.Where<CSGenioAexpense>(m_userContext, distinct, test____pseudfield001Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_TEST____PSEUDFIELD001", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapTest_ValField001(listing);

				Menu.Identifier = "IBL_TEST____PSEUDFIELD001";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_TEST____PSEUDFIELD001";

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

		private List<Test_ValField001_RowViewModel> MapTest_ValField001(ListingMVC<CSGenioAexpense> Qlisting)
		{
			List<Test_ValField001_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTest_ValField001(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAexpense row
		/// to a Test_ValField001_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Test_ValField001_RowViewModel MapTest_ValField001(CSGenioAexpense row)
		{
			var model = new Test_ValField001_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "expense":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "category_type":
						model.Category_type.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAexpense> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Expense m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Expense m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM TEST_VALFIELD001]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Expense", "Expense.ValCodexpense", "Expense.ValZzstate", "Category_type", "Category_type.ValName", "Expense.ValValue", "Expense.ValCategory_id", "Expense.ValType_id", "Expense.ValGroup_id", "Expense.ValMember_id", "Expense.ValSource_id"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Category_type_ValName", CSGenioAcategory_type.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValValue", CSGenioAexpense.FldValue, typeof(decimal?)),
		];
	}
}
