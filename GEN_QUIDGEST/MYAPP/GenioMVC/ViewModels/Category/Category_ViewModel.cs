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

namespace GenioMVC.ViewModels.Category
{
	public class Category_ViewModel : FormViewModel<Models.Category>, IPreparableForSerialization
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
		/// Title: "Type" | Type: "CE"
		/// </summary>
		public string ValType_id { get; set; }

		#endregion
		/// <summary>
		/// Title: "Type" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Category_type> TableCategory_typeName { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "C"
		/// </summary>
		public string ValDescription { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodcategory { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Category_ViewModel() : base(null!) { }

		public Category_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCATEGORY", nestedForm) { }

		public Category_ViewModel(UserContext userContext, Models.Category row, bool nestedForm = false) : base(userContext, "FCATEGORY", row, nestedForm) { }

		public Category_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("category", id);
			Model = Models.Category.Find(id, userContext, "FCATEGORY", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ADMINISTRATION;
			this.RoleToEdit = CSGenio.framework.Role.ADMINISTRATION;
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
			Models.Category model = new Models.Category(userContext) { Identifier = "FCATEGORY" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FCATEGORY");
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
		public override void MapFromModel(Models.Category m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Category) to ViewModel (Category) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValType_id = ViewModelConversion.ToString(m.ValType_id);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValDescription = ViewModelConversion.ToString(m.ValDescription);
				ValCodcategory = ViewModelConversion.ToString(m.ValCodcategory);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Category) to ViewModel (Category) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Category m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Category) to Model (Category) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValType_id = ViewModelConversion.ToString(ValType_id);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDescription = ViewModelConversion.ToString(ValDescription);
				m.ValCodcategory = ViewModelConversion.ToString(ValCodcategory);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Category) to Model (Category) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "category.type_id":
						this.ValType_id = ViewModelConversion.ToString(_value);
						break;
					case "category.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "category.description":
						this.ValDescription = ViewModelConversion.ToString(_value);
						break;
					case "category.codcategory":
						this.ValCodcategory = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Category) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Category)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Category.Find(id ?? Navigation.GetStrValue("category"), m_userContext, "FCATEGORY"); }
			finally { Model ??= new Models.Category(m_userContext) { Identifier = "FCATEGORY" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Category.Find(Navigation.GetStrValue("category"), m_userContext, "FCATEGORY");
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

			Model.Identifier = "FCATEGORY";
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
		
		protected override void LoadDocumentsProperties(Models.Category row)
		{
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
				Model = Models.Category.Find(Navigation.GetStrValue("category"), m_userContext, "FCATEGORY");
				if (Model == null)
				{
					Model = new Models.Category(m_userContext) { Identifier = "FCATEGORY" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("category");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Category__category_type__name(qs, lazyLoad);

// USE /[MANUAL MNT VIEWMODEL_LOADPARTIAL CATEGORY]/
		}

// USE /[MANUAL MNT VIEWMODEL_NEW CATEGORY]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValType_id", Resources.Resources.TYPE00312, ViewModelConversion.ToString(ValType_id), FieldType.KEY_INT.GetFormatting());
			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 20);

			validator.Required("ValName", Resources.Resources.NAME31974, ViewModelConversion.ToString(ValName), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValDescription", Resources.Resources.DESCRIPTION07383, ValDescription, 80);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL MNT VIEWMODEL_SAVE CATEGORY]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL MNT VIEWMODEL_APPLY CATEGORY]/

// USE /[MANUAL MNT VIEWMODEL_DUPLICATE CATEGORY]/

// USE /[MANUAL MNT VIEWMODEL_DESTROY CATEGORY]/
		public override void Destroy(string id)
		{
			Model = Models.Category.Find(id, m_userContext, "FCATEGORY");
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
		public void Load_Category__category_type__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool category__category_type__nameDoLoad = true;
			CriteriaSet category__category_type__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("category_type", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					category__category_type__nameConds.Equal(CSGenioAcategory_type.FldCodcategory_type, hValue);
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
				FillDependant_CategoryTableCategory_typeName(lazyLoad);
				return;
			}

			if (category__category_type__nameDoLoad)
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
				category__category_type__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCategory_typeName"] != null ? qs["pTableCategory_typeName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcategory_type.FldCodcategory_type, CSGenioAcategory_type.FldName, CSGenioAcategory_type.FldZzstate];

// USE /[MANUAL MNT OVERRQ CATEGORY_CATEGORY_TYPENAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("category_type", FormMode.New) || Navigation.checkFormMode("category_type", FormMode.Duplicate))
					category__category_type__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcategory_type.FldZzstate, 0)
						.Equal(CSGenioAcategory_type.FldCodcategory_type, Navigation.GetStrValue("category_type")));
				else
					category__category_type__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcategory_type.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("category_type", "name");
				ListingMVC<CSGenioAcategory_type> listing = Models.ModelBase.Where<CSGenioAcategory_type>(m_userContext, false, category__category_type__nameConds, fields, offset, numberItems, sorts, "LED_CATEGORY__CATEGORY_TYPE__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCategory_typeName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCategory_typeName.Query = query;
				TableCategory_typeName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Category_type(m_userContext, r, true, _fieldsToSerialize_CATEGORY__CATEGORY_TYPE__NAME));

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
				FillDependant_CategoryTableCategory_typeName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCategory_typeName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Category_type</param>
		public ConcurrentDictionary<string, object> GetDependant_CategoryTableCategory_typeName(string PKey)
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
		public void FillDependant_CategoryTableCategory_typeName(bool lazyLoad = false)
		{
			var row = GetDependant_CategoryTableCategory_typeName(this.ValType_id);
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

		private readonly string[] _fieldsToSerialize_CATEGORY__CATEGORY_TYPE__NAME = ["Category_type", "Category_type.ValCodcategory_type", "Category_type.ValZzstate", "Category_type.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"category.type_id" => ViewModelConversion.ToString(modelValue),
				"category.name" => ViewModelConversion.ToString(modelValue),
				"category.description" => ViewModelConversion.ToString(modelValue),
				"category.codcategory" => ViewModelConversion.ToString(modelValue),
				"category_type.codcategory_type" => ViewModelConversion.ToString(modelValue),
				"category_type.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM CATEGORY]/

		#endregion
	}
}
