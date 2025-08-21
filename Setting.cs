using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckArhcivAvail
{
    internal class Setting
    {
        /// <summary>
        /// Путь к директории проверки
        /// </summary>
        public string Path
        {
            get
            {
                return Path;
            }
            set
            {
                string path = ConfigurationManager.AppSettings["Path"];
                if (path == null)
                {
                    throw new Exception("В настройках поле Path не заполнено");
                }
                else
                {
                    _ = path;
                }
            }
        }
        /// <summary>
        /// Расширение файла для проверки его наличия
        /// </summary>
        public string FileExtension
        {
            get
            {
                return FileExtension;
            }
            set
            {
                string fileExtension = ConfigurationManager.AppSettings["FileExtension"];
                if (fileExtension == null)
                {
                    throw new Exception("В настройках поле FileExtension не заполнено");
                }
                else
                {
                    _ = fileExtension;
                }
            }
        }
        /// <summary>
        /// Временой интервал между проверками в минутах
        /// </summary>
        public int CheckTimeIntervalInMinuts
        {
            get
            {
                return CheckTimeIntervalInMinuts * 60000;
            }
            set
            {
                string checkTimeIntervalInMinuts = ConfigurationManager.AppSettings["CheckTimeIntervalInMinuts"];
                if (checkTimeIntervalInMinuts == null)
                {
                    throw new Exception("В настройках поле CheckTimeIntervalInMinuts не заполнено");
                }
                else
                {
                    _ =  Int32.Parse(checkTimeIntervalInMinuts);
                }
            }
        }
        /// <summary>
        /// Включить звуковое сопровождение при обнаружении файла
        /// </summary>
        public bool AudioPlayback
        {
            set
            {
                string audioPlayback = ConfigurationManager.AppSettings["AudioPlayback"];
                if (audioPlayback == null)
                {
                    throw new Exception("В настройках поле AudioPlayback не заполнено");
                }
                else if (audioPlayback != "true" || audioPlayback != "false")
                {
                    Console.WriteLine("В настройках поле Path не заполнено");
                    throw new Exception("В поле AudioPlayback не верно записано true/false");
                }
                else
                {
                    _ = bool.Parse(audioPlayback);
                }
            }
        }
        /// <summary>
        /// Повторная поверка после предварительного нахождения файла в секундах
        /// </summary>
        public int RepeatCheckInSeconds
        {
            get
            {
                return RepeatCheckInSeconds * 1000;
            }
            set
            {
                string repeatCheckInSeconds = ConfigurationManager.AppSettings["RepeatCheckInSeconds"];
                if (repeatCheckInSeconds == null)
                {
                    throw new Exception("В настройках поле RepeatCheckInSeconds не заполнено");
                }
                else
                {
                    _ = Int32.Parse(repeatCheckInSeconds);
                }
            }
        }
        /// <summary>
        /// Путь к звуковой дорожке
        /// </summary>
        public string PathInSound
        {
            get
            {
                return PathInSound;
            }
            set
            {
                string pathInSound = ConfigurationManager.AppSettings["PathInSound"];
                if (pathInSound == null)
                {
                    throw new Exception("В настройках поле PathInSound не заполнено");
                }
                else
                {
                    _ = pathInSound;
                }
            }
        }

    }
}
