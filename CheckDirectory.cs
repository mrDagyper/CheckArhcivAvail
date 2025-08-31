using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CheckArhcivAvail
{
    /// <summary>
    /// Проверка директории
    /// </summary>
    internal class CheckDirectory
    {
        /// <summary>
        /// Директория для проверки
        /// </summary>
        private string Path;
        /// <summary>
        /// Коллекция найденных архивов
        /// </summary>
       // public IEnumerable<string> Archives;
        public List<string> Archives;
        private string FileExtension;


        public CheckDirectory() 
        {
            //Setting setting = new Setting();
            Path = Setting.Path;
            FileExtension = Setting.FileExtension;
        }
        public CheckDirectory(string path) {  Path = path; }

        /// <summary>
        /// Получение всех файлов директории
        /// </summary>
        /// <returns></returns>
        private FileInfo[] GetFilesForDirectory()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path);
            FileInfo[] files = directoryInfo.GetFiles();
            return files;
        }

        /// <summary>
        /// Вернуть название архивов в каталоге
        /// </summary>
        /// <param name="allFiles">все файлы в каталоге</param>
        /// <returns></returns>
        private IEnumerable<FileInfo> GetArchiveForDirectory(FileInfo[] allFiles)
            => allFiles.Where(x => x.Extension.ToLower() == FileExtension);

        /// <summary>
        /// Проверка на наличие архива в директории
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool CheckForAnArchive()
        {
            var archives = GetArchiveForDirectory(GetFilesForDirectory());
            if( archives.Count() != 0)
            {
                //this.Archives = archives;
                PullsOutTheName(archives);
                return true;
            }
            this.Archives = null;
            return false;
        }

        private void PullsOutTheName(IEnumerable<FileInfo> files)
        {
            List<string> names = new List<string>();
            foreach (var file in files)
            {
               names.Add(file.FullName);
            }
            this.Archives = names;
            
        }
    }

}
