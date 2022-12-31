using static System.Console;

namespace Diary.Instruments
{
    public class TextOperations
    {
        public static string TestString(string WritelineIfLessThan, int RequiredLength)
        {
            while (true)
            {
                string? UserInput = ReadLine();
                if (UserInput.Length < RequiredLength)
                {
                    WriteLine(WritelineIfLessThan);
                    WriteLine("Попробуйте ещё раз.");
                    continue;
                }
                return UserInput;
            }
        }
        public static int ConvertToInt()
        {
            while (true) 
            {
                string? Input = ReadLine();
                try
                {
                    Convert.ToInt32(Input);
                }
                catch (FormatException)
                {
                    WriteLine("Ввод должен быть числом");
                    continue;
                }
                return Convert.ToInt32(Input);
            }
        }
        public static void WaitForUser(string Input) 
        {
            WriteLine(Input);
            ReadLine();
            Clear();
        }
    }
}
