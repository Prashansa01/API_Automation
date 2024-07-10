using ApiAutomationHelper.Support;
using TechTalk.SpecFlow;

namespace ApiAutomationHelper.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Test Data used:");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            foreach (KeyValuePair<object, object> kvp in Base.Instance.testData)
            {
                Console.WriteLine($"Key: {kvp.Key.ToString()}, Value: {kvp.Value.ToString()}");
            }
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Base.Instance.testData.Clear();
            Base.ClearInstance();
        }
    }
}