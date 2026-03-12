using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Investment;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER INVESTMENT]/

namespace GenioMVC.Controllers
{
	public partial class InvestmentController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_INVESTMENT_CANCEL = new("INVESTMENT14761", "Investment_Cancel", "Investment") { vueRouteName = "form-INVESTMENT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_INVESTMENT_SHOW = new("INVESTMENT14761", "Investment_Show", "Investment") { vueRouteName = "form-INVESTMENT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_INVESTMENT_NEW = new("INVESTMENT14761", "Investment_New", "Investment") { vueRouteName = "form-INVESTMENT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_INVESTMENT_EDIT = new("INVESTMENT14761", "Investment_Edit", "Investment") { vueRouteName = "form-INVESTMENT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_INVESTMENT_DUPLICATE = new("INVESTMENT14761", "Investment_Duplicate", "Investment") { vueRouteName = "form-INVESTMENT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_INVESTMENT_DELETE = new("INVESTMENT14761", "Investment_Delete", "Investment") { vueRouteName = "form-INVESTMENT", mode = "DELETE" };

		#endregion

		#region Investment private

		private void FormHistoryLimits_Investment()
		{

		}

		#endregion

		#region Investment_Show

// USE /[MANUAL MNT CONTROLLER_SHOW INVESTMENT]/

		[HttpPost]
		public ActionResult Investment_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Investment_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Investment_Show_GET",
				AreaName = "investment",
				Location = ACTION_INVESTMENT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Investment();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW INVESTMENT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Investment_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET INVESTMENT]/
		[HttpPost]
		public ActionResult Investment_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Investment_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Investment_New_GET",
				AreaName = "investment",
				FormName = "INVESTMENT",
				Location = ACTION_INVESTMENT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Investment();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW INVESTMENT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Investment/Investment_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST INVESTMENT]/
		[HttpPost]
		public ActionResult Investment_New([FromBody]Investment_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Investment_New",
				ViewName = "Investment",
				AreaName = "investment",
				Location = ACTION_INVESTMENT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW INVESTMENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX INVESTMENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX INVESTMENT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Investment_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET INVESTMENT]/
		[HttpPost]
		public ActionResult Investment_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Investment_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Investment_Edit_GET",
				AreaName = "investment",
				FormName = "INVESTMENT",
				Location = ACTION_INVESTMENT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Investment();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT INVESTMENT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Investment/Investment_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST INVESTMENT]/
		[HttpPost]
		public ActionResult Investment_Edit([FromBody]Investment_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Investment_Edit",
				ViewName = "Investment",
				AreaName = "investment",
				Location = ACTION_INVESTMENT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT INVESTMENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX INVESTMENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX INVESTMENT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Investment_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET INVESTMENT]/
		[HttpPost]
		public ActionResult Investment_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Investment_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Investment_Delete_GET",
				AreaName = "investment",
				FormName = "INVESTMENT",
				Location = ACTION_INVESTMENT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Investment();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE INVESTMENT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Investment/Investment_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST INVESTMENT]/
		[HttpPost]
		public ActionResult Investment_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Investment_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Investment_Delete",
				ViewName = "Investment",
				AreaName = "investment",
				Location = ACTION_INVESTMENT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE INVESTMENT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Investment_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("INVESTMENT");
		}

		#endregion

		#region Investment_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET INVESTMENT]/

		[HttpPost]
		public ActionResult Investment_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Investment_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Investment_Duplicate_GET",
				AreaName = "investment",
				FormName = "INVESTMENT",
				Location = ACTION_INVESTMENT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE INVESTMENT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Investment/Investment_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST INVESTMENT]/
		[HttpPost]
		public ActionResult Investment_Duplicate([FromBody]Investment_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Investment_Duplicate",
				ViewName = "Investment",
				AreaName = "investment",
				Location = ACTION_INVESTMENT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE INVESTMENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX INVESTMENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX INVESTMENT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Investment_Cancel

		//
		// GET: /Investment/Investment_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET INVESTMENT]/
		public ActionResult Investment_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Investment model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("investment");

// USE /[MANUAL MNT BEFORE_CANCEL INVESTMENT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL INVESTMENT]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_investment", "true", true);
			}

			Navigation.ClearValue("investment");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Investment_Category_typeValNameModel : RequestLookupModel
		{
			public Investment_ViewModel Model { get; set; }
		}

		//
		// GET: /Investment/Investment_Category_typeValName
		// POST: /Investment/Investment_Category_typeValName
		[ActionName("Investment_Category_typeValName")]
		public ActionResult Investment_Category_typeValName([FromBody] Investment_Category_typeValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_category_type")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_category_type");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Investment parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Investment_Category_typeValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Investment_CategoryValNameModel : RequestLookupModel
		{
			public Investment_ViewModel Model { get; set; }
		}

		//
		// GET: /Investment/Investment_CategoryValName
		// POST: /Investment/Investment_CategoryValName
		[ActionName("Investment_CategoryValName")]
		public ActionResult Investment_CategoryValName([FromBody] Investment_CategoryValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_category")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_category");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Investment parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Investment_CategoryValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Investment_MemberValNameModel : RequestLookupModel
		{
			public Investment_ViewModel Model { get; set; }
		}

		//
		// GET: /Investment/Investment_MemberValName
		// POST: /Investment/Investment_MemberValName
		[ActionName("Investment_MemberValName")]
		public ActionResult Investment_MemberValName([FromBody] Investment_MemberValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_member")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_member");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Investment parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Investment_MemberValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Investment_SourceValTitleModel : RequestLookupModel
		{
			public Investment_ViewModel Model { get; set; }
		}

		//
		// GET: /Investment/Investment_SourceValTitle
		// POST: /Investment/Investment_SourceValTitle
		[ActionName("Investment_SourceValTitle")]
		public ActionResult Investment_SourceValTitle([FromBody] Investment_SourceValTitleModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_source")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_source");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Investment parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Investment_SourceValTitle_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Investment/Investment_SaveEdit
		[HttpPost]
		public ActionResult Investment_SaveEdit([FromBody] Investment_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Investment_SaveEdit",
				ViewName = "Investment",
				AreaName = "investment",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT INVESTMENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT INVESTMENT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class InvestmentDocumValidateTickets : RequestDocumValidateTickets
		{
			public Investment_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsInvestment([FromBody] InvestmentDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
