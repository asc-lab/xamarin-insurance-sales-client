using System.Threading.Tasks;
using MvvmHelpers;

namespace InsuranceSales.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        public virtual Task InitializeAsync()
        {
            return Task.FromResult(true);
        }
    }
}
