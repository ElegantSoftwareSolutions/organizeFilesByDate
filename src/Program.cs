// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Elegant Software Solutions, LLC">
//   MIT License
//   Copyright Elegant Software Solutions, LLC
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace LogOrganizer
{
    using System.Linq;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     The path.
        /// </summary>
        private static string path;

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            if (args.Count() < 1)
            {
                // MessageWriter.WriteLine("please add path as command line argument");
                return;
            }

            path = args.First();
            var allDirectoryPaths = new DirectoryManager().GetChildDirectories(path);

            foreach (var directory in allDirectoryPaths)
            {
                var fileOrganizer = new FileOrganizer(directory);
                fileOrganizer.OrganizeFiles();
            }

            // MessageWriter.WriteLine("work complete, great one...");
        }
    }
}