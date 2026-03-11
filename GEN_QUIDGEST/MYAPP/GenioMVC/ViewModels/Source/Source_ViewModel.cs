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

namespace GenioMVC.ViewModels.Source
{
	public class Source_ViewModel : FormViewModel<Models.Source>, IPreparableForSerialization
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
		/// Title: "Owner" | Type: "CE"
		/// </summary>
		public string ValMember_id { get; set; }

		#endregion
		/// <summary>
		/// Title: "Type" | Type: "AC"
		/// </summary>
		public string ValType { get; set; }
		/// <summary>
		/// Title: "Owner" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Member> TableMemberName { get; set; }
		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }
		/// <summary>
		/// Title: "Bank" | Type: "AC"
		/// </summary>
		public string ValBank { get; set; }
		/// <summary>
		/// Title: "Account Number" | Type: "C"
		/// </summary>
		public string ValAccount_number { get; set; }
		/// <summary>
		/// Title: "Balance" | Type: "N"
		/// </summary>
		public decimal? ValBalance { get; set; }
		/// <summary>
		/// Title: "Created At" | Type: "OD"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreated_at { get; set; }
		/// <summary>
		/// Title: "Created By" | Type: "ON"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreated_by { get; set; }
		/// <summary>
		/// Title: "Updated At" | Type: "ED"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValUpdated_at { get; set; }
		/// <summary>
		/// Title: "Updated By" | Type: "EN"
		/// </summary>
		[ValidateSetAccess]
		public string ValUpdated_by { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodsource { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Source_ViewModel() : base(null!) { }

		public Source_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FSOURCE", nestedForm) { }

		public Source_ViewModel(UserContext userContext, Models.Source row, bool nestedForm = false) : base(userContext, "FSOURCE", row, nestedForm) { }

		public Source_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("source", id);
			Model = Models.Source.Find(id, userContext, "FSOURCE", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
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
			Models.Source model = new Models.Source(userContext) { Identifier = "FSOURCE" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FSOURCE");
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
		public override void MapFromModel(Models.Source m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Source) to ViewModel (Source) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValMember_id = ViewModelConversion.ToString(m.ValMember_id);
				ValType = ViewModelConversion.ToString(m.ValType);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValBank = ViewModelConversion.ToString(m.ValBank);
				ValAccount_number = ViewModelConversion.ToString(m.ValAccount_number);
				ValBalance = ViewModelConversion.ToNumeric(m.ValBalance);
				ValCreated_at = ViewModelConversion.ToDateTime(m.ValCreated_at);
				ValCreated_by = ViewModelConversion.ToString(m.ValCreated_by);
				ValUpdated_at = ViewModelConversion.ToDateTime(m.ValUpdated_at);
				ValUpdated_by = ViewModelConversion.ToString(m.ValUpdated_by);
				ValCodsource = ViewModelConversion.ToString(m.ValCodsource);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Source) to ViewModel (Source) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Source m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Source) to Model (Source) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValMember_id = ViewModelConversion.ToString(ValMember_id);
				m.ValType = ViewModelConversion.ToString(ValType);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValBank = ViewModelConversion.ToString(ValBank);
				m.ValAccount_number = ViewModelConversion.ToString(ValAccount_number);
				m.ValBalance = ViewModelConversion.ToNumeric(ValBalance);
				m.ValCodsource = ViewModelConversion.ToString(ValCodsource);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCreated_at = ViewModelConversion.ToDateTime(ValCreated_at);
				m.ValCreated_by = ViewModelConversion.ToString(ValCreated_by);
				m.ValUpdated_at = ViewModelConversion.ToDateTime(ValUpdated_at);
				m.ValUpdated_by = ViewModelConversion.ToString(ValUpdated_by);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Source) to Model (Source) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "source.member_id":
						this.ValMember_id = ViewModelConversion.ToString(_value);
						break;
					case "source.type":
						this.ValType = ViewModelConversion.ToString(_value);
						break;
					case "source.title":
						this.ValTitle = ViewModelConversion.ToString(_value);
						break;
					case "source.bank":
						this.ValBank = ViewModelConversion.ToString(_value);
						break;
					case "source.account_number":
						this.ValAccount_number = ViewModelConversion.ToString(_value);
						break;
					case "source.balance":
						this.ValBalance = ViewModelConversion.ToNumeric(_value);
						break;
					case "source.codsource":
						this.ValCodsource = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Source) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Source)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Source.Find(id ?? Navigation.GetStrValue("source"), m_userContext, "FSOURCE"); }
			finally { Model ??= new Models.Source(m_userContext) { Identifier = "FSOURCE" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Source.Find(Navigation.GetStrValue("source"), m_userContext, "FSOURCE");
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

			Model.Identifier = "FSOURCE";
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
		
		protected override void LoadDocumentsProperties(Models.Source row)
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
				Model = Models.Source.Find(Navigation.GetStrValue("source"), m_userContext, "FSOURCE");
				if (Model == null)
				{
					Model = new Models.Source(m_userContext) { Identifier = "FSOURCE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("source");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Source__member__name(qs, lazyLoad);

// USE /[MANUAL MNT VIEWMODEL_LOADPARTIAL SOURCE]/
		}

// USE /[MANUAL MNT VIEWMODEL_NEW SOURCE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValMember_id", Resources.Resources.OWNER09558, ViewModelConversion.ToString(ValMember_id), FieldType.KEY_INT.GetFormatting());

			validator.Required("ValType", Resources.Resources.TYPE00312, ViewModelConversion.ToString(ValType), FieldType.ARRAY_TEXT.GetFormatting());
			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 50);

			validator.Required("ValTitle", Resources.Resources.TITLE21885, ViewModelConversion.ToString(ValTitle), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValAccount_number", Resources.Resources.ACCOUNT_NUMBER58504, ValAccount_number, 20);

			validator.Required("ValBalance", Resources.Resources.BALANCE13297, ViewModelConversion.ToNumeric(ValBalance), FieldType.NUMERIC.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL MNT VIEWMODEL_SAVE SOURCE]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL MNT VIEWMODEL_APPLY SOURCE]/

// USE /[MANUAL MNT VIEWMODEL_DUPLICATE SOURCE]/

// USE /[MANUAL MNT VIEWMODEL_DESTROY SOURCE]/
		public override void Destroy(string id)
		{
			Model = Models.Source.Find(id, m_userContext, "FSOURCE");
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
		public void Load_Source__member__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool source__member__nameDoLoad = true;
			CriteriaSet source__member__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("member", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					source__member__nameConds.Equal(CSGenioAmember.FldCodmember, hValue);
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
				FillDependant_SourceTableMemberName(lazyLoad);
				return;
			}

			if (source__member__nameDoLoad)
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
				source__member__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableMemberName"] != null ? qs["pTableMemberName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAmember.FldCodmember, CSGenioAmember.FldName, CSGenioAmember.FldZzstate];

// USE /[MANUAL MNT OVERRQ SOURCE_MEMBERNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("member", FormMode.New) || Navigation.checkFormMode("member", FormMode.Duplicate))
					source__member__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAmember.FldZzstate, 0)
						.Equal(CSGenioAmember.FldCodmember, Navigation.GetStrValue("member")));
				else
					source__member__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAmember.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("member", "name");
				ListingMVC<CSGenioAmember> listing = Models.ModelBase.Where<CSGenioAmember>(m_userContext, false, source__member__nameConds, fields, offset, numberItems, sorts, "LED_SOURCE__MEMBER__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableMemberName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableMemberName.Query = query;
				TableMemberName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Member(m_userContext, r, true, _fieldsToSerialize_SOURCE__MEMBER__NAME));

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
				FillDependant_SourceTableMemberName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableMemberName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Member</param>
		public ConcurrentDictionary<string, object> GetDependant_SourceTableMemberName(string PKey)
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
		public void FillDependant_SourceTableMemberName(bool lazyLoad = false)
		{
			var row = GetDependant_SourceTableMemberName(this.ValMember_id);
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

		private readonly string[] _fieldsToSerialize_SOURCE__MEMBER__NAME = ["Member", "Member.ValCodmember", "Member.ValZzstate", "Member.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"source.member_id" => ViewModelConversion.ToString(modelValue),
				"source.type" => ViewModelConversion.ToString(modelValue),
				"source.title" => ViewModelConversion.ToString(modelValue),
				"source.bank" => ViewModelConversion.ToString(modelValue),
				"source.account_number" => ViewModelConversion.ToString(modelValue),
				"source.balance" => ViewModelConversion.ToNumeric(modelValue),
				"source.created_at" => ViewModelConversion.ToDateTime(modelValue),
				"source.created_by" => ViewModelConversion.ToString(modelValue),
				"source.updated_at" => ViewModelConversion.ToDateTime(modelValue),
				"source.updated_by" => ViewModelConversion.ToString(modelValue),
				"source.codsource" => ViewModelConversion.ToString(modelValue),
				"member.codmember" => ViewModelConversion.ToString(modelValue),
				"member.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM SOURCE]/

		#endregion
	}
}
