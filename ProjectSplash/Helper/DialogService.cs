using ProjectSplash.Interface;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls; 

namespace ProjectSplash.Helper
{
    //public class DialogService : IDialogService
    //{
    //    private const string instanceName = "UWP dialog service";

    //    private ContentDialog _contentDialog;
    //    public ContentDialog ShowCustomDialog(ContentDialog dialog)
    //    {
    //        return dialog;
    //    }

    //    public async Task<ContentDialogResult> ShowCustomDialogAsync(ContentDialog dialog)
    //    {
    //        return await dialog.ShowAsync();
    //    }

    //    private void ContentDialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
    //    {
    //        _contentDialog = null;
    //    }

    //    public async Task<ContentDialogResult> ShowMessageAsync(string title, string content)
    //    {
    //        if (_contentDialog != null)
    //            _contentDialog.Hide();

    //        _contentDialog = new MessageDialog(title, content);
    //        _contentDialog.Closed += ContentDialog_Closed;
    //        return await _contentDialog.ShowAsync(ContentDialogPlacement.Popup);
    //    } 

    //    public async Task<ContentDialogResult> ShowMessageAsync(string title, string content, string primaryButtonText)
    //    {
    //        if (_contentDialog != null)
    //            _contentDialog.Hide();

    //        _contentDialog = new MessageDialog(title, content, primaryButtonText);
    //        _contentDialog.Closed += ContentDialog_Closed;
    //        return await _contentDialog.ShowAsync(ContentDialogPlacement.Popup); 
    //    }

    //    public async Task<ContentDialogResult> ShowMessageAsync(string title, string content, string primaryButtonText, string secondaryButtonText)
    //    {
    //        if (_contentDialog != null)
    //            _contentDialog.Hide();

    //        _contentDialog = new MessageDialog(title, content, primaryButtonText, secondaryButtonText);
    //        _contentDialog.Closed += ContentDialog_Closed;
    //        return await _contentDialog.ShowAsync(ContentDialogPlacement.Popup); 
    //    }

    //    public async Task<ContentDialogResult> ShowMessageAsync(string title, string content, string primaryButtonText, string secondaryButtonText, ContentDialogButton defaultButton)
    //    {
    //        if (_contentDialog != null)
    //            _contentDialog.Hide();

    //        _contentDialog = new MessageDialog(title, content, primaryButtonText, secondaryButtonText, defaultButton);
    //        _contentDialog.Closed += ContentDialog_Closed;
    //        return await _contentDialog.ShowAsync(ContentDialogPlacement.Popup);
    //    }

    //    public async Task<ContentDialogResult> ShowMessageAsync(string title, string content, string primaryButtonText, string secondaryButtonText, string closeButtonText, ContentDialogButton defaultButton)
    //    {
    //        if (_contentDialog != null)
    //            _contentDialog.Hide();

    //        _contentDialog = new MessageDialog(title, content, primaryButtonText, secondaryButtonText, closeButtonText, defaultButton);
    //        _contentDialog.Closed += ContentDialog_Closed;
    //        return await _contentDialog.ShowAsync(ContentDialogPlacement.Popup); 
    //    }
    //}
}
