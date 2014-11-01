using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolModern.Packets.Client.Login
{
    public struct LoginStartPacket : IPacket
    {
        public string Name;

        public byte ID { get { return 0x00; } }

        public IPacket ReadPacket(IMinecraftDataReader reader)
        {
            Name = reader.ReadString();

            return this;
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteString(Name);
            stream.Purge();

            return this;
        }
    }
}