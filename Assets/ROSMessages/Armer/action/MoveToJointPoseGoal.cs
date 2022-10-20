//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Armer
{
    [Serializable]
    public class MoveToJointPoseGoal : Message
    {
        public const string k_RosMessageName = "armer_msgs/MoveToJointPose";
        public override string RosMessageName => k_RosMessageName;

        //  Goal definition
        public double[] joints;
        //  radians
        public float speed;
        //  m/s

        public MoveToJointPoseGoal()
        {
            this.joints = new double[0];
            this.speed = 0.0f;
        }

        public MoveToJointPoseGoal(double[] joints, float speed)
        {
            this.joints = joints;
            this.speed = speed;
        }

        public static MoveToJointPoseGoal Deserialize(MessageDeserializer deserializer) => new MoveToJointPoseGoal(deserializer);

        private MoveToJointPoseGoal(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.joints, sizeof(double), deserializer.ReadLength());
            deserializer.Read(out this.speed);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.WriteLength(this.joints);
            serializer.Write(this.joints);
            serializer.Write(this.speed);
        }

        public override string ToString()
        {
            return "MoveToJointPoseGoal: " +
            "\njoints: " + System.String.Join(", ", joints.ToList()) +
            "\nspeed: " + speed.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Goal);
        }
    }
}
