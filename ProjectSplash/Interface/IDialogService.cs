using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ProjectSplash.Interface
{
    public interface IDialogService
    {
        Task<ContentDialogResult> ShowMessageAsync(string title, string content);
        Task<ContentDialogResult> ShowMessageAsync(string title, string content, string primaryButtonText);
        Task<ContentDialogResult> ShowMessageAsync(string title, string content, string primaryButtonText, string secondaryButtonText);
        Task<ContentDialogResult> ShowMessageAsync(string title, string content, string primaryButtonText, string secondaryButtonText, ContentDialogButton defaultButton);
        Task<ContentDialogResult> ShowMessageAsync(string title, string content, string primaryButtonText, string secondaryButtonText, string closeButtonText, ContentDialogButton defaultButton);
        Task<ContentDialogResult> ShowCustomDialogAsync(ContentDialog dialog);
    }
}
