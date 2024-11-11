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

}
