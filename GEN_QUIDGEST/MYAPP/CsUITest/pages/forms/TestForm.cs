using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TestForm : Form
{
	/// <summary>
	/// New Data Grid
	/// </summary>
	public ListControl PseudField001 => new ListControl(driver, ContainerLocator, "#TEST____PSEUDFIELD001");

	public TestForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TEST", containerLocator: containerLocator) { }
}
