using Diary;
using Diary.Classes;
using static System.Console;

namespace ProgramMain;

public class Program
{
    static void Main()
    {
        bool End = true;
        FileFramework FileFRM = new FileFramework();
        FileFRM.Restore();
        while (End) 
        {
            WriteLine("Добро пожаловать в Ежедневник!");
            WriteLine("Выберите, что вы хотите сделать:");
            WriteLine("\n1 - Добавить новую заметку.\n2 - Показать заметку.\n3 - Удалить заметку.\n4 - Редактировать заметку.\n5 - Удалить все заметки.\n6 - Показать все заметки.\n\nЧтобы выйти, напиши 'Выйти'");
            string ?UserInput = ReadLine();
            switch(UserInput) 
            {
                case "1":
                    {
                        Clear();
                        Menu.AddNote();
                    }
                    break;
                case "2":
                    {
                        Clear();
                        Menu.CheckForNote();
                    }
                    break;
                case "3":
                    {
                        Clear();
                        Menu.Delete();
                    }
                    break;
                case "4":
                    {
                        Clear();
                        Menu.Edit();
                    }
                    break;
                case "5":
                    {
                        Clear();
                        Menu.DeleteAll();
                    }
                    break;
                case "6":
                    {
                        Clear();
                        Menu.ShowAll();
                    }
                    break;
                case "Выйти" or "выйти":
                    {
                        Clear();
                        WriteLine("Выхожу!");
                        FileFRM.Save();
                        End = false;
                    }
                    break;
                default:
                    WriteLine("Такого номера нет.");
                    Clear();
                    break;
            }
        }
    }
}