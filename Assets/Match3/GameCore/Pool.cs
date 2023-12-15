using System.Collections.Generic;

namespace Match3.GameCore
{
  
        /// <summary>
        /// check //https://docs.unity3d.com/ScriptReference/Pool.IObjectPool_1.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        public class Pool<T,K> where K : struct
        {
            List<T> _objects = new List<T>();
            public Pool()
            {
                
            }
            public void Get<T>(K id)
            {
                
            }
            public void Release(T obj)
            {
                _objects.Add(obj);
            }
        }
    }

