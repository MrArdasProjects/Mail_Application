using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization; // XmlSerializer için gerekli namespace

namespace LAB7
{
    [Serializable] // Bu sınıfın serileştirilebilmesi için
    public enum PriorityEnum
    {
        Low, Normal, High
    }

    [Serializable] // Bu sınıfın serileştirilebilmesi için
    public class Mail
    {
        public DateTime Date { get; set; } // public yapılmalı
        public string Subject { get; set; } // public yapılmalı
        public string Body { get; set; } // public yapılmalı
        public PriorityEnum Prio { get; set; } // public yapılmalı

        public (string, string) Sender { get; set; } // public yapılmalı
        public (string, string) Receiver { get; set; } // public yapılmalı
        public List<(string, string)> CC { get; set; } // public yapılmalı

        public DateTime GetDate() { return Date; }
        public string GetSubject() { return Subject; }
        public string GetBody() { return Body; }
        public PriorityEnum GetPrio() { return Prio; }

        public Mail(DateTime date, (string, string) sender, (string, string) receiver, List<(string, string)> cc, string subject, string body, PriorityEnum prio)
        {
            Date = date;
            Sender = sender;
            Receiver = receiver;
            CC = cc;
            Subject = subject;
            Body = body;
            Prio = prio;
        }

        public Mail () { }

        public override string ToString()
        {
            string finalString = Date.ToShortDateString() + ", " + Date.ToShortTimeString() + "\n";
            finalString += "From: " + Sender.Item1 + " <" + Sender.Item2 + ">\n";
            finalString += "To: " + Receiver.Item1 + " <" + Receiver.Item2 + ">\n";
            finalString += CC.Count > 0 ? "CC: " + CC[0].Item1 + " <" + CC[0].Item2 + ">" : "";
            for (int i = 1; i < CC.Count; i++)
                finalString += ", " + CC[i].Item1 + " <" + CC[i].Item2 + ">\n\n";
            finalString += Prio != PriorityEnum.Normal ? "[Priority: " + Prio + "] " : "";
            finalString += "Subject: " + Subject + "\n\n" + Body;
            return finalString;
        }

        public virtual void DisplayHeader()
        {
            Console.Write(Date.ToString() + " --- ");
            Console.Write(Prio != PriorityEnum.Normal ? "[Priority: " + Prio + "] " : "");
            Console.WriteLine("Subject: " + Subject);
        }
    }
}
