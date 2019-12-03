using InsuranceSales.Interfaces;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Product;
using InsuranceSales.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Product
{
    public class ProductDetailsViewModel : ViewModelBase
    {
        #region SERVICES
        private readonly NetworkManager _networkManager;
        #endregion

        #region COMMANDS

        private ICommand _createOfferCommand;
        public ICommand CreateOfferCommand => _createOfferCommand ??= new Command(async () => await CreateOfferWizard());

        #endregion

        #region PROPS
        private ProductModel _productModel;

        private Guid _productId;
        public Guid ProductId { get => _productId; set => SetProperty(ref _productId, value); }

        private string _productCode;
        public string ProductCode { get => _productCode; set => SetProperty(ref _productCode, value); }

        private CoverModel[] _covers;
        public CoverModel[] Covers { get => _covers; set => SetProperty(ref _covers, value); }

        private QuestionModel[] _questions;
        public QuestionModel[] Questions { get => _questions; set => SetProperty(ref _questions, value); }

        private string _name;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private string _description;
        public string Description { get => _description; set => SetProperty(ref _description, value); }

        private long _maxNumberOfInsured;
        public long MaxNumberOfInsured { get => _maxNumberOfInsured; set => SetProperty(ref _maxNumberOfInsured, value); }

        private ImageSource _image;
        public ImageSource Image { get => _image; set => SetProperty(ref _image, value); }
        #endregion

        /// <summary>
        /// TESTING ONLY
        /// </summary>
        public ProductDetailsViewModel(
            NetworkManager networkManager,
            IAuthenticationService authenticationService
            ) : base(authenticationService)
        {
            _networkManager = networkManager;
        }

        public ProductDetailsViewModel() : this(
            App.NetworkManager,
            DependencyService.Resolve<IAuthenticationService>()
            )
        { }

        public override async Task InitializeAsync()
        {
            IsBusy = true;

            var product = await _networkManager.GetProductByCodeAsync(ProductCode);
            SetupProperties(product);

            IsBusy = false;

            await base.InitializeAsync();
        }

        private void SetupProperties(ProductModel product)
        {
            _productModel = product;

            Name = product.Name;
            Description = product.Description;
            ProductCode = product.Code;
            MaxNumberOfInsured = product.MaxNumberOfInsured;
            Image = product.Image;
            Covers = product.Covers;
            Questions = product.Questions;
        }

        private async Task CreateOfferWizard()
        {
            if (_productModel != null && _productModel.Id != Guid.Empty)
                await Shell.Current.GoToAsync($"/Policy/CreateOffer?productCode={_productModel.Code}");
        }

    }
}
