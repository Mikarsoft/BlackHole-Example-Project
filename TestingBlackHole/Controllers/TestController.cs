using Microsoft.AspNetCore.Mvc;
using TestingBlackHole.Interfaces;

namespace TestingBlackHole.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ITestDataGenerator _testDataGenerator;
        public TestController(ITestService testService, ITestDataGenerator testDataGenerator)
        {
            _testService = testService;
            _testDataGenerator = testDataGenerator;
        }
    }
}