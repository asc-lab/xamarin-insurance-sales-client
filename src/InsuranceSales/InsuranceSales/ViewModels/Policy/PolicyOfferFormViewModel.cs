using InsuranceSales.Controls;
using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer;
using InsuranceSales.Models.Offer.Dto;
using InsuranceSales.Models.Policy;
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

        private AddressModel _address;
        public AddressModel Address { get => _address; set => SetProperty(ref _address, value); }

        private PersonModel _person;
        public PersonModel Person { get => _person; set => SetProperty(ref _person, value); }

        private DynamicEntriesViewModel _dynamicEntriesViewModel;
        public DynamicEntriesViewModel DynamicEntriesViewModel { get => _dynamicEntriesViewModel; set => SetProperty(ref _dynamicEntriesViewModel, value); }

        private DynamicEntriesView _dynamicEntriesView;
        public DynamicEntriesView DynamicEntriesView { get => _dynamicEntriesView; set => SetProperty(ref _dynamicEntriesView, value); }
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
            DynamicEntriesViewModel = new DynamicEntriesViewModel { Questions = Questions };

            await base.InitializeAsync();
        }

        private static QuestionAnswerModel MapQuestionsToAnswers(Tuple<QuestionModel, object> tuple)
        {
            var (question, answer) = tuple;
            var answerModel = question.Type switch
            {
                QuestionTypeEnum.Text => (QuestionAnswerModel)new TextQuestionAnswerModel { QuestionCode = question.Code, Answer = (string)answer },
                QuestionTypeEnum.Numeric => new NumericQuestionAnswerModel { QuestionCode = question.Code, Answer = decimal.Parse(answer.ToString(), CultureInfo.CurrentCulture) },
                QuestionTypeEnum.Choice => new ChoiceQuestionAnswerModel { QuestionCode = question.Code, Answer = (string)answer },
                _ => throw new ApplicationException($"Unexpected question type {Enum.GetName(typeof(QuestionTypeEnum), question)}")
            };
            return answerModel;
        }

        private void SendNewOffer()
        {
            IsBusy = true;
            // TODO: Obtain reference to DynamicEntriesView somehow
            var entryAnswers = DynamicEntriesView?.GetAnswers();
            var answers = entryAnswers?.Select(MapQuestionsToAnswers);
            var newOffer = new CreateOfferDto
            {
                ProductCode = ProductCode,
                PolicyFrom = ProductFrom,
                PolicyTo = ProductTo,
                SelectedCovers = new List<string>(), //! TODO
                Answers = answers?.ToList(),
            };
            _networkManager.SendOffer(newOffer);

            IsBusy = false;
        }
    }
}
