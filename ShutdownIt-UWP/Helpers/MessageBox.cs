using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ShutdownIt_UWP.Helpers
{
    public static class MessageBox
    {
        public async static Task<ContentDialogResult> Show(string title, string content, string acceptButton = null, string cancelButton = null)
        {
            ContentDialog dialogBox = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = acceptButton ?? "",
                SecondaryButtonText = cancelButton ?? "Ok",
            };

            return await dialogBox.ShowAsync();
        }
    }
}
