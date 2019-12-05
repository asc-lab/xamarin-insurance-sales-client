using InsuranceSales.Extensions;
using InsuranceSales.Models.Offer;
using InsuranceSales.ViewModels.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicEntryView
    {
        #region SERVICES

        private readonly IValueConverter _stringToIntConverter = new StringToIntConverter();

        #endregion

        #region PROPS

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
                    picker.SetBinding(Picker.ItemsSourceProperty, nameof(vm.Choices)); // TODO
                    EntryLayout.Children.Add(picker);
                    break;
                case QuestionTypeEnum.Numeric:
                    var slider = new Slider(0, ulong.MaxValue, 0);
                    slider.SetBinding(Slider.ValueProperty, nameof(vm.SelectedValue), BindingMode.TwoWay); // TODO

                    var numericEntry = new Entry { Keyboard = Keyboard.Numeric };
                    numericEntry.SetBinding(Entry.PlaceholderProperty, nameof(vm.Placeholder));
                    numericEntry.SetBinding(Entry.TextProperty, nameof(vm.SelectedValue), BindingMode.TwoWay, _stringToIntConverter); // TODO

                    var selectedValueLabel = new Label();
                    selectedValueLabel.SetBinding(Label.TextProperty, nameof(vm.SelectedValue)); // TODO

                    EntryLayout.Children.Add(selectedValueLabel);
                    EntryLayout.Children.Add(numericEntry);
                    EntryLayout.Children.Add(slider);
                    break;
                case QuestionTypeEnum.Text:
                    var textEntry = new Entry();
                    textEntry.SetBinding(Entry.PlaceholderProperty, nameof(vm.Placeholder));
                    EntryLayout.Children.Add(textEntry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type));
            }
            base.OnBindingContextChanged();
        }

        public Tuple<string, object> GetAnswer()
        {
            if (!(BindingContext is DynamicEntryViewModel vm))
                return null;

            var answer = vm.Type switch
            {
                QuestionTypeEnum.Text => Tuple.Create<string, object>(vm.Code, vm.SelectedText),
                QuestionTypeEnum.Numeric => Tuple.Create<string, object>(vm.Code, vm.SelectedValue),
                QuestionTypeEnum.Choice => Tuple.Create<string, object>(vm.Code, vm.SelectedChoice),
                _ => throw new ArgumentOutOfRangeException()
            };
            return answer;
        }
    }
}