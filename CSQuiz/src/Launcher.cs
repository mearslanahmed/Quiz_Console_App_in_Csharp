namespace Quiz
{
    public class Launcher
    {
        // Fields to manage the different components of the quiz game
        private readonly JSONQuestionsReader<QuestionDataWithPoints> questionsReader; // Reads questions from a JSON file
        private readonly PointsCounter<QuestionDataWithPoints> pointsCounter; // Tracks and calculates the player's points
        private readonly PointsConsoleCommunicator<QuestionDataWithPoints> communicator; // Handles console communication with the user
        private readonly KeyboardInput input; // Handles user input from the keyboard
        private readonly Game<QuestionDataWithPoints> game; // Represents the core game logic and flow

        // Constructor for initializing all components and starting the game
        public Launcher()
        {
            // Initialize components
            questionsReader = new JSONQuestionsReader<QuestionDataWithPoints>(Constants.QUESTIONS_FILENAME); // Reads questions from JSON
            pointsCounter = new PointsCounter<QuestionDataWithPoints>(questionsReader); // Initializes the points counter
            communicator = new PointsConsoleCommunicator<QuestionDataWithPoints>(pointsCounter); // Sets up the console communicator
            input = new KeyboardInput(); // Prepares the keyboard input handler
            game = new Game<QuestionDataWithPoints>(questionsReader, communicator, input); // Sets up the game with its components

            // Configure the game's event handlers
            ConfigureEvents();

            // Start the game
            game.Start();
        }

        // Configures all event handlers for the game
        private void ConfigureEvents()
        {
            ConfigureOnStartEvent(); // Event for when the game starts
            ConfigureOnCorrectAnswerEvent(); // Event for when the user answers correctly
            ConfigureOnWrongAnswerEvent(); // Event for when the user answers incorrectly
            ConfigureOnEndEvent(); // Event for when the game ends
            ConfigureOnIncreaseEvent(); // Event for when the points are increased
        }

        // Configures the event that triggers when the game starts
        private void ConfigureOnStartEvent()
        {
            game.OnStart += communicator.WriteGameTitle; // Writes the game title to the console
        }

        // Configures the event for handling correct answers
        private void ConfigureOnCorrectAnswerEvent()
        {
            game.OnCorrectAnswer += communicator.WriteCorrectAnswer<QuestionDataWithPoints>; // Writes a message for a correct answer
            game.OnCorrectAnswer += delegate (QuestionDataWithPoints qdwp) // Updates the points when the answer is correct
            {
                pointsCounter.Points += qdwp.Points; // Adds the points for the correct answer
            };
        }

        // Configures the event for handling wrong answers
        private void ConfigureOnWrongAnswerEvent()
        {
            game.OnWrongAnswer += communicator.WriteWrongAnswer<QuestionDataWithPoints>; // Writes a message for a wrong answer
        }

        // Configures the event that triggers when the game ends
        private void ConfigureOnEndEvent()
        {
            game.OnEnd += communicator.WriteEnd; // Writes a message indicating the end of the game
            game.OnEnd += communicator.WriteTotalPoints; // Writes the total points scored by the user
        }

        // Configures the event for handling point increases
        private void ConfigureOnIncreaseEvent()
        {
            pointsCounter.OnIncrease += communicator.WriteGainedPoints; // Writes a message for points gained
        }
    }
}