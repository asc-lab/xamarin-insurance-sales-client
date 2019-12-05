using InsuranceSales.ViewModels.Controls;
using System;
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

            EntriesLayout.Children.Clear();
            foreach (var question in vm.Questions.OrderBy(q => q.Index))
            {
                var entryViewModel = new DynamicEntryViewModel { Question = question };
                var entry = new DynamicEntryView { BindingContext = entryViewModel };
                _entryViews.Add(entry);
            }
            foreach (var view in _entryViews)
                EntriesLayout.Children.Add(view);

            base.OnBindingContextChanged();
        }

        public IReadOnlyDictionary<string, object> GetAnswers()
        {
            var dict = new Dictionary<string, object>();
            foreach (var entry in _entryViews)
            {
                var (code, answer) = entry.GetAnswer();
                dict.Add(code, answer);
            }
            return dict;
        }
    }
}