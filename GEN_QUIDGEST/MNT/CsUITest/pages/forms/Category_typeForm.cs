using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Category_typeForm : Form
{
	/// <summary>
	/// Logo
	/// </summary>
	public BaseInputControl Category_typeLogo => new BaseInputControl(driver, ContainerLocator, "container-CATEGORY_TYPE__CATEGORY_TYPE__LOGO", "#CATEGORY_TYPE__CATEGORY_TYPE__LOGO");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl Category_typeName => new BaseInputControl(driver, ContainerLocator, "container-CATEGORY_TYPE__CATEGORY_TYPE__NAME", "#CATEGORY_TYPE__CATEGORY_TYPE__NAME");

	public Category_typeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CATEGORY_TYPE", containerLocator: containerLocator) { }
}
