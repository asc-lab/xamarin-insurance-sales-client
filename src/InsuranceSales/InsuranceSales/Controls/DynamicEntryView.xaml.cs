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
        public string Placeholder { get; private set; }

        public IList<ChoiceModel> Choices { get; private set; }

        public ChoiceModel Choice { get; private set; }
        #endregion

        public DynamicEntryView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (!(BindingContext is QuestionModel questionModel))
                return;

            Placeholder = questionModel.Text;
            Choices = questionModel.Choices;

            View view;
            switch (questionModel.Type)
            {
                case QuestionTypeEnum.Choice:
                    view = new Picker();
                    view.SetDynamicResource(Picker.TitleProperty, Placeholder);
                    view.SetDynamicResource(Picker.ItemsSourceProperty, nameof(Choices));
                    EntryLayout.Children.Add(view);
                    break;
                case QuestionTypeEnum.Numeric:
                    view = new Slider(0, ulong.MaxValue, 0);
                    var entry = new Entry();
                    view.SetBinding(Entry.TextProperty, "Value", BindingMode.TwoWay); //? TODO: TEST
                    EntryLayout.Children.Add(entry);
                    EntryLayout.Children.Add(view);
                    break;
                default:
                    return;
            }
            base.OnBindingContextChanged();
        }

        public void OnChoiceSelected(ChoiceModel choice)
        {
            MessagingCenter.Send(this, "OFFER_CHOICE", Choice);
        }
    }
}