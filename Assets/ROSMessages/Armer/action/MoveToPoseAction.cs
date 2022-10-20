using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.Armer
{
    public class MoveToPoseAction : Action<MoveToPoseActionGoal, MoveToPoseActionResult, MoveToPoseActionFeedback, MoveToPoseGoal, MoveToPoseResult, MoveToPoseFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/MoveToPoseAction";
        public override string RosMessageName => k_RosMessageName;


        public MoveToPoseAction() : base()
        {
            this.action_goal = new MoveToPoseActionGoal();
            this.action_result = new MoveToPoseActionResult();
            this.action_feedback = new MoveToPoseActionFeedback();
        }

        public static MoveToPoseAction Deserialize(MessageDeserializer deserializer) => new MoveToPoseAction(deserializer);

        MoveToPoseAction(MessageDeserializer deserializer)
        {
            this.action_goal = MoveToPoseActionGoal.Deserialize(deserializer);
            this.action_result = MoveToPoseActionResult.Deserialize(deserializer);
            this.action_feedback = MoveToPoseActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
