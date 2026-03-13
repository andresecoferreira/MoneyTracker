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
	public class Wd_catmonth_ValCatmonth_ViewModel : MenuListViewModel<Models.View_catmonth>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Wd_catmonth_ValCatmonth_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "view_catmonth";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Wd_catmonth_ValCatmonth";

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
// USE /[MANUAL MNT LIST_LIMITS WD_CATMONTH_PSEUDCATMONTH]/

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
		public Wd_catmonth_ValCatmonth_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Wd_catmonth_ValCatmonth_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Wd_catmonth_ValCatmonth_ViewModel(UserContext userContext) : base(userContext)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Wd_catmonth_ValCatmonth_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Wd_catmonth_ValCatmonth_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAview_catmonth.FldCategory_type, FieldType.TEXT, Resources.Resources.CATEGORY_TYPE34342, 30, 0, true),
				new Exports.QColumn(CSGenioAview_catmonth.FldYear, FieldType.NUMERIC, Resources.Resources.YEAR61794, 4, 0, true),
				new Exports.QColumn(CSGenioAview_catmonth.FldMonth, FieldType.ARRAY_NUMERIC, Resources.Resources.MONTH46035, 10, 0, true, "Month"),
				new Exports.QColumn(CSGenioAview_catmonth.FldTotal, FieldType.CURRENCY, Resources.Resources.TOTAL49307, 12, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAview_catmonth> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAview_catmonth> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new TablePartial<Wd_catmonth_ValCatmonth_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, true);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			if (!tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_YEAR"))
			{
				string defaultValue = "";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_ValCatmonth_YEAR", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_ValCatmonth_YEAR_1 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_YEAR"))
					filter_ValCatmonth_YEAR_1 = tableConfig.GroupFilters["filter_ValCatmonth_YEAR"].Contains("1");
				if (filter_ValCatmonth_YEAR_1)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldYear, 2024);

				}

				bool filter_ValCatmonth_YEAR_2 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_YEAR"))
					filter_ValCatmonth_YEAR_2 = tableConfig.GroupFilters["filter_ValCatmonth_YEAR"].Contains("2");
				if (filter_ValCatmonth_YEAR_2)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldYear, 2025);

				}

				bool filter_ValCatmonth_YEAR_3 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_YEAR"))
					filter_ValCatmonth_YEAR_3 = tableConfig.GroupFilters["filter_ValCatmonth_YEAR"].Contains("3");
				if (filter_ValCatmonth_YEAR_3)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldYear, 2026);

				}

				subfilters.SubSets.Add(groupFilters);
			}
			if (!tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
			{
				string defaultValue = "";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_ValCatmonth_MONTH", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_ValCatmonth_MONTH_1 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_1 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("1");
				if (filter_ValCatmonth_MONTH_1)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 1);

				}

				bool filter_ValCatmonth_MONTH_2 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_2 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("2");
				if (filter_ValCatmonth_MONTH_2)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 2);

				}

				bool filter_ValCatmonth_MONTH_3 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_3 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("3");
				if (filter_ValCatmonth_MONTH_3)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 3);

				}

				bool filter_ValCatmonth_MONTH_4 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_4 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("4");
				if (filter_ValCatmonth_MONTH_4)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 4);

				}

				bool filter_ValCatmonth_MONTH_5 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_5 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("5");
				if (filter_ValCatmonth_MONTH_5)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 5);

				}

				bool filter_ValCatmonth_MONTH_6 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_6 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("6");
				if (filter_ValCatmonth_MONTH_6)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 6);

				}

				bool filter_ValCatmonth_MONTH_7 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_7 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("7");
				if (filter_ValCatmonth_MONTH_7)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 7);

				}

				bool filter_ValCatmonth_MONTH_8 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_8 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("8");
				if (filter_ValCatmonth_MONTH_8)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 8);

				}

				bool filter_ValCatmonth_MONTH_9 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_9 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("9");
				if (filter_ValCatmonth_MONTH_9)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 9);

				}

				bool filter_ValCatmonth_MONTH_10 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_10 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("10");
				if (filter_ValCatmonth_MONTH_10)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 10);

				}

				bool filter_ValCatmonth_MONTH_11 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_11 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("11");
				if (filter_ValCatmonth_MONTH_11)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 11);

				}

				bool filter_ValCatmonth_MONTH_12 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValCatmonth_MONTH"))
					filter_ValCatmonth_MONTH_12 = tableConfig.GroupFilters["filter_ValCatmonth_MONTH"].Contains("12");
				if (filter_ValCatmonth_MONTH_12)
				{
					groupFilters.Equal(CSGenioAview_catmonth.FldMonth, 12);

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
				crs = Models.View_catmonth.AddEPH<CSGenioAview_catmonth>(ref u, crs, "IBL_WD_CATMONTH__PSEUD__CATMONTH");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAview_catmonth.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("VIEW_CATMONTH", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAview_catmonth.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_view_catmonth");
				Navigation.DestroyEntry("QMVC_POS_RECORD_view_catmonth");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.View_catmonth.AddEPH<CSGenioAview_catmonth>(ref u, null, "IBL_WD_CATMONTH__PSEUD__CATMONTH"));
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
			ListingMVC<CSGenioAview_catmonth> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAview_catmonth> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAview_catmonth> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAview_catmonth> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Wd_catmonth_ValCatmonth_RowViewModel>();

			CriteriaSet wd_catmonth__pseud__catmonthConds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "view_catmonth", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAview_catmonth.FldCodview_catmonth, CSGenioAview_catmonth.FldZzstate, CSGenioAview_catmonth.FldCategory_type, CSGenioAview_catmonth.FldYear, CSGenioAview_catmonth.FldMonth, CSGenioAview_catmonth.FldTotal };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("view_catmonth", "category_type");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAview_catmonth model_limit_area = new CSGenioAview_catmonth(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_WD_CATMONTH__PSEUD__CATMONTH");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(wd_catmonth__pseud__catmonthConds);
			wd_catmonth__pseud__catmonthConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL MNT OVERRQ WD_CATMONTH_PSEUDCATMONTH]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAview_catmonth>(m_userContext, false, ref wd_catmonth__pseud__catmonthConds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_WD_CATMONTH__PSEUD__CATMONTH", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL MNT OVERRQLSTEXP WD_CATMONTH_PSEUDCATMONTH]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL MNT OVERRQLIST WD_CATMONTH_PSEUDCATMONTH]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_view_catmonth");
				Navigation.DestroyEntry("QMVC_POS_RECORD_view_catmonth");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAview_catmonth.GetInformation(), QMVC_POS_RECORD, sorts, wd_catmonth__pseud__catmonthConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAview_catmonth> listing = Models.ModelBase.Where<CSGenioAview_catmonth>(m_userContext, distinct, wd_catmonth__pseud__catmonthConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_WD_CATMONTH__PSEUD__CATMONTH", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapWd_catmonth_ValCatmonth(listing);

				Menu.Identifier = "IBL_WD_CATMONTH__PSEUD__CATMONTH";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_WD_CATMONTH__PSEUD__CATMONTH";

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

		private List<Wd_catmonth_ValCatmonth_RowViewModel> MapWd_catmonth_ValCatmonth(ListingMVC<CSGenioAview_catmonth> Qlisting)
		{
			List<Wd_catmonth_ValCatmonth_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWd_catmonth_ValCatmonth(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAview_catmonth row
		/// to a Wd_catmonth_ValCatmonth_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Wd_catmonth_ValCatmonth_RowViewModel MapWd_catmonth_ValCatmonth(CSGenioAview_catmonth row)
		{
			var model = new Wd_catmonth_ValCatmonth_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "view_catmonth":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAview_catmonth> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.View_catmonth m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.View_catmonth m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM WD_CATMONTH_VALCATMONTH]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"View_catmonth", "View_catmonth.ValCodview_catmonth", "View_catmonth.ValZzstate", "View_catmonth.ValCategory_type", "View_catmonth.ValYear", "View_catmonth.ValMonth", "View_catmonth.ValTotal"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValCategory_type", CSGenioAview_catmonth.FldCategory_type, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValYear", CSGenioAview_catmonth.FldYear, typeof(decimal?)),
			new TableSearchColumn("ValMonth", CSGenioAview_catmonth.FldMonth, typeof(decimal), array : "Month"),
			new TableSearchColumn("ValTotal", CSGenioAview_catmonth.FldTotal, typeof(decimal?)),
		];
	}
}
