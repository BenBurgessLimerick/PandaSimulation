using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.Armer
{
    public class HomeAction : Action<HomeActionGoal, HomeActionResult, HomeActionFeedback, HomeGoal, HomeResult, HomeFeedback>
    {
        public const string k_RosMessageName = "armer_msgs/HomeAction";
        public override string RosMessageName => k_RosMessageName;


        public HomeAction() : base()
        {
            this.action_goal = new HomeActionGoal();
            this.action_result = new HomeActionResult();
            this.action_feedback = new HomeActionFeedback();
        }

        public static HomeAction Deserialize(MessageDeserializer deserializer) => new HomeAction(deserializer);

        HomeAction(MessageDeserializer deserializer)
        {
            this.action_goal = HomeActionGoal.Deserialize(deserializer);
            this.action_result = HomeActionResult.Deserialize(deserializer);
            this.action_feedback = HomeActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
