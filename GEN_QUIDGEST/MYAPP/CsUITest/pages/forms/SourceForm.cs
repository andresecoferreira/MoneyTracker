using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class SourceForm : Form
{
	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl SourceTitle => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__TITLE", "#SOURCE__SOURCE__TITLE");

	/// <summary>
	/// Owner
	/// </summary>
	public LookupControl MemberName => new LookupControl(driver, ContainerLocator, "container-SOURCE__MEMBER__NAME");
	public SeeMorePage MemberNameSeeMorePage => new SeeMorePage(driver, "SOURCE", "SOURCE__MEMBER__NAME");

	/// <summary>
	/// Type
	/// </summary>
	public EnumControl SourceType => new EnumControl(driver, ContainerLocator, "container-SOURCE__SOURCE__TYPE");

	/// <summary>
	/// Balance
	/// </summary>
	public BaseInputControl SourceBalance => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__BALANCE", "#SOURCE__SOURCE__BALANCE");

	/// <summary>
	/// Bank
	/// </summary>
	public EnumControl SourceBank => new EnumControl(driver, ContainerLocator, "container-SOURCE__SOURCE__BANK");

	/// <summary>
	/// Account Number
	/// </summary>
	public BaseInputControl SourceAccount_number => new BaseInputControl(driver, ContainerLocator, "container-SOURCE__SOURCE__ACCOUNT_NUMBER", "#SOURCE__SOURCE__ACCOUNT_NUMBER");

	public SourceForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "SOURCE", containerLocator: containerLocator) { }
}
