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
using GenioMVC.ViewModels.Income;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER INCOME]/

namespace GenioMVC.Controllers
{
	public partial class IncomeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_INCOME_CANCEL = new("INCOME04695", "Income_Cancel", "Income") { vueRouteName = "form-INCOME", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_INCOME_SHOW = new("INCOME04695", "Income_Show", "Income") { vueRouteName = "form-INCOME", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_INCOME_NEW = new("INCOME04695", "Income_New", "Income") { vueRouteName = "form-INCOME", mode = "NEW" };
		private static readonly NavigationLocation ACTION_INCOME_EDIT = new("INCOME04695", "Income_Edit", "Income") { vueRouteName = "form-INCOME", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_INCOME_DUPLICATE = new("INCOME04695", "Income_Duplicate", "Income") { vueRouteName = "form-INCOME", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_INCOME_DELETE = new("INCOME04695", "Income_Delete", "Income") { vueRouteName = "form-INCOME", mode = "DELETE" };

		#endregion

		#region Income private

		private void FormHistoryLimits_Income()
		{

		}

		#endregion

		#region Income_Show

// USE /[MANUAL MNT CONTROLLER_SHOW INCOME]/

		[HttpPost]
		public ActionResult Income_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Income_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Income_Show_GET",
				AreaName = "income",
				Location = ACTION_INCOME_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Income();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW INCOME]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Income_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET INCOME]/
		[HttpPost]
		public ActionResult Income_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Income_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Income_New_GET",
				AreaName = "income",
				FormName = "INCOME",
				Location = ACTION_INCOME_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Income();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW INCOME]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Income/Income_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST INCOME]/
		[HttpPost]
		public ActionResult Income_New([FromBody]Income_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Income_New",
				ViewName = "Income",
				AreaName = "income",
				Location = ACTION_INCOME_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW INCOME]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX INCOME]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX INCOME]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Income_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET INCOME]/
		[HttpPost]
		public ActionResult Income_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Income_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Income_Edit_GET",
				AreaName = "income",
				FormName = "INCOME",
				Location = ACTION_INCOME_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Income();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT INCOME]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Income/Income_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST INCOME]/
		[HttpPost]
		public ActionResult Income_Edit([FromBody]Income_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Income_Edit",
				ViewName = "Income",
				AreaName = "income",
				Location = ACTION_INCOME_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT INCOME]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX INCOME]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX INCOME]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Income_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET INCOME]/
		[HttpPost]
		public ActionResult Income_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Income_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Income_Delete_GET",
				AreaName = "income",
				FormName = "INCOME",
				Location = ACTION_INCOME_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Income();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE INCOME]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Income/Income_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST INCOME]/
		[HttpPost]
		public ActionResult Income_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Income_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Income_Delete",
				ViewName = "Income",
				AreaName = "income",
				Location = ACTION_INCOME_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE INCOME]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Income_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("INCOME");
		}

		#endregion

		#region Income_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET INCOME]/

		[HttpPost]
		public ActionResult Income_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Income_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Income_Duplicate_GET",
				AreaName = "income",
				FormName = "INCOME",
				Location = ACTION_INCOME_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE INCOME]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Income/Income_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST INCOME]/
		[HttpPost]
		public ActionResult Income_Duplicate([FromBody]Income_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Income_Duplicate",
				ViewName = "Income",
				AreaName = "income",
				Location = ACTION_INCOME_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE INCOME]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX INCOME]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX INCOME]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Income_Cancel

		//
		// GET: /Income/Income_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET INCOME]/
		public ActionResult Income_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Income model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("income");

// USE /[MANUAL MNT BEFORE_CANCEL INCOME]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL INCOME]/

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

				Navigation.SetValue("ForcePrimaryRead_income", "true", true);
			}

			Navigation.ClearValue("income");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Income_CategoryValNameModel : RequestLookupModel
		{
			public Income_ViewModel Model { get; set; }
		}

		//
		// GET: /Income/Income_CategoryValName
		// POST: /Income/Income_CategoryValName
		[ActionName("Income_CategoryValName")]
		public ActionResult Income_CategoryValName([FromBody] Income_CategoryValNameModel requestModel)
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

			Models.Income parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Income_CategoryValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Income_MemberValNameModel : RequestLookupModel
		{
			public Income_ViewModel Model { get; set; }
		}

		//
		// GET: /Income/Income_MemberValName
		// POST: /Income/Income_MemberValName
		[ActionName("Income_MemberValName")]
		public ActionResult Income_MemberValName([FromBody] Income_MemberValNameModel requestModel)
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

			Models.Income parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Income_MemberValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Income_SourceValTitleModel : RequestLookupModel
		{
			public Income_ViewModel Model { get; set; }
		}

		//
		// GET: /Income/Income_SourceValTitle
		// POST: /Income/Income_SourceValTitle
		[ActionName("Income_SourceValTitle")]
		public ActionResult Income_SourceValTitle([FromBody] Income_SourceValTitleModel requestModel)
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

			Models.Income parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Income_SourceValTitle_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Income/Income_SaveEdit
		[HttpPost]
		public ActionResult Income_SaveEdit([FromBody] Income_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Income_SaveEdit",
				ViewName = "Income",
				AreaName = "income",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT INCOME]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT INCOME]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class IncomeDocumValidateTickets : RequestDocumValidateTickets
		{
			public Income_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsIncome([FromBody] IncomeDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
