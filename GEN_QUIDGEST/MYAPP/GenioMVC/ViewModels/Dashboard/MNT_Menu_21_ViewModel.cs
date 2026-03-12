using System.Collections.Generic;
using System.Text.Json.Serialization;

using CSGenio.business;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Dashboard
{
	/// <summary>
	/// MNT_Menu_21 Dashboard Viewmodel
	/// </summary>
	public class MNT_Menu_21_ViewModel : DashboardViewModel
	{
		[JsonPropertyName("uuid")]
		public override string Uuid => "30002c37-8c10-4dde-a8b2-fb90726c0517";

		public MNT_Menu_21_ViewModel(UserContext userContext): base(userContext)
		{
			RoleToShow = CSGenio.framework.Role.ROLE_50;

			SingletonWidgetProviders = new Dictionary<WidgetType, WidgetProvider>()
			{
			};

			WidgetProviders =
			[
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "EXP_CAT",
					Order = 3,
					Width = 6,
					Height = 6,
					BorderStyle = "secondary",
					Required = true,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "MNT",
					Title = Resources.Resources.TOP_CATEGORIES11384,
					Group = "_ACTIONS",
					Form = "WD_CATEGORIES",
					Component = "QFormWdCategories",
					RefreshMode = WidgetRefreshMode.Automatic,
					RefreshRate = 60,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
			];

			IndependentWidgetInstances =
			[
				new MenuWidget
				{
					Id = "Menu_NEW_EXPENSE",
					Order = 2,
					Width = 1,
					Height = 1,
					Style = "primary",
					BorderStyle = "secondary",
					RenderSubmenus = false,
					Required = true,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.NEW_EXPENSE57711,
					Group = "_ACTIONS",
					Module = "MNT",
					Path = "MNT" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("MNT", "NEW_EXPENSE")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("MNT", "NEW_EXPENSE")
				},
			];
		}


	}
}
