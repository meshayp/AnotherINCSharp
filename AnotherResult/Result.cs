
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

  public static implicit operator Result<V>(V val) => new Result<V>(val, null, "Success");                                                  // implicit cast from object to Result
  public static implicit operator Result<V>(Error error) => new Result<V>(default(V), error, "Error");                                      // implicit cast from Error to Result

  public void Match(Action successAction = null, Action failAction = null)
  {
    if (isSuccess) { if (successAction != null) successAction(); } else { if (failAction != null) failAction(); };
  }

  public V OrDefault(V def)
  {
    return isSuccess ? value ?? def : def;
  }

  public override string ToString()
  {
    return isSuccess ? value?.ToString() : error.ToString();
  }
}
