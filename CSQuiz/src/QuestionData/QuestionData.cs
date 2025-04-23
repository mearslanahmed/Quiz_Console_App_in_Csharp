namespace Quiz
{
    // Represents a question in the quiz
    public class QuestionData : IValidatable
    {
        public string? Question { get; set; } // The question text
        public string[]? Answers { get; set; } // Array of possible answers
        public int CorrectAnswer { get; set; } // Index of the correct answer (1-based)

        // Validates the question data to ensure it is correctly formatted
        public virtual void Validate()
        {
            if (CorrectAnswer > Answers!.Length)
            {
                throw new Exception("Incorrect questions data! The number of correct answer is greater than amount of answers!");
            }
            else if (CorrectAnswer < 1)
            {
                throw new Exception("Incorrect questions data! The number of correct answer is less than 1!");
            }
            else if (string.IsNullOrEmpty(Question) || string.IsNullOrWhiteSpace(Question))
            {
                throw new Exception("Incorrect questions data! The question is empty!");
            }
            else if (Answers!.Any<string>(a => string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a)))
            {
                throw new Exception("Incorrect questions data! The answer is empty!");
            }
        }
    }
}