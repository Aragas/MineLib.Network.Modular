﻿using System;
using System.Collections.Generic;
using System.Linq;
using MineLib.Network;
using MineLib.Network.Data.Structs;
using ProtocolClassic.Enums;
using ProtocolClassic.Packets.Client;

namespace ProtocolClassic
{
    public partial class Protocol
    {
        private Dictionary<Type, Func<IAsyncSendingParameters, IAsyncResult>> AsyncSendingHandlers { get; set; }

        public void RegisterAsyncSending(Type asyncSendingType, Func<IAsyncSendingParameters, IAsyncResult> method)
        {
            bool any = asyncSendingType.GetInterfaces().Any(p => p == typeof(IAsyncSending));
            if (!any)
                throw new InvalidOperationException("AsyncSending type must implement MineLib.Network.IAsyncSending");

            AsyncSendingHandlers[asyncSendingType] = method;
        }


        private void RegisterSupportedAsyncSendings()
        {
            RegisterAsyncSending(typeof(BeginConnectToServer), BeginConnectToServer);
            RegisterAsyncSending(typeof(BeginPlayerMoved), BeginPlayerMoved);
            RegisterAsyncSending(typeof(BeginPlayerSetRemoveBlock), BeginPlayerSetRemoveBlock);
            RegisterAsyncSending(typeof(BeginSendMessage), BeginSendMessage);
        }

        public IAsyncResult DoAsyncSending(Type asyncSendingType, IAsyncSendingParameters parameters)
        {
            bool any = asyncSendingType.GetInterfaces().Any(p => p == typeof(IAsyncSending));
            if (!any)
                throw new InvalidOperationException("AsyncSending type must implement MineLib.Network.IAsyncSending");

            if (!AsyncSendingHandlers.ContainsKey(asyncSendingType))
                return null;

            return AsyncSendingHandlers[asyncSendingType](parameters);
        }


        private IAsyncResult BeginConnectToServer(IAsyncSendingParameters parameters)
        {
            var param = (BeginConnectToServerParameters) parameters;

            State = ConnectionState.JoiningServer;

            return BeginSendPacketHandled(new PlayerIdentificationPacket
            {
                ProtocolVersion = 0x07,
                Username = _minecraft.ClientUsername,
                VerificationKey = _minecraft.AccessToken,
                UnUsed = 0x42
            }, param.AsyncCallback, param.State);
        }

        private IAsyncResult BeginPlayerMoved(IAsyncSendingParameters parameters)
        {
            var param = (BeginPlayerMovedParameters) parameters;
            switch (param.Mode)
            {
                case PlaverMovedMode.OnGround:
                {
                    var data = (PlaverMovedDataOnGround) param.Data;
                    return null;
                }

                case PlaverMovedMode.Vector3:
                {
                    var data = (PlaverMovedDataVector3) param.Data;
                    return null;
                }

                case PlaverMovedMode.YawPitch:
                {
                    var data = (PlaverMovedDataYawPitch) param.Data;
                    return null;
                }

                case PlaverMovedMode.All:
                {
                    var data = (PlaverMovedDataAll) param.Data;

                    return BeginSendPacketHandled(new PositionAndOrientationPacket
                    {
                        Position = data.Vector3,
                        Yaw = (byte)data.Yaw,
                        Pitch = (byte)data.Pitch,
                        PlayerID = 255
                    }, param.AsyncCallback, param.State);
                }

                default:
                    throw new Exception("PacketError");
            }
        }

        private IAsyncResult BeginPlayerSetRemoveBlock(IAsyncSendingParameters parameters)
        {
            var param = (BeginPlayerSetRemoveBlockParameters)parameters;
            switch (param.Mode)
            {
                case PlayerSetRemoveBlockMode.Place:
                    {
                        var data = (PlayerSetRemoveBlockDataPlace)param.Data;
                        return null;
                    }

                case PlayerSetRemoveBlockMode.Dig:
                    {
                        var data = (PlayerSetRemoveBlockDataDig)param.Data;
                        return null;
                    }

                case PlayerSetRemoveBlockMode.Remove:
                    {
                        var data = (PlayerSetRemoveBlockDataRemove)param.Data;

                        return BeginSendPacketHandled(new SetBlockPacket
                        {
                            Coordinates = data.Location,
                            BlockType = (byte)data.BlockID,
                            Mode = (SetBlockMode)data.Mode
                        }, param.AsyncCallback, param.State);
                    }

                default:
                    throw new Exception("PacketError");
            }
        }

        private IAsyncResult BeginSendMessage(IAsyncSendingParameters parameters)
        {
            var param = (BeginSendMessageParameters)parameters;

            return BeginSendPacketHandled(new MessagePacket { Message = param.Message }, param.AsyncCallback, param.State);
        }
    }
}