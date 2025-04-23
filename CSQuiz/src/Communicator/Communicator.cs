namespace Quiz
{
    // Abstract base class for handling communication in the quiz
    public abstract class Communicator
    {
        public abstract void WriteGameTitle(); // Writes the game title
        public abstract void WriteQuestionHeader<T>(T t, int ordinalNumber) where T : QuestionData; // Writes the question header
        public abstract void WriteQuestion<T>(T t, int ordinalNumber) where T : QuestionData; // Writes the question text
        public abstract void WriteAnswers<T>(T t, int ordinalNumber) where T : QuestionData; // Writes the possible answers
        public abstract void WriteAnswer(int number, string answer); // Writes a single answer
        public abstract void WriteRequestToTypeNumber(int min, int max); // Writes a request to input a number within a range
        public abstract void WriteCorrectAnswer<T>(T t) where T : QuestionData; // Writes a message for a correct answer
        public abstract void WriteWrongAnswer<T>(T t) where T : QuestionData; // Writes a message for a wrong answer
        public abstract void WriteEnd(); // Writes a message indicating the end of the game
    }
}