using Customer.Api.Dtos.v1;

namespace Customer.Api.Messaging.Send.Sender.v1
{
    public interface ICustomerUpdateSender
    {
        void SendCustomer(CustomerDto customer);
    }
}
