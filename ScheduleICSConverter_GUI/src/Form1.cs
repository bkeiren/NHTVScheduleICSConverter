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

        private string ExePath = string.Empty;

        System.Threading.SynchronizationContext formSynchronizationContext;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formSynchronizationContext = WindowsFormsSynchronizationContext.Current;

            checkBox1.Checked = true;
//          consoleAppPath.Text = Application.ExecutablePath;

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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                consoleAppPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (consoleAppPath.Text == string.Empty)
            {
                toolStripStatusLabel1.Text = "Select the console application folder";
                button1_Click(null, null);
                if (consoleAppPath.Text == string.Empty)
                {
                    return;
                }
            }

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
                    Process.Start(consoleAppPath.Text + @"\output");
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
        }

        private void WorkerThreadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            formSynchronizationContext.Post(this.WorkerThreadCompletedMainThread, e);
        }

        private void UpdateProgressBar( object obj )
        {
            progressBar1.Value = (int)obj;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            consoleAppPath.Text = Application.StartupPath;
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
            toolStripStatusLabel1.Text = msg;
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
                string classCode = selectedItem.ToString().Replace(" ", "%20");

                if (classCode == string.Empty)
                {
                    Log.Warning("Skipped classcode string at index " + i + " because it was empty");
                    continue;
                }

                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.FileName = ExePath;
                StartInfo.ErrorDialog = true;
                StartInfo.WorkingDirectory = consoleAppPath.Text;
                if (checkBox2.Checked)
                {
                    StartInfo.CreateNoWindow = true;
                    StartInfo.RedirectStandardOutput = true;
                    StartInfo.UseShellExecute = false;
                }
                StartInfo.Arguments = "1 " +
                                                classCode +
                                                " " +
                                                workerData.startyear +
                                                " " +
                                                workerData.startweek +
                                                " " +
                                                workerData.endweek;

                Process process = null;
                try
                {
                    process = Process.Start(StartInfo);
                    process.EnableRaisingEvents = true;
                    //process.Exited += new EventHandler(this.cliProcessExited);
                }
                catch (Win32Exception exception)
                {
                    switch (exception.NativeErrorCode)
                    {
                        case ERROR_FILE_NOT_FOUND:
                            {
                                formSynchronizationContext.Post(this.workerThreadException, "Could not find executable file in specified folder");
                                break;
                            }
                        case ERROR_ACCESS_DENIED:
                            {
                                formSynchronizationContext.Post(this.workerThreadException, "System denied access to executable file");
                                break;
                            }
                        default:
                            {
                                formSynchronizationContext.Post(this.workerThreadException, "I didn't bother writing a message for this error code (" + exception.NativeErrorCode.ToString() + ")");
                                break;
                            }
                    }
                    return;
                }
                string progressString = "In progress... (" + i.ToString() + "/" + selectedItems.Length + ")";
                formSynchronizationContext.Post(this.ReportWorkerThreadStatus, progressString);
                if (process != null)
                {
                    process.WaitForExit();
                    Log.Info("Process ouput:\n" + process.StandardOutput.ReadToEnd());
                }
                formSynchronizationContext.Post(this.UpdateProgressBar, (int)(((float)i / selectedItems.Length) * 100.0f));
            }
        }

        private void consoleAppPath_TextChanged(object sender, EventArgs e)
        {
            ExePath = consoleAppPath.Text + @"\ScheduleICSConverter_CLI.exe";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }
    }
}
