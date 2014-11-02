﻿using MineLib.Network.IO;

namespace MineLib.Network.Data.EntityMetadataEntries
{
    /// <summary>
    /// Slot Metadata
    /// </summary>
    public class MetadataSlot : MetadataEntry
    {
        public override byte Identifier { get { return 5; } }
        public override string FriendlyName { get { return "slot"; } }

        public ItemStack Value;

        public static implicit operator MetadataSlot(ItemStack value)
        {
            return new MetadataSlot(value);
        }

        public MetadataSlot()
        {
        }

        public MetadataSlot(ItemStack value)
        {
            Value = value;
        }

        public override void FromReader(IProtocolDataReader reader)
        {
            Value = ItemStack.FromReader(reader);
        }

        public override void ToStream(IProtocolStream stream, byte index)
        {
            stream.WriteByte(GetKey(index));
            Value.ToStream(stream);
        }
    }
}