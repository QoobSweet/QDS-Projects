using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Qnet
{
    public class Protocols : MonoBehaviour
    {
        [Serializable]
        public class QnMessage
        {
            public byte[] Data { get; set; }
        }

        //Handlers for converting Qnet Messages to network transferable
        public static QnMessage Serialize(object anySerializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
                return new QnMessage { Data = memoryStream.ToArray() };
            }
        }
        public static object Deserialize(QnMessage message)
        {
            using (var memoryStream = new MemoryStream(message.Data))
                return (new BinaryFormatter()).Deserialize(memoryStream);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
