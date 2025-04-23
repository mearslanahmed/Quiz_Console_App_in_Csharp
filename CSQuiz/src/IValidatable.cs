namespace Quiz
{
    // Interface representing a validatable entity
    public interface IValidatable
    {
        /// <summary>
        /// Validates the implementing object.
        /// </summary>
        void Validate();
    }
}