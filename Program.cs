using System;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace W2_DevMode
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!IsCompatibleFrontend(W2_DevMode.Main.options.filename))
            {
                MessageBox.Show("Unable to find a compatible frontend.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        private static bool IsCompatibleFrontend(string filename)
        {
            byte[] signature = { 0x57, 0x6F, 0x72, 0x6D, 0x73, 0x32 };
            try
            {
                using (FileStream frontend = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    frontend.Seek(0x115140, SeekOrigin.Begin);
                    foreach (byte expected in signature)
                    {
                        if (frontend.ReadByte() != expected)
                            return false;
                    }
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (SecurityException)
            {
                return false;
            }
        }
    }
}
