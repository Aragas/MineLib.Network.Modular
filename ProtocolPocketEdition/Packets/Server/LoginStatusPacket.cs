﻿using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolPocketEdition.Packets.Server
{
    public class LoginStatusPacket : IPacketWithSize
    {
        public int Status;

        public byte ID { get { return 0x83; } }
        public short Size { get { return 0; } }

        public IPacketWithSize ReadPacket(IProtocolDataReader reader)
        {
            Status = reader.ReadInt();

            return this;
        }

        IPacket IPacket.ReadPacket(IProtocolDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteInt(Status);
            stream.Purge();

            return this;
        }
    }
}
