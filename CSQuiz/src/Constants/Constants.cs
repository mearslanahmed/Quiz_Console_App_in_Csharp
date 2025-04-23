namespace Quiz
{
    // Holds constant values used throughout the application
    public static class Constants
    {
        // The title of the game
        public static readonly string GAME_TITLE = "QUIZ";

        // The filename where questions are stored
        public static readonly string QUESTIONS_FILENAME = "questions.json";

        // Messages displayed during gameplay
        public static readonly string INCORRECT_RANGE_OF_NUMBERS_EXCEPTION_MESSAGE = "Incorrect range of numbers! Minimum is greater than maximum!";
        public static readonly string QUESTION_MESSAGE = "QUESTION";
        public static readonly string CORRECT_ANSWER_MESSAGE = "Correct!";
        public static readonly string WRONG_ANSWER_MESSAGE = "Wrong!";
        public static readonly string GAME_END_MESSAGE = "This is the end!";

        // Strings used for input prompts
        public static readonly string TYPE_NUMBER_STRING = "Type number";
        public static readonly string FROM_STRING = "from";
        public static readonly string TO_STRING = "to";
    }
}