using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ExpenseForm : Form
{
	/// <summary>
	/// ID
	/// </summary>
	public BaseInputControl ExpenseExpense_id => new BaseInputControl(driver, ContainerLocator, "container-EXPENSE__EXPENSE__EXPENSE_ID", "#EXPENSE__EXPENSE__EXPENSE_ID");

	/// <summary>
	/// Info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#EXPENSE_PSEUDNEWGRP02-container");

	/// <summary>
	/// Category Type
	/// </summary>
	public LookupControl Category_typeName => new LookupControl(driver, ContainerLocator, "container-EXPENSE__CATEGORY_TYPE__NAME");
	public SeeMorePage Category_typeNameSeeMorePage => new SeeMorePage(driver, "EXPENSE", "EXPENSE__CATEGORY_TYPE__NAME");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategoryName => new LookupControl(driver, ContainerLocator, "container-EXPENSE__CATEGORY__NAME");
	public SeeMorePage CategoryNameSeeMorePage => new SeeMorePage(driver, "EXPENSE", "EXPENSE__CATEGORY__NAME");

	/// <summary>
	/// Member
	/// </summary>
	public LookupControl MemberName => new LookupControl(driver, ContainerLocator, "container-EXPENSE__MEMBER__NAME");
	public SeeMorePage MemberNameSeeMorePage => new SeeMorePage(driver, "EXPENSE", "EXPENSE__MEMBER__NAME");

	/// <summary>
	/// Account
	/// </summary>
	public LookupControl SourceTitle => new LookupControl(driver, ContainerLocator, "container-EXPENSE__SOURCE__TITLE");
	public SeeMorePage SourceTitleSeeMorePage => new SeeMorePage(driver, "EXPENSE", "EXPENSE__SOURCE__TITLE");

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl ExpenseValue => new BaseInputControl(driver, ContainerLocator, "container-EXPENSE__EXPENSE__VALUE", "#EXPENSE__EXPENSE__VALUE");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl ExpenseDate => new DateInputControl(driver, ContainerLocator, "#EXPENSE__EXPENSE__DATE");

	/// <summary>
	/// Invoice
	/// </summary>
	public DocumentControl ExpenseInvoice => new DocumentControl(driver, ContainerLocator, "EXPENSE__EXPENSE__INVOICE-container");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl ExpenseDescription => new BaseInputControl(driver, ContainerLocator, "container-EXPENSE__EXPENSE__DESCRIPTION", "#EXPENSE__EXPENSE__DESCRIPTION");

	/// <summary>
	/// Control
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EXPENSE_PSEUDNEWGRP01-container");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl ExpenseUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-EXPENSE__EXPENSE__UPDATED_AT", "#EXPENSE__EXPENSE__UPDATED_AT");

	/// <summary>
	/// Created At
	/// </summary>
	public BaseInputControl ExpenseCreated_at => new BaseInputControl(driver, ContainerLocator, "container-EXPENSE__EXPENSE__CREATED_AT", "#EXPENSE__EXPENSE__CREATED_AT");

	/// <summary>
	/// Created By
	/// </summary>
	public BaseInputControl ExpenseCreated_by => new BaseInputControl(driver, ContainerLocator, "container-EXPENSE__EXPENSE__CREATED_BY", "#EXPENSE__EXPENSE__CREATED_BY");

	/// <summary>
	/// Updated By
	/// </summary>
	public BaseInputControl ExpenseUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-EXPENSE__EXPENSE__UPDATED_BY", "#EXPENSE__EXPENSE__UPDATED_BY");

	public ExpenseForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EXPENSE", containerLocator: containerLocator) { }
}
