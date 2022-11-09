# Fun with Franz v 1.0

---

.NET + Kafka practice projects

## Requirements
Zookeeper and Running Kafka cluster

## Install (mac HomeBrew)

---
- check If you have installed **Java** first, if not install 
```bash
# check
$ java -version
 
# install
$ brew tap caskroom/cask
$ brew cask install java
```
- install **Kafka**
```bash
$ brew install kafka
```

### Kafka Server config

---
- set the server to run on *localhost:9092*, run this command which starts nano editor
```bash
nano /usr/local/etc/kafka/server.properties
```
- find this commented line and uncomment it  *listeners=PLAINTEXT://:9092*
- also find the line with advertised.listeners and change the to any localhost format
``` text
listeners=PLAINTEXT://localhost:9092

advertised.listeners=PLAINTEXT://127.0.0.1:9092
```  

### Running zookeeper and kafka

---
- both services ara managed by `brew` commands
- always start *zookeeper first*
```bash
brew services <start / restart / stop> zookeeper
brew services <start / restart / stop> kafka
```

## Projects

---
### KafkaProducer Project
Run this first
 - produces messages and adds them to the queue on the **running kafka server**
 - after sending few messages we can stop runnig th project but messages are waiting in the queue
 - the sample is waiting for users's input to provide "name of the state" where we show/assign temperature to our Weather model (hardcoded to 10) 
 - insert few times few strings (states) to console and  stop running this


### KafkaConsumer Project
 - consumes the messages from kafka server by pulling data from linked topic named : `kafka-topic`
 - shows the previously provided "states" with temps in the console
