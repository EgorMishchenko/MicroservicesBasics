namespace Customer.Api.Domain.ValueObjects
{
    public readonly record struct LastName
    {
        public const int MaxLength = 70;
        private readonly string _value;

        public LastName(string value)
        {
            _value = value;
        }

        public LastName() : this(string.Empty) { }

        public string Value
        {
            get => _value;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Last name cannot be empty {MaxLength}", nameof(Value));
                }

                if (value.Length > MaxLength)
                {
                    throw new ArgumentException($"Last name cannot exceed {MaxLength}", nameof(Value));
                }

                _value = value.Trim();
            }
        }

        public static implicit operator string(LastName value) => value.Value;
    }
}
