namespace Customer.Api.Messaging.Send.Options.v1
{
  public record RabbitMqConfiguration(string Hostname, string QueueName, string UserName, string Password);
}
