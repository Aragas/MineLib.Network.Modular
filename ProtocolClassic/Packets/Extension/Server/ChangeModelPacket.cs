﻿using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolClassic.Packets.Extension.Server
{
    public struct ChangeModelPacket : IPacketWithSize
    {
        public byte EntityID;
        public string ModelName;

        public byte ID { get { return 0x1D; } }
        public short Size { get { return 66; } }

        public IPacketWithSize ReadPacket(IProtocolDataReader stream)
        {
            EntityID = stream.ReadByte();
            ModelName = stream.ReadString();

            return this;
        }

        IPacket IPacket.ReadPacket(IProtocolDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteByte(EntityID);
            stream.WriteString(ModelName);
            stream.Purge();

            return this;
        }
    }
}
