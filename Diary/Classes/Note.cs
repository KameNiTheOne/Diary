namespace Diary.Classes
{
    public class Note
    {
        private int id;
        private string titlename;
        private string contents;
        private string date;
        public Note(int InputId, string InputTitleName, string InputContents, string InputDate)
        {
            id = InputId; titlename = InputTitleName; contents = InputContents; date = InputDate;
        }
        public void ResetId(int NewId)
        {
            id = NewId;
        }
        public int Id 
        { 
            get { return id; } 
        }
        public string Title
        {
            get { return titlename; }
        }
        public string Contents
        {
            get { return contents; }
        }
        public string Date
        {
            get { return date; } 
        }
    }
}
