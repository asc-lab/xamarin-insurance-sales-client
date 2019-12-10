using InsuranceSales.Models.Policy;
using InsuranceSales.ViewModels.Controls;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicEntriesView
    {
        #region PROPS
        private readonly IList<DynamicEntryView> _entryViews = new List<DynamicEntryView>();
        #endregion

        public DynamicEntriesView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (!(BindingContext is DynamicEntriesViewModel vm))
                return;

            _entryViews?.Clear();
            EntriesLayout.Children?.Clear();
            foreach (var question in vm.Questions.OrderBy(q => q.Index))
            {
                var entryViewModel = new DynamicEntryViewModel { Question = question };
                var entryView = new DynamicEntryView { BindingContext = entryViewModel };
                _entryViews?.Add(entryView);
                EntriesLayout.Children?.Add(entryView);
            }
            base.OnBindingContextChanged();
        }

        public IDictionary<QuestionModel, object> GetAnswers()
        {
            var answers = _entryViews?.Select(ev => ev?.GetAnswer())
                .ToDictionary(k => k?.Item1, v => v?.Item2);

            return answers;
        }
    }
}