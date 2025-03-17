using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace appium;

public class SelectProductMDA
{
    public static string SAUCE_USERNAME = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
    public static string SAUCE_ACCESS_KEY = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");
    public Uri URI = new Uri("https://{SAUCE_USERNAME}:{SAUCE_ACCESS_KEY}@ondemand.us-west-1.saucelabs.com:443/wd/hub");

    public AndroidDriver<AndroidElement> driver { get; set; } // declara o objeto do Appium para leitura e gravação


    // Funções e Métodos

    [SetUp] // Inicializa - Antes do Teste
    public void MobileBAseSetup() // Configurações de Inicialização para o Mobile
    {
        var options = new AppiumOptions(); // objeto que vai reunir as configurações
        options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
        options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Samsung Galaxy S9 FHD GoogleAPI Emulator");
        options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9.0");
        options.AddAdditionalCapability(MobileCapabilityType.App, "storage:filename=mda-2.0.0-21.apk");
        options.AddAdditionalCapability("appPackage", "com.saucelabs.mydemoapp.android");
        options.AddAdditionalCapability("appActivity", "com.saucelabs.mydemoapp.android.view.activities.SplashActivity");
        options.AddAdditionalCapability("appWaitActivity", "com.saucelabs.mydemoapp.android.view.activities.WelcomeActivity");
        options.AddAdditionalCapability("newCommandTimeout", 90); // espera elementos por 90s

        // Inicializa o Appium como Android
        driver = new AndroidDriver<AndroidElement>(remoteAddress: URI, 
                                    driverOptions: options, commandTimeout: TimeSpan.FromSeconds(180));
    }

    [TearDown] // Encerra - Depois do Teste
    public void Finalizar()
    {
        if (driver == null) return; // Se não tem o driver ativo, apenas termine o script
        driver.Quit();
    }
}