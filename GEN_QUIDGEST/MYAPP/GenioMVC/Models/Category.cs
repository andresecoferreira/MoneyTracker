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
	public class Category : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcategory klass { get { return baseklass as CSGenioAcategory; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Category.ValCodcategory")]
		public string ValCodcategory { get { return klass.ValCodcategory; } set { klass.ValCodcategory = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Category.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Category.ValDescription")]
		public string ValDescription { get { return klass.ValDescription; } set { klass.ValDescription = value; } }

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Category.ValType_id")]
		public string ValType_id { get { return klass.ValType_id; } set { klass.ValType_id = value; } }

		private Category_type _category_type;
		[DisplayName("Category_type")]
		[ShouldSerialize("Category_type")]
		public virtual Category_type Category_type
		{
			get
			{
				if (!isEmptyModel && (_category_type == null || (!string.IsNullOrEmpty(ValType_id) && (_category_type.isEmptyModel || _category_type.klass.QPrimaryKey != ValType_id))))
					_category_type = Models.Category_type.Find(ValType_id, m_userContext, Identifier, _fieldsToSerialize);
				_category_type ??= new Models.Category_type(m_userContext, true, _fieldsToSerialize);
				return _category_type;
			}
			set { _category_type = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Category.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Category(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcategory(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Category(UserContext userContext, CSGenioAcategory val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcategory csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "category_type":
						_category_type ??= new Category_type(m_userContext, true, _fieldsToSerialize);
						_category_type.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Category Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcategory>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Category(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Category> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcategory>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Category>((r) => new Category(userCtx, r));
		}

// USE /[MANUAL MNT MODEL CATEGORY]/
	}
}
