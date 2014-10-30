﻿using MineLib.Network.Events;

namespace MineLib.Network
{
    public sealed partial class NetworkHandler
    {
        public event PacketHandler OnPacketHandled;

        public void RaisePacketHandled(int id, IPacket packet, ServerState? state)
        {
            if (DebugPackets)
                PacketsReceived.Add(packet);

            if (OnPacketHandled != null)
                OnPacketHandled(id, packet, state);
        }
    }
}
