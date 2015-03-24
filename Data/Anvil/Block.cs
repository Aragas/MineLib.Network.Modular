﻿using System;
using System.Runtime.InteropServices;

namespace MineLib.Network.Data.Anvil
{
    // -- Full  - 3 bytes.
    // -- Empty - 3 bytes.
    // -- Performace cost isn't too high. We are handling maximum 1kk, loose ~5 ms, but win 10mb.
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Block : IEquatable<Block>
    {
        private readonly ushort IDMeta;
        private byte SkyAndBlockLight;

        public int ID => IDMeta >> 5;
        public int Meta => IDMeta & 0x000F;

        public byte SkyLight
        {
            get { return (byte) (SkyAndBlockLight >> 4); }
            set { SkyAndBlockLight = (byte) (value << 4 & 0xF0 | Light & 0x0F); }
        }
        public byte Light
        {
            get { return (byte) (SkyAndBlockLight & 0xF); }
            set { SkyAndBlockLight = (byte) (SkyLight << 4 & 0xF0 | value & 0x0F); }
        }

        public bool IsActive
        {
            get { return (bool) (IDMeta << 4 & 0x8); }
            set { IDMeta = (ushort) (IDMeta & 0xFFEF | (byte) value >> 11); }
       }

        public Block(ushort id)
        {
            IDMeta = (ushort) (id << 5 & 0xFFE0 | 0 & 0x000F);
            SkyAndBlockLight = 0;
        }

        public Block(ushort id, byte meta)
        {
            IDMeta = (ushort) (id << 5 & 0xFFE0 | meta & 0x000F);
            SkyAndBlockLight = 0;
        }

        public Block(ushort id, byte meta, byte light)
        {
            IDMeta = (ushort) (id << 5 & 0xFFE0 | meta & 0x000F);
            SkyAndBlockLight = (byte) (0 << 4 & 0xF0 | light & 0x0F);
        }

        public Block(ushort id, byte meta, byte light, byte skyLight)
        {
            IDMeta = (ushort) (id << 5 & 0xFFE0 | meta & 0x000F);
            SkyAndBlockLight = (byte) (skyLight << 4 & 0xF0 | light & 0x0F);
        }

        public override string ToString()
        {
            return String.Format("ID: {0}, Meta: {1}, Light: {2}, SkyLight: {3}", ID, Meta, Light, SkyLight);
        }

        public static bool operator ==(Block a, Block b)
        {
            return a.IDMeta == b.IDMeta && a.SkyAndBlockLight == b.SkyAndBlockLight;
        }

        public static bool operator !=(Block a, Block b)
        {
            return a.IDMeta != b.IDMeta && a.SkyAndBlockLight != b.SkyAndBlockLight;
        }

        public bool Equals(Block other)
        {
            return other.IDMeta.Equals(IDMeta);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Block))
                return false;

            return Equals((Block) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = IDMeta.GetHashCode();
                return result;
            }
        }
    }
}
