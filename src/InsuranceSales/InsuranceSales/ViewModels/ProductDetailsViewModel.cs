using InsuranceSales.Interfaces;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Product;
using InsuranceSales.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
{
    public class ProductDetailsViewModel : ViewModelBase
    {
        #region SERVICES
        private readonly NetworkManager _networkManager;
        #endregion

        #region PROPS
        private ProductModel _productModel;

        private Guid _productId;
        public Guid ProductId { get => _productId; set => SetProperty(ref _productId, value); }

        private string _code;
        public string Code { get => _code; set => SetProperty(ref _code, value); }

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
            IAuthenticationService authenticationService,
            NetworkManager networkManager)
            : base(authenticationService)
        {
            _networkManager = networkManager;
        }

        public ProductDetailsViewModel()
            : base(DependencyService.Resolve<IAuthenticationService>())
        {
            _networkManager = App.NetworkManager;
        }

        public override async Task InitializeAsync()
        {
            _productModel = await _networkManager.GetProductByIdAsync(ProductId);

            // ASSIGN PROPS
            Code = _productModel.Code;
            Name = _productModel.Name;
            Description = _productModel.Description;
            Image = ImageSource.FromUri(new Uri(_productModel.Image));
            Covers = _productModel.Covers;
            MaxNumberOfInsured = _productModel.MaxNumberOfInsured;
            Questions = _productModel.Questions;

            await base.InitializeAsync();
        }
    }
}
