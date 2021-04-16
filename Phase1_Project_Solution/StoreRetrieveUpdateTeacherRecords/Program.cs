using System;
using System.Collections.Generic;
using System.IO;

namespace StoreRetrieveUpdateTeacherRecords
{
    class Program
    {

        static void Main(string[] args)
        {
            string path;
            string filename;
            string filePath;
            Console.WriteLine("Welcome to Rainbow School.");
            Console.WriteLine("Following are the available options.");
            Console.WriteLine("Enter 1 to Create a new file and store teacher details.");
            Console.WriteLine("Enter 2 to Retrieve the complete teacher details contained in the file.");
            Console.WriteLine("Enter 3 to Update a teacher details.");

            Console.WriteLine("Please enter your option : ");

            int userOption = int.Parse(Console.ReadLine());

            switch (userOption)
            {
                case 1:
                    Console.WriteLine("Enter the path to create school teacher details file: ");
                    path = Console.ReadLine();

                    // check if the folder exists
                    if (!Directory.Exists(path))
                    {
                        Console.WriteLine("Path does not exists. Creating the path/folder....");
                        Directory.CreateDirectory(path);
                        Console.WriteLine("Completed creating path/folder....");
                    }

                    Console.WriteLine("Enter the filename to create school teacher details: ");
                    filename = Console.ReadLine();
                    // Final file path name
                    filePath = @path + "\\" + filename;
                    Console.WriteLine("File location: " + filePath);
                    // check if the file already exists
                    if (File.Exists(filePath))
                    {
                        Console.WriteLine("File already exists. Deleting the existing file....");
                        File.Delete(filePath);
                        Console.WriteLine("Completed deleting the existing file....");

                    }
                    Console.WriteLine();

                    // Write all of the text to the file
                    string text = "Rainbow School Teacher's Details: ";
                    File.WriteAllText(filePath, text);

                    // Id is unique number and increased by 1 for every iteration.
                    int Id = 1;
                    string Name;
                    string Class;
                    string Section;
                    string keyExit = "exit";
                    Console.WriteLine("Please press Enter Key to Proceed");
                    List<string> TeachersList = new List<string>();
                    TeachersList.Add("");
                    TeachersList.Add("ID|Name|Class|Section");
                    while (!Console.ReadLine().Equals(keyExit))
                    {
                        Console.WriteLine("Enter Teacher's Name:");
                        Name = Console.ReadLine();
                        Console.WriteLine("Enter Class:");
                        Class = Console.ReadLine();
                        Console.WriteLine("Enter Section:");
                        Section = Console.ReadLine();

                        TeachersList.Add(Id.ToString()+"|"+Name+"|"+Class+"|"+Section);

                        Console.WriteLine("Please Type \"exit\" to Exit the program OR press Enter Key to continue appending the file:");
                        Id++;
                    }
                    // Add/Append the details at the end of the file
                    File.AppendAllLines(filePath, TeachersList);
                    Console.WriteLine("Retrieving the contents of the file...");
                    // Read all contents of the file
                    Console.WriteLine(File.ReadAllText(filePath));
                    Console.ReadKey();
                    break;


                case 2:
                    filePath = null;
                    bool filePathFound = false;

                    while (!filePathFound)
                    {
                        Console.WriteLine("Enter the path to retrieve school teacher details file: ");
                        path = Console.ReadLine();
                        Console.WriteLine("Enter the filename to retrieve school teacher details: ");
                        filename = Console.ReadLine();
                        // Final file path name
                        filePath = @path + "\\" + filename;
                        Console.WriteLine("FilePath provided is : " + filePath);
                        // check if the folder exists
                        if (!File.Exists(filePath))
                        {
                            Console.WriteLine("Path/filename does not exists. Please provide the correct path/filename.");

                        }
                        else {
                            filePathFound = true;
                        }
                    }

                    Console.WriteLine("Retrieving the contents of the file...");
                    // Read all contents of the file
                    Console.WriteLine(File.ReadAllText(filePath));
                    Console.WriteLine("Press Enter Key to exit.");
                    Console.ReadKey();

                    break;

                case 3:
                    filePath = null;
                    filePathFound = false;
                    path = null;
                    filename = null;

                    while (!filePathFound)
                    {
                        Console.WriteLine("Enter the path to retrieve school teacher details file: ");
                        path = Console.ReadLine();
                        Console.WriteLine("Enter the filename to retrieve school teacher details: ");
                        filename = Console.ReadLine();
                        // Final file path name
                        filePath = @path + "\\" + filename;
                        Console.WriteLine("FilePath provided is : " + filePath);
                        // check if the folder exists
                        if (!File.Exists(filePath))
                        {
                            Console.WriteLine("Path/filename does not exists. Please provide the correct path/filename.");

                        }
                        else
                        {
                            filePathFound = true;
                        }
                    }

                    Console.WriteLine("Retrieving the contents of the file...");
                    // Read all contents of the file
                    Console.WriteLine(File.ReadAllText(filePath));

                    Console.WriteLine("Enter the name of the teacher to be updated: ");
                    string findTeacher = Console.ReadLine();
                    Console.WriteLine("Enter the teacher details to be updated in the format- ID|Name|Class|Section .");
                    string updateTeacher = Console.ReadLine();

                    // create a temp file 
                    string tmpfilePath = @path + "\\" + filename+"tmp";
                    // Read all lines from txt file to string array
                    string[] lines = File.ReadAllLines(filePath);
                    // search the user entered string in the file and if exists , update
                    bool matchFound = false;
                    List<string> UpdatedTeachersList = new List<string>();
                    UpdatedTeachersList.Add("");
                    foreach (string line in lines){
                        if (line.Contains(findTeacher))
                        {
                            Console.WriteLine("Match found for user provided teacher name. Details in original file is :  "+ line);
                            matchFound = true;
                            //File.AppendAllText(tmpfilePath, updateTeacher);
                            UpdatedTeachersList.Add(updateTeacher);
                        }
                        else
                        {
                            Console.WriteLine("Match NOT found for user provided teacher name. Checking for next line in the file.");

                            // File.AppendAllText(tmpfilePath, line);
                            UpdatedTeachersList.Add(line);
                        }
                    }

                    if (matchFound == false)
                    {
                        Console.WriteLine("User provided string did not match any of the string in text file. No changes were made.");

                    }
                    else {
                        File.Delete(filePath);
                        Console.WriteLine("User provided string found match in text file. Updating the file with changes.");
                        // Add/Append the details of the file
                        File.AppendAllLines(tmpfilePath, UpdatedTeachersList);
                        File.Copy(tmpfilePath, filePath);
                        File.Delete(tmpfilePath);

                    }
                    Console.WriteLine("Retrieving the contents of the updated file...");
                    // Read all contents of the file
                    Console.WriteLine(File.ReadAllText(filePath));
                    Console.WriteLine("Press Enter Key to exit.");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("User entered option is not valid. Exiting now.");
                    Console.WriteLine("Press Enter Key to exit.");
                    Console.ReadKey();

                    break;
            }

        }
    }
}
