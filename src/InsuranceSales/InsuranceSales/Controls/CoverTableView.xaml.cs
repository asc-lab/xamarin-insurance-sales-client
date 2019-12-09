using InsuranceSales.Models.Product;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoverTableView
    {
        public CoverTableView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (!(BindingContext is IList<CoverModel> covers))
                return;

            for (var i = 0; i < covers.Count; i++)
            {
                var index = i + 1;
                var cover = covers[i];
                var indexLabel = new Label { Text = index.ToString(CultureInfo.CurrentCulture), HorizontalTextAlignment = TextAlignment.End };
                var nameLabel = new Label { Text = cover.Name };
                var sumInsuredLabel = new Label { Text = cover.SumInsured.ToString() };

                CoverTableGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                CoverTableGrid.Children.Add(indexLabel, 0, index);
                CoverTableGrid.Children.Add(nameLabel, 1, index);
                CoverTableGrid.Children.Add(sumInsuredLabel, 2, index);
            }
            base.OnBindingContextChanged();
        }
    }
}