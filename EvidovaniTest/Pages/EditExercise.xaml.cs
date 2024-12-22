using EvidovaniTest.Classes;

namespace EvidovaniTest.Pages;

public partial class EditExercise : ContentPage
{
    private Exercise exercise;
    private string[] exerciseTypes =
    [
        "Kliky",
        "Døepy",
        "Výpady",
        "Prkno",
        "Sedy-lehy",
        "Panáky",
        "Shyby",
        "Anglièáky",
        "Horolezci",
        "Mrtvý tah"
    ];
    private bool isEdit;

    public EditExercise(Exercise? exercise = null)
	{
		InitializeComponent();
        TypePicker.ItemsSource = exerciseTypes;
        if (exercise is not null)
        {
            this.exercise = exercise;
            TypePicker.SelectedItem = exercise.Name;
            SeriesEntry.Text = exercise.Sets.ToString();
            RepsEntry.Text = exercise.Reps.ToString();
            isEdit = true;
        }
    }

    private void AddExerciseBtn_OnClicked(object? sender, EventArgs e)
    {
        if (TypePicker.SelectedItem is null || string.IsNullOrWhiteSpace(SeriesEntry.Text) || string.IsNullOrWhiteSpace(RepsEntry.Text))
        {
            DisplayAlert("Error", "Enter valid data","Ok");
            return;
        }

        if (!isEdit)
        {
            Exercise newExercise = new()
            {
                Name = TypePicker.SelectedItem.ToString(),
                Reps = int.Parse(RepsEntry.Text),
                Sets = int.Parse(SeriesEntry.Text)
            };
            if (EditTrainingPage.Exercsises is null)
            {
                EditTrainingPage.Exercsises = [];
            }
            EditTrainingPage.Exercsises.Add(newExercise);
        }
        else
        {
            exercise.Name = TypePicker.SelectedItem.ToString();
            exercise.Reps = int.Parse(RepsEntry.Text);
            exercise.Sets = int.Parse(SeriesEntry.Text);
        }
        Navigation.PopAsync();
    }
}