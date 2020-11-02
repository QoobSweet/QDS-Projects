using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qnet
{
    public static class SaveTools
    {
        #region SerializableProperties

        [Serializable]
        public class StoreTransform
        {
            public Vector3 position;
            public Quaternion rotation;
            public Vector3 localScale;
        }

        [Serializable]
        public class StoreQNetID
        {
            public QnID qnUID;
        }

        [Serializable]
        public class StoreGameObject
        {
            public StoreQNetID StoredQNetID;
            public StoreTransform StoredTransform;
            public QnID Parent = new QnID();
        }

        #endregion

        #region QnID Serialization

        public static StoreQNetID SaveLocal(this QnID _QnID)
        {
            return new StoreQNetID
            {
                qnUID = _QnID,
            };
        }

        #endregion

        #region TransformSerialization

        public static StoreTransform SaveLocal(this Transform aTransform)
        {
            return new StoreTransform()
            {
                position = aTransform.localPosition,
                rotation = aTransform.rotation,
                localScale = aTransform.localScale
            };
        }
        public static StoreTransform SaveWorld(this Transform aTransform)
        {
            return new StoreTransform()
            {
                position = aTransform.position,
                rotation = aTransform.rotation,
                localScale = aTransform.localScale
            };
        }
        
        public static void LoadLocal(this Transform aTransform, StoreTransform aData)
        {
            aTransform.localPosition = aData.position;
            aTransform.localRotation = aData.rotation;
            aTransform.localScale = aData.localScale;
        }
        public static void LoadWorld(this Transform aTransform, StoreTransform aData)
        {
            aTransform.position = aData.position;
            aTransform.rotation = aData.rotation;
            aTransform.localScale = aData.localScale;
        }

        #endregion

        #region GameObject Serialization

        public static StoreGameObject SaveGameObject(this GameObject aGameObject)
        {
            //store main GameObject with world location
            return new StoreGameObject
            {
                StoredTransform = aGameObject.transform.SaveWorld(),
                StoredQNetID = aGameObject.GetComponent<QnID>().SaveLocal(),
                //Parent QnUID is default value ie null. Object is assumed to be part of root game
            }; 
        }
        public static StoreGameObject SaveGameObject(this GameObject aGameObject, QnID ParentObjectID)
        {
            //store main GameObject with world location
            return new StoreGameObject
            {
                StoredTransform = aGameObject.transform.SaveWorld(),
                StoredQNetID = aGameObject.GetComponent<QnID>().SaveLocal(),
                Parent = ParentObjectID,
            };
        }

        #endregion

    }
}
