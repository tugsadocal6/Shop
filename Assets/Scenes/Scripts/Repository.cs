using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading.Tasks;
using Model;

namespace Persistence
{
    [Serializable]
    public abstract class Repository<T> : MonoBehaviour where T : Base
    {
        [HideInInspector] public DataContext context;

        private List<T> Entities => context.Set<T>();

        public T GetById(string id)
        {
            return Entities.FirstOrDefault(e => e.id == id);
        }

        public void Add(T entity)
        {
            Debug.Log(entity);
        }

        public void Modify(T entity)
        {
            Debug.Log(entity);
        }

        public void Delete(T entity)
        {
            Debug.Log(entity);
        }

        public async Task Save()
        {
            await context.Save();
        }
    }
}


