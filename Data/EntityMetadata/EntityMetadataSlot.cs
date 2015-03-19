﻿using MineLib.Network.Data.Structs;
using MineLib.Network.IO;

namespace MineLib.Network.Data.EntityMetadata
{
    /// <summary>
    /// Slot Metadata
    /// </summary>
    public class EntityMetadataSlot : EntityMetadataEntry
    {
        public override byte Identifier => 5;
        public override string FriendlyName => "slot";

        public ItemStack Value;

        public static implicit operator EntityMetadataSlot(ItemStack value)
        {
            return new EntityMetadataSlot(value);
        }

        public EntityMetadataSlot()
        {
        }

        public EntityMetadataSlot(ItemStack value)
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