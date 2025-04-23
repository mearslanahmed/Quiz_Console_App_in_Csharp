# Algorithmic Solution for Conducting a Quiz

## Pseudo-Code
```plaintext
Algorithm ConductQuiz
Input: QuestionsList (a list of questions), MaxScore (maximum possible score)
Output: FinalScore (total score of the participant)

BEGIN
    // Initialize variables
    SET FinalScore ← 0
    SET QuestionNumber ← 1

    // Display game title
    CALL DisplayGameTitle()

    // Loop through each question in the QuestionsList
    FOR EACH Question IN QuestionsList DO
        // Display question header
        CALL DisplayQuestionHeader(QuestionNumber)

        // Display the question and its answers
        CALL DisplayQuestion(Question)
        CALL DisplayAnswers(Question)

        // Get the user's answer
        CALL DisplayRequestToTypeNumber(1, NumberOfAnswers(Question))
        SET UserAnswer ← GetUserInput()

        // Validate the user's answer
        IF ValidateAnswer(Question, UserAnswer) THEN
            // Correct answer
            CALL DisplayCorrectAnswer()
            SET FinalScore ← FinalScore + Points(Question)
        ELSE
            // Wrong answer
            CALL DisplayWrongAnswer()
        END IF

        // Increment the question number
        SET QuestionNumber ← QuestionNumber + 1
    END FOR

    // Display final score
    CALL DisplayFinalScore(FinalScore, MaxScore)

END
```

## Explanation
- **Initialization**: Sets up the initial state of the quiz.
- **Game Title**: Displays the title of the quiz.
- **Iterating Through Questions**: Loops through the list of questions to display and validate user answers.
- **Answer Validation**: Checks if the user's input matches the correct answer.
- **Final Score**: Displays the user's total score at the end.

## Flow Chart
1. **Start** → Initialize Variables.
2. Display Game Title → Loop through Questions:
   - **Condition**: Is there a next question?
     - **Yes** → Display Question and Answers → Get User Input → Validate Answer:
       - **Correct** → Increment Score.
       - **Incorrect** → Display Wrong Message.
     - **No** → Exit Loop → Display Final Score.
3. **End**.