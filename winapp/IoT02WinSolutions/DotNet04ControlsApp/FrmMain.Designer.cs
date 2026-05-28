namespace DotNet04ControlsApp
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox1 = new GroupBox();
            BtnDialog = new Button();
            BtnMsgbox = new Button();
            BtnModaless = new Button();
            BtnModal = new Button();
            ChkItalic = new CheckBox();
            TxtResult = new ComboBox();
            ChkBold = new CheckBox();
            CboFonts = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            PrgStatus = new ProgressBar();
            TrkStatus = new TrackBar();
            groupBox3 = new GroupBox();
            BtnAddNode = new Button();
            BtnAddRoot = new Button();
            LvwDummy = new ListView();
            TvwDummy = new TreeView();
            ImageDummy = new ImageList(components);
            groupBox4 = new GroupBox();
            BtnLoadImg = new Button();
            PicImage = new PictureBox();
            groupBox5 = new GroupBox();
            BtnStop = new Button();
            BtnThread = new Button();
            BtnNoThread = new Button();
            PrgProcess = new ProgressBar();
            TxtLog = new TextBox();
            powe = new GroupBox();
            DlgOpenFile = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            WrkProcess = new System.ComponentModel.BackgroundWorker();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrkStatus).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicImage).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(BtnDialog);
            groupBox1.Controls.Add(BtnMsgbox);
            groupBox1.Controls.Add(BtnModaless);
            groupBox1.Controls.Add(BtnModal);
            groupBox1.Controls.Add(ChkItalic);
            groupBox1.Controls.Add(TxtResult);
            groupBox1.Controls.Add(ChkBold);
            groupBox1.Controls.Add(CboFonts);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 153);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "기본 컨트롤";
            // 
            // BtnDialog
            // 
            BtnDialog.Location = new Point(306, 77);
            BtnDialog.Name = "BtnDialog";
            BtnDialog.Size = new Size(75, 23);
            BtnDialog.TabIndex = 8;
            BtnDialog.Text = "...";
            BtnDialog.UseVisualStyleBackColor = true;
            BtnDialog.Click += BtnDialog_Click;
            // 
            // BtnMsgbox
            // 
            BtnMsgbox.Location = new Point(212, 77);
            BtnMsgbox.Name = "BtnMsgbox";
            BtnMsgbox.Size = new Size(75, 23);
            BtnMsgbox.TabIndex = 7;
            BtnMsgbox.Text = "메시지창";
            BtnMsgbox.UseVisualStyleBackColor = true;
            BtnMsgbox.Click += BtnMsgbox_Click;
            // 
            // BtnModaless
            // 
            BtnModaless.Location = new Point(114, 77);
            BtnModaless.Name = "BtnModaless";
            BtnModaless.Size = new Size(75, 23);
            BtnModaless.TabIndex = 6;
            BtnModaless.Text = "모달리스";
            BtnModaless.UseVisualStyleBackColor = true;
            BtnModaless.Click += BtnModaless_Click;
            // 
            // BtnModal
            // 
            BtnModal.Location = new Point(21, 77);
            BtnModal.Name = "BtnModal";
            BtnModal.Size = new Size(75, 23);
            BtnModal.TabIndex = 5;
            BtnModal.Text = "모달";
            BtnModal.UseVisualStyleBackColor = true;
            BtnModal.Click += BtnModal_Click;
            // 
            // ChkItalic
            // 
            ChkItalic.AutoSize = true;
            ChkItalic.Location = new Point(317, 22);
            ChkItalic.Name = "ChkItalic";
            ChkItalic.Size = new Size(62, 19);
            ChkItalic.TabIndex = 4;
            ChkItalic.Text = "이탤릭";
            ChkItalic.UseVisualStyleBackColor = true;
            ChkItalic.CheckedChanged += ChkItalic_CheckedChanged;
            // 
            // TxtResult
            // 
            TxtResult.FormattingEnabled = true;
            TxtResult.Location = new Point(21, 48);
            TxtResult.Name = "TxtResult";
            TxtResult.Size = new Size(358, 23);
            TxtResult.TabIndex = 3;
            // 
            // ChkBold
            // 
            ChkBold.AutoSize = true;
            ChkBold.Location = new Point(257, 22);
            ChkBold.Name = "ChkBold";
            ChkBold.Size = new Size(50, 19);
            ChkBold.TabIndex = 2;
            ChkBold.Text = "굵게";
            ChkBold.UseVisualStyleBackColor = true;
            ChkBold.CheckedChanged += ChkBold_CheckedChanged;
            // 
            // CboFonts
            // 
            CboFonts.FormattingEnabled = true;
            CboFonts.Location = new Point(66, 19);
            CboFonts.Name = "CboFonts";
            CboFonts.Size = new Size(173, 23);
            CboFonts.TabIndex = 1;
            CboFonts.SelectedIndexChanged += CboFonts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 22);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "폰트";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(PrgStatus);
            groupBox2.Controls.Add(TrkStatus);
            groupBox2.Location = new Point(12, 171);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(386, 153);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "트랙바, 진행바";
            // 
            // PrgStatus
            // 
            PrgStatus.Location = new Point(6, 76);
            PrgStatus.Name = "PrgStatus";
            PrgStatus.Size = new Size(373, 32);
            PrgStatus.TabIndex = 1;
            PrgStatus.Value = 10;
            // 
            // TrkStatus
            // 
            TrkStatus.Location = new Point(6, 25);
            TrkStatus.Maximum = 100;
            TrkStatus.Name = "TrkStatus";
            TrkStatus.Size = new Size(374, 45);
            TrkStatus.TabIndex = 0;
            TrkStatus.TickFrequency = 5;
            TrkStatus.Scroll += TrkStatus_Scroll;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox3.Controls.Add(BtnAddNode);
            groupBox3.Controls.Add(BtnAddRoot);
            groupBox3.Controls.Add(LvwDummy);
            groupBox3.Controls.Add(TvwDummy);
            groupBox3.Location = new Point(12, 330);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(386, 212);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "트리, 리스트뷰";
            // 
            // BtnAddNode
            // 
            BtnAddNode.Location = new Point(283, 179);
            BtnAddNode.Name = "BtnAddNode";
            BtnAddNode.Size = new Size(75, 23);
            BtnAddNode.TabIndex = 3;
            BtnAddNode.Text = "노드추가";
            BtnAddNode.UseVisualStyleBackColor = true;
            BtnAddNode.Click += BtnAddNode_Click;
            // 
            // BtnAddRoot
            // 
            BtnAddRoot.Location = new Point(176, 179);
            BtnAddRoot.Name = "BtnAddRoot";
            BtnAddRoot.Size = new Size(75, 23);
            BtnAddRoot.TabIndex = 2;
            BtnAddRoot.Text = "루트추가";
            BtnAddRoot.UseVisualStyleBackColor = true;
            BtnAddRoot.Click += BtnAddRoot_Click;
            // 
            // LvwDummy
            // 
            LvwDummy.Location = new Point(176, 22);
            LvwDummy.Name = "LvwDummy";
            LvwDummy.Size = new Size(182, 151);
            LvwDummy.TabIndex = 1;
            LvwDummy.UseCompatibleStateImageBehavior = false;
            // 
            // TvwDummy
            // 
            TvwDummy.ImageIndex = 0;
            TvwDummy.ImageList = ImageDummy;
            TvwDummy.Location = new Point(6, 22);
            TvwDummy.Name = "TvwDummy";
            TvwDummy.SelectedImageIndex = 0;
            TvwDummy.Size = new Size(164, 151);
            TvwDummy.TabIndex = 0;
            // 
            // ImageDummy
            // 
            ImageDummy.ColorDepth = ColorDepth.Depth32Bit;
            ImageDummy.ImageStream = (ImageListStreamer)resources.GetObject("ImageDummy.ImageStream");
            ImageDummy.TransparentColor = Color.Transparent;
            ImageDummy.Images.SetKeyName(0, "folder.png");
            ImageDummy.Images.SetKeyName(1, "file.png");
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(BtnLoadImg);
            groupBox4.Controls.Add(PicImage);
            groupBox4.Location = new Point(401, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(386, 312);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "픽쳐박스";
            // 
            // BtnLoadImg
            // 
            BtnLoadImg.Location = new Point(305, 277);
            BtnLoadImg.Name = "BtnLoadImg";
            BtnLoadImg.Size = new Size(75, 23);
            BtnLoadImg.TabIndex = 1;
            BtnLoadImg.Text = "이미지";
            BtnLoadImg.UseVisualStyleBackColor = true;
            BtnLoadImg.Click += BtnLoadImg_Click;
            // 
            // PicImage
            // 
            PicImage.Location = new Point(6, 19);
            PicImage.Name = "PicImage";
            PicImage.Size = new Size(374, 248);
            PicImage.TabIndex = 0;
            PicImage.TabStop = false;
            PicImage.Click += PicImage_Click;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(BtnStop);
            groupBox5.Controls.Add(BtnThread);
            groupBox5.Controls.Add(BtnNoThread);
            groupBox5.Controls.Add(PrgProcess);
            groupBox5.Controls.Add(TxtLog);
            groupBox5.Location = new Point(401, 330);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(386, 212);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "스레드";
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(305, 179);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(75, 23);
            BtnStop.TabIndex = 4;
            BtnStop.Text = "button3";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // BtnThread
            // 
            BtnThread.Location = new Point(210, 179);
            BtnThread.Name = "BtnThread";
            BtnThread.Size = new Size(75, 23);
            BtnThread.TabIndex = 3;
            BtnThread.Text = "button2";
            BtnThread.UseVisualStyleBackColor = true;
            BtnThread.Click += BtnThread_Click;
            // 
            // BtnNoThread
            // 
            BtnNoThread.Location = new Point(113, 179);
            BtnNoThread.Name = "BtnNoThread";
            BtnNoThread.Size = new Size(75, 23);
            BtnNoThread.TabIndex = 2;
            BtnNoThread.Text = "button1";
            BtnNoThread.UseVisualStyleBackColor = true;
            BtnNoThread.Click += BtnNoThread_Click;
            // 
            // PrgProcess
            // 
            PrgProcess.Location = new Point(6, 150);
            PrgProcess.Name = "PrgProcess";
            PrgProcess.Size = new Size(374, 23);
            PrgProcess.TabIndex = 1;
            // 
            // TxtLog
            // 
            TxtLog.BorderStyle = BorderStyle.FixedSingle;
            TxtLog.Location = new Point(6, 22);
            TxtLog.Multiline = true;
            TxtLog.Name = "TxtLog";
            TxtLog.Size = new Size(374, 122);
            TxtLog.TabIndex = 0;
            // 
            // powe
            // 
            powe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            powe.Location = new Point(790, 12);
            powe.Name = "powe";
            powe.Size = new Size(386, 530);
            powe.TabIndex = 4;
            powe.TabStop = false;
            powe.Text = "텍스트 에디터";
            // 
            // DlgOpenFile
            // 
            DlgOpenFile.FileName = "텍스트 파일을 선택하세요";
            DlgOpenFile.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*_";
            DlgOpenFile.InitialDirectory = "C:\\SourceBank";
            DlgOpenFile.Title = "텍스트 파일 열기";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 561);
            Controls.Add(powe);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "컨트롤 예제";
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrkStatus).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicImage).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private GroupBox powe;
        private Label label1;
        private CheckBox ChkItalic;
        private ComboBox TxtResult;
        private CheckBox ChkBold;
        private ComboBox CboFonts;
        private Button BtnDialog;
        private Button BtnMsgbox;
        private Button BtnModaless;
        private Button BtnModal;
        private OpenFileDialog DlgOpenFile;
        private ProgressBar PrgStatus;
        private TrackBar TrkStatus;
        private ListView LvwDummy;
        private TreeView TvwDummy;
        private Button BtnAddNode;
        private Button BtnAddRoot;
        private ImageList ImageDummy;
        private SaveFileDialog saveFileDialog1;
        private Button BtnLoadImg;
        private PictureBox PicImage;
        private TextBox TxtLog;
        private Button BtnStop;
        private Button BtnThread;
        private Button BtnNoThread;
        private ProgressBar PrgProcess;
        private System.ComponentModel.BackgroundWorker WrkProcess;
    }
}
