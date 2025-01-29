using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization; // XmlSerializer için gerekli namespace

namespace LAB7
{
    [Serializable] // Bu sınıfın serileştirilebilmesi için
    public class Trash : Mailbox
    {
        public List<InOutEnum> InitialLocations { get; set; } // public yapılmalı

        public Trash((string, string) owner) : base(owner, InOutEnum.Trash)
        {
            InitialLocations = new List<InOutEnum>();
        }

        public Trash () { }

        public InOutEnum GetLocation(int index)
        {
            return InitialLocations[index];
        }

        public override void DeleteMail(int index)
        {
            base.DeleteMail(index);
            InitialLocations.RemoveAt(index);
        }

        public void AddMail(Mail deletedMail, InOutEnum prevLoc)
        {
            ReceiveMail(deletedMail);
            InitialLocations.Add(prevLoc);
        }

        public override void DisplayMailbox()
        {
            if (Mails.Count == 0)
                Console.WriteLine("No mails here!");
            else
            {
                for (int i = 0; i < Mails.Count; i++)
                {
                    Console.Write("[" + (InitialLocations[i] == InOutEnum.Inbox ? "Inbox" : "Outbox") + "] " + (i + 1) + ") ");
                    Mails[i].DisplayHeader();
                }
            }
        }
    }
}
