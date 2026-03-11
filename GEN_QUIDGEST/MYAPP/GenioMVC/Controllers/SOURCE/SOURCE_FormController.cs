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
using GenioMVC.ViewModels.Source;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER SOURCE]/

namespace GenioMVC.Controllers
{
	public partial class SourceController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_SOURCE_CANCEL = new("ACCOUNT64260", "Source_Cancel", "Source") { vueRouteName = "form-SOURCE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_SOURCE_SHOW = new("ACCOUNT64260", "Source_Show", "Source") { vueRouteName = "form-SOURCE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_SOURCE_NEW = new("ACCOUNT64260", "Source_New", "Source") { vueRouteName = "form-SOURCE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_SOURCE_EDIT = new("ACCOUNT64260", "Source_Edit", "Source") { vueRouteName = "form-SOURCE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_SOURCE_DUPLICATE = new("ACCOUNT64260", "Source_Duplicate", "Source") { vueRouteName = "form-SOURCE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_SOURCE_DELETE = new("ACCOUNT64260", "Source_Delete", "Source") { vueRouteName = "form-SOURCE", mode = "DELETE" };

		#endregion

		#region Source private

		private void FormHistoryLimits_Source()
		{

		}

		#endregion

		#region Source_Show

// USE /[MANUAL MNT CONTROLLER_SHOW SOURCE]/

		[HttpPost]
		public ActionResult Source_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Source_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Source_Show_GET",
				AreaName = "source",
				Location = ACTION_SOURCE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Source();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW SOURCE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Source_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET SOURCE]/
		[HttpPost]
		public ActionResult Source_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Source_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Source_New_GET",
				AreaName = "source",
				FormName = "SOURCE",
				Location = ACTION_SOURCE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Source();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW SOURCE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Source/Source_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST SOURCE]/
		[HttpPost]
		public ActionResult Source_New([FromBody]Source_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Source_New",
				ViewName = "Source",
				AreaName = "source",
				Location = ACTION_SOURCE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW SOURCE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX SOURCE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX SOURCE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Source_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET SOURCE]/
		[HttpPost]
		public ActionResult Source_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Source_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Source_Edit_GET",
				AreaName = "source",
				FormName = "SOURCE",
				Location = ACTION_SOURCE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Source();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT SOURCE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Source/Source_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST SOURCE]/
		[HttpPost]
		public ActionResult Source_Edit([FromBody]Source_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Source_Edit",
				ViewName = "Source",
				AreaName = "source",
				Location = ACTION_SOURCE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT SOURCE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX SOURCE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX SOURCE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Source_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET SOURCE]/
		[HttpPost]
		public ActionResult Source_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Source_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Source_Delete_GET",
				AreaName = "source",
				FormName = "SOURCE",
				Location = ACTION_SOURCE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Source();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE SOURCE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Source/Source_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST SOURCE]/
		[HttpPost]
		public ActionResult Source_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Source_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Source_Delete",
				ViewName = "Source",
				AreaName = "source",
				Location = ACTION_SOURCE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE SOURCE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Source_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("SOURCE");
		}

		#endregion

		#region Source_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET SOURCE]/

		[HttpPost]
		public ActionResult Source_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Source_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Source_Duplicate_GET",
				AreaName = "source",
				FormName = "SOURCE",
				Location = ACTION_SOURCE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE SOURCE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Source/Source_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST SOURCE]/
		[HttpPost]
		public ActionResult Source_Duplicate([FromBody]Source_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Source_Duplicate",
				ViewName = "Source",
				AreaName = "source",
				Location = ACTION_SOURCE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE SOURCE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX SOURCE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX SOURCE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Source_Cancel

		//
		// GET: /Source/Source_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET SOURCE]/
		public ActionResult Source_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Source model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("source");

// USE /[MANUAL MNT BEFORE_CANCEL SOURCE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL SOURCE]/

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

				Navigation.SetValue("ForcePrimaryRead_source", "true", true);
			}

			Navigation.ClearValue("source");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Source_MemberValNameModel : RequestLookupModel
		{
			public Source_ViewModel Model { get; set; }
		}

		//
		// GET: /Source/Source_MemberValName
		// POST: /Source/Source_MemberValName
		[ActionName("Source_MemberValName")]
		public ActionResult Source_MemberValName([FromBody] Source_MemberValNameModel requestModel)
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

			Models.Source parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Source_MemberValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Source/Source_SaveEdit
		[HttpPost]
		public ActionResult Source_SaveEdit([FromBody] Source_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Source_SaveEdit",
				ViewName = "Source",
				AreaName = "source",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT SOURCE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT SOURCE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class SourceDocumValidateTickets : RequestDocumValidateTickets
		{
			public Source_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsSource([FromBody] SourceDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
