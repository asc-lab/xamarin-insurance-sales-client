using InsuranceSales.Interfaces;
using InsuranceSales.Models.Offer;
using InsuranceSales.Models.Policy;
using InsuranceSales.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuranceSales.ViewModels.Controls
{
    public class DynamicEntryViewModel : ViewModelBase
    {
        #region PROPS
        private QuestionModel _question;
        public QuestionModel Question { get => _question; set => SetProperty(ref _question, value); }

        private string _code = string.Empty;
        public string Code { get => _code; set => SetProperty(ref _code, value); }

        private QuestionTypeEnum _type;
        public QuestionTypeEnum Type { get => _type; set => SetProperty(ref _type, value); }

        private IList<ChoiceModel> _choices;
        public IList<ChoiceModel> Choices { get => _choices; set => SetProperty(ref _choices, value); }

        private ChoiceModel _selectedChoice;
        public ChoiceModel SelectedChoice { get => _selectedChoice; set => SetProperty(ref _selectedChoice, value); }

        private string _placeholder = string.Empty;
        public string Placeholder { get => _placeholder; set => SetProperty(ref _placeholder, value); }

        private string _selectedText = string.Empty;
        public string SelectedText { get => _selectedText; set => SetProperty(ref _selectedText, value); }

        private ulong _selectedValue;
        public ulong SelectedValue { get => _selectedValue; set => SetProperty(ref _selectedValue, value); }
        #endregion

        public DynamicEntryViewModel(
            IAuthenticationService authenticationService
        ) : base(authenticationService)
        { }

        public DynamicEntryViewModel() : this(
            DependencyService.Resolve<IAuthenticationService>()
        )
        { }

        public override Task InitializeAsync()
        {
            Code = Question.Code;
            Type = Question.Type;
            Choices = Question.Choices;
            Placeholder = Question.Text;

            return base.InitializeAsync();
        }
    }
}
