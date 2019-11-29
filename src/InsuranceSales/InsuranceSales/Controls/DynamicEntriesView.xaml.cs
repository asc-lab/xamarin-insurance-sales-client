using InsuranceSales.Models.Policy;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicEntriesView
    {
        public DynamicEntriesView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (BindingContext is IEnumerable<QuestionModel> questions)
            {
                foreach (var question in questions)
                {
                    var entry = new DynamicEntryView { BindingContext = question };
                    Entries.Children.Add(entry);
                }
            }
            base.OnBindingContextChanged();
        }
    }
}