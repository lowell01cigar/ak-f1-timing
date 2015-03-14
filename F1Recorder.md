**f1recorder** is simple console app which records the live-timing feed so it can be played back at some later date.

You can find the app in the bin\latest-f1utils directory once the project has been [built](Building.md) or it can be downloaded from the [build server](http://teamcity.codebetter.com/viewLog.html?buildTypeId=bt174&buildId=lastSuccessful&tab=artifacts&guest=1).

### Example usage ###

The app requires the name of the session to record and your live-timing username and password.

The example below show the app's output when no session it currently in progress.

```
> f1recorder live your-username your-password no-session
> 22:36:45.772: authenticating...
> 22:36:46.368: authenticated your-username
> 22:36:46.370: connecting...
> 22:36:48.172: SetSessionTypeMessage(SessionType='None', SessionId='_10041504')
> 22:36:48.174: SetSystemMessageMessage(Message='First Timed Session for 2010 FORMULA 1 CHINESE GRANDPRIX in Shanghai will be Practice 1')
> 22:36:48.176: SetStreamValidityMessage(IsValid='False')
> 22:36:48.176: SetKeyframeMessage(Keyframe=1)
> 22:36:48.182: SetPingIntervalMessage(PingInterval='00:00:00')
> 22:36:48.187: CompositeMessage([SetSessionStatusMessage(SessionStatus='Finished'), EndOfSessionMessage()])
> 22:36:48.189: disconnected
```

Once the session has ended the app will terminate and the resultant TMS (Timing Message Store) file can be played back by the `RecordedMessageReader`, as covered in the [examples](ExampleUsage.md).