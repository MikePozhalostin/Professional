namespace GuessNumber.Interfaces
{
    public interface INumberComparer
    {
        CompareResult Compare(int secret, int userNumber);
    }

    public enum CompareResult
    {
        Less,
        Greater,
        Equal
    }
}
