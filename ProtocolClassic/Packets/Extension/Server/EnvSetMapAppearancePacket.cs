﻿using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolClassic.Packets.Extension.Server
{
    public struct EnvSetMapAppearancePacket : IPacketWithSize
    {
        public string TextureURL;
        public byte SideBlock;
        public byte EdgeBlock;
        public short SideLevel;

        public byte ID { get { return 0x1E; } }
        public short Size { get { return 69; } }

        public IPacketWithSize ReadPacket(IProtocolDataReader stream)
        {
            TextureURL = stream.ReadString();
            SideBlock = stream.ReadByte();
            EdgeBlock = stream.ReadByte();
            SideLevel = stream.ReadShort();

            return this;
        }

        IPacket IPacket.ReadPacket(IProtocolDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteString(TextureURL);
            stream.WriteByte(SideBlock);
            stream.WriteByte(EdgeBlock);
            stream.WriteShort(SideLevel);
            stream.Purge();

            return this;
        }
    }
}
