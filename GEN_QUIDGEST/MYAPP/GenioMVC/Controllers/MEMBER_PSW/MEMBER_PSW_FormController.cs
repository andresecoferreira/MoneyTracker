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
using GenioMVC.ViewModels.Member_psw;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL MNT INCLUDE_CONTROLLER MEMBER_PSW]/

namespace GenioMVC.Controllers
{
	public partial class Member_pswController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MEMBER_PSW_CANCEL = new("MEMBER_PSW31555", "Member_psw_Cancel", "Member_psw") { vueRouteName = "form-MEMBER_PSW", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MEMBER_PSW_SHOW = new("MEMBER_PSW31555", "Member_psw_Show", "Member_psw") { vueRouteName = "form-MEMBER_PSW", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MEMBER_PSW_NEW = new("MEMBER_PSW31555", "Member_psw_New", "Member_psw") { vueRouteName = "form-MEMBER_PSW", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MEMBER_PSW_EDIT = new("MEMBER_PSW31555", "Member_psw_Edit", "Member_psw") { vueRouteName = "form-MEMBER_PSW", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MEMBER_PSW_DUPLICATE = new("MEMBER_PSW31555", "Member_psw_Duplicate", "Member_psw") { vueRouteName = "form-MEMBER_PSW", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MEMBER_PSW_DELETE = new("MEMBER_PSW31555", "Member_psw_Delete", "Member_psw") { vueRouteName = "form-MEMBER_PSW", mode = "DELETE" };

		#endregion

		#region Member_psw private

		private void FormHistoryLimits_Member_psw()
		{

		}

		#endregion

		#region Member_psw_Show

// USE /[MANUAL MNT CONTROLLER_SHOW MEMBER_PSW]/

		[HttpPost]
		public ActionResult Member_psw_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Member_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_Show_GET",
				AreaName = "member_psw",
				Location = ACTION_MEMBER_PSW_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Member_psw();
// USE /[MANUAL MNT BEFORE_LOAD_SHOW MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_SHOW MEMBER_PSW]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Member_psw_New

// USE /[MANUAL MNT CONTROLLER_NEW_GET MEMBER_PSW]/
		[HttpPost]
		public ActionResult Member_psw_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Member_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_New_GET",
				AreaName = "member_psw",
				FormName = "MEMBER_PSW",
				Location = ACTION_MEMBER_PSW_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Member_psw();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW MEMBER_PSW]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Member_psw/Member_psw_New
// USE /[MANUAL MNT CONTROLLER_NEW_POST MEMBER_PSW]/
		[HttpPost]
		public ActionResult Member_psw_New([FromBody]Member_psw_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_New",
				ViewName = "Member_psw",
				AreaName = "member_psw",
				Location = ACTION_MEMBER_PSW_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_NEW MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_NEW MEMBER_PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_NEW_EX MEMBER_PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_NEW_EX MEMBER_PSW]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Member_psw_Edit

// USE /[MANUAL MNT CONTROLLER_EDIT_GET MEMBER_PSW]/
		[HttpPost]
		public ActionResult Member_psw_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Member_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_Edit_GET",
				AreaName = "member_psw",
				FormName = "MEMBER_PSW",
				Location = ACTION_MEMBER_PSW_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Member_psw();
// USE /[MANUAL MNT BEFORE_LOAD_EDIT MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT MEMBER_PSW]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Member_psw/Member_psw_Edit
// USE /[MANUAL MNT CONTROLLER_EDIT_POST MEMBER_PSW]/
		[HttpPost]
		public ActionResult Member_psw_Edit([FromBody]Member_psw_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_Edit",
				ViewName = "Member_psw",
				AreaName = "member_psw",
				Location = ACTION_MEMBER_PSW_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_EDIT MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_EDIT MEMBER_PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_EDIT_EX MEMBER_PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_EDIT_EX MEMBER_PSW]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Member_psw_Delete

// USE /[MANUAL MNT CONTROLLER_DELETE_GET MEMBER_PSW]/
		[HttpPost]
		public ActionResult Member_psw_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Member_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_Delete_GET",
				AreaName = "member_psw",
				FormName = "MEMBER_PSW",
				Location = ACTION_MEMBER_PSW_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Member_psw();
// USE /[MANUAL MNT BEFORE_LOAD_DELETE MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DELETE MEMBER_PSW]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Member_psw/Member_psw_Delete
// USE /[MANUAL MNT CONTROLLER_DELETE_POST MEMBER_PSW]/
		[HttpPost]
		public ActionResult Member_psw_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Member_psw_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Member_psw_Delete",
				ViewName = "Member_psw",
				AreaName = "member_psw",
				Location = ACTION_MEMBER_PSW_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_DESTROY_DELETE MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_DESTROY_DELETE MEMBER_PSW]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Member_psw_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MEMBER_PSW");
		}

		#endregion

		#region Member_psw_Duplicate

// USE /[MANUAL MNT CONTROLLER_DUPLICATE_GET MEMBER_PSW]/

		[HttpPost]
		public ActionResult Member_psw_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Member_psw_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_Duplicate_GET",
				AreaName = "member_psw",
				FormName = "MEMBER_PSW",
				Location = ACTION_MEMBER_PSW_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE MEMBER_PSW]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Member_psw/Member_psw_Duplicate
// USE /[MANUAL MNT CONTROLLER_DUPLICATE_POST MEMBER_PSW]/
		[HttpPost]
		public ActionResult Member_psw_Duplicate([FromBody]Member_psw_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_Duplicate",
				ViewName = "Member_psw",
				AreaName = "member_psw",
				Location = ACTION_MEMBER_PSW_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_SAVE_DUPLICATE MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_SAVE_DUPLICATE MEMBER_PSW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_LOAD_DUPLICATE_EX MEMBER_PSW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_LOAD_DUPLICATE_EX MEMBER_PSW]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Member_psw_Cancel

		//
		// GET: /Member_psw/Member_psw_Cancel
// USE /[MANUAL MNT CONTROLLER_CANCEL_GET MEMBER_PSW]/
		public ActionResult Member_psw_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Member_psw model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("member_psw");

// USE /[MANUAL MNT BEFORE_CANCEL MEMBER_PSW]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL MNT AFTER_CANCEL MEMBER_PSW]/

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

				Navigation.SetValue("ForcePrimaryRead_member_psw", "true", true);
			}

			Navigation.ClearValue("member_psw");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Member_psw_MemberValNameModel : RequestLookupModel
		{
			public Member_psw_ViewModel Model { get; set; }
		}

		//
		// GET: /Member_psw/Member_psw_MemberValName
		// POST: /Member_psw/Member_psw_MemberValName
		[ActionName("Member_psw_MemberValName")]
		public ActionResult Member_psw_MemberValName([FromBody] Member_psw_MemberValNameModel requestModel)
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

			Models.Member_psw parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Member_psw_MemberValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Member_psw_PswValNomeModel : RequestLookupModel
		{
			public Member_psw_ViewModel Model { get; set; }
		}

		//
		// GET: /Member_psw/Member_psw_PswValNome
		// POST: /Member_psw/Member_psw_PswValNome
		[ActionName("Member_psw_PswValNome")]
		public ActionResult Member_psw_PswValNome([FromBody] Member_psw_PswValNomeModel requestModel)
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

			Models.Member_psw parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Member_psw_PswValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Member_psw/Member_psw_SaveEdit
		[HttpPost]
		public ActionResult Member_psw_SaveEdit([FromBody] Member_psw_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Member_psw_SaveEdit",
				ViewName = "Member_psw",
				AreaName = "member_psw",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL MNT BEFORE_APPLY_EDIT MEMBER_PSW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL MNT AFTER_APPLY_EDIT MEMBER_PSW]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Member_pswDocumValidateTickets : RequestDocumValidateTickets
		{
			public Member_psw_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsMember_psw([FromBody] Member_pswDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
