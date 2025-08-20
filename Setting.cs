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
        private string Path
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
                    throw new Exception("В найстройках поле Path не заполнено");
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
        private string FileExtension
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
                    throw new Exception("В найстройках поле FileExtension не заполнено");
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
        private int CheckTimeIntervalInMinuts
        {
            get
            {
                return CheckTimeIntervalInMinuts;
            }
            set
            {
                string checkTimeIntervalInMinuts = ConfigurationManager.AppSettings["CheckTimeIntervalInMinuts"];
                if (checkTimeIntervalInMinuts == null)
                {
                    throw new Exception("В найстройках поле CheckTimeIntervalInMinuts не заполнено");
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
        private bool AudioPlayback
        {
            set
            {
                string audioPlayback = ConfigurationManager.AppSettings["AudioPlayback"];
                if (audioPlayback == null)
                {
                    throw new Exception("В найстройках поле AudioPlayback не заполнено");
                }
                else if (audioPlayback != "true" || audioPlayback != "false")
                {
                    throw new Exception("В поле AudioPlayback не верно записано true/false");
                }
                else
                {
                    _ = bool.Parse(audioPlayback);
                }
            }
        }
        /// <summary>
        /// Повторная поверка после предварительного нахождения файла
        /// </summary>
        private int RepeatCheckInSeconds
        {
            get
            {
                return RepeatCheckInSeconds;
            }
            set
            {
                string repeatCheckInSeconds = ConfigurationManager.AppSettings["RepeatCheckInSeconds"];
                if (repeatCheckInSeconds == null)
                {
                    throw new Exception("В найстройках поле RepeatCheckInSeconds не заполнено");
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
        private string PathInSound
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
                    throw new Exception("В найстройках поле PathInSound не заполнено");
                }
                else
                {
                    _ = pathInSound;
                }
            }
        }

    }
}
