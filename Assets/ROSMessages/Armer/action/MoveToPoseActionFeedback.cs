using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToPoseActionFeedback : ActionFeedback<MoveToPoseFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToPoseActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public MoveToPoseActionFeedback() : base()
        {
            this.feedback = new MoveToPoseFeedback();
        }

        public MoveToPoseActionFeedback(HeaderMsg header, GoalStatusMsg status, MoveToPoseFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static MoveToPoseActionFeedback Deserialize(MessageDeserializer deserializer) => new MoveToPoseActionFeedback(deserializer);

        MoveToPoseActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = MoveToPoseFeedback.Deserialize(deserializer);
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
