using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization; // XmlSerializer için gerekli namespace

namespace LAB7
{
    [Serializable] // Bu sınıfın serileştirilebilmesi için
    public enum InOutEnum
    {
        Inbox,
        Outbox,
        Trash
    }

    [Serializable] // Bu sınıfın serileştirilebilmesi için
    public class Mailbox
    {
        public List<Mail> Mails { get; set; } // public yapılmalı
        public int Capacity { get; set; } // public yapılmalı
        public (string, string) Owner { get; set; } // public yapılmalı
        public InOutEnum IOIndicator { get; set; } // public yapılmalı

        public Mailbox((string, string) owner, InOutEnum indicator)
        {
            Mails = new List<Mail>();
            Capacity = 5; // To test capacity
            Owner = owner;
            IOIndicator = indicator;
        }

        public Mailbox() { }

        public virtual void DisplayMailbox()
        {
            Console.WriteLine(IOIndicator + " for " + Owner.Item1 + " <" + Owner.Item2 + ">:");

            if (Mails.Count == 0)
                Console.WriteLine("No mails here!\n");
            else
            {
                for (int i = 0; i < Mails.Count; i++)
                {
                    Console.Write((i + 1) + ") ");
                    Mails[i].DisplayHeader();
                }
            }
        }

        public Mail ReadMail(int selection)
        {
            if (selection >= Mails.Count || selection < 0)
                throw new Exception("Incorrect mail selection!");
            Console.WriteLine(Mails[selection].ToString());
            return Mails[selection];
        }

        public virtual void DeleteMail(int selection)
        {
            Mails.RemoveAt(selection);
        }

        public void ReceiveMail(Mail newMail)
        {
            if (Mails.Count == Capacity)
            {
                throw new ExceededCapacityException(Owner, IOIndicator);
            }
            Mails.Add(newMail);
            Console.WriteLine("Success!");
        }

        public void SortByPriority(int mode)
        {
            // mode: 0 for ascending, 1 for descending
            for (int i = 0; i < Mails.Count; i++)
            {
                int j = i;
                if (mode == 1)
                {
                    while (j > 0 && Mails[j - 1].GetPrio() < Mails[j].GetPrio())
                    {
                        Mail temp = Mails[j - 1];
                        Mails[j - 1] = Mails[j];
                        Mails[j] = temp;
                        j--;
                    }
                }
                else
                {
                    while (j > 0 && Mails[j - 1].GetPrio() > Mails[j].GetPrio())
                    {
                        Mail temp = Mails[j - 1];
                        Mails[j - 1] = Mails[j];
                        Mails[j] = temp;
                        j--;
                    }
                }
            }
        }

        public void SortByDate(int mode)
        {
            // mode: 0 for ascending, 1 for descending
            for (int i = 0; i < Mails.Count; i++)
            {
                int j = i;
                if (mode == 1)
                {
                    while (j > 0 && Mails[j - 1].GetDate() < Mails[j].GetDate())
                    {
                        Mail temp = Mails[j - 1];
                        Mails[j - 1] = Mails[j];
                        Mails[j] = temp;
                        j--;
                    }
                }
                else
                {
                    while (j > 0 && Mails[j - 1].GetDate() > Mails[j].GetDate())
                    {
                        Mail temp = Mails[j - 1];
                        Mails[j - 1] = Mails[j];
                        Mails[j] = temp;
                        j--;
                    }
                }
            }
        }

        public void Sort(int sortBy)
        {
            if (sortBy == 2)
                SortByPriority(0); // ascending
            else if (sortBy == 3)
                SortByPriority(1); // descending
            else if (sortBy == 4)
                SortByDate(0); // ascending
            else
                SortByDate(1); // descending
        }
    }
}
