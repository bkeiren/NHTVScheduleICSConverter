namespace SchoolScheduleICSConverter_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ClassSelection = new System.Windows.Forms.ListBox();
            this.StartOfSchoolYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SchoolWeekRangeStart = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SchoolWeekRangeEnd = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button6 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClassSelection
            // 
            this.ClassSelection.ColumnWidth = 256;
            this.ClassSelection.FormattingEnabled = true;
            this.ClassSelection.ItemHeight = 16;
            this.ClassSelection.Items.AddRange(new object[] {
            "1 A-1 RP",
            "1 A-2 RP",
            "1 A-3 RP",
            "1 A-4 RP",
            "1 A-5 RP",
            "1 A-6 RP",
            "1 A 1 UD",
            "1 A 2 UD",
            "1 A 3 UD",
            "1 A 4 UD",
            "1 A 5 UD",
            "1 A 6 UD",
            "1 B-1 MOB",
            "1 B-2 MOB",
            "1 B-3 MOB",
            "1 B-4 MOB",
            "1 B-5 MOB",
            "1 B-6 MOB",
            "1 C-1 LTV",
            "1 C-10 LTV",
            "1 C-2 LTV",
            "1 C-3 LTV",
            "1 C-4 LTV",
            "1 C-5 LTV",
            "1 C-6 LTV",
            "1 C-7 LTV",
            "1 C-8 LTV",
            "1 C-9 LTV",
            "1 CD 2",
            "1 CD 3",
            "1 CD 4",
            "1 CD 5",
            "1 CD 6",
            "1 CD 7",
            "1 CD 8",
            "1 CD 9",
            "1 D-1 LE",
            "1 D-10 LE",
            "1 D-11 LE",
            "1 D-12 LE",
            "1 D-2 LE",
            "1 D-3 LE",
            "1 D-4 LE",
            "1 D-5 LE",
            "1 D-6 LE",
            "1 D-7 LE",
            "1 D-8 LE",
            "1 D-9 LE",
            "1 IB-1 SLM",
            "1 IB-2 SLM",
            "1 IB-3 SLM",
            "1 IB-4 SLM",
            "1 IB-5 SLM",
            "1 IB-6 SLM",
            "1 IB-7 SLM",
            "1 IB-8 SLM",
            "1 IB-9 SLM",
            "1 MBO instroom 1",
            "1 MBO instroom 2",
            "1BTO",
            "1FBTR-01",
            "1FBTR-02",
            "1FBTR-03",
            "1FBTR-04",
            "1FBTR-05",
            "1FBTR-06",
            "1FBTR-07",
            "1FBTR-08",
            "1FBTR-09",
            "1FBTR-10",
            "1FM-01",
            "1FM-02",
            "1FM-03",
            "1FM-04",
            "1FM-05",
            "1FM-06",
            "1FM-07",
            "1FM-08",
            "1FM-09",
            "1FM-10",
            "1FM-11",
            "1FM-12",
            "1FM-13",
            "1FM-14",
            "1FM-15",
            "1FM-16",
            "1FM-17",
            "1GA-10 IGD",
            "1GA-11 IGD",
            "1GA-12 IGD",
            "1GA-1PR",
            "1GA-1VA",
            "1GA-2PR",
            "1GA-2VA",
            "1GA-3PR",
            "1GA-3VA",
            "1GA-4PR",
            "1GA-4VA",
            "1GA-5PR",
            "1GA-5VA",
            "1GA-6VA",
            "1GA-7DP",
            "1GA-8DP",
            "1GA-9DP",
            "1HM-01",
            "1HM-02",
            "1HM-03",
            "1HM-04",
            "1HM-05",
            "1HM-06",
            "1HM-07",
            "1HM-08",
            "1HM-09",
            "1HM-10",
            "1HM-11",
            "1HM-12",
            "1HM-13",
            "1HM-14",
            "1HM-15",
            "1HM-16",
            "1HM-17",
            "1HM-18",
            "1HM-19",
            "1ILS-01",
            "1ME-1a",
            "1ME-1b",
            "1ME-2a",
            "1ME-2b",
            "1ME-3a",
            "1ME-3b",
            "1ME-4a",
            "1ME-4b",
            "1ME-5a",
            "1ME-5b",
            "1ME-6a",
            "1ME-6b",
            "1ME-7a",
            "1ME-7b",
            "1ME-8a",
            "1ME-8b",
            "1MMI-1",
            "1MMI-1",
            "1TMS-01",
            "1TMS-01-2",
            "1TMS-02",
            "1TMS-02-2",
            "1TMS-03",
            "1TMS-03-2",
            "1TMS-04",
            "1TMS-04-2",
            "1TMS-05",
            "1TMS-05-2",
            "1TMS-06",
            "1TMS-06-2",
            "1TMS-07",
            "1TMS-07-2",
            "1TMS-08",
            "1TMS-08-2",
            "1TMS-09",
            "1TMS-09-2",
            "1TMS-10",
            "1TMS-10-2",
            "1TMS-20M",
            "1TMS-21M",
            "1TMS-22M",
            "1VTM-01",
            "1VTM-02",
            "1VTM-03",
            "1VTM-04",
            "1VTM-05",
            "1VTM-06",
            "1VTM-07",
            "1VTM-08",
            "1VTM-09",
            "1VTM-10",
            "1VTM-11",
            "1VTM-12",
            "1VTM-13",
            "1VTM-14",
            "1VTM-15",
            "1VTM-16",
            "1VTM-17",
            "1VTM-18",
            "2 A-1 RP",
            "2 A-2 RP",
            "2 A-3 RP",
            "2 A-4 RP",
            "2 A-5 RP",
            "2 A-6 RP",
            "2 A 1 UD",
            "2 A 2 UD",
            "2 A 3 UD",
            "2 A 4 UD",
            "2 B-1 MOB",
            "2 B-2 MOB",
            "2 B-3 MOB",
            "2 B-4 MOB",
            "2 B-5 MOB",
            "2 B-6 MOB",
            "2 C-1 LTV",
            "2 C-2 LTV",
            "2 C-3 LTV",
            "2 C-4 LTV",
            "2 C-5 LTV",
            "2 C-6 LTV",
            "2 CD LG Event 1",
            "2 CD LG Event 2",
            "2 CD LG FD 1",
            "2 CD LG FD 2",
            "2 CD LG FD 3",
            "2 CD LG prod.1",
            "2 CD LG Prod.2",
            "2 CD LG Prod.3",
            "2 CD LG Zorg",
            "2 D-1 LE",
            "2 D-10 LE",
            "2 D-2 LE",
            "2 D-3 LE",
            "2 D-4 LE",
            "2 D-5 LE",
            "2 D-6 LE",
            "2 D-7 LE",
            "2 D-8 LE",
            "2 D-9 LE",
            "2 IB-1 SLM",
            "2 IB-2 SLM",
            "2 IB-3 SLM",
            "2 IB-4 SLM",
            "2 IB-5 SLM",
            "2BTO",
            "2FBTR-DUAvT",
            "2FBTR-MRO-01a",
            "2FBTR-MRO-01b",
            "2FBTR-MRO-02a",
            "2FBTR-MRO-02b",
            "2FBTR-MTMC-01",
            "2FBTR-MTMC-02",
            "2FBTR-MTT-01a",
            "2FBTR-MTT-01b",
            "2FBTR-MTT-02a",
            "2FBTR-MTT-02b",
            "2FBTR-MTT-03a",
            "2FBTR-MTT-03b",
            "2FBTR-TM-01a",
            "2FBTR-TM-01b",
            "2FBTR-TM-02",
            "2FM-01 (REG)",
            "2FM-02 (REG)",
            "2FM-03 (REG)",
            "2FM-04 (VWO)",
            "2FM-05 (VWO)",
            "2FM-06 (VWO)",
            "2FM-07 (REG)",
            "2FM-08 (REG)",
            "2FM-09 (REG)",
            "2FM-10 (REG)",
            "2FM-11 (REG)",
            "2FM-12 (REG)",
            "2FM-13 (REG)",
            "2FM-14 (REG)",
            "2GA-1PR",
            "2GA-1VA",
            "2GA-2PR",
            "2GA-2VA",
            "2GA-3DP",
            "2GA-4 IGD",
            "2HM-01 (REG)",
            "2HM-02 (REG)",
            "2HM-03 (REG)",
            "2HM-04 (MHBO-MHS-REG)",
            "2HM-05 (MHBO-MHS-REG)",
            "2HM-06 (MHBO-MHS-REG)",
            "2HM-07 (VWO)",
            "2HM-08 (VWO)",
            "2HM-09 (VWO)",
            "2HM-10 (VWO)",
            "2HM-11 (VWO)",
            "2HM-12 (REG)",
            "2HM-13 (MHBO-MHS-REG)",
            "2HM-14 (MHBO-MHS-REG)",
            "2HM-15 (MHBO-MHS-REG)",
            "2HM-16 (MHBO-MHS-REG)",
            "2HM-17 (MHBO-MHS-REG)",
            "2HM-18 (MHBO-MHS-REG)",
            "2HM-19 (MHBO-MHS-REG)",
            "2HM-20 (MHBO-MHS-REG)",
            "2HM-22 (REG-EX)",
            "2HM-23 (REG-EX)",
            "2HM-24 (REG-EX)",
            "2HM-25 (REG)",
            "2HM-26 (REG)",
            "2HM-27 (REG)",
            "2HM-28 (REG)",
            "2HM-29 (REG)",
            "2HM-30 (REG)",
            "2ILM-01",
            "2ILM-02",
            "2ILM-03",
            "2ILM-04",
            "2ILM-05",
            "2ILM-05-FT",
            "2ILM-06",
            "2ILS-01",
            "2ITMC-01",
            "2ITMC-01-2",
            "2ITMC-02",
            "2ITMC-02-2",
            "2ITMC-03",
            "2ITMC-03-2",
            "2ITMC-04",
            "2ITMC-04-2",
            "2ITMC-05",
            "2ITMC-05-2",
            "2ITMC-06",
            "2ITMC-06-2",
            "2ITMC-07",
            "2ITMC-07-2",
            "2ITMC-08",
            "2ITMC-08-2",
            "2ITMC-09",
            "2ITMC-09-2",
            "2ITTI-01",
            "2ITTI-01-2",
            "2ITTI-02",
            "2ITTI-02-2",
            "2ITTI-03",
            "2ITTI-03-2",
            "2ITTI-04",
            "2ITTI-04-2",
            "2ITTI-05",
            "2ITTI-05-2",
            "2ITTI-06",
            "2ME-1a",
            "2ME-1b",
            "2ME-2a",
            "2ME-2b",
            "2ME-3a",
            "2ME-3b",
            "2ME-4a",
            "2ME-4b",
            "2ME-5a",
            "2ME-5b",
            "2TMS-01",
            "2TMS-02",
            "2TMS-03",
            "2TMS-04",
            "2TMS-05",
            "2TMS-06",
            "2TMS-07",
            "2TMS-08",
            "2TMS-09",
            "2VTM-01",
            "2VTM-02",
            "2VTM-03",
            "2VTM-04",
            "2VTM-05",
            "2VTM-06",
            "2VTM-07",
            "2VTM-08",
            "2VTM-09",
            "2VTM-10",
            "2VTM-11",
            "2VTM-12",
            "2VTM-IMAGI-01",
            "2VTM-IMAGI-02",
            "3A-RO",
            "3A-UD",
            "3AHA-01",
            "3AHA-02",
            "3B-MOB",
            "3C-LTV",
            "3D-LE",
            "3E-IB",
            "3FBTR-DUAvT",
            "3FBTR-MRO-01",
            "3FBTR-MRO-02",
            "3FBTR-MTMC-01",
            "3FBTR-MTMC-02",
            "3FBTR-MTT-01a",
            "3FBTR-MTT-01b",
            "3FBTR-MTT-02a",
            "3FBTR-MTT-02b",
            "3FBTR-TM-01",
            "3FBTR-TM-02",
            "3FM",
            "3FM-01 Community 1",
            "3FM-02 Community 2",
            "3GA-1PR",
            "3GA-1VA",
            "3GA-2PR",
            "3GA-2VA",
            "3GA-3 IGD",
            "3GA-4 DP",
            "3HM-01 Community 3",
            "3HM-02 Community 4",
            "3HM-03 Community 5",
            "3ILM-01",
            "3ILM-02",
            "3ILM-03",
            "3ILM-04",
            "3ILS-01",
            "3ITMC-01",
            "3ITMC-02",
            "3ITMC-03",
            "3ITMC-04",
            "3ITMC-05",
            "3ITMC-06",
            "3ITMC-07",
            "3ITMC-08",
            "3ITMC-09",
            "3ITTI-01",
            "3ITTI-02",
            "3ITTI-03",
            "3ITTI-04",
            "3ITTI-05",
            "3ME-1CO",
            "3ME-1DS",
            "3ME-1MA",
            "3ME-1PR",
            "3ME-2CO",
            "3ME-2MA",
            "3ME-2PR",
            "3ME-6",
            "3TBBC-01",
            "3TBBC-02",
            "3TMS-01",
            "3TMS-02",
            "3TMS-03",
            "3TMS-04",
            "3TOU-01",
            "3TOU-02",
            "3TOU-03",
            "3TOU-04",
            "3TOU-05",
            "3TOU-06",
            "3VTM-01",
            "3VTM-02",
            "3VTM-03",
            "3VTM-04",
            "3VTM-05",
            "3VTM-06",
            "3VTM-07",
            "3VTM-08",
            "3VTM-09",
            "3VTM-10",
            "3VTM-11",
            "3VTM-12",
            "3VTM-IMAGI",
            "3VTM-TP",
            "4 A RO",
            "4 A UD",
            "4 B MOB",
            "4 C LTV",
            "4 D LE",
            "4 E IB",
            "4e jr LM",
            "4e jr MOB",
            "4e jr P&amp;V",
            "4e jr SC",
            "4e jr UD",
            "4e jr. RVU groep 1",
            "4e jr. RVU groep 10",
            "4e jr. RVU groep 11",
            "4e jr. RVU groep 12",
            "4e jr. RVU groep 13",
            "4e jr. RVU groep 14",
            "4e jr. RVU groep 15",
            "4e jr. RVU groep 16",
            "4e jr. RVU groep 2",
            "4e jr. RVU groep 3",
            "4e jr. RVU groep 4",
            "4e jr. RVU groep 5",
            "4e jr. RVU groep 6",
            "4e jr. RVU groep 7",
            "4e jr. RVU groep 8",
            "4e jr. RVU groep 9",
            "4e jr. UR/UD",
            "4FBTR-DUAvT",
            "4FBTR-MRO-01",
            "4FBTR-MRO-02",
            "4FBTR-MTMC-01",
            "4FBTR-MTMC-02",
            "4FBTR-MTT-01",
            "4FBTR-MTT-02",
            "4FBTR-MTT-03",
            "4FBTR-MTT-04",
            "4FBTR-TM-01",
            "4FM",
            "4GA-1PR",
            "4GA-1VA",
            "4GA-2PR",
            "4GA-2VA",
            "4HM",
            "4ME-1CO",
            "4ME-1DS",
            "4ME-1MA",
            "4ME-1PR",
            "4ME-2CO",
            "4ME-2MA",
            "4ME-2PR",
            "5FBTR-MRO-01",
            "5FBTR-MTMC-01",
            "5FBTR-MTT-01",
            "5FBTR-TM-01",
            "5GA-1",
            "5ME-1",
            "DT2",
            "DT3VTM",
            "DT4 MT",
            "DT4 VTM",
            "Duaal1prop-BR",
            "Duaal2postprop-AP",
            "Duaal2postprop-BR",
            "Duaal3postprop-AP",
            "Duaal3postprop-BR",
            "ETM",
            "ETM",
            "EXCHANGE GROUP B)",
            "fbtr4",
            "fm4",
            "hho4",
            "HMS",
            "HMS",
            "igad4",
            "ilm4",
            "IMA-Master",
            "IMA-Master",
            "itmc4",
            "itti4",
            "JR4-AT-KST",
            "JR4-CM-MIN",
            "JR4-SBM gr1",
            "JR4-SBM gr2",
            "JR4-SBM gr3",
            "khbo",
            "ltm4",
            "mem4",
            "mt4",
            "PI-01",
            "PI-02",
            "PI-03",
            "PI-04",
            "PI-05",
            "PI-06",
            "PI-07",
            "PI-08",
            "PI-09",
            "PI-10",
            "PI-11",
            "PI-12",
            "PI-13",
            "PI-14",
            "PI-15",
            "PI-16",
            "PI-17",
            "PI-18",
            "PI-19",
            "PI-20",
            "Premaster LS",
            "slm4",
            "TDM-Masters",
            "TDM-Masters-1",
            "TDM-Masters-2",
            "TEST",
            "vpll",
            "vtm4"});
            this.ClassSelection.Location = new System.Drawing.Point(314, 41);
            this.ClassSelection.Name = "ClassSelection";
            this.ClassSelection.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ClassSelection.Size = new System.Drawing.Size(307, 372);
            this.ClassSelection.Sorted = true;
            this.ClassSelection.TabIndex = 6;
            // 
            // StartOfSchoolYear
            // 
            this.StartOfSchoolYear.FormattingEnabled = true;
            this.StartOfSchoolYear.Location = new System.Drawing.Point(11, 54);
            this.StartOfSchoolYear.Name = "StartOfSchoolYear";
            this.StartOfSchoolYear.Size = new System.Drawing.Size(121, 24);
            this.StartOfSchoolYear.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start of schoolyear";
            // 
            // SchoolWeekRangeStart
            // 
            this.SchoolWeekRangeStart.FormattingEnabled = true;
            this.SchoolWeekRangeStart.Location = new System.Drawing.Point(11, 110);
            this.SchoolWeekRangeStart.Name = "SchoolWeekRangeStart";
            this.SchoolWeekRangeStart.Size = new System.Drawing.Size(108, 24);
            this.SchoolWeekRangeStart.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Range of school weeks to download";
            // 
            // SchoolWeekRangeEnd
            // 
            this.SchoolWeekRangeEnd.FormattingEnabled = true;
            this.SchoolWeekRangeEnd.Location = new System.Drawing.Point(151, 110);
            this.SchoolWeekRangeEnd.Name = "SchoolWeekRangeEnd";
            this.SchoolWeekRangeEnd.Size = new System.Drawing.Size(108, 24);
            this.SchoolWeekRangeEnd.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "to";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 285);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 61);
            this.button2.TabIndex = 5;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 197);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(176, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "View output when done";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(635, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.StartOfSchoolYear);
            this.groupBox4.Controls.Add(this.SchoolWeekRangeEnd);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.SchoolWeekRangeStart);
            this.groupBox4.Location = new System.Drawing.Point(12, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(271, 147);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parse Settings";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(17, 224);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(266, 21);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Hide process window (recommended)";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 424);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(270, 40);
            this.progressBar1.Step = 100;
            this.progressBar1.TabIndex = 11;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(13, 352);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(270, 61);
            this.button6.TabIndex = 12;
            this.button6.Text = "Stop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(314, 424);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 40);
            this.button4.TabIndex = 13;
            this.button4.Text = "Select All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(470, 424);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(151, 40);
            this.button5.TabIndex = 14;
            this.button5.Text = "Select None";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openOutputFolderToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openOutputFolderToolStripMenuItem
            // 
            this.openOutputFolderToolStripMenuItem.Name = "openOutputFolderToolStripMenuItem";
            this.openOutputFolderToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.openOutputFolderToolStripMenuItem.Text = "Open Output Folder";
            this.openOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.openOutputFolderToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 497);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ClassSelection);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "NHTV Schedule ICS Converter GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox ClassSelection;
        private System.Windows.Forms.ComboBox StartOfSchoolYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SchoolWeekRangeStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SchoolWeekRangeEnd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOutputFolderToolStripMenuItem;
    }
}

