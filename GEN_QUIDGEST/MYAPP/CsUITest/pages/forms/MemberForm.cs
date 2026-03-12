using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MemberForm : Form
{
	/// <summary>
	/// Info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#MEMBER__PSEUDNEWGRP01-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl MemberPhoto => new BaseInputControl(driver, ContainerLocator, "container-MEMBER__MEMBER__PHOTO", "#MEMBER__MEMBER__PHOTO");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl MemberName => new BaseInputControl(driver, ContainerLocator, "container-MEMBER__MEMBER__NAME", "#MEMBER__MEMBER__NAME");

	/// <summary>
	/// Birthday
	/// </summary>
	public DateInputControl MemberBirthday => new DateInputControl(driver, ContainerLocator, "#MEMBER__MEMBER__BIRTHDAY");

	/// <summary>
	/// E-Mail
	/// </summary>
	public BaseInputControl MemberEmail => new BaseInputControl(driver, ContainerLocator, "container-MEMBER__MEMBER__EMAIL", "#MEMBER__MEMBER__EMAIL");

	/// <summary>
	/// Phone
	/// </summary>
	public BaseInputControl MemberPhone => new BaseInputControl(driver, ContainerLocator, "container-MEMBER__MEMBER__PHONE", "#MEMBER__MEMBER__PHONE");

	/// <summary>
	/// Group
	/// </summary>
	public LookupControl GroupName => new LookupControl(driver, ContainerLocator, "container-MEMBER__GROUPNAME____");
	public SeeMorePage GroupNameSeeMorePage => new SeeMorePage(driver, "MEMBER", "MEMBER__GROUPNAME____");

	/// <summary>
	/// Accounts
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#MEMBER__PSEUDNEWGRP03-container");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudSources => new ListControl(driver, ContainerLocator, "#MEMBER__PSEUDSOURCES_");

	public MemberForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "MEMBER", containerLocator: containerLocator) { }
}
