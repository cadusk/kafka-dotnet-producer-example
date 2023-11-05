# Kafka .Net Producer Example

This is an example application on how to build a Kafka producers, automatically generate development infrastrucure and basic concepts about event streaming.

Scenario illustrates messages being sent to a topic called 'user-create' that supposedly will have consumers listening to requests for user creation in external applications.

## Getting started

There are not many prerequisits for this example to work since the solution is based on docker containers.

* docker
* make (optional)

Docker is the containerization tool used to make the development process seamless by providing and configuring services automatigically.

Make is a helper tool in this context and you don't have to have it installed to get through, but it will save a lot of typing. If you choose not to install or use make, "make sure" you check out it's targets to run the commands manually.

### Running the application for the first time

Should be as straight forward as:
```
make initialize producer.rebuild producer.run consumer.run
```

> NOTE: notice how nice it is to be able to chain make targets in single line. 

If all goes well, you should see something like this at the end of the output.

```
Produced to topic: user-create, Partition: [0], Offset: 0
Produced to topic: user-create, Partition: [0], Offset: 1
{
  "topic": "user-create",
  "value": "\u0000\u0000\u0000\u0000\u0001\u0010John DoeV",
  "timestamp": 1699202107498,
  "partition": 0,
  "offset": 0
}
{
  "topic": "user-create",
  "value": "\u0000\u0000\u0000\u0000\u0001\u0014Jack Smith4",
  "timestamp": 1699202108427,
  "partition": 0,
  "offset": 1
}
```

And all this simply means that 2 messages with user data were sent to `user-create` topic by the `make producer.run` command and `make consumer.run` was able to read them from the other end of the topic.

There are additional steps for all this to work going on under the hood that are detailed in the documentation.