using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckArhcivAvail
{
    internal static class Setting
    {
        /// <summary>
        /// Путь к директории проверки
        /// </summary>
        public static string Path
        {
            get
            {
                string path = ConfigurationManager.AppSettings["Path"];
                if (path == null)
                {
                    throw new Exception("В настройках поле Path не заполнено");
                }
                else
                {
                    return path;
                }
            }
        }
        /// <summary>
        /// Расширение файла для проверки его наличия
        /// </summary>
        public static string FileExtension
        {
            get
            {
                string fileExtension = ConfigurationManager.AppSettings["FileExtension"];
                if (fileExtension == null)
                {
                    throw new Exception("В настройках поле FileExtension не заполнено");
                }
                else
                {
                    return fileExtension;
                }
            }
        }
        /// <summary>
        /// Временой интервал между проверками в минутах
        /// </summary>
        public static int CheckTimeIntervalInMinuts
        {
            get
            {
                string checkTimeIntervalInMinuts = ConfigurationManager.AppSettings["CheckTimeIntervalInMinuts"];
                if (checkTimeIntervalInMinuts == null)
                {
                    throw new Exception("В настройках поле CheckTimeIntervalInMinuts не заполнено");
                }
                else
                {
                    return Int32.Parse(checkTimeIntervalInMinuts) * 60000;
                }
            }
        }
        /// <summary>
        /// Включить звуковое сопровождение при обнаружении файла
        /// </summary>
        public static bool AudioPlayback
        {
            get
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
                    return bool.Parse(audioPlayback);
                }
            }
        }
        /// <summary>
        /// Повторная пауза перед повторной проверкой. Время в секундах.
        /// </summary>
        public static int RepeatCheckInSeconds
        {
            get
            {
                string repeatCheckInSeconds = ConfigurationManager.AppSettings["RepeatCheckInSeconds"];
                if (repeatCheckInSeconds == null)
                {
                    throw new Exception("В настройках поле RepeatCheckInSeconds не заполнено");
                }
                else
                {
                    return Int32.Parse(repeatCheckInSeconds) * 1000;
                }
            }
        }
        /// <summary>
        /// Путь к звуковой дорожке
        /// </summary>
        public static string PathInSound
        {
            get
            {
                string pathInSound = ConfigurationManager.AppSettings["PathInSound"];
                if (pathInSound == null)
                {
                    throw new Exception("В настройках поле PathInSound не заполнено");
                }
                else
                {
                    return pathInSound;
                }
            }
        }

    }
}
