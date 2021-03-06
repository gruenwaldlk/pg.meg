﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.meg.test")]

namespace pg.meg.typedef
{
    internal sealed class MegFileContentTable : IBinaryFile, ISizeable
    {
        private readonly List<MegFileContentTableRecord> _megFileContentTableRecords;
        
        public MegFileContentTable(List<MegFileContentTableRecord> megFileContentTableRecords)
        {
            _megFileContentTableRecords = megFileContentTableRecords;
        }

        public List<MegFileContentTableRecord> MegFileContentTableRecords => _megFileContentTableRecords;

        public byte[] GetBytes()
        {
            List<byte> b = new List<byte>();
            foreach (MegFileContentTableRecord megFileContentTableRecord in _megFileContentTableRecords)
            {
                b.AddRange(megFileContentTableRecord.GetBytes());
            }
            return b.ToArray();
        }

        public uint Size()
        {
            uint size = 0;
            foreach (MegFileContentTableRecord megFileContentTableRecord in _megFileContentTableRecords)
            {
                size = size + megFileContentTableRecord.Size();
            }
            return size;
        }
    }
}
