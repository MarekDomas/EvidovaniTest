using EvidovaniTest.Classes;

namespace EvidovaniTest.Pages;

public partial class EditTrainingPage : ContentPage
{
    private Training training;
    public static List<Exercise> Exercsises= [];
    private bool isEdit;
    private Exercise exerciseToEdit;
    public EditTrainingPage(Training? training = null)
	{
		InitializeComponent();
        if (training is not null)
        {
            this.training = training;
            Exercsises = training.Exercizes;
            TrainingNameEntry.Text = training.Name;
            TrainingDatePicker.Date = training.Date;
            DescriptionEntry.Text = training.Description;
            isEdit = true;
        }
	}

    protected override void OnAppearing()
    {
        Functions.Refresh(ExercisesLv, Exercsises);
        base.OnAppearing();
    }

    private void CreateBtn_Clicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new EditExercise());
    }

    protected override void OnDisappearing()
    {
        Functions.SaveData(MainPage.Trainings);
        Exercsises = [];
        base.OnDisappearing();
    }

    private void SubmitBtn_OnClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TrainingNameEntry.Text))
        {
            DisplayAlert("Error", "Zadejte název tréninku", "Ok");
            return;
        }

        if (!isEdit)
        {
            Training newTraining = new()
            {
                Name = TrainingNameEntry.Text,
                Date = TrainingDatePicker.Date,
                Description = DescriptionEntry.Text,
                Exercizes = Exercsises
            };
            MainPage.Trainings.Add(newTraining);
        }
        else
        {
            training.Name = TrainingNameEntry.Text;
            training.Date = TrainingDatePicker.Date;
            training.Description = DescriptionEntry.Text;
            training.Exercizes = Exercsises;
        }
        Exercsises = [];
        Navigation.PopAsync();
    }

    private void ExercisesLv_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        var exercise = ExercisesLv.SelectedItem as Exercise;
        if (exercise is null)
        {
            return;
        }
        exerciseToEdit = exercise;
        EditBtn.BackgroundColor = CreateBtn.BackgroundColor;
    }

    private void EditBtn_OnClicked(object? sender, EventArgs e)
    {
        if (exerciseToEdit is null) { EditBtn.BackgroundColor = Colors.DarkRed; return; }
        Navigation.PushAsync(new EditExercise(exerciseToEdit));
    }
}