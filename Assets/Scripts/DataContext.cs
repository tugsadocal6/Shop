using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine;
using Persistance;
using Model;

namespace Persistence
{
    [Serializable]
    public abstract class DataContext : MonoBehaviour
    {
        public GameData data = new GameData();

        public abstract Task Load();
        public abstract Task Save();

        private void Start()
        {
            Load();
        }

        public List<T> Set<T>()
        {
            if (typeof(T) == typeof(Player))
            {
                return data.players as List<T>;
            }

            if (typeof(T) == typeof(Shop))
            {
                return data.shops as List<T>;
            }

            return null;
        }

    }

}

