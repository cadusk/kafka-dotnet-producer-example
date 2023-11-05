using System;

namespace KafkaUserProducerExample {
    public static class Settings {
      public static string BootstrapServers {
        get {
          return GetValueFor("EXAMPLE_BOOTSTRAP_SERVERS");
        }
      }

      public static string SchemaRegistryUrl {
        get {
          return GetValueFor("EXAMPLE_SCHEMA_REGISTRY_URL");
        }
      }

      public static string UserCreateTopic {
        get {
          return GetValueFor("USER_CREATE_TOPIC");
        }
      }

      private static string GetValueFor(string variable) {
        var c = Environment.GetEnvironmentVariable(variable);

        if (string.IsNullOrEmpty(c))
          throw new Exception($"Missing configuration: variable '{variable}' not set.");

        return c;
      }
    }
}
