using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer;
using InsuranceSales.Models.Offer.Dto;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Product;
using InsuranceSales.Services;
using InsuranceSales.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Policy
{
    //! TODO: Look up how to create a policy offer
    //! TODO: Obtain data from DynamicEntriesView
    //! TODO: Create entries for client name/surname/tax ID
    [QueryProperty(nameof(ProductCode), "productCode")]
    public class PolicyOfferFormViewModel : ViewModelBase
    {
        #region SERVICES
        private readonly NetworkManager _networkManager;
        #endregion

        #region PROPS
        private DynamicEntriesViewModel _dynamicEntriesViewModel;
        public DynamicEntriesViewModel DynamicEntriesViewModel { get => _dynamicEntriesViewModel; set => SetProperty(ref _dynamicEntriesViewModel, value); }

        /// STEP 1
        private string _productCode;
        public string ProductCode { get => _productCode; set => SetProperty(ref _productCode, value); }

        private string _productName;
        public string ProductName { get => _productName; set => SetProperty(ref _productName, value); }

        private DateTime _productFrom;
        public DateTime ProductFrom { get => _productFrom; set => SetProperty(ref _productFrom, value); }

        private DateTime _productTo;
        public DateTime ProductTo { get => _productTo; set => SetProperty(ref _productTo, value); }

        private IList<QuestionModel> _questions;
        public IList<QuestionModel> Questions { get => _questions; set => SetProperty(ref _questions, value); }

        private IList<CoverModel> _covers;
        public IList<CoverModel> Covers { get => _covers; set => SetProperty(ref _covers, value); }

        /// STEP 2
        private bool _isOffering;
        public bool IsOffering { get => _isOffering; set => SetProperty(ref _isOffering, value); }
        public bool IsNotOffering => !_isOffering;

        private CreateOfferResult _offer;
        public CreateOfferResult Offer { get => _offer; set => SetProperty(ref _offer, value); }

        /// STEP 3
        private bool _isBuying;
        public bool IsBuying { get => _isBuying; set => SetProperty(ref _isBuying, value); }
        public bool IsNotBuying => !_isBuying;

        private AddressModel _address;
        public AddressModel Address { get => _address; set => SetProperty(ref _address, value); }

        private PersonModel _person;
        public PersonModel Person { get => _person; set => SetProperty(ref _person, value); }


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

        public static QuestionAnswerModel MapQuestionsToAnswers(Tuple<QuestionModel, object> qaTuple)
        {
            var (question, answer) = qaTuple;
            var answerModel = question.Type switch
            {
                QuestionTypeEnum.Text => (QuestionAnswerModel)new TextQuestionAnswerModel { QuestionCode = question.Code, Answer = (string)answer },
                QuestionTypeEnum.Numeric => new NumericQuestionAnswerModel { QuestionCode = question.Code, Answer = decimal.Parse(answer.ToString(), CultureInfo.CurrentCulture) },
                QuestionTypeEnum.Choice => new ChoiceQuestionAnswerModel { QuestionCode = question.Code, Answer = (string)answer },
                _ => throw new ApplicationException($"Unexpected question type {Enum.GetName(typeof(QuestionTypeEnum), question)}")
            };
            return answerModel;
        }

        public async void SendNewOffer(IEnumerable<Tuple<QuestionModel, object>> entryAnswers)
        {
            IsBusy = true;

            var answers = entryAnswers?.Select(MapQuestionsToAnswers).ToList();
            var covers = Covers?.Select(c => c.Code).ToList();
            var offerDto = new CreateOfferRequest
            {
                ProductCode = ProductCode,
                PolicyFrom = ProductFrom,
                PolicyTo = ProductTo,
                SelectedCovers = covers,
                Answers = answers,
            };
            var offer = await _networkManager.GetPolicyPricesAsync(offerDto);
            if (offer != null)
            {
                Offer = offer;
                IsOffering = true;
            }
            IsBusy = false;
        }
    }
}
