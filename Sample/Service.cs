using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
  public record User
  {
    public int ID { get; set; } = 0;
    public string Password { get; set; } = "";

    public override string ToString()
    {
      return $"User({ID})";
    }
  }

  public class UserService
  {
    public Result<User> Get(int ID)
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

    public Result<User> Validate(User user)
    {
      if (user.ID <= 0)
      {
        return new Error("ID must be greater than zero", 201);
      }
      return user;
    }

    public Result<User> Save(User user)
    {
      if (user == null)
      {
        return new Error("User is null", 203);
      }
      // simulate save
      return Result.Success(user, "User saved");
    }

    public Result<User> Create(int id)
    {
      return new User() { ID = id };
    }
  }

  public class PasswordService
  {
    public Result<string> Validate(string password)
    {
      if (string.IsNullOrEmpty(password) || password.Length < 6)
      {
        return new Error("Password must be at least 6 characters", 301);
      }
      return Result.Success(password, "Valid password");
    }
  }
}
