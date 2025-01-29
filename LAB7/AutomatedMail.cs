using System;
using System.Collections.Generic;
using System.Text;

namespace LAB7
{
    enum AutomatedTypeEnum
    {
        Batch,
        Fail
    }

    class AutomatedMail : Mail
    {
        private AutomatedTypeEnum Type { get; set; }

        public AutomatedMail (DateTime date, (String, String) receiver, List<(String, String)> cc, String subject, String body, AutomatedTypeEnum type)
                : base(date, ("Automated mail", "auto"), receiver, cc, subject, body, PriorityEnum.Normal)
        {
            Type = type;
        }

        public override string ToString()
        {
            return "[" + Type + " - Automated Mail] " + base.ToString();
        }

        public override void DisplayHeader()
        {
            Console.Write("[" + Type + "-Auto] ");
            base.DisplayHeader();
        }
    }
}
