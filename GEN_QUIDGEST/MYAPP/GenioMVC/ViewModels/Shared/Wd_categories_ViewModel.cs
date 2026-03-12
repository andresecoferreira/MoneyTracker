using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels
{
	public class Wd_categories_ViewModel(UserContext userContext, bool nestedForm = false) : EmptyFormViewModel(userContext, nestedForm)
	{

		#region DatabaseFields used in title buttons



		#endregion

		#region Tab region


		#endregion

		#region Foreign Keys


		#endregion

		#region Fields for formulas



		#endregion

		#region ViewModel Wd_categories ()

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}
		
		protected override void FillExtraProperties()
		{
		}
		
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{

// USE /[MANUAL MNT VIEWMODEL_LOADPARTIAL WD_CATEGORIES]/
		}

		#endregion

		#region Global filter lookup fields

		#endregion

		#region Custom code

// USE /[MANUAL MNT VIEWMODEL_CUSTOM WD_CATEGORIES]/

		#endregion
	}
}
