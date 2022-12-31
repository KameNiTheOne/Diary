using Diary.Classes;
using Diary.Instruments;
using static System.Console;

namespace Diary
{
    public class Menu
    {
        public static void AddNote()
        {
            Repository.NoteCounter++;
            WriteLine($"Заметка номер {Repository.NoteCounter}\n");
            WriteLine("Напиши название заметки");
            string TitleName = TextOperations.TestString("Слишком короткое название!", 3);
            WriteLine("Напиши содержимое заметки");
            string Contents = TextOperations.TestString("Слишком короткое содержимое!", 5);
            NoteManager.New(Repository.NoteCounter, TitleName, Contents, Convert.ToString(DateTime.Now));
            Clear();
            TextOperations.WaitForUser("Заметка успешно добавлена!");
        }
        public static void CheckForNote()
        {
            if (Repository.Notes is null)
            {
                TextOperations.WaitForUser("Вы ещё не создали ни одну заметку!\nСделайте это через меню 'Добавить новую заметку'.");
            }
            else 
            {
                while (true)
                {
                    WriteLine($"Выберите заметку, всего заметок: {Repository.NoteCounter}.");
                    foreach (Note note in Repository.Notes)
                    {
                        WriteLine($"{note.Id} - {note.Title}");
                    }
                    int Input = TextOperations.ConvertToInt();
                    bool Checker = false;
                    int StoredId = 0;
                    foreach (Note note in Repository.Notes)
                    {
                        if (Input == note.Id)
                        {
                            Checker = true;
                            StoredId = Input - 1;
                            break;
                        }
                    }
                    if (Checker)
                    {
                        Clear();
                        TextOperations.WaitForUser($"Заметка номер {Repository.Notes[StoredId].Id}\n" +
                                                   $"Дата создания: {Repository.Notes[StoredId].Date}\n\n" +
                                                   $"Название: {Repository.Notes[StoredId].Title}\n\n" +
                                                   $"{Repository.Notes[StoredId].Contents}");
                        break;
                    }
                    Clear();
                    TextOperations.WaitForUser("Такой заметки нет");
                }
            }
        }
        public static void DeleteAll()
        {
            if (Repository.Notes is null)
            {
                TextOperations.WaitForUser("Вы ещё не создали ни одну заметку!\nСделайте это через меню 'Добавить новую заметку'.");
            }
            else
            {
                NoteManager.DeleteAll();
                TextOperations.WaitForUser("Заметки очищены!");
            }
        }
        public static void ShowAll()
        {
            if (Repository.Notes is null)
            {
                TextOperations.WaitForUser("Вы ещё не создали ни одну заметку!\nСделайте это через меню 'Добавить новую заметку'.");
            }
            else
            {
                NoteManager.ShowAll();
                ReadLine();
                Clear();
            }
        }
        public static void Edit()
        {
            if (Repository.Notes is null)
            {
                TextOperations.WaitForUser("Вы ещё не создали ни одну заметку!\nСделайте это через меню 'Добавить новую заметку'.");
            }
            else
            {
                while (true)
                {
                    WriteLine($"Выберите заметку, всего заметок: {Repository.NoteCounter}.");
                    foreach (Note note in Repository.Notes)
                    {
                        WriteLine($"{note.Id} - {note.Title}");
                    }
                    int Input = TextOperations.ConvertToInt();
                    bool Checker = false;
                    int StoredId = 0;
                    foreach (Note note in Repository.Notes)
                    {
                        if (Input == note.Id)
                        {
                            Checker = true;
                            StoredId = Input - 1;
                            break;
                        }
                    }
                    if (Checker)
                    {
                        Clear();
                        WriteLine($"Заметка номер {Repository.Notes[StoredId].Id}\n" +
                                                   $"Дата создания: {Repository.Notes[StoredId].Date}\n\n" +
                                                   $"Название: {Repository.Notes[StoredId].Title}\n\n" +
                                                   $"{Repository.Notes[StoredId].Contents}");
                        bool Start = true;
                        while (Start)
                        {
                            WriteLine("\nЧто вы хотите изменить?\n\n1 - Название.\n2 - Содержимое.");
                            switch (ReadLine())
                            {
                                case "1":
                                    {
                                        string FormalTitle = Repository.Notes[StoredId].Title;
                                        Clear();
                                        WriteLine($"Старое название:\n{FormalTitle}\n");
                                        WriteLine("Напиши новое название.");
                                        NoteManager.EditTitle(TextOperations.TestString("Слишком короткое название!", 3), StoredId);
                                        Clear();
                                        TextOperations.WaitForUser($"Название изменено с {FormalTitle} на {Repository.Notes[StoredId].Title}!");
                                        Start = false;
                                    }
                                    break;
                                case "2":
                                    {
                                        string FormalContents = Repository.Notes[StoredId].Contents;
                                        Clear();
                                        WriteLine($"Старое содержимое:\n{FormalContents}\n");
                                        WriteLine("Напиши новое содержимое.");
                                        NoteManager.EditContents(TextOperations.TestString("Слишком короткое содержимое!", 5), StoredId);
                                        Clear();
                                        TextOperations.WaitForUser($"Содержимое изменено!");
                                        Start = false;
                                    }
                                    break;
                                default:
                                    {
                                        Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                    Clear();
                    TextOperations.WaitForUser("Такой заметки нет");
                }
            }
        }
        public static void Delete()
        {
            if (Repository.Notes is null)
            {
                TextOperations.WaitForUser("Вы ещё не создали ни одну заметку!\nСделайте это через меню 'Добавить новую заметку'.");
            }
            else
            {
                while (true)
                {
                    WriteLine($"Выберите заметку, всего заметок: {Repository.NoteCounter}.");
                    foreach (Note note in Repository.Notes)
                    {
                        WriteLine($"{note.Id} - {note.Title}");
                    }
                    int Input = TextOperations.ConvertToInt();
                    bool Checker = false;
                    int StoredId = 0;
                    foreach (Note note in Repository.Notes)
                    {
                        if (Input == note.Id)
                        {
                            Checker = true;
                            StoredId = Input - 1;
                            break;
                        }
                    }
                    if (Checker)
                    {
                        NoteManager.Delete(StoredId);
                        Clear();
                        TextOperations.WaitForUser($"Записка номер {StoredId + 1} удалена!");
                        break;
                    }
                    Clear();
                    TextOperations.WaitForUser("Такой заметки нет");
                }
            }
        }
    }
}
