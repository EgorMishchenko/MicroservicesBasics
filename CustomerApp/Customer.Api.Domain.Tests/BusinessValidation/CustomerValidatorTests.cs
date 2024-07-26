using Customer.Api.Data.Models;
using Customer.Api.Data.Repository;
using Customer.Api.Domain.BusinessValidation;
using Customer.Api.Domain.Entities;
using Customer.Api.Domain.ValueObjects;
using Moq;

namespace Customer.Api.Domain.Tests.BusinessValidation
{
    public class CustomerValidatorTests
    {
        private CustomerValidator _customerValidator;
        private Mock<ICustomerRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<ICustomerRepository>();
            _customerValidator = new CustomerValidator(_repository.Object);
        }

        [Test]
        public async Task Validate_NullEmail_Success()
        {
            var customerEntity = new CustomerEntity(
                new CustomerId(Guid.NewGuid()), 
                FirstName.Create("firstName"),
                new LastName("LastName"), 
                null, 
                null,
                new List<AddressEntity>());

            _customerValidator = new CustomerValidator(_repository.Object);
            var validationResult = await _customerValidator.ValidateAsync(customerEntity);

            Assert.IsEmpty(validationResult.Errors);
        }

        [Test]
        public async Task Validate_UniqEmail_Success()
        {
            // arrange
            var email = "email@rambler.ku";
            var customerEntity = new CustomerEntity(
                new CustomerId(Guid.NewGuid()),
                FirstName.Create("firstName"),
                new LastName("LastName"),
                null,
                email,
                new List<AddressEntity>());

            _repository.Setup(x => x.GetCustomersByEmailAsync(email, It.IsAny<CancellationToken>())).ReturnsAsync(new List<CustomerTable>());
            _customerValidator = new CustomerValidator(_repository.Object);

            // run
            var validationResult = await _customerValidator.ValidateAsync(customerEntity);

            // assert
            Assert.IsEmpty(validationResult.Errors);
        }

        [Test]
        public async Task Validate_NonUniqEmail_Failure()
        {
            // arrange
            var uniqEmail = "uniqEmail";
            var customerEntity = new CustomerEntity(
                new CustomerId(Guid.NewGuid()),
                FirstName.Create("firstName"),
                new LastName("LastName"),
                null,
                uniqEmail,
                new List<AddressEntity>());

            var listWithEmails = new List<CustomerTable>()
            {
                new (Guid.NewGuid(), "a2", "b2", null, uniqEmail, new List<AddressTable>())
            };

            _repository.Setup(x => x.GetCustomersByEmailAsync(uniqEmail, It.IsAny<CancellationToken>())).ReturnsAsync(listWithEmails);
            
            // run
            var validationResult = await _customerValidator.ValidateAsync(customerEntity);

            // assert
            Assert.IsNotEmpty(validationResult.Errors);
            Assert.IsTrue(validationResult.Errors.Count == 1);

            var errorMessage = validationResult.Errors.Single().ErrorMessage;
            Assert.That(errorMessage, Is.EqualTo("Email already exists."));
        }

        [Test]
        public async Task Validate_WhiteSpaceEmail_Failure()
        {
            // arrange
            var whitespaceEmail = "             ";
            var customerEntity = new CustomerEntity(
                new CustomerId(Guid.NewGuid()),
                FirstName.Create("firstName"),
                new LastName("LastName"),
                null,
                whitespaceEmail,
                new List<AddressEntity>());

            // run
            var validationResult = await _customerValidator.ValidateAsync(customerEntity);

            // assert
            Assert.IsNotEmpty(validationResult.Errors);
            Assert.IsTrue(validationResult.Errors.Count == 1);

            var errorMessage = validationResult.Errors.Single().ErrorMessage;
            Assert.That(errorMessage, Is.EqualTo("Email empty or white space."));
        }
    }
}
