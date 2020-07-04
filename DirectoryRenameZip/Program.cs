using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace DirectoryRenameZip
{
    class Program
    {
        static void Main(string[] args)
        {
            var directories = new List<string>();
            if (args.Length >= 1)
            {
                directories.AddRange(args);
            }
            else
            {
                Console.WriteLine("圧縮するディレクトリを引数に渡してください");
                return;
            }

            Console.WriteLine("圧縮後のファイル名から一括して置換するワードを入力してください");
            string before = Console.ReadLine();

            Console.WriteLine("置換後のワードを入力してください");
            string after = Console.ReadLine();

            foreach (string directory in directories)
            {
                if (!Directory.Exists(directory))
                {
                    Console.WriteLine("ディレクトリではありませんでした", directory);
                    continue;
                }

                string rename = Path.Combine(Directory.GetParent(directory).FullName, 
                    Path.GetFileName(directory).Replace(before, after) + ".zip");

                Console.WriteLine("{0}圧縮中...", rename);
                ZipFile.CreateFromDirectory(directory, rename);
            }
        }
    }
}
