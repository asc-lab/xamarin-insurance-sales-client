using InsuranceSales.Models.Policy;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicEntriesView
    {
        public DynamicEntriesView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (BindingContext is QuestionModel[] questions)
                foreach (var question in questions)
                {
                    var entry = new DynamicEntryView { BindingContext = question };
                    Entries.Children.Add(entry);
                }
            base.OnBindingContextChanged();
        }
    }
}