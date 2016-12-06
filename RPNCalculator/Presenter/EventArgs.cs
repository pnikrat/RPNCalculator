namespace RPNCalculator.Presenter
{
    public class EventArgs<T>
    {
        private readonly T _value;

        public EventArgs(T value)
        {
            _value = value;
        }

        public T value
        {
            get { return _value; }
        }
    }
}