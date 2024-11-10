  public class Error
  {
    public string message;
    
    public Error(string msg = "Error")
    {
      this.message = msg;
    }
    public override string ToString()
    {
      return message;
    }

    public static implicit operator Result<V>(Error error) => new Result<V>(default(V), error, "Error");                                      // explicit cast from Error to Result
  }

  public class MultipleError : Error
  {
    public List<Error> errors;

    public MultipleError(List<Error> errors)
    {
      this.errors = errors;
    }

    public static implicit operator Result<V>(List<Error> errors) => new Result<V>(default(V), new MultipleError(errors), "Multiple Errors"); // explicit cast from error list to Result
  }

  public class TimeOutError : Error
  {
    public TimeOutError() : base("Timeout")
    {
    }

    public TimeOutError(string msg) : base(msg)
    {
    }
  }

  public class ExceptionError : Error
  {
    public Exception exception;

    public ExceptionError(Exception ex) : base("Exception")
    {
      this.exception = ex;
    }

    public override string ToString()
    {
      return base.ToString() + " : " + exception.ToString();
    }

    public static implicit operator Result<V>(Exception ex) => new Result<V>(default(V), new ExceptionError(ex), "Exception");                // explicit cast from Exception to Result
  }

  public class Result
  {
    public static Result<V> Success<V>(V value = default, string message = "Success")
    {
      return new Result<V>(value, null, message);
    }

    public static Result<V> Fail<V>(Error error, string message = "Fail")
    {
      return new Result<V>(default(V), error, message);
    }
  }

  public class Result<V>
  {
    public V value;
    public Error error = null;
    public string message;

    public bool isSuccess => error == null;
    public bool hasError => error != null;

    public Result(V value, Error error, string message)
    {
      this.value = value;
      this.error = error;
      this.message = message;
    }

    public static implicit operator Result<V>(V val) => new Result<V>(val, null, "Success");                                                  // explicit cast from object to Result

    public void Match(Action successAction, Action failAction)
    {
      if (isSuccess) { if (successAction != null) successAction(); } else { if (failAction != null) failAction(); };
    }

    public V OrDefault(V def)
    {
      return isSuccess ? value : def;
    }
  }
