using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wd_expensesForm : Form
{
	/// <summary>
	/// Financial Summary by Member
	/// </summary>
	public ListControl PseudField002 => new ListControl(driver, ContainerLocator, "#WD_EXPENSES__PSEUD__FIELD002");

	/// <summary>
	/// Financial Summary by Member
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#WD_EXPENSES__PSEUD__FIELD001");

	public Wd_expensesForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WD_EXPENSES", containerLocator: containerLocator) { }
}
