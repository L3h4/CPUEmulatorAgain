using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Types
{
    public enum DataSize
    {
        NONE,
        BYTE,
        WORD,
        DWORD,
        QWORD,
        OTHER
    }
    public enum DataType
    {
        NONE,
        DATA,
        SUB_PART,

        NUMBER,
        UNUMBER,
        FLOAT,

        ADDRESS,
        POINTER,

        INSTRUCTION,
        ARGUMENT,
        REGISTER
    }
    public enum RequestMethod
    {
        READ,
        READ_MANY,
        WRITE,
        WRITE_MANY,
        CALL,
        FAR_CALL,
    }
    public enum RequestType
    {
        DATA,
        DATA_SUB_PART,
        INSTRUCTION,
        INSTRUCTION_ARG,
    }
    public enum Privileges
    {
        USER,
        SUPERUSER,
        DRIVER,
        KERNEL,
    }
}
