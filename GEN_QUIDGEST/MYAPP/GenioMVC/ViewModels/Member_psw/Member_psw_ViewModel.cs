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

namespace GenioMVC.ViewModels.Member_psw
{
	public class Member_psw_ViewModel : FormViewModel<Models.Member_psw>, IPreparableForSerialization
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
		/// Title: "Member" | Type: "CE"
		/// </summary>
		public string ValMember_id { get; set; }
		/// <summary>
		/// Title: "User" | Type: "CE"
		/// </summary>
		public string ValPsw_id { get; set; }

		#endregion
		/// <summary>
		/// Title: "Member" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Member> TableMemberName { get; set; }
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

		public string ValCodmember_psw { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Member_psw_ViewModel() : base(null!) { }

		public Member_psw_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FMEMBER_PSW", nestedForm) { }

		public Member_psw_ViewModel(UserContext userContext, Models.Member_psw row, bool nestedForm = false) : base(userContext, "FMEMBER_PSW", row, nestedForm) { }

		public Member_psw_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("member_psw", id);
			Model = Models.Member_psw.Find(id, userContext, "FMEMBER_PSW", fieldsToQuery: fieldsToLoad);
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
			Models.Member_psw model = new Models.Member_psw(userContext) { Identifier = "FMEMBER_PSW" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FMEMBER_PSW");
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
		public override void MapFromModel(Models.Member_psw m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Member_psw) to ViewModel (Member_psw) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValMember_id = ViewModelConversion.ToString(m.ValMember_id);
				ValPsw_id = ViewModelConversion.ToString(m.ValPsw_id);
				ValCodmember_psw = ViewModelConversion.ToString(m.ValCodmember_psw);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Member_psw) to ViewModel (Member_psw) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Member_psw m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Member_psw) to Model (Member_psw) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValMember_id = ViewModelConversion.ToString(ValMember_id);
				m.ValPsw_id = ViewModelConversion.ToString(ValPsw_id);
				m.ValCodmember_psw = ViewModelConversion.ToString(ValCodmember_psw);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Member_psw) to Model (Member_psw) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "member_psw.member_id":
						this.ValMember_id = ViewModelConversion.ToString(_value);
						break;
					case "member_psw.psw_id":
						this.ValPsw_id = ViewModelConversion.ToString(_value);
						break;
					case "member_psw.codmember_psw":
						this.ValCodmember_psw = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Member_psw) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Member_psw)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Member_psw.Find(id ?? Navigation.GetStrValue("member_psw"), m_userContext, "FMEMBER_PSW"); }
			finally { Model ??= new Models.Member_psw(m_userContext) { Identifier = "FMEMBER_PSW" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Member_psw.Find(Navigation.GetStrValue("member_psw"), m_userContext, "FMEMBER_PSW");
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

			Model.Identifier = "FMEMBER_PSW";
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
		
		protected override void LoadDocumentsProperties(Models.Member_psw row)
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
				Model = Models.Member_psw.Find(Navigation.GetStrValue("member_psw"), m_userContext, "FMEMBER_PSW");
				if (Model == null)
				{
					Model = new Models.Member_psw(m_userContext) { Identifier = "FMEMBER_PSW" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("member_psw");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Member_psw__member__name(qs, lazyLoad);
			Load_Member_psw__psw__nome(qs, lazyLoad);

// USE /[MANUAL MNT VIEWMODEL_LOADPARTIAL MEMBER_PSW]/
		}

// USE /[MANUAL MNT VIEWMODEL_NEW MEMBER_PSW]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValMember_id", Resources.Resources.MEMBER00534, ViewModelConversion.ToString(ValMember_id), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValPsw_id", Resources.Resources.USER57012, ViewModelConversion.ToString(ValPsw_id), FieldType.KEY_INT.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL MNT VIEWMODEL_SAVE MEMBER_PSW]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL MNT VIEWMODEL_APPLY MEMBER_PSW]/

// USE /[MANUAL MNT VIEWMODEL_DUPLICATE MEMBER_PSW]/

// USE /[MANUAL MNT VIEWMODEL_DESTROY MEMBER_PSW]/
		public override void Destroy(string id)
		{
			Model = Models.Member_psw.Find(id, m_userContext, "FMEMBER_PSW");
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
		/// TableMemberName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Member_psw__member__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool member_psw__member__nameDoLoad = true;
			CriteriaSet member_psw__member__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("member", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					member_psw__member__nameConds.Equal(CSGenioAmember.FldCodmember, hValue);
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
				FillDependant_Member_pswTableMemberName(lazyLoad);
				return;
			}

			if (member_psw__member__nameDoLoad)
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
				member_psw__member__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableMemberName"] != null ? qs["pTableMemberName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAmember.FldCodmember, CSGenioAmember.FldName, CSGenioAmember.FldZzstate];

// USE /[MANUAL MNT OVERRQ MEMBER_PSW_MEMBERNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("member", FormMode.New) || Navigation.checkFormMode("member", FormMode.Duplicate))
					member_psw__member__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAmember.FldZzstate, 0)
						.Equal(CSGenioAmember.FldCodmember, Navigation.GetStrValue("member")));
				else
					member_psw__member__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAmember.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("member", "name");
				ListingMVC<CSGenioAmember> listing = Models.ModelBase.Where<CSGenioAmember>(m_userContext, false, member_psw__member__nameConds, fields, offset, numberItems, sorts, "LED_MEMBER_PSW__MEMBER__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableMemberName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableMemberName.Query = query;
				TableMemberName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Member(m_userContext, r, true, _fieldsToSerialize_MEMBER_PSW__MEMBER__NAME));

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
				FillDependant_Member_pswTableMemberName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableMemberName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Member</param>
		public ConcurrentDictionary<string, object> GetDependant_Member_pswTableMemberName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAmember.FldCodmember, CSGenioAmember.FldName];

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
		public void FillDependant_Member_pswTableMemberName(bool lazyLoad = false)
		{
			var row = GetDependant_Member_pswTableMemberName(this.ValMember_id);
			try
			{

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

		private readonly string[] _fieldsToSerialize_MEMBER_PSW__MEMBER__NAME = ["Member", "Member.ValCodmember", "Member.ValZzstate", "Member.ValName"];

		/// <summary>
		/// TablePswNome -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Member_psw__psw__nome(NameValueCollection qs, bool lazyLoad = false)
		{
			bool member_psw__psw__nomeDoLoad = true;
			CriteriaSet member_psw__psw__nomeConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("psw", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					member_psw__psw__nomeConds.Equal(CSGenioApsw.FldCodpsw, hValue);
					this.ValPsw_id = DBConversion.ToString(hValue);
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
					this.ValPsw_id = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}
				FillDependant_Member_pswTablePswNome(lazyLoad);
				return;
			}

			if (member_psw__psw__nomeDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePswNome, "sTablePswNome", "dTablePswNome", qs, "psw");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApsw.FldNome), SortOrder.Ascending));

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
				member_psw__psw__nomeConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePswNome"] != null ? qs["pTablePswNome"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApsw.FldCodpsw, CSGenioApsw.FldNome, CSGenioApsw.FldZzstate];

// USE /[MANUAL MNT OVERRQ MEMBER_PSW_PSWNOME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("psw", FormMode.New) || Navigation.checkFormMode("psw", FormMode.Duplicate))
					member_psw__psw__nomeConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApsw.FldZzstate, 0)
						.Equal(CSGenioApsw.FldCodpsw, Navigation.GetStrValue("psw")));
				else
					member_psw__psw__nomeConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApsw.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("psw", "nome");
				ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(m_userContext, false, member_psw__psw__nomeConds, fields, offset, numberItems, sorts, "LED_MEMBER_PSW__PSW__NOME", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePswNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePswNome.Query = query;
				TablePswNome.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Psw(m_userContext, r, true, _fieldsToSerialize_MEMBER_PSW__PSW__NOME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_psw") != null)
				{
					this.ValPsw_id = Navigation.GetStrValue("RETURN_psw");
					Navigation.CurrentLevel.SetEntry("RETURN_psw", null);
				}

				TablePswNome.List = new SelectList(TablePswNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodpsw,  x => x.ValCodpsw == this.ValPsw_id), "Value", "Text", this.ValPsw_id);
				FillDependant_Member_pswTablePswNome();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePswNome (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Psw</param>
		public ConcurrentDictionary<string, object> GetDependant_Member_pswTablePswNome(string PKey)
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
		public void FillDependant_Member_pswTablePswNome(bool lazyLoad = false)
		{
			var row = GetDependant_Member_pswTablePswNome(this.ValPsw_id);
			try
			{

				// Fill List fields
				this.ValPsw_id = ViewModelConversion.ToString(row["psw.codpsw"]);
				TablePswNome.Value = (string)row["psw.nome"];
				if (GenFunctions.emptyG(this.ValPsw_id) == 1)
				{
					this.ValPsw_id = "";
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
							Value = Convert.ToString(this.ValPsw_id),
							Text = Convert.ToString(TablePswNome.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValPsw_id);
				}

				TablePswNome.Selected = this.ValPsw_id;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePswNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_MEMBER_PSW__PSW__NOME = ["Psw", "Psw.ValCodpsw", "Psw.ValZzstate", "Psw.ValNome"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"member_psw.member_id" => ViewModelConversion.ToString(modelValue),
				"member_psw.psw_id" => ViewModelConversion.ToString(modelValue),
				"member_psw.codmember_psw" => ViewModelConversion.ToString(modelValue),
				"member.codmember" => ViewModelConversion.ToString(modelValue),
				"member.name" => ViewModelConversion.ToString(modelValue),
				"psw.codpsw" => ViewModelConversion.ToString(modelValue),
				"psw.nome" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM MEMBER_PSW]/

		#endregion
	}
}
