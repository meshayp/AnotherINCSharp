using static System.Runtime.InteropServices.JavaScript.JSType;

public static class TaskResult
{
  public static Task<Result<T>> ThenAsync<V, T>(this Task<Result<V>> task, Func<Result<V>, Result<T>> func)
  {
    return task.ContinueWith((t) => t.Result.Then(func));
  }

  public static Task<Result<T>> ThenAsync<V, T>(this Task<V> task, Func<Result<V>, Result<T>> func)
  {
    return task.ContinueWith((t) => Result.Success(t.Result).Then(func));
  }
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

  public static Result<bool> And<T1, T2>(Result<T1> one, Result<T2> two)
  {
    return one.isSuccess && two.isSuccess ? true : Result.Fail<bool>(new Error("At least one result not Success"));
  }

  public static Result<bool> Or<T1, T2>(Result<T1> one, Result<T2> two)
  {
    return one.isSuccess || two.isSuccess ? true : Result.Fail<bool>(new Error("No results in Success"));
  }

  public static Result<bool> All(params Result[] results)
  {
    return results.All(r => r.isSuccess) ? true : Result.Fail<bool>(new Error("Not all results are Success"));
  }

  public string message;
  public Error error = null;
  public bool isSuccess => error == null;
  public bool hasError => error != null;

  public static Result<T> Action<T>(Func<Result<T>> func)
  {
    Result<T> res = null;
    try
    {
      res = func();
    }
    catch (Exception ex)
    {
      res = new ExceptionError(ex);
    }
    return res;
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
  public static implicit operator Result(Result<V> val) => new Result() { error = val.error, message = val.message };

  //public Result<T> Then<T>(Func<Result<V>, Result<T>> func)


  public Result<V> Match(Action<Result<V>> successAction = null, Action<Result<V>> failAction = null)
  {
    (isSuccess ? successAction : failAction)?.Invoke(this);
    return this;
  }

  public Result<T> Then<T>(Func<Result<V>, Result<T>> func)
  {
    return isSuccess ? func(value) : new Result<T>(default(T), error, message);
  }

  public Task<Result<T>> ThenAsync<T>(Func<Result<V>, Result<T>> func)
  {
    return isSuccess ? Task.Run(() => func(value)) : Task.FromResult(new Result<T>(default(T), error, message));
  }

  public Result<T> Convert<T>(Func<V, T> func)
  {
    return isSuccess ? new Result<T>(func(value), null, message) : new Result<T>(default(T), error, message);
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
