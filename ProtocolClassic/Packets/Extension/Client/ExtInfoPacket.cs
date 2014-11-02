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

        public IPacketWithSize ReadPacket(IProtocolDataReader stream)
        {
            AppName = stream.ReadString();
            ExtensionCount = stream.ReadShort();

            return this;
        }

        IPacket IPacket.ReadPacket(IProtocolDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteString(AppName);
            stream.WriteShort(ExtensionCount);
            stream.Purge();

            return this;
        }
    }
}
