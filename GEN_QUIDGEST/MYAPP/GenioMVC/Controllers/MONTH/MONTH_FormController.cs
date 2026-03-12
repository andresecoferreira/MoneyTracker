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
using GenioMVC.ViewModels.Month;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER MONTH]/

namespace GenioMVC.Controllers
{
	public partial class MonthController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MONTH_CANCEL = new("MONTH46035", "Month_Cancel", "Month") { vueRouteName = "form-MONTH", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MONTH_SHOW = new("MONTH46035", "Month_Show", "Month") { vueRouteName = "form-MONTH", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MONTH_NEW = new("MONTH46035", "Month_New", "Month") { vueRouteName = "form-MONTH", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MONTH_EDIT = new("MONTH46035", "Month_Edit", "Month") { vueRouteName = "form-MONTH", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MONTH_DUPLICATE = new("MONTH46035", "Month_Duplicate", "Month") { vueRouteName = "form-MONTH", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MONTH_DELETE = new("MONTH46035", "Month_Delete", "Month") { vueRouteName = "form-MONTH", mode = "DELETE" };

		#endregion

		#region Month private

		private void FormHistoryLimits_Month()
		{

		}

		#endregion

		#region Month_Show

// USE /[MANUAL MNT CONTROLLER_SHOW MONTH]/

		[HttpPost]
		public ActionResult Month_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Month_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Month_Show_GET",
				AreaName = "month",
				Location = ACTION_MONTH_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Month();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW MONTH]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Month_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET MONTH]/
		[HttpPost]
		public ActionResult Month_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Month_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Month_New_GET",
				AreaName = "month",
				FormName = "MONTH",
				Location = ACTION_MONTH_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Month();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW MONTH]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Month/Month_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST MONTH]/
		[HttpPost]
		public ActionResult Month_New([FromBody]Month_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Month_New",
				ViewName = "Month",
				AreaName = "month",
				Location = ACTION_MONTH_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW MONTH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX MONTH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX MONTH]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Month_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET MONTH]/
		[HttpPost]
		public ActionResult Month_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Month_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Month_Edit_GET",
				AreaName = "month",
				FormName = "MONTH",
				Location = ACTION_MONTH_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Month();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT MONTH]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Month/Month_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST MONTH]/
		[HttpPost]
		public ActionResult Month_Edit([FromBody]Month_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Month_Edit",
				ViewName = "Month",
				AreaName = "month",
				Location = ACTION_MONTH_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT MONTH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX MONTH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX MONTH]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Month_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET MONTH]/
		[HttpPost]
		public ActionResult Month_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Month_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Month_Delete_GET",
				AreaName = "month",
				FormName = "MONTH",
				Location = ACTION_MONTH_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Month();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE MONTH]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Month/Month_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST MONTH]/
		[HttpPost]
		public ActionResult Month_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Month_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Month_Delete",
				ViewName = "Month",
				AreaName = "month",
				Location = ACTION_MONTH_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE MONTH]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Month_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MONTH");
		}

		#endregion

		#region Month_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET MONTH]/

		[HttpPost]
		public ActionResult Month_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Month_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Month_Duplicate_GET",
				AreaName = "month",
				FormName = "MONTH",
				Location = ACTION_MONTH_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE MONTH]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Month/Month_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST MONTH]/
		[HttpPost]
		public ActionResult Month_Duplicate([FromBody]Month_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Month_Duplicate",
				ViewName = "Month",
				AreaName = "month",
				Location = ACTION_MONTH_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE MONTH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX MONTH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX MONTH]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Month_Cancel

		//
		// GET: /Month/Month_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET MONTH]/
		public ActionResult Month_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Month model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("month");

// USE /[MANUAL MNT BEFORE_CANCEL MONTH]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL MONTH]/

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

				Navigation.SetValue("ForcePrimaryRead_month", "true", true);
			}

			Navigation.ClearValue("month");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Month_YearValYear_numberModel : RequestLookupModel
		{
			public Month_ViewModel Model { get; set; }
		}

		//
		// GET: /Month/Month_YearValYear_number
		// POST: /Month/Month_YearValYear_number
		[ActionName("Month_YearValYear_number")]
		public ActionResult Month_YearValYear_number([FromBody] Month_YearValYear_numberModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_year")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_year");
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

			Models.Month parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Month_YearValYear_number_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Month/Month_SaveEdit
		[HttpPost]
		public ActionResult Month_SaveEdit([FromBody] Month_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Month_SaveEdit",
				ViewName = "Month",
				AreaName = "month",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT MONTH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT MONTH]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class MonthDocumValidateTickets : RequestDocumValidateTickets
		{
			public Month_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsMonth([FromBody] MonthDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
