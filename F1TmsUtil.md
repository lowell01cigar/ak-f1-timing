**f1tmsutil** is simple console app which allows you to process the TMS (Timing Message Store) files generated by the [f1recorder](F1Recorder.md).

You can find the app in the bin\latest-f1utils directory once the project has been [built](Building.md) or it can be downloaded from the [build server](http://teamcity.codebetter.com/viewLog.html?buildTypeId=bt174&buildId=lastSuccessful&tab=artifacts&guest=1).

### Available Commands ###

<dl>
<blockquote><dt>dump</dt>
<dd>Dumps the contents of the TMS file to the standard out.</dd>
<dt>dumpSession</dt>
<dd>Dumps the result of the session contained within the TMS file to the standard out.</dd>
<dt>stats</dt>
<dd>Prints statistical information about the TMS, including the object type, instance count and average object length.</dd>
<dt>fixup</dt>
<dd>Filters out translated messages from the TMS and replays the session. Useful for when the translator has been modified. Note this overwrites the input TMS file.</dd>
</dl></blockquote>

### Example Usage ###

The example below show the app's output for the stats commands.

```
> f1tmsutil stats race.tms
+--------------------------------+----------+
|File Name:                      |  race.tms|
|File Length:                    |    598705|
|Number of Objects:              |     46761|
|Average Object Length:          |        12|
|Number of Object Types:         |        40|
+--------------------------------+----------+
|Object Type                     |     Count|
+--------------------------------+----------+
|SetGridColumnValueMessage       |      7864|
|SetNextMessageDelayMessage      |      7552|
|SetGridColumnColourMessage      |      6673|
|StopSessionTimeCountdownMessage |      5634|
|SetRemainingSessionTimeMessage  |      5634|
|SetElapsedSessionTimeMessage    |      2907|
|SetDriverSectorTimeMessage      |      2630|
|SetDriverSpeedMessage           |      1132|
|SetDriverIntervalMessage        |      1032|
|StartSessionTimeCountdownMessage|       944|
|SetDriverLapNumberMessage       |       857|
|SetDriverGapMessage             |       853|
|SetDriverLapTimeMessage         |       845|
|SetKeyframeMessage              |       437|
|SetDriverPositionMessage        |       395|
|ReplaceDriverSectorTimeMessage  |       318|
|SpeedCaptureMessage             |       198|
|ReplaceDriverLapTimeMessage     |       182|
|AddCommentaryMessage            |       148|
|SetDriverStatusMessage          |       110|
|SetWindAngleMessage             |        70|
|SetWindSpeedMessage             |        67|
|SetRaceLapNumberMessage         |        53|
|SetDriverPitCountMessage        |        42|
|SetDriverPitTimeMessage         |        32|
|SetHumidityMessage              |        28|
|SetSessionStatusMessage         |        25|
|SetDriverCarNumberMessage       |        24|
|SetDriverNameMessage            |        24|
|SetTrackTemperatureMessage      |        21|
|SetAtmosphericPressureMessage   |        13|
|SetAirTemperatureMessage        |         7|
|SetPingIntervalMessage          |         2|
|SetStreamValidityMessage        |         2|
|SetStreamTimestampMessage       |         1|
|SetSessionTypeMessage           |         1|
|SetCopyrightMessage             |         1|
|SetSystemMessageMessage         |         1|
|SetIsWetMessage                 |         1|
|EndOfSessionMessage             |         1|
+--------------------------------+----------+
```