using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public static class GameObjectExtensions
    {

        public static T GetOrAddComponent<T>(this MonoBehaviour monoBehaviour) where T : MonoBehaviour
        {
            T result = monoBehaviour.GetComponent<T>();
            if (!result)
            {
                result = monoBehaviour.gameObject.AddComponent<T>();
            }

            return result;
        }
    }    
}


