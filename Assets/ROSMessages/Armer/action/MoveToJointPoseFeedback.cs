//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Armer
{
    [Serializable]
    public class MoveToJointPoseFeedback : Message
    {
        public const string k_RosMessageName = "armer_msgs/MoveToJointPose";
        public override string RosMessageName => k_RosMessageName;

        //  Feedback definition
        public sbyte status;

        public MoveToJointPoseFeedback()
        {
            this.status = 0;
        }

        public MoveToJointPoseFeedback(sbyte status)
        {
            this.status = status;
        }

        public static MoveToJointPoseFeedback Deserialize(MessageDeserializer deserializer) => new MoveToJointPoseFeedback(deserializer);

        private MoveToJointPoseFeedback(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.status);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.status);
        }

        public override string ToString()
        {
            return "MoveToJointPoseFeedback: " +
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
