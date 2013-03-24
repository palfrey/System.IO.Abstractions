﻿using System.Diagnostics;
using NUnit.Framework;
using System.IO;

namespace System.IO.Abstractions.TestingHelpers.Tests
{
    public class MockPathTests
    {
        private bool UnixSystem {get {
            return Path.DirectorySeparatorChar != '\\';
        }}


        private string TestPath {get {
            if (UnixSystem)
                return "/test/test.bmp";
            else
                return "C:\\test\\test.bmp";
        }}

        private MockPath SetupMockPath()
        {
            return new MockPath();
        }

        [Test]
        public void ChangeExtension_ExtensionNoPeriod_PeriodAdded()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.ChangeExtension(TestPath, "doc");

            //Assert
            Assert.AreEqual(UnixSystem?"/test/test.doc":"C:\\test\\test.doc", result);
        }

        [Test]
        public void Combine_SentTwoPaths_Combines()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.Combine(UnixSystem?"/test":"C:\\test", "test.bmp");

            //Assert
            Assert.AreEqual(UnixSystem?"/test/test.bmp":"C:\\test\\test.bmp", result);
        }

        [Test]
        public void GetDirectoryName_SentPath_ReturnsDirectory()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetDirectoryName(TestPath);

            //Assert
            Assert.AreEqual(UnixSystem?"/test":"C:\\test", result);
        }

        [Test]
        public void GetExtension_SendInPath_ReturnsExtension()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetExtension(TestPath);

            //Assert
            Assert.AreEqual(".bmp", result);
        }

        [Test]
        public void GetFileName_SendInPath_ReturnsFilename()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetFileName(TestPath);

            //Assert
            Assert.AreEqual("test.bmp", result);
        }

        [Test]
        public void GetFileNameWithoutExtension_SendInPath_ReturnsFileNameNoExt()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetFileNameWithoutExtension(TestPath);

            //Assert
            Assert.AreEqual("test", result);
        }

        [Test]
        public void GetFullPath_SendInPath_ReturnsFullPath()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetFullPath(TestPath);

            //Assert
            Assert.AreEqual(TestPath, result);
        }

        [Test]
        public void GetInvalidFileNameChars_Called_ReturnsChars()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetInvalidFileNameChars();

            //Assert
            Assert.IsTrue(result.Length > 0);
        }

        [Test]
        public void GetInvalidPathChars_Called_ReturnsChars()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetInvalidPathChars();

            //Assert
            Assert.IsTrue(result.Length > 0);
        }

        [Test]
        public void GetPathRoot_SendInPath_ReturnsRoot()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetPathRoot(TestPath);

            //Assert
            Assert.AreEqual(UnixSystem?"/":"C:\\", result);
        }

        [Test]
        public void GetRandomFileName_Called_ReturnsStringLengthGreaterThanZero()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetRandomFileName();

            //Assert
            Assert.IsTrue(result.Length>0);
        }

        [Test]
        public void GetTempFileName_Called_ReturnsStringLengthGreaterThanZero()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetTempFileName();

            //Assert
            Assert.IsTrue(result.Length > 0);
        }

        [Test]
        public void GetTempPath_Called_ReturnsStringLengthGreaterThanZero()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.GetTempPath();

            //Assert
            Assert.IsTrue(result.Length > 0);
        }

        [Test]
        public void HasExtension_PathSentIn_DeterminesExtension()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.HasExtension(TestPath);

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsPathRooted_PathSentIn_DeterminesPathExists()
        {
            //Arrange
            var mockPath = SetupMockPath();

            //Act
            var result = mockPath.IsPathRooted(TestPath);

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}
