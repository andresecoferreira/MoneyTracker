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

namespace GenioMVC.ViewModels.Member
{
	public class Member_ViewModel : FormViewModel<Models.Member>, IPreparableForSerialization
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

		#endregion
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.Models.ImageModel ValPhoto { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Birthday" | Type: "D"
		/// </summary>
		public DateTime? ValBirthday { get; set; }
		/// <summary>
		/// Title: "E-Mail" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }
		/// <summary>
		/// Title: "Phone" | Type: "C"
		/// </summary>
		public string ValPhone { get; set; }
		/// <summary>
		/// Title: "Group" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Group> TableGroupName { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodmember { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Member_ViewModel() : base(null!) { }

		public Member_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FMEMBER", nestedForm) { }

		public Member_ViewModel(UserContext userContext, Models.Member row, bool nestedForm = false) : base(userContext, "FMEMBER", row, nestedForm) { }

		public Member_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("member", id);
			Model = Models.Member.Find(id, userContext, "FMEMBER", fieldsToQuery: fieldsToLoad);
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
			Models.Member model = new Models.Member(userContext) { Identifier = "FMEMBER" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FMEMBER");
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
		public override void MapFromModel(Models.Member m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Member) to ViewModel (Member) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValGroup_id = ViewModelConversion.ToString(m.ValGroup_id);
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValBirthday = ViewModelConversion.ToDateTime(m.ValBirthday);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValPhone = ViewModelConversion.ToString(m.ValPhone);
				ValCodmember = ViewModelConversion.ToString(m.ValCodmember);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Member) to ViewModel (Member) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Member m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Member) to Model (Member) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValGroup_id = ViewModelConversion.ToString(ValGroup_id);
				if (ValPhoto == null || !ValPhoto.IsThumbnail)
					m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValBirthday = ViewModelConversion.ToDateTime(ValBirthday);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValPhone = ViewModelConversion.ToString(ValPhone);
				m.ValCodmember = ViewModelConversion.ToString(ValCodmember);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Member) to Model (Member) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "member.group_id":
						this.ValGroup_id = ViewModelConversion.ToString(_value);
						break;
					case "member.photo":
						this.ValPhoto = ViewModelConversion.ToImage(_value);
						break;
					case "member.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "member.birthday":
						this.ValBirthday = ViewModelConversion.ToDateTime(_value);
						break;
					case "member.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "member.phone":
						this.ValPhone = ViewModelConversion.ToString(_value);
						break;
					case "member.codmember":
						this.ValCodmember = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Member) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Member)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Member.Find(id ?? Navigation.GetStrValue("member"), m_userContext, "FMEMBER"); }
			finally { Model ??= new Models.Member(m_userContext) { Identifier = "FMEMBER" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Member.Find(Navigation.GetStrValue("member"), m_userContext, "FMEMBER");
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

			Model.Identifier = "FMEMBER";
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
		
		protected override void LoadDocumentsProperties(Models.Member row)
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
				Model = Models.Member.Find(Navigation.GetStrValue("member"), m_userContext, "FMEMBER");
				if (Model == null)
				{
					Model = new Models.Member(m_userContext) { Identifier = "FMEMBER" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("member");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Member__groupname____(qs, lazyLoad);

// USE /[MANUAL MNT VIEWMODEL_LOADPARTIAL MEMBER]/
		}

// USE /[MANUAL MNT VIEWMODEL_NEW MEMBER]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 80);
			validator.StringLength("ValEmail", Resources.Resources.E_MAIL26803, ValEmail, 50);
			validator.StringLength("ValPhone", Resources.Resources.PHONE56703, ValPhone, 15);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL MNT VIEWMODEL_SAVE MEMBER]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL MNT VIEWMODEL_APPLY MEMBER]/

// USE /[MANUAL MNT VIEWMODEL_DUPLICATE MEMBER]/

// USE /[MANUAL MNT VIEWMODEL_DESTROY MEMBER]/
		public override void Destroy(string id)
		{
			Model = Models.Member.Find(id, m_userContext, "FMEMBER");
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
		public void Load_Member__groupname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool member__groupname____DoLoad = true;
			CriteriaSet member__groupname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("group", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					member__groupname____Conds.Equal(CSGenioAgroup.FldCodgroup, hValue);
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
				FillDependant_MemberTableGroupName(lazyLoad);
				return;
			}

			if (member__groupname____DoLoad)
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
				member__groupname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableGroupName"] != null ? qs["pTableGroupName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAgroup.FldCodgroup, CSGenioAgroup.FldName, CSGenioAgroup.FldZzstate];

// USE /[MANUAL MNT OVERRQ MEMBER_GROUPNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("group", FormMode.New) || Navigation.checkFormMode("group", FormMode.Duplicate))
					member__groupname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAgroup.FldZzstate, 0)
						.Equal(CSGenioAgroup.FldCodgroup, Navigation.GetStrValue("group")));
				else
					member__groupname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAgroup.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("group", "name");
				ListingMVC<CSGenioAgroup> listing = Models.ModelBase.Where<CSGenioAgroup>(m_userContext, false, member__groupname____Conds, fields, offset, numberItems, sorts, "LED_MEMBER__GROUPNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableGroupName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableGroupName.Query = query;
				TableGroupName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Group(m_userContext, r, true, _fieldsToSerialize_MEMBER__GROUPNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_group") != null)
				{
					this.ValGroup_id = Navigation.GetStrValue("RETURN_group");
					Navigation.CurrentLevel.SetEntry("RETURN_group", null);
				}

				TableGroupName.List = new SelectList(TableGroupName.Elements.ToSelectList(x => x.ValName, x => x.ValCodgroup,  x => x.ValCodgroup == this.ValGroup_id), "Value", "Text", this.ValGroup_id);
				FillDependant_MemberTableGroupName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableGroupName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Group</param>
		public ConcurrentDictionary<string, object> GetDependant_MemberTableGroupName(string PKey)
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
		public void FillDependant_MemberTableGroupName(bool lazyLoad = false)
		{
			var row = GetDependant_MemberTableGroupName(this.ValGroup_id);
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

		private readonly string[] _fieldsToSerialize_MEMBER__GROUPNAME____ = ["Group", "Group.ValCodgroup", "Group.ValZzstate", "Group.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"member.group_id" => ViewModelConversion.ToString(modelValue),
				"member.photo" => ViewModelConversion.ToImage(modelValue),
				"member.name" => ViewModelConversion.ToString(modelValue),
				"member.birthday" => ViewModelConversion.ToDateTime(modelValue),
				"member.email" => ViewModelConversion.ToString(modelValue),
				"member.phone" => ViewModelConversion.ToString(modelValue),
				"member.codmember" => ViewModelConversion.ToString(modelValue),
				"group.codgroup" => ViewModelConversion.ToString(modelValue),
				"group.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhoto != null)
				ValPhoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaMEMBER, CSGenioAmember.FldPhoto.Field, null, ValCodmember);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM MEMBER]/

		#endregion
	}
}
