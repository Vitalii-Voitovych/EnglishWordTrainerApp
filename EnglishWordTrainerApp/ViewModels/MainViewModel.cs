using EnglishWordTrainerApp.Commands;
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

        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }

        public VocabularyItem? VocabularyItem
        {
            get => vocabularyItem;
            set
            {
                vocabularyItem = value;
                OnPropertyChanged();
            }
        }
        public int CorrectAnswer
        {
            get => correctAnswer;
            set
            {
                correctAnswer = value;
                OnPropertyChanged();
            }
        }

        public int IncorrectAnswer
        {
            get => incorrectAnswer;
            set
            {
                incorrectAnswer = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand UpCountCommand { get; }
        public RelayCommand DownCountCommand { get; }
        public RelayCommand StartCommand { get; }
        public RelayCommand<TextBox> EndCommand { get; }
        public RelayCommand<TextBox> OkCommand { get; }


        public MainViewModel()
        {
            Vocabulary = VocabularyDataSaver.Load(path);
            Vocabulary.ListChanged += Vocabulary_ListChanged;

            UpCountCommand = new RelayCommand(() => Count++, () => !isStart);
            DownCountCommand = new RelayCommand(() =>
            {
                if (Count > 0)
                    Count--;
            }, () => !isStart);

            StartCommand = new RelayCommand(() =>
            {
                if (Count == 0) return;
                VocabularyItem = Vocabulary[new Random(DateTime.Now.Millisecond).Next(0, Vocabulary.Count)];
                isStart = true;
                CorrectAnswer = IncorrectAnswer = 0;
            }, () => !isStart);
            EndCommand = new RelayCommand<TextBox>(textBox =>
            {
                End();
                textBox.Clear();
            }, (textBox) => isStart);

            OkCommand = new RelayCommand<TextBox>(textBox =>
            {
                CheckAnswer(textBox);
                VocabularyItem = Vocabulary[new Random(DateTime.Now.Millisecond).Next(0, Vocabulary.Count)];
                counter++;
                if (Count == counter)
                {
                    End();
                }
                textBox.Clear();
            }, (textBox) => isStart);

        }
    }
}
