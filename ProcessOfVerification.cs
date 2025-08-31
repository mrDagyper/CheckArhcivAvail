using System;
using System.Collections;
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
                List<string> archives = new List<string> ();
                archives = null;
                Alert alert = new Alert();
                string strTimeCheck = null;

                while (true)
                {
                    if (checkDirectory.CheckForAnArchive())
                    {
                        if (archives == null)
                        {
                            Thread.Sleep(Setting.RepeatCheckInSeconds);
                            if (checkDirectory.CheckForAnArchive())
                            {
                                //Console.Clear();
                                archives = checkDirectory.Archives;
                                alert.NameArchives = archives;
                                strTimeCheck = alert.InformationCheck(strTimeCheck);
                                alert.AlertProcess();
                            }
                        }
                        else if (!archives.SequenceEqual(checkDirectory.Archives))
                        {
                            Thread.Sleep(Setting.RepeatCheckInSeconds);
                            if (checkDirectory.CheckForAnArchive())
                            {
                               // Console.Clear();
                                archives = checkDirectory.Archives.ToList();
                                alert.NameArchives = archives;
                                strTimeCheck = alert.InformationCheck(strTimeCheck);
                                alert.AlertProcess();
                            }
                        }
                        else if (archives.SequenceEqual(checkDirectory.Archives))
                        {
                          //  Console.Clear();
                            strTimeCheck = alert.InformationCheck(strTimeCheck);
                            alert.SlineceAlertProcess();

                        }
                        
                    }
                    else
                    {
                        if (alert.NameArchives.Count > 0)
                        {
                            alert.ClearOther();
                        }

                        //Console.Clear();
                        strTimeCheck = alert.InformationCheck(strTimeCheck);
                        archives = null;
                    }

                   // strTimeCheck = InformationCheck(strTimeCheck);
                    Thread.Sleep(Setting.CheckTimeIntervalInMinuts);
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
