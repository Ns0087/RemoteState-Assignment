using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangFireDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        [HttpGet] 
        public IActionResult Get()
        {
            return Ok("Hello from hangfire web API...");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app"));
            
            return Ok($"Job Id : {jobId}. Welcome Email has been sent to the user!");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DelayedWelcome()
        {
            var timeInSeconds = 30;
            var jobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Welcome to our app"), TimeSpan.FromSeconds(timeInSeconds));

            return Ok($"Job Id : {jobId}. Welcome Email will be sent in {timeInSeconds} to the user!");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult RecurringWelcome()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Database Updated!!"), Cron.Weekly(DayOfWeek.Monday, 16, 7));

            return Ok($"Welcome Email will be sent in to the user!");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult ContinuousWelcome()
        {
            var timeInSeconds = 30;
            var jobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Welcome to our app"), TimeSpan.FromSeconds(timeInSeconds));

            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Continuous Job executed"));

            return Ok($"Job Id : {jobId}. Welcome Email will be sent in {timeInSeconds} to the user!");
        }

        public void SendWelcomeEmail(string v)
        {
            Console.WriteLine(v);
        }
    }
}