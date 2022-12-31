using Diary.Classes;
using static System.Console;

namespace Diary
{
    public class NoteManager
    {
        public static void New(int InputId, string InputTitleName, string InputContents, string InputDate)
        {
            Array.Resize(ref Repository.Notes, Repository.NoteCounter);
            Repository.Notes[Repository.Notes.Length - 1] = new Note(InputId, InputTitleName, InputContents, InputDate);
        }
        public static void EditTitle(string NewTitle, int EditedNotePosition)
        {
            Note TempNote = Repository.Notes[EditedNotePosition];
            Repository.Notes[EditedNotePosition] = new Note(EditedNotePosition + 1, NewTitle, TempNote.Contents, TempNote.Date);
        }
        public static void EditContents(string NewContents, int EditedNotePosition)
        {
            Note TempNote = Repository.Notes[EditedNotePosition];
            Repository.Notes[EditedNotePosition] = new Note(EditedNotePosition + 1, TempNote.Title, NewContents, TempNote.Date);
        }
        public static void ShowAll()
        {
            foreach(Note note in Repository.Notes)
            {
                WriteLine($"Заметка номер {note.Id}\n" +
                          $"Дата создания: {note.Date}\n\n" +
                          $"Название: {note.Title}\n\n" +
                          $"{note.Contents}\n");
            }
        }
        public static void Delete(int NoteId)
        {
            Note[] TempArray = new Note[Repository.Notes.Length - 1];
            Repository.NoteCounter = 0;
            Array.Clear(Repository.Notes, NoteId, 1);
            foreach(Note note in Repository.Notes)
            {
                if(note is null) 
                {
                    continue;
                }
                WriteLine(Repository.NoteCounter++);
                ReadLine();
                note.ResetId(Repository.NoteCounter);
                TempArray[Repository.NoteCounter - 1] = note;
            }
            if(TempArray.Length == 0) 
            {
                Repository.NoteCounter = 0;
                TempArray = null;
            }
            Repository.Notes = TempArray;
        }
        public static void DeleteAll()
        {
            Repository.Notes = null;
            Repository.NoteCounter = 0;
        }
    }
}
