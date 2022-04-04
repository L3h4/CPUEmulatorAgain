using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hardware.Types;

namespace Hardware.Devices.CPU
{
    public class RegisterFile
    {
        private Dictionary<string, Register> registers;

        public Register A { get => registers["A"]; }
        public Register B { get => registers["B"]; }
        public Register C { get => registers["C"]; }
        public Register D { get => registers["D"]; }
        public Register E { get => registers["E"]; }
        public Register F { get => registers["F"]; }

        public Register IP { get => registers["IP"]; }
        public Register SP { get => registers["SP"]; }
        public Register IDT { get => registers["IDT"]; }
        public Register GDT { get => registers["GDT"]; }
        public Register STATUS { get => registers["STATUS"]; }

        public Register SEGMENTS1 { get => registers["S1"]; }
        public Register SEGMENTS2 { get => registers["S2"]; }
        public Register SEGMENTS3 { get => registers["S3"]; }

        public byte CORENUMBER { get; private set; }
        
        public Privileges PRIVILEGES { get; set;}

        public RegisterFile(byte coreNumber)
        {
            PRIVILEGES = Privileges.KERNEL;
            CORENUMBER = coreNumber;
            registers = new Dictionary<string, Register>()
            {
               { "A", new Register("A", 1, this, Privileges.USER) },
               { "B", new Register("B", 2, this, Privileges.USER) },
               { "C", new Register("C", 3, this, Privileges.USER) },
               { "D", new Register("D", 4, this, Privileges.USER) },
               { "E", new Register("E", 5, this, Privileges.USER) },
               { "F", new Register("F", 6, this, Privileges.USER) },

               { "IP", new Register("IP", 7, this, Privileges.KERNEL) },
               { "SP", new Register("SP", 8, this, Privileges.KERNEL) },

               { "IDT", new Register("IDT", 9, this, Privileges.KERNEL) },
               { "GDT", new Register("GDT", 10, this, Privileges.KERNEL) },
               { "STATUS", new Register("STATUS", 11, this, Privileges.USER) },

               { "S1", new Register("S1", 12, this, Privileges.KERNEL) },
               { "S2", new Register("S2", 13, this, Privileges.KERNEL) },
               { "S3", new Register("S3", 14, this, Privileges.KERNEL) },
            };
        }
    }
}
