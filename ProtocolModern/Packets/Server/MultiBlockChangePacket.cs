using MineLib.Network;
using MineLib.Network.Data;
using MineLib.Network.IO;

namespace ProtocolModern.Packets.Server
{
    public struct MultiBlockChangePacket : IPacket
    {
        public Coordinates2D Coordinates; // TODO: Add FromReader() ?
        public RecordList RecordList;

        public byte ID { get { return 0x22; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            Coordinates.X = reader.ReadInt();
            Coordinates.Z = reader.ReadInt();
            RecordList = RecordList.FromReader(reader);

            return this;
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteInt(Coordinates.X);
            stream.WriteInt(Coordinates.Z);
            RecordList.ToStream(stream);
            stream.Purge();

            return this;
        }
    }
}