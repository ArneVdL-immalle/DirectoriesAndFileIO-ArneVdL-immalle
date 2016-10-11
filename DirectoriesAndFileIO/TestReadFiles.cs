using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace DirectoriesAndFileIO
{
    [TestClass]
    public class TestReadFiles
    {
        string testDir = "";
        string fileA = "";
        string fileAContents = "";
        string fileB = "";
        string fileBContents = "";
        string subDir = "";
        string subDirFile = "";
        string subDirFileContents = "";

        [TestInitialize]
        public void Initialize()
        {
            // Create a test-directory with known files and directories
            testDir = "testDir";
            fileA = Path.Combine(testDir, "a.txt");
            fileB = Path.Combine(testDir, "b.txt");
            subDir = Path.Combine(testDir, "subDir");
            subDirFile = Path.Combine(subDir, subDirFile);
            fileAContents = "This is a.txt.";
            fileBContents = "This is b.txt. \n fileB";
            subDirFileContents = "This is a file in a sub-directory.";

            Directory.CreateDirectory(testDir);
            File.WriteAllText(fileA, fileAContents);
            File.WriteAllText(fileB, fileBContents);
            Directory.CreateDirectory(subDir);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (Directory.Exists(testDir))
            {
                Directory.Delete(testDir, recursive: true);
            }
        }

        [TestMethod]
        public void TestFileReadAllText()
        {
            string txt = File.ReadAllText(fileA);
            Assert.AreEqual(fileAContents, txt);

            string txt2 = File.ReadAllText(fileB);
            Assert.AreEqual(fileBContents, txt2);
        }

        [TestMethod]
        public void TestReadAllLines()
        {
            string[] lines = File.ReadAllLines(fileA);

            Assert.AreEqual(1, lines.Length);
            Assert.AreEqual(fileAContents, lines[0]);

            string[] lines2 = File.ReadAllLines(fileB);

            Assert.AreEqual(2, lines2.Length);
            String line = lines2[0] + "\n"+ lines2[1];
            Assert.AreEqual(fileBContents, line);
        }

        [TestMethod]
        public void TestFileOpenText()
        {
            string path = @"D:\6ITN\Arne Van den Langenbergh\SOFTW\DirectoriesAndFileIO\DirectoriesAndFileIO\bin\Debug\MyTest.txt";

            if (!File.Exists(path))
            {
                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes("is some text in the file.");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }        

        [TestMethod]
        public void TestStreamReader()
        {
            StreamReader s = new StreamReader(fileA);

            string txt = s.ReadToEnd();
            Assert.AreEqual(fileAContents, txt);

            s.Close();
        }

        [TestMethod]
        public void TestFileStream()
        {
            byte[] data = new byte[20]; // we choose 20 bytes because that's more than enough for what we choose as fileAContents, all bytes will be initialized to 0

            FileStream stream = File.OpenRead(fileA);
            int r = stream.Read(data, 0, 20); // we read 20 bytes or less if the stream is finished

            string txt = "";
            foreach(byte b in data)
            {
                if(b != 0) // the last bytes of the array will still be 0
                {
                    txt += (char)b;
                }
            }

            Assert.AreEqual(fileAContents.Length, r);
            Assert.AreEqual(fileAContents, txt);

            stream.Close();
        }

    }
}
