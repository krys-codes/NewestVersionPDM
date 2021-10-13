using EdmLib;
using System;
using System.Diagnostics;

namespace newestversion
{
    class Program
    {
        /// <summary>
        /// Get path from clipboard (excel calculation) and run newest version of file
        /// </summary>
        /// <param name="args">put file path as args</param>
        static void Main(string[] args)
        {
            IEdmVault5 Vault = new EdmVault5();
            string vaultName = "YourVaultName";

            //login if user is not authenticated
            Vault.LoginAuto(vaultName, 0); 

            string mainPath = args[0];

            if (string.IsNullOrEmpty(mainPath)) { Console.WriteLine("path is empty.."); }
            else
            {
                IEdmFolder5 folder = default(IEdmFolder5);
                IEdmFile5 file = Vault.GetFileFromPath(mainPath, out folder);
                file.GetFileCopy(0);
                Process.Start(mainPath);
            }
        }
    }
}
