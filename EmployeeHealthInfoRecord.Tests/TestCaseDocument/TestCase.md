- Test Suite ID:
- Test Case ID: 01
- Test Case Summary: To verify that clicking the Load button could import database from file.
- Related Requirement:
- Prerequisites: 
  - file is accessible
  - file has correct format
  - database saved in file has no error
- Test Procedure:
  1. Click the Load button in the form
  2. Select the file to import in the pop-up dialog and confirm
- Test Data:
  - csv/txt file with correct format of data and also accessible
  - file with wrong file type
  - csv/txt file with wrong format of data
  - csv/txt file inaccssible (opened by other applications)
- Expected Result:
  - Only csv/txt file accessible with correct format of data can be imported to form, and a successful message box is popped up after confirm
  - A message indicating error for importing pops up, and no table is displayed in the form
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:

---

- Test Suite ID:
- Test Case ID: 02
- Test Case Summary: To verify that clicking the Save button could save database to file.
- Related Requirement:
- Prerequisites: 
  - file is accessible
  - file has correct format
- Test Procedure:
  1. Click the Save button in the form
  2. Select the file to save to in the pop-up dialog Or Input new file name and confirm
- Test Data:
  - existed csv/txt file accessible
  - new file
  - file inaccssible (opened by other applications)
- Expected Result:
  - database can only be saved to existed csv/txt file accessible or new file, and a successful message box is popped up after confirm
  - A message indicating error for saving pops up
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:

---

- Test Suite ID:
- Test Case ID: 03
- Test Case Summary: To verify that add button can add record to database
- Related Requirement:
- Prerequisites:
  - input is all valid and non-empty
  - record with same ginNumber and checkdate does not exist
  - existed ginNumber with different name could not be added
- Test Procedure:
  1. Click the Add button in the form and a new form is popped up
  2. Finish the input of different items and click save button to confirm
- Test Data:
  - new record with consistent name
  - record collide with existed records
  - new record with inconsistent name
  - record with invalid input
- Expected Result:
  - only new record with consistent name is added to database. and a messagebox is popped up to inform user
  - record with invalid input will not be added to database when save button is clicked, and tip labels will show for all those invalid inputs
  - record colliding with existed records or new record with inconsistent name will not be added to database when save button is clicked, and messagebox for advising user to edit but not add is popped up
  - when cancel button is clicked, the new form is closed and main form has no change
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:

---

- Test Suite ID:
- Test Case ID: 04
- Test Case Summary: To verify that edit button can edit existed record
- Related Requirement:
- Prerequisites:
  - record row is selected in the table
  - new inputs are valid and do not collide with existed records
- Test Procedure:
  1. Click the Edit button in the form and a new record detail form is popped up
  2. Finish the input of different items and click save button to confirm edit
- Test Data:
  - at least ginNumber and check date not changed
  - change record to other existed records
  - new record with new ginNumber
  - new record wit existed GinNumber
    - new name
    - same name
  - invalid input items
- Expected Result:
  - when ginNumber and check date not changed, all changes on other items are accepted
  - when changed to existed records, not allowed, an error messagebox pops up
  - when changed to new record with new ginNumber, all changes are accepted
  - when changed to new record with existed GinNumber, if name is changed, not allowed and error messagebox pops up; if name not changed, all other changes are accepted.
  - when inputs are not all valid, nothing happens when save button is clicked, except for tip labels information.      
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:

---

- Test Suite ID:
- Test Case ID: 05
- Test Case Summary: To verify that remove button can remove existed record
- Related Requirement:
- Prerequisites:
  - record row is selected in the table
- Test Procedure:
  1. Click the Remove button in the form and a confirm messagebox is popped up
- Test Data:
  - Any single record
- Expected Result:
  - when OK choice is clicked for confirm messagebox, the selected record is removed from database; table and treeview are updated.
  - when Cancel choice is clicked, messagebox closed and nothing happens.
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:


---

- Test Suite ID:
- Test Case ID: 06
- Test Case Summary: To verify that all filters work
- Related Requirement:
- Prerequisites:
  - Database is loaded
- Test Procedure:
  1. Input GinNumber in textbox for searching and filtering
  2. check Suspect checkbox for viewing only suspect records
  3. check checkdate checkbox for viewing only records recorded in that day
  4. Choose different combinations of filters
- Test Data:
  - database with different records of different checkdates, ginNumbers, etc
- Expected Result:
  - Only records with same ginNumber are showed in table if text in GinNumber textbox is valid existed ginNumber
  - Only records with same check date are showed in table if checkdate checkbox is checked and the date is valid check date in database
  - Only suspect records are showed in table if suspect checkbox is checked
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:

---

- Test Suite ID:
- Test Case ID: 07
- Test Case Summary: To verify that treeview selection work as a filter
- Related Requirement:
- Prerequisites:
  - Database is loaded
- Test Procedure:
  1. select different tree nodes for viewing corresponding records
- Test Data:
  - database with different records of different checkdates, ginNumbers, etc
- Expected Result:
  - In checkdate-based treeview mode, if one tree node is selected, only records with same checkdate will be showed in table
  - In name-based treeview mode, if one tree node is selected, only records with same name&GinNumber will be showed in table 
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:

---

- Test Suite ID:
- Test Case ID: 08
- Test Case Summary: To verify that treeview bar can be open/close normally
- Related Requirement:
- Prerequisites:
- Test Procedure:
  1. click switch button to open/close treeview bar
  2. right click inside treeview panel, and choose closing bar
  3. right click inside records table panel, and choose openning the bar
- Test Data:
- Expected Result:
  - The switch button could open/close the treeview bar at any time
  - When treeview is shown, right click inside treeview panel and choose click will close the treeview, and records table will be extended to the left of main form
  - Right click inside records table panel and choose open/close will open/close the treeview, the layouts size will also change automaticlly
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:

---

- Test Suite ID:
- Test Case ID: 09
- Test Case Summary: To verify that "view code" can open browser and open github repo normally
- Related Requirement:
- Prerequisites:
- Test Procedure:
  1. click "view code" menu item to see whether browser and github repo link are opened
- Test Data:
- Expected Result:
  - Browser is opened and redirected to the github source code repo 
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment:

---

- Test Suite ID:
- Test Case ID: 10
- Test Case Summary: To verify that all shortcuts work normally
- Related Requirement:
- Prerequisites:
- Test Procedure:
  1. use different shortcuts to check whether those functions are invoked
- Test Data:
- Expected Result:
  - different functions are invoked when using shortcuts labeled in menu items
- Actual Result:
- Status:
- Remarks:
- Created by:
- Date of Creation:
- Executed by:
- Date of Execution:
- Test environment: