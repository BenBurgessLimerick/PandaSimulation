using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.Armer
{
    public class GuardedVelocityAction : Action<GuardedVelocityActionGoal, GuardedVelocityActionResult, GuardedVelocityActionFeedback, GuardedVelocityGoal, GuardedVelocityResult, GuardedVelocityFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/GuardedVelocityAction";
        public override string RosMessageName => k_RosMessageName;


        public GuardedVelocityAction() : base()
        {
            this.action_goal = new GuardedVelocityActionGoal();
            this.action_result = new GuardedVelocityActionResult();
            this.action_feedback = new GuardedVelocityActionFeedback();
        }

        public static GuardedVelocityAction Deserialize(MessageDeserializer deserializer) => new GuardedVelocityAction(deserializer);

        GuardedVelocityAction(MessageDeserializer deserializer)
        {
            this.action_goal = GuardedVelocityActionGoal.Deserialize(deserializer);
            this.action_result = GuardedVelocityActionResult.Deserialize(deserializer);
            this.action_feedback = GuardedVelocityActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
