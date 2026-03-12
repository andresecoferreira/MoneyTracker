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
	public class Member : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmember klass { get { return baseklass as CSGenioAmember; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Member.ValCodmember")]
		public string ValCodmember { get { return klass.ValCodmember; } set { klass.ValCodmember = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Member.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Birthday")]
		/// <summary>Field : "Birthday" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Member.ValBirthday")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValBirthday { get { return klass.ValBirthday; } set { klass.ValBirthday = value ?? DateTime.MinValue; } }

		[DisplayName("E-Mail")]
		/// <summary>Field : "E-Mail" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Member.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Member.ValPhone")]
		public string ValPhone { get { return klass.ValPhone; } set { klass.ValPhone = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Member.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhoto { get { return new ImageModel(klass.ValPhoto) { Ticket = ValPhotoQTicket }; } set { klass.ValPhoto = value; } }
		[JsonIgnore]
		public string ValPhotoQTicket = null;

		[DisplayName("Group")]
		/// <summary>Field : "Group" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Member.ValGroup_id")]
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

		[DisplayName("Age")]
		/// <summary>Field : "Age" Tipo: "N" Formula: + "floor(Diferenca_entre_Datas([Today],[MEMBER->BIRTHDAY],"D")/365)"</summary>
		[ShouldSerialize("Member.ValAge")]
		[NumericAttribute(0)]
		public decimal? ValAge { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValAge, 0)); } set { klass.ValAge = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Member.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Member(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmember(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Member(UserContext userContext, CSGenioAmember val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAmember csgenioa)
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
		public static Member Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmember>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Member(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Member> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmember>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Member>((r) => new Member(userCtx, r));
		}

// USE /[MANUAL MNT MODEL MEMBER]/
	}
}
