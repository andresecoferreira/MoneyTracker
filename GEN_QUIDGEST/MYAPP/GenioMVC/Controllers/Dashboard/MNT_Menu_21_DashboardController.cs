using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace GenioMVC.Controllers
{
	public partial class DashboardController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_MNT_Menu_21 =
			new ("DASHBOARD51597", "MNT_Menu_21", "Dashboard");

		public ActionResult MNT_Menu_21()
		{
			DashboardViewModel vm = new MNT_Menu_21_ViewModel(UserContext.Current);
			vm.Load();

			bool isHomePage =
				RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			
			if (isHomePage)
				Navigation.SetValue("HomePage", "MNT_Menu_21");
			ViewBag.isHomePage = isHomePage;

			CSGenio.framework.StatusMessage result = vm.CheckPermissions(FormMode.Show);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return JsonERROR(result.Message);

			if (
				!isHomePage
				&& !Request.IsAjaxRequest()
				&& (
					Navigation.CurrentLevel == null
					|| !ACTION_MNT_Menu_21.IsSameAction(Navigation.CurrentLevel.Location)
				)
				&& Navigation.CurrentLevel.Location.Action != ACTION_MNT_Menu_21.Action
			)
				CSGenio.framework.Audit.registAction(
					UserContext.Current.User,
					Resources.Resources.MENU01948
						+ " "
						+ Navigation.CurrentLevel.Location.ShortDescription()
				);
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(
					UserContext.Current.User,
					Resources.Resources.MENU01948 + " " + ACTION_MNT_Menu_21.ShortDescription()
				);
			}

			return JsonOK(vm);
		}

		public ActionResult MNT_Menu_21_Save([FromBody]DashboardSaveRequest dto)
		{
			// Don't allow changes in maintenance mode
			if (Maintenance.Current.IsActive)
				return JsonERROR(Resources.Resources.O_SISTEMA_ENCONTRA_S37912);

			DashboardViewModel vm = new MNT_Menu_21_ViewModel(UserContext.Current);
			vm.Save(dto);

			return JsonOK();
		}

		public ActionResult MNT_Menu_21_GetWidgetData([FromBody]RequestWidgetModel requestModel)
		{
			DashboardViewModel vm = new MNT_Menu_21_ViewModel(UserContext.Current);
			object data = vm.GetWidgetData(requestModel.WidgetType, requestModel.WidgetId);

			return JsonOK(data);
		}
	}
}
