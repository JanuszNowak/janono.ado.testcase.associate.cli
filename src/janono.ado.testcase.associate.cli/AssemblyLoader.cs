using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;

namespace janono.ado.testcase.associate.cli
{
    public static class AssemblyLoader
    {
        private static readonly ConcurrentDictionary<string, bool> AssemblyDirectories = new ConcurrentDictionary<string, bool>();

        //static AssemblyLoader()
        //{
        //    AssemblyDirectories[GetExecutingAssemblyDirectory()] = true;
        //    AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
        //}

        public static Assembly LoadWithDependencies(string assemblyPath)
        {
            AssemblyDirectories[Path.GetDirectoryName(assemblyPath)] = true;
            return Assembly.LoadFile(assemblyPath);
        }

        //private static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        //{
        //    var dependentAssemblyName = args.Name.Split(',')[0] + ".dll";
        //    var directoriesToScan = AssemblyDirectories.Keys.ToList();

        //    foreach (var directoryToScan in directoriesToScan)
        //    {
        //        var dependentAssemblyPath = Path.Combine(directoryToScan, dependentAssemblyName);
        //        if (File.Exists(dependentAssemblyPath))
        //        {
        //            return LoadWithDependencies(dependentAssemblyPath);
        //        }
        //    }

        //    return null;
        //}

        //private static string GetExecutingAssemblyDirectory()
        //{
        //    var codeBase = Assembly.GetExecutingAssembly().CodeBase;
        //    var uri = new UriBuilder(codeBase);
        //    var path = Uri.UnescapeDataString(uri.Path);
        //    return Path.GetDirectoryName(path);
        //}
    }
}