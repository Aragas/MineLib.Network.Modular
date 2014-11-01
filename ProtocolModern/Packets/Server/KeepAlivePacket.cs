using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolModern.Packets.Server
{
    public struct KeepAlivePacket : IPacket
    {
        public int KeepAlive;

        public byte ID { get { return 0x00; } }

        public IPacket ReadPacket(IMinecraftDataReader reader)
        {
            KeepAlive = reader.ReadVarInt();

            return this;
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteVarInt(KeepAlive);
            stream.Purge();

            return this;
        }
    }
}