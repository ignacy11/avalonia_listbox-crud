using System.Threading.Tasks;

namespace ListBoxCrudJsonMamy.Services;

public interface IDialogService
{
    Task<bool> ShowConfirmationDialogAsync(string message);
}