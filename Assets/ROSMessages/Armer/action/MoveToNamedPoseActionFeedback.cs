using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToNamedPoseActionFeedback : ActionFeedback<MoveToNamedPoseFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToNamedPoseActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public MoveToNamedPoseActionFeedback() : base()
        {
            this.feedback = new MoveToNamedPoseFeedback();
        }

        public MoveToNamedPoseActionFeedback(HeaderMsg header, GoalStatusMsg status, MoveToNamedPoseFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static MoveToNamedPoseActionFeedback Deserialize(MessageDeserializer deserializer) => new MoveToNamedPoseActionFeedback(deserializer);

        MoveToNamedPoseActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = MoveToNamedPoseFeedback.Deserialize(deserializer);
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
