using Assets.CodeBase.Model;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class StaticDataLoader
    {
        public T Load<T>(string path) where T : ScriptableObject => 
            Resources.Load<T>(path);
    }
}
