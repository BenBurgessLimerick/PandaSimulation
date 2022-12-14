//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Armer
{
    [Serializable]
    public class GuardsMsg : Message
    {
        public const string k_RosMessageName = "armer_msgs/Guards";
        public override string RosMessageName => k_RosMessageName;

        public const byte GUARD_DURATION = 1;
        public const byte GUARD_EFFORT = 2;
        public const byte GUARD_DIVERGANCE = 4;
        public byte enabled;
        //  Enabled guard constraints
        public float duration;
        public Geometry.WrenchMsg effort;

        public GuardsMsg()
        {
            this.enabled = 0;
            this.duration = 0.0f;
            this.effort = new Geometry.WrenchMsg();
        }

        public GuardsMsg(byte enabled, float duration, Geometry.WrenchMsg effort)
        {
            this.enabled = enabled;
            this.duration = duration;
            this.effort = effort;
        }

        public static GuardsMsg Deserialize(MessageDeserializer deserializer) => new GuardsMsg(deserializer);

        private GuardsMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.enabled);
            deserializer.Read(out this.duration);
            this.effort = Geometry.WrenchMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.enabled);
            serializer.Write(this.duration);
            serializer.Write(this.effort);
        }

        public override string ToString()
        {
            return "GuardsMsg: " +
            "\nenabled: " + enabled.ToString() +
            "\nduration: " + duration.ToString() +
            "\neffort: " + effort.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
