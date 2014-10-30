﻿using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolClassic.Packets.Extension.Client
{
    public struct ExtInfoPacket : IPacketWithSize
    {
        public string AppName;
        public short ExtensionCount;

        public byte ID { get { return 0x10; } }
        public short Size { get { return 67; } }

        public IPacketWithSize ReadPacket(IMinecraftDataReader stream)
        {
            AppName = stream.ReadString();
            ExtensionCount = stream.ReadShort();

            return this;
        }

        IPacket IPacket.ReadPacket(IMinecraftDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteString(AppName);
            stream.WriteShort(ExtensionCount);
            stream.Purge();

            return this;
        }
    }
}
