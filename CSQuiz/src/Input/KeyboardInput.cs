namespace Quiz
{
    // Handles keyboard input from the user
    public class KeyboardInput : Input
    {
        // Reads a number input from the user within a specified range
        public override int NumberFromInput(Communicator communicator, NumbersRange nr)
        {
            string? s; // User input as a string
            int number; // Parsed number

            do
            {
                communicator.WriteRequestToTypeNumber(nr.min, nr.max); // Prompt the user for input

                s = Console.ReadLine(); // Read input
            }
            while (!int.TryParse(s, out number) || number < nr.min || number > nr.max); // Validate input

            return number; // Return the validated number
        }
    }
}