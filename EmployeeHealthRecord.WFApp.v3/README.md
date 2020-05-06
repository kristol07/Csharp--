## Project: Daily Health Monitor Windows Application

A Windows GUI application for recording daily health of special groups of people.


### Screenshots:

![Main form](imgs/MainForm.png)
|
![Record Detail Form - add/edit](imgs/edit.png)

### Features:

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

#### Special Requirements:

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

#### To do:

- [ ] Search textbox function
- [ ] EditHistory property in record
- [ ] Improve datagrid table and treeview sidebar redraw speed when database is large
- [ ] "About" form (TBC)
- [ ] Integration Tests and Unit Tests (TBC)

### Installation

#### Prerequisites

Make sure you have `.Net Framework 4.x` installed.



### User Documentation

### Developer Documentation

#### Getting Started

#### Testing

