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
using GenioMVC.ViewModels.Expense;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER EXPENSE]/

namespace GenioMVC.Controllers
{
	public partial class ExpenseController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EXPENSE_CANCEL = new("EXPENSE49437", "Expense_Cancel", "Expense") { vueRouteName = "form-EXPENSE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EXPENSE_SHOW = new("EXPENSE49437", "Expense_Show", "Expense") { vueRouteName = "form-EXPENSE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EXPENSE_NEW = new("EXPENSE49437", "Expense_New", "Expense") { vueRouteName = "form-EXPENSE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EXPENSE_EDIT = new("EXPENSE49437", "Expense_Edit", "Expense") { vueRouteName = "form-EXPENSE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EXPENSE_DUPLICATE = new("EXPENSE49437", "Expense_Duplicate", "Expense") { vueRouteName = "form-EXPENSE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EXPENSE_DELETE = new("EXPENSE49437", "Expense_Delete", "Expense") { vueRouteName = "form-EXPENSE", mode = "DELETE" };

		#endregion

		#region Expense private

		private void FormHistoryLimits_Expense()
		{

		}

		#endregion

		#region Expense_Show

// USE /[MANUAL MNT CONTROLLER_SHOW EXPENSE]/

		[HttpPost]
		public ActionResult Expense_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Expense_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Expense_Show_GET",
				AreaName = "expense",
				Location = ACTION_EXPENSE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Expense();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW EXPENSE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Expense_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET EXPENSE]/
		[HttpPost]
		public ActionResult Expense_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Expense_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Expense_New_GET",
				AreaName = "expense",
				FormName = "EXPENSE",
				Location = ACTION_EXPENSE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Expense();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW EXPENSE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Expense/Expense_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST EXPENSE]/
		[HttpPost]
		public ActionResult Expense_New([FromBody]Expense_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Expense_New",
				ViewName = "Expense",
				AreaName = "expense",
				Location = ACTION_EXPENSE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW EXPENSE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX EXPENSE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX EXPENSE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Expense_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET EXPENSE]/
		[HttpPost]
		public ActionResult Expense_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Expense_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Expense_Edit_GET",
				AreaName = "expense",
				FormName = "EXPENSE",
				Location = ACTION_EXPENSE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Expense();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT EXPENSE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Expense/Expense_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST EXPENSE]/
		[HttpPost]
		public ActionResult Expense_Edit([FromBody]Expense_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Expense_Edit",
				ViewName = "Expense",
				AreaName = "expense",
				Location = ACTION_EXPENSE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT EXPENSE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX EXPENSE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX EXPENSE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Expense_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET EXPENSE]/
		[HttpPost]
		public ActionResult Expense_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Expense_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Expense_Delete_GET",
				AreaName = "expense",
				FormName = "EXPENSE",
				Location = ACTION_EXPENSE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Expense();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE EXPENSE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Expense/Expense_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST EXPENSE]/
		[HttpPost]
		public ActionResult Expense_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Expense_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Expense_Delete",
				ViewName = "Expense",
				AreaName = "expense",
				Location = ACTION_EXPENSE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE EXPENSE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Expense_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EXPENSE");
		}

		#endregion

		#region Expense_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET EXPENSE]/

		[HttpPost]
		public ActionResult Expense_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Expense_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Expense_Duplicate_GET",
				AreaName = "expense",
				FormName = "EXPENSE",
				Location = ACTION_EXPENSE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE EXPENSE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Expense/Expense_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST EXPENSE]/
		[HttpPost]
		public ActionResult Expense_Duplicate([FromBody]Expense_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Expense_Duplicate",
				ViewName = "Expense",
				AreaName = "expense",
				Location = ACTION_EXPENSE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE EXPENSE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX EXPENSE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX EXPENSE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Expense_Cancel

		//
		// GET: /Expense/Expense_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET EXPENSE]/
		public ActionResult Expense_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Expense model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("expense");

// USE /[MANUAL MNT BEFORE_CANCEL EXPENSE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL EXPENSE]/

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

				Navigation.SetValue("ForcePrimaryRead_expense", "true", true);
			}

			Navigation.ClearValue("expense");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Expense_CategoryValNameModel : RequestLookupModel
		{
			public Expense_ViewModel Model { get; set; }
		}

		//
		// GET: /Expense/Expense_CategoryValName
		// POST: /Expense/Expense_CategoryValName
		[ActionName("Expense_CategoryValName")]
		public ActionResult Expense_CategoryValName([FromBody] Expense_CategoryValNameModel requestModel)
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

			Models.Expense parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Expense_CategoryValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Expense_MemberValNameModel : RequestLookupModel
		{
			public Expense_ViewModel Model { get; set; }
		}

		//
		// GET: /Expense/Expense_MemberValName
		// POST: /Expense/Expense_MemberValName
		[ActionName("Expense_MemberValName")]
		public ActionResult Expense_MemberValName([FromBody] Expense_MemberValNameModel requestModel)
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

			Models.Expense parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Expense_MemberValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Expense_SourceValTitleModel : RequestLookupModel
		{
			public Expense_ViewModel Model { get; set; }
		}

		//
		// GET: /Expense/Expense_SourceValTitle
		// POST: /Expense/Expense_SourceValTitle
		[ActionName("Expense_SourceValTitle")]
		public ActionResult Expense_SourceValTitle([FromBody] Expense_SourceValTitleModel requestModel)
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

			Models.Expense parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Expense_SourceValTitle_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Expense/Expense_SaveEdit
		[HttpPost]
		public ActionResult Expense_SaveEdit([FromBody] Expense_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Expense_SaveEdit",
				ViewName = "Expense",
				AreaName = "expense",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT EXPENSE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT EXPENSE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ExpenseDocumValidateTickets : RequestDocumValidateTickets
		{
			public Expense_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsExpense([FromBody] ExpenseDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}

		/// <summary>
		/// Stores a new document, in the Docums table, associated to field INVOICE
		/// </summary>
		/// <param name="requestModel">The request model with the document and ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFileExpenseInvoice([FromForm] RequestDocumsCreateModel requestModel)
		{
			List<string> extensions = [];
			return base.SetFile(requestModel.Ticket, requestModel.Mode, requestModel.Version, extensions);
		}
	}
}
