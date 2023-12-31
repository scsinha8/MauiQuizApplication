using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class QuizPage : ContentPage
{
	public QuizPage()
	{
		InitializeComponent();
		BindingContext = new QuizVM();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await (BindingContext as QuizVM).ClearData();
    }
}