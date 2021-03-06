﻿using System.IO;
using LibWarDB2.Extensions;
using LibWarDB2.Structures;

namespace LibWarDB2
{
    public class WDC3
    {
        /// <summary>
        /// WDC3
        /// </summary>
        public const uint Signature = 860046423;

        public WDC3Header Header { get; set; }
        public WDC3SectionHeader[] SectionHeaders { get; set; }
        public FieldStructure[] Fields { get; set; }
        public FieldStorageInfo[] FieldInfo { get; set; }
        public byte[] PalletData { get; set; }
        public byte[] CommonData { get; set; }
        public Section[] DataSections { get; set; }

        public void Load(string path)
        {
            using (var reader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read)))
            {
                var wdc = reader.ReadWDC3();
                Header = wdc.Header;
                SectionHeaders = wdc.SectionHeaders;
                Fields = wdc.Fields;
                FieldInfo = wdc.FieldInfo;
                PalletData = wdc.PalletData;
                CommonData = wdc.CommonData;
                DataSections = wdc.DataSections;
            }
        }

        public void Save(string path)
        {
            using (var writer = new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write)))
            {
                writer.Write(this);
            }
        }
    }
}
