public class MultipleError : Error
{
  public List<Error> errors;

  public MultipleError(List<Error> errors)
  {
    this.errors = errors;
  }

  public static implicit operator MultipleError(List<Error> errors) => new MultipleError(errors); // implicit cast from error list to Result
}
