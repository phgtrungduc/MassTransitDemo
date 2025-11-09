using ConsumeDemo;
using MassTransit; // Add this using directive

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddMassTransit(mt =>
{
    // Đăng ký tất cả consumers
    mt.AddConsumer<ProcessDemoMessage>();

    // Cấu hình RabbitMQ
    mt.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

var host = builder.Build();
host.Run();
