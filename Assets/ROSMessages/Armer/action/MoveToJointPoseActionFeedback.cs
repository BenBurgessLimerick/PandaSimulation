using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToJointPoseActionFeedback : ActionFeedback<MoveToJointPoseFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToJointPoseActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public MoveToJointPoseActionFeedback() : base()
        {
            this.feedback = new MoveToJointPoseFeedback();
        }

        public MoveToJointPoseActionFeedback(HeaderMsg header, GoalStatusMsg status, MoveToJointPoseFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static MoveToJointPoseActionFeedback Deserialize(MessageDeserializer deserializer) => new MoveToJointPoseActionFeedback(deserializer);

        MoveToJointPoseActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = MoveToJointPoseFeedback.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.feedback);
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
