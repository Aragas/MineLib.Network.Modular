﻿using MineLib.Network;
using MineLib.Network.Data;
using MineLib.Network.IO;

namespace ProtocolClassic.Packets.Server
{
    public struct LevelFinalizePacket : IPacketWithSize
    {
        public Position Coordinates;

        public byte ID { get { return 0x04; } }
        public short Size { get { return 7; } }

        public IPacketWithSize ReadPacket(IMinecraftDataReader stream)
        {
            Coordinates.X = stream.ReadShort();
            Coordinates.Y = stream.ReadShort();
            Coordinates.Z = stream.ReadShort();

            return this;
        }

        IPacket IPacket.ReadPacket(IMinecraftDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteShort((short)Coordinates.X);
            stream.WriteShort((short)Coordinates.Y);
            stream.WriteShort((short)Coordinates.Z);
            stream.Purge();

            return this;
        }
    }
}