﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using pg.util.interfaces;
[assembly: InternalsVisibleTo("pg.meg.test")]

namespace pg.meg.typedef
{
    internal sealed class MegFile : IBinaryFile
    {
        private readonly MegHeader _header;
        private readonly MegFileNameTable _fileNameTable;
        private readonly MegFileContentTable _megFileContentTable;

        internal List<string> Files { get; set; }

        internal MegFile(MegHeader header, MegFileNameTable fileNameTable, MegFileContentTable megFileContentTable)
        {
            _header = header;
            _fileNameTable = fileNameTable;
            _megFileContentTable = megFileContentTable;
        }

        public byte[] GetBytes()
        {
            List<byte> b = new List<byte>();
            b.AddRange(_header.GetBytes());
            b.AddRange(_fileNameTable.GetBytes());
            b.AddRange(_megFileContentTable.GetBytes());
            return b.ToArray();
        }

        public MegFileContentTable ContentTable => _megFileContentTable ?? new MegFileContentTable(new List<MegFileContentTableRecord>());
        public MegFileNameTable FileNameTable => _fileNameTable ?? new MegFileNameTable(new List<MegFileNameTableRecord>());

        internal string LookupFileNameByIndex(int i)
        {
            return _fileNameTable.MegFileNameTableRecords[i].FileName;
        }
    }
}
