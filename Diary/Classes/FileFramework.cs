using System.Text;

namespace Diary.Classes

{
    public class FileFramework
    {
        string filename;
        public void Save()
        {
            File.Delete(filename);
            using (var stream = File.Open(filename, FileMode.Create))
            {
                using (var Writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    if (Repository.Notes != null)
                    {
                        foreach (Note note in Repository.Notes)
                        {
                            Writer.WriteLine($"{note.Date}\t{note.Title}\t{note.Contents}");
                        }
                    }
                }
            }
        }
        public void Restore() 
        {
            CreateFolder();
            using (var stream = File.Open(filename, FileMode.OpenOrCreate))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] tempstr = reader.ReadLine().Split(new char[] {'\t'});
                        Repository.NoteCounter++;
                        NoteManager.New(Repository.NoteCounter, tempstr[1], tempstr[2], tempstr[0]);
                    }
                }
            }
        }
        void CreateFolder()
        {
            string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(baseFolder, @"Diary(C#)\");
            Directory.CreateDirectory(folderPath);
            filename = folderPath + "notes.dat";
        }
    }
}
