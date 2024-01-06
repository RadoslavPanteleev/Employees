# Radoslav-Panteleev-employees
## TASK: Pair of employees who have worked together

**Create an application that identifies the pair of employees who have worked together on common projects for the longest period of time.**

<ins>*Input data:*</ins>\
&nbsp;&nbsp;&nbsp;&nbsp;A **CSV file** with data in the following format:\
&nbsp;&nbsp;&nbsp;&nbsp;EmpID, ProjectID, DateFrom, DateTo

<ins>*Sample data:*</ins>\
&nbsp;&nbsp;&nbsp;&nbsp;143, 12, 2013-11-01, 2014-01-05\
&nbsp;&nbsp;&nbsp;&nbsp;218, 10, 2012-05-16, NULL\
&nbsp;&nbsp;&nbsp;&nbsp;143, 10, 2009-01-01, 2011-04-27\
&nbsp;&nbsp;&nbsp;&nbsp;...

<ins>*Sample output:*</ins>\
&nbsp;&nbsp;&nbsp;&nbsp;143, 218, 8

## Solution
This is a small object-oriented WPF application based on the: MVVM pattern. \
You can choose a CSV file (from ```Test data``` directory in the repo) with input data, after that choose date format of the input data.\
At the end it calculates longest overlap and visualise the pair of employees, which has longest overlap on common projects for the longest period of time.

## Getting Started
**Application is supposed to be run using an Visual Studio 2022**

* In the Visual Studio, clone repository using the link ```https://github.com/RadoslavPanteleev/Radoslav-Panteleev-employees.git```
* Open Tools -> Command Line -> Developer PowerShell and type ```dotnet restore```, to restore the required NuGet libraries.
* Build -> Rebuild Solution
* To start the app:\
&nbsp;&nbsp;&nbsp;&nbsp;from Visual Studio: Debug -> Start Without Debuging\
&nbsp;&nbsp;&nbsp;&nbsp;from repo: ```bin\Debug\net8.0-windows\Employees.exe```

## Used technologies
* WPF
* .NET 8.0

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details
