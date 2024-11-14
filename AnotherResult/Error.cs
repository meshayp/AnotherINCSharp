public class Error
{
  public string message;
  public int code = 0;

  public Error(string msg = "Error", int code = 0)
  {
    this.message = msg;
    this.code = code;
  }

  public override string ToString()
  {
    return message;
  }

}
