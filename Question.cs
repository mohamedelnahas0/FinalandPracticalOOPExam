using Final_and_Practical_Exam;


public abstract class Question
{
    public string Body { get; }
    public string Explanation { get; }
    public int Difficulty { get; }
    public List<Answer> Options { get; }
    public Answer CorrectAnswer { get; set; }

    public Question(string body, string explanation, int difficulty, List<Answer> options)
    {
        Body = body;
        Explanation = explanation;
        Difficulty = difficulty;
        Options = options;
    }

    public abstract string GetQuestionType();

    public abstract bool IsCorrectAnswer(string userAnswer);

    public void DisplayAnswers()
    {
        foreach (var option in Options)
        {
            Console.WriteLine($"{option.AnswerId}: {option.AnswerText}");
        }
    }
}

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion(string body, string explanation, int difficulty, List<Answer> options, Answer correctAnswer) : base(body, explanation, difficulty, options)
    {
        CorrectAnswer = correctAnswer;
    }

    public override bool IsCorrectAnswer(string userAnswer)
    {
        return userAnswer.Equals(CorrectAnswer.AnswerText, StringComparison.OrdinalIgnoreCase);
    }

    public override string GetQuestionType()
    {
        return "TrueFalse";
    }
}

public class MultipleChoiceQuestion : Question
{
    public MultipleChoiceQuestion(string body, string explanation, int difficulty, List<Answer> options, Answer correctAnswer) : base(body, explanation, difficulty, options)
    {
        CorrectAnswer = correctAnswer;
    }

    public override bool IsCorrectAnswer(string userAnswer)
    {
        int selectedOption;
        if (int.TryParse(userAnswer, out selectedOption))
        {
            return selectedOption == CorrectAnswer.AnswerId;
        }
        return false;
    }

    public override string GetQuestionType()
    {
        return "MultipleChoice";
    }
}