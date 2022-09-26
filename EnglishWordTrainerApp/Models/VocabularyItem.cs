using CommunityToolkit.Mvvm.ComponentModel;

namespace EnglishWordTrainerApp.Models
{
    public partial class VocabularyItem : ObservableObject
    {
        [ObservableProperty]
        private string englishWord = "";

        [ObservableProperty]
        private string translateWord = "";
    }
}
