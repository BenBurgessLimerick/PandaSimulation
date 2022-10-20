using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class GuardedVelocityActionFeedback : ActionFeedback<GuardedVelocityFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/GuardedVelocityActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public GuardedVelocityActionFeedback() : base()
        {
            this.feedback = new GuardedVelocityFeedback();
        }

        public GuardedVelocityActionFeedback(HeaderMsg header, GoalStatusMsg status, GuardedVelocityFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static GuardedVelocityActionFeedback Deserialize(MessageDeserializer deserializer) => new GuardedVelocityActionFeedback(deserializer);

        GuardedVelocityActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = GuardedVelocityFeedback.Deserialize(deserializer);
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
