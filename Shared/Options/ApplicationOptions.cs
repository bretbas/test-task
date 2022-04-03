
namespace Shared.Options;

public class RabbitMqOptions
{
    public const string RabbitMqSection = "RabbitMQConfig";

    public string Host { get; set; }

    public string VirtualHost { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }
}