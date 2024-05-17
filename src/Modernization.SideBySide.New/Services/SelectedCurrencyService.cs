namespace Modernization.SideBySide.New.Services;

public class SelectedCurrencyService
{

    public string SelectedCurrency { get; private set; } = "USD";

    public event Action? SelectedCurrencyChanged;

    public void SetCurrency(string currency)
    {
        SelectedCurrency = currency;
        SelectedCurrencyChanged?.Invoke();
    }

}