# ApiTestingFramework

REST API AUTOMATION USING BDD FRAMEWORK
Purpose of API Automation Framework:
The purpose for this API automation framework is to serve a technical implementation 
guideline for automation testing. 

With the help for BDD implementation this framework not only helps to reuse 
the code but also helps to set standard for test scripts.

Overview:
To automate REST API this framework uses SpecFlow which is a testing framework that supports Behaviour Driven Development (BDD). 

In order to consume web API I have used Flurlclient class. 

The FlurlClient class is used in SpecFlow API automation to simplify the process of sending and receiving data from a server. 
It is a part of the Flurl library, which is a fluent URL builder and HTTP client library for .NET.

Here are a few reasons why we use FlurlClient in SpecFlow API automation:
1.	Simplified HTTP Requests: FlurlClient provides a simple and intuitive API for making HTTP requests. 
	It abstracts away the complexities of creating and managing HTTP requests, allowing developers to focus on the actual testing logic.
	
2.	Fluent API: FlurlClient offers a fluent API that allows developers to chain methods together, making the code more readable and expressive. 
	This makes it easier to construct complex API requests with headers, query parameters, and request bodies.
	
3.	Easy Response Handling: FlurlClient provides convenient methods for handling API responses. 
	It allows you to easily extract response data, such as status codes, headers, and response bodies. 
	This makes it straightforward to validate the API responses and perform assertions in your tests.
	
4.	Integration with SpecFlow: FlurlClient integrates well with SpecFlow, which is a popular BDD testing framework. 
	It allows you to write your API tests in a natural language format using Gherkin syntax and easily map them to step definitions.
	FlurlClient's fluent API complements the readability and maintainability of SpecFlow tests.
	
5.	Extensibility: FlurlClient is highly extensible, allowing you to customize and extend its functionality as per your specific testing needs. 
	You can create custom extensions, interceptors, and plugins to add additional features or modify the behavior of the HTTP requests.
	
Overall, FlurlClient simplifies the process of making API requests, handling responses, and integrating with SpecFlow, making it a valuable tool for API automation testing.
Depending upon the security, an API may or may not require any authentication or authorization. 

This framework covers the these scenarios for the Depot Service:
1.	Consume API which requires Bearer Authentication/Token Authentication (Get request covered) 
2.  POST request process using Kafka to consume a topic.

Framework structure:

There are 2 parts of this framework

a. ApiAutomationHelper library
   This library has resuable code to be used by ApiFramework.

b. ApiTestingFramework 

The folder structure in the ApiTestingFramework project is organized in a hierarchical manner to help manage 
and organize the different components of the project. The folder structure helps 
to organize the codebase and makes it easier to locate and manage different 
components of the project. It also promotes modularity and separation of concerns by grouping related files together.


Packages used: 
Here is the list of packages used in the project:
•	Azure.Identity (Version 1.12.0)
•	Azure.Security.KeyVault.Secrets (Version 4.6.0)
•	Flurl (Version 2.8.2)
•	Flurl.Http (Version 2.4.0)
•	Microsoft.Extensions.Configuration.Json (Version 7.0.0)
•	Microsoft.NET.Test.Sdk (Version 17.0.0)
•	Newtonsoft.Json (Version 13.0.3)
•	RestSharp (Version 111.2.0)
•	SpecFlow.Plus.LivingDocPlugin (Version 3.9.57)
•	SpecFlow (Version 3.9.74)
•	SpecFlow.Tools.MsBuild.Generation (Version 3.9.8)
•	SpecFlow.xUnit (Version 3.9.8)
•	xunit (Version 2.8.1)
•	xunit.runner.visualstudio (Version 2.4.3)
•	FluentAssertions (Version 6.2.0)
These packages are used to provide additional functionality and dependencies to the project.

Where and how to use:
This framework can support any project that requires Rest API automation testing in C#.

To use this framework you need to perform following steps:
1.	Install Visual Studio (VS 2017 ,2019 recommended)
2.	Install supporting packages. Specflow extention is installed via Visual Studio/Code
3. 	Here are the DLLs listed which must be exists in the bin folder of ApiTestingFramework:
	3.1.	ApiAutomationHelper.dll -  bin\ApiAutomationHelper.dll
	3.2.	MongoDB.Bson.dll - bin\MongoDB.Bson.dll
	3.3.	MongoDB.Driver.dll -  bin\MongoDB.Driver.dll
	3.4.	MongoDB.Driver.Core.dll -  bin\MongoDB.Driver.Core.dll
	3.5.	MongoDB.Libmongocrypt.dll -  bin\MongoDB.Libmongocrypt.dll
	3.6.	Newtonsoft.Json.dll -  bin\Debug\net8.0\Newtonsoft.Json.dll
	3.7.	Sainsburys.DepotManagement.Depots.Api.dll -  bin\Sainsburys.DepotManagement.Depots.Api.dll
	3.8.	Sainsburys.DepotManagement.Depots.Models.dll -  bin\Sainsburys.DepotManagement.Depots.Models.dll
	3.9.	Sainsburys.DepotManagement.Depots.Services.dll -  bin\Sainsburys.DepotManagement.Depots.Services.dll
	4.0.	Sainsburys.DepotManagement.Shared.dll -  bin\Sainsburys.DepotManagement.Shared.dll
	4.1.	Sainsburys.EO.KeyVault.dll -  bin\Sainsburys.EO.KeyVault.dll
	4.2.	Sainsburys.EO.KeyVault.Models.dll - bin\Sainsburys.EO.KeyVault.Models.dll
	4.3.	Sainsburys.EO.Repository.dll - bin\Sainsburys.EO.Repository.dll
	4.5.	Sainsburys.EO.Repository.Models.dll - bin\Sainsburys.EO.Repository.Models.dll
	 
3.	add/update .json files the TestData->Enviornment with your project specific data.
4.	Update the appsettings.json  with your project specific API base URLs and endpoints..
5.	Test data should be in .json format.
6.	Follow the specflow feature file scenario standards (scenario standards can also be customized).


This section describe various files, folder structure used in the implementation.

1. ApiAutomationHelper library

ApiClientExtension class 

This is a static class that provides extension methods for the FlurlClient class. 
It contains two methods: GetFlurClientDataAsync and FlurlClientPostAsync.

The GetFlurClientDataAsync method is used to asynchronously send a GET request to a specified endpoint using the Flurl client. 
It takes in the Flurl client object, the base URL, the authentication URL, and the endpoint as parameters. 
It internally calls the Base.Instance.GetFlurlClient method to get an instance of the Flurl client 
and the Base.Instance.GetToken method to retrieve the authentication token. 
It then appends the endpoint to the base URL, sets the authentication token, and sends the GET request using the Flurl client. 
The response is stored in a HttpResponseMessage object, and the response content is returned as a string.

The FlurlClientPostAsync method is used to asynchronously send a POST request to a specified endpoint using the Flurl client. 
It takes in the Flurl client object, the data to be posted, the base URL, the authentication URL, and the endpoint as parameters. 
Similar to the GetFlurClientDataAsync method, it internally calls the Base.Instance.GetFlurlClient method to get an instance of the Flurl client 
and the Base.Instance.GetToken method to retrieve the authentication token. 
It appends the endpoint to the base URL, sets the authentication token, and sends the POST request with the data using the Flurl client. 
The response is returned as a HttpResponseMessage object.

Overall, the ApiClientExtension class provides convenient methods to interact with the Flurl client for making GET and POST requests, 
handling authentication, and retrieving response data.

The Base.Instance.GetFlurlClient method is called to retrieve an instance of the FlurlClient class.
In the provided code, Base is a class or a base class that contains a static property or method named Instance. 
This property or method returns an instance of the Base class.

The GetFlurlClient method is then called on this instance to obtain an instance of the FlurlClient class. 
The GetFlurlClient method likely contains the necessary logic to create and configure a FlurlClient object, such as setting the base URL, 
headers, or other client-specific settings.


Helper Folder:
The helper folder contains helper classes which intends to give quick implementation of 
basic methods that can be used again and again.

Base Class

This class, named Base, is a support class in the ApiAutomationHelper namespace. 
It contains various methods and properties that are used for API automation testing. 

Here is a summary of what this class is doing:
1.	It defines private fields, such as configuration, appSettings, testData, and Response, which are used throughout the class.
2.	It implements the singleton pattern, ensuring that only one instance of the Base class can be created.
3.	It has a private constructor that initializes the configuration, appSettings, testData, and tokenHelper objects.
4.	It provides a public static property called Instance, which returns the instance of the Base class using the singleton pattern.
5.	It has a method called GetFlurlClient, which returns a FlurlClient instance with the specified base URL.
6.	It has a method called GetToken, which retrieves the access token from the specified authentication URL using the _tokenHelper object.
7.	It has a static method called ClearInstance, which clears the instance of the Base class.
	
Overall, this class serves as a central point for managing configuration settings, accessing API clients, retrieving access tokens, and ensuring that only one instance of the Base class exists.

AzureHelper class 

This is a static class that provides helper methods for interacting with Azure services, specifically Azure Key Vault. 
It contains two main methods: GetSecret and SetupSecretClient.
The GetSecret method takes in two parameters: keyVaultName and secretKey. It is responsible for retrieving a secret value from Azure Key Vault.
Here's how it works:
1.	It calls the SetupSecretClient method to set up a SecretClient object, which is used to interact with the Azure Key Vault.
2.	If the SecretClient object is not null, it checks if the secretKey parameter is not null or empty.
3.	If the secretKey is not null or empty, it calls the GetSecret method on the SecretClient object to retrieve 
	1. the secret value associated with the provided secretKey.
4.	Finally, it returns the value of the secret.
If any exceptions occur during the process, they are caught and re-thrown to be handled by the calling code.
The SetupSecretClient method is a private method that takes in the keyVaultName parameter and returns a SecretClient object. 
It is responsible for setting up the SecretClient with the necessary configurations and credentials to interact with the Azure Key Vault.
	
Here's how it works:
1.	It checks if the keyVaultName parameter is not null or empty.
2.	If the keyVaultName is not null or empty, it creates an instance of SecretClientOptions and sets the retry policy for handling transient errors.
3.	It retrieves the Azure AD tenant ID, client ID, and client secret from environment variables.
4.	If all the necessary credentials are available, it creates a SecretClient object using the provided credentials and the keyVaultName.
5.	If any of the necessary credentials are missing, it falls back to using the DefaultAzureCredential, 
	which uses the current user's credentials or the Azure CLI credentials for authentication.
6.	Finally, it returns the SecretClient object.
	
Overall, the AzureHelper class provides convenient methods for retrieving secret values from Azure Key Vault, 
abstracting away the complexities of authentication and interaction with the Azure services.

JsonHelper class 

This is a helper class that provides methods for working with JSON files and data. 
It is used in the context of API automation testing.

Here's a brief explanation of the methods in the JsonHelper class:
1.	ReadJsonFile(Table table): This method takes a Table object as a parameter. 
	It iterates over the rows in the table and calls the ReadJsonFile(string fileName) method for each row, passing the value of the "FileName" column. 
	It then returns the last read JSON file as a string.
	
2.	ReadJsonFile(string fileName): This method takes a file name as a parameter and reads the contents of the 
	JSON file specified by the file name. It uses the Directory.GetParent() and Path.Combine() methods to 
	construct the full path of the file based on the project directory. It then reads the file 
	using File.ReadAllText() and returns the contents as a string.
	
3.	BuildRequestURL(string requestUrl, string jsonInputParams): This method takes a request URL and JSON input 
	parameters as parameters. It checks if the jsonInputParams is null. 
	If it is null, it returns the original request URL. Otherwise, it deserializes the jsonInputParams 
	string into a dictionary using JsonConvert.DeserializeObject(). It then iterates over the dictionary 
	and adds non-empty key-value pairs to a list of string values. 
	Finally, it formats the request URL by appending the string values as query parameters using 
	string.Format() and string.Join(), and returns the formatted URL.
	
Overall, the JsonHelper class provides convenient methods for reading JSON files and building 
request URLs with JSON input parameters for API automation testing.

TokenHelper class 

This is a helper class that is responsible for generating an authentication token. 
It implements the ITokenHelper interface.
The class has a constructor that takes in a dictionary of app settings as a parameter. 
This dictionary contains various settings required for generating the authentication token.

The class has a method called GenerateAuthTokenAsync which is used to generate the authentication token asynchronously. 
It returns a Task<AuthResponse> object, which represents the asynchronous operation of generating the token.
Inside the GenerateAuthTokenAsync method, an instance of the AuthRequest class is created. 
This class contains the necessary information required for generating the token, such as the client ID, username, password, and connection type. These values are retrieved from the _appsettings dictionary.

The GetAuthTokenAsync method is then called with the authentication URL and the AuthRequest object as parameters. 
This method sends a POST request to the authentication URL with the serialized AuthRequest object as the request body. 
It also adds the necessary headers, such as the client ID.
The response from the authentication server is deserialized into an AuthResponse object, which contains the authentication token.
If an exception occurs during the token generation process, it is caught and the exception is logged to the console.
Finally, the generated authentication token is returned as the result of the GenerateAuthTokenAsync method.

Hooks class 

This is a class defined in the ApiAutomationHelper.Hooks namespace. It is marked with the [Binding] attribute, which indicates that it is a class used for SpecFlow bindings. 
SpecFlow is a testing framework that allows you to write tests in a natural language format called Gherkin.

Within the Hooks class, there is a single method called AfterScenario(). This method is decorated with the [AfterScenario] attribute, which means that it will be executed after each scenario in your SpecFlow tests.
The purpose of the AfterScenario() method is to perform certain actions after the execution of a scenario. In this case, the method does the following:
1.	It writes a new line to the console using Console.WriteLine(Environment.NewLine). This is done to create a separation between the output of the previous scenario and the current scenario.
2.	It writes the text "Test Data used:" to the console using Console.WriteLine("Test Data used:"). This is a header that indicates that the following output will display the test data used in the scenario.
3.	It writes a line of ">" characters to the console using Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"). This is a visual separator to make the output more readable.
4.	It iterates over each key-value pair in the Base.Instance.testData dictionary using a foreach loop. The Base.Instance.testData dictionary is an instance of the testData dictionary in the Base class. For each key-value pair, it writes the key and value to the console using Console.WriteLine($"Key: {kvp.Key.ToString()}, Value: {kvp.Value.ToString()}").
5.	It writes a line of "<" characters to the console using Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<"). This is another visual separator to mark the end of the test data output.
6.	It clears the Base.Instance.testData dictionary using Base.Instance.testData.Clear(). This ensures that the test data is cleared after each scenario.
7.	It calls the Base.ClearInstance() method. This method is defined in the Base class and is responsible for clearing any instance-specific data or resources.

In summary, the Hooks class contains a method called AfterScenario() that is executed after each scenario in your SpecFlow tests. 
It writes the test data used in the scenario to the console and clears the test data dictionary and any instance-specific data or resources.


In the given code, Base.Instance is used to access the testData dictionary.
The purpose of using Base.Instance is to access a single instance of the Base class. By using a static property or method in the Base class, such as Instance, you can ensure that there is only one instance of the class throughout the application. This is often referred to as the Singleton pattern.
The implementation of Base.Instance is not shown in the provided code snippet, but it is likely that the Base class has a static property or method named Instance that returns the single instance of the class. This can be achieved by using a private static field to hold the instance and a public static property or method to provide access to it.
Here's an example of how the Base class might be implemented with a Singleton pattern:

public class Base
{
    private static Base instance;
    public Dictionary<object, object> testData;

    private Base()
    {
        testData = new Dictionary<object, object>();
    }

    public static Base Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Base();
            }
            return instance;
        }
    }

    public static void ClearInstance()
    {
        instance = null;
    }
}

In this example, the Base class has a private static field instance to hold the single instance of the class. 
The constructor is private to prevent direct instantiation of the class. The Instance property is a public static property 
that returns the single instance of the class. If the instance is null, it creates a new instance of the Base class. 

The ClearInstance method is a public static method that sets the instance field to null, allowing a new instance to be created if needed.
By using Base.Instance.testData, the code can access the testData dictionary of the single instance of the Base class. 
This ensures that the test data is shared across different parts of the application and can be accessed consistently.


2. ApiTestingFramework 

The folder structure in the ApiTestingFramework project is organized in a hierarchical manner to help manage 
and organize the different components of the project. The folder structure helps 
to organize the codebase and makes it easier to locate and manage different 
components of the project. It also promotes modularity and separation of concerns by grouping related files together.

Let's break down the folder structure:
1.	ApiTestingFramework: This is the root folder of the project. It contains all the files and folders related 
	to the ApiTestingFramework project.
	
2.	Models: This folder is used to store the model classes that represent the data structures used in the project. 

3.	Response: This folder is a subfolder of the Models folder. 
	It is used to group together the model classes that represent the response data from the API. 

4. Features: This folder contains the feature file you provided is written in a language called Gherkin, 
   which is a plain-text language used to describe the behavior of a software system in a structured 
   and human-readable format. It is commonly used in Behavior-Driven Development (BDD) to define the expected 
   behavior of a system from the perspective of its stakeholders.

Let's go through the structure and content of the feature file:
1.	Feature: Depots
•	This line indicates the name of the feature being described, which is "Depots". 
	It provides a high-level description of the functionality being tested.
	
2.	Scenario: Depot Process Kafka Worker
•	This scenario describes a specific test case or behavior related to the "Depot Process Kafka Worker" functionality.
•	It starts with the keyword "Scenario" followed by the scenario name.
•	The scenario consists of a series of steps that define the actions and expected outcomes of the test case.
	
3.	Given, When, Then
•	These keywords are used to define the steps of the scenario.
•	"Given" represents the initial context or setup for the test case.
•	"When" represents the action or event being performed.
•	"Then" represents the expected outcome or result of the action.
4.	And
•	The keyword "And" is used to add additional steps to the scenario.
•	It is used to make the scenario more readable and concise.
5.	Examples
•	The "Examples" section is used to provide a set of input data for a scenario.
•	It uses a table format with column headers representing the variables used in the scenario steps.
•	Each row in the table represents a different set of input data for the scenario.
	
The feature file you provided contains multiple scenarios that test different aspects of the "Depots" functionality. 
Each scenario describes a specific behavior or test case, and the steps within the scenario define the actions 
and expected outcomes.
It's important to note that the feature file serves as a high-level description of the desired behavior, 
and the actual implementation of the steps is typically done in code using a testing framework 
like Cucumber or SpecFlow. The feature file acts as a bridge between the business requirements 
and the technical implementation.

5. StepDefinitions: 
The DepotStepDefinition.cs file is a C# source code file that contains the step definitions for the SpecFlow scenarios related 
to depot management in an API testing framework. SpecFlow is a behavior-driven development (BDD) framework that allows you 
to write executable specifications in a natural language format.

Let's go through the code step by step:
5.1	The file starts with the necessary using statements to import the required namespaces.
	
5.2	The DepotStepDefinition class is defined and marked with the [Binding] attribute. 
	This attribute indicates that this class contains the step definitions for SpecFlow scenarios.
	
5.3	The class has several private fields, including _scenarioContext, inputParameters, jsonHelper, _depot, _depotSubscription, and responseMessage.	
	These fields are used to store various data and objects used in the step definitions.
	
5.4 The class has a constructor that takes a ScenarioContext object as a parameter. The ScenarioContext is a SpecFlow context object 
	that provides access to scenario-specific information and data.

5.5	The class contains several step definition methods, each marked with a [Given], [When], or [Then] attribute. 
	These attributes define the type of step (given, when, or then) and associate the method with a specific step in a SpecFlow scenario.
	
5.6	The step definition methods are named according to the corresponding steps in the SpecFlow scenarios. 
	For example, the method GivenKafkaJsonInputFile corresponds to the step "Given kafka json input file" in the scenario.
	
5.7	Each step definition method contains the code that is executed when the corresponding step is encountered during scenario execution. 
	For example, the GivenKafkaJsonInputFile method reads a JSON file specified in a SpecFlow table, deserializes 
	it into a DepotSubscriptionModel object, and assigns it to the _depotSubscription field.
	
5.8	 Some step definition methods make use of the _depot object to perform API requests and store the response in the responseMessage field.
5.9	 The step definition methods also make use of the Base.Instance.testData object to manipulate and validate the API response data.
5.10 The step definition methods may contain assertions using the Assert class to verify the expected behavior of the API response.
5.11 The step definition methods may also interact with the ScenarioContext object to store and retrieve data between steps.
	
Overall, the DepotStepDefinition.cs file contains the implementation of the step definitions for the SpecFlow 
scenarios related to depot management in the API testing framework. 
These step definitions define the behavior and actions to be taken during the execution of the scenarios.

4. ResourceObjects: This folder contains 
The Depot class is a part of the ApiTestingFramework and is responsible for handling depot-related 
operations in the application. It contains methods for retrieving, creating, and interacting with 
depot data asynchronously.

Let's go through the code snippet you provided:
// Initialize the URLs and endpoints
private string authURL = Base.Instance.appSettings["AuthUrl"].ToString();
private string baseURL = Base.Instance.appSettings["TestApiUrl"].ToString();
private string resource = Base.Instance.appSettings["ResourceEndPoint"].ToString();
private string kafka = Base.Instance.appSettings["KafkaEndPoint"].ToString();

In this section, the class initializes the URLs and endpoints required for depot operations. 
These values are retrieved from the appSettings dictionary in the Base class instance.

// Get a specific depot asynchronously by ID
public async Task GetDepotAsync(string id)
{
    await Base.Instance.m_client.GetFlurClientDataAsync(baseURL, authURL, resource + id);
}

This method, GetDepotAsync, retrieves a specific depot asynchronously based on the provided id parameter. 
It uses the GetFlurClientDataAsync method from the m_client instance of the Base class to make the API request. 
The baseURL, authURL, and resource variables are used to construct the URL for the request, 
and the id parameter is appended to the resource URL.

// Create a depot asynchronously
public async Task<HttpResponseMessage> CreateDepot(DepotSubscriptionModel data)
{
    return await Base.Instance.m_client.FlurlClientPostAsync(data, authURL, baseURL, kafka);
}

This method, CreateDepot, creates a depot asynchronously. It takes a DepotSubscriptionModel object as a parameter, 
which contains the necessary data for creating a depot. It uses the FlurlClientPostAsync 
method from the m_client instance of the Base class to make the API request. 
The data, authURL, baseURL, and kafka variables are passed to the method to construct the request.

Overall, the Depot class provides methods for interacting with depot data in the API testing framework. 
It handles retrieving specific depots by ID and creating new depots asynchronously.

5.Test Data Folder:
 This folder contains various combination of json inputs/params required to provide for an API. 
 These files are in json format. You can provide positive as well as negative inputs to the API.


Advantages:
Supports execution for testing multiple environments by simply providing required test environment name.
Supports cloud integration.
Supports OAuth2 (bearer token) authorization.
Can be used for Unit testing by developers.

Use of BDD framework allows every person like Testers, Developers, business analyst, etc., to participate actively.
Enhanced speed at which testing progresses.

Limitation:
Supports only REST APIs. Does not support SOAP APIs.
At the moment, this is only supporting Get and POST functionality as DMA services have only those endpoints.

API testing framework and library are extensible, so we can extend as needed.

TODOs

1. Add more functionalities for PUT, PATCH, DELETE if required







