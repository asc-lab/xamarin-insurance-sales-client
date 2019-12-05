namespace InsuranceSales.Models.Offer
{
    public enum QuestionTypeEnum
    {
        Text,
        Numeric,
        Choice
    }

    public abstract class QuestionAnswerModel
    {
        public string QuestionCode { get; set; }

        public abstract QuestionTypeEnum QuestionType { get; }

        public abstract object GetAnswer();
    }

    public abstract class QuestionAnswerModel<T> : QuestionAnswerModel
    {
        public T Answer { get; set; }

        public override object GetAnswer() => Answer;
    }

    public class TextQuestionAnswerModel : QuestionAnswerModel<string>
    {
        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Text;
    }

    public class NumericQuestionAnswerModel : QuestionAnswerModel<decimal>
    {
        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Numeric;
    }

    public class ChoiceQuestionAnswerModel : QuestionAnswerModel<string>
    {
        public override QuestionTypeEnum QuestionType => QuestionTypeEnum.Choice;
    }
}
