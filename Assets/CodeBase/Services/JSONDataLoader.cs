using System.IO;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class JSONDataLoader
    {
        public T Load<T>(string path) where T : class
        {
            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException($"File not found at path {path}");
            }

            string jsonData = File.ReadAllText(path);
            T data = JsonUtility.FromJson<T>(jsonData);

            return data;
        }
    }
}