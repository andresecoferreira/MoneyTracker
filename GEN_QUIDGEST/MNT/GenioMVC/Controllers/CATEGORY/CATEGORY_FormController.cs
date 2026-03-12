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
using GenioMVC.ViewModels.Category;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER CATEGORY]/

namespace GenioMVC.Controllers
{
	public partial class CategoryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CATEGORY_CANCEL = new("CATEGORY18978", "Category_Cancel", "Category") { vueRouteName = "form-CATEGORY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CATEGORY_SHOW = new("CATEGORY18978", "Category_Show", "Category") { vueRouteName = "form-CATEGORY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CATEGORY_NEW = new("CATEGORY18978", "Category_New", "Category") { vueRouteName = "form-CATEGORY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CATEGORY_EDIT = new("CATEGORY18978", "Category_Edit", "Category") { vueRouteName = "form-CATEGORY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CATEGORY_DUPLICATE = new("CATEGORY18978", "Category_Duplicate", "Category") { vueRouteName = "form-CATEGORY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CATEGORY_DELETE = new("CATEGORY18978", "Category_Delete", "Category") { vueRouteName = "form-CATEGORY", mode = "DELETE" };

		#endregion

		#region Category private

		private void FormHistoryLimits_Category()
		{

		}

		#endregion

		#region Category_Show

// USE /[MANUAL MNT CONTROLLER_SHOW CATEGORY]/

		[HttpPost]
		public ActionResult Category_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_Show_GET",
				AreaName = "category",
				Location = ACTION_CATEGORY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Category();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW CATEGORY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Category_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET CATEGORY]/
		[HttpPost]
		public ActionResult Category_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_New_GET",
				AreaName = "category",
				FormName = "CATEGORY",
				Location = ACTION_CATEGORY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Category();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW CATEGORY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Category/Category_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST CATEGORY]/
		[HttpPost]
		public ActionResult Category_New([FromBody]Category_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Category_New",
				ViewName = "Category",
				AreaName = "category",
				Location = ACTION_CATEGORY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW CATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX CATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX CATEGORY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Category_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET CATEGORY]/
		[HttpPost]
		public ActionResult Category_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_Edit_GET",
				AreaName = "category",
				FormName = "CATEGORY",
				Location = ACTION_CATEGORY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Category();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT CATEGORY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Category/Category_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST CATEGORY]/
		[HttpPost]
		public ActionResult Category_Edit([FromBody]Category_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Category_Edit",
				ViewName = "Category",
				AreaName = "category",
				Location = ACTION_CATEGORY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT CATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX CATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX CATEGORY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Category_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET CATEGORY]/
		[HttpPost]
		public ActionResult Category_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_Delete_GET",
				AreaName = "category",
				FormName = "CATEGORY",
				Location = ACTION_CATEGORY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Category();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE CATEGORY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Category/Category_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST CATEGORY]/
		[HttpPost]
		public ActionResult Category_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Category_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Category_Delete",
				ViewName = "Category",
				AreaName = "category",
				Location = ACTION_CATEGORY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE CATEGORY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Category_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CATEGORY");
		}

		#endregion

		#region Category_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET CATEGORY]/

		[HttpPost]
		public ActionResult Category_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Category_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Category_Duplicate_GET",
				AreaName = "category",
				FormName = "CATEGORY",
				Location = ACTION_CATEGORY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE CATEGORY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Category/Category_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST CATEGORY]/
		[HttpPost]
		public ActionResult Category_Duplicate([FromBody]Category_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Category_Duplicate",
				ViewName = "Category",
				AreaName = "category",
				Location = ACTION_CATEGORY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE CATEGORY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX CATEGORY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX CATEGORY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Category_Cancel

		//
		// GET: /Category/Category_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET CATEGORY]/
		public ActionResult Category_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Category model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("category");

// USE /[MANUAL MNT BEFORE_CANCEL CATEGORY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL CATEGORY]/

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

				Navigation.SetValue("ForcePrimaryRead_category", "true", true);
			}

			Navigation.ClearValue("category");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Category_Category_typeValNameModel : RequestLookupModel
		{
			public Category_ViewModel Model { get; set; }
		}

		//
		// GET: /Category/Category_Category_typeValName
		// POST: /Category/Category_Category_typeValName
		[ActionName("Category_Category_typeValName")]
		public ActionResult Category_Category_typeValName([FromBody] Category_Category_typeValNameModel requestModel)
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

			Models.Category parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Category_Category_typeValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Category/Category_SaveEdit
		[HttpPost]
		public ActionResult Category_SaveEdit([FromBody] Category_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Category_SaveEdit",
				ViewName = "Category",
				AreaName = "category",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT CATEGORY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT CATEGORY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class CategoryDocumValidateTickets : RequestDocumValidateTickets
		{
			public Category_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCategory([FromBody] CategoryDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
