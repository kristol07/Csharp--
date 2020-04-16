using EmployeeHealthInfoRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EmployeeHealthRecord.WFApp.v3
{
    public delegate bool DataValidator(string input);
    public delegate bool DataValidatorWithDatabase(string input, EmployeeRecords recordsDatabase);
    public delegate void UpdateView();

    public partial class MainForm : Form
    {
        readonly string GIN_NUMBER_TYPE_TIP;
        readonly string GIN_NUMBER_NOT_FOUND_TIP;

        private EmployeeRecords employeeRecords;

        IconsImageResource iconImageResource;
        ControlInputTipHelper tipHelper;
        WinFormAppInputValidator inputValidator;

        int treeViewType; // name: 0; date: 1

        public MainForm()
        {
            InitializeComponent();

            GIN_NUMBER_TYPE_TIP = "? Number Only"; //"Not valid GinNumber type (Integer)."; //"Only integer is allowed for ginNumber.";
            GIN_NUMBER_NOT_FOUND_TIP = "X Not Found"; //"No such GinNumber found.";//"Record of same GinNumber Not found.";

            employeeRecords = new EmployeeRecords();

            iconImageResource = new IconsImageResource();
            tipHelper = new ControlInputTipHelper();
            inputValidator = new WinFormAppInputValidator();

            UpdateTreeView();

            FilterRecords();
            UpdateAutoCompleteStringForFilterGinNumberTextBox();
            employeeDatabaseDataGridView.DataSource = employeeRecordBindingSource;

        }

        // Validate input with tipinfo
        public void ValidExistedGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            tipHelper.AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_NOT_FOUND_TIP, employeeRecords, inputValidator.IsValidExistedGinNumber);
            tipHelper.AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_TYPE_TIP, inputValidator.IsValidGinNumberType);
            tipHelper.ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, employeeRecords, inputValidator.IsValidExistedGinNumber);
        }

        // Update autocomplete source for textbox
        private void UpdateAutoCompleteStringForFilterGinNumberTextBox()
        {
            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeRecords.RecordsDatabase.Keys.ToArray());
            filterGinNumberTextBox.AutoCompleteCustomSource = existedGinNumber;
        }

        // update records status info
        private void UpdateRecordsStatus(List<EmployeeRecord> recordList)
        {
            List<EmployeeRecord> suspectRecords = recordList.FindAll(x => !string.IsNullOrEmpty(x.GetAbnormalInfo()));
            suspectRecordsNumberStatusLabel.Text = suspectRecords.Count.ToString();
            recordsStatisticsStatusLabel.Text = recordList.Count.ToString();
        }

        // data file operation

        private void ImportDatabaseFromFile()
        {
            ChangeStatusInfo("Loading...");

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string loadResult = EmployeeRecordsFileOperation.ReadDatabaseFromCSVFile(filePath, ref employeeRecords);

                switch (loadResult)
                {
                    case "success":
                        UpdateTreeView();
                        FilterRecords();
                        UpdateAutoCompleteStringForFilterGinNumberTextBox();
                        MessageBox.Show($"Database loading from {filePath} succeed.", "Loading Database", MessageBoxButtons.OK);
                        break;
                    case "formatError":
                        MessageBox.Show($"Format error in Database from {filePath}.", "Loading Database", MessageBoxButtons.OK);
                        break;
                    case "loadError":
                        MessageBox.Show($"Can not load file at {filePath}.", "Loading Database", MessageBoxButtons.OK);
                        break;
                    case "error":
                        MessageBox.Show($"Database loading from {filePath} operation failed.", "Loading Database", MessageBoxButtons.OK);
                        break;
                }
            }

            ChangeStatusInfo("Ready");
        }

        private void SaveDatabaseToFile()
        {
            ChangeStatusInfo("Saving...");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string saveResult = EmployeeRecordsFileOperation.SaveDatabaseToCSVFile(filePath, employeeRecords);

                switch (saveResult)
                {
                    case "done":
                        MessageBox.Show($"Database saving to {filePath} succeed", "Saving Database", MessageBoxButtons.OK);
                        break;
                    case "error":
                        MessageBox.Show($"Database saving to {filePath} failed, can not open file.", "Saving Database", MessageBoxButtons.OK);
                        break;
                    default:
                        MessageBox.Show($"Database saving to {filePath} operation failed.", "Saving Database", MessageBoxButtons.OK);
                        break;
                }
            }

            ChangeStatusInfo("Ready");
        }

        private void EditCurrentRecord()
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {
                ChangeStatusInfo("Editing...");

                string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                string checkDate = ((DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value).ToShortDateString();
                EmployeeRecord currentRecord = employeeRecords.GetEmployeeRecordGivenSpecificDate(ginNumber, checkDate);

                UpdateRecordForm editRecordForm = new UpdateRecordForm(employeeRecords, currentRecord, "Edit");
                editRecordForm.Text = "Edit Record";
                editRecordForm.updatedView += UpdateTreeView;
                editRecordForm.updatedView += FilterRecords;
                editRecordForm.updatedView += UpdateAutoCompleteStringForFilterGinNumberTextBox;
                editRecordForm.ShowDialog();

                ChangeStatusInfo("Ready");
            }
        }

        private void AddNewRecord()
        {
            ChangeStatusInfo("Working...");

            UpdateRecordForm addNewRecordForm = new UpdateRecordForm(employeeRecords, null, "Add");
            addNewRecordForm.Text = "Add New Record";
            addNewRecordForm.updatedView += UpdateTreeView;
            addNewRecordForm.updatedView += FilterRecords;
            addNewRecordForm.updatedView += UpdateAutoCompleteStringForFilterGinNumberTextBox;
            addNewRecordForm.ShowDialog();

            ChangeStatusInfo("Ready");
        }

        private void DeleteCurrentRecord()
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {
                ChangeStatusInfo("Deleting...");

                if (MessageBox.Show("You are trying to delete this record, are you sure?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                    DateTime checkDate = (DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value;
                    employeeRecords.RemoveRecord(ginNumber, checkDate.ToShortDateString());

                    UpdateTreeView();
                    FilterRecords();
                    UpdateAutoCompleteStringForFilterGinNumberTextBox();
                }

                ChangeStatusInfo("Ready");
            }
        }

        // status update
        private void ChangeStatusInfo(string description)
        {
            statusLabel.Text = description;

            string iconPath = iconImageResource.IconImagePath[description];
            statusLabel.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + iconPath);
        }

        // tree view

        private void ShowAndHideTreeView()
        {
            navigationBarPanel.Visible = !navigationBarPanel.Visible;
            if (navigationBarPanel.Visible == true)
            {
                contentPanel.Location = new Point(contentPanel.Location.X + navigationBarPanel.Width, contentPanel.Location.Y);
                contentPanel.Width -= recordsTreeView.Width;
            }
            else
            {
                contentPanel.Location = new Point(contentPanel.Location.X - navigationBarPanel.Width, contentPanel.Location.Y);
                contentPanel.Width += recordsTreeView.Width;
            }
        }

        private void UpdateTreeView()
        {
            if (treeViewType == 0)
            {
                ShowNameBasedTreeViewNodes();
            }
            else
            {
                ShowCheckDateBasedTreeViewNodes();
            }
        }

        private List<EmployeeRecord> GetRecordsOfSelectedTreeNodeUnderCheckDateBasedMode()
        {
            //Regex rx = new Regex(@"\d+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            TreeNode currentTreeNode = recordsTreeView.SelectedNode;
            if (currentTreeNode.Level == 0)
            {
                return employeeRecords.GetAllRecords();
            }
            else if (currentTreeNode.Level == 1)
            {
                int year = int.Parse(currentTreeNode.Text.Substring(6));
                List<EmployeeRecord> recordsWithSameYear = employeeRecords.GetAllRecords().FindAll(x => x.CheckDate.Year == year).ToList();
                return recordsWithSameYear;
            }
            else if (currentTreeNode.Level == 2)
            {
                int year = int.Parse(currentTreeNode.Parent.Text.Substring(6));
                int month = int.Parse(currentTreeNode.Text.Substring(7));
                List<EmployeeRecord> recordsWithSameYearAndMonth = employeeRecords.GetAllRecords().FindAll(x => x.CheckDate.Year == year && x.CheckDate.Month == month).ToList();
                return recordsWithSameYearAndMonth;
            }
            else
            {
                int year = int.Parse(currentTreeNode.Parent.Parent.Text.Substring(6));
                int month = int.Parse(currentTreeNode.Parent.Text.Substring(7));
                int day = int.Parse(currentTreeNode.Text.Substring(5));
                List<EmployeeRecord> recordsWithSameCheckDate = employeeRecords.GetAllRecords().FindAll(x => x.CheckDate.Year == year && x.CheckDate.Month == month && x.CheckDate.Day == day).ToList();
                return recordsWithSameCheckDate;
            }
        }

        private List<EmployeeRecord> GetRecordsOfSelectedTreeNodeUnderNameBasedMode()
        {
            TreeNode currentTreeNode = recordsTreeView.SelectedNode;
            if (currentTreeNode.Level == 0)
            {
                return employeeRecords.GetAllRecords();
            }
            else if (currentTreeNode.Level == 1) // name level 1
            {
                string name = currentTreeNode.Text;
                List<EmployeeRecord> recordsWithSameName = employeeRecords.GetAllRecords().FindAll(x => x.Name == name).ToList();
                return recordsWithSameName;
            }
            else // ginNumber level 2
            {
                string name = currentTreeNode.Parent.Text;
                string ginNumber = currentTreeNode.Text;
                List<EmployeeRecord> recordsWithSameNameAndGinNumber = employeeRecords.GetAllRecords().FindAll(x => x.Name == name && x.GinNumber == ginNumber).ToList();
                return recordsWithSameNameAndGinNumber;
            }
        }

        private List<EmployeeRecord> GetRecordsOfSelectedTreeNode()
        {

            if (treeViewType == 0) // name based treeview
            {
                return GetRecordsOfSelectedTreeNodeUnderNameBasedMode();
            }
            else // check date based treeview
            {
                return GetRecordsOfSelectedTreeNodeUnderCheckDateBasedMode();
            }
        }

        private void ShowNameBasedTreeViewNodes()
        {
            List<string> allNames = employeeRecords.GetAllRecords().Select(x => x.Name).Distinct().ToList();
            allNames.Sort();

            recordsTreeView.BeginUpdate();
            recordsTreeView.Nodes[0].Nodes.Clear();
            int i = 0;
            foreach (var name in allNames)
            {
                recordsTreeView.Nodes[0].Nodes.Add(name);
                List<string> allGinNumbersForSameName = employeeRecords.GetAllRecords().FindAll(x => x.Name == name)
                                                                                       .Select(x => x.GinNumber)
                                                                                       .Distinct().ToList();
                allGinNumbersForSameName.Sort();

                foreach (var ginNumber in allGinNumbersForSameName)
                {
                    recordsTreeView.Nodes[0].Nodes[i].Nodes.Add(ginNumber);
                }
                i++;
            }
            recordsTreeView.EndUpdate();

            recordsTreeView.SelectedNode = recordsTreeView.Nodes[0];
            recordsTreeView.ExpandAll();

            treeViewType = 0;
        }

        private void ShowCheckDateBasedTreeViewNodes()
        {
            List<DateTime> allDates = employeeRecords.GetAllRecords().Select(x => x.CheckDate).Distinct().ToList();
            allDates.Sort();

            recordsTreeView.BeginUpdate();

            recordsTreeView.Nodes[0].Nodes.Clear();

            List<int> allYears = allDates.Select(x => x.Year).Distinct().ToList();
            allYears.Sort();

            int i = 0;
            foreach (var year in allYears)
            {
                recordsTreeView.Nodes[0].Nodes.Add("Year: " + year.ToString());
                List<int> allMonthsForSameYear = allDates.FindAll(x => x.Year == year)
                                                         .Select(x => x.Month)
                                                         .Distinct().ToList();
                allMonthsForSameYear.Sort();
                int j = 0;
                foreach (var month in allMonthsForSameYear)
                {
                    recordsTreeView.Nodes[0].Nodes[i].Nodes.Add("Month: " + month.ToString());
                    List<int> allDaysForSameYearAndMonth = allDates.FindAll(x => x.Year == year && x.Month == month)
                                                                   .Select(x => x.Day)
                                                                   .Distinct().ToList();
                    allDaysForSameYearAndMonth.Sort();
                    foreach (var day in allDaysForSameYearAndMonth)
                    {
                        recordsTreeView.Nodes[0].Nodes[i].Nodes[j].Nodes.Add("Day: " + day.ToString());
                    }
                    j++;
                }
                i++;
            }

            recordsTreeView.EndUpdate();

            recordsTreeView.SelectedNode = recordsTreeView.Nodes[0];
            recordsTreeView.ExpandAll();

            treeViewType = 1;
        }

        /////////////// Filter Control Events /////////////////

        private void FilterGinNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidExistedGinNumberInputWithTipInfo(filterGinNumberTextBox, filterGinNumberTipLabel);

            //ClearHealthInfoInput();

            FilterRecords();
        }

        private void FilterDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterRecords();
        }

        private void ViewOnlySuspectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterRecords();
        }

        private void FilterCheckDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FilterRecords();
        }

        private void FilterCheckDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterRecords();
        }

        private void FilterRecords()
        {
            List<EmployeeRecord> filterBindingList = GetRecordsOfSelectedTreeNode();
            if (filterCheckDateCheckBox.Checked)
            {
                filterBindingList = filterBindingList.FindAll(x => x.CheckDate.ToShortDateString() == filterCheckDateTimePicker.Value.ToShortDateString());
            }

            if (viewOnlySuspectCheckBox.Checked)
            {
                filterBindingList = filterBindingList.FindAll(x => !string.IsNullOrEmpty(x.GetAbnormalInfo()));
            }

            string ginNumber = filterGinNumberTextBox.Text.Trim();
            if (inputValidator.IsValidExistedGinNumber(ginNumber, employeeRecords))
            {
                filterBindingList = filterBindingList.FindAll(x => x.GinNumber == ginNumber);
            }

            // status bar: records statistics
            UpdateRecordsStatus(filterBindingList);

            // update datagrid view/source
            employeeRecordBindingSource.DataSource = EmployeeRecords.TransformRecordListToBindingSource(filterBindingList.ToArray());
        }

        ///////////////// Menu Strips ///////////////////

        private void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabaseFromFile();
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveDatabaseToFile();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewRecordMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        private void EditRecordMenuItem_Click(object sender, EventArgs e)
        {
            EditCurrentRecord();
        }

        private void DeleteRecordMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCurrentRecord();
        }

        private void NameBasedMenuItem_Click(object sender, EventArgs e)
        {
            ShowNameBasedTreeViewNodes();
            FilterRecords();
        }

        private void CheckDateBasedMenuItem_Click(object sender, EventArgs e)
        {
            ShowCheckDateBasedTreeViewNodes();
            FilterRecords();
        }

        private void TreeViewStatusMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndHideTreeView();
        }

        private void ViewOnlySuspectsMenuItem_Click(object sender, EventArgs e)
        {
            viewOnlySuspectCheckBox.Checked = true;
            FilterRecords();
        }

        private void ViewCodeMenuItem_Click(object sender, EventArgs e)
        {
            // HACK
            System.Diagnostics.Process.Start("https://github.com/kristol07/Csharp--/tree/master/EmployeeHealthRecord.WFApp.v3");
        }

        private void AboutHealthRecorderMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
            //MessageBox.Show("This is an application for helping recording and management of employee health info during the outbreak of COVID-19.", "About Employee Health Recorder");
        }

        ///////////////// ContextMenu Strips ////////////////

        private void ViewOnlySuspectEployeeContextMenuItem_Click(object sender, EventArgs e)
        {
            viewOnlySuspectCheckBox.Checked = true;
            FilterRecords();
        }

        private void ViewAllEmployeesContextMenuItem_Click(object sender, EventArgs e)
        {
            viewOnlySuspectCheckBox.Checked = false;
            FilterRecords();
        }

        private void ImportFromFileContextpMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabaseFromFile();
        }

        private void SaveAsContextMenuItem_Click(object sender, EventArgs e)
        {
            SaveDatabaseToFile();
        }

        private void AddNewRecordContextMenuItem_Click(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        private void DeleteCurrentRecordContextMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCurrentRecord();
        }

        private void EditCurrentRecordContextMenuItem_Click(object sender, EventArgs e)
        {
            EditCurrentRecord();
        }

        private void OpenSidebarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndHideTreeView();
        }

        //////////////// Tool Strips /////////////////////

        private void ImportRecordsToolStripButton_Click(object sender, EventArgs e)
        {
            ImportDatabaseFromFile();
        }

        private void SaveRecordsToolStripButton_Click(object sender, EventArgs e)
        {
            SaveDatabaseToFile();
        }

        private void AddRecordToolStripButton_Click(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        private void EditRecordToolStripButton_Click(object sender, EventArgs e)
        {
            EditCurrentRecord();
        }

        private void DeleteRecordToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteCurrentRecord();
        }

        private void NameBasedTreeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNameBasedTreeViewNodes();
            FilterRecords();
        }

        private void CheckDateBasedTreeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCheckDateBasedTreeViewNodes();
            FilterRecords();
        }

        private void SwitchTreeviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndHideTreeView();
        }

        private void SearchToolStripTextBox_Click(object sender, EventArgs e)
        {
            SearchToolStripTextBox.ForeColor = Color.Black;
            SearchToolStripTextBox.Text = "";
        }

        private void SearchToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            // UNDONE
        }

        private void SearchToolStripTextBox_Leave(object sender, EventArgs e)
        {
            SearchToolStripTextBox.ForeColor = Color.Gray;
            SearchToolStripTextBox.Text = "Search By GinNumber & CheckDate";
        }

        ///////////////// status strip //////////////////////

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeStatusLabel.Text = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        ////////////////// tree view ////////////////////////

        private void RecordsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FilterRecords();
        }

        private void NameBasedContextMenuItem_Click(object sender, EventArgs e)
        {
            ShowNameBasedTreeViewNodes();
            FilterRecords();
        }

        private void CheckDateBasedContextMenuItem_Click(object sender, EventArgs e)
        {
            ShowCheckDateBasedTreeViewNodes();
            FilterRecords();
        }

        private void OpenCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAndHideTreeView();
        }

    }
}
