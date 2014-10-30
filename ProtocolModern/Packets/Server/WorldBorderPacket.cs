﻿using MineLib.Network;
using MineLib.Network.IO;
using ProtocolModern.Enum;

namespace ProtocolModern.Packets.Server
{
    public interface IWorldBorder
    {
        IWorldBorder FromReader(IMinecraftDataReader reader);
        void ToStream(ref IMinecraftStream stream);
    }

    public struct WorldBorderSetSize : IWorldBorder
    {
        public double Radius;
        
        public IWorldBorder FromReader(IMinecraftDataReader reader)
        {
            Radius = reader.ReadDouble();

            return this;
        }

        public void ToStream(ref IMinecraftStream stream)
        {
            stream.WriteDouble(Radius);
        }
    }

    public struct WorldBorderLerpSize : IWorldBorder
    {
        public double OldRadius;
        public double NewRadius;
        public long Speed;

        public IWorldBorder FromReader(IMinecraftDataReader reader)
        {
            OldRadius = reader.ReadDouble();
            NewRadius = reader.ReadDouble();
            //Speed = stream.ReadVarLong(); TODO: VarLong

            return this;
        }

        public void ToStream(ref IMinecraftStream stream)
        {
            stream.WriteDouble(OldRadius);
            stream.WriteDouble(NewRadius);
            //stream.WriteVarLong(Speed); TODO: VarLong
        }
    }

    public struct WorldBorderSetCenter : IWorldBorder
    {
        public double X, Z;

        public IWorldBorder FromReader(IMinecraftDataReader reader)
        {
            X = reader.ReadDouble();
            Z = reader.ReadDouble();

            return this;
        }

        public void ToStream(ref IMinecraftStream stream)
        {
            stream.WriteDouble(X);
            stream.WriteDouble(Z);
        }
    }

    public struct WorldBorderInitialize : IWorldBorder
    {
        public double X, Z;
        public double OldRadius;
        public double NewRadius;
        public long Speed;
        public int PortalTeleportBoundary;
        public int WarningTime;
        public int WarningBlocks;

        public IWorldBorder FromReader(IMinecraftDataReader reader)
        {
            X = reader.ReadDouble();
            Z = reader.ReadDouble();

            OldRadius = reader.ReadDouble();
            NewRadius = reader.ReadDouble();
            //Speed = stream.ReadVarLong(); TODO: VarLong
            PortalTeleportBoundary = reader.ReadVarInt();
            WarningTime = reader.ReadVarInt();
            WarningBlocks = reader.ReadVarInt();

            return this;
        }

        public void ToStream(ref IMinecraftStream stream)
        {
            stream.WriteDouble(X);
            stream.WriteDouble(Z);

            stream.WriteDouble(OldRadius);
            stream.WriteDouble(NewRadius);
            //stream.WriteVarLong(Speed); TODO: VarLong
            stream.WriteVarInt(PortalTeleportBoundary);
            stream.WriteVarInt(WarningTime);
            stream.WriteVarInt(WarningBlocks);
        }
    }

    public struct WorldBorderSetWarningTime : IWorldBorder
    {
        public int WarningTime;

        public IWorldBorder FromReader(IMinecraftDataReader reader)
        {
            WarningTime = reader.ReadVarInt();

            return this;
        }

        public void ToStream(ref IMinecraftStream stream)
        {
            stream.WriteVarInt(WarningTime);
        }
    }

    public struct WorldBorderSetWarningBlocks : IWorldBorder
    {
        public int WarningBlocks;

        public IWorldBorder FromReader(IMinecraftDataReader reader)
        {
            WarningBlocks = reader.ReadVarInt();

            return this;
        }

        public void ToStream(ref IMinecraftStream stream)
        {
            stream.WriteVarInt(WarningBlocks);
        }
    }

    public struct WorldBorderPacket : IPacket
    {
        public WorldBorderAction Action;

        public IWorldBorder WorldBorder;

        public byte ID { get { return 0x44; } }

        public IPacket ReadPacket(IMinecraftDataReader reader)
        {
            Action = (WorldBorderAction) reader.ReadVarInt();

            switch (Action)
            {
                case WorldBorderAction.SetSize:
                    WorldBorder = new WorldBorderSetSize().FromReader(reader);
                    break;
                case WorldBorderAction.LerpSize:
                    WorldBorder = new WorldBorderLerpSize().FromReader(reader);
                    break;
                case WorldBorderAction.SetCenter:
                    WorldBorder = new WorldBorderSetCenter().FromReader(reader);
                    break;
                case WorldBorderAction.Initialize:
                    WorldBorder = new WorldBorderInitialize().FromReader(reader);
                    break;
                case WorldBorderAction.SetWarningTime:
                    WorldBorder = new WorldBorderSetWarningTime().FromReader(reader);
                    break;
                case WorldBorderAction.SetWarningBlocks:
                    WorldBorder = new WorldBorderSetWarningBlocks().FromReader(reader);
                    break;
            }

            return this;
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteVarInt((byte) Action);
            WorldBorder.ToStream(ref stream);
            stream.Purge();

            return this;
        }
    }
}
