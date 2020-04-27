using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    /// <summary>
    /// Абстрактный класс <c>WayOfCommunication</c>,
    /// представляющий способ коммуникации - сообщение, голосовое сообщение или звонок.
    /// <list type="bullet">
    /// <item>
    /// <term>Messenger</term>
    /// <description>Экземпляр интерфейса IMessanger.</description>
    /// </item>
    /// <item>
    /// <term>Text</term>
    /// <description>Свойство - текст передаваемого сообщения.</description>
    /// </item>
    /// <item>
    /// <term>FileName</term>
    /// <description>Название файла, содержащего сообщение.</description>
    /// </item>
    /// <item>
    /// <term>Send</term>
    /// <description>Метод для передачи сообщения.</description>
    /// </item>
    /// <item>
    /// <term>CompileFile</term>
    /// <description>Метод для формирования сообщения.</description>
    /// </item>
    /// </list>
    /// </summary>

    public abstract class WayOfCommunication
    {
        /// <summary>
        /// Экземпляр интерфейса IMessanger.
        /// </summary>
        public IMessanger Messenger { get; set; }
        /// <summary>
        /// Свойство - текст передаваемого сообщения.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Название файла, содержащего сообщение.
        /// </summary>
        public string FileName;
        /// <summary>
        /// Метод для передачи сообщения.
        /// </summary>
        public abstract void Send();
        /// <summary>
        /// Метод для формирования сообщения.
        /// </summary>
        public abstract void CompileFile();
    }
    /// <summary>
    /// Класс <c>TextMessage</c>,
    /// представляющий уточненную абстракцию, способ коммуникации - текстовое сообщение.
    /// <list type="bullet">
    /// <item>
    /// <term>Send</term>
    /// <description>Переопределенный метод Send родительского класса.</description>
    /// </item>
    /// <item>
    /// <term>CompileFile</term>
    /// <description>Переопределенный метод CompileFile родительского класса.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class TextMessage : WayOfCommunication
    {
        /// <summary>
        /// Переопределенный метод Send родительского класса.
        /// </summary>
        public override void Send()
        {
            Console.WriteLine("Ready to send a text message...");
            CompileFile();
            // Обращаемся к методy интерфеса IMessanger через экземпляр интерфейса.
            // Связываем абстракцию и реализацию.
            Messenger.SendMessage(FileName);
            Console.WriteLine("Text message sent.");
        }
        /// <summary>
        /// Переопределенный метод CompileFile родительского класса.
        /// </summary>
        public override void CompileFile()
        {
            FileName = "message.txt";
            Console.WriteLine("Create a text file using this text: " + Text);
        }
    }

    /// <summary>
    /// Класс <c>VoiceMessage</c>,
    /// представляющий уточненную абстракцию, способ коммуникации - голосовое сообщение.
    /// <list type="bullet">
    /// <item>
    /// <term>Send</term>
    /// <description>Переопределенный метод Send родительского класса.</description>
    /// </item>
    /// <item>
    /// <term>CompileFile</term>
    /// <description>Переопределенный метод CompileFile родительского класса.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class VoiceMessage : WayOfCommunication
    {
        /// <summary>
        /// Переопределенный метод Send родительского класса.
        /// </summary>
        public override void Send()
        {
            Console.WriteLine("Ready to send a voice message...");
            CompileFile();
            Messenger.SendMessage(FileName);
            Console.WriteLine("Voice message sent.");
        }
        /// <summary>
        /// Переопределенный метод CompileFile родительского класса.
        /// </summary>
        public override void CompileFile()
        {
            FileName = "message.mp3";
            Console.WriteLine("Create a sound file using this text: " + Text);
        }
    }
    /// <summary>
    /// Класс <c>Call</c>,
    /// представляющий уточненную абстракцию, способ коммуникации - звонок.
    /// <list type="bullet">
    /// <item>
    /// <term>Send</term>
    /// <description>Переопределенный метод Send родительского класса.</description>
    /// </item>
    /// <item>
    /// <term>CompileFile</term>
    /// <description>Переопределенный метод CompileFile родительского класса.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class Call : WayOfCommunication
    {
        /// <summary>
        /// Переопределенный метод Send родительского класса.
        /// </summary>
        public override void Send()
        {
            Console.WriteLine("Ready to call a user...");
            CompileFile();
            Messenger.SendMessage(FileName);
            Console.WriteLine("Call completed.");
        }
        /// <summary>
        /// Переопределенный метод CompileFile родительского класса.
        /// </summary>
        public override void CompileFile()
        {
            FileName = "message.call";
            Console.WriteLine("Create a call file using this text: " + Text);
        }
    }

    /// <summary>
    /// Интерфейс <c>IMessanger</c>,
    /// представляющий мессенджер, через который передается сообщение.
    /// <list type="bullet">
    /// <item>
    /// <term>SendMessage</term>
    /// <description>Метод для отправки сообщения через мессенджер.</description>
    /// </item>
    /// </list>
    /// </summary>
    public interface IMessanger
    {
        /// <summary>
        /// Метод для отправки сообщения в конкретном мессенджере.
        /// </summary>
        void SendMessage(string fiilename);
    }

    /// <summary>
    /// Класс <c>VKontakte</c>,
    /// представляющий уточнение реализации, мессенджер - ВКонтакте.
    /// <list type="bullet">
    /// <item>
    /// <term>SendMessage</term>
    /// <description>Реализация метода отправки сообщения через ВКонтакте.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class VKontakte : IMessanger
    {
        /// <summary>
        /// Метод для отправки сообщения в ВКонтакте.
        /// </summary>
        public void SendMessage(string fiilename)
        {
            Console.WriteLine("Using VKontakte to contact a user with a file:"+fiilename);
        }
    }

    /// <summary>
    /// Класс <c>WhatsApp</c>,
    /// представляющий уточнение реализации, мессенджер - WhatsApp.
    /// <list type="bullet">
    /// <item>
    /// <term>SendMessage</term>
    /// <description>Реализация метода отправки сообщения через WhatsApp.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class WhatsApp : IMessanger
    {
        /// <summary>
        /// Метод для отправки сообщения в WhatsApp.
        /// </summary>
        public void SendMessage(string fiilename)
        {
            Console.WriteLine("Using WhatsApp to contact a user with a file:" + fiilename);
        }
    }

    /// <summary>
    /// Класс <c>Telegram</c>,
    /// представляющий уточнение реализации, мессенджер - Telegram.
    /// <list type="bullet">
    /// <item>
    /// <term>SendMessage</term>
    /// <description>Реализация метода отправки сообщения через Telegram.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class Telegram : IMessanger
    {
        /// <summary>
        /// Метод для отправки сообщения в Telegram.
        /// </summary>
        public void SendMessage(string fiilename)
        {
            Console.WriteLine("Using Telegram to contact a user with a file:" + fiilename);
        }
    }
    /// <summary>
    /// Класс <c>Viber</c>,
    /// представляющий уточнение реализации, мессенджер - Viber.
    /// <list type="bullet">
    /// <item>
    /// <term>SendMessage</term>
    /// <description>Реализация метода отправки сообщения через Viber.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class Viber : IMessanger
    {
        /// <summary>
        /// Метод для отправки сообщения в Viber.
        /// </summary>
        public void SendMessage(string fiilename)
        {
            Console.WriteLine("Using Viber to contact a user with a file:" + fiilename);
        }
    }
    /// <summary>
    /// Класс <c>FacebookMessenger</c>,
    /// представляющий уточнение реализации, мессенджер - Facebook Messenger.
    /// <list type="bullet">
    /// <item>
    /// <term>SendMessage</term>
    /// <description>Реализация метода отправки сообщения через Facebook Messenger.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class FacebookMessanger : IMessanger
    {
        /// <summary>
        /// Метод для отправки сообщения в Facebook Messenger.
        /// </summary>
        public void SendMessage(string fiilename)
        {
            Console.WriteLine("Using Facebook Messenger to contact a user with a file:" + fiilename);
        }
    }
    /// <summary>
    /// Класс для входа в программу - Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        static void Main(string[] args)
        {
            string ans_WayOfCom, ans_Messang, message_text;
            try
            {
                while (true)
                {
                    Console.WriteLine("Укажите мессенджер (номер из списка):\n1. VK\n2. Whats App" +
                       "\n3. Facebook Messenger\n4. Viber\n5. Telegram");
                    ans_Messang = Console.ReadLine();
                    Console.WriteLine("Укажите тип сообщения (номер из списка):\n1. Текстовое сообщение\n2. Голосовое сообщение\n3. Звонок");
                    ans_WayOfCom = Console.ReadLine();
                    Console.WriteLine("Введите текст сообщения:");
                    message_text = Console.ReadLine();
                    SendingControl(ans_WayOfCom, ans_Messang, message_text);
                    Console.WriteLine("Отправить другое сообщение? (да/нет)");
                    string ans = Console.ReadLine();
                    if (ans.ToLower() != "да")
                        break;

                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Управление передачей сообщения.
        /// </summary>
        static void SendingControl(string way, string mes, string text)
        {
            WayOfCommunication wayofcomminication;
            IMessanger Messenger;

            switch (mes)
            {
                case "1":
                    Messenger = new VKontakte();
                    break;
                case "2":
                    Messenger = new WhatsApp();
                    break;
                case "3":
                    Messenger = new FacebookMessanger();
                    break;
                case "4":
                    Messenger = new Viber();
                    break;
                case "5":
                    Messenger = new Telegram();
                    break;
                default:
                    throw new Exception("Ошибка при выборе мессенджера.");
            }
            switch (way)
            {
                case "1":
                    wayofcomminication = new TextMessage();
                    break;
                case "2":
                    wayofcomminication = new VoiceMessage();
                    break;
                case "3":
                    wayofcomminication = new Call();
                    break;
                default:
                    throw new Exception("Ошибка при выборе типа сообщения.");
            }
            wayofcomminication.Text = text;
            wayofcomminication.Messenger = Messenger;
            wayofcomminication.Send();
            Console.WriteLine();
        }
    }
}