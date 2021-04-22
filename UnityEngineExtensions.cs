using UnityEngine;

static public class UnityEngineExtensions {

    /// <summary>
    /// Usage example: gameObject.GetOrAddComponent<Rigidbody>();
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <returns> reference to component passed as param (will create new and pass reference is no component is found)</returns>
    static public T GetOrAddComponent<T>(this GameObject gameObject) where T : Component {
        return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
    }
}


