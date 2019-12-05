using InsuranceSales.Models.Policy;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicEntriesView
    {
        public DynamicEntriesView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (!(BindingContext is IEnumerable<QuestionModel> questions))
                return;

            Entries.Children.Clear();
            foreach (var question in questions.OrderBy(q => q.Index))
            {
                var entry = new DynamicEntryView { BindingContext = question };
                Entries.Children.Add(entry);
            }
            base.OnBindingContextChanged();
        }

        public IReadOnlyDictionary<string, object> GetAnswers()
        {
            var dict = new Dictionary<string, object>();
            foreach (var entry in Entries.Children.OfType<DynamicEntryView>())
            {
                var (code, answer) = entry.GetAnswer();
                dict.Add(code, answer);
            }
            return dict;
        }
    }
}