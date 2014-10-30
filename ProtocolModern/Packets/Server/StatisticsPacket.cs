﻿using MineLib.Network;
using MineLib.Network.Data;
using MineLib.Network.IO;

namespace ProtocolModern.Packets.Server
{
    public struct StatisticsPacket : IPacket
    {
        public StatisticsEntryList StatisticsEntryList;

        public byte ID { get { return 0x37; } }

        public IPacket ReadPacket(IMinecraftDataReader reader)
        {
            StatisticsEntryList = StatisticsEntryList.FromReader(reader);

            return this;
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteVarInt(ID);
            StatisticsEntryList.ToStream(stream);
            stream.Purge();

            return this;
        }
    }
}