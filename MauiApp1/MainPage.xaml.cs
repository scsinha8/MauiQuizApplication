using MauiApp1.ViewModels;
using MauiApp1.Views;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        BindingContext = new QuizVM();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        //count++;

        //if (count == 1)
        //	CounterBtn.Text = $"Clicked {count} time";
        //else
        //	CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);

        Shell.Current.GoToAsync("//Quiz");

        //await Navigation.PushAsync(new QuizPage());
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if(e.Value)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}

