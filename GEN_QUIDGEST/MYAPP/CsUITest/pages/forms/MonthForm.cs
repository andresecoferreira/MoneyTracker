using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MonthForm : Form
{
	/// <summary>
	/// Month Number
	/// </summary>
	public BaseInputControl MonthMonth_number => new BaseInputControl(driver, ContainerLocator, "container-MONTH__MONTH__MONTH_NUMBER", "#MONTH__MONTH__MONTH_NUMBER");

	/// <summary>
	/// Month Text
	/// </summary>
	public BaseInputControl MonthMonth_title => new BaseInputControl(driver, ContainerLocator, "container-MONTH__MONTH__MONTH_TITLE", "#MONTH__MONTH__MONTH_TITLE");

	/// <summary>
	/// Year
	/// </summary>
	public LookupControl YearYear_number => new LookupControl(driver, ContainerLocator, "container-MONTH__YEAR__YEAR_NUMBER");
	public SeeMorePage YearYear_numberSeeMorePage => new SeeMorePage(driver, "MONTH", "MONTH__YEAR__YEAR_NUMBER");

	public MonthForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "MONTH", containerLocator: containerLocator) { }
}
