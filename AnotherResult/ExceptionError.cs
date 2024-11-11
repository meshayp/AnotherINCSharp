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

  public static implicit operator ExceptionError(Exception ex) => new ExceptionError(ex);     // implicit cast from Exception to Result
}
