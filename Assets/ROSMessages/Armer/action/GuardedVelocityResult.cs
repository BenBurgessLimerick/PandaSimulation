//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Armer
{
    [Serializable]
    public class GuardedVelocityResult : Message
    {
        public const string k_RosMessageName = "armer_msgs/GuardedVelocity";
        public override string RosMessageName => k_RosMessageName;

        //  Result definition
        public byte triggered;

        public GuardedVelocityResult()
        {
            this.triggered = 0;
        }

        public GuardedVelocityResult(byte triggered)
        {
            this.triggered = triggered;
        }

        public static GuardedVelocityResult Deserialize(MessageDeserializer deserializer) => new GuardedVelocityResult(deserializer);

        private GuardedVelocityResult(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.triggered);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.triggered);
        }

        public override string ToString()
        {
            return "GuardedVelocityResult: " +
            "\ntriggered: " + triggered.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Result);
        }
    }
}
