//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Armer
{
    [Serializable]
    public class MoveToNamedPoseFeedback : Message
    {
        public const string k_RosMessageName = "armer_msgs/MoveToNamedPose";
        public override string RosMessageName => k_RosMessageName;

        //  Feedback definition
        public sbyte status;

        public MoveToNamedPoseFeedback()
        {
            this.status = 0;
        }

        public MoveToNamedPoseFeedback(sbyte status)
        {
            this.status = status;
        }

        public static MoveToNamedPoseFeedback Deserialize(MessageDeserializer deserializer) => new MoveToNamedPoseFeedback(deserializer);

        private MoveToNamedPoseFeedback(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.status);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.status);
        }

        public override string ToString()
        {
            return "MoveToNamedPoseFeedback: " +
            "\nstatus: " + status.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Feedback);
        }
    }
}
