using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GroupForm : Form
{
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl GroupName => new BaseInputControl(driver, ContainerLocator, "container-GROUP___GROUPNAME____", "#GROUP___GROUPNAME____");

	/// <summary>
	/// Members
	/// </summary>
	public ListControl PseudMembers => new ListControl(driver, ContainerLocator, "#GROUP___PSEUDMEMBERS_");

	public GroupForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "GROUP", containerLocator: containerLocator) { }
}
