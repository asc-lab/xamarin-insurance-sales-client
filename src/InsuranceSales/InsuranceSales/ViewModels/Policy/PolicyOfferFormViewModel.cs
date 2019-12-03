using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer;
using InsuranceSales.Models.Offer.Dto;
using InsuranceSales.Models.Policy;
using InsuranceSales.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private Guid _productId;
        public Guid ProductId { get => _productId; set => SetProperty(ref _productId, value); }

        private string _productCode;
        public string ProductCode { get => _productCode; set => SetProperty(ref _productCode, value); }

        private DateTime _productFrom;
        public DateTime ProductFrom { get => _productFrom; set => SetProperty(ref _productFrom, value); }

        private DateTime _productTo;
        public DateTime ProductTo { get => _productTo; set => SetProperty(ref _productTo, value); }

        private PolicyModel _policy;
        public PolicyModel Policy { get => _policy; protected set => SetProperty(ref _policy, value); }

        private IList<QuestionAnswer> _questionAnswers;
        public IList<QuestionAnswer> QuestionAnswers { get => _questionAnswers; set => SetProperty(ref _questionAnswers, value); }

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
            var answers = product.Questions.Select(MapQuestionsToAnswers);
            QuestionAnswers = new ObservableCollection<QuestionAnswer>(answers);

            await base.InitializeAsync();
        }

        private static QuestionAnswer MapQuestionsToAnswers(QuestionModel question) => question.Type switch
        {
            QuestionTypeEnum.Text => (QuestionAnswer)new TextQuestionAnswer { QuestionCode = question.Code },
            QuestionTypeEnum.Numeric => new NumericQuestionAnswer { QuestionCode = question.Code },
            QuestionTypeEnum.Choice => new ChoiceQuestionAnswer { QuestionCode = question.Code },
            _ => throw new ApplicationException($"Unexpected question type {Enum.GetName(typeof(QuestionTypeEnum), question)}")
        };

        private void SendNewOffer()
        {
            var newOffer = new CreateOfferDto
            {
                ProductCode = ProductCode,
                PolicyFrom = ProductFrom,
                PolicyTo = ProductTo,
                SelectedCovers = new List<string>(), //! TODO
                Answers = QuestionAnswers,
            };
            //_networkManager.CreateOffer(newOffer);
        }
    }
}
