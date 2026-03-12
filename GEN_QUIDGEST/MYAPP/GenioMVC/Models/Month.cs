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
	public class Month : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmonth klass { get { return baseklass as CSGenioAmonth; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Month.ValCodmonth")]
		public string ValCodmonth { get { return klass.ValCodmonth; } set { klass.ValCodmonth = value; } }

		[DisplayName("Month Number")]
		/// <summary>Field : "Month Number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Month.ValMonth_number")]
		[NumericAttribute(0)]
		public decimal? ValMonth_number { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValMonth_number, 0)); } set { klass.ValMonth_number = Convert.ToDecimal(value); } }

		[DisplayName("Month Text")]
		/// <summary>Field : "Month Text" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Month.ValMonth_title")]
		public string ValMonth_title { get { return klass.ValMonth_title; } set { klass.ValMonth_title = value; } }

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Month.ValYear_number")]
		public string ValYear_number { get { return klass.ValYear_number; } set { klass.ValYear_number = value; } }

		private Year _year;
		[DisplayName("Year")]
		[ShouldSerialize("Year")]
		public virtual Year Year
		{
			get
			{
				if (!isEmptyModel && (_year == null || (!string.IsNullOrEmpty(ValYear_number) && (_year.isEmptyModel || _year.klass.QPrimaryKey != ValYear_number))))
					_year = Models.Year.Find(ValYear_number, m_userContext, Identifier, _fieldsToSerialize);
				_year ??= new Models.Year(m_userContext, true, _fieldsToSerialize);
				return _year;
			}
			set { _year = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Month.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Month(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmonth(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Month(UserContext userContext, CSGenioAmonth val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAmonth csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "year":
						_year ??= new Year(m_userContext, true, _fieldsToSerialize);
						_year.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Month Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmonth>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Month(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Month> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmonth>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Month>((r) => new Month(userCtx, r));
		}

// USE /[MANUAL MNT MODEL MONTH]/
	}
}
