using System.Collections.Generic;
using UnityEngine;

namespace TheLine.ObjectPool
{
    public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected int objectCount;
        [SerializeField] protected T template;

        [SerializeField] protected Transform endPoint;



        protected List<T> objects;


        public T GetObject()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].gameObject.activeInHierarchy == false)
                {
                    objects[i].gameObject.SetActive(true);
                    return objects[i];
                }
            }
            CreateObject();
            objects[objects.Count - 1].gameObject.SetActive(true);
            return objects[objects.Count - 1];
        }


        protected void Initialize()
        {
            objects = new List<T>();
            for (int i = 0; i < objectCount; i++)
            {
                CreateObject();
            }
        }

        protected T CreateObject()
        {
            T temp = Instantiate(template);
            objects.Add(temp);
            temp.gameObject.SetActive(false);
            return temp;
        }
    }
}
