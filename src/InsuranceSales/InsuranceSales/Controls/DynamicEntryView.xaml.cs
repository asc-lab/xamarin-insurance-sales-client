using InsuranceSales.Models.Offer;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Product;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicEntryView
    {
        #region PROPS
        public IList<ChoiceModel> Choices { get; protected set; }

        public ChoiceModel SelectedChoice { get; protected set; }
        #endregion

        public DynamicEntryView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (!(BindingContext is QuestionModel questionModel))
                return;

            Choices = questionModel.Choices;

            View view;
            switch (questionModel.Type)
            {
                case QuestionTypeEnum.Choice:
                    view = new Picker();
                    view.SetDynamicResource(Picker.TitleProperty, questionModel.Text);
                    view.SetDynamicResource(Picker.ItemsSourceProperty, nameof(Choices));
                    EntryLayout.Children.Add(view);
                    break;
                case QuestionTypeEnum.Numeric:
                    view = new Slider(0, ulong.MaxValue, 0);
                    var numericEntry = new Entry();
                    view.SetBinding(Entry.TextProperty, "Value", BindingMode.TwoWay); // TODO: TEST BINDING
                    EntryLayout.Children.Add(numericEntry);
                    EntryLayout.Children.Add(view);
                    break;
                case QuestionTypeEnum.Text:
                    var textEntry = new Entry();
                    EntryLayout.Children.Add(textEntry);
                    break;
                default:
                    return;
            }
            base.OnBindingContextChanged();
        }
    }
}