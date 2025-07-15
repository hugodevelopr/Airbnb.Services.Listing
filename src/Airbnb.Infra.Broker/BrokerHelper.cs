using System.Text;

namespace Airbnb.Infra.Broker;

public static class BrokerHelper
{
    public static string GetTopicOrQueueName(string eventName)
    {
        if (string.IsNullOrEmpty(eventName))
            return string.Empty;

        var topicOrQueue = eventName.Replace("Event", string.Empty);

        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(topicOrQueue[0]));

        for (var i = 1; i < topicOrQueue.Length; i++)
        {
            var @char = topicOrQueue[i];

            if (char.IsUpper(@char))
            {
                sb.Append('-');
                sb.Append(char.ToLowerInvariant(@char));
            }
            else
            {
                sb.Append(@char);
            }
        }

        return sb.ToString();
    }
}