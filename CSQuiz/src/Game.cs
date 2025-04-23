namespace Quiz
{
    // Generic Game class for handling the quiz logic
    public class Game<T> where T : QuestionData
    {
        // Delegate definitions for game events
        public delegate void GameOnStartDelegate(); // Delegate for the start of the game
        public delegate void GameOnQuestionAskDelegate(T t, int ordinalNumber); // Delegate for asking a question
        public delegate void GameOnCorrectAnswerDelegate(T t); // Delegate for a correct answer
        public delegate void GameOnWrongAnswerDelegate(T t); // Delegate for a wrong answer
        public delegate void GameOnEndDelegate(); // Delegate for the end of the game

        // Events triggered at various stages of the game
        public event GameOnStartDelegate OnStart = delegate { }; // Event triggered when the game starts
        public event GameOnQuestionAskDelegate OnQuestionAsk = delegate { }; // Event triggered when a question is asked
        public event GameOnCorrectAnswerDelegate OnCorrectAnswer = delegate { }; // Event triggered for a correct answer
        public event GameOnWrongAnswerDelegate OnWrongAnswer = delegate { }; // Event triggered for a wrong answer
        public event GameOnEndDelegate OnEnd = delegate { }; // Event triggered when the game ends

        // Dependencies injected into the game
        private readonly QuestionsReader<T> questionsReader; // Reads the list of questions
        private readonly Communicator communicator; // Handles communication with the user
        private readonly Input input; // Handles user input

        // Constructor initializes the game with its dependencies
        public Game(QuestionsReader<T> questionsReader, Communicator communicator, Input input)
        {
            this.questionsReader = questionsReader; // Initialize questions reader
            this.communicator = communicator; // Initialize communicator
            this.input = input; // Initialize input handler
        }

        // Starts the game
        public void Start()
        {
            OnStart(); // Trigger the OnStart event
            ConfigureOnQuestionAskEvent(); // Configure event for asking questions
            AskQuestions(); // Start asking questions
            OnEnd(); // Trigger the OnEnd event
        }

        // Configures the event for asking questions
        private void ConfigureOnQuestionAskEvent()
        {
            OnQuestionAsk += communicator.WriteQuestionHeader; // Write question header
            OnQuestionAsk += communicator.WriteQuestion; // Display the question text
            OnQuestionAsk += communicator.WriteAnswers; // Display the answer options
        }

        // Iterates through the list of questions and asks them
        private void AskQuestions()
        {
            for (int i = 0; i < questionsReader.Data!.Count; ++i)
            {
                T t = questionsReader.Data[i]; // Get the current question

                OnQuestionAsk(t, i + 1); // Trigger OnQuestionAsk event
                CheckAnswer(t); // Check the user's answer
                Console.WriteLine(); // Add a blank line for spacing
            }
        }

        // Checks if the user's answer is correct or not
        private void CheckAnswer(T t)
        {
            if (AnsweredCorrectly(t))
            {
                OnCorrectAnswer(t); // Trigger OnCorrectAnswer event
            }
            else
            {
                OnWrongAnswer(t); // Trigger OnWrongAnswer event
            }
        }

        // Validates the user's input and returns whether the answer is correct
        private bool AnsweredCorrectly(T t) =>
            input.NumberFromInput(communicator, new NumbersRange(1, t.Answers!.Length)) == t.CorrectAnswer;
    }
}