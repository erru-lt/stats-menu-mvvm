using System;

namespace Assets.CodeBase
{
    public class ReactiveProperty<T>
    {
        public Action<T> OnValueChanged { get; set; }

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }
}
