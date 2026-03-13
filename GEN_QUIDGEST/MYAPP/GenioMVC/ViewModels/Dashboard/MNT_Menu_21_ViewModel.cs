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
				new CustomWidgetProvider<CSGenio.business.CSGenioAexpense>
{
					Id = "LATEST",
					Order = 8,
					Width = 6,
					Height = 3,
					BorderStyle = "secondary",
					Required = true,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "MNT",
					Title = Resources.Resources.LATEST_TRANSACTIONS30213,
					Group = "_LAST_EXP",
					Form = "WD_LAST_EXPENSES",
					Component = "QFormWdLastExpenses",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAexpense>,
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.DbArea>
{
					Id = "CAT_MONTH",
					Order = 6,
					Width = 12,
					Height = 6,
					BorderStyle = "",
					Required = true,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "MNT",
					Group = "_GRAPH",
					Form = "WD_CATMONTH",
					Component = "QFormWdCatmonth",
					RefreshMode = WidgetRefreshMode.None,
					UsesCache = false,
					InstantionMethod = WidgetInstantionMethod.Aggregate
				},
				new CustomWidgetProvider<CSGenio.business.CSGenioAexpense>
{
					Id = "EXP_MEM",
					Order = 10,
					Width = 6,
					Height = 5,
					BorderStyle = "secondary",
					Required = true,
					Visible = true,
					Role = CSGenio.framework.Role.AUTHORIZED,
					Module = "MNT",
					Group = "_MEMBER",
					Form = "WD_EXPENSES",
					Component = "QFormWdExpenses",
					RowsSelector = GenioMVC.Models.ModelBase.All<CSGenio.business.CSGenioAexpense>,
					RefreshMode = WidgetRefreshMode.None,
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
					Width = 2,
					Height = 2,
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
				new MenuWidget
				{
					Id = "Menu_6",
					Order = 3,
					Width = 2,
					Height = 2,
					Style = "primary",
					BorderStyle = "secondary",
					RenderSubmenus = false,
					Required = true,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.NEW_INCOME43900,
					Group = "_ACTIONS",
					Module = "MNT",
					Path = "MNT" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("MNT", "6")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("MNT", "6")
				},
				new MenuWidget
				{
					Id = "Menu_7",
					Order = 4,
					Width = 2,
					Height = 2,
					Style = "primary",
					BorderStyle = "secondary",
					RenderSubmenus = false,
					Required = true,
					Visible = true,
					ButtonText = Resources.Resources.IR_PARA07866,
					Title = Resources.Resources.NEW_INVESTMENT45430,
					Group = "_ACTIONS",
					Module = "MNT",
					Path = "MNT" + " > " + string.Join(" > ", GenioMVC.Helpers.Menus.Menus.MenuTextPath("MNT", "7")),
					MenuEntry = GenioMVC.Helpers.Menus.Menus.FindMenu("MNT", "7")
				},
			];
		}


	}
}
