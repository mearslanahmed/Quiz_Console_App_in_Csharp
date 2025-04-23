using System;

namespace Quiz
{
    // ConsoleCommunicator class to handle all interactions with the console
    public class ConsoleCommunicator : Communicator
    {
        // Writes the game title to the console
        public override void WriteGameTitle()
        {
            Console.WriteLine(Constants.GAME_TITLE);
            Console.WriteLine("Welcome to the Quiz Game! Test your knowledge and have fun!");
            Console.WriteLine("----------------------------------------------------------");
        }

        // Writes the question header (e.g., "Question 1") to the console
        public override void WriteQuestionHeader<T>(T t, int ordinalNumber)
        {
            Console.WriteLine("\nQuestion {0}:", ordinalNumber);
            Console.WriteLine(Constants.QUESTION_MESSAGE);
        }

        // Writes the current progress (e.g., "Progress: Question 1 of 10") to the console
        public void WriteProgress(int currentQuestion, int totalQuestions)
        {
            Console.WriteLine($"Progress: Question {currentQuestion} of {totalQuestions}");
        }

        // Writes the actual question text to the console
        public override void WriteQuestion<T>(T t, int ordinalNumber)
        {
            Console.WriteLine(t.Question);
        }

        // Writes all possible answers for a given question to the console
        public override void WriteAnswers<T>(T t, int ordinalNumber)
        {
            for (int a = 0; a < t.Answers!.Length; ++a)
            {
                WriteAnswer(a + 1, t.Answers[a]);
            }
        }

        // Writes a single answer option (e.g., "1) Answer text") to the console
        public override void WriteAnswer(int number, string answer)
        {
            Console.WriteLine("{0}) {1}", number, answer);
        }

        // Prompts the user to type a number within a specified range
        public override void WriteRequestToTypeNumber(int min, int max)
        {
            Console.WriteLine("\nType your answer:");
            Console.Write("{0} {1} {2} {3} {4}: ", Constants.TYPE_NUMBER_STRING, Constants.FROM_STRING, min, Constants.TO_STRING, max);
        }

        // Writes a message indicating the user's answer was correct
        public override void WriteCorrectAnswer<T>(T t)
        {
            Console.WriteLine(Constants.CORRECT_ANSWER_MESSAGE);
            Console.WriteLine("Great job! Keep it up!");
        }

        // Writes a message indicating the user's answer was wrong
        public override void WriteWrongAnswer<T>(T t)
        {
            Console.WriteLine(Constants.WRONG_ANSWER_MESSAGE);
            Console.WriteLine("Don't worry, you'll get the next one!");
        }

        // Writes the end-of-game message to the console
        public override void WriteEnd()
        {
            Console.WriteLine(Constants.GAME_END_MESSAGE);
            Console.WriteLine("Thank you for playing the Quiz Game! We hope you enjoyed it.");
        }

        // Writes a performance summary after the game ends
        public void WritePerformanceSummary(int score, int totalQuestions)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Your final score: {score} out of {totalQuestions}.");
            if (score == totalQuestions)
            {
                Console.WriteLine("Perfect Score! You're amazing!");
            }
            else if (score > totalQuestions / 2)
            {
                Console.WriteLine("Good job! You did well!");
            }
            else
            {
                Console.WriteLine("Better luck next time. Keep practicing!");
            }
        }
    }
}