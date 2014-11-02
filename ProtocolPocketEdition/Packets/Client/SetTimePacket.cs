﻿using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolPocketEdition.Packets.Client
{
    public class SetTimePacket : IPacketWithSize
    {
        public int Time;

        public byte ID { get { return 0x82; } }
        public short Size { get { return 0; } }

        public IPacketWithSize ReadPacket(IProtocolDataReader reader)
        {
            Time = reader.ReadInt();

            return this;
        }

        IPacket IPacket.ReadPacket(IProtocolDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteInt(Time);
            stream.Purge();

            return this;
        }
    }
}
