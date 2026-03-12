using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wd_categoriesForm : Form
{
	/// <summary>
	/// Category Breakdown
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#WD_CATEGORIES__PSEUD__FIELD001");

	public Wd_categoriesForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WD_CATEGORIES", containerLocator: containerLocator) { }
}
