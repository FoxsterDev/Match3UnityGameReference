using System;

namespace Match3.GameCore
{
    public interface IBlockView : IDisposable
    {
        uint ID { get; }
    }
}
