using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InvestmentForm : Form
{
	/// <summary>
	/// ID
	/// </summary>
	public BaseInputControl InvestmentInvestment_id => new BaseInputControl(driver, ContainerLocator, "container-INVESTMENT__INVESTMENT__INVESTMENT_ID", "#INVESTMENT__INVESTMENT__INVESTMENT_ID");

	/// <summary>
	/// info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#INVESTMENT__PSEUD__NEWGRP01-container");

	/// <summary>
	/// Category Type
	/// </summary>
	public LookupControl Category_typeName => new LookupControl(driver, ContainerLocator, "container-INVESTMENT__CATEGORY_TYPE__NAME");
	public SeeMorePage Category_typeNameSeeMorePage => new SeeMorePage(driver, "INVESTMENT", "INVESTMENT__CATEGORY_TYPE__NAME");

	/// <summary>
	/// Category
	/// </summary>
	public LookupControl CategoryName => new LookupControl(driver, ContainerLocator, "container-INVESTMENT__CATEGORY__NAME");
	public SeeMorePage CategoryNameSeeMorePage => new SeeMorePage(driver, "INVESTMENT", "INVESTMENT__CATEGORY__NAME");

	/// <summary>
	/// Member
	/// </summary>
	public LookupControl MemberName => new LookupControl(driver, ContainerLocator, "container-INVESTMENT__MEMBER__NAME");
	public SeeMorePage MemberNameSeeMorePage => new SeeMorePage(driver, "INVESTMENT", "INVESTMENT__MEMBER__NAME");

	/// <summary>
	/// Account
	/// </summary>
	public LookupControl SourceTitle => new LookupControl(driver, ContainerLocator, "container-INVESTMENT__SOURCE__TITLE");
	public SeeMorePage SourceTitleSeeMorePage => new SeeMorePage(driver, "INVESTMENT", "INVESTMENT__SOURCE__TITLE");

	/// <summary>
	/// Value
	/// </summary>
	public BaseInputControl InvestmentValue => new BaseInputControl(driver, ContainerLocator, "container-INVESTMENT__INVESTMENT__VALUE", "#INVESTMENT__INVESTMENT__VALUE");

	/// <summary>
	/// Date
	/// </summary>
	public DateInputControl InvestmentDate => new DateInputControl(driver, ContainerLocator, "#INVESTMENT__INVESTMENT__DATE");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl InvestmentDescription => new BaseInputControl(driver, ContainerLocator, "container-INVESTMENT__INVESTMENT__DESCRIPTION", "#INVESTMENT__INVESTMENT__DESCRIPTION");

	/// <summary>
	/// Control
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#INVESTMENT__PSEUD__NEWGRP02-container");

	/// <summary>
	/// Created By
	/// </summary>
	public BaseInputControl InvestmentCreated_by => new BaseInputControl(driver, ContainerLocator, "container-INVESTMENT__INVESTMENT__CREATED_BY", "#INVESTMENT__INVESTMENT__CREATED_BY");

	/// <summary>
	/// Created At
	/// </summary>
	public BaseInputControl InvestmentCreated_at => new BaseInputControl(driver, ContainerLocator, "container-INVESTMENT__INVESTMENT__CREATED_AT", "#INVESTMENT__INVESTMENT__CREATED_AT");

	/// <summary>
	/// Updated By
	/// </summary>
	public BaseInputControl InvestmentUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-INVESTMENT__INVESTMENT__UPDATED_BY", "#INVESTMENT__INVESTMENT__UPDATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl InvestmentUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-INVESTMENT__INVESTMENT__UPDATED_AT", "#INVESTMENT__INVESTMENT__UPDATED_AT");

	public InvestmentForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "INVESTMENT", containerLocator: containerLocator) { }
}
