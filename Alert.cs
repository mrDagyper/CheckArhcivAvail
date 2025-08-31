using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckArhcivAvail
{
    internal class Alert
    {

        private string PathInSound
        {
            get
            {
                return Setting.PathInSound;
            }
        }

        /// <summary>
        /// Коллекция найденых архивов
        /// </summary>
        public List<string> NameArchives = new List<string>();
        private List<int> LenghtSymbolInFile = new List<int>();
        private int CountTextIfFindArhive;
        /// <summary>
        /// Начальная позиция курсора для архива
        /// </summary>
        private int CrsPos = 5;

        public Alert() { }
        public Alert(List<string> nameArchives) 
        {
            NameArchives = nameArchives;
        }
     


        /// <summary>
        /// Оповещение
        /// </summary>
        public void AlertProcess()
        {
            AlertSound();
            AlertText();
        }

        public void SlineceAlertProcess()
        {
            AlertText();
        }
        
        /// <summary>
        /// Текстовое оповещения о наличия архива в директории
        /// </summary>
        private void AlertText()
        {

            TextIfFindArhive(NameArchives.Count);

            ClearTextAlert();
            LenghtSymbolInFile.Clear();

            Console.SetCursorPosition(0, CrsPos);
            foreach (var file in NameArchives)
            {
                LenghtSymbolInFile.Add(file.Length);
                Console.WriteLine(file);
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
                sound.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            
        }

        /// <summary>
        /// Очищает в консоли элементы коллекции
        /// </summary>
        private void ClearTextAlert()
        {
            if ( LenghtSymbolInFile != null )
            {
                int num = 0;
                foreach (var match in LenghtSymbolInFile)
                {
                    Console.SetCursorPosition(0, CrsPos + num);
                    Console.Write(new string(' ', match));
                    Console.SetCursorPosition(0, CrsPos + num);
                    num++;
                }
            }
        }

        /// <summary>
        /// Информация в консоле о последней проверке
        /// </summary>
        /// <param name="strTimeCheck"></param>
        /// <returns></returns>
        public string InformationCheck(string strTimeCheck)
        {
            string text = "Последняя проверка проведена в " + DateTime.Now.ToString();

            if (strTimeCheck != null)
            {
                Console.SetCursorPosition(0, 2);
                Console.Write(new string(' ', strTimeCheck.Length));
                Console.SetCursorPosition(0, 2);
            }

            Console.WriteLine(text);
            return text;
        }

        internal void ClearOther()
        {
            if (LenghtSymbolInFile != null)
            {

                Console.SetCursorPosition(0, CrsPos-1);
                Console.Write(new string(' ', CountTextIfFindArhive));
                Console.SetCursorPosition(0, CrsPos -1);

                int num = 0;
                foreach (var match in LenghtSymbolInFile)
                {
                    Console.SetCursorPosition(0, CrsPos + num);
                    Console.Write(new string(' ', match));
                    Console.SetCursorPosition(0, CrsPos + num);
                    num++;
                }
            }
        }

        private void TextIfFindArhive(int count)
        {
            Console.SetCursorPosition(0, CrsPos - 1);
            string text = "============== Обнаружено заявок: " + count.ToString() + " ==================";
            Console.WriteLine(text);
            CountTextIfFindArhive = text.Length;
        }
    }
}
