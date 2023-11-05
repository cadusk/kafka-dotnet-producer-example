using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

namespace KafkaUserProducerExample.Kafka
{

  public abstract class Producer<TModel>
  {
    private SchemaRegistryConfig _schemaRegistryConfig;
    private AvroSerializerConfig _avroSerializerConfig;
    private ProducerConfig _producerConfig;

    public Producer(string schemaRegistryUrl, string bootstrapServers)
    {
      this._schemaRegistryConfig = new SchemaRegistryConfig
      {
        Url = schemaRegistryUrl
      };

      this._avroSerializerConfig = new AvroSerializerConfig
      {
        AutoRegisterSchemas = false,
        UseLatestVersion = true
      };

      this._producerConfig = new ProducerConfig
      {
        BootstrapServers = bootstrapServers
      };
    }

    public async Task Produce(string topic, IList<TModel> items)
    {
      using (var schemaRegistry = new CachedSchemaRegistryClient(this._schemaRegistryConfig))
      using (var producer = new ProducerBuilder<Null, TModel>(this._producerConfig)
            .SetValueSerializer(new AvroSerializer<TModel>(schemaRegistry, this._avroSerializerConfig))
            .Build())
      {
        foreach(var item in items)
        {
          try {
            var report = await producer.ProduceAsync(topic, new Message<Null, TModel> {Value = item});
            Console.WriteLine($"Produced to topic: {report.Topic}, Partition: {report.Partition}, Offset: {report.Offset}");
          }
          catch (ProduceException<Null, TModel> e) {
            Console.WriteLine($"Failed to deliver message: {e.Error.Reason}");
            Console.WriteLine($"Failed with error: {e}");
          }
        }

        producer.Flush(TimeSpan.FromSeconds(10));
      }
    }
  }
}
