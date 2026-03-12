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
	public class Member_psw : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmember_psw klass { get { return baseklass as CSGenioAmember_psw; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Member_psw.ValCodmember_psw")]
		public string ValCodmember_psw { get { return klass.ValCodmember_psw; } set { klass.ValCodmember_psw = value; } }

		[DisplayName("Member")]
		/// <summary>Field : "Member" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Member_psw.ValMember_id")]
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

		[DisplayName("PSW")]
		/// <summary>Field : "PSW" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Member_psw.ValCodpsw")]
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }

		private Psw _psw;
		[DisplayName("Psw")]
		[ShouldSerialize("Psw")]
		public virtual Psw Psw
		{
			get
			{
				if (!isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw))))
					_psw = Models.Psw.Find(ValCodpsw, m_userContext, Identifier, _fieldsToSerialize);
				_psw ??= new Models.Psw(m_userContext, true, _fieldsToSerialize);
				return _psw;
			}
			set { _psw = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Member_psw.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Member_psw(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmember_psw(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Member_psw(UserContext userContext, CSGenioAmember_psw val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAmember_psw csgenioa)
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
					case "psw":
						_psw ??= new Psw(m_userContext, true, _fieldsToSerialize);
						_psw.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Member_psw Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmember_psw>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Member_psw(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Member_psw> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmember_psw>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Member_psw>((r) => new Member_psw(userCtx, r));
		}

// USE /[MANUAL MNT MODEL MEMBER_PSW]/
	}
}
