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
	public class Source : ModelBase
	{
		[JsonIgnore]
		public CSGenioAsource klass { get { return baseklass as CSGenioAsource; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Source.ValCodsource")]
		public string ValCodsource { get { return klass.ValCodsource; } set { klass.ValCodsource = value; } }

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "AC" Formula: DG ""CA""</summary>
		[ShouldSerialize("Source.ValType")]
		[DataArray("Accout_type", GenioMVC.Helpers.ArrayType.Character)]
		public string ValType { get { return klass.ValType; } set { klass.ValType = value; } }
		[JsonIgnore]
		public SelectList ArrayValtype { get { return new SelectList(CSGenio.business.ArrayAccout_type.GetDictionary(), "Key", "Value", ValType); } set { ValType = value.SelectedValue as string; } }

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Source.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Balance")]
		/// <summary>Field : "Balance" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Source.ValBalance")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValBalance { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBalance, 2)); } set { klass.ValBalance = Convert.ToDecimal(value); } }

		[DisplayName("Bank")]
		/// <summary>Field : "Bank" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Source.ValBank")]
		[DataArray("Banks", GenioMVC.Helpers.ArrayType.Character)]
		public string ValBank { get { return klass.ValBank; } set { klass.ValBank = value; } }
		[JsonIgnore]
		public SelectList ArrayValbank { get { return new SelectList(CSGenio.business.ArrayBanks.GetDictionary(), "Key", "Value", ValBank); } set { ValBank = value.SelectedValue as string; } }

		[DisplayName("Account Number")]
		/// <summary>Field : "Account Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Source.ValAccount_number")]
		public string ValAccount_number { get { return klass.ValAccount_number; } set { klass.ValAccount_number = value; } }

		[DisplayName("Member")]
		/// <summary>Field : "Member" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Source.ValMember_id")]
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

		[DisplayName("Updated At")]
		/// <summary>Field : "Updated At" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Source.ValUpdated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValUpdated_at { get { return klass.ValUpdated_at; } set { klass.ValUpdated_at = value ?? DateTime.MinValue;  } }

		[DisplayName("Created At")]
		/// <summary>Field : "Created At" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Source.ValCreated_at")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreated_at { get { return klass.ValCreated_at; } set { klass.ValCreated_at = value ?? DateTime.Now;  } }

		[DisplayName("Created By")]
		/// <summary>Field : "Created By" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Source.ValCreated_by")]
		public string ValCreated_by { get { return klass.ValCreated_by; } set { klass.ValCreated_by = value; } }

		[DisplayName("Updated By")]
		/// <summary>Field : "Updated By" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Source.ValUpdated_by")]
		public string ValUpdated_by { get { return klass.ValUpdated_by; } set { klass.ValUpdated_by = value; } }

		[DisplayName("Group")]
		/// <summary>Field : "Group" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Source.ValGroup_id")]
		public string ValGroup_id { get { return klass.ValGroup_id; } set { klass.ValGroup_id = value; } }

		private Group _group;
		[DisplayName("Group")]
		[ShouldSerialize("Group")]
		public virtual Group Group
		{
			get
			{
				if (!isEmptyModel && (_group == null || (!string.IsNullOrEmpty(ValGroup_id) && (_group.isEmptyModel || _group.klass.QPrimaryKey != ValGroup_id))))
					_group = Models.Group.Find(ValGroup_id, m_userContext, Identifier, _fieldsToSerialize);
				_group ??= new Models.Group(m_userContext, true, _fieldsToSerialize);
				return _group;
			}
			set { _group = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Source.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Source(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAsource(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Source(UserContext userContext, CSGenioAsource val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAsource csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "member":
						_member ??= new Member(m_userContext, true, _fieldsToSerialize);
						_member.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "group":
						_group ??= new Group(m_userContext, true, _fieldsToSerialize);
						_group.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Source Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAsource>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Source(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Source> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAsource>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Source>((r) => new Source(userCtx, r));
		}

// USE /[MANUAL MNT MODEL SOURCE]/
	}
}
