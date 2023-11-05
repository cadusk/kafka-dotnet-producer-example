using KafkaUserProducerExample.Kafka;
using KafkaUserProducerExample.Services;

namespace KafkaUserProducerExample
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var producer = new UserProducer(Settings.SchemaRegistryUrl, Settings.BootstrapServers);
      await producer.Produce(Settings.UserCreateTopic,
          new Services.UserService().GetAll());
    }
  }
}
