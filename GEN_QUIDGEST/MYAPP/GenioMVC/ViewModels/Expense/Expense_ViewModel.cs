using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Expense
{
	public class Expense_ViewModel : FormViewModel<Models.Expense>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Category" | Type: "CE"
		/// </summary>
		public string ValCategory_id { get; set; }
		/// <summary>
		/// Title: "Category Type" | Type: "CE"
		/// </summary>
		public string ValType_id { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValGroup_id { get; set; }
		/// <summary>
		/// Title: "Member" | Type: "CE"
		/// </summary>
		public string ValMember_id { get; set; }
		/// <summary>
		/// Title: "Account" | Type: "CE"
		/// </summary>
		public string ValSource_id { get; set; }

		#endregion
		/// <summary>
		/// Title: "ID" | Type: "N"
		/// </summary>
		public decimal? ValExpense_id { get; set; }
		/// <summary>
		/// Title: "Category Type" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Category_type> TableCategory_typeName { get; set; }
		/// <summary>
		/// Title: "Category" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Category> TableCategoryName { get; set; }
		/// <summary>
		/// Title: "Member" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Member> TableMemberName { get; set; }
		/// <summary>
		/// Title: "Group" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string GroupValName
		{
			get
			{
				return funcGroupValName != null ? funcGroupValName() : _auxGroupValName;
			}
			set { funcGroupValName = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcGroupValName { get; set; }

		private string _auxGroupValName { get; set; }
		/// <summary>
		/// Title: "Account" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Source> TableSourceTitle { get; set; }
		/// <summary>
		/// Title: "Value" | Type: "$"
		/// </summary>
		public decimal? ValValue { get; set; }
		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "Month" | Type: "AN"
		/// </summary>
		[ValidateSetAccess]
		public decimal ValMonth { get; set; }
		/// <summary>
		/// Title: "Year" | Type: "AN"
		/// </summary>
		[ValidateSetAccess]
		public decimal ValYear { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "C"
		/// </summary>
		public string ValDescription { get; set; }
		/// <summary>
		/// Title: "Invoice" | Type: "IB"
		/// </summary>
		[Document("ValInvoice", false, false, false, DocumentViewTypeMode.Preview)]
		public string ValInvoice { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValInvoicefk { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValInvoicePropertiesVM { get; set; }
		/// <summary>
		/// Title: "Created By" | Type: "ON"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreated_by { get; set; }
		/// <summary>
		/// Title: "Created At" | Type: "OD"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreated_at { get; set; }
		/// <summary>
		/// Title: "Updated By" | Type: "EN"
		/// </summary>
		[ValidateSetAccess]
		public string ValUpdated_by { get; set; }
		/// <summary>
		/// Title: "Updated At" | Type: "ED"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValUpdated_at { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodexpense { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Expense_ViewModel() : base(null!) { }

		public Expense_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FEXPENSE", nestedForm) { }

		public Expense_ViewModel(UserContext userContext, Models.Expense row, bool nestedForm = false) : base(userContext, "FEXPENSE", row, nestedForm) { }

		public Expense_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("expense", id);
			Model = Models.Expense.Find(id, userContext, "FEXPENSE", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_50;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_50;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Expense model = new Models.Expense(userContext) { Identifier = "FEXPENSE" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FEXPENSE");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Expense m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Expense) to ViewModel (Expense) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCategory_id = ViewModelConversion.ToString(m.ValCategory_id);
				ValType_id = ViewModelConversion.ToString(m.ValType_id);
				ValGroup_id = ViewModelConversion.ToString(m.ValGroup_id);
				ValMember_id = ViewModelConversion.ToString(m.ValMember_id);
				ValSource_id = ViewModelConversion.ToString(m.ValSource_id);
				ValExpense_id = ViewModelConversion.ToNumeric(m.ValExpense_id);
				funcGroupValName = () => ViewModelConversion.ToString(m.Group.ValName);
				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValMonth = ViewModelConversion.ToNumeric(m.ValMonth);
				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
				ValDescription = ViewModelConversion.ToString(m.ValDescription);
				ValInvoice = ViewModelConversion.ToString(m.ValInvoice);
				ValInvoicefk = ViewModelConversion.ToString(m.ValInvoicefk);
				ValCreated_by = ViewModelConversion.ToString(m.ValCreated_by);
				ValCreated_at = ViewModelConversion.ToDateTime(m.ValCreated_at);
				ValUpdated_by = ViewModelConversion.ToString(m.ValUpdated_by);
				ValUpdated_at = ViewModelConversion.ToDateTime(m.ValUpdated_at);
				ValCodexpense = ViewModelConversion.ToString(m.ValCodexpense);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Expense) to ViewModel (Expense) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Expense m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Expense) to Model (Expense) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCategory_id = ViewModelConversion.ToString(ValCategory_id);
				m.ValType_id = ViewModelConversion.ToString(ValType_id);
				m.ValGroup_id = ViewModelConversion.ToString(ValGroup_id);
				m.ValMember_id = ViewModelConversion.ToString(ValMember_id);
				m.ValSource_id = ViewModelConversion.ToString(ValSource_id);
				// Block When condition(s)
				if (HasDisabledUserValuesSecurity || !(Logical)(true))
				{
					m.ValExpense_id = ViewModelConversion.ToNumeric(ValExpense_id);
				}
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDescription = ViewModelConversion.ToString(ValDescription);
				m.ValInvoice = ViewModelConversion.ToString(ValInvoice);
				m.ValInvoicefk = ViewModelConversion.ToString(ValInvoicefk);
				m.ValCodexpense = ViewModelConversion.ToString(ValCodexpense);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValMonth = ViewModelConversion.ToNumeric(ValMonth);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValCreated_by = ViewModelConversion.ToString(ValCreated_by);
				m.ValCreated_at = ViewModelConversion.ToDateTime(ValCreated_at);
				m.ValUpdated_by = ViewModelConversion.ToString(ValUpdated_by);
				m.ValUpdated_at = ViewModelConversion.ToDateTime(ValUpdated_at);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Expense) to Model (Expense) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "expense.category_id":
						this.ValCategory_id = ViewModelConversion.ToString(_value);
						break;
					case "expense.type_id":
						this.ValType_id = ViewModelConversion.ToString(_value);
						break;
					case "expense.group_id":
						this.ValGroup_id = ViewModelConversion.ToString(_value);
						break;
					case "expense.member_id":
						this.ValMember_id = ViewModelConversion.ToString(_value);
						break;
					case "expense.source_id":
						this.ValSource_id = ViewModelConversion.ToString(_value);
						break;
					case "expense.expense_id":
						this.ValExpense_id = ViewModelConversion.ToNumeric(_value);
						break;
					case "expense.value":
						this.ValValue = ViewModelConversion.ToNumeric(_value);
						break;
					case "expense.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "expense.description":
						this.ValDescription = ViewModelConversion.ToString(_value);
						break;
					case "expense.invoice":
						this.ValInvoice = ViewModelConversion.ToString(_value);
						break;
					case "expense.codexpense":
						this.ValCodexpense = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Expense) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Expense)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Expense.Find(id ?? Navigation.GetStrValue("expense"), m_userContext, "FEXPENSE"); }
			finally { Model ??= new Models.Expense(m_userContext) { Identifier = "FEXPENSE" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Expense.Find(Navigation.GetStrValue("expense"), m_userContext, "FEXPENSE");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FEXPENSE";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}
		
		protected override void LoadDocumentsProperties(Models.Expense row)
		{
			try
			{
				ValInvoicePropertiesVM = row.GetInfoDoc("ValInvoice");
			}
			catch (Exception)
			{
				ValInvoicePropertiesVM = new DocumsProperties_ViewModel(m_userContext);
			}
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Expense.Find(Navigation.GetStrValue("expense"), m_userContext, "FEXPENSE");
				if (Model == null)
				{
					Model = new Models.Expense(m_userContext) { Identifier = "FEXPENSE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("expense");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Expense__category_type__name(qs, lazyLoad);
			Load_Expense__category__name(qs, lazyLoad);
			Load_Expense__member__name(qs, lazyLoad);
			Load_Expense__source__title(qs, lazyLoad);

// USE /[MANUAL MNT VIEWMODEL_LOADPARTIAL EXPENSE]/
		}

// USE /[MANUAL MNT VIEWMODEL_NEW EXPENSE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValCategory_id", Resources.Resources.CATEGORY18978, ViewModelConversion.ToString(ValCategory_id), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValType_id", Resources.Resources.CATEGORY_TYPE34342, ViewModelConversion.ToString(ValType_id), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValMember_id", Resources.Resources.MEMBER00534, ViewModelConversion.ToString(ValMember_id), FieldType.KEY_INT.GetFormatting());
			validator.StringLength("GroupValName", Resources.Resources.GROUP38232, GroupValName, 50);

			validator.Required("ValValue", Resources.Resources.VALUE10285, ViewModelConversion.ToNumeric(ValValue), FieldType.CURRENCY.GetFormatting());

			validator.Required("ValDate", Resources.Resources.DATE18475, ViewModelConversion.ToDateTime(ValDate), FieldType.DATE.GetFormatting());
			validator.StringLength("ValDescription", Resources.Resources.DESCRIPTION07383, ValDescription, 200);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL MNT VIEWMODEL_SAVE EXPENSE]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL MNT VIEWMODEL_APPLY EXPENSE]/

// USE /[MANUAL MNT VIEWMODEL_DUPLICATE EXPENSE]/

// USE /[MANUAL MNT VIEWMODEL_DESTROY EXPENSE]/
		public override void Destroy(string id)
		{
			Model = Models.Expense.Find(id, m_userContext, "FEXPENSE");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TableCategory_typeName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Expense__category_type__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool expense__category_type__nameDoLoad = true;
			CriteriaSet expense__category_type__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("category_type", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					expense__category_type__nameConds.Equal(CSGenioAcategory_type.FldCodcategory_type, hValue);
					this.ValType_id = DBConversion.ToString(hValue);
				}
			}

			TableCategory_typeName = new TableDBEdit<Models.Category_type>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_category_type") != null)
				{
					this.ValType_id = Navigation.GetStrValue("RETURN_category_type");
					Navigation.CurrentLevel.SetEntry("RETURN_category_type", null);
				}
				FillDependant_ExpenseTableCategory_typeName(lazyLoad);
				return;
			}

			if (expense__category_type__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCategory_typeName, "sTableCategory_typeName", "dTableCategory_typeName", qs, "category_type");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcategory_type.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCategory_typeName_tableFilters"]))
					TableCategory_typeName.TableFilters = bool.Parse(qs["TableCategory_typeName_tableFilters"]);
				else
					TableCategory_typeName.TableFilters = false;

				query = qs["qTableCategory_typeName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcategory_type.FldName, query + "%");
				}
				expense__category_type__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCategory_typeName"] != null ? qs["pTableCategory_typeName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcategory_type.FldCodcategory_type, CSGenioAcategory_type.FldName, CSGenioAcategory_type.FldZzstate];

// USE /[MANUAL MNT OVERRQ EXPENSE_CATEGORY_TYPENAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("category_type", FormMode.New) || Navigation.checkFormMode("category_type", FormMode.Duplicate))
					expense__category_type__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcategory_type.FldZzstate, 0)
						.Equal(CSGenioAcategory_type.FldCodcategory_type, Navigation.GetStrValue("category_type")));
				else
					expense__category_type__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcategory_type.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("category_type", "name");
				ListingMVC<CSGenioAcategory_type> listing = Models.ModelBase.Where<CSGenioAcategory_type>(m_userContext, false, expense__category_type__nameConds, fields, offset, numberItems, sorts, "LED_EXPENSE__CATEGORY_TYPE__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCategory_typeName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCategory_typeName.Query = query;
				TableCategory_typeName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Category_type(m_userContext, r, true, _fieldsToSerialize_EXPENSE__CATEGORY_TYPE__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_category_type") != null)
				{
					this.ValType_id = Navigation.GetStrValue("RETURN_category_type");
					Navigation.CurrentLevel.SetEntry("RETURN_category_type", null);
				}

				TableCategory_typeName.List = new SelectList(TableCategory_typeName.Elements.ToSelectList(x => x.ValName, x => x.ValCodcategory_type,  x => x.ValCodcategory_type == this.ValType_id), "Value", "Text", this.ValType_id);
				//Seleciona se só um
				if (TableCategory_typeName.List != null && TableCategory_typeName.List.Count() == 1)
				{
					this.ValType_id = TableCategory_typeName.List.First().Value;
					Navigation.SetValue("category_type", this.ValType_id);
				}
				FillDependant_ExpenseTableCategory_typeName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCategory_typeName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Category_type</param>
		public ConcurrentDictionary<string, object> GetDependant_ExpenseTableCategory_typeName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcategory_type.FldCodcategory_type, CSGenioAcategory_type.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAcategory_type tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcategory_type.FldCodcategory_type, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCategory_typeName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ExpenseTableCategory_typeName(bool lazyLoad = false)
		{
			var row = GetDependant_ExpenseTableCategory_typeName(this.ValType_id);
			try
			{

				// Fill List fields
				this.ValType_id = ViewModelConversion.ToString(row["category_type.codcategory_type"]);
				TableCategory_typeName.Value = (string)row["category_type.name"];
				if (GenFunctions.emptyG(this.ValType_id) == 1)
				{
					this.ValType_id = "";
					TableCategory_typeName.Value = "";
					Navigation.ClearValue("category_type");
				}
				else if (lazyLoad)
				{
					TableCategory_typeName.SetPagination(1, 0, false, false, 1);
					TableCategory_typeName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValType_id),
							Text = Convert.ToString(TableCategory_typeName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValType_id);
				}

				TableCategory_typeName.Selected = this.ValType_id;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCategory_typeName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EXPENSE__CATEGORY_TYPE__NAME = ["Category_type", "Category_type.ValCodcategory_type", "Category_type.ValZzstate", "Category_type.ValName"];

		/// <summary>
		/// TableCategoryName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Expense__category__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool expense__category__nameDoLoad = true;
			CriteriaSet expense__category__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("category", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					expense__category__nameConds.Equal(CSGenioAcategory.FldCodcategory, hValue);
					this.ValCategory_id = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			expense__category__nameDoLoad &= AddCriteriaAreaLimit(expense__category__nameConds, CSGenio.business.CSGenioAcategory_type.FldCodcategory_type, "category_type", this.ValType_id, true);

			TableCategoryName = new TableDBEdit<Models.Category>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_category") != null)
				{
					this.ValCategory_id = Navigation.GetStrValue("RETURN_category");
					Navigation.CurrentLevel.SetEntry("RETURN_category", null);
				}
				FillDependant_ExpenseTableCategoryName(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValType_id))
				expense__category__nameDoLoad = false;

			if (expense__category__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCategoryName, "sTableCategoryName", "dTableCategoryName", qs, "category");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcategory.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCategoryName_tableFilters"]))
					TableCategoryName.TableFilters = bool.Parse(qs["TableCategoryName_tableFilters"]);
				else
					TableCategoryName.TableFilters = false;

				query = qs["qTableCategoryName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcategory.FldName, query + "%");
				}
				expense__category__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCategoryName"] != null ? qs["pTableCategoryName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcategory.FldCodcategory, CSGenioAcategory.FldName, CSGenioAcategory.FldZzstate];

// USE /[MANUAL MNT OVERRQ EXPENSE_CATEGORYNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("category", FormMode.New) || Navigation.checkFormMode("category", FormMode.Duplicate))
					expense__category__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcategory.FldZzstate, 0)
						.Equal(CSGenioAcategory.FldCodcategory, Navigation.GetStrValue("category")));
				else
					expense__category__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcategory.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("category", "name");
				ListingMVC<CSGenioAcategory> listing = Models.ModelBase.Where<CSGenioAcategory>(m_userContext, false, expense__category__nameConds, fields, offset, numberItems, sorts, "LED_EXPENSE__CATEGORY__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCategoryName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCategoryName.Query = query;
				TableCategoryName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Category(m_userContext, r, true, _fieldsToSerialize_EXPENSE__CATEGORY__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_category") != null)
				{
					this.ValCategory_id = Navigation.GetStrValue("RETURN_category");
					Navigation.CurrentLevel.SetEntry("RETURN_category", null);
				}

				TableCategoryName.List = new SelectList(TableCategoryName.Elements.ToSelectList(x => x.ValName, x => x.ValCodcategory,  x => x.ValCodcategory == this.ValCategory_id), "Value", "Text", this.ValCategory_id);
				//Seleciona se só um
				if (TableCategoryName.List != null && TableCategoryName.List.Count() == 1)
				{
					this.ValCategory_id = TableCategoryName.List.First().Value;
					Navigation.SetValue("category", this.ValCategory_id);
				}
				FillDependant_ExpenseTableCategoryName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCategoryName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Category</param>
		public ConcurrentDictionary<string, object> GetDependant_ExpenseTableCategoryName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcategory.FldCodcategory, CSGenioAcategory.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("category_type");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAcategory.FldType_id, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAcategory tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcategory.FldCodcategory, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCategoryName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ExpenseTableCategoryName(bool lazyLoad = false)
		{
			var row = GetDependant_ExpenseTableCategoryName(this.ValCategory_id);
			try
			{

				// Fill List fields
				this.ValCategory_id = ViewModelConversion.ToString(row["category.codcategory"]);
				TableCategoryName.Value = (string)row["category.name"];
				if (GenFunctions.emptyG(this.ValCategory_id) == 1)
				{
					this.ValCategory_id = "";
					TableCategoryName.Value = "";
					Navigation.ClearValue("category");
				}
				else if (lazyLoad)
				{
					TableCategoryName.SetPagination(1, 0, false, false, 1);
					TableCategoryName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCategory_id),
							Text = Convert.ToString(TableCategoryName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCategory_id);
				}

				TableCategoryName.Selected = this.ValCategory_id;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCategoryName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EXPENSE__CATEGORY__NAME = ["Category", "Category.ValCodcategory", "Category.ValZzstate", "Category.ValName"];

		/// <summary>
		/// TableMemberName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Expense__member__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool expense__member__nameDoLoad = true;
			CriteriaSet expense__member__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("member", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					expense__member__nameConds.Equal(CSGenioAmember.FldCodmember, hValue);
					this.ValMember_id = DBConversion.ToString(hValue);
				}
			}

			TableMemberName = new TableDBEdit<Models.Member>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_member") != null)
				{
					this.ValMember_id = Navigation.GetStrValue("RETURN_member");
					Navigation.CurrentLevel.SetEntry("RETURN_member", null);
				}
				FillDependant_ExpenseTableMemberName(lazyLoad);
				return;
			}

			if (expense__member__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableMemberName, "sTableMemberName", "dTableMemberName", qs, "member");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAmember.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableMemberName_tableFilters"]))
					TableMemberName.TableFilters = bool.Parse(qs["TableMemberName_tableFilters"]);
				else
					TableMemberName.TableFilters = false;

				query = qs["qTableMemberName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAmember.FldName, query + "%");
				}
				expense__member__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableMemberName"] != null ? qs["pTableMemberName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAmember.FldCodmember, CSGenioAmember.FldName, CSGenioAmember.FldZzstate];

// USE /[MANUAL MNT OVERRQ EXPENSE_MEMBERNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("member", FormMode.New) || Navigation.checkFormMode("member", FormMode.Duplicate))
					expense__member__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAmember.FldZzstate, 0)
						.Equal(CSGenioAmember.FldCodmember, Navigation.GetStrValue("member")));
				else
					expense__member__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAmember.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("member", "name");
				ListingMVC<CSGenioAmember> listing = Models.ModelBase.Where<CSGenioAmember>(m_userContext, false, expense__member__nameConds, fields, offset, numberItems, sorts, "LED_EXPENSE__MEMBER__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableMemberName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableMemberName.Query = query;
				TableMemberName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Member(m_userContext, r, true, _fieldsToSerialize_EXPENSE__MEMBER__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_member") != null)
				{
					this.ValMember_id = Navigation.GetStrValue("RETURN_member");
					Navigation.CurrentLevel.SetEntry("RETURN_member", null);
				}

				TableMemberName.List = new SelectList(TableMemberName.Elements.ToSelectList(x => x.ValName, x => x.ValCodmember,  x => x.ValCodmember == this.ValMember_id), "Value", "Text", this.ValMember_id);
				//Seleciona se só um
				if (TableMemberName.List != null && TableMemberName.List.Count() == 1)
				{
					this.ValMember_id = TableMemberName.List.First().Value;
					Navigation.SetValue("member", this.ValMember_id);
				}
				FillDependant_ExpenseTableMemberName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableMemberName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Member</param>
		public ConcurrentDictionary<string, object> GetDependant_ExpenseTableMemberName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAmember.FldCodmember, CSGenioAmember.FldName, CSGenioAgroup.FldCodgroup, CSGenioAgroup.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAmember tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAmember.FldCodmember, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableMemberName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ExpenseTableMemberName(bool lazyLoad = false)
		{
			var row = GetDependant_ExpenseTableMemberName(this.ValMember_id);
			try
			{
				this.ValGroup_id = (string)row["group.codgroup"];
				this.funcGroupValName = () => (string)row["group.name"];

				// Fill List fields
				this.ValMember_id = ViewModelConversion.ToString(row["member.codmember"]);
				TableMemberName.Value = (string)row["member.name"];
				if (GenFunctions.emptyG(this.ValMember_id) == 1)
				{
					this.ValMember_id = "";
					TableMemberName.Value = "";
					Navigation.ClearValue("member");
				}
				else if (lazyLoad)
				{
					TableMemberName.SetPagination(1, 0, false, false, 1);
					TableMemberName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValMember_id),
							Text = Convert.ToString(TableMemberName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValMember_id);
				}

				TableMemberName.Selected = this.ValMember_id;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableMemberName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EXPENSE__MEMBER__NAME = ["Member", "Member.ValCodmember", "Member.ValZzstate", "Member.ValName"];

		/// <summary>
		/// TableSourceTitle -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Expense__source__title(NameValueCollection qs, bool lazyLoad = false)
		{
			bool expense__source__titleDoLoad = true;
			CriteriaSet expense__source__titleConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("source", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					expense__source__titleConds.Equal(CSGenioAsource.FldCodsource, hValue);
					this.ValSource_id = DBConversion.ToString(hValue);
				}
			}

			TableSourceTitle = new TableDBEdit<Models.Source>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_source") != null)
				{
					this.ValSource_id = Navigation.GetStrValue("RETURN_source");
					Navigation.CurrentLevel.SetEntry("RETURN_source", null);
				}
				FillDependant_ExpenseTableSourceTitle(lazyLoad);
				return;
			}

			if (expense__source__titleDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableSourceTitle, "sTableSourceTitle", "dTableSourceTitle", qs, "source");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAsource.FldTitle), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableSourceTitle_tableFilters"]))
					TableSourceTitle.TableFilters = bool.Parse(qs["TableSourceTitle_tableFilters"]);
				else
					TableSourceTitle.TableFilters = false;

				query = qs["qTableSourceTitle"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAsource.FldTitle, query + "%");
				}
				expense__source__titleConds.SubSet(search_filters);

				string tryParsePage = qs["pTableSourceTitle"] != null ? qs["pTableSourceTitle"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAsource.FldCodsource, CSGenioAsource.FldTitle, CSGenioAsource.FldZzstate];

// USE /[MANUAL MNT OVERRQ EXPENSE_SOURCETITLE]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("source", FormMode.New) || Navigation.checkFormMode("source", FormMode.Duplicate))
					expense__source__titleConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAsource.FldZzstate, 0)
						.Equal(CSGenioAsource.FldCodsource, Navigation.GetStrValue("source")));
				else
					expense__source__titleConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAsource.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("source", "title");
				ListingMVC<CSGenioAsource> listing = Models.ModelBase.Where<CSGenioAsource>(m_userContext, false, expense__source__titleConds, fields, offset, numberItems, sorts, "LED_EXPENSE__SOURCE__TITLE", true, false, firstVisibleColumn: firstVisibleColumn);

				TableSourceTitle.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableSourceTitle.Query = query;
				TableSourceTitle.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Source(m_userContext, r, true, _fieldsToSerialize_EXPENSE__SOURCE__TITLE));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_source") != null)
				{
					this.ValSource_id = Navigation.GetStrValue("RETURN_source");
					Navigation.CurrentLevel.SetEntry("RETURN_source", null);
				}

				TableSourceTitle.List = new SelectList(TableSourceTitle.Elements.ToSelectList(x => x.ValTitle, x => x.ValCodsource,  x => x.ValCodsource == this.ValSource_id), "Value", "Text", this.ValSource_id);
				//Seleciona se só um
				if (TableSourceTitle.List != null && TableSourceTitle.List.Count() == 1)
				{
					this.ValSource_id = TableSourceTitle.List.First().Value;
					Navigation.SetValue("source", this.ValSource_id);
				}
				FillDependant_ExpenseTableSourceTitle();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableSourceTitle (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Source</param>
		public ConcurrentDictionary<string, object> GetDependant_ExpenseTableSourceTitle(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAsource.FldCodsource, CSGenioAsource.FldTitle];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAsource tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAsource.FldCodsource, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableSourceTitle (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ExpenseTableSourceTitle(bool lazyLoad = false)
		{
			var row = GetDependant_ExpenseTableSourceTitle(this.ValSource_id);
			try
			{

				// Fill List fields
				this.ValSource_id = ViewModelConversion.ToString(row["source.codsource"]);
				TableSourceTitle.Value = (string)row["source.title"];
				if (GenFunctions.emptyG(this.ValSource_id) == 1)
				{
					this.ValSource_id = "";
					TableSourceTitle.Value = "";
					Navigation.ClearValue("source");
				}
				else if (lazyLoad)
				{
					TableSourceTitle.SetPagination(1, 0, false, false, 1);
					TableSourceTitle.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValSource_id),
							Text = Convert.ToString(TableSourceTitle.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValSource_id);
				}

				TableSourceTitle.Selected = this.ValSource_id;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableSourceTitle): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EXPENSE__SOURCE__TITLE = ["Source", "Source.ValCodsource", "Source.ValZzstate", "Source.ValTitle"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"expense.category_id" => ViewModelConversion.ToString(modelValue),
				"expense.type_id" => ViewModelConversion.ToString(modelValue),
				"expense.group_id" => ViewModelConversion.ToString(modelValue),
				"expense.member_id" => ViewModelConversion.ToString(modelValue),
				"expense.source_id" => ViewModelConversion.ToString(modelValue),
				"expense.expense_id" => ViewModelConversion.ToNumeric(modelValue),
				"group.name" => ViewModelConversion.ToString(modelValue),
				"expense.value" => ViewModelConversion.ToNumeric(modelValue),
				"expense.date" => ViewModelConversion.ToDateTime(modelValue),
				"expense.month" => ViewModelConversion.ToNumeric(modelValue),
				"expense.year" => ViewModelConversion.ToNumeric(modelValue),
				"expense.description" => ViewModelConversion.ToString(modelValue),
				"expense.invoice" => ViewModelConversion.ToString(modelValue),
				"expense.created_by" => ViewModelConversion.ToString(modelValue),
				"expense.created_at" => ViewModelConversion.ToDateTime(modelValue),
				"expense.updated_by" => ViewModelConversion.ToString(modelValue),
				"expense.updated_at" => ViewModelConversion.ToDateTime(modelValue),
				"expense.codexpense" => ViewModelConversion.ToString(modelValue),
				"category_type.codcategory_type" => ViewModelConversion.ToString(modelValue),
				"category_type.name" => ViewModelConversion.ToString(modelValue),
				"category.codcategory" => ViewModelConversion.ToString(modelValue),
				"category.name" => ViewModelConversion.ToString(modelValue),
				"member.codmember" => ViewModelConversion.ToString(modelValue),
				"member.name" => ViewModelConversion.ToString(modelValue),
				"group.codgroup" => ViewModelConversion.ToString(modelValue),
				"source.codsource" => ViewModelConversion.ToString(modelValue),
				"source.title" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM EXPENSE]/

		#endregion
	}
}
