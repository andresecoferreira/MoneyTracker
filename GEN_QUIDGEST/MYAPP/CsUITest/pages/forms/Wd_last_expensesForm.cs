using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wd_last_expensesForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#WD_LAST_EXPENSES__PSEUD__FIELD001");

	public Wd_last_expensesForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WD_LAST_EXPENSES", containerLocator: containerLocator) { }
}
