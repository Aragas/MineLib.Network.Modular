﻿namespace MineLib.Network.Data
{
    /// <summary>
    /// Represents the size of an object in 3D space.
    /// </summary>
    public struct Size
    {
        public readonly double Width;
        public readonly double Height;
        public readonly double Depth;

        public Size(double width, double height, double depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
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
            return string.Format("Width: {0}, Height: {1}, Depth: {2}", Width, Height, Depth);
        }
        
        // TODO: More operators
        public static Size operator /(Size a, double b)
        {
            return new Size(a.Width/b, a.Height/b, a.Depth/b);
        }

        public static bool operator ==(Size a, double b)
        {
            return a.Width == b && a.Height == b && a.Depth == b;
        }

        public static bool operator !=(Size a, double b)
        {
            return a.Width!= b && a.Height != b && a.Depth != b;
        }

        public bool Equals(Size other)
        {
            return other.Width.Equals(Width) && other.Height.Equals(Height) && other.Depth.Equals(Depth);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Size))
                return false;

            return Equals((Size)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = Width.GetHashCode();
                result = (result * 397) ^ Height.GetHashCode();
                result = (result * 397) ^ Depth.GetHashCode();
                return result;
            }
        }
    }
}