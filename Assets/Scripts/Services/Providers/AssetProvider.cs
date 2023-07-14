using UnityEngine;

namespace Services.Providers
{
    public class AssetProvider
    {
        public T Get<T>(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return prefab.GetComponent<T>();
        }
    }
}