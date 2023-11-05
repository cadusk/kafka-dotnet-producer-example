using KafkaUserProducerExample.Models;

namespace KafkaUserProducerExample.Services
{
  public class UserService
  {
    public IList<Models.User> GetAll()
    {
      return new List<Models.User> {
        new Models.User { Name = "John Doe", Age = 43 },
        new Models.User { Name = "Jack Smith", Age = 26 },
      };
    }
  }
}
