using Data;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICapPublisher _capPublisher;

        public HomeController(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        [Route("~/checkAccountWithTrans")]
        [HttpPost]
        public async Task<IActionResult> PublishMessageWithTransaction([FromServices] MyContext dbContext)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {            //指定发送的消息标题（供订阅）和内容
                await _capPublisher.PublishAsync("xxx.services.account.check", new Person { Name = "Foo", Age = 11 });            // 你的业务代码。
                trans.Commit();
            }
            return Ok();
        }

        [NonAction]
        [CapSubscribe("xxx.services.account.check")]
        public Task CheckReceivedMessage(Person person)
        {
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
            return Task.CompletedTask;
        }
    }
}
