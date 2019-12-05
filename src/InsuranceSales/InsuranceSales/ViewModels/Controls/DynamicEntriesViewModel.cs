using InsuranceSales.Interfaces;
using InsuranceSales.Models.Policy;
using System.Collections.Generic;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Controls
{
    public class DynamicEntriesViewModel : ViewModelBase
    {
        #region PROPS
        private IEnumerable<QuestionModel> _questions;
        public IEnumerable<QuestionModel> Questions { get => _questions; set => SetProperty(ref _questions, value); }
        #endregion

        public DynamicEntriesViewModel(
            IAuthenticationService authenticationService
        ) : base(authenticationService)
        { }

        public DynamicEntriesViewModel() : this(
            DependencyService.Resolve<IAuthenticationService>()
        )
        { }
    }
}
