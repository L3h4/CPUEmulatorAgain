using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.Types;
using Hardware.Exceptions;

namespace Hardware.Devices.CPU
{
    public class Register
    {
        public Data Data { get; set; }
        public string Name { get; private set; }
        public byte Id { get; private set; }
        public Privileges ReadPrivileges { get; private set; }
        public Privileges WritePrivileges { get; private set; }

        private RegisterFile registerFile;

        public Register(string name, byte id, RegisterFile registerFile, Privileges write, Privileges read = Privileges.USER)
        {
            Data = new Data();
            Name = name;
            Id = id;
            ReadPrivileges = read;
            WritePrivileges = write;
            this.registerFile = registerFile;
        }

        private bool ChekRights(Privileges p, Exception e)
        {
            if (registerFile.PRIVILEGES >= p)
                return true;
            else
                throw e;
        }

        public ulong Data64 
        { 
            get 
            {
                ChekRights(ReadPrivileges, new ReadException($"REGISTER {Name}64 READ EXCEPTION"));
                return Data.Data64;
            } 
            set
            {
                ChekRights(WritePrivileges, new WriteException($"REGISTER {Name}64 WRITE EXCEPTION"));
                Data.Data64 = value;
            } 
        }
        public uint Data32
        {
            get
            {
                ChekRights(ReadPrivileges, new ReadException($"REGISTER {Name}32 READ EXCEPTION"));
                return Data.Data32lo;
            }
            set
            {
                ChekRights(WritePrivileges, new WriteException($"REGISTER {Name}32 WRITE EXCEPTION"));
                Data.Data32lo = value;
            }
        }
        public ushort Data16
        {
            get
            {
                ChekRights(ReadPrivileges, new ReadException($"REGISTER {Name}16 READ EXCEPTION"));
                return Data.Data16lolo;
            }
            set
            {
                ChekRights(WritePrivileges, new WriteException($"REGISTER {Name}16 WRITE EXCEPTION"));
                Data.Data16lolo = value;
            }
        }
        public byte Data8
        {
            get
            {
                ChekRights(ReadPrivileges, new ReadException($"REGISTER {Name}8 READ EXCEPTION"));
                return Data.Data8lololo;
            }
            set
            {
                ChekRights(WritePrivileges, new WriteException($"REGISTER {Name}8 WRITE EXCEPTION"));
                Data.Data8lololo = value;
            }
        }



        public static implicit operator ulong(Register value) => value.Data;
        public static implicit operator uint(Register value) => value.Data;
        public static implicit operator ushort(Register value) => value.Data;
        public static implicit operator long(Register value) => value.Data;
        public static implicit operator int(Register value) => value.Data;
        public static implicit operator short(Register value) => value.Data;
        public static implicit operator Data(Register value) => value.Data;

        public override string ToString()
        {
            return $"{Name} = 0x{Data}";
        }
    }
}
