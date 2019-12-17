using InsuranceSales.Models.Product;
using InsuranceSales.Resources;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceSales.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoverTableView
    {
        private readonly ColorsDictionary _colorsDictionary = new ColorsDictionary();

        public CoverTableView() => InitializeComponent();

        protected override void OnBindingContextChanged()
        {
            if (!(BindingContext is IList<CoverModel> covers))
                return;

            var color1 = (Color)_colorsDictionary["BackgroundColor"];
            var color2 = (Color)_colorsDictionary["PrimaryLight"];
            for (var i = 0; i < covers.Count; i++)
            {
                var index = i + 1;
                var cover = covers[i];
                var rowColor = index % 2 == 0 ? color1 : color2;
                var indexLabel = new Label
                {
                    Text = index.ToString(CultureInfo.CurrentCulture),
                    Padding = new Thickness(2),
                    BackgroundColor = rowColor
                };
                var nameLabel = new Label
                {
                    Text = cover.Name,
                    Padding = new Thickness(2),
                    BackgroundColor = rowColor
                };
                var sumInsuredLabel = new Label
                {
                    Text = cover.SumInsured.ToString(),
                    Padding = new Thickness(2),
                    BackgroundColor = rowColor
                };

                CoverTableGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                CoverTableGrid.Children.Add(indexLabel, 0, index);
                CoverTableGrid.Children.Add(nameLabel, 1, index);
                CoverTableGrid.Children.Add(sumInsuredLabel, 2, index);
            }
            base.OnBindingContextChanged();
        }
    }
}