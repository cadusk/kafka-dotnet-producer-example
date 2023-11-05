
namespace KafkaUserProducerExample.Kafka
{
  public class UserProducer : Producer<Models.User>
  {
    public UserProducer(string schemaRegistryUrl, string bootstrapServers)
      : base(schemaRegistryUrl, bootstrapServers)
    {
    }
  }
}
