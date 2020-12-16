using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace compareFiles
{
    public static class Helper
    {
        // This method accepts two strings the represent two files to
        // compare. A return value of 0 indicates that the contents of the files
        // are the same. A return value of any other value indicates that the
        // files are not the same.
        public static bool FileCompare(Dictionary<string, string> pathToFiles)
        {
            string file1 = pathToFiles["file1"];
            string file2 = pathToFiles["file2"];
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            if (file1 == file2)
            {
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            } while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is
            // equal to "file2byte" at this point only if the files are
            // the same.
            return ((file1byte - file2byte) == 0);
        }
        public static bool TxtFileCompare(Dictionary<string, string> pathToFiles)
        {
            bool result = false;

            string pathToFile1 = pathToFiles["file1"];
            string pathToFile2 = pathToFiles["file2"];

            string file1 = GetMd5(File.ReadAllBytes(pathToFile1));
            string file2 = GetMd5(File.ReadAllBytes(pathToFile2));

            if (file1 == file2)
            {
                result = true;
            }

            return result;
        }
        public static string GetMd5(byte[] b)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(b);
            StringBuilder hash = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                hash.Append(data[i].ToString("x2"));
            }

            return hash.ToString();
        }
    }
}