using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace StudentManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime startedAt = DateTime.Now;

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
                            Console.WriteLine(names[i] + "-" + ages[i]);
                        break;
                    case "2":
                        AddStudent(ref names,ref ages);
                        break;
                    case "3":
                        Console.WriteLine("Axtaris deyerini daxil edin:");
                        string search = Console.ReadLine();

                        for (int i = 0; i < names.Length; i++)
                        {
                            if (names[i].Contains(search))
                                Console.WriteLine(names[i] + "-" + ages[i]);
                        }
                        break;
                    case "4":
                        for (int i = 0; i < names.Length; i++)
                        {
                            Console.WriteLine($"{i}-{names[i]}-{ages[i]}");
                        }
                        string indexStr;
                        int index;
                        do
                        {
                            Console.Write("Index: ");
                            indexStr = Console.ReadLine();
                        }
                        while (!int.TryParse(indexStr, out index) || index<0 || index>=names.Length);
                        Console.WriteLine($"secilen telebe: {names[index]}");
                        break;
                    case "5":
                        for (int i = 0; i < names.Length; i++)
                        {
                            Console.WriteLine($"{i}-{names[i]}");
                        }
                        do
                        {
                            Console.Write("Index: ");
                            indexStr = Console.ReadLine();
                        }
                        while (!int.TryParse(indexStr, out index) || index < 0 || index >= names.Length);
                        RemoveElementByIndex(ref names, index);
                        RemoveElementByIndex(ref ages, index);
                        break;
                    default:
                        break;
                }

            } while (opt != "0");

            var diff = DateTime.Now - startedAt;

            Console.WriteLine($"Total seconds: {diff.TotalSeconds.ToString("0.00")}");
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

        //saLAm -> Salam
        static string Capitalize(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;

            string newStr = char.ToUpper(str[0]).ToString();

            if (str.Length > 1)
                newStr += str.Substring(1).ToLower();

            return newStr;
        }

        static void AddStudent(ref string[] names,ref byte[]ages)
        {
            string name;
            do
            {
                Console.WriteLine("Telebe adini daxil edin:");
                name = Console.ReadLine();

            } while (!CheckName(name));
            string ageStr;
            byte age;
            do
            {
                Console.WriteLine("Yasi daxil edin:");
                ageStr = Console.ReadLine();
            } while (!byte.TryParse(ageStr,out age) || age<15 || age>60);

            Array.Resize(ref names, names.Length + 1);
            names[names.Length - 1] = Capitalize(name);

            Array.Resize(ref ages, ages.Length + 1);
            ages[ages.Length - 1] = age;
        }

        static void RemoveElementByIndex(ref string[] arr,int index)
        {
            //string[] newArr = new string[arr.Length - 1];

            //int j = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (i != index)
            //    {
            //        newArr[j] = arr[i];
            //        j++;
            //    }
            //}
            //arr=newArr;
            for (int i = index; i < arr.Length-1; i++)
            {
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }

            Array.Resize(ref arr, arr.Length - 1);
        }

        static void RemoveElementByIndex(ref byte[] arr, int index)
        {
            
            for (int i = index; i < arr.Length - 1; i++)
            {
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }

            Array.Resize(ref arr, arr.Length - 1);
        }
    }
}
