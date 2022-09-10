using System.Windows.Controls;
using System.Windows;
using System;
using EnglishWordTrainerApp.Services;
using System.ComponentModel;
using EnglishWordTrainerApp.Models;

namespace EnglishWordTrainerApp.ViewModels
{
    public partial class MainViewModel
    {
        private readonly string path = $@"C:\Users\{Environment.UserName}\Documents\{Environment.UserName}-Vocabulary.json";
        private bool isStart = false;
        private int counter;

        private int count;
        private VocabularyItem? vocabularyItem;
        private int correctAnswer;
        private int incorrectAnswer;
        
        private void CheckAnswer(TextBox textBox)
        {
            if (string.Equals(VocabularyItem?.TranstaleWord, textBox.Text, StringComparison.OrdinalIgnoreCase))
            {
                CorrectAnswer++;
            }
            else
            {
                IncorrectAnswer++;
            }
        }

        private void End()
        {
            isStart = false;
            Count = counter = 0;
            VocabularyItem = null;
            MessageBox.Show("Ви завершили");
        }

        private void Vocabulary_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                VocabularyDataSaver.Save(Vocabulary, path);
            }
        }
    }
}
