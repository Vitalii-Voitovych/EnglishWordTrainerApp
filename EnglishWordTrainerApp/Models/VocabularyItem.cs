namespace EnglishWordTrainerApp.Models
{
    public class VocabularyItem : ObservableObject
    {
        private string englishWord = "";
        public string EnglishWord
        {
            get => englishWord;
            set
            {
                englishWord = value;
                OnPropertyChanged();
            }
        }

        private string translateWord = "";
        public string TranstaleWord
        {
            get => translateWord;
            set
            {
                translateWord = value;
                OnPropertyChanged();
            }
        }
    }
}
