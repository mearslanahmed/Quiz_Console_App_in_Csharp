namespace Quiz
{
    // Delegate for handling points increase events
    public delegate void PointsCounterOnIncreaseDelegate(int gainedPoints, int points);

    // Class to handle points logic for a quiz
    public class PointsCounter<T> where T : QuestionDataWithPoints
    {
        // Event triggered when points increase
        public event PointsCounterOnIncreaseDelegate OnIncrease = delegate { };

        // Current points
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                int previous = points;

                points = value;

                // Trigger event if points increased
                if (value > 0)
                {
                    OnIncrease(points - previous, points);
                }
            }
        }

        // Maximum possible points
        public int MaxPoints
        {
            get
            {
                return questionsReader.Data!.Sum<T>(d => d.Points);
            }
        }

        private int points = 0; // Backing field for Points
        private QuestionsReader<T> questionsReader; // Reader for quiz questions

        // Constructor to initialize with a questions reader
        public PointsCounter(QuestionsReader<T> questionsReader)
        {
            this.questionsReader = questionsReader;
        }
    }
}