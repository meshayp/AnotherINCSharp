// See https://aka.ms/new-console-template for more information
using Sample;

Console.WriteLine("Another Result Sample");

Service service = new Service();

// get "real" user
Result<User> result = service.GetUser(10);
result.OrDefault(new User()).ID = 123;
Console.WriteLine($"get user 10 result is {result}");

if (result.OrDefault(null) != null)
{
  Console.WriteLine($"get user 10 result is not null");
}

// get null object user
result = service.GetUser(0);
result.OrDefault(new User()).ID = 10;
Console.WriteLine($"get user 0 result is {result}");

result.Match(() => Console.WriteLine($"get user 0 result is success") );

// get error
result = service.GetUser(-10);
result.OrDefault(new User()).ID = 10;
Console.WriteLine($"get user -10 result is {result}");

if (result.hasError)
{
  Console.WriteLine($"get user -10 returned an error");
}

// get exception error
result = service.GetUser(-1000);
result.OrDefault(new User()).ID = 10;
Console.WriteLine($"get user -1000 result is {result}");

if (result.hasError)
{
  Console.WriteLine($"get user -1000 returned an error");
}