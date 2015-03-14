The examples below require a reference to the AK.F1.Timing.Core assembly which can be found in the bin\latest-f1core directory once the project has been [built](Building.md) or it can be downloaded from the [build server](http://teamcity.codebetter.com/viewLog.html?buildTypeId=bt174&buildId=lastSuccessful&tab=artifacts&guest=1).

## Reading the live feed ##

The example below shows how to log into the live-timing feed, create a message reader and read all messages until the end of the stream is reached.

```
Message message;
// Log into the service.
AuthenticationToken token = F1Timing.Live.Login("your-username", "your-password");
// Create a message reader using the issued token.
using(IMessageReader reader = F1Timing.Live.Read(token)) {
    // Read all messages until the end of the stream is reached (indicated by a null message)
    while((message = reader.Read()) != null) {
        // Do something with the message.
        Console.WriteLine(message);
    }
}
```

## Reading and recording the live feed ##

The example below shows how to log into the live-timing feed, create a recording message reader and read all messages until the end of the stream is reached.


```
Message message;
// The path to record to.
string path = "session.tms";
// Log into the service.
AuthenticationToken token = F1Timing.Live.Login("your-username", "your-password");
// Create a message reader using the issued token and record the messages to the given path.
using(IMessageReader reader = F1Timing.Live.ReadAndRecord(token, path)) {
    // Read all messages until the end of the stream is reached (indicated by a null message)
    while((message = reader.Read()) != null) {
        // Do something with the message.
        Console.WriteLine(message);
    }
}
```

## Playback a recorded session ##

The example below shows how to read a session which has been previously recorded.


```
Message message;
// The path of the recorded sesssion.
string path = "session.tms";
// Create a message reader using the given path.
using(IRecordedMessageReader reader = F1Timing.Playback.Read(path)) {
    // An IRecordedMessageReader allows you to change the playback speed, for
    // example, lets play this session back at 2x speed.
    reader.PlaybackSpeed = 2d;
    // Read all messages until the end of the stream is reached (indicated by a null message)
    while((message = reader.Read()) != null) {
        // Do something with the message.
        Console.WriteLine(message);
    }
}
```

## Processing messages ##

The example belows shows how to process messages using a `SessionResultBuilder` which is a concrete `MessageVisitorBase`. As the `SessionResultBuilder` visits messages it builds a dictionary of `Driver` instances each of which contains the driver's name and current position. Once the end of the message stream has been reached the result of the session is printed out.

```

    public static void Main(string[] args) {
        Message message;
        var builder = new SessionResultBuilder();
        // CreateReader has been omitted for brevity.
        using(var reader = CreateReader()) {
            while((message = reader.Read()) != null) {
                // Process the message.
                message.Accept(builder);
            }
        }
        // Print the result of the session to the console.
        builder.Print();
    }

    public class SessionResultBuilder : MessageVisitorBase
    {
        private IDictionary<int, Driver> _drivers = new Dictionary<int, Driver>();

        public override void Visit(SetDriverNameMessage message) {
            GetDriver(message).Name = message.DriverName;
        }

        public override void Visit(SetDriverPositionMessage message) {
            GetDriver(message).Position = message.Position;
        }

        public void Print() {
            foreach(var driver in _drivers.Values.OrderBy(x => x.Position)) {
                Console.WriteLine("{0,-2} - {1}", driver.Position, driver.Name);
            }
        }

        private Driver GetDriver(DriverMessageBase message) {
            Driver driver = null;
            if(!_drivers.TryGetValue(message.DriverId, out driver)) {
                driver = new Driver();
                _drivers.Add(message.DriverId, driver);
            }
            return driver;
        }
    }

    public class Driver
    {
        public string Name { get; set; }
        public int Position { get; set; }
    }
```

Using this simple technique you can build expressive models that are cleanly seperated from the message source and messages.

For a more complete example, please refer to the [model project](ModelProject.md).