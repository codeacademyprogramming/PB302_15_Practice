using System;

namespace StudentManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Abbas", "Tofiq", "Nermin" , };
            byte[] ages = { 16, 20, 54 };

            string opt;
            do
            {
                Console.WriteLine("1. Butun telebelere bax");
                Console.WriteLine("2. Telebe elave et");
                Console.WriteLine("3. Teleber uzerinde axtaris et");
                Console.WriteLine("4. Secilmis nomreli telebeni goster");
                Console.WriteLine("5. Secilmis nomreli telebeni sil");
                Console.WriteLine("0. Cix");

                Console.WriteLine("\nEmeliyyat secin:");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        for (int i = 0; i < names.Length; i++)
                            Console.WriteLine(names[i]);
                        break;
                    case "2":

                        string name;
                        bool hasOnlyLetter = true;

                        do
                        {
                            Console.WriteLine("Telebe adini daxil edin:");
                            name = Console.ReadLine();

                        } while (!CheckName(name));
                      
                        //string[] newNames = new string[names.Length + 1];
                        //for (int i = 0; i < names.Length; i++)
                        //{
                        //    newNames[i] = names[i];
                        //}
                        //names= newNames;

                        Array.Resize(ref names,names.Length+1);
                        names[names.Length - 1] = name;

                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }

            } while (opt != "0");
        }

        static bool HasOnlyLetter(string str)
        {
            if (String.IsNullOrWhiteSpace(str)) return false;

            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i])) return false;
            }

            return true;
        }

        static bool CheckName(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return false;

            if(name.Length>=3 && name.Length<=20 && HasOnlyLetter(name)) return true;
            return false;
        }
    }
}
