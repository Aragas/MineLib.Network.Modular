﻿using MineLib.Network;
using MineLib.Network.Data;
using MineLib.Network.IO;
using ProtocolClassic.Enum;

namespace ProtocolClassic.Packets.Client
{
    public struct SetBlockPacket : IPacketWithSize
    {
        public Position Coordinates;
        public SetBlockMode Mode;
        public byte BlockType;

        public byte ID { get { return 0x05; } }
        public short Size { get { return 9; } }

        public IPacketWithSize ReadPacket(IMinecraftDataReader stream)
        {
            Coordinates.X = stream.ReadShort();
            Coordinates.Y = stream.ReadShort();
            Coordinates.Z = stream.ReadShort();
            Mode = (SetBlockMode) stream.ReadByte();
            BlockType = stream.ReadByte();

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
            stream.WriteByte((byte) Mode);
            stream.WriteByte(BlockType);
            stream.Purge();

            return this;
        }
    }
}
