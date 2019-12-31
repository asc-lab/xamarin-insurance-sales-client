using System.Threading.Tasks;

namespace InsuranceSales.Interfaces
{
    public interface IDialogService
    {
        Task DisplayInfoAlertAsync(string message);

        Task DisplayErrorAlertAsync(string message);

        Task DisplayCustomAlertAsync(string title, string message);
        Task DisplayCustomAlertAsync(string title, string message, string confirm);

        Task<bool> DisplayConfirmationAlertAsync(string title, string message);
        Task<bool> DisplayConfirmationAlertAsync(string title, string message, string accept, string cancel);
    }
}
