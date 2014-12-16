﻿using MineLib.Network.Data;
using MineLib.Network.Data.Anvil;
using MineLib.Network.Data.Structs;

namespace MineLib.Network
{
    public interface IAsyncReceive { }

    public struct OnChatMessage : IAsyncReceive
    {
        public string Message { get; set; }

        public OnChatMessage(string message): this()
        {
            Message = message;
        }
    }

    #region Anvil

    public struct OnChunk : IAsyncReceive
    {
        public Chunk Chunk { get; set; }

        public OnChunk(Chunk chunk) : this()
        {
            Chunk = chunk;
        }
    }

    public struct OnChunkList : IAsyncReceive
    {
        public ChunkList Chunks { get; set; }

        public OnChunkList(ChunkList chunks) : this()
        {
            Chunks = chunks;
        }
    }

    public struct OnBlockChange : IAsyncReceive
    {
        public Position Location { get; set; }
        public int Block { get; set; }

        public OnBlockChange(Position location, int block) : this()
        {
            Location = location;
            Block = block;
        }
    }

    public struct OnMultiBlockChange : IAsyncReceive
    {
        public Coordinates2D ChunkLocation { get; set; }
        public Record[] Records { get; set; }

        public OnMultiBlockChange(Coordinates2D chunkLocation, Record[] records) : this()
        {
            ChunkLocation = chunkLocation;
            Records = records;
        }
    }

    public struct OnBlockAction : IAsyncReceive
    {
        public Position Location { get; set; }
        public int Block { get; set; }
        public object BlockAction { get; set; }

        public OnBlockAction(Position location, int block, object blockAction) : this()
        {
            Location = location;
            Block = block;
            BlockAction = blockAction;
        }
    }

    public struct OnBlockBreakAction : IAsyncReceive
    {
        public int EntityID { get; set; }
        public Position Location { get; set; }
        public byte Stage { get; set; }

        public OnBlockBreakAction(int entityID, Position location, byte stage) : this()
        {
            EntityID = entityID;
            Location = location;
            Stage = stage;
        }
    }

    #endregion

    public struct OnPlayerPosition : IAsyncReceive
    {
        public Vector3 Position { get; set; }

        public OnPlayerPosition(Vector3 position): this()
        {
            Position = position;
        }
    }

    public struct OnPlayerLook : IAsyncReceive
    {
        public Vector3 Look { get; set; }

        public OnPlayerLook(Vector3 look): this()
        {
            Look = look;
        }
    }

    public struct OnHeldItemChange : IAsyncReceive
    {
        public byte Slot { get; set; }

        public OnHeldItemChange(byte slot): this()
        {
            Slot = slot;
        }
    }

    public struct OnSpawnPoint : IAsyncReceive
    {
        public Position Location { get; set; }

        public OnSpawnPoint(Position location): this()
        {
            Location = location;
        }
    }

    public struct OnUpdateHealth : IAsyncReceive
    {
        public float Health { get; set; }
        public int Food { get; set; }
        public float FoodSaturation { get; set; }

        public OnUpdateHealth(float health, int food, float foodSaturation): this()
        {
            Health = health;
            Food = food;
            FoodSaturation = foodSaturation;
        }
    }

    public struct OnRespawn : IAsyncReceive
    {
        public object GameInfo { get; set; }

        public OnRespawn(object gameInfo): this()
        {
            GameInfo = gameInfo;
        }
    }

    public struct OnAction : IAsyncReceive
    {
        public int EntityID { get; set; }
        public int Action { get; set; }

        public OnAction(int entityID, int action): this()
        {
            EntityID = entityID;
            Action = action;
        }
    }
    
    public struct OnSetExperience : IAsyncReceive
    {
        public float ExperienceBar { get; set; }
        public int Level { get; set; }
        public int TotalExperience { get; set; }

        public OnSetExperience(float experienceBar, int level, int totalExperience): this()
        {
            ExperienceBar = experienceBar;
            Level = level;
            TotalExperience = totalExperience;
        }
    }
    
}
