using RecurringScheduleGenerator;
using TechTalk.SpecFlow.Assist;

namespace ScheduleGeneratorPractice.Specs.StepDefinitions
{
    [Binding]
    public sealed class EventGeneratorStepDefinitions
    {
        private readonly Program _program = new Program();

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            throw new PendingStepException();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

            throw new PendingStepException();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            throw new PendingStepException();
        }

        [Then("the event instance count should be (.*)")]
        public void ThenTheResultShouldBe(int instanceCount)
        {
            DateTime startDate = new DateTime(2023, 9, 1, 16, 0, 0).AddDays(-1);
            DateTime endDate = new DateTime(2023, 9, 29);
            //DateTime endDate = DateTime.Today.AddDays(1);

            List<DayOfWeek> daysOfWeek = new List<DayOfWeek>
            {
                //DayOfWeek.Monday//,
                DayOfWeek.Monday, DayOfWeek.Wednesday//, DayOfWeek.Tuesday, DayOfWeek.Wednesday//, DayOfWeek.Friday
            }.OrderBy(x => x)
            .ToList();

            int intervalInWeeks = 2;
            var instances = Program.GenerateRecurringSchedule(daysOfWeek: daysOfWeek, startDate: startDate, endDate: endDate, intervalInWeeks: intervalInWeeks);
            instances.Should().HaveCount(instanceCount);
        }

        [Then("event instance count should be")]
        public void ThenTheInstancesShouldBe(Table values)
        {
            IEnumerable<dynamic> dateTimeOffsets = values.CreateDynamicSet();
            foreach (var product in dateTimeOffsets)
            {
                var sfdklj = product.DateTimeOffsets;
            }
            DateTime startDate = new DateTime(2023, 9, 1, 16, 0, 0).AddDays(-1);
            DateTime endDate = new DateTime(2023, 9, 29);
            //DateTime endDate = DateTime.Today.AddDays(1);

            List<DayOfWeek> daysOfWeek = new List<DayOfWeek>
            {
                //DayOfWeek.Monday//,
                DayOfWeek.Monday, DayOfWeek.Wednesday//, DayOfWeek.Tuesday, DayOfWeek.Wednesday//, DayOfWeek.Friday
            }.OrderBy(x => x)
            .ToList();

            int intervalInWeeks = 2;
            var instances = Program.GenerateRecurringSchedule(daysOfWeek: daysOfWeek, startDate: startDate, endDate: endDate, intervalInWeeks: intervalInWeeks);
            //instances.Should().HaveCount(instanceCount);
        }

        [Then("add products")]
        public void AddOnlineStoreProductsWthAffiliateCodes(Table values)
        {
            IEnumerable<dynamic> products = values.CreateDynamicSet();
            foreach (var product in products)
            {
                var fs= string.Concat(product.Url, "?", product.AffilicateCode);
            }
        }
    }
}
