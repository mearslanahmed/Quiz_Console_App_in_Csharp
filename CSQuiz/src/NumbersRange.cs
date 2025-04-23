namespace Quiz
{
    // Represents a range of numbers with validation
    public readonly struct NumbersRange : IValidatable
    {
        public readonly int min, max; // Minimum and maximum of the range

        // Constructor to initialize the range and validate it
        public NumbersRange(int min, int max)
        {
            this.min = min;
            this.max = max;

            Validate(); // Validate the range
        }

        // Ensures the range is valid (min <= max)
        public void Validate()
        {
            if (min > max)
            {
                throw new Exception(Constants.INCORRECT_RANGE_OF_NUMBERS_EXCEPTION_MESSAGE);
            }
        }
    }
}