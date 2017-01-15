﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace chemistrecipe
{
    public class ObjectManager : MonoBehaviour
    {

        // Models path
        public const string OBJECT_PATH = "Objects/";
        // Models load
        private Dictionary<ChemstObject, UnityEngine.Object> models = new Dictionary<ChemstObject, UnityEngine.Object>();

        public UnityEngine.Object getObject(ChemstObject chemstObject)
        {
            if(!models.ContainsKey(chemstObject))
            {
                models[chemstObject] = Resources.Load(OBJECT_PATH + chemstObject.toString());
            }

            return models[chemstObject];
        }

    }
}
