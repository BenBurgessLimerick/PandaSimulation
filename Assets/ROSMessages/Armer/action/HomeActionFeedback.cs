using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class HomeActionFeedback : ActionFeedback<HomeFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/HomeActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public HomeActionFeedback() : base()
        {
            this.feedback = new HomeFeedback();
        }

        public HomeActionFeedback(HeaderMsg header, GoalStatusMsg status, HomeFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static HomeActionFeedback Deserialize(MessageDeserializer deserializer) => new HomeActionFeedback(deserializer);

        HomeActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = HomeFeedback.Deserialize(deserializer);
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
