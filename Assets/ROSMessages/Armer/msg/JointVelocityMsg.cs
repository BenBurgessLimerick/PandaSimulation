//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Armer
{
    [Serializable]
    public class JointVelocityMsg : Message
    {
        public const string k_RosMessageName = "armer_msgs/JointVelocity";
        public override string RosMessageName => k_RosMessageName;

        public double[] joints;
        //  rad/s

        public JointVelocityMsg()
        {
            this.joints = new double[0];
        }

        public JointVelocityMsg(double[] joints)
        {
            this.joints = joints;
        }

        public static JointVelocityMsg Deserialize(MessageDeserializer deserializer) => new JointVelocityMsg(deserializer);

        private JointVelocityMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.joints, sizeof(double), deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.WriteLength(this.joints);
            serializer.Write(this.joints);
        }

        public override string ToString()
        {
            return "JointVelocityMsg: " +
            "\njoints: " + System.String.Join(", ", joints.ToList());
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
