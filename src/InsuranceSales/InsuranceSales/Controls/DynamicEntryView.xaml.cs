using InsuranceSales.Extensions;
using InsuranceSales.Models.Offer;
using InsuranceSales.Models.Policy;
using InsuranceSales.ViewModels.Controls;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicEntryView
    {
        #region SERVICES
        private readonly IValueConverter _stringToIntConverter = new IntToStringConverter();
        #endregion

        #region PROPS
        private static readonly double SliderMaxValue = Math.Pow(2, 20);
        #endregion

        public DynamicEntryView() => InitializeComponent();

        protected override async void OnBindingContextChanged()
        {
            if (!(BindingContext is DynamicEntryViewModel vm))
                return;

            await vm.InitializeAsync();

            EntryLayout.Children.Clear();
            switch (vm.Type)
            {
                case QuestionTypeEnum.Choice:
                    var picker = new Picker();
                    picker.SetBinding(Picker.TitleProperty, nameof(vm.Placeholder));
                    picker.SetBinding(Picker.ItemsSourceProperty, nameof(vm.Choices));
                    picker.SetBinding(IsEnabledProperty, nameof(vm.IsEditable));
                    EntryLayout.Children.Add(picker);
                    break;
                case QuestionTypeEnum.Numeric:
                    var slider = new Slider(0, SliderMaxValue, 0);
                    slider.SetBinding(Slider.ValueProperty, nameof(vm.SelectedValue), BindingMode.TwoWay);
                    slider.SetBinding(IsEnabledProperty, nameof(vm.IsEditable));

                    var numericEntry = new Entry { Keyboard = Keyboard.Numeric };
                    numericEntry.SetBinding(Entry.PlaceholderProperty, nameof(vm.Placeholder));
                    numericEntry.SetBinding(Entry.TextProperty, nameof(vm.SelectedValue), BindingMode.TwoWay, _stringToIntConverter);
                    slider.SetBinding(IsEnabledProperty, nameof(vm.IsEditable));

                    EntryLayout.Children.Add(numericEntry);
                    EntryLayout.Children.Add(slider);
                    break;
                case QuestionTypeEnum.Text:
                    var textEntry = new Entry();
                    textEntry.SetBinding(Entry.PlaceholderProperty, nameof(vm.Placeholder));
                    textEntry.SetBinding(IsEnabledProperty, nameof(vm.IsEditable));

                    EntryLayout.Children.Add(textEntry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type));
            }
            base.OnBindingContextChanged();
        }

        public (QuestionModel, object)? GetAnswer()
        {
            if (!(BindingContext is DynamicEntryViewModel vm))
                return null;

            switch (vm.Type)
            {
                case QuestionTypeEnum.Text:
                    return (vm.Question, vm.SelectedText);
                case QuestionTypeEnum.Numeric:
                    return (vm.Question, vm.SelectedValue);
                case QuestionTypeEnum.Choice:
                    return (vm.Question, vm.Question.Choices.SingleOrDefault(c => c.Label == vm.SelectedText));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}