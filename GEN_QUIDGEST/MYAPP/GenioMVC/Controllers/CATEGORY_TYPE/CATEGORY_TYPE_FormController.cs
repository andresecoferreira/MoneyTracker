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
using GenioMVC.ViewModels.Category_type;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER CATEGORY_TYPE]/

namespace GenioMVC.Controllers
{
	public partial class Category_typeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CATEGORY_TYPE_CANCEL = new("CATEGORY_TYPE34342", "Category_type_Cancel", "Category_type") { vueRouteName = "form-CATEGORY_TYPE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CATEGORY_TYPE_SHOW = new("CATEGORY_TYPE34342", "Category_type_Show", "Category_type") { vueRouteName = "form-CATEGORY_TYPE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CATEGORY_TYPE_NEW = new("CATEGORY_TYPE34342", "Category_type_New", "Category_type") { vueRouteName = "form-CATEGORY_TYPE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CATEGORY_TYPE_EDIT = new("CATEGORY_TYPE34342", "Category_type_Edit", "Category_type") { vueRouteName = "form-CATEGORY_TYPE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CATEGORY_TYPE_DUPLICATE = new("CATEGORY_TYPE34342", "Category_type_Duplicate", "Category_type") { vueRouteName = "form-CATEGORY_TYPE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CATEGORY_TYPE_DELETE = new("CATEGORY_TYPE34342", "Category_type_Delete", "Category_type") { vueRouteName = "form-CATEGORY_TYPE", mode = "DELETE" };

		#endregion

		#region Category_type private

		private void FormHistoryLimits_Category_type()
		{

		}

		#endregion

		#region Category_type_Show

// USE /[MANUAL MNT CONTROLLER_SHOW CATEGORY_TYPE]/

		[HttpPost]
		public ActionResult Category_type_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Category_type_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_type_Show_GET",
				AreaName = "category_type",
				Location = ACTION_CATEGORY_TYPE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Category_type();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW CATEGORY_TYPE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Category_type_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET CATEGORY_TYPE]/
		[HttpPost]
		public ActionResult Category_type_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Category_type_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_type_New_GET",
				AreaName = "category_type",
				FormName = "CATEGORY_TYPE",
				Location = ACTION_CATEGORY_TYPE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Category_type();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW CATEGORY_TYPE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Category_type/Category_type_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST CATEGORY_TYPE]/
		[HttpPost]
		public ActionResult Category_type_New([FromBody]Category_type_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Category_type_New",
				ViewName = "Category_type",
				AreaName = "category_type",
				Location = ACTION_CATEGORY_TYPE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW CATEGORY_TYPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX CATEGORY_TYPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX CATEGORY_TYPE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Category_type_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET CATEGORY_TYPE]/
		[HttpPost]
		public ActionResult Category_type_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Category_type_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_type_Edit_GET",
				AreaName = "category_type",
				FormName = "CATEGORY_TYPE",
				Location = ACTION_CATEGORY_TYPE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Category_type();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT CATEGORY_TYPE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Category_type/Category_type_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST CATEGORY_TYPE]/
		[HttpPost]
		public ActionResult Category_type_Edit([FromBody]Category_type_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Category_type_Edit",
				ViewName = "Category_type",
				AreaName = "category_type",
				Location = ACTION_CATEGORY_TYPE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT CATEGORY_TYPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX CATEGORY_TYPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX CATEGORY_TYPE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Category_type_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET CATEGORY_TYPE]/
		[HttpPost]
		public ActionResult Category_type_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Category_type_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_type_Delete_GET",
				AreaName = "category_type",
				FormName = "CATEGORY_TYPE",
				Location = ACTION_CATEGORY_TYPE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Category_type();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE CATEGORY_TYPE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Category_type/Category_type_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST CATEGORY_TYPE]/
		[HttpPost]
		public ActionResult Category_type_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Category_type_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Category_type_Delete",
				ViewName = "Category_type",
				AreaName = "category_type",
				Location = ACTION_CATEGORY_TYPE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE CATEGORY_TYPE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Category_type_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CATEGORY_TYPE");
		}

		#endregion

		#region Category_type_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET CATEGORY_TYPE]/

		[HttpPost]
		public ActionResult Category_type_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Category_type_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_type_Duplicate_GET",
				AreaName = "category_type",
				FormName = "CATEGORY_TYPE",
				Location = ACTION_CATEGORY_TYPE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE CATEGORY_TYPE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Category_type/Category_type_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST CATEGORY_TYPE]/
		[HttpPost]
		public ActionResult Category_type_Duplicate([FromBody]Category_type_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Category_type_Duplicate",
				ViewName = "Category_type",
				AreaName = "category_type",
				Location = ACTION_CATEGORY_TYPE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE CATEGORY_TYPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX CATEGORY_TYPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX CATEGORY_TYPE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Category_type_Cancel

		//
		// GET: /Category_type/Category_type_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET CATEGORY_TYPE]/
		public ActionResult Category_type_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Category_type model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("category_type");

// USE /[MANUAL MNT BEFORE_CANCEL CATEGORY_TYPE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL CATEGORY_TYPE]/

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

				Navigation.SetValue("ForcePrimaryRead_category_type", "true", true);
			}

			Navigation.ClearValue("category_type");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Category_type_ValCategoriesModel : RequestLookupModel
		{
			public Category_type_ViewModel Model { get; set; }
		}

		//
		// GET: /Category_type/Category_type_ValCategories
		// POST: /Category_type/Category_type_ValCategories
		[ActionName("Category_type_ValCategories")]
		public ActionResult Category_type_ValCategories([FromBody] Category_type_ValCategoriesModel requestModel)
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

			Models.Category_type parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Category_type_ValCategories_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Category_type/Category_type_SaveEdit
		[HttpPost]
		public ActionResult Category_type_SaveEdit([FromBody] Category_type_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Category_type_SaveEdit",
				ViewName = "Category_type",
				AreaName = "category_type",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT CATEGORY_TYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT CATEGORY_TYPE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Category_typeDocumValidateTickets : RequestDocumValidateTickets
		{
			public Category_type_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCategory_type([FromBody] Category_typeDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
