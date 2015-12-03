﻿using System.Runtime.InteropServices;

using MineLib.Core.Extensions;

namespace MineLib.Core.Data
{
    /// <summary>
    /// Represents the size of an object in 3D space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Size
    {
        public readonly float Width;
        public readonly float Height;
        public readonly float Depth;

        public Size(float width, float height, float depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public Size(double width, double height, double depth)
        {
            Width = (float) width;
            Height = (float) height;
            Depth = (float) depth;
        }

        public Size(Size s)
        {
            Width = s.Width;
            Height = s.Height;
            Depth = s.Depth;
        }

        /// <summary>
        /// Converts this Size to a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Width: {Width}, Height: {Height}, Depth: {Depth}";
        }
        
        // TODO: More operators
        public static Size operator /(Size a, float b)
        {
            return new Size(a.Width / b, a.Height / b, a.Depth / b);
        }

        public static bool operator ==(Size a, float b)
        {
            return a.Width.Equals(b) && a.Height.Equals(b) && a.Depth.Equals(b);
        }

        public static bool operator !=(Size a, float b)
        {
            return !a.Width.Equals(b) && !a.Height.Equals(b) && !a.Depth.Equals(b);
        }

        public bool Equals(Size other)
        {
            return other.Width.NearlyEquals(Width) && other.Height.NearlyEquals(Height) && other.Depth.NearlyEquals(Depth);
        }

        public bool Equals(float other)
        {
            return other.NearlyEquals(Width) && other.NearlyEquals(Height) && other.NearlyEquals(Depth);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Size) obj);
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode() ^ Depth.GetHashCode();
        }
    }
}