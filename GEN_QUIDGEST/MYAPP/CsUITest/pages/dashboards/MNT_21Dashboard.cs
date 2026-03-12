[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MNT_21Dashboard(IWebDriver driver, By containerLocator, string css) : BaseDashboardControl(driver, containerLocator, css)
{
    public WidgetMenuControl EXPENSE_BUTTON => new WidgetMenuControl(driver, By.Id("w-Menu_4111"), ".q-widget");
    public IWebElement EXP_CAT => throw new NotImplementedException();
}
