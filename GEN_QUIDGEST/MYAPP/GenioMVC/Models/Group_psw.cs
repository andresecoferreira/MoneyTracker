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
	public class Group_psw : ModelBase
	{
		[JsonIgnore]
		public CSGenioAgroup_psw klass { get { return baseklass as CSGenioAgroup_psw; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Group_psw.ValCodgroup_psw")]
		public string ValCodgroup_psw { get { return klass.ValCodgroup_psw; } set { klass.ValCodgroup_psw = value; } }

		[DisplayName("Group")]
		/// <summary>Field : "Group" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Group_psw.ValGroup_id")]
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

		[DisplayName("CodPSW")]
		/// <summary>Field : "CodPSW" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Group_psw.ValCodpsw")]
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
		[ShouldSerialize("Group_psw.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Group_psw(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAgroup_psw(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Group_psw(UserContext userContext, CSGenioAgroup_psw val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAgroup_psw csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "group":
						_group ??= new Group(m_userContext, true, _fieldsToSerialize);
						_group.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Group_psw Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgroup_psw>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Group_psw(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Group_psw> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgroup_psw>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Group_psw>((r) => new Group_psw(userCtx, r));
		}

// USE /[MANUAL MNT MODEL GROUP_PSW]/
	}
}
