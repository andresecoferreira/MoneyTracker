using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Member_pswForm : Form
{
	/// <summary>
	/// Member
	/// </summary>
	public LookupControl MemberName => new LookupControl(driver, ContainerLocator, "container-MEMBER_PSW__MEMBER__NAME");
	public SeeMorePage MemberNameSeeMorePage => new SeeMorePage(driver, "MEMBER_PSW", "MEMBER_PSW__MEMBER__NAME");

	/// <summary>
	/// User
	/// </summary>
	public LookupControl PswNome => new LookupControl(driver, ContainerLocator, "container-MEMBER_PSW__PSW__NOME");
	public SeeMorePage PswNomeSeeMorePage => new SeeMorePage(driver, "MEMBER_PSW", "MEMBER_PSW__PSW__NOME");

	public Member_pswForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "MEMBER_PSW", containerLocator: containerLocator) { }
}
