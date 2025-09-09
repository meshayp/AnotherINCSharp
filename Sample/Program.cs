// See https://aka.ms/new-console-template for more information
using AnotherExtentions;
using Sample;

// Another Result Sample
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
  Console.WriteLine($"get user -1000 returned an error {result.error}");
}


// Another Extentions sample
Dictionary<int, string> values = new Dictionary<int, string>();
values.Add(1, "one");
values.Add(2, "two");

Result<string> value;
value = values.Val(1); // return "one"
value = values.Val(10); // return null
value = values.ValOrSet(30, ()=> "thirthy");  // return "thirthy", dictionary will have 30 => "thirthy" key value pair
value = values.ValOrSet(30, () => "thirthy and some");  // return "thirthy", dictionary will have 30 => "thirthy" key value pair

List<string> text = new List<string>() { "one", "two", "three" }; 
string joined = text.Join(","); // return "one,two,three"

int count = 5;
count.ForEach((i) => Console.WriteLine($"for each {i}")); // print 0,1,2,3,4

TimeSpan span = 10.Seconds(); // return TimeSpan of 10 seconds
TimeSpan span2 = 10.Minutes(); // return TimeSpan of 10 minutes

Double percent = 50.PercentOf(100.0); // return 50.0
Double percent2 = 50.0.AsPercentOf(200.0); // return 25.0

DateTime then = DateTime.Now.AddMinutes(-10);
TimeSpan SpenThenToNow = then.UntilNow(); // return TimeSpan of about 10 minutes

bool exist = "Cat".In(new List<string>(){"Cat", "Cat2", "Cat3"}); // return true

"HellowWorld".RegexMatches("[A-Z]").ForEach((m) => Console.WriteLine($"match {m}")); // print H and W