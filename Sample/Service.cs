using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
  public class User
  {
    public int ID { get; set; } = 0;

    public override string ToString()
    {
      return $"User({ID})";
    }
  }

  public class Service
  {
    public Result<User> GetUser(int ID)
    {
      try
      {
        if (ID < -100)
        {
          throw new Exception("id very low");
        }

        if (ID > 1)
        {
          return new User() {  ID = ID };
        }

        if (ID == 1)
        {
          return Result.Success(new User() { ID = ID }, "Found the user");
        }

        if (ID == 0)
        {
          return Result.Success<User>(null);
        }

        if (ID < 0)
        {
          return new Error("Error finding user", 202);
        }
      }
      catch (Exception ex) {

        return (ExceptionError)ex;

      }

      return Result.Success<User>(null);
    }
  }
}
