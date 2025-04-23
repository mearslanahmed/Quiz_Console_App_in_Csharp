namespace Quiz
{
    // Abstract class for handling communication with points-related data
    public abstract class PointsCommunicator<T> : ConsoleCommunicator where T : QuestionDataWithPoints
    {
        protected PointsCounter<T> pointsCounter; // Counter to track points

        public PointsCommunicator(PointsCounter<T> pointsCounter)
        {
            this.pointsCounter = pointsCounter;
        }

        public abstract void WriteGainedPoints(int gainedPoints, int points); // Writes a message for gained points
        public abstract void WriteTotalPoints(); // Writes the total points
        public abstract string SingularOrPluralPointNoun(int value); // Determines singular or plural form of 'point'
    }
}