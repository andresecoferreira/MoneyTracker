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
using GenioMVC.ViewModels.Group_psw;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER GROUP_PSW]/

namespace GenioMVC.Controllers
{
	public partial class Group_pswController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GROUP_PSW_CANCEL = new("GROUP_PSW08201", "Group_psw_Cancel", "Group_psw") { vueRouteName = "form-GROUP_PSW", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GROUP_PSW_SHOW = new("GROUP_PSW08201", "Group_psw_Show", "Group_psw") { vueRouteName = "form-GROUP_PSW", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GROUP_PSW_NEW = new("GROUP_PSW08201", "Group_psw_New", "Group_psw") { vueRouteName = "form-GROUP_PSW", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GROUP_PSW_EDIT = new("GROUP_PSW08201", "Group_psw_Edit", "Group_psw") { vueRouteName = "form-GROUP_PSW", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GROUP_PSW_DUPLICATE = new("GROUP_PSW08201", "Group_psw_Duplicate", "Group_psw") { vueRouteName = "form-GROUP_PSW", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GROUP_PSW_DELETE = new("GROUP_PSW08201", "Group_psw_Delete", "Group_psw") { vueRouteName = "form-GROUP_PSW", mode = "DELETE" };

		#endregion

		#region Group_psw private

		private void FormHistoryLimits_Group_psw()
		{

		}

		#endregion

		#region Group_psw_Show

// USE /[MANUAL MNT CONTROLLER_SHOW GROUP_PSW]/

		[HttpPost]
		public ActionResult Group_psw_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Group_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_Show_GET",
				AreaName = "group_psw",
				Location = ACTION_GROUP_PSW_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Group_psw();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW GROUP_PSW]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Group_psw_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET GROUP_PSW]/
		[HttpPost]
		public ActionResult Group_psw_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Group_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_New_GET",
				AreaName = "group_psw",
				FormName = "GROUP_PSW",
				Location = ACTION_GROUP_PSW_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Group_psw();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW GROUP_PSW]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Group_psw/Group_psw_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST GROUP_PSW]/
		[HttpPost]
		public ActionResult Group_psw_New([FromBody]Group_psw_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_New",
				ViewName = "Group_psw",
				AreaName = "group_psw",
				Location = ACTION_GROUP_PSW_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW GROUP_PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX GROUP_PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX GROUP_PSW]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Group_psw_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET GROUP_PSW]/
		[HttpPost]
		public ActionResult Group_psw_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Group_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_Edit_GET",
				AreaName = "group_psw",
				FormName = "GROUP_PSW",
				Location = ACTION_GROUP_PSW_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Group_psw();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT GROUP_PSW]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Group_psw/Group_psw_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST GROUP_PSW]/
		[HttpPost]
		public ActionResult Group_psw_Edit([FromBody]Group_psw_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_Edit",
				ViewName = "Group_psw",
				AreaName = "group_psw",
				Location = ACTION_GROUP_PSW_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT GROUP_PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX GROUP_PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX GROUP_PSW]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Group_psw_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET GROUP_PSW]/
		[HttpPost]
		public ActionResult Group_psw_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Group_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_Delete_GET",
				AreaName = "group_psw",
				FormName = "GROUP_PSW",
				Location = ACTION_GROUP_PSW_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Group_psw();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE GROUP_PSW]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Group_psw/Group_psw_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST GROUP_PSW]/
		[HttpPost]
		public ActionResult Group_psw_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Group_psw_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Group_psw_Delete",
				ViewName = "Group_psw",
				AreaName = "group_psw",
				Location = ACTION_GROUP_PSW_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE GROUP_PSW]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Group_psw_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GROUP_PSW");
		}

		#endregion

		#region Group_psw_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET GROUP_PSW]/

		[HttpPost]
		public ActionResult Group_psw_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Group_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_Duplicate_GET",
				AreaName = "group_psw",
				FormName = "GROUP_PSW",
				Location = ACTION_GROUP_PSW_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE GROUP_PSW]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Group_psw/Group_psw_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST GROUP_PSW]/
		[HttpPost]
		public ActionResult Group_psw_Duplicate([FromBody]Group_psw_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_Duplicate",
				ViewName = "Group_psw",
				AreaName = "group_psw",
				Location = ACTION_GROUP_PSW_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE GROUP_PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX GROUP_PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX GROUP_PSW]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Group_psw_Cancel

		//
		// GET: /Group_psw/Group_psw_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET GROUP_PSW]/
		public ActionResult Group_psw_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Group_psw model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("group_psw");

// USE /[MANUAL MNT BEFORE_CANCEL GROUP_PSW]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL GROUP_PSW]/

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

				Navigation.SetValue("ForcePrimaryRead_group_psw", "true", true);
			}

			Navigation.ClearValue("group_psw");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Group_psw_GroupValNameModel : RequestLookupModel
		{
			public Group_psw_ViewModel Model { get; set; }
		}

		//
		// GET: /Group_psw/Group_psw_GroupValName
		// POST: /Group_psw/Group_psw_GroupValName
		[ActionName("Group_psw_GroupValName")]
		public ActionResult Group_psw_GroupValName([FromBody] Group_psw_GroupValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_group")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_group");
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

			Models.Group_psw parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Group_psw_GroupValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Group_psw_PswValNomeModel : RequestLookupModel
		{
			public Group_psw_ViewModel Model { get; set; }
		}

		//
		// GET: /Group_psw/Group_psw_PswValNome
		// POST: /Group_psw/Group_psw_PswValNome
		[ActionName("Group_psw_PswValNome")]
		public ActionResult Group_psw_PswValNome([FromBody] Group_psw_PswValNomeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_psw")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_psw");
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

			Models.Group_psw parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Group_psw_PswValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Group_psw/Group_psw_SaveEdit
		[HttpPost]
		public ActionResult Group_psw_SaveEdit([FromBody] Group_psw_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Group_psw_SaveEdit",
				ViewName = "Group_psw",
				AreaName = "group_psw",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT GROUP_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT GROUP_PSW]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Group_pswDocumValidateTickets : RequestDocumValidateTickets
		{
			public Group_psw_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsGroup_psw([FromBody] Group_pswDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
