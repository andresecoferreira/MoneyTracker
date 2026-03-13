[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MNT_21Dashboard(IWebDriver driver, By containerLocator, string css) : BaseDashboardControl(driver, containerLocator, css)
{
    public WidgetMenuControl NEW_EXPENSE => new WidgetMenuControl(driver, By.Id("w-Menu_NEW_EXPENSE"), ".q-widget");
    public WidgetMenuControl NEW_INCOME => new WidgetMenuControl(driver, By.Id("w-Menu_6"), ".q-widget");
    public IWebElement LATEST => throw new NotImplementedException();
    public IWebElement CAT_MONTH => throw new NotImplementedException();
    public WidgetMenuControl NEW_INVESTMENT => new WidgetMenuControl(driver, By.Id("w-Menu_7"), ".q-widget");
    public IWebElement TEST => throw new NotImplementedException();
    public IWebElement EXP_CAT => throw new NotImplementedException();
    public IWebElement EXP_MEM => throw new NotImplementedException();
}
