namespace MetaHic
{
    public class Display
    {
        public const int DisplayWidth = 64;
        public const int DisplayHeight = 8;

        private readonly int[,] pixels = new int[DisplayWidth, DisplayHeight];

        private readonly Action<byte[]> commandDispatcher;

        public Display(Action<byte[]> commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void CommandFlush()
        {
            byte[] data = new byte[64];

            for (int x = 0; x < DisplayWidth; x++)
            {
                for (int y = 0; y < DisplayHeight; y++)
                {
                    int state = pixels[x, y] > 0 ? 1 : 0;
                    data[x] |= (byte)(state << y);
                    pixels[x, y] = 0;
                }
            }

            commandDispatcher(data);
        }

        public void Set(int value = 0)
        {
            for (int y = 0; y < DisplayHeight; y++)
            {
                for (int x = 0; x < DisplayWidth; x++)
                {
                    pixels[x, y] = value;
                }
            }
        }

        public int GetPixel((int x, int y) pos)
        {
            return pixels[pos.x, pos.y];
        }

        public void SetPixel((int x, int y) pos, int value)
        {
            pixels[pos.x, pos.y] = value;
        }
    }
}