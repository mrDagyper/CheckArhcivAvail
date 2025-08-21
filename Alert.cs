using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CheckArhcivAvail
{
    internal class Alert
    {

        private string PathInSound
        {
            get
            {
                return PathInSound;
            }
            set
            {
                Setting setting = new Setting();
                PathInSound = setting.PathInSound;
            }
        }

        private IEnumerable<FileInfo> NameArchives { get; set; }

        public Alert() { }
        public Alert(IEnumerable<FileInfo> nameArchives) 
        {
            NameArchives = nameArchives;
        }
     


        /// <summary>
        /// Оповещение
        /// </summary>
        private void AlertProcedure()
        {
            AlertSound();
            AlertText();

        }
        
        /// <summary>
        /// Текстовое оповещения о наличия архива в директории
        /// </summary>
        private void AlertText()
        {
            foreach (var file in NameArchives)
            {
                Console.WriteLine(file.FullName.ToString());
            }

        }

        /// <summary>
        /// Воспроизведение звукового сигнала
        /// </summary>
        private void AlertSound()
        {
            try
            {
                SoundPlayer sound = new SoundPlayer
                {
                    SoundLocation = PathInSound
                };
                sound.Load();
                sound.PlayLooping();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            
        }
    }
}
