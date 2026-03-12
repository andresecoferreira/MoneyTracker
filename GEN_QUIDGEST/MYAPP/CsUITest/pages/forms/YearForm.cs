using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class YearForm : Form
{
	/// <summary>
	/// Year
	/// </summary>
	public BaseInputControl YearYear_number => new BaseInputControl(driver, ContainerLocator, "container-YEAR__YEAR__YEAR_NUMBER", "#YEAR__YEAR__YEAR_NUMBER");

	public YearForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "YEAR", containerLocator: containerLocator) { }
}
