using MineLib.Network.IO;

namespace MineLib.Network.Data.EntityMetadata
{
    /// <summary>
    /// Int32 Metadata
    /// </summary>
    public class EntityMetadataInt : EntityMetadataEntry
    {
        public override byte Identifier => 2;
        public override string FriendlyName => "int";

        public int Value;

        public static implicit operator EntityMetadataInt(int value)
        {
            return new EntityMetadataInt(value);
        }

        public EntityMetadataInt()
        {
        }

        public EntityMetadataInt(int value)
        {
            Value = value;
        }

        public override void FromReader(IProtocolDataReader reader)
        {
            Value = reader.ReadInt();
        }

        public override void ToStream(IProtocolStream stream, byte index)
        {
            stream.WriteByte(GetKey(index));
            stream.WriteInt(Value);
        }
    }
}