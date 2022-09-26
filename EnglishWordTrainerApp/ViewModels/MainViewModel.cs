using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EnglishWordTrainerApp.Models;
using EnglishWordTrainerApp.Services;
using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace EnglishWordTrainerApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        public BindingList<VocabularyItem> Vocabulary { get; }

        [ObservableProperty]
        private int count;

        [ObservableProperty]
        private VocabularyItem? vocabularyItem;

        [ObservableProperty]
        private int correctAnswer;

        [ObservableProperty]
        private int incorrectAnswer;

        [RelayCommand]
        void UpCount()
        {
            if (isStart) return;
            Count++;
        }

        [RelayCommand]
        void DownCount()
        {
            if (isStart) return;
            if (Count > 0)
                Count--;
        }
        [RelayCommand]
        void Start()
        {
            if (Count == 0) return;
            if (isStart) return;
            VocabularyItem = Vocabulary[new Random(DateTime.Now.Millisecond).Next(0, Vocabulary.Count)];
            isStart = true;
            CorrectAnswer = IncorrectAnswer = 0;
        }

        [RelayCommand]
        void End(TextBox textBox)
        {
            if (!isStart) return;
            EndAnswer();
            textBox.Clear();
        }

        [RelayCommand]
        void Ok(TextBox textBox)
        {
            if (!isStart) return;
            CheckAnswer(textBox);
            VocabularyItem = Vocabulary[new Random(DateTime.Now.Millisecond).Next(0, Vocabulary.Count)];
            counter++;
            if (Count == counter)
            {
                EndAnswer();
            }
            textBox.Clear();
        }

        public MainViewModel()
        {
            Vocabulary = VocabularyDataSaver.Load(path);
            Vocabulary.ListChanged += Vocabulary_ListChanged;
        }
    }
}
