# MissingCoverlet.Repro.Tests
Example of missing code coverage data when using coverlet with NetMq in .NetStnd 2.0 lib.

The issue seems localized on the following call: `NetMQPoller.RunAsync()` See source here: https://github.com/zeromq/netmq/blob/0b58c232799ce578868524814ce7a59ed13a0a37/src/NetMQ/NetMQPoller.cs#L418.

Notice that

1) `MissingCoverlet.Repro.Tests.SubscriberTests.NoCoverage()` test does not collect coverage data while `MissingCoverlet.Repro.Tests2.UnitTest1.CoverageIsCollected` does.
2) Even if other tests are added to the test project `MissingCoverlet.Repro.Tests`, NO tests will be seen by coverlet (or at least, no coverage data is collected)
3) If line 32 in `Subscriber.cs` is removed, coverlet sees coverage data from `MissingCoverlet.Repro.Tests.SubscriberTests.NoCoverage()` see line:  https://github.com/jasells/MissingCoverlet.Repro.Tests/blob/9621ea362e31d4a18198018484455704d64c6fe3/MissingCoverlet.Repro/Subscriber.cs#L32

Test log:

```
Fine Code Coverage : ================================== START ==================================

Fine Code Coverage : File synchronization duration : 00:00:00.5890356

Fine Code Coverage : File synchronization duration : 00:00:00.0389997

Fine Code Coverage : Run Coverage Tool (MissingCoverlet.Repro.Tests)

Fine Code Coverage : Coverlet Run (MissingCoverlet.Repro.Tests) Arguments 
--format "cobertura"
--exclude "[*Test*]*"
--exclude-by-file "**/Migrations/*"
--exclude-by-attribute "GeneratedCode"
--target "dotnet"
--threshold-type line
--threshold-stat total
--threshold 0

Fine Code Coverage : Coverlet Run (MissingCoverlet.Repro.Tests)
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: < 1 ms - MissingCoverlet.Repro.Tests.dll (net5.0)

Calculating coverage result...
+-----------------------+------+--------+--------+
| Module                | Line | Branch | Method |
+-----------------------+------+--------+--------+
| MissingCoverlet.Repro | 0%   | 0%     | 0%     |
+-----------------------+------+--------+--------+

+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 0%   | 0%     | 0%     |
+---------+------+--------+--------+
| Average | 0%   | 0%     | 0%     |
+---------+------+--------+--------+

Fine Code Coverage : Completed coverage for MissingCoverlet.Repro.Tests : 00:00:04.2844353

Fine Code Coverage : Run Coverage Tool (MissingCoverlet.Repro.Tests2)

Fine Code Coverage : Coverlet Run (MissingCoverlet.Repro.Tests2) Arguments 
--format "cobertura"
--exclude "[*Test*]*"
--exclude-by-file "**/Migrations/*"
--exclude-by-attribute "GeneratedCode"
--target "dotnet"
--threshold-type line
--threshold-stat total
--threshold 0

Fine Code Coverage : Coverlet Run (MissingCoverlet.Repro.Tests2)
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: < 1 ms - MissingCoverlet.Repro.Tests2.dll (net5.0)

Calculating coverage result...
+-----------------------+--------+--------+--------+
| Module                | Line   | Branch | Method |
+-----------------------+--------+--------+--------+
| MissingCoverlet.Repro | 44.44% | 12.5%  | 50%    |
+-----------------------+--------+--------+--------+

+---------+--------+--------+--------+
|         | Line   | Branch | Method |
+---------+--------+--------+--------+
| Total   | 44.44% | 12.5%  | 50%    |
+---------+--------+--------+--------+
| Average | 44.44% | 12.5%  | 50%    |
+---------+--------+--------+--------+

Fine Code Coverage : Completed coverage for MissingCoverlet.Repro.Tests2 : 00:00:03.8351438

Fine Code Coverage : ReportGenerator Run Arguments [reporttype:Cobertura] 
"-reporttypes:Cobertura"

Fine Code Coverage : ReportGenerator Run [reporttype:Cobertura]
2022-02-23T09:38:49: Arguments
2022-02-23T09:38:49:  -reporttypes:Cobertura
2022-02-23T09:38:50: Report generation took 0.2 seconds

Fine Code Coverage : ReportGenerator Run Arguments [reporttype:HtmlInline_AzurePipelines] 
"-reporttypes:FccLight"
"riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=30"
"riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=15"
"riskHotspotsAnalysisThresholds:metricThresholdForNPathComplexity=200"

Fine Code Coverage : ReportGenerator Run [reporttype:HtmlInline_AzurePipelines]
2022-02-23T09:38:50: Arguments
2022-02-23T09:38:50:  -reporttypes:FccLight
2022-02-23T09:38:50:  riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=30
2022-02-23T09:38:50:  riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=15
2022-02-23T09:38:50:  riskHotspotsAnalysisThresholds:metricThresholdForNPathComplexity=200
2022-02-23T09:38:50: Writing report file 'MissingCoverlet.Repro.Tests\MissingCoverlet.Repro.Tests\bin\Debug\net5.0\fine-code-coverage\coverage-tool-output\index.html'
2022-02-23T09:38:51: Report generation took 0.1 seconds

Fine Code Coverage : Processing cobertura

Fine Code Coverage : Processing report

Fine Code Coverage : ================================== DONE ==================================
```
