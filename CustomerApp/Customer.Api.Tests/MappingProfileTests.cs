using AutoMapper;
using Customer.Api.Contracts;
using Customer.Api.Data.Models;
using Customer.Api.Dtos.v1;
using Customer.Api.Mappings;
using CustomerContract = Customer.Api.Contracts.Customer;

namespace Customer.Api.Tests
{
  public class MappingProfileTests
  {
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
      var mockMapper = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new MappingProfile());
      });

      _mapper = mockMapper.CreateMapper();
    }

    [Test]
    public void MapCustomerDto_ToCustomerContract_Success()
    {
      var customerDto = new CustomerDto(
        new Guid("6746f3da-46ca-4822-a708-5c2798f8527e"),
        "TestFirstName",
        "TestLastName",
        new DateOnly(2000, 01, 01));

      var customerContract = _mapper.Map<CustomerContract>(customerDto);

      Assert.Pass();
      Assert.NotNull(customerContract);
      Assert.That(new Guid("6746f3da-46ca-4822-a708-5c2798f8527e"), Is.EqualTo(customerContract.Id));
      Assert.That("TestFirstName", Is.EqualTo(customerContract.FirstName));
      Assert.That("TestLastName", Is.EqualTo(customerContract.LastName));
      Assert.That(new DateOnly(2000, 01, 01), Is.EqualTo(customerContract.Birthday));
    }

    [Test]
    public void MapCustomerTable_ToCustomerDto_Success()
    {
      var customerTable = new CustomerTable(
        new Guid("6746f3da-46ca-4822-a708-5c2798f8527e"),
        "TestFirstName",
        "TestLastName",
        new DateOnly(2000, 01, 01));

      var customerDto = _mapper.Map<CustomerDto>(customerTable);

      Assert.Pass();
      Assert.NotNull(customerDto);
      Assert.That(new Guid("6746f3da-46ca-4822-a708-5c2798f8527e"), Is.EqualTo(customerDto.Id));
      Assert.That("TestFirstName", Is.EqualTo(customerDto.FirstName));
      Assert.That("TestLastName", Is.EqualTo(customerDto.LastName));
      Assert.That(new DateOnly(2000, 01, 01), Is.EqualTo(customerDto.Birthday));
    }

    [Test]
    public void MapListCustomerTable_ToListCustomerDto_Success()
    {
      var customerTable1 = new CustomerTable(
        new Guid("6746f3da-46ca-4822-a708-5c2798f8527e"),
        "TestFirstName",
        "TestLastName",
        new DateOnly(2000, 01, 01));

      var customerTable2 = new CustomerTable(
        new Guid("9f76f54f-5704-4de1-bd3f-91ce68fb7b2c"),
        "TestFirstName2",
        "TestLastName2",
        new DateOnly(2002, 02, 02));

      var listCustomerTable = new List<CustomerTable>() { customerTable1, customerTable2 };
      var listCustomerDto = _mapper.Map<List<CustomerDto>>(listCustomerTable);

      Assert.Pass();
      Assert.NotNull(listCustomerDto);

      var first = listCustomerDto.First(x => x.FirstName == "TestFirstName");

      Assert.That(new Guid("6746f3da-46ca-4822-a708-5c2798f8527e"), Is.EqualTo(first.Id));
      Assert.That("TestFirstName", Is.EqualTo(first.FirstName));
      Assert.That("TestLastName", Is.EqualTo(first.LastName));
      Assert.That(new DateOnly(2000, 01, 01), Is.EqualTo(first.Birthday));

      var second = listCustomerDto.First(x => x.FirstName == "TestFirstName2");

      Assert.That(new Guid("9f76f54f-5704-4de1-bd3f-91ce68fb7b2c"), Is.EqualTo(second.Id));
      Assert.That("TestFirstName2", Is.EqualTo(second.FirstName));
      Assert.That("TestLastName2", Is.EqualTo(second.LastName));
      Assert.That(new DateOnly(2002, 02, 02), Is.EqualTo(second.Birthday));
    }
  }
}