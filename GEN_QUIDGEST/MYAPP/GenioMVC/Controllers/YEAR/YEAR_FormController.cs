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
using GenioMVC.ViewModels.Year;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER YEAR]/

namespace GenioMVC.Controllers
{
	public partial class YearController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_YEAR_CANCEL = new("YEAR61794", "Year_Cancel", "Year") { vueRouteName = "form-YEAR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_YEAR_SHOW = new("YEAR61794", "Year_Show", "Year") { vueRouteName = "form-YEAR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_YEAR_NEW = new("YEAR61794", "Year_New", "Year") { vueRouteName = "form-YEAR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_YEAR_EDIT = new("YEAR61794", "Year_Edit", "Year") { vueRouteName = "form-YEAR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_YEAR_DUPLICATE = new("YEAR61794", "Year_Duplicate", "Year") { vueRouteName = "form-YEAR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_YEAR_DELETE = new("YEAR61794", "Year_Delete", "Year") { vueRouteName = "form-YEAR", mode = "DELETE" };

		#endregion

		#region Year private

		private void FormHistoryLimits_Year()
		{

		}

		#endregion

		#region Year_Show

// USE /[MANUAL MNT CONTROLLER_SHOW YEAR]/

		[HttpPost]
		public ActionResult Year_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Year_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Year_Show_GET",
				AreaName = "year",
				Location = ACTION_YEAR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Year();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW YEAR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Year_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET YEAR]/
		[HttpPost]
		public ActionResult Year_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Year_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Year_New_GET",
				AreaName = "year",
				FormName = "YEAR",
				Location = ACTION_YEAR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Year();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW YEAR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Year/Year_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST YEAR]/
		[HttpPost]
		public ActionResult Year_New([FromBody]Year_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Year_New",
				ViewName = "Year",
				AreaName = "year",
				Location = ACTION_YEAR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW YEAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX YEAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX YEAR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Year_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET YEAR]/
		[HttpPost]
		public ActionResult Year_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Year_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Year_Edit_GET",
				AreaName = "year",
				FormName = "YEAR",
				Location = ACTION_YEAR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Year();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT YEAR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Year/Year_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST YEAR]/
		[HttpPost]
		public ActionResult Year_Edit([FromBody]Year_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Year_Edit",
				ViewName = "Year",
				AreaName = "year",
				Location = ACTION_YEAR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT YEAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX YEAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX YEAR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Year_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET YEAR]/
		[HttpPost]
		public ActionResult Year_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Year_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Year_Delete_GET",
				AreaName = "year",
				FormName = "YEAR",
				Location = ACTION_YEAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Year();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE YEAR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Year/Year_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST YEAR]/
		[HttpPost]
		public ActionResult Year_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Year_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Year_Delete",
				ViewName = "Year",
				AreaName = "year",
				Location = ACTION_YEAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE YEAR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Year_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("YEAR");
		}

		#endregion

		#region Year_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET YEAR]/

		[HttpPost]
		public ActionResult Year_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Year_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Year_Duplicate_GET",
				AreaName = "year",
				FormName = "YEAR",
				Location = ACTION_YEAR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE YEAR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Year/Year_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST YEAR]/
		[HttpPost]
		public ActionResult Year_Duplicate([FromBody]Year_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Year_Duplicate",
				ViewName = "Year",
				AreaName = "year",
				Location = ACTION_YEAR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE YEAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX YEAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX YEAR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Year_Cancel

		//
		// GET: /Year/Year_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET YEAR]/
		public ActionResult Year_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Year model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("year");

// USE /[MANUAL MNT BEFORE_CANCEL YEAR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL YEAR]/

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

				Navigation.SetValue("ForcePrimaryRead_year", "true", true);
			}

			Navigation.ClearValue("year");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Year/Year_SaveEdit
		[HttpPost]
		public ActionResult Year_SaveEdit([FromBody] Year_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Year_SaveEdit",
				ViewName = "Year",
				AreaName = "year",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT YEAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT YEAR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class YearDocumValidateTickets : RequestDocumValidateTickets
		{
			public Year_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsYear([FromBody] YearDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
