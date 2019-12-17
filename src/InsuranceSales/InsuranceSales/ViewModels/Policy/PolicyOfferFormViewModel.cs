using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer;
using InsuranceSales.Models.Offer.Dto;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Policy.Dto;
using InsuranceSales.Models.Product;
using InsuranceSales.Services;
using InsuranceSales.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Policy
{
    [QueryProperty(nameof(ProductCode), "productCode")]
    public class PolicyOfferFormViewModel : ViewModelBase
    {
        #region SERVICES
        private readonly NetworkManager _networkManager;
        #endregion

        #region COMMANDS

        private ICommand _sendNewOfferCommand;
        public ICommand SendNewOfferCommand => _sendNewOfferCommand ??= new Command<IDictionary<QuestionModel, object>>(
            async answers => await SendNewOfferAsync(answers));

        private ICommand _changeParametersCommand;
        public ICommand ChangeParametersCommand => _changeParametersCommand ??= new Command(async () => await ChangeParametersAsync());

        private ICommand _buyNowCommand;
        public ICommand BuyNowCommand => _buyNowCommand ??= new Command(async () => await BuyNowAsync());
        #endregion

        #region PROPS
        private DynamicEntriesViewModel _dynamicEntriesViewModel;
        public DynamicEntriesViewModel DynamicEntriesViewModel { get => _dynamicEntriesViewModel; set => SetProperty(ref _dynamicEntriesViewModel, value); }

        //! STEP 1
        private string _productCode = string.Empty;
        public string ProductCode { get => _productCode; set => SetProperty(ref _productCode, value); }

        private string _productName = string.Empty;
        public string ProductName { get => _productName; set => SetProperty(ref _productName, value); }

        private DateTime _productFrom;
        public DateTime ProductFrom { get => _productFrom; set => SetProperty(ref _productFrom, value); }

        private DateTime _productTo;
        public DateTime ProductTo { get => _productTo; set => SetProperty(ref _productTo, value); }

        private IList<QuestionModel> _questions;
        public IList<QuestionModel> Questions { get => _questions; set => SetProperty(ref _questions, value); }

        private IList<CoverModel> _covers;
        public IList<CoverModel> Covers { get => _covers; set => SetProperty(ref _covers, value); }

        //! STEP 2
        private bool _isOnStepTwo;
        public bool IsOnStepTwo { get => _isOnStepTwo; set => SetProperty(ref _isOnStepTwo, value); }

        private CreateOfferResultDto _offer;
        public CreateOfferResultDto Offer { get => _offer; set => SetProperty(ref _offer, value); }

        //! STEP 3
        private bool _isOnStepThree;
        public bool IsOnStepThree { get => _isOnStepThree; set => SetProperty(ref _isOnStepThree, value); }

        // Person
        private string _firstName = string.Empty;
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }

        private string _lastName = string.Empty;
        public string LastName { get => _lastName; set => SetProperty(ref _lastName, value); }

        private string _taxId = string.Empty;
        public string TaxId { get => _taxId; set => SetProperty(ref _taxId, value); }

        // Address
        private string _country = string.Empty;
        public string Country { get => _country; set => SetProperty(ref _country, value); }

        private string _zipCode = string.Empty;
        public string ZipCode { get => _zipCode; set => SetProperty(ref _zipCode, value); }

        private string _city = string.Empty;
        public string City { get => _city; set => SetProperty(ref _city, value); }

        private string _street = string.Empty;
        public string Street { get => _street; set => SetProperty(ref _street, value); }
        #endregion

        /// <summary>
        /// TESTING ONLY
        /// </summary>
        public PolicyOfferFormViewModel(
            NetworkManager networkManager,
            IAuthenticationService authenticationService
        ) : base(authenticationService)
        {
            _networkManager = networkManager;
        }

        public PolicyOfferFormViewModel() : this(
            App.NetworkManager,
            DependencyService.Resolve<IAuthenticationService>()
        )
        { }

        public override async Task InitializeAsync()
        {
            var product = await _networkManager.GetProductByCodeAsync(ProductCode);
            ProductName = product.Name;
            Questions = product.Questions;
            Covers = product.Covers;
            DynamicEntriesViewModel = new DynamicEntriesViewModel { Questions = Questions };

            await base.InitializeAsync();
        }

        public static QuestionAnswerModel MapQuestionsToAnswers(KeyValuePair<QuestionModel, object> qaPair)
        {
            var (question, answer) = qaPair;
            var answerModel = question.Type switch
            {
                QuestionTypeEnum.Text => (QuestionAnswerModel)new TextQuestionAnswerModel { QuestionCode = question.Code, Answer = (string)answer },
                QuestionTypeEnum.Numeric => new NumericQuestionAnswerModel { QuestionCode = question.Code, Answer = decimal.Parse(answer.ToString(), CultureInfo.CurrentCulture) },
                QuestionTypeEnum.Choice => new ChoiceQuestionAnswerModel { QuestionCode = question.Code, Answer = (string)answer },
                _ => throw new ApplicationException($"Unexpected question type {Enum.GetName(typeof(QuestionTypeEnum), question)}")
            };
            return answerModel;
        }

        private async Task SendNewOfferAsync(IDictionary<QuestionModel, object> entryAnswers)
        {
            IsBusy = true;

            DynamicEntriesViewModel.IsEditable = false;

            var answers = entryAnswers?.Select(MapQuestionsToAnswers);
            var covers = Covers?.Select(c => c.Code);
            var request = new CreateOfferRequestDto
            {
                ProductCode = ProductCode,
                PolicyFrom = ProductFrom,
                PolicyTo = ProductTo,
                SelectedCovers = covers,
                Answers = answers,
            };
            var result = await _networkManager.CreateOfferAsync(request);
            if (result != null)
            {
                Offer = result;
                IsOnStepTwo = true;
            }
            IsBusy = false;

            await Task.CompletedTask;
        }

        public async Task ChangeParametersAsync()
        {
            IsBusy = true;

            IsOnStepTwo = false;
            IsOnStepThree = false;
            DynamicEntriesViewModel.IsEditable = true;

            IsBusy = false;

            await Task.CompletedTask;
        }

        private async Task BuyNowAsync()
        {
            IsBusy = true;

            IsOnStepTwo = false;
            IsOnStepThree = true;
            DynamicEntriesViewModel.IsEditable = false;

            var policyHolder = new PersonModel
            {
                FirstName = FirstName,
                LastName = LastName,
                TaxId = TaxId,
            };
            var holderAddress = new AddressModel
            {
                City = City,
                Country = Country,
                Street = Street,
                ZipCode = ZipCode,
            };

            var request = new CreatePolicyRequestDto
            {
                OfferNumber = Offer.OfferNumber,
                PolicyHolder = policyHolder,
                PolicyHolderAddress = holderAddress,

            };
            var result = await _networkManager.CreatePolicyAsync(request, ""); //! TODO

            await Shell.Current.GoToAsync($"/Policy/Details?policyNumber={result.PolicyNumber}");

            IsBusy = false;
        }
    }
}
