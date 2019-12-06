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

            var indexHeader = new Label { Text = "Index", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
            var nameHeader = new Label { Text = nameof(CoverModel.Name), FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
            var sumInsuredHeader = new Label { Text = "Sum Insured", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };

            CoverTableGrid.Padding = new Thickness(2, 4);
            CoverTableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.5, GridUnitType.Star) });
            CoverTableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            CoverTableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            CoverTableGrid.Children.Add(indexHeader, 0, 0);
            CoverTableGrid.Children.Add(nameHeader, 1, 0);
            CoverTableGrid.Children.Add(sumInsuredHeader, 2, 0);

            for (var i = 0; i < covers.Count; i++)
            {
                var cover = covers[i];
                var indexLabel = new Label { Text = i.ToString(CultureInfo.CurrentCulture), HorizontalTextAlignment = TextAlignment.End };
                var nameLabel = new Label { Text = cover.Name };
                var sumInsuredLabel = new Label { Text = cover.SumInsured.ToString() };

                CoverTableGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                CoverTableGrid.Children.Add(indexLabel, 0, i + 1);
                CoverTableGrid.Children.Add(nameLabel, 1, i + 1);
                CoverTableGrid.Children.Add(sumInsuredLabel, 2, i + 1);
            }
            base.OnBindingContextChanged();
        }
    }
}