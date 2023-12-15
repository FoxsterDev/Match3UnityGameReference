using System;
using UnityEngine;

namespace Match3.GameCore
{
    public class BlockView : MonoBehaviour, IBlockView
    {
        [SerializeField]
        uint _id = 0;

        uint IBlockView.ID => _id;
        public void Dispose()
        {

        }
    }
}
