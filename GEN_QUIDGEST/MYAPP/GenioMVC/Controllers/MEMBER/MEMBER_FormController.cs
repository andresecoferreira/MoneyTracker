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
using GenioMVC.ViewModels.Member;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER MEMBER]/

namespace GenioMVC.Controllers
{
	public partial class MemberController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MEMBER_CANCEL = new("MEMBER00534", "Member_Cancel", "Member") { vueRouteName = "form-MEMBER", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MEMBER_SHOW = new("MEMBER00534", "Member_Show", "Member") { vueRouteName = "form-MEMBER", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MEMBER_NEW = new("MEMBER00534", "Member_New", "Member") { vueRouteName = "form-MEMBER", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MEMBER_EDIT = new("MEMBER00534", "Member_Edit", "Member") { vueRouteName = "form-MEMBER", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MEMBER_DUPLICATE = new("MEMBER00534", "Member_Duplicate", "Member") { vueRouteName = "form-MEMBER", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MEMBER_DELETE = new("MEMBER00534", "Member_Delete", "Member") { vueRouteName = "form-MEMBER", mode = "DELETE" };

		#endregion

		#region Member private

		private void FormHistoryLimits_Member()
		{

		}

		#endregion

		#region Member_Show

// USE /[MANUAL MNT CONTROLLER_SHOW MEMBER]/

		[HttpPost]
		public ActionResult Member_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Member_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_Show_GET",
				AreaName = "member",
				Location = ACTION_MEMBER_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Member();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW MEMBER]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Member_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET MEMBER]/
		[HttpPost]
		public ActionResult Member_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Member_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_New_GET",
				AreaName = "member",
				FormName = "MEMBER",
				Location = ACTION_MEMBER_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Member();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW MEMBER]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Member/Member_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST MEMBER]/
		[HttpPost]
		public ActionResult Member_New([FromBody]Member_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Member_New",
				ViewName = "Member",
				AreaName = "member",
				Location = ACTION_MEMBER_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW MEMBER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX MEMBER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX MEMBER]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Member_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET MEMBER]/
		[HttpPost]
		public ActionResult Member_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Member_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_Edit_GET",
				AreaName = "member",
				FormName = "MEMBER",
				Location = ACTION_MEMBER_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Member();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT MEMBER]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Member/Member_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST MEMBER]/
		[HttpPost]
		public ActionResult Member_Edit([FromBody]Member_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Member_Edit",
				ViewName = "Member",
				AreaName = "member",
				Location = ACTION_MEMBER_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT MEMBER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX MEMBER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX MEMBER]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Member_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET MEMBER]/
		[HttpPost]
		public ActionResult Member_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Member_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_Delete_GET",
				AreaName = "member",
				FormName = "MEMBER",
				Location = ACTION_MEMBER_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Member();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE MEMBER]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Member/Member_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST MEMBER]/
		[HttpPost]
		public ActionResult Member_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Member_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Member_Delete",
				ViewName = "Member",
				AreaName = "member",
				Location = ACTION_MEMBER_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE MEMBER]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Member_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MEMBER");
		}

		#endregion

		#region Member_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET MEMBER]/

		[HttpPost]
		public ActionResult Member_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Member_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_Duplicate_GET",
				AreaName = "member",
				FormName = "MEMBER",
				Location = ACTION_MEMBER_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE MEMBER]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Member/Member_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST MEMBER]/
		[HttpPost]
		public ActionResult Member_Duplicate([FromBody]Member_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Member_Duplicate",
				ViewName = "Member",
				AreaName = "member",
				Location = ACTION_MEMBER_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE MEMBER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX MEMBER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX MEMBER]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Member_Cancel

		//
		// GET: /Member/Member_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET MEMBER]/
		public ActionResult Member_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Member model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("member");

// USE /[MANUAL MNT BEFORE_CANCEL MEMBER]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL MEMBER]/

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

				Navigation.SetValue("ForcePrimaryRead_member", "true", true);
			}

			Navigation.ClearValue("member");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Member_GroupValNameModel : RequestLookupModel
		{
			public Member_ViewModel Model { get; set; }
		}

		//
		// GET: /Member/Member_GroupValName
		// POST: /Member/Member_GroupValName
		[ActionName("Member_GroupValName")]
		public ActionResult Member_GroupValName([FromBody] Member_GroupValNameModel requestModel)
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

			Models.Member parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Member_GroupValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Member/Member_SaveEdit
		[HttpPost]
		public ActionResult Member_SaveEdit([FromBody] Member_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Member_SaveEdit",
				ViewName = "Member",
				AreaName = "member",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT MEMBER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT MEMBER]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class MemberDocumValidateTickets : RequestDocumValidateTickets
		{
			public Member_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsMember([FromBody] MemberDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
