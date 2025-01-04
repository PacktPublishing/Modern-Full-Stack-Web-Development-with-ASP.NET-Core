public class CounterService
{
    public int Count { get; private set; }

    public void IncrementCount()
    {
        Count++;
    }
}
