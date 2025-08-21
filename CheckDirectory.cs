using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CheckArhcivAvail
{
    /// <summary>
    /// Проверка директории
    /// </summary>
    internal class CheckDirectory
    {
        private string Path { get; set; }

        public IEnumerable<FileInfo> Archives;

        public CheckDirectory() 
        {
            Setting setting = new Setting();
            Path = setting.Path;
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
            => allFiles.Where(x => x.Extension.ToLower() == ".rar");

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
                this.Archives = archives;
                return true;
            }
            this.Archives = null;
            return false;
        }
    }

}
