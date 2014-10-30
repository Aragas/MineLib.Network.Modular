using MineLib.Network;
using MineLib.Network.IO;
using ProtocolModern.Enum;

namespace ProtocolModern.Packets.Client
{
    public struct EntityActionPacket : IPacket
    {
        public int EntityID;
        public EntityAction Action;

        public byte ID { get { return 0x0B; } }

        public IPacket ReadPacket(IMinecraftDataReader reader)
        {
            EntityID = reader.ReadVarInt();
            Action = (EntityAction) reader.ReadByte();

            return this;
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteVarInt(EntityID);
            stream.WriteByte((byte) Action);
            stream.Purge();

            return this;
        }
    }
}