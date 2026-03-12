[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MNT_21Dashboard(IWebDriver driver, By containerLocator, string css) : BaseDashboardControl(driver, containerLocator, css)
{
    public WidgetMenuControl NEW_EXPENSE => new WidgetMenuControl(driver, By.Id("w-Menu_NEW_EXPENSE"), ".q-widget");
    public IWebElement EXP_CAT => throw new NotImplementedException();
}
