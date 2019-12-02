using InsuranceSales.Interfaces;
using InsuranceSales.Models.Policy;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Policy
{
    //! TODO: Look up how to create a policy offer
    //! TODO: Obtain data from DynamicEntriesView
    //! TODO: Create entries for client name/surname/tax ID
    public class PolicyOfferFormViewModel : ViewModelBase
    {
        #region SERVICES
        #endregion

        #region PROPS
        #endregion

        #region PROPS

        public ObservableCollection<QuestionAnswer> QuestionAnswers { get; set; } = new ObservableCollection<QuestionAnswer>();

        public AddressModel Address { get; set; }

        public PersonModel Person { get; set; }
        #endregion

        public PolicyOfferFormViewModel()
            : base(DependencyService.Resolve<IAuthenticationService>())
        { }

        public override Task InitializeAsync()
        {


            return base.InitializeAsync();
        }
    }
}
