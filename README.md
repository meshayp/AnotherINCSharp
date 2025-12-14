# Result
Another Result pattern implemented in c#

```
// Another Result Sample
Console.WriteLine("Another Result Sample");

UserService userService = new UserService();
PasswordService passwordService = new PasswordService();

// get "real" user
Result<User> result = userService.Get(10);
result.OrDefault(new User()).ID = 123;
Console.WriteLine($"get user 10 result is {result}");

if (result.OrDefault(null) != null)
{
  Console.WriteLine($"get user 10 result is not null");
}

// get null object user
result = userService.Get(0);
result.OrDefault(new User()).ID = 10;
Console.WriteLine($"get user 0 result is {result}");

result.Match((success) => Console.WriteLine($"get user 0 result is success") );

// get error
result = userService.Get(-10);
result.OrDefault(new User()).ID = 10;
Console.WriteLine($"get user -10 result is {result}");

if (result.hasError)
{
  Console.WriteLine($"get user -10 returned an error");
}

// get exception error
result = userService.Get(-1000);
result.OrDefault(new User()).ID = 10;
Console.WriteLine($"get user -1000 result is {result}");

if (result.hasError)
{
  Console.WriteLine($"get user -1000 returned an error {result.error}");
}

Result.And(userService.Get(10), userService.Save(new User()))
  .Match(
    successAction: (res) => Console.WriteLine($"Or result is success"),
    failAction: (res) => Console.WriteLine($"Or result is fail")
  );

Result.All(userService.Get(10), userService.Get(-10), userService.Validate(new User()), userService.Save(new User()))
  .Match(
    successAction: (res) => Console.WriteLine($"Or result is success"),
    failAction: (res) => Console.WriteLine($"Or result is fail")
  );

var newUser = userService.Create(5);

var resultID =
newUser
  .Then(user => userService.Validate(user))
  .Then(user => passwordService.Validate(newUser.value.Password))
  .Then(success => userService.Save(newUser.value))
  .Match(
    successAction: (res) => Console.WriteLine($"user created and saved {res.value}"),
    failAction: (res) => Console.WriteLine($"error creating user: {res.error}")
  )
  .Convert(user => user.ID);
```

# Extentions
Another Extentions sample

```
Dictionary<int, string> values = new Dictionary<int, string>();
values.Add(1, "one");
values.Add(2, "two");

Result<string> value;
value = values.Val(1); // return "one"
value = values.Val(10); // return null
value = values.ValOrSet(30, ()=> "thirty");  // return "thirty", dictionary will have 30 => "thirty" key value pair
value = values.ValOrSet(2, ()=> "two again");  // return "two"
```

