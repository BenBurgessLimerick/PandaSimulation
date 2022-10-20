//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Armer
{
    [Serializable]
    public class MoveToNamedPoseResult : Message
    {
        public const string k_RosMessageName = "armer_msgs/MoveToNamedPose";
        public override string RosMessageName => k_RosMessageName;

        //  Result definition
        public bool success;

        public MoveToNamedPoseResult()
        {
            this.success = false;
        }

        public MoveToNamedPoseResult(bool success)
        {
            this.success = success;
        }

        public static MoveToNamedPoseResult Deserialize(MessageDeserializer deserializer) => new MoveToNamedPoseResult(deserializer);

        private MoveToNamedPoseResult(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.success);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.success);
        }

        public override string ToString()
        {
            return "MoveToNamedPoseResult: " +
            "\nsuccess: " + success.ToString();
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