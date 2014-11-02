﻿using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolClassic.Packets.Client
{
    public struct PlayerIdentificationPacket : IPacketWithSize
    {
        public byte ProtocolVersion;
        public string Username;
        public string VerificationKey;
        public byte UnUsed;

        public byte ID { get { return 0x00; } }
        public short Size { get { return 131; } }

        public IPacketWithSize ReadPacket(IProtocolDataReader stream)
        {
            ProtocolVersion = stream.ReadByte();
            Username = stream.ReadString();
            VerificationKey = stream.ReadString();
            UnUsed = stream.ReadByte();

            return this;
        }

        IPacket IPacket.ReadPacket(IProtocolDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteByte(ProtocolVersion);
            stream.WriteString(Username);
            stream.WriteString(VerificationKey);
            stream.WriteByte(UnUsed);
            stream.Purge();

            return this;
        }
    }
}
