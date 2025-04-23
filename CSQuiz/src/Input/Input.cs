namespace Quiz
{
    // Abstract base class for handling user input
    public abstract class Input
    {
        // Abstract method for reading a number from the user
        public abstract int NumberFromInput(Communicator communicator, NumbersRange nr);
    }
}