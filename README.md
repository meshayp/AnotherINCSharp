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

if (exist.OrDefault(false))
{
    // file exist
}
else
{
   // file does not exist or error
}
```


