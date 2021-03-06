﻿using EmployeeHealthInfoRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
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

        CultureInfo cultureInfo;

        public MainForm()
        {
            cultureInfo = new CultureInfo("en-US");

            InitializeComponent();

            GIN_NUMBER_TYPE_TIP = "? Number Only"; //"Not valid GinNumber type (Integer)."; //"Only integer is allowed for ginNumber.";
            GIN_NUMBER_NOT_FOUND_TIP = "X Not Found"; //"No such GinNumber found.";//"Record of same GinNumber Not found.";

            employeeRecords = new EmployeeRecords();

            iconImageResource = new IconsImageResource();
            tipHelper = new ControlInputTipHelper();
            inputValidator = new WinFormAppInputValidator();

            UpdateTreeView();

            FilterRecords();
            UpdateAutoSuggestionForFilterGinNumberTextBox();
            employeeDatabaseDataGridView.DataSource = employeeRecordBindingSource;

        }

        public BindingList<EmployeeRecord> TransformRecordListToBindingSource(params EmployeeRecord[] arrayOfRecords)
        {
            BindingList<EmployeeRecord> recordList = new BindingList<EmployeeRecord>();

            foreach (var record in arrayOfRecords)
            {
                recordList.Add(record);
            }

            return recordList;
        }

        // Validate input with tipinfo
        public void ValidExistedGinNumberInputWithTipInfo(TextBox textbox, Label tipLabel)
        {
            tipHelper.AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_NOT_FOUND_TIP, employeeRecords, inputValidator.IsValidExistedGinNumber);
            tipHelper.AddTipInfoForInvalidInput(textbox, tipLabel, GIN_NUMBER_TYPE_TIP, inputValidator.IsValidGinNumberType);
            tipHelper.ClearTipInfoWhenInputIsEmptyOrValid(textbox, tipLabel, employeeRecords, inputValidator.IsValidExistedGinNumber);
        }

        // Update autocomplete source for textbox
        private void UpdateAutoSuggestionForFilterGinNumberTextBox()
        {
            AutoCompleteStringCollection existedGinNumber = new AutoCompleteStringCollection();
            existedGinNumber.AddRange(employeeRecords.RecordsDatabase.Keys.ToArray());
            filterGinNumberTextBox.AutoCompleteCustomSource = existedGinNumber;
        }

        // update records statistics info
        private void UpdateRecordsStatistics(List<EmployeeRecord> recordList)
        {
            List<EmployeeRecord> suspectRecords = recordList.FindAll(x => !string.IsNullOrEmpty(x.GetAbnormalInfo()));
            suspectRecordsNumberStatusLabel.Text = suspectRecords.Count.ToString();
            recordsStatisticsStatusLabel.Text = recordList.Count.ToString();
        }

        // data file operation

        private void ImportDatabaseFromFile()
        {
            UpdateStatusInfo("Loading...");

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string loadResult = EmployeeRecordsFileOperation.ReadDatabaseFromCSVFile(filePath, ref employeeRecords);

                switch (loadResult)
                {
                    case "success":
                        UpdateTreeView();
                        FilterRecords();
                        UpdateAutoSuggestionForFilterGinNumberTextBox();
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

            UpdateStatusInfo("Ready");
        }

        private void SaveDatabaseToFile()
        {
            UpdateStatusInfo("Saving...");

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

            UpdateStatusInfo("Ready");
        }

        private void EditCurrentRecord()
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {
                UpdateStatusInfo("Editing...");

                string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                string checkDate = ((DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value).ToShortDateString();
                EmployeeRecord currentRecord = employeeRecords.GetEmployeeRecordGivenGinNumberAndCheckDate(ginNumber, checkDate);

                UpdateRecordForm editRecordForm = new UpdateRecordForm(employeeRecords, currentRecord, "Edit");
                editRecordForm.Text = "Edit Record";
                editRecordForm.updatedView += UpdateTreeView;
                editRecordForm.updatedView += FilterRecords;
                editRecordForm.updatedView += UpdateAutoSuggestionForFilterGinNumberTextBox;
                editRecordForm.ShowDialog();

                UpdateStatusInfo("Ready");
            }
        }

        private void AddNewRecord()
        {
            UpdateStatusInfo("Working...");

            UpdateRecordForm addNewRecordForm = new UpdateRecordForm(employeeRecords, null, "Add");
            addNewRecordForm.Text = "Add New Record";
            addNewRecordForm.updatedView += UpdateTreeView;
            addNewRecordForm.updatedView += FilterRecords;
            addNewRecordForm.updatedView += UpdateAutoSuggestionForFilterGinNumberTextBox;
            addNewRecordForm.ShowDialog();

            UpdateStatusInfo("Ready");
        }

        private void DeleteCurrentRecord()
        {
            if (employeeDatabaseDataGridView.SelectedRows.Count != 0)
            {
                UpdateStatusInfo("Deleting...");

                if (MessageBox.Show("You are trying to delete this record, are you sure?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string ginNumber = (string)employeeDatabaseDataGridView.SelectedRows[0].Cells[0].Value;
                    DateTime checkDate = (DateTime)employeeDatabaseDataGridView.SelectedRows[0].Cells[2].Value;
                    employeeRecords.RemoveRecord(ginNumber, checkDate.ToShortDateString());

                    UpdateTreeView();
                    FilterRecords();
                    UpdateAutoSuggestionForFilterGinNumberTextBox();
                }

                UpdateStatusInfo("Ready");
            }
        }

        // status update
        private void UpdateStatusInfo(string description)
        {
            statusLabel.Text = description;

            string iconPath = iconImageResource.IconImagePath[description];
            statusLabel.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + iconPath);
        }

        // tree view

        private void SwitchTreeViewSideBar()
        {
            mainSplitContainer.Panel1Collapsed = !mainSplitContainer.Panel1Collapsed;
        }

        private void UpdateTreeView()
        {
            if (treeViewType == 0)
            {
                DrawNameBasedTreeView();
            }
            else
            {
                DrawCheckDateBasedTreeView();
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
                int year = int.Parse(currentTreeNode.Text);
                List<EmployeeRecord> recordsWithSameYear = employeeRecords.GetAllRecords()
                                                                          .FindAll(x => x.CheckDate.Year == year)
                                                                          .ToList();
                return recordsWithSameYear;
            }
            else if (currentTreeNode.Level == 2)
            {
                int year = int.Parse(currentTreeNode.Parent.Text);
                string month = currentTreeNode.Text;
                List<EmployeeRecord> recordsWithSameYearAndMonth = employeeRecords.GetAllRecords()
                                                                                  .FindAll(x => x.CheckDate.Year == year 
                                                                                                && cultureInfo.DateTimeFormat.GetMonthName(x.CheckDate.Month) == month)
                                                                                  .ToList();
                return recordsWithSameYearAndMonth;
            }
            else
            {
                int year = int.Parse(currentTreeNode.Parent.Parent.Text);
                string month = currentTreeNode.Parent.Text;
                int day = int.Parse(currentTreeNode.Text);
                List<EmployeeRecord> recordsWithSameCheckDate = employeeRecords.GetAllRecords()
                                                                               .FindAll(x => x.CheckDate.Year == year 
                                                                                             && cultureInfo.DateTimeFormat.GetMonthName(x.CheckDate.Month) == month 
                                                                                             && x.CheckDate.Day == day)
                                                                               .ToList();
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
            else if (currentTreeNode.Level == 1) // first char level 1
            {
                string firstChar = currentTreeNode.Text;
                List<EmployeeRecord> recordsWithSameName = employeeRecords.GetAllRecords()
                                                                          .FindAll(x => x.Name.ElementAt(0).ToString().ToUpper() == firstChar)
                                                                          .ToList();
                return recordsWithSameName;
            }
            else // name+ginNumber level 2
            {
                string firstChar = currentTreeNode.Parent.Text;
                string ginNumber = currentTreeNode.Text.Split('_')[1];
                List<EmployeeRecord> recordsWithSameNameAndGinNumber = employeeRecords.GetAllRecords()
                                                                                      .FindAll(x => x.Name.ElementAt(0).ToString().ToUpper() == firstChar 
                                                                                                    && x.GinNumber == ginNumber)
                                                                                      .ToList();
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

        private TreeNode SearchPreviousSelectedNode(string previousSelectedNodeName)
        {
            TreeNode[] nodes = recordsTreeView.Nodes.Find(previousSelectedNodeName, true);

            return nodes.Length > 0 ? nodes[0] : recordsTreeView.Nodes[0];
        }

        private void DrawNameBasedTreeView()
        {
            List<string> allFirstCharInName = employeeRecords.GetAllEmployees().Select(x => x.Name.ElementAt(0).ToString().ToUpper()).Distinct().ToList();
            allFirstCharInName.Sort();

            string previousSelectedNodeName = recordsTreeView.SelectedNode == null ? "All Records" : recordsTreeView.SelectedNode.Name;

            recordsTreeView.BeginUpdate();
            recordsTreeView.Nodes[0].Nodes.Clear();
            int i = 0;
            foreach (var firstChar in allFirstCharInName)
            {
                recordsTreeView.Nodes[0].Nodes.Add(firstChar.ToString());
                recordsTreeView.Nodes[0].Nodes[i].Name = firstChar.ToString(); // add Name property for search previous selected node

                List<Employee> allEmployeeWithSameFirstChar = employeeRecords.GetAllEmployees().FindAll(x => x.Name.ElementAt(0).ToString().ToUpper() == firstChar);
                allEmployeeWithSameFirstChar.Sort();
                List<string> allGinNumbersForSameFirstChar = allEmployeeWithSameFirstChar.Select(x => x.GinNumber).ToList();

                int j = 0;
                foreach (var ginNumber in allGinNumbersForSameFirstChar)
                {
                    string labelText = employeeRecords.GetEmployeeGivenGinNumber(ginNumber).Name + "_" + ginNumber;
                    recordsTreeView.Nodes[0].Nodes[i].Nodes.Add(labelText);
                    recordsTreeView.Nodes[0].Nodes[i].Nodes[j].Name = labelText;
                    j++;
                }
                i++;
            }
            recordsTreeView.EndUpdate();

            recordsTreeView.SelectedNode = SearchPreviousSelectedNode(previousSelectedNodeName);
            recordsTreeView.ExpandAll();

            treeViewType = 0;
        }

        private void DrawCheckDateBasedTreeView()
        {
            List<DateTime> allDates = employeeRecords.GetAllRecords().Select(x => x.CheckDate).Distinct().ToList();
            allDates.Sort();

            string previousSelectedNodeName = recordsTreeView.SelectedNode == null ? "All Records" : recordsTreeView.SelectedNode.Name;

            recordsTreeView.BeginUpdate();

            recordsTreeView.Nodes[0].Nodes.Clear();

            List<int> allYears = allDates.Select(x => x.Year).Distinct().ToList();
            allYears.Sort();

            int i = 0;
            foreach (var year in allYears)
            {
                recordsTreeView.Nodes[0].Nodes.Add(year.ToString());
                recordsTreeView.Nodes[0].Nodes[i].Name = year.ToString();
                List<int> allMonthsForSameYear = allDates.FindAll(x => x.Year == year)
                                                         .Select(x => x.Month)
                                                         .Distinct().ToList();
                allMonthsForSameYear.Sort();
                int j = 0;
                foreach (var month in allMonthsForSameYear)
                {
                    recordsTreeView.Nodes[0].Nodes[i].Nodes.Add(cultureInfo.DateTimeFormat.GetMonthName(month));
                    recordsTreeView.Nodes[0].Nodes[i].Nodes[j].Name = year.ToString() + "-" + cultureInfo.DateTimeFormat.GetMonthName(month);
                    List<int> allDaysForSameYearAndMonth = allDates.FindAll(x => x.Year == year && x.Month == month)
                                                                   .Select(x => x.Day)
                                                                   .Distinct().ToList();
                    allDaysForSameYearAndMonth.Sort();
                    int k = 0;
                    foreach (var day in allDaysForSameYearAndMonth)
                    {
                        recordsTreeView.Nodes[0].Nodes[i].Nodes[j].Nodes.Add(day.ToString());
                        recordsTreeView.Nodes[0].Nodes[i].Nodes[j].Nodes[k].Name = year.ToString() + "-" + cultureInfo.DateTimeFormat.GetMonthName(month) + "-" + day.ToString();
                        k++;
                    }
                    j++;
                }
                i++;
            }

            recordsTreeView.EndUpdate();

            recordsTreeView.SelectedNode = SearchPreviousSelectedNode(previousSelectedNodeName);
            recordsTreeView.ExpandAll();

            treeViewType = 1;
        }

        private void DeleteRecordsUnderSelectedNode()
        {
            if(employeeDatabaseDataGridView.Rows.Count != 0)
            {
                string nameOfCurrentSelectedNode = recordsTreeView.SelectedNode.Name;
                if (MessageBox.Show($"You are trying to delete all records for the selected node \"{nameOfCurrentSelectedNode}\", are you sure?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<EmployeeRecord> selectedRecords = GetRecordsOfSelectedTreeNode();
                    foreach (var record in selectedRecords)
                    {
                        employeeRecords.RemoveRecord(record.GinNumber, record.CheckDate.ToShortDateString());
                    }

                    UpdateTreeView();
                    FilterRecords();
                    UpdateAutoSuggestionForFilterGinNumberTextBox();
                }
            }
        }

        /////////////// Filter Control Events /////////////////

        private void FilterGinNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidExistedGinNumberInputWithTipInfo(filterGinNumberTextBox, filterGinNumberTipLabel);

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
            //filterBindingList.Sort();
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
            UpdateRecordsStatistics(filterBindingList);

            // update datagrid view/source
            employeeRecordBindingSource.DataSource = TransformRecordListToBindingSource(filterBindingList.ToArray());
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
            DrawNameBasedTreeView();
            FilterRecords();
        }

        private void CheckDateBasedMenuItem_Click(object sender, EventArgs e)
        {
            DrawCheckDateBasedTreeView();
            FilterRecords();
        }

        private void TreeViewStatusMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTreeViewSideBar();
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
            SwitchTreeViewSideBar();
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
            DrawNameBasedTreeView();
            FilterRecords();
        }

        private void CheckDateBasedTreeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawCheckDateBasedTreeView();
            FilterRecords();
        }

        private void SwitchTreeviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTreeViewSideBar();
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
            DrawNameBasedTreeView();
            FilterRecords();
        }

        private void CheckDateBasedContextMenuItem_Click(object sender, EventArgs e)
        {
            DrawCheckDateBasedTreeView();
            FilterRecords();
        }

        private void DeleteNodeContextMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRecordsUnderSelectedNode();
        }

        private void OpenCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTreeViewSideBar();
        }

        private void DeleteSelectedNodeMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRecordsUnderSelectedNode();
        }

        private void DeleteSelectedNodeToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteRecordsUnderSelectedNode();
        }
    }
}
