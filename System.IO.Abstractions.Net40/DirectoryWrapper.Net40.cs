using System.Collections.Generic;

namespace System.IO.Abstractions
{
    public partial class DirectoryWrapper
    {
        public override IEnumerable<string> EnumerateFiles(string path)
        {
            return Directory.EnumerateFiles(path);
        }

        public override IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern);
        }

        public override IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateFiles(path, searchPattern, searchOption);
        }

        public override IEnumerable<string> EnumerateDirectories(string path)
        {
            return Directory.EnumerateDirectories(path);
        }

        public override IEnumerable<string> EnumerateDirectories(string path, string searchPattern)
        {
            return Directory.EnumerateDirectories(path, searchPattern);
        }

        public override IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.EnumerateDirectories(path, searchPattern, searchOption);
        }
    }
}
