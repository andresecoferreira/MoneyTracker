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
	public class Account : ModelBase
	{
		[JsonIgnore]
		public CSGenioAaccount klass { get { return baseklass as CSGenioAaccount; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Account.ValCodaccount")]
		public string ValCodaccount { get { return klass.ValCodaccount; } set { klass.ValCodaccount = value; } }

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Account.ValType")]
		[DataArray("Accout_type", GenioMVC.Helpers.ArrayType.Character)]
		public string ValType { get { return klass.ValType; } set { klass.ValType = value; } }
		[JsonIgnore]
		public SelectList ArrayValtype { get { return new SelectList(CSGenio.business.ArrayAccout_type.GetDictionary(), "Key", "Value", ValType); } set { ValType = value.SelectedValue as string; } }

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Account.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Balance")]
		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Account.ValBalance")]
		[NumericAttribute(2)]
		public decimal? ValBalance { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBalance, 2)); } set { klass.ValBalance = Convert.ToDecimal(value); } }

		[DisplayName("Bank")]
		/// <summary>Field : "Bank" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Account.ValBank")]
		[DataArray("Banks", GenioMVC.Helpers.ArrayType.Character)]
		public string ValBank { get { return klass.ValBank; } set { klass.ValBank = value; } }
		[JsonIgnore]
		public SelectList ArrayValbank { get { return new SelectList(CSGenio.business.ArrayBanks.GetDictionary(), "Key", "Value", ValBank); } set { ValBank = value.SelectedValue as string; } }

		[DisplayName("Account Number")]
		/// <summary>Field : "Account Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Account.ValAccount_number")]
		public string ValAccount_number { get { return klass.ValAccount_number; } set { klass.ValAccount_number = value; } }

		[DisplayName("Owner")]
		/// <summary>Field : "Owner" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Account.ValMember_id")]
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

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Account.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Account(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAaccount(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Account(UserContext userContext, CSGenioAaccount val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAaccount csgenioa)
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
		public static Account Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAaccount>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Account(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Account> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAaccount>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Account>((r) => new Account(userCtx, r));
		}

// USE /[MANUAL MNT MODEL ACCOUNT]/
	}
}
