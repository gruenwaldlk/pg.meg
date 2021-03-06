﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.meg.test")]

namespace pg.meg.typedef
{
    internal sealed class MegFileNameTable : IBinaryFile, ISizeable
    {
        private readonly List<MegFileNameTableRecord> _megFileNameTableRecords;

        public MegFileNameTable(List<MegFileNameTableRecord> megFileNameTableRecords)
        {
            _megFileNameTableRecords = megFileNameTableRecords;
        }

        public List<MegFileNameTableRecord> MegFileNameTableRecords => _megFileNameTableRecords;

        public byte[] GetBytes()
        {
            List<byte> b = new List<byte>();
            foreach (MegFileNameTableRecord megFileNameTableRecord in _megFileNameTableRecords)
            {
                b.AddRange(megFileNameTableRecord.GetBytes());
            }
            return b.ToArray();
        }

        public uint Size()
        {
            uint size = 0;

            foreach (MegFileNameTableRecord megFileNameTableRecord in _megFileNameTableRecords)
            {
                size = size + megFileNameTableRecord.Size();
            }

            return size;
        }
    }
}
