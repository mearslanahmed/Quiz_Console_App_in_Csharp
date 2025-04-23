using System.Text.Json;

namespace Quiz
{
    // Reads questions from a JSON file
    public class JSONQuestionsReader<T> : QuestionsReader<T> where T : IValidatable
    {
        // Constructor that delegates to the base class
        public JSONQuestionsReader(string filename) : base(filename)
        {
        }

        // Reads and deserializes JSON data from the specified file
        protected override void GetData(string filename)
        {
            string data = File.ReadAllText(filename); // Read the file contents

            Data = JsonSerializer.Deserialize<List<T>>(data); // Deserialize JSON into a list of questions
        }
    }
}