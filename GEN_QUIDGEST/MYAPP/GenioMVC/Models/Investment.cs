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
	public class Investment : ModelBase
	{
		[JsonIgnore]
		public CSGenioAinvestment klass { get { return baseklass as CSGenioAinvestment; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValCodinvestment")]
		public string ValCodinvestment { get { return klass.ValCodinvestment; } set { klass.ValCodinvestment = value; } }

		[DisplayName("Id")]
		/// <summary>Field : "Id" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValInvestment_id")]
		[NumericAttribute(0)]
		public decimal? ValInvestment_id { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValInvestment_id, 0)); } set { klass.ValInvestment_id = Convert.ToDecimal(value); } }

		[DisplayName("Category")]
		/// <summary>Field : "Category" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValCategory_id")]
		public string ValCategory_id { get { return klass.ValCategory_id; } set { klass.ValCategory_id = value; } }

		private Category _category;
		[DisplayName("Category")]
		[ShouldSerialize("Category")]
		public virtual Category Category
		{
			get
			{
				if (!isEmptyModel && (_category == null || (!string.IsNullOrEmpty(ValCategory_id) && (_category.isEmptyModel || _category.klass.QPrimaryKey != ValCategory_id))))
					_category = Models.Category.Find(ValCategory_id, m_userContext, Identifier, _fieldsToSerialize);
				_category ??= new Models.Category(m_userContext, true, _fieldsToSerialize);
				return _category;
			}
			set { _category = value; }
		}

		[DisplayName("Member")]
		/// <summary>Field : "Member" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValMember_id")]
		public string ValMember_id { get { return klass.ValMember_id; } set { klass.ValMember_id = value; } }

		private Member _member;
		[DisplayName("Member")]
		[ShouldSerialize("Member")]
		public virtual Member Member
		{
			get
			{
				if (!isEmptyModel && (_member == null || (!string.IsNullOrEmpty(ValMember_id) && (_member.isEmptyModel || _member.klass.QPrimaryKey != ValMember_id))))
					_member = Models.Member.Find(ValMember_id, m_userContext, Identifier, _fieldsToSerialize);
				_member ??= new Models.Member(m_userContext, true, _fieldsToSerialize);
				return _member;
			}
			set { _member = value; }
		}

		[DisplayName("Account")]
		/// <summary>Field : "Account" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValSource_id")]
		public string ValSource_id { get { return klass.ValSource_id; } set { klass.ValSource_id = value; } }

		private Source _source;
		[DisplayName("Source")]
		[ShouldSerialize("Source")]
		public virtual Source Source
		{
			get
			{
				if (!isEmptyModel && (_source == null || (!string.IsNullOrEmpty(ValSource_id) && (_source.isEmptyModel || _source.klass.QPrimaryKey != ValSource_id))))
					_source = Models.Source.Find(ValSource_id, m_userContext, Identifier, _fieldsToSerialize);
				_source ??= new Models.Source(m_userContext, true, _fieldsToSerialize);
				return _source;
			}
			set { _source = value; }
		}

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValValue")]
		[NumericAttribute(0)]
		public decimal? ValValue { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValValue, 0)); } set { klass.ValValue = Convert.ToDecimal(value); } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValDescription")]
		public string ValDescription { get { return klass.ValDescription; } set { klass.ValDescription = value; } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("Updated At")]
		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValUpdated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValUpdated_at { get { return klass.ValUpdated_at; } set { klass.ValUpdated_at = value ?? DateTime.MinValue;  } }

		[DisplayName("Created At")]
		/// <summary>Field : "Created At" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValCreated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreated_at { get { return klass.ValCreated_at; } set { klass.ValCreated_at = value ?? DateTime.Now;  } }

		[DisplayName("Created By")]
		/// <summary>Field : "Created By" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValCreated_by")]
		public string ValCreated_by { get { return klass.ValCreated_by; } set { klass.ValCreated_by = value; } }

		[DisplayName("Updated By")]
		/// <summary>Field : "Updated By" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Investment.ValUpdated_by")]
		public string ValUpdated_by { get { return klass.ValUpdated_by; } set { klass.ValUpdated_by = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Investment.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Investment(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAinvestment(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Investment(UserContext userContext, CSGenioAinvestment val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAinvestment csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "category":
						_category ??= new Category(m_userContext, true, _fieldsToSerialize);
						_category.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "member":
						_member ??= new Member(m_userContext, true, _fieldsToSerialize);
						_member.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "source":
						_source ??= new Source(m_userContext, true, _fieldsToSerialize);
						_source.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Investment Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAinvestment>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Investment(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Investment> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAinvestment>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Investment>((r) => new Investment(userCtx, r));
		}

// USE /[MANUAL MNT MODEL INVESTMENT]/
	}
}
