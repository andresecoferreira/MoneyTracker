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
	public class Category_type : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcategory_type klass { get { return baseklass as CSGenioAcategory_type; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Category_type.ValCodcategory_type")]
		public string ValCodcategory_type { get { return klass.ValCodcategory_type; } set { klass.ValCodcategory_type = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Category_type.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Category_type.ValLogo")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLogo { get { return new ImageModel(klass.ValLogo) { Ticket = ValLogoQTicket }; } set { klass.ValLogo = value; } }
		[JsonIgnore]
		public string ValLogoQTicket = null;

		[DisplayName("Total")]
		/// <summary>Field : "Total" Tipo: "$" Formula: SR "[EXPENSE->VALUE]"</summary>
		[ShouldSerialize("Category_type.ValTotal_sum")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValTotal_sum { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTotal_sum, 2)); } set { klass.ValTotal_sum = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Category_type.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Category_type(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcategory_type(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Category_type(UserContext userContext, CSGenioAcategory_type val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcategory_type csgenioa)
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
		public static Category_type Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcategory_type>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Category_type(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Category_type> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcategory_type>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Category_type>((r) => new Category_type(userCtx, r));
		}

// USE /[MANUAL MNT MODEL CATEGORY_TYPE]/
	}
}
