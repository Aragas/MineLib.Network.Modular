﻿using MineLib.Network;
using MineLib.Network.IO;
using ProtocolClassic.Enum;

namespace ProtocolClassic.Packets.Extension.Server
{
    public struct HoldThisPacket : IPacketWithSize
    {
        public byte BlockToHold;
        public PreventChange PreventChange;

        public byte ID { get { return 0x14; } }
        public short Size { get { return 3; } }

        public IPacketWithSize ReadPacket(IMinecraftDataReader stream)
        {
            BlockToHold = stream.ReadByte();
            PreventChange = (PreventChange) stream.ReadByte();

            return this;
        }

        IPacket IPacket.ReadPacket(IMinecraftDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteByte(BlockToHold);
            stream.WriteByte((byte) PreventChange);
            stream.Purge();

            return this;
        }
    }
}
