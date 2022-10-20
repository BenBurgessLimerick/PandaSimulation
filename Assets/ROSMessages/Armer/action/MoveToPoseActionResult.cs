using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.Armer
{
    public class MoveToPoseActionResult : ActionResult<MoveToPoseResult>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToPoseActionResult";
        public override string RosMessageName => k_RosMessageName;


        public MoveToPoseActionResult() : base()
        {
            this.result = new MoveToPoseResult();
        }

        public MoveToPoseActionResult(HeaderMsg header, GoalStatusMsg status, MoveToPoseResult result) : base(header, status)
        {
            this.result = result;
        }
        public static MoveToPoseActionResult Deserialize(MessageDeserializer deserializer) => new MoveToPoseActionResult(deserializer);

        MoveToPoseActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = MoveToPoseResult.Deserialize(deserializer);
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
