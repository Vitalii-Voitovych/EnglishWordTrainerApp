using EnglishWordTrainerApp.Models;
using System.ComponentModel;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace EnglishWordTrainerApp.Services
{
    public class VocabularyDataSaver
    {
        public static BindingList<VocabularyItem> Load(string fileName)
        {
            if (File.Exists(fileName))
            {
                var fileText = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<BindingList<VocabularyItem>>(fileText)!;
            }
            else
            {
                File.Create(fileName).Dispose();
                return new BindingList<VocabularyItem>();
            }
        }

        public static void Save(BindingList<VocabularyItem> vocabulary, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            File.WriteAllText(fileName, JsonSerializer.Serialize(vocabulary, options));
        }
    }
}
