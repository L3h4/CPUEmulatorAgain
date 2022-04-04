using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.Types
{
    public class Data
    {

        public virtual DataType Type { get; set; }
        public virtual DataSize Size { get; set; }

        public uint NextPart { get; set; }

        private byte[] Bytes;
        public ulong Data64 { 
            get 
            {
                ulong res = 0;
                for (int i = 0, j = 7; i < 64; i+=8, j--)
                    res += (ulong)Bytes[j] << i;

                return res;
            }
            set 
            {
                for (int i = 0, j = 7; i < 64; i += 8, j--)
                    Bytes[j] = (byte)(value >> i);

            } 
        }
        public uint Data32hi
        {
            get
            {
                uint res = 0;
                for (int i = 0, j = 3; i < 32; i += 8, j--)
                    res += (uint)Bytes[j] << i;

                return res;
            }
            set
            {
                for (int i = 0, j = 3; i < 32; i += 8, j--)
                    Bytes[j] = (byte)(value >> i);
            }
        }
        public uint Data32lo
        {
            get
            {
                uint res = 0;
                for (int i = 0, j = 7; i < 32; i += 8, j--)
                    res += (uint)Bytes[j] << i;

                return res;
            }
            set
            {
                for (int i = 0, j = 7; i < 32; i += 8, j--)
                    Bytes[j] = (byte)(value >> i);
            }
        }
        public ushort Data16hihi
        {
            get
            {
                ushort res = 0;
                for (int i = 0, j = 1; i < 16; i += 8, j--)
                    res += Convert.ToUInt16((uint)Bytes[j] << i);

                return res;
            }
            set
            {
                for (int i = 0, j = 1; i < 16; i += 8, j--)
                    Bytes[j] = (byte)(value >> i);
            }
        }
        public ushort Data16hilo
        {
            get
            {
                ushort res = 0;
                for (int i = 0, j = 3; i < 16; i += 8, j--)
                    res += Convert.ToUInt16((uint)Bytes[j] << i);

                return res;
            }
            set
            {
                for (int i = 0, j = 3; i < 16; i += 8, j--)
                    Bytes[j] = (byte)(value >> i);
            }
        }
        public ushort Data16lohi
        {
            get
            {
                ushort res = 0;
                for (int i = 0, j = 5; i < 16; i += 8, j--)
                    res += Convert.ToUInt16((uint)Bytes[j] << i);

                return res;
            }
            set
            {
                for (int i = 0, j = 5; i < 16; i += 8, j--)
                    Bytes[j] = (byte)(value >> i);
            }
        }
        public ushort Data16lolo
        {
            get
            {
                ushort res = 0;
                for (int i = 0, j = 7; i < 16; i += 8, j--)
                    res += Convert.ToUInt16((uint)Bytes[j] << i);

                return res;
            }
            set
            {
                for (int i = 0, j = 7; i < 16; i += 8, j--)
                    Bytes[j] = (byte)(value >> i);
            }
        }

        public byte Data8hihihi { get => Bytes[0]; set => Bytes[0] = value; }
        public byte Data8hihilo { get => Bytes[1]; set => Bytes[1] = value; }
        public byte Data8hilohi { get => Bytes[2]; set => Bytes[2] = value; }
        public byte Data8hilolo { get => Bytes[3]; set => Bytes[3] = value; }
        public byte Data8lohihi { get => Bytes[4]; set => Bytes[4] = value; }
        public byte Data8lohilo { get => Bytes[5]; set => Bytes[5] = value; }
        public byte Data8lolohi { get => Bytes[6]; set => Bytes[6] = value; }
        public byte Data8lololo { get => Bytes[7]; set => Bytes[7] = value; }

        public Data(DataType type, DataSize size)
        {
            Bytes = new byte[8];
            Type = type;
            Size = size;
        }
        public Data(): this(DataType.NONE, DataSize.NONE)
        {
        }

        public Data(DataType type, DataSize size, ulong data): this(type, size)
        {
            Data64 = data;
        }
        public Data(DataType type, DataSize size, uint data) : this(type, size)
        {
            Data32lo = data;
        }
        public Data(DataType type, DataSize size, ushort data) : this(type, size)
        {
            Data16lolo = data;
        }
        public Data(DataType type, DataSize size, byte data) : this(type, size)
        {
            Bytes[7] = data;
        }

        public override string ToString()
        {
            return $"{Data16hihi:X4} {Data16hilo:X4} {Data16lohi:X4} {Data16lolo:X4}";
        }

        // public static explicit operator Data(ulong value) => new Data(DataType.UNUMBER, DataSize.QWORD, value);
        // public static explicit operator Data(uint value) => new Data(DataType.UNUMBER, DataSize.DWORD, value);
        // public static explicit operator Data(ushort value) => new Data(DataType.UNUMBER, DataSize.BYTE, value);

        public static implicit operator ulong(Data value) => value.Data64;
        public static implicit operator uint(Data value) => value.Data32lo;
        public static implicit operator ushort(Data value) => value.Data16lolo;
        public static implicit operator long(Data value) => (long)value.Data64;
        public static implicit operator int(Data value) => (int)value.Data32lo;
        public static implicit operator short(Data value) => (short)value.Data16lolo;
    }
}
