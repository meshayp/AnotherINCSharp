# Result
Another Result pattern implemented in c#

# Usage
```
Result<bool> FileExist(string fileName)
{
  try
  {
    // if file exist
    return true;

    // if file does not exist
    return false;
   }
   catch (Exception ex)
   {
      return ex;
   }
}
```

```
Result<bool> exist = FileExist("cmd.exe");

// quick check
if (exist.OrDefault(false))
{
   // file exist
}
```

```
Result<bool> exist = FileExist("cmd.exe");

// complete check
if (exist.hasError)
{
    // error
}
else if (exist.value)
{
   // file exist
}
else
{
   // file does not exist
}
```

```
Result<bool> exist = FileExist("cmd.exe");

// check using match with callbacks
exist.Match(
    () => {   if (exist.value) // file exist  } ,
    () => {  //error }
);
```
