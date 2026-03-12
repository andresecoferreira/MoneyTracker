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

		private static readonly NavigationLocation ACTION_WD_LAST_EXPENSES_CANCEL = new("CANCELAR49513", "Wd_last_expenses_Cancel", "Expense") { vueRouteName = "form-WD_LAST_EXPENSES", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_WD_LAST_EXPENSES_SHOW = new("CONSULTA40695", "Wd_last_expenses_Show", "Expense") { vueRouteName = "form-WD_LAST_EXPENSES", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_WD_LAST_EXPENSES_NEW = new("INSERIR43365", "Wd_last_expenses_New", "Expense") { vueRouteName = "form-WD_LAST_EXPENSES", mode = "NEW" };
		private static readonly NavigationLocation ACTION_WD_LAST_EXPENSES_EDIT = new("EDITAR11616", "Wd_last_expenses_Edit", "Expense") { vueRouteName = "form-WD_LAST_EXPENSES", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_WD_LAST_EXPENSES_DUPLICATE = new("DUPLICAR09748", "Wd_last_expenses_Duplicate", "Expense") { vueRouteName = "form-WD_LAST_EXPENSES", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_WD_LAST_EXPENSES_DELETE = new("APAGAR04097", "Wd_last_expenses_Delete", "Expense") { vueRouteName = "form-WD_LAST_EXPENSES", mode = "DELETE" };

		#endregion

		#region Wd_last_expenses private

		private void FormHistoryLimits_Wd_last_expenses()
		{

		}

		#endregion

		#region Wd_last_expenses_Show

// USE /[MANUAL MNT CONTROLLER_SHOW WD_LAST_EXPENSES]/

		[HttpPost]
		public ActionResult Wd_last_expenses_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Wd_last_expenses_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_Show_GET",
				AreaName = "expense",
				Location = ACTION_WD_LAST_EXPENSES_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wd_last_expenses();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW WD_LAST_EXPENSES]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Wd_last_expenses_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET WD_LAST_EXPENSES]/
		[HttpPost]
		public ActionResult Wd_last_expenses_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Wd_last_expenses_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_New_GET",
				AreaName = "expense",
				FormName = "WD_LAST_EXPENSES",
				Location = ACTION_WD_LAST_EXPENSES_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Wd_last_expenses();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW WD_LAST_EXPENSES]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Expense/Wd_last_expenses_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST WD_LAST_EXPENSES]/
		[HttpPost]
		public ActionResult Wd_last_expenses_New([FromBody]Wd_last_expenses_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_New",
				ViewName = "Wd_last_expenses",
				AreaName = "expense",
				Location = ACTION_WD_LAST_EXPENSES_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW WD_LAST_EXPENSES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX WD_LAST_EXPENSES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX WD_LAST_EXPENSES]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Wd_last_expenses_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET WD_LAST_EXPENSES]/
		[HttpPost]
		public ActionResult Wd_last_expenses_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Wd_last_expenses_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_Edit_GET",
				AreaName = "expense",
				FormName = "WD_LAST_EXPENSES",
				Location = ACTION_WD_LAST_EXPENSES_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wd_last_expenses();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT WD_LAST_EXPENSES]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Expense/Wd_last_expenses_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST WD_LAST_EXPENSES]/
		[HttpPost]
		public ActionResult Wd_last_expenses_Edit([FromBody]Wd_last_expenses_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_Edit",
				ViewName = "Wd_last_expenses",
				AreaName = "expense",
				Location = ACTION_WD_LAST_EXPENSES_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT WD_LAST_EXPENSES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX WD_LAST_EXPENSES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX WD_LAST_EXPENSES]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Wd_last_expenses_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET WD_LAST_EXPENSES]/
		[HttpPost]
		public ActionResult Wd_last_expenses_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Wd_last_expenses_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_Delete_GET",
				AreaName = "expense",
				FormName = "WD_LAST_EXPENSES",
				Location = ACTION_WD_LAST_EXPENSES_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wd_last_expenses();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE WD_LAST_EXPENSES]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Expense/Wd_last_expenses_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST WD_LAST_EXPENSES]/
		[HttpPost]
		public ActionResult Wd_last_expenses_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Wd_last_expenses_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_Delete",
				ViewName = "Wd_last_expenses",
				AreaName = "expense",
				Location = ACTION_WD_LAST_EXPENSES_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE WD_LAST_EXPENSES]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Wd_last_expenses_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("WD_LAST_EXPENSES");
		}

		#endregion

		#region Wd_last_expenses_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET WD_LAST_EXPENSES]/

		[HttpPost]
		public ActionResult Wd_last_expenses_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Wd_last_expenses_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_Duplicate_GET",
				AreaName = "expense",
				FormName = "WD_LAST_EXPENSES",
				Location = ACTION_WD_LAST_EXPENSES_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE WD_LAST_EXPENSES]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Expense/Wd_last_expenses_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST WD_LAST_EXPENSES]/
		[HttpPost]
		public ActionResult Wd_last_expenses_Duplicate([FromBody]Wd_last_expenses_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_Duplicate",
				ViewName = "Wd_last_expenses",
				AreaName = "expense",
				Location = ACTION_WD_LAST_EXPENSES_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE WD_LAST_EXPENSES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX WD_LAST_EXPENSES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX WD_LAST_EXPENSES]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Wd_last_expenses_Cancel

		//
		// GET: /Expense/Wd_last_expenses_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET WD_LAST_EXPENSES]/
		public ActionResult Wd_last_expenses_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Expense model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("expense");

// USE /[MANUAL MNT BEFORE_CANCEL WD_LAST_EXPENSES]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL WD_LAST_EXPENSES]/

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


		public class Wd_last_expenses_ValField001Model : RequestLookupModel
		{
			public Wd_last_expenses_ViewModel Model { get; set; }
		}

		//
		// GET: /Expense/Wd_last_expenses_ValField001
		// POST: /Expense/Wd_last_expenses_ValField001
		[ActionName("Wd_last_expenses_ValField001")]
		public ActionResult Wd_last_expenses_ValField001([FromBody] Wd_last_expenses_ValField001Model requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expense")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_expense");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Expense parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Wd_last_expenses_ValField001_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(5, "");

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Expense/Wd_last_expenses_SaveEdit
		[HttpPost]
		public ActionResult Wd_last_expenses_SaveEdit([FromBody] Wd_last_expenses_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Wd_last_expenses_SaveEdit",
				ViewName = "Wd_last_expenses",
				AreaName = "expense",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT WD_LAST_EXPENSES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT WD_LAST_EXPENSES]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Wd_last_expensesDocumValidateTickets : RequestDocumValidateTickets
		{
			public Wd_last_expenses_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsWd_last_expenses([FromBody] Wd_last_expensesDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
