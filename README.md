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
Result<User> exist = GetUser(123);

// quick check
if (exist.OrDefault(null) != null)
{
   // user exist
}
```

```
Result<User> exist = GetUser(123);

// complete check
if (exist.hasError)
{
    // error
}
else if (exist.value)
{
   // user exist
}
else
{
   // user does not exist
}
```

```
Result<User> exist = GetUser(123);

// check using match with callbacks
exist.Match(
    () => {   if (exist.value) // user exist  } ,
    () => {  //error }
);
```
