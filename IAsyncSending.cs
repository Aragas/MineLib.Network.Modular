﻿using System;
using MineLib.Network.Data.Structs;

namespace MineLib.Network
{
    public interface IAsyncSending { }

    public interface IAsyncSendingParameters
    {
        AsyncCallback AsyncCallback { get; set; } 
        Object State { get; set; }
    }

    public struct BeginConnectToServer : IAsyncSending { }
    public struct BeginConnectToServerParameters : IAsyncSendingParameters 
    {
        public AsyncCallback AsyncCallback { get; set; }
        public object State { get; set; }

        public BeginConnectToServerParameters(AsyncCallback asyncCallback, object state) : this()
        {
            AsyncCallback = asyncCallback;
            State = state;
        }
    }

    public struct BeginKeepAlive : IAsyncSending { }
    public struct BeginKeepAliveParameters : IAsyncSendingParameters
    {
        public int KeepAlive { get; set; }

        public AsyncCallback AsyncCallback { get; set; }
        public object State { get; set; }

        public BeginKeepAliveParameters(int value, AsyncCallback asyncCallback, object state) : this()
        {
            KeepAlive = value;

            AsyncCallback = asyncCallback;
            State = state;
        }
    }

    public struct BeginSendClientInfo : IAsyncSending { }
    public struct BeginSendClientInfoParameters : IAsyncSendingParameters
    {
        public AsyncCallback AsyncCallback { get; set; }
        public object State { get; set; }

        public BeginSendClientInfoParameters(AsyncCallback asyncCallback, object state) : this()
        {
            AsyncCallback = asyncCallback;
            State = state;
        }
    }

    public struct BeginRespawn : IAsyncSending { }
    public struct BeginRespawnParameters : IAsyncSendingParameters
    {
        public AsyncCallback AsyncCallback { get; set; }
        public object State { get; set; }

        public BeginRespawnParameters(AsyncCallback asyncCallback, object state) : this()
        {
            AsyncCallback = asyncCallback;
            State = state;
        }
    }

    public struct BeginPlayerMoved : IAsyncSending { }
    public struct BeginPlayerMovedParameters : IAsyncSendingParameters
    {
        public AsyncCallback AsyncCallback { get; set; }
        public object State { get; set; }

        public PlaverMovedMode Mode { get; set; }
        public IPlaverMovedData Data { get; set; }

        public BeginPlayerMovedParameters(IPlaverMovedData data, AsyncCallback asyncCallback, object state) : this()
        {
            {
                var type = data as PlaverMovedDataOnGround;
                if (type != null)
                    Mode = PlaverMovedMode.OnGround;
            }

            {
                var type = data as PlaverMovedDataVector3;
                if (type != null)
                    Mode = PlaverMovedMode.Vector3;
            }

            {
                var type = data as PlaverMovedDataYawPitch;
                if (type != null)
                    Mode = PlaverMovedMode.YawPitch;
            }

            {
                var type = data as PlaverMovedDataAll;
                if (type != null)
                    Mode = PlaverMovedMode.All;
            }

            Data = data;

            AsyncCallback = asyncCallback;
            State = state;
        }

        public BeginPlayerMovedParameters(PlaverMovedMode mode, IPlaverMovedData data, AsyncCallback asyncCallback, object state): this()
        {
            Mode = mode;

            Data = data;

            AsyncCallback = asyncCallback;
            State = state;
        }
    }

    public struct BeginPlayerSetRemoveBlock : IAsyncSending { }
    public struct BeginPlayerSetRemoveBlockParameters : IAsyncSendingParameters
    {
        public AsyncCallback AsyncCallback { get; set; }
        public object State { get; set; }

        public PlayerSetRemoveBlockMode Mode { get; set; }
        public IPlayerSetRemoveBlockData Data { get; set; }

        public BeginPlayerSetRemoveBlockParameters(IPlayerSetRemoveBlockData data, AsyncCallback asyncCallback, object state) : this()
        {
            {
                var type = data as PlayerSetRemoveBlockDataDig;
                if (type != null)
                    Mode = PlayerSetRemoveBlockMode.Dig;
            }

            {
                var type = data as PlayerSetRemoveBlockDataPlace;
                if (type != null)
                    Mode = PlayerSetRemoveBlockMode.Place;
            }

            {
                var type = data as PlayerSetRemoveBlockDataRemove;
                if (type != null)
                    Mode = PlayerSetRemoveBlockMode.Remove;
            }

            Data = data;

            AsyncCallback = asyncCallback;
            State = state;
        }

        public BeginPlayerSetRemoveBlockParameters(PlayerSetRemoveBlockMode mode, IPlayerSetRemoveBlockData data, AsyncCallback asyncCallback, object state) : this()
        {
            Mode = mode;

            Data = data;

            AsyncCallback = asyncCallback;
            State = state;
        }
    }

    public struct BeginSendMessage : IAsyncSending { }
    public struct BeginSendMessageParameters : IAsyncSendingParameters
    {
        public AsyncCallback AsyncCallback { get; set; }
        public object State { get; set; }

        public string Message { get; set; }

        public BeginSendMessageParameters(string message, AsyncCallback asyncCallback, object state) : this()
        {
            Message = message;

            AsyncCallback = asyncCallback;
            State = state;
        }
    }

    public struct BeginPlayerHeldItem : IAsyncSending { }
    public struct BeginPlayerHeldItemParameters : IAsyncSendingParameters
    {
        public AsyncCallback AsyncCallback { get; set; }
        public object State { get; set; }

        public short Slot { get; set; }

        public BeginPlayerHeldItemParameters(short slot, AsyncCallback asyncCallback, object state) : this()
        {
            Slot = slot;

            AsyncCallback = asyncCallback;
            State = state;
        }
    }
}
