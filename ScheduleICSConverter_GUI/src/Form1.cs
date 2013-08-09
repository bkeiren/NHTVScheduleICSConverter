using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace SchoolScheduleICSConverter_GUI
{
    public partial class Form1 : Form
    {
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_ACCESS_DENIED = 5;

        System.Threading.SynchronizationContext formSynchronizationContext;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formSynchronizationContext = WindowsFormsSynchronizationContext.Current;

            checkBox1.Checked = true;

            int CurrentYear = DateTime.Now.Year;
            int StartYearOfComboBox = 2012;
            int EndYearOfComboBox = 3000;
            for (int i = StartYearOfComboBox; i <= EndYearOfComboBox; ++i)
            {
                StartOfSchoolYear.Items.Add(i.ToString());
                if (i == CurrentYear)
                {
                    StartOfSchoolYear.SelectedIndex = i - StartYearOfComboBox - ((DateTime.Now.Month <= 7)?(1):(0));
                }
            }

            for (int i = 0; i <= 52; ++i)
            {
                SchoolWeekRangeStart.Items.Add(i.ToString());
                SchoolWeekRangeEnd.Items.Add(i.ToString());
            }
            SchoolWeekRangeStart.SelectedIndex = 0;
            SchoolWeekRangeEnd.SelectedIndex = 52;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = ClassSelection.SelectedItems;
            if (selectedItems.Count <= 0)
            {
                MessageBox.Show("You haven't selected any classes yet.", "Notice");
                return;
            }
            else
            {
                object[] selectedItemsArray = new object[selectedItems.Count];
                selectedItems.CopyTo(selectedItemsArray, 0);
                WorkerData workerData = new WorkerData();
                workerData.classes = selectedItemsArray;
                workerData.startyear = StartOfSchoolYear.Text.ToString();
                workerData.startweek = SchoolWeekRangeStart.Text.ToString();
                workerData.endweek= SchoolWeekRangeEnd.Text.ToString();
                button6.Enabled = true;
                backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerThreadCompleted);
                button2.Enabled = false;
                backgroundWorker1.RunWorkerAsync(workerData);
            }            
        }

        private void WorkerThreadCompletedMainThread( object obj )
        {
            RunWorkerCompletedEventArgs eventArgs = (RunWorkerCompletedEventArgs)obj;

            progressBar1.Value = 0;
            if (eventArgs.Cancelled)
            {
                toolStripStatusLabel1.Text = "Cancelled";
                Log.Info("Background Worker was cancelled");
            }
            else
            {
                if (eventArgs.Error != null)    // This is null when eventArgs.Cancelled, so we don't have to check there.
                {
                    toolStripStatusLabel1.Text = "Error: " + eventArgs.Error.Message;
                    Log.Error("Background Worker resulted in an error: " + eventArgs.Error.Message + " -- Stack trace: " + eventArgs.Error.StackTrace);
                }
                else
                {
                    toolStripStatusLabel1.Text = "Done";
                    Log.Info("Background Worker completed successfully");
                }
            }
            button6.Enabled = false;

            if (checkBox1.Checked)
            {
                try
                {
                    OpenOutputFolder();
                }
                catch (Win32Exception exception)
                {
                    switch (exception.NativeErrorCode)
                    {
                        case ERROR_FILE_NOT_FOUND:
                            {
                                string msg = "Could not open output folder";
                                toolStripStatusLabel1.Text = msg;
                                Log.Error(msg);
                                break;
                            }
                        case ERROR_ACCESS_DENIED:
                            {
                                string msg = "System denied access to output folder";
                                toolStripStatusLabel1.Text = msg;
                                Log.Error(msg);
                                break;
                            }
                        default:
                            {
                                string msg = "Something went wrong while opening the output folder (" + exception.NativeErrorCode + ")";
                                toolStripStatusLabel1.Text = msg;
                                Log.Error(msg);
                                break;
                            }
                    }
                }
            }

            button2.Enabled = true;
        }

        private void WorkerThreadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            formSynchronizationContext.Post(this.WorkerThreadCompletedMainThread, e);
        }

        private void UpdateProgressBar( object obj )
        {
            progressBar1.Value = (int)obj;
        }

        private void SelectOrDeselectEntireClassSelection( bool _SelectAll )
        {
            for (int i = 0; i < ClassSelection.Items.Count; ++i)
            {
                ClassSelection.SetSelected(i, _SelectAll);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectOrDeselectEntireClassSelection(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectOrDeselectEntireClassSelection(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void workerThreadException( object obj )
        {
            string status = (string)obj;
            toolStripStatusLabel1.Text = status;
            Log.Error("Background Worker raised an exception: " + status);
        }

        private void ReportWorkerThreadStatus( object obj )
        {
            string msg = (string)obj;
            toolStripStatusLabel1.Text = "Progress: " + msg;
            Log.Info("Background Worker progress: " + msg);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            WorkerData workerData = (WorkerData)e.Argument;
            object[] selectedItems = workerData.classes;
            int i = 0;
            foreach (object selectedItem in selectedItems)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                ++i;
                string classCode = selectedItem.ToString()/*.Replace(" ", "%20")*/;

                if (classCode == string.Empty)
                {
                    Log.Warning("Skipped classcode string at index " + i + " because it was empty");
                    continue;
                }

                ScheduleConverter.ProcessClassSchedule(classCode, workerData.startyear, workerData.startweek, workerData.endweek);

                formSynchronizationContext.Post(this.UpdateProgressBar, (int)(((float)i / selectedItems.Length) * 100.0f));
                formSynchronizationContext.Post(this.ReportWorkerThreadStatus, "(" + (i + 1) + "/" + selectedItems.Length + ")");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void openOutputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOutputFolder();
        }

        private void OpenOutputFolder()
        {
            Process.Start(Application.StartupPath + @"\output");
        }
    }
}
