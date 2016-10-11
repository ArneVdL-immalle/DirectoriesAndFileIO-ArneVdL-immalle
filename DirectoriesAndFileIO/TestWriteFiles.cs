using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DirectoriesAndFileIO
{
    [TestClass]
    public class TestWriteFiles
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
                Directory.Delete(testDir, true);
            }
        }

        [TestMethod]
        public void TestFileWriteAllText()
        {
            File.WriteAllText(fileA, fileAContents);
            string txt = File.ReadAllText(fileA);
            Assert.AreEqual(fileAContents, txt);

            File.WriteAllText(fileB, fileBContents);
            string txt2 = File.ReadAllText(fileB);
            Assert.AreEqual(fileBContents, txt2);
        }

        [TestMethod]
        public void TestWriteAllLines()
        {
            File.WriteAllLines(fileA, fileAContents.Split('\n'));

            string[] lines = File.ReadAllLines(fileA);

            Assert.AreEqual(1, lines.Length);
            Assert.AreEqual(fileAContents, lines[0]);

            File.WriteAllLines(fileB, fileBContents.Split('\n'));

            string[] lines2 = File.ReadAllLines(fileB);

            Assert.AreEqual(2, lines2.Length);
            String line = lines2[0] + "\n" + lines2[1];
            Assert.AreEqual(fileBContents, line);
        }
    }
}
