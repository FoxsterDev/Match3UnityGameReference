using UnityEngine;

namespace Match3.GameCore
{
    [System.Serializable]
    public class BlockConfig
    {
        /// <summary>
        /// it should be a weak reference for object from a resource mediator
        /// </summary>
        [SerializeField]
        GameObject _prefab = null;
    }
}
