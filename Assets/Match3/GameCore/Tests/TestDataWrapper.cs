namespace Match3.GameCore.Tests
{
    public class TestDataWrapper<T, TExp>
    {
        public T? Value { get; set; }
        public TExp? Expected { get; set; }
    }
}
