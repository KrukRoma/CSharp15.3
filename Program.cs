namespace CSharp15._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = null;

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Enter array elements");
                Console.WriteLine("2. Load array from file");
                Console.WriteLine("3. Save array to file");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        array = EnterArray();
                        break;

                    case "2":
                        array = LoadArrayFromFile();
                        break;

                    case "3":
                        if (array != null)
                        {
                            SaveArrayToFile(array);
                        }
                        else
                        {
                            Console.WriteLine("No array to save. Please enter or load an array first.");
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static string[] EnterArray()
        {
            Console.WriteLine("Enter the number of elements in the array:");
            int arraySize = int.Parse(Console.ReadLine());

            string[] array = new string[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"Enter element {i + 1}:");
                array[i] = Console.ReadLine();
            }

            return array;
        }

        static void SaveArrayToFile(string[] array)
        {
            Console.WriteLine("Enter the file path to save the array:");
            string filePath = Console.ReadLine();

            try
            {
                File.WriteAllLines(filePath, array);
                Console.WriteLine("Array successfully saved to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
            }
        }

        static string[] LoadArrayFromFile()
        {
            Console.WriteLine("Enter the file path to load the array from:");
            string filePath = Console.ReadLine();

            try
            {
                if (File.Exists(filePath))
                {
                    string[] array = File.ReadAllLines(filePath);
                    Console.WriteLine("Array successfully loaded from the file.");
                    return array;
                }
                else
                {
                    Console.WriteLine("The file does not exist.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
                return null;
            }
        }
    }
}
