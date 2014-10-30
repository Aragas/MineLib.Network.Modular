﻿using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolPocketEdition.Packets.Client
{
    public class ReadyPacket : IPacketWithSize
    {
        public byte Status;

        public byte ID { get { return 0x84; } }
        public short Size { get { return 0; } }

        public IPacketWithSize ReadPacket(IMinecraftDataReader reader)
        {
            Status = reader.ReadByte();

            return this;
        }

        IPacket IPacket.ReadPacket(IMinecraftDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteByte(Status);
            stream.Purge();

            return this;
        }
    }
}
