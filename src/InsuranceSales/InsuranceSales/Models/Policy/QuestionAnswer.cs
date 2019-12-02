namespace InsuranceSales.Models.Policy
{
    public enum QuestionTypeEnum
    {
        Text,
        Numeric,
        Choice
    }

    public abstract class QuestionAnswer
    {
        public string QuestionCode { get; set; }
        public abstract QuestionTypeEnum QuestionType { get; }

    }

    public abstract class QuestionAnswer<T> : QuestionAnswer
    {
        public T Answer { get; set; }

    }

    public class TextQuestionAnswer : QuestionAnswer<string>
    {
        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Text;
    }


    public class NumericQuestionAnswer : QuestionAnswer<decimal>
    {
        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Numeric;
    }

    public class ChoiceQuestionAnswer : QuestionAnswer<string>
    {
        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Choice;
    }
}
