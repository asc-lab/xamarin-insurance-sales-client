using InsuranceSales.Models.Offer;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Product;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicEntryView
    {
        #region PROPS
        public QuestionModel Question { get; set; }

        public string Code { get; set; }

        public QuestionTypeEnum Type { get; set; }

        public IList<ChoiceModel> Choices { get; protected set; }

        public ChoiceModel SelectedChoice { get; protected set; }

        public string Placeholder { get; protected set; } = string.Empty;

        public string SelectedText { get; protected set; } = string.Empty;

        public ulong SelectedValue { get; protected set; }
        #endregion

        public DynamicEntryView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (!(BindingContext is QuestionModel question))
                return;

            Question = question;
            Code = question.Code;
            Type = question.Type;
            Placeholder = question.Text;

            EntryLayout.Children.Clear();
            switch (Type)
            {
                case QuestionTypeEnum.Choice:
                    var picker = new Picker();
                    picker.SetBinding(Picker.TitleProperty, nameof(Placeholder));
                    picker.SetBinding(Picker.ItemsSourceProperty, nameof(Choices)); // TODO
                    EntryLayout.Children.Add(picker);
                    break;
                case QuestionTypeEnum.Numeric:
                    // Bind both elements to single property in both ways
                    var slider = new Slider(0, ulong.MaxValue, 0);
                    slider.SetBinding(Slider.ValueProperty, nameof(SelectedValue), BindingMode.TwoWay); // TODO
                    var numericEntry = new Entry() { Keyboard = Keyboard.Numeric };
                    numericEntry.SetBinding(Entry.PlaceholderProperty, nameof(Placeholder));
                    numericEntry.SetBinding(Entry.TextProperty, nameof(SelectedValue), BindingMode.TwoWay); // TODO
                    EntryLayout.Children.Add(numericEntry);
                    EntryLayout.Children.Add(slider);
                    break;
                case QuestionTypeEnum.Text:
                    var textEntry = new Entry();
                    textEntry.SetBinding(Entry.PlaceholderProperty, nameof(Placeholder));
                    EntryLayout.Children.Add(textEntry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type));
            }
            base.OnBindingContextChanged();
        }

        public (string, object) GetAnswer()
        {
            switch (Type)
            {
                case QuestionTypeEnum.Text:
                    return (Code, SelectedText);
                case QuestionTypeEnum.Numeric:
                    return (Code, SelectedValue);
                case QuestionTypeEnum.Choice:
                    return (Code, SelectedChoice);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}