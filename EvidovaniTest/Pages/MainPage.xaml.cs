using EvidovaniTest.Classes;
using EvidovaniTest.Pages;

namespace EvidovaniTest;

public partial class MainPage : ContentPage
{
    public static List<Training> Trainings = [new(){Name = "Test1",Date = DateTime.Now,Description = "popis"}];
    private Training trainingToEdit;
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    { 
        Trainings = Functions.LoadTasks<Training>();
        Functions.Refresh(TrainingsLv,Trainings);
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        Functions.SaveData(Trainings);
        base.OnDisappearing();
    }

    private void CreateBtn_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new EditTrainingPage());
    }

    private void TrainingsLv_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        var training = TrainingsLv.SelectedItem as Training;
        if (training is null)
        {
            return;
        }
        trainingToEdit = training;
        EditBtn.BackgroundColor = CreateBtn.BackgroundColor;
    }

    private void EditBtn_OnClicked(object? sender, EventArgs e)
    {
        if(trainingToEdit is null){EditBtn.BackgroundColor = Colors.DarkRed; return;}
        Navigation.PushAsync(new EditTrainingPage(trainingToEdit));
    }
}