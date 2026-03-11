using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CategoryForm : PopupForm
{
	/// <summary>
	/// Type
	/// </summary>
	public LookupControl Category_typeName => new LookupControl(driver, ContainerLocator, "container-CATEGORY__CATEGORY_TYPE__NAME");
	public SeeMorePage Category_typeNameSeeMorePage => new SeeMorePage(driver, "CATEGORY", "CATEGORY__CATEGORY_TYPE__NAME");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl CategoryName => new BaseInputControl(driver, ContainerLocator, "container-CATEGORY__CATEGORY__NAME", "#CATEGORY__CATEGORY__NAME");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CategoryDescription => new BaseInputControl(driver, ContainerLocator, "container-CATEGORY__CATEGORY__DESCRIPTION", "#CATEGORY__CATEGORY__DESCRIPTION");

	public CategoryForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CATEGORY") { }
}
