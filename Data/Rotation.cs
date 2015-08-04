﻿using System;
using System.Runtime.InteropServices;

using MineLib.Core.Extensions;
using MineLib.Core.IO;

namespace MineLib.Core.Data
{
    /// <summary>
    /// Represents mostly head location of an entity
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Rotation : IEquatable<Rotation>
    {
        public readonly float Pitch;
        public readonly float Yaw;
        public readonly float Roll;

        public Rotation(float pitch, float yaw, float roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }

        public Rotation(Rotation v)
        {
            Pitch = v.Pitch;
            Yaw = v.Yaw;
            Roll = v.Roll;
        }


        #region Network

        public Rotation FromReaderFloat(IProtocolDataReader reader)
        {
            return new Rotation(
                reader.ReadFloat(),
                reader.ReadFloat(),
                reader.ReadFloat());
        }


        public void ToStreamFloat(IProtocolStream stream)
        {
            stream.WriteFloat(Pitch);
            stream.WriteFloat(Yaw);
            stream.WriteFloat(Roll);
        }

        #endregion


        /// <summary>
        /// Converts this Rotation to a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Pitch: {0}, Yaw: {1}, Roll: {2}", Pitch, Yaw, Roll);
        }

        public static bool operator ==(Rotation a, Rotation b)
        {
            return a.Pitch.Equals(b.Pitch) && a.Yaw.Equals(b.Yaw) && a.Roll.Equals(b.Roll);
        }

        public static bool operator !=(Rotation a, Rotation b)
        {
            return !a.Pitch.Equals(b.Pitch) && !a.Yaw.Equals(b.Yaw) && !a.Roll.Equals(b.Roll);
        }

        public bool Equals(Rotation other)
        {
            return other.Pitch.NearlyEquals(Pitch) && other.Yaw.NearlyEquals(Yaw) && other.Roll.NearlyEquals(Roll);
        }

        public bool Equals(float other)
        {
            return other.NearlyEquals(Pitch) && other.NearlyEquals(Yaw) && other.NearlyEquals(Roll);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Rotation) obj);         
        }

        public override int GetHashCode()
        {
            return Pitch.GetHashCode() ^ Yaw.GetHashCode() ^ Roll.GetHashCode();
        }
    }
}
