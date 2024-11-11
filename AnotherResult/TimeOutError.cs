public class TimeOutError : Error
{
  public TimeOutError() : base("Timeout")
  {
  }

  public TimeOutError(string msg) : base(msg)
  {
  }
}
