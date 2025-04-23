namespace Quiz
{
	public class Program
	{
		public static void Main(string[] args)
		{
            Console.WriteLine("Starting the Quiz Application...");

            //launch the quiz
            new Launcher();

            // Pause at the end to prevent console from closing
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
	}
}