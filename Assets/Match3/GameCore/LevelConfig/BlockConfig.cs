using System;
using UnityEngine;

namespace Match3.GameCore
{
    [Serializable]
    public class BlockConfig
    {
        /// <summary>
        /// it should be a weak reference for object from a resource mediator
        /// </summary>
        [SerializeField]
        GameObject _prefab = null;

        public BlockConfig(GameObject prefab)
        {
            _prefab = prefab;
        }
        /// <summary>
        /// it should be a weak reference for object from a resource mediator
        /// </summary>
        public GameObject Prefab => _prefab;
    }
}
