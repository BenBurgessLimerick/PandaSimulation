using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class GuardedVelocityActionResult : ActionResult<GuardedVelocityResult>
    {
        public const string k_RosMessageName = "armer_msgs/GuardedVelocityActionResult";
        public override string RosMessageName => k_RosMessageName;


        public GuardedVelocityActionResult() : base()
        {
            this.result = new GuardedVelocityResult();
        }

        public GuardedVelocityActionResult(HeaderMsg header, GoalStatusMsg status, GuardedVelocityResult result) : base(header, status)
        {
            this.result = result;
        }
        public static GuardedVelocityActionResult Deserialize(MessageDeserializer deserializer) => new GuardedVelocityActionResult(deserializer);

        GuardedVelocityActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = GuardedVelocityResult.Deserialize(deserializer);
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
