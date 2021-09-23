using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace GraphFunc
{
    public unsafe class FastBitmap : IDisposable
    {
        private readonly Bitmap _source;

        public readonly int Width;

        public readonly int Height;

        private readonly int _bytesPerPixel;

        private readonly BitmapData _bData;

        private readonly byte* _scan0;

        public int Count => _source.Height * _source.Width;

        public FastBitmap(Bitmap bitmap)
        {
            Width = bitmap.Width;
            Height = bitmap.Height;
            _source = bitmap;
            _bData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                bitmap.PixelFormat
            );
            _bytesPerPixel = _bData.Stride / Width;
            _scan0 = (byte*)_bData.Scan0.ToPointer();
        }

        private Color GetI(int i)
        {
            var data = _scan0 + i * _bytesPerPixel;
            return Color.FromArgb(data[2], data[1], data[0]);
        }

        private void SetI(int i, Color cl)
        {
            var data = _scan0 + i * _bytesPerPixel;
            (data[2], data[1], data[0]) = (cl.R, cl.G, cl.B);
            data[3] = 255;
        }

        public void SetPixel(Point p, Color cl)
            => SetI(p.X + p.Y * Width, cl);

        public Color GetPixel(Point p)
            => GetI(p.X + p.Y * Width);

        public void Dispose()
        {
            _source.UnlockBits(_bData);
        }
    }
}