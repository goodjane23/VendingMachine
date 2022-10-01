using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VendingMachine.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private string displayText = string.Empty;
    public string DisplayText
    {
        get => displayText;
        set => SetProperty(ref displayText, value);
    }

    public MainWindowViewModel()
    {
        UpdateTextAfterDelay();
    }
    
    private void UpdateTextAfterDelay()
    {
        Task.Run(async () =>
        {
            await Task.Delay(2500);
        }).ContinueWith(_ => DisplayText = "12345");
    } 
}
