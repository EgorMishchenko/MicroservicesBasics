using System.Text;
using System.Text.Json;
using Customer.Api.Messaging.Send.Options.v1;
using Customer.Api.Dtos.v1;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Customer.Api.Messaging.Send.Sender.v1
{
  public class CustomerUpdateSender : ICustomerUpdateSender
  {
    private readonly RabbitMqConfiguration _rabbitConfig;
    private IConnection _connection;
    
    public CustomerUpdateSender(IOptions<RabbitMqConfiguration> rabbitMqOptions, IOptions<RabbitMqConfiguration> rabbitConfig)
    {
      _rabbitConfig = rabbitConfig.Value;
      CreateConnection();
    }
    public void SendCustomer(CustomerDto customer)
    {
      if (ConnectionExists())
      {
        using (var channel = _connection.CreateModel())
        {
          channel.QueueDeclare(queue: _rabbitConfig.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

          var json = JsonSerializer.Serialize(customer);
          var body = Encoding.UTF8.GetBytes(json);

          channel.BasicPublish(exchange: "", routingKey: _rabbitConfig.QueueName, basicProperties: null, body: body);
        }
      }
    }


    private void CreateConnection()
    {
      try
      {
        var factory = new ConnectionFactory
        {
          HostName = _rabbitConfig.Hostname,
          UserName = _rabbitConfig.UserName,
          Password = _rabbitConfig.Password,
        };
        _connection = factory.CreateConnection();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Could not create connection: {ex.Message}");
      }
    }

    private bool ConnectionExists()
    {
      if (_connection != null)
      {
        return true;
      }

      CreateConnection();

      return _connection != null;
    }
  }
}
