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
using GenioMVC.ViewModels.Group;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER GROUP]/

namespace GenioMVC.Controllers
{
	public partial class GroupController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GROUP_CANCEL = new("GROUP38232", "Group_Cancel", "Group") { vueRouteName = "form-GROUP", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GROUP_SHOW = new("GROUP38232", "Group_Show", "Group") { vueRouteName = "form-GROUP", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GROUP_NEW = new("GROUP38232", "Group_New", "Group") { vueRouteName = "form-GROUP", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GROUP_EDIT = new("GROUP38232", "Group_Edit", "Group") { vueRouteName = "form-GROUP", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GROUP_DUPLICATE = new("GROUP38232", "Group_Duplicate", "Group") { vueRouteName = "form-GROUP", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GROUP_DELETE = new("GROUP38232", "Group_Delete", "Group") { vueRouteName = "form-GROUP", mode = "DELETE" };

		#endregion

		#region Group private

		private void FormHistoryLimits_Group()
		{

		}

		#endregion

		#region Group_Show

// USE /[MANUAL MNT CONTROLLER_SHOW GROUP]/

		[HttpPost]
		public ActionResult Group_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Group_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_Show_GET",
				AreaName = "group",
				Location = ACTION_GROUP_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Group();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW GROUP]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Group_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET GROUP]/
		[HttpPost]
		public ActionResult Group_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Group_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_New_GET",
				AreaName = "group",
				FormName = "GROUP",
				Location = ACTION_GROUP_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Group();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW GROUP]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Group/Group_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST GROUP]/
		[HttpPost]
		public ActionResult Group_New([FromBody]Group_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Group_New",
				ViewName = "Group",
				AreaName = "group",
				Location = ACTION_GROUP_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW GROUP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX GROUP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX GROUP]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Group_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET GROUP]/
		[HttpPost]
		public ActionResult Group_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Group_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_Edit_GET",
				AreaName = "group",
				FormName = "GROUP",
				Location = ACTION_GROUP_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Group();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT GROUP]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Group/Group_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST GROUP]/
		[HttpPost]
		public ActionResult Group_Edit([FromBody]Group_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Group_Edit",
				ViewName = "Group",
				AreaName = "group",
				Location = ACTION_GROUP_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT GROUP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX GROUP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX GROUP]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Group_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET GROUP]/
		[HttpPost]
		public ActionResult Group_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Group_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_Delete_GET",
				AreaName = "group",
				FormName = "GROUP",
				Location = ACTION_GROUP_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Group();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE GROUP]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Group/Group_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST GROUP]/
		[HttpPost]
		public ActionResult Group_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Group_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Group_Delete",
				ViewName = "Group",
				AreaName = "group",
				Location = ACTION_GROUP_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE GROUP]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Group_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GROUP");
		}

		#endregion

		#region Group_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET GROUP]/

		[HttpPost]
		public ActionResult Group_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Group_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Group_Duplicate_GET",
				AreaName = "group",
				FormName = "GROUP",
				Location = ACTION_GROUP_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE GROUP]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Group/Group_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST GROUP]/
		[HttpPost]
		public ActionResult Group_Duplicate([FromBody]Group_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Group_Duplicate",
				ViewName = "Group",
				AreaName = "group",
				Location = ACTION_GROUP_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE GROUP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX GROUP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX GROUP]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Group_Cancel

		//
		// GET: /Group/Group_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET GROUP]/
		public ActionResult Group_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Group model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("group");

// USE /[MANUAL MNT BEFORE_CANCEL GROUP]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL GROUP]/

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

				Navigation.SetValue("ForcePrimaryRead_group", "true", true);
			}

			Navigation.ClearValue("group");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Group_ValMembersModel : RequestLookupModel
		{
			public Group_ViewModel Model { get; set; }
		}

		//
		// GET: /Group/Group_ValMembers
		// POST: /Group/Group_ValMembers
		[ActionName("Group_ValMembers")]
		public ActionResult Group_ValMembers([FromBody] Group_ValMembersModel requestModel)
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

			Models.Group parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Group_ValMembers_ViewModel model = new(m_userContext, parentCtx);

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

		public class Group_ValMember_userModel : RequestLookupModel
		{
			public Group_ViewModel Model { get; set; }
		}

		//
		// GET: /Group/Group_ValMember_user
		// POST: /Group/Group_ValMember_user
		[ActionName("Group_ValMember_user")]
		public ActionResult Group_ValMember_user([FromBody] Group_ValMember_userModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_member_psw")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_member_psw");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Group parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Group_ValMember_user_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Group/Group_SaveEdit
		[HttpPost]
		public ActionResult Group_SaveEdit([FromBody] Group_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Group_SaveEdit",
				ViewName = "Group",
				AreaName = "group",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT GROUP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT GROUP]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class GroupDocumValidateTickets : RequestDocumValidateTickets
		{
			public Group_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsGroup([FromBody] GroupDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
