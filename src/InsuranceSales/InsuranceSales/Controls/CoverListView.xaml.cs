using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoverListView
    {
        public CoverListView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (!(BindingContext is IList<string> covers) || !covers.Any())
                return;

            var coverLabels = covers.Where(c => !string.IsNullOrWhiteSpace(c))
                .Select(c => new Label
                {
                    Text = c,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                });
            foreach (var label in coverLabels)
                PolicyCovers.Children.Add(label);

            base.OnBindingContextChanged();
        }
    }
}