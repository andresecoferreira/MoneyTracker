using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class View_catmonth : ModelBase
	{
		[JsonIgnore]
		public CSGenioAview_catmonth klass { get { return baseklass as CSGenioAview_catmonth; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("View_catmonth.ValCodview_catmonth")]
		public string ValCodview_catmonth { get { return klass.ValCodview_catmonth; } set { klass.ValCodview_catmonth = value; } }

		[DisplayName("Category Type")]
		/// <summary>Field : "Category Type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("View_catmonth.ValCategory_type")]
		public string ValCategory_type { get { return klass.ValCategory_type; } set { klass.ValCategory_type = value; } }

		[DisplayName("Month")]
		/// <summary>Field : "Month" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("View_catmonth.ValMonth")]
		[DataArray("Month", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValMonth { get { return klass.ValMonth; } set { klass.ValMonth = value; } }
		[JsonIgnore]
		public SelectList ArrayValmonth { get { return new SelectList(CSGenio.business.ArrayMonth.GetDictionary(), "Key", "Value", ValMonth); } set { ValMonth = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("Total")]
		/// <summary>Field : "Total" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("View_catmonth.ValTotal")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValTotal { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTotal, 2)); } set { klass.ValTotal = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("View_catmonth.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public View_catmonth(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAview_catmonth(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public View_catmonth(UserContext userContext, CSGenioAview_catmonth val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAview_catmonth csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static View_catmonth Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAview_catmonth>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new View_catmonth(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<View_catmonth> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAview_catmonth>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<View_catmonth>((r) => new View_catmonth(userCtx, r));
		}

// USE /[MANUAL MNT MODEL VIEW_CATMONTH]/
	}
}
