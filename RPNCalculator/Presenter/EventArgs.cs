namespace RPNCalculator.Presenter
{
    /*
     * Klasa służąca do przesyłania dowolnych obiektów wraz ze zdarzeniem.
     * Używana przy zdarzeniach wrzucenia na stos oraz wpisywania cyfr.
     */
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