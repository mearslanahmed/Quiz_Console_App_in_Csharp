namespace Quiz
{
    // Abstract base class for reading questions from a data source
    public abstract class QuestionsReader<T> where T : IValidatable
    {
        public List<T>? Data { get; set; } // List of questions

        // Constructor to load and validate questions
        public QuestionsReader(string filename)
        {
            GetData(filename); // Load data
            Data!.ForEach(d => d.Validate()); // Validate each question
        }

        // Abstract method to be implemented by subclasses for loading data
        protected abstract void GetData(string filename);
    }
}