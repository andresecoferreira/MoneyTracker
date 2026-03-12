using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using CSGenio.core.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels.Member;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL MNT INCLUDE_CONTROLLER MEMBER]/

namespace GenioMVC.Controllers
{
	public partial class MemberController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_MNT_MENU_1111 = new NavigationLocation("MEMBERS31628", "MNT_Menu_1111", "Member") { vueRouteName = "menu-MNT_1111" };
		private static readonly NavigationLocation ACTION_MNT_MENU_41 = new NavigationLocation("MEMBERS31628", "MNT_Menu_41", "Member") { vueRouteName = "menu-MNT_41" };


		//
		// GET: /Member/MNT_Menu_1111
		[ActionName("MNT_Menu_1111")]
		[HttpPost]
		public ActionResult MNT_Menu_1111([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			MNT_Menu_1111_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "MNT_Menu_1111");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_member")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_member");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_MNT_MENU_1111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_MNT_MENU_1111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_MNT_MENU_1111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			if (!String.IsNullOrEmpty(querystring["group"]))
				Navigation.SetValue("group", querystring["group"]);


// USE /[MANUAL MNT MENU_GET 1111]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}

		//
		// GET: /Member/MNT_Menu_41
		[ActionName("MNT_Menu_41")]
		[HttpPost]
		public ActionResult MNT_Menu_41([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			MNT_Menu_41_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "MNT_Menu_41");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_member")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_member");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_MNT_MENU_41.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_MNT_MENU_41.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_MNT_MENU_41.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL MNT MENU_GET 41]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}



	}
}
