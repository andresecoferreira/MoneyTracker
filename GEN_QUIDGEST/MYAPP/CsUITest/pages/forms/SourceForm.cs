using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class SourceForm : PopupForm
{
	/// <summary>
	/// New Group
	/// </summary>
	public IWebElement PseudNewgrp04 => throw new NotImplementedException();

	/// <summary>
	/// Info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#SOURCE__PSEUDNEWGRP01-container");

	/// <summary>
	/// Type
	/// </summary>
	public EnumControl SourceType => new EnumControl(driver, ContainerLocator, "container-SOURCE__SOURCE__TYPE");

	/// <summary>
	/// Owner
	/// </summary>
	public LookupControl MemberName => new LookupControl(driver, ContainerLocator, "container-SOURCE__MEMBER__NAME");
	public SeeMorePage MemberNameSeeMorePage => new SeeMorePage(driver, "SOURCE", "SOURCE__MEMBER__NAME");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl SourceTitle => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__TITLE", "#SOURCE__SOURCE__TITLE");

	/// <summary>
	/// Details
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#SOURCE__PSEUDNEWGRP02-container");

	/// <summary>
	/// Bank
	/// </summary>
	public EnumControl SourceBank => new EnumControl(driver, ContainerLocator, "container-SOURCE__SOURCE__BANK");

	/// <summary>
	/// Account Number
	/// </summary>
	public BaseInputControl SourceAccount_number => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__ACCOUNT_NUMBER", "#SOURCE__SOURCE__ACCOUNT_NUMBER");

	/// <summary>
	/// Balance
	/// </summary>
	public BaseInputControl SourceBalance => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__BALANCE", "#SOURCE__SOURCE__BALANCE");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp05 => new CollapsibleZoneControl(driver, ContainerLocator, "#SOURCE__PSEUDNEWGRP05-container");

	/// <summary>
	/// Control
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#SOURCE__PSEUDNEWGRP03-container");

	/// <summary>
	/// Created At
	/// </summary>
	public BaseInputControl SourceCreated_at => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__CREATED_AT", "#SOURCE__SOURCE__CREATED_AT");

	/// <summary>
	/// Created By
	/// </summary>
	public BaseInputControl SourceCreated_by => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__CREATED_BY", "#SOURCE__SOURCE__CREATED_BY");

	/// <summary>
	/// Updated At
	/// </summary>
	public BaseInputControl SourceUpdated_at => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__UPDATED_AT", "#SOURCE__SOURCE__UPDATED_AT");

	/// <summary>
	/// Updated By
	/// </summary>
	public BaseInputControl SourceUpdated_by => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__UPDATED_BY", "#SOURCE__SOURCE__UPDATED_BY");

	public SourceForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "SOURCE") { }
}
