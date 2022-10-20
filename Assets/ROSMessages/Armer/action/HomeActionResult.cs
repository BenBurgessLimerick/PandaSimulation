using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class HomeActionResult : ActionResult<HomeResult>
    {
        public const string k_RosMessageName = "armer_msgs/HomeActionResult";
        public override string RosMessageName => k_RosMessageName;


        public HomeActionResult() : base()
        {
            this.result = new HomeResult();
        }

        public HomeActionResult(HeaderMsg header, GoalStatusMsg status, HomeResult result) : base(header, status)
        {
            this.result = result;
        }
        public static HomeActionResult Deserialize(MessageDeserializer deserializer) => new HomeActionResult(deserializer);

        HomeActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = HomeResult.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.result);
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
