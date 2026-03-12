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

namespace GenioMVC.ViewModels.Group_psw
{
	public class Group_psw_ViewModel : FormViewModel<Models.Group_psw>, IPreparableForSerialization
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
		/// Title: "Group" | Type: "CE"
		/// </summary>
		public string ValGroup_id { get; set; }
		/// <summary>
		/// Title: "User" | Type: "CE"
		/// </summary>
		public string ValCodpsw { get; set; }

		#endregion
		/// <summary>
		/// Title: "Group" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Group> TableGroupName { get; set; }
		/// <summary>
		/// Title: "User" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Psw> TablePswNome { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodgroup_psw { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Group_psw_ViewModel() : base(null!) { }

		public Group_psw_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FGROUP_PSW", nestedForm) { }

		public Group_psw_ViewModel(UserContext userContext, Models.Group_psw row, bool nestedForm = false) : base(userContext, "FGROUP_PSW", row, nestedForm) { }

		public Group_psw_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("group_psw", id);
			Model = Models.Group_psw.Find(id, userContext, "FGROUP_PSW", fieldsToQuery: fieldsToLoad);
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
			Models.Group_psw model = new Models.Group_psw(userContext) { Identifier = "FGROUP_PSW" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FGROUP_PSW");
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
		public override void MapFromModel(Models.Group_psw m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Group_psw) to ViewModel (Group_psw) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValGroup_id = ViewModelConversion.ToString(m.ValGroup_id);
				ValCodpsw = ViewModelConversion.ToString(m.ValCodpsw);
				ValCodgroup_psw = ViewModelConversion.ToString(m.ValCodgroup_psw);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Group_psw) to ViewModel (Group_psw) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Group_psw m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Group_psw) to Model (Group_psw) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValGroup_id = ViewModelConversion.ToString(ValGroup_id);
				m.ValCodpsw = ViewModelConversion.ToString(ValCodpsw);
				m.ValCodgroup_psw = ViewModelConversion.ToString(ValCodgroup_psw);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Group_psw) to Model (Group_psw) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "group_psw.group_id":
						this.ValGroup_id = ViewModelConversion.ToString(_value);
						break;
					case "group_psw.codpsw":
						this.ValCodpsw = ViewModelConversion.ToString(_value);
						break;
					case "group_psw.codgroup_psw":
						this.ValCodgroup_psw = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Group_psw) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Group_psw)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Group_psw.Find(id ?? Navigation.GetStrValue("group_psw"), m_userContext, "FGROUP_PSW"); }
			finally { Model ??= new Models.Group_psw(m_userContext) { Identifier = "FGROUP_PSW" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Group_psw.Find(Navigation.GetStrValue("group_psw"), m_userContext, "FGROUP_PSW");
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

			Model.Identifier = "FGROUP_PSW";
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
		
		protected override void LoadDocumentsProperties(Models.Group_psw row)
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
				Model = Models.Group_psw.Find(Navigation.GetStrValue("group_psw"), m_userContext, "FGROUP_PSW");
				if (Model == null)
				{
					Model = new Models.Group_psw(m_userContext) { Identifier = "FGROUP_PSW" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("group_psw");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Group_psw__group__name(qs, lazyLoad);
			Load_Group_psw__psw__nome(qs, lazyLoad);

// USE /[MANUAL MNT VIEWMODEL_LOADPARTIAL GROUP_PSW]/
		}

// USE /[MANUAL MNT VIEWMODEL_NEW GROUP_PSW]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL MNT VIEWMODEL_SAVE GROUP_PSW]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL MNT VIEWMODEL_APPLY GROUP_PSW]/

// USE /[MANUAL MNT VIEWMODEL_DUPLICATE GROUP_PSW]/

// USE /[MANUAL MNT VIEWMODEL_DESTROY GROUP_PSW]/
		public override void Destroy(string id)
		{
			Model = Models.Group_psw.Find(id, m_userContext, "FGROUP_PSW");
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
		/// TableGroupName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Group_psw__group__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool group_psw__group__nameDoLoad = true;
			CriteriaSet group_psw__group__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("group", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					group_psw__group__nameConds.Equal(CSGenioAgroup.FldCodgroup, hValue);
					this.ValGroup_id = DBConversion.ToString(hValue);
				}
			}

			TableGroupName = new TableDBEdit<Models.Group>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_group") != null)
				{
					this.ValGroup_id = Navigation.GetStrValue("RETURN_group");
					Navigation.CurrentLevel.SetEntry("RETURN_group", null);
				}
				FillDependant_Group_pswTableGroupName(lazyLoad);
				return;
			}

			if (group_psw__group__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableGroupName, "sTableGroupName", "dTableGroupName", qs, "group");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAgroup.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableGroupName_tableFilters"]))
					TableGroupName.TableFilters = bool.Parse(qs["TableGroupName_tableFilters"]);
				else
					TableGroupName.TableFilters = false;

				query = qs["qTableGroupName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAgroup.FldName, query + "%");
				}
				group_psw__group__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableGroupName"] != null ? qs["pTableGroupName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAgroup.FldCodgroup, CSGenioAgroup.FldName, CSGenioAgroup.FldZzstate];

// USE /[MANUAL MNT OVERRQ GROUP_PSW_GROUPNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("group", FormMode.New) || Navigation.checkFormMode("group", FormMode.Duplicate))
					group_psw__group__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAgroup.FldZzstate, 0)
						.Equal(CSGenioAgroup.FldCodgroup, Navigation.GetStrValue("group")));
				else
					group_psw__group__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgroup.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("group", "name");
				ListingMVC<CSGenioAgroup> listing = Models.ModelBase.Where<CSGenioAgroup>(m_userContext, false, group_psw__group__nameConds, fields, offset, numberItems, sorts, "LED_GROUP_PSW__GROUP__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableGroupName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableGroupName.Query = query;
				TableGroupName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Group(m_userContext, r, true, _fieldsToSerialize_GROUP_PSW__GROUP__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_group") != null)
				{
					this.ValGroup_id = Navigation.GetStrValue("RETURN_group");
					Navigation.CurrentLevel.SetEntry("RETURN_group", null);
				}

				TableGroupName.List = new SelectList(TableGroupName.Elements.ToSelectList(x => x.ValName, x => x.ValCodgroup,  x => x.ValCodgroup == this.ValGroup_id), "Value", "Text", this.ValGroup_id);
				FillDependant_Group_pswTableGroupName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableGroupName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Group</param>
		public ConcurrentDictionary<string, object> GetDependant_Group_pswTableGroupName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAgroup.FldCodgroup, CSGenioAgroup.FldName];

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

			CSGenioAgroup tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAgroup.FldCodgroup, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableGroupName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Group_pswTableGroupName(bool lazyLoad = false)
		{
			var row = GetDependant_Group_pswTableGroupName(this.ValGroup_id);
			try
			{

				// Fill List fields
				this.ValGroup_id = ViewModelConversion.ToString(row["group.codgroup"]);
				TableGroupName.Value = (string)row["group.name"];
				if (GenFunctions.emptyG(this.ValGroup_id) == 1)
				{
					this.ValGroup_id = "";
					TableGroupName.Value = "";
					Navigation.ClearValue("group");
				}
				else if (lazyLoad)
				{
					TableGroupName.SetPagination(1, 0, false, false, 1);
					TableGroupName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValGroup_id),
							Text = Convert.ToString(TableGroupName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValGroup_id);
				}

				TableGroupName.Selected = this.ValGroup_id;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableGroupName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_GROUP_PSW__GROUP__NAME = ["Group", "Group.ValCodgroup", "Group.ValZzstate", "Group.ValName"];

		/// <summary>
		/// TablePswNome -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Group_psw__psw__nome(NameValueCollection qs, bool lazyLoad = false)
		{
			bool group_psw__psw__nomeDoLoad = true;
			CriteriaSet group_psw__psw__nomeConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("psw", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					group_psw__psw__nomeConds.Equal(CSGenioApsw.FldCodpsw, hValue);
					this.ValCodpsw = DBConversion.ToString(hValue);
				}
			}

			TablePswNome = new TableDBEdit<Models.Psw>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}
				FillDependant_Group_pswTablePswNome(lazyLoad);
				return;
			}

			if (group_psw__psw__nomeDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePswNome, "sTablePswNome", "dTablePswNome", qs, "psw");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePswNome_tableFilters"]))
					TablePswNome.TableFilters = bool.Parse(qs["TablePswNome_tableFilters"]);
				else
					TablePswNome.TableFilters = false;

				query = qs["qTablePswNome"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApsw.FldNome, query + "%");
				}
				group_psw__psw__nomeConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePswNome"] != null ? qs["pTablePswNome"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome, CSGenioApsw.FldZzstate];

// USE /[MANUAL MNT OVERRQ GROUP_PSW_PSWNOME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("psw", FormMode.New) || Navigation.checkFormMode("psw", FormMode.Duplicate))
					group_psw__psw__nomeConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApsw.FldZzstate, 0)
						.Equal(CSGenioApsw.FldCodpsw, Navigation.GetStrValue("psw")));
				else
					group_psw__psw__nomeConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApsw.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("psw", "nome");
				ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(m_userContext, false, group_psw__psw__nomeConds, fields, offset, numberItems, sorts, "LED_GROUP_PSW__PSW__NOME", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePswNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePswNome.Query = query;
				TablePswNome.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Psw(m_userContext, r, true, _fieldsToSerialize_GROUP_PSW__PSW__NOME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValCodpsw = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}

				TablePswNome.List = new SelectList(TablePswNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodpsw,  x => x.ValCodpsw == this.ValCodpsw), "Value", "Text", this.ValCodpsw);
				FillDependant_Group_pswTablePswNome();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Psw</param>
		public ConcurrentDictionary<string, object> GetDependant_Group_pswTablePswNome(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome];

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

			CSGenioApsw tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApsw.FldCodpsw, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Group_pswTablePswNome(bool lazyLoad = false)
		{
			var row = GetDependant_Group_pswTablePswNome(this.ValCodpsw);
			try
			{

				// Fill List fields
				this.ValCodpsw = ViewModelConversion.ToString(row["psw.codpsw"]);
				TablePswNome.Value = (string)row["psw.nome"];
				if (GenFunctions.emptyG(this.ValCodpsw) == 1)
				{
					this.ValCodpsw = "";
					TablePswNome.Value = "";
					Navigation.ClearValue("psw");
				}
				else if (lazyLoad)
				{
					TablePswNome.SetPagination(1, 0, false, false, 1);
					TablePswNome.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpsw),
							Text = Convert.ToString(TablePswNome.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpsw);
				}

				TablePswNome.Selected = this.ValCodpsw;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePswNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_GROUP_PSW__PSW__NOME = ["Psw", "Psw.ValCodpsw", "Psw.ValZzstate", "Psw.ValNome"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"group_psw.group_id" => ViewModelConversion.ToString(modelValue),
				"group_psw.codpsw" => ViewModelConversion.ToString(modelValue),
				"group_psw.codgroup_psw" => ViewModelConversion.ToString(modelValue),
				"group.codgroup" => ViewModelConversion.ToString(modelValue),
				"group.name" => ViewModelConversion.ToString(modelValue),
				"psw.codpsw" => ViewModelConversion.ToString(modelValue),
				"psw.nome" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM GROUP_PSW]/

		#endregion
	}
}
