using MassTransit;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeDemo
{
    public class ProcessDemoMessage : IConsumer<DemoEvent>
    {
        readonly ILogger<ProcessDemoMessage> _logger;
        public ProcessDemoMessage(ILogger<ProcessDemoMessage> logger)
        {
            _logger = logger;
        }
        
        public Task Consume(ConsumeContext<DemoEvent> context)
        {
            _logger.LogInformation("Received DemoEvent with name: {Name}, Value: {Value}", context.Message.Name, context.Message.Value);
            return Task.CompletedTask;
        }
    }
}
