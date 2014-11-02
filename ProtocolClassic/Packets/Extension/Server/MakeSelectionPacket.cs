﻿using MineLib.Network;
using MineLib.Network.IO;

namespace ProtocolClassic.Packets.Extension.Server
{
    public struct MakeSelectionPacket : IPacketWithSize
    {
        public byte SelectionID;
        public string Label;
        public short StartX;
        public short StartY;
        public short StartZ;
        public short EndX;
        public short EndY;
        public short EndZ;
        public short Red;
        public short Green;
        public short Blue;
        public short Opacity;

        public byte ID { get { return 0x1A; } }
        public short Size { get { return 86; } }

        public IPacketWithSize ReadPacket(IProtocolDataReader stream)
        {
            SelectionID = stream.ReadByte();
            Label = stream.ReadString();
            StartX = stream.ReadShort();
            StartY = stream.ReadShort();
            StartZ = stream.ReadShort();
            EndX = stream.ReadShort();
            EndY = stream.ReadShort();
            EndZ = stream.ReadShort();
            Red = stream.ReadShort();
            Green = stream.ReadShort();
            Blue = stream.ReadShort();
            Opacity = stream.ReadShort();

            return this;
        }

        IPacket IPacket.ReadPacket(IProtocolDataReader stream)
        {
            return ReadPacket(stream);
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteByte(SelectionID);
            stream.WriteString(Label);
            stream.WriteShort(StartX);
            stream.WriteShort(StartY);
            stream.WriteShort(StartZ);
            stream.WriteShort(EndX);
            stream.WriteShort(EndY);
            stream.WriteShort(EndZ);
            stream.WriteShort(Red);
            stream.WriteShort(Green);
            stream.WriteShort(Blue);
            stream.WriteShort(Opacity);
            stream.Purge();

            return this;
        }
    }
}
