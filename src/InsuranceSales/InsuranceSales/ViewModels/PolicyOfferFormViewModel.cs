using InsuranceSales.Interfaces;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Product;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels
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
        public ObservableCollection<KeyValuePair<QuestionModel, ChoiceModel>> PolicyChoices { get; } = new ObservableCollection<KeyValuePair<QuestionModel, ChoiceModel>>();
        #endregion

        public PolicyOfferFormViewModel()
            : base(DependencyService.Resolve<IAuthenticationService>())
        { }
    }
}
