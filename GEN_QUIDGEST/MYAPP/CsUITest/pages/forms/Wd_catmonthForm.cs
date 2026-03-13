using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wd_catmonthForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudCatmonth => new ListControl(driver, ContainerLocator, "#WD_CATMONTH__PSEUD__CATMONTH");

	public Wd_catmonthForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "WD_CATMONTH", containerLocator: containerLocator) { }
}
