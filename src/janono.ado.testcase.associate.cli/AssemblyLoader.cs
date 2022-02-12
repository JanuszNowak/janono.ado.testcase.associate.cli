using System.Collections.Concurrent;
using System.IO;
using System.Reflection;

namespace janono.ado.testcase.associate.cli
{
    public static class AssemblyLoader
    {
        private static readonly ConcurrentDictionary<string, bool> AssemblyDirectories = new ConcurrentDictionary<string, bool>();

        public static Assembly LoadWithDependencies(string assemblyPath)
        {
            AssemblyDirectories[Path.GetDirectoryName(assemblyPath)] = true;
            return Assembly.LoadFile(assemblyPath);
        }
    }
}