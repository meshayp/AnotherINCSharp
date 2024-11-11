# Result
Another Result pattern implemented in c#

# Usage
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
