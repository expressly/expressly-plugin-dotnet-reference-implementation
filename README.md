[![Expressly](https://buyexpressly.com/assets/img/expressly-logo-sm-gray.png)](https://buyexpressly.com)
# Expressly .NET SDK Sample

This project is supplied as a reference for any developers wishing to integrate their ASP .NET e-commerce platform with the Expressly Network.

The reference implementation makes use of [the Expressly .NET SDK](https://github.com/expressly/expressly-plugin-sdk-dotnet-core).


* * *

# Running the solution
In order to run the sample project, you will need to have Visual Studio 2010 or later installed.

After run site if you go to **/expressly/api/ping** you can see the endpoint is answering correctly


* * *


## Configuration
In order to use the Expressly .NET SDK with your application, you will need to first configure your application. By default, the SDK will attempt to look for Expressly-specific settings in your application's **web.config** file.

# Implementation


The ExpresslyProvider class gives you methods to talk directly to our back end.

Make sure to publish ExpresslyRouter, this exposes the necessary endpoints for our back end to talk to.

Finally, configure your application. (details below)

This is sample of ASP MVC 4 project with the core steps that you will need to integrate your shop with the Expressly Network. These are:

 1. **Create an Implementation of the [IMerchantProvider](https://github.com/expressly/expressly-plugin-dotnet-reference-implementation/blob/master/Sample/Source/Services/ExpresslyMerchantProvider.cs) interface** - this is necessary for the plugin to communicate with your own logic.

 1. **Set Up ExpresslyPlugin Merchant interface Implementation** - in entry point of ASP MVC aplication, you will need set Up ExpresslyPlugin Merchant interface Implementation. Entry point for ASP .MVC 4 - is an *Application_Start()* method in **[Global.asax.cs](https://github.com/expressly/expressly-plugin-dotnet-reference-implementation/blob/master/Sample/Source/Global.asax.cs)**.

 1. **Configure your application** - Configure your application **web.config** (details below).
 

- - -


# Expressly Config Settings

The following is a sample config file containing the configuration sections that are required in order for the settings to be used with this SDK:

```
<configuration>
  <configSections>
     <section name="expressly" type="Expressly.SDKConfigHandler, Expressly" />
  </configSections>

<!-- Expressly Http Module settings -->
    <system.webServer>
        <modules>
            <add name="ExpresslyRouter" type="Expressly.ExpresslyRouter" />
        </modules>
    </system.webServer>

 <!-- Expressly SDK settings -->
    <expressly>
        <settings>
            <add name="mode" value="sandbox" />
            <add name="requestRetries" value="1" />
            <add name="apiKey" value="Y2Q4MDNlYTMtY2YwNi00OTk0LTkxMDItOGNjODMxNjkzNzlmOm55TzRnNnB3QlNhZFB3WjhTVmNzeXdkVUE5VlNXeUU2" />
            <add name="apiBaseUrl" value="http://vstudio-xly.cloudapp.net" />
        </settings>
    </expressly>
</configuration>
```
The following table defines the currently supported settings that can be specified in the <expressly> section:
  
| Settings Name | Description | Default |
|-------------------|------------------------------------------------------------------------------------------------------------------|---------|
| mode | Determines which Expressly endpoint URL will be used with your application. Possible values are *live* or *sandbox*. | sandbox |
| requestRetries | The number of times HTTP requests should be attempted by the SDK before an error is thrown. | 3 |
| connectionTimeout | The amount of time (in milliseconds) before an HTTP request should timeout. | 30000 |
| apiKey | Your application's Api Key as specified on your Expressly account | none |
| apiBaseUrl | Url for you site, where the expressly plugin is reacheable from | none |
  

# Log4net Config Settings (Optional)

The SDK comes with built-in support for logging using log4net if you choose to include it as a reference in your application.

In order to enable logging with the SDK, add the following configuration information to your config file along with the Expressly config information in the previous section:
```
<configuration>
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
  </configSections>

    <!-- log4net settings -->
    <log4net>
        <appender name="FileAppender" type="log4net.Appender.FileAppender">
            <file value="Logs\Expressly\log.txt" />
            <encoding value="utf-8" />
            <staticLogFileName value="true" />
            <countDirection value="1" />
            <appendToFile value="true" />
            <rollingStyle value="Composite" />
            <datePattern value="'-'yyyy.MM.dd'.txt'" />
            <lockingModel type="log4net.Appender.FileAppender+MinimalLock" />
            <maxSizeRollBackups value="10" />
            <maximumFileSize value="10MB" />
            <layout type="log4net.Layout.PatternLayout">
                <conversionPattern value="%utcdate [%level] - %message%newline" />
            </layout>
        </appender>
        <root>
            <level value="ALL" />
            <appender-ref ref="FileAppender" />
        </root>
    </log4net>
    
    <!-- App-specific settings. Here we specify which Expressly logging classes are enabled.
    Expressly.Log.Log4netLogger: Provides base log4net logging functionality
    Expressly.Log.DiagnosticsLogger: Provides more thorough logging of system diagnostic information and tracing code execution -->
  <appSettings>
    <!-- Diagnostics logging is only available in a Full Trust environment. -->
    <!-- <add key="ExpresslyLogger" value="Expressly.Log.DiagnosticsLogger, Expressly.Log.Log4netLogger"/> -->
    <add key="ExpresslyLogger" value="Expressly.Log.Log4netLogger"/>
  </appSettings>
</configuration>
```

## Contributing

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request

- - -

## License

Released under the [MIT License](http://www.opensource.org/licenses/MIT).
