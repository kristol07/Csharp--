## Project: Daily Health Monitor Windows Application

A Windows GUI application for recording daily health in convenience.

  - [Video & Screenshots](#video--screenshots)
  - [Features](#features)
    - [Special Requirements](#special-requirements)
    - [Shortcuts](#shortcuts)
    - [To do](#to-do)
  - [Installation](#installation)
    - [Prerequisites](#prerequisites)
  - [Developer Documentation](#developer-documentation)
    - [Getting Started](#getting-started)
    - [Testing](#testing)
      - [GUI Test](#gui-test)
      - [Unit Test](#unit-test)
  - [Bugs and Feature Requests](#bugs-and-feature-requests)

### Video & Screenshots

[Video](Presentation-video.mp4)
|
![Main form](imgs/MainForm.png)
|
![Record Detail Form - add/edit](imgs/edit.png)

### Features

- Basic
  - Load Database From csv/txt file
  - Save Database to csv/txt file
  - Add new record
  - Edit selected record
  - Delete selected record
- Search & Filter Records by
  - GinNumber
  - Check Date
  - Suspect records
  - Name (through navigation sidebar)
- GUI
  - Switch Treeview navigation sidebar
  - Context menus inside navigation sidebar and datagrid table
  - Working status & records statistics auto-update in status bar
  - key shortcuts & access key support

#### Special Requirements

- Cannot add new record which has conflict with existed records in case of
   - same ginNumber & same checkdate
   - same ginNumber but different name (ginNumber-name consistency)
- Cannot save edited record if:
  - has conflict with existed records
  - ginNumber or checkdate changed, and name is also changed (name can only be changed if ginNumber & checkdate are untouched.)

#### Shortcuts

- `Ctrl+Shift+O` - Load database from file
- `Ctrl+Shift+S` - Save database to file
- `ctrl+Alt+N` - Change to name-based navigation sidebar
- `Ctrl+Alt+D` - Change to date-based navigation sidebar
- `Ctrl+Alt+Space` - Switch navigation sidebar
- `Ctrl+Alt+S` - Filter only suspect records
- `Ctrl+A` - Add new record
- `Ctrl+E` - Edit current selected record
- `Ctrl+D` - Delete current selected record
- `Ctrl+D1` - Open external browser and redirect to source repository
- `Ctrl+Q` - Exit program

#### To do

- [ ] Search textbox function
- [ ] EditHistory property in record
- [ ] Improve datagrid table and treeview sidebar redraw speed when database is large
- [ ] "About" form (TBC)
- [ ] Integration Tests and Unit Tests (TBC)

### Installation

#### Prerequisites

Make sure you have `.Net Framework 4.x` installed.

To be continued.... (no release version for now)

### Developer Documentation

This application is built with [Windows Forms programming](https://docs.microsoft.com/en-us/dotnet/framework/winforms/), and (default) IDE
[Visual Studio](https://visualstudio.microsoft.com/vs/compare/) is required for development.

#### Getting Started

Clone the repo

```shell
$ git clone git@github.com:kristol07/Csharp--.git
```

, open the solution file `Csharp--/EmployeeHealthRecord.WFApp.v3/EmployeeHealthRecord.WFApp.v3.sln` with Visual Studio, and build the program.

The solution includes two projects:
- `EmployeeHealthInfoRecord` generating the **class library** used by GUI program. Input validator, data model and file operation handling are declared in this project. See detail [here](../EmployeeHealthInfoRecord/README.md).
- `EmployeeHealthRecord.WFApp.v3` generating the **GUI program**. Use Visual Studio Designer to view or redesign `Main Form` and `Record Detail Form`.

#### Testing

All test codes or documents are saved in `Csharp--\EmployeeHealthInfoRecord.Tests`.

##### GUI Test

You can find test case documents under directory `TestCaseDocument`. Follow test cases and use different databases under directory `TestData` to test the GUI program. (Use the most updated test case design, i.e., test cases in Xmind file.)

You can also use codes under directory `RecordRandomGenerator` to generate new test database.

##### Unit Test

```shell
$ cd Csharp--\EmployeeHealthInfoRecord.Tests

$ dotnet test # Run the test

$ ./GenerateCodeCoverageReport.bat # use .bat file to generate code coverage report automatically
```

### Bugs and Feature Requests

Open new issue [here](https://github.com/kristol07/Csharp--/issues). 
(See [help](https://help.github.com/en/github/managing-your-work-on-github/creating-an-issue) for how to create issue in Github.)