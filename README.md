# Result
Another Result pattern implemented in c#

```
Result<User> GetUser(int ID)
{
  try
  {
    // if user exist
    return user;

    // if user does not exist
    return null;
   }
   catch (Exception ex)
   {
      return ex;
   }
}
```

```
Result<User> user = GetUser(123);

// quick check
if (user.OrDefault(null) != null)
{
   // user found
}
```

```
Result<User> user = GetUser(123);

// complete check
if (user.hasError)
{
    // error
}
else if (user.value)
{
   // user found
}
else
{
   // user not found
}
```

```
Result<User> user = GetUser(123);

// check using match with callbacks
user.Match(
    () => {   if (user.value) // user found  } ,
    () => {  //error }
);
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
