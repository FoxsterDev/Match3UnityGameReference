using UnityEngine;

namespace Match3.GameCore
{
    [RequireComponent(typeof(RectTransform))]
    public class GameBoardRect : MonoBehaviour
    {
        
        [SerializeField]
        RectTransform _rectTransform = null;

        [SerializeField]
        Transform _rootTransform = null;

        public Transform RootTransform => _rootTransform;

        public Vector3 GetLeftUpAnchorPosition()
        {
            var v = new Vector3[4];
            _rectTransform.GetWorldCorners(v);
            return v[1];
        }

        public void SetRootLocalPosition(Vector2 offset)
        {
            _rootTransform.localPosition = offset;
        }

        void Start()
        {
           
        }

        void OnDrawGizmos()
        {
            var v = new Vector3[4];
            _rectTransform.GetWorldCorners(v);

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(v[0], 0.1f);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(v[1], 0.1f); 
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(v[2], 0.1f);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(v[3], 0.1f);
        }

        void OnValidate()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    }
}
