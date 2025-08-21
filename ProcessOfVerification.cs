using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckArhcivAvail
{
    /// <summary>
    /// Процесс проверки
    /// </summary>
    internal class ProcessOfVerification
    {
        public ProcessOfVerification() { }

        /// <summary>
        /// Главная логика проверки
        /// </summary>
        public void MainProcces()
        {
            try
            {
                CheckDirectory checkDirectory = new CheckDirectory();
                Setting setting = new Setting();
                IEnumerable<FileInfo> archives;

                while (true)
                {
                    if (checkDirectory.CheckForAnArchive())
                    {
                        Thread.Sleep(setting.RepeatCheckInSeconds);
                        if(checkDirectory.CheckForAnArchive())
                        {
                            archives = checkDirectory.Archives;
                            AlertPrc();
                        }
                    }
                    else
                    {
                        archives = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        
    }
}
