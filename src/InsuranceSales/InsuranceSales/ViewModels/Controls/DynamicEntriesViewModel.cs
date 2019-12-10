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

        private bool _isEditable = true;
        public bool IsEditable { get => _isEditable; set => SetProperty(ref _isEditable, value); }
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
