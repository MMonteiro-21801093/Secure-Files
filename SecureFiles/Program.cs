using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureFiles
{
    class Program
    {
        static void Main(string[] args)
        {
 
            startMenu();
            string input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "0":
                        startMenu();
                        input = Console.ReadLine();
                        break;
                    case "1":
                        encryptFileOption();
                        Console.WriteLine("Option");
                        input = Console.ReadLine();
                        break;
                    case "2":
                        optionEncryptDirectory();
                        Console.WriteLine("Option");
                        input = Console.ReadLine();                 
                        break;
                    case "3":
                        decryptFileOption();
                        Console.WriteLine("Option");
                        input = Console.ReadLine();
                        break;
                    case "4":
                        optionDecryptDirectory();
                        Console.WriteLine("Option");
                        input = Console.ReadLine();
                        break;
                }
            } while (input != "99");
        }
        private static void startMenu()
        {
            Console.WriteLine("Select option");
            Console.WriteLine("0.Start Menu");
            Console.WriteLine("1.Encrypt file");
            Console.WriteLine("2.Encrypt all files in a directory");
            Console.WriteLine("3.Decrypt file");
            Console.WriteLine("4.Decrypt all files in a directory");
            Console.WriteLine("99.Close");
        }

        private static void optionDecryptDirectory()
        {
            Console.WriteLine("Enter the directory to decrypt");
            string dir = Console.ReadLine();
            string[] files = Directory.GetFiles(@dir, "*", SearchOption.AllDirectories);
            if (dir != "")
            {
                Encryption obj = new Encryption();
                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine("A Encriptar => " + files[i]);
                    string output = files[i].Replace("_", "");
                    obj.DecryptFile(files[i], output);
                }
                Console.WriteLine("The decryption process has ended");
            }


        }


        private static void optionEncryptDirectory()
        {
            Console.WriteLine("Enter the directory to encrypt");
            string dir = Console.ReadLine();
            string[] files = Directory.GetFiles(@dir, "*", SearchOption.AllDirectories);
            if (dir != "")
            {
                Encryption obj = new Encryption();
                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine("Encrypt file => "+files[i]);
                    string output = treatsFileOutput(files[i]);
                    obj.EncryptFile(files[i], output);
                }
                Console.WriteLine("The encryption process has ended");
            }
        }

        private static void encryptFileOption()
        {
            Console.WriteLine("Insert the file to be encrypted");
            string filePath = Console.ReadLine();
            if (filePath != "")
            { 
                string output = treatsFileOutput(filePath);
                Encryption obj = new Encryption();
                obj.EncryptFile(filePath, output);
                Console.WriteLine("The encryption process has ended");
            }
        }

        private static string treatsFileOutput(string filePath)
        {
            string output = "";
            string[] wfield = filePath.Split('\\');
            for (int i = 0; i < wfield.Length; i++)
            {
                output += (i < wfield.Length - 1) ? wfield[i] + "\\" : "_" + wfield[i];
            }
            return output;
        }

        private static void decryptFileOption()
        {
            Console.WriteLine("Insert the file to be decrypted");
            string filePath = Console.ReadLine();
            if (filePath != "")
            {
                string output = filePath.Replace("_", "");
                Encryption obj = new Encryption();
                obj.DecryptFile(filePath, output);
                Console.WriteLine("The decryption process has ended");
            }

        }

        }
    }
 
