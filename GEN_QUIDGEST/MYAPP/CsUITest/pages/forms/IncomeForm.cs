using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class IncomeForm : PopupForm
{
	/// <summary>
	/// ID
	/// </summary>
	public BaseInputControl IncomeIncome_id => new BaseInputControl(driver, ContainerLocator, "container-INCOME__INCOME__INCOME_ID", "#INCOME__INCOME__INCOME_ID");

	/// <summary>
	/// Info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#INCOME__PSEUDNEWGRP01-container");

	/// <summary>
	/// Category Type
	/// </summary>
	public LookupControl Category_typeName => new LookupControl(driver, ContainerLocator, "container-INCOME__CATEGORY_TYPE__NAME");
	public SeeMorePage Category_typeNameSeeMorePage => new SeeMorePage(driver, "INCOME", "INCOME__CATEGORY_TYPE__NAME");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategoryName => new LookupControl(driver, ContainerLocator, "container-INCOME__CATEGORY__NAME");
	public SeeMorePage CategoryNameSeeMorePage => new SeeMorePage(driver, "INCOME", "INCOME__CATEGORY__NAME");

	/// <summary>
	/// Member
	/// </summary>
	public LookupControl MemberName => new LookupControl(driver, ContainerLocator, "container-INCOME__MEMBER__NAME");
	public SeeMorePage MemberNameSeeMorePage => new SeeMorePage(driver, "INCOME", "INCOME__MEMBER__NAME");

	/// <summary>
	/// Group
	/// </summary>
	public IWebElement GroupName => throw new NotImplementedException();

	/// <summary>
	/// Account
	/// </summary>
	public LookupControl SourceTitle => new LookupControl(driver, ContainerLocator, "container-INCOME__SOURCE__TITLE");
	public SeeMorePage SourceTitleSeeMorePage => new SeeMorePage(driver, "INCOME", "INCOME__SOURCE__TITLE");

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl IncomeValue => new BaseInputControl(driver, ContainerLocator, "container-INCOME__INCOME__VALUE", "#INCOME__INCOME__VALUE");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl IncomeDate => new DateInputControl(driver, ContainerLocator, "#INCOME__INCOME__DATE");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl IncomeDescription => new BaseInputControl(driver, ContainerLocator, "container-INCOME__INCOME__DESCRIPTION", "#INCOME__INCOME__DESCRIPTION");

	/// <summary>
	/// Control
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#INCOME__PSEUDNEWGRP02-container");

	/// <summary>
	/// Created By
	/// </summary>
	public BaseInputControl IncomeCreated_by => new BaseInputControl(driver, ContainerLocator, "container-INCOME__INCOME__CREATED_BY", "#INCOME__INCOME__CREATED_BY");

	/// <summary>
	/// Created At
	/// </summary>
	public BaseInputControl IncomeCreated_at => new BaseInputControl(driver, ContainerLocator, "container-INCOME__INCOME__CREATED_AT", "#INCOME__INCOME__CREATED_AT");

	/// <summary>
	/// Updated By
	/// </summary>
	public BaseInputControl IncomeUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-INCOME__INCOME__UPDATED_BY", "#INCOME__INCOME__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl IncomeUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-INCOME__INCOME__UPDATED_AT", "#INCOME__INCOME__UPDATED_AT");

	public IncomeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "INCOME") { }
}
