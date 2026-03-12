using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Group_pswForm : Form
{
	/// <summary>
	/// Group
	/// </summary>
	public LookupControl GroupName => new LookupControl(driver, ContainerLocator, "container-GROUP_PSW__GROUP__NAME");
	public SeeMorePage GroupNameSeeMorePage => new SeeMorePage(driver, "GROUP_PSW", "GROUP_PSW__GROUP__NAME");

	/// <summary>
	/// User
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, ContainerLocator, "container-GROUP_PSW__PSW__NOME");
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "GROUP_PSW", "GROUP_PSW__PSW__NOME");

	public Group_pswForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "GROUP_PSW", containerLocator: containerLocator) { }
}
