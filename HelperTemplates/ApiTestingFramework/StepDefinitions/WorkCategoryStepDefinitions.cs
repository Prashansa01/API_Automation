using System;
using TechTalk.SpecFlow;
using ApiAutomationHelper.Models.Response;
using ApiAutomationHelper.Support;
using ApiAutomationHelper.Tests.Helper;
using ApiTestingFramework.Models.Response;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sainsburys.DepotManagement.Depots;
using Sainsburys.DepotManagement.Shared.Data.ViewModels;
using TechTalk.SpecFlow.Assist;
using Xunit;
using ApiTestingFramework.ResourceObjects.WorkCategory;

namespace ApiTestingFramework.StepDefinitions
{
    [Binding]
    public class WorkCategoryStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private string inputParameters;
        public JsonHelper jsonHelper = new();
        WorkCategory _workcategory = new();
 
        HttpResponseMessage responseMessage = new();

        [Given(@"Kafka json input file for WorkCategory")]
        public void GivenKafkaJsonInputFileForWorkCategory(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"User sends POST request")]
        public void WhenUserSendsPOSTRequest()
        {
            throw new PendingStepException();
        }

        [Then(@"Validate Status Code should be (.*)")]
        public void ThenValidateStatusCodeShouldBe(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"User makes GET Request with key'([^']*)'")]
        public void GivenUserMakesGETRequestWithKey(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"User receives API response in json input file with single data")]
        public void ThenUserReceivesAPIResponseInJsonInputFileWithSingleData(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"Validate the json resopnse and Status Code should be (.*)")]
        public void ThenValidateTheJsonResopnseAndStatusCodeShouldBe(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"User sends a GET Request to retrieve json response")]
        public void GivenUserSendsAGETRequestToRetrieveJsonResponse()
        {
            throw new PendingStepException();
        }

        [Then(@"User receives API response with json input file")]
        public void ThenUserReceivesAPIResponseWithJsonInputFile(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"User sends GET request to retrieve  count of WorkCategory response data")]
        public void GivenUserSendsGETRequestToRetrieveCountOfWorkCategoryResponseData()
        {
            throw new PendingStepException();
        }

        [Then(@"Validate the json response and Status Code should be (.*)")]
        public void ThenValidateTheJsonResponseAndStatusCodeShouldBe(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"User sends GET request with invalid EndPoint")]
        public void GivenUserSendsGETRequestWithInvalidEndPoint()
        {
            throw new PendingStepException();
        }

        [Then(@"User recieves no response for invalid end point")]
        public void ThenUserRecievesNoResponseForInvalidEndPoint()
        {
            throw new PendingStepException();
        }

        [Then(@"Validate the Status Code should be (.*)")]
        public void ThenValidateTheStatusCodeShouldBe(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"User sends GET request with invalid Bearer Token")]
        public void GivenUserSendsGETRequestWithInvalidBearerToken()
        {
            throw new PendingStepException();
        }

        [Then(@"User recieves no response for invalid token")]
        public void ThenUserRecievesNoResponseForInvalidToken()
        {
            throw new PendingStepException();
        }
    }
}
