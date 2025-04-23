namespace Quiz
{
    // Represents a question in the quiz with an associated point value
    public class QuestionDataWithPoints : QuestionData
    {
        public int Points { get; set; } // The number of points awarded for a correct answer

        // Validates the question data and ensures the point value is valid
        public new void Validate()
        {
            base.Validate(); // Validate the base question data

            if (Points <= 0)
            {
                throw new ArgumentException("Points must be greater than 0.");
            }
        }
    }
}