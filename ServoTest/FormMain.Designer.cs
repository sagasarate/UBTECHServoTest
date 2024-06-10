
namespace ServoTest
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_cbComs = new System.Windows.Forms.ComboBox();
            this.m_rtLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cbBaudRates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbDataBit = new System.Windows.Forms.ComboBox();
            this.m_cbStopBit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cbParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btTogglePort = new System.Windows.Forms.Button();
            this.timerLog = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.m_ActionTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.m_btnSetAngle = new System.Windows.Forms.Button();
            this.m_ID = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.m_TargetAngle = new System.Windows.Forms.NumericUpDown();
            this.m_btnSetAngle0 = new System.Windows.Forms.Button();
            this.m_btnSetAngle240 = new System.Windows.Forms.Button();
            this.m_btnSetAngle120 = new System.Windows.Forms.Button();
            this.m_LockTime = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.m_btnReadAngle = new System.Windows.Forms.Button();
            this.n_btnSetID = new System.Windows.Forms.Button();
            this.m_NewID = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.m_btnReadAngleOffset = new System.Windows.Forms.Button();
            this.m_btnSetANgleOffset = new System.Windows.Forms.Button();
            this.m_btnClearOutput = new System.Windows.Forms.Button();
            this.m_btnServoDetect = new System.Windows.Forms.Button();
            this.timerDetect = new System.Windows.Forms.Timer(this.components);
            this.m_btnStopDetect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_ActionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_TargetAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_LockTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NewID)).BeginInit();
            this.SuspendLayout();
            // 
            // m_cbComs
            // 
            this.m_cbComs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbComs.FormattingEnabled = true;
            this.m_cbComs.Location = new System.Drawing.Point(12, 12);
            this.m_cbComs.Name = "m_cbComs";
            this.m_cbComs.Size = new System.Drawing.Size(64, 20);
            this.m_cbComs.TabIndex = 0;
            // 
            // m_rtLog
            // 
            this.m_rtLog.Location = new System.Drawing.Point(12, 201);
            this.m_rtLog.Name = "m_rtLog";
            this.m_rtLog.ReadOnly = true;
            this.m_rtLog.Size = new System.Drawing.Size(776, 237);
            this.m_rtLog.TabIndex = 1;
            this.m_rtLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "波特率:";
            // 
            // m_cbBaudRates
            // 
            this.m_cbBaudRates.FormattingEnabled = true;
            this.m_cbBaudRates.Items.AddRange(new object[] {
            "1000000",
            "921600",
            "460800",
            "256000",
            "230400",
            "128000",
            "115200",
            "57600",
            "56000",
            "38400",
            "19200",
            "14400",
            "9600"});
            this.m_cbBaudRates.Location = new System.Drawing.Point(142, 12);
            this.m_cbBaudRates.Name = "m_cbBaudRates";
            this.m_cbBaudRates.Size = new System.Drawing.Size(89, 20);
            this.m_cbBaudRates.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "数据位:";
            // 
            // m_cbDataBit
            // 
            this.m_cbDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbDataBit.FormattingEnabled = true;
            this.m_cbDataBit.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.m_cbDataBit.Location = new System.Drawing.Point(294, 12);
            this.m_cbDataBit.Name = "m_cbDataBit";
            this.m_cbDataBit.Size = new System.Drawing.Size(45, 20);
            this.m_cbDataBit.TabIndex = 5;
            // 
            // m_cbStopBit
            // 
            this.m_cbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbStopBit.FormattingEnabled = true;
            this.m_cbStopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2",
            "无"});
            this.m_cbStopBit.Location = new System.Drawing.Point(406, 12);
            this.m_cbStopBit.Name = "m_cbStopBit";
            this.m_cbStopBit.Size = new System.Drawing.Size(45, 20);
            this.m_cbStopBit.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "停止位:";
            // 
            // m_cbParity
            // 
            this.m_cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbParity.FormattingEnabled = true;
            this.m_cbParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验",
            "1校验",
            "0校验"});
            this.m_cbParity.Location = new System.Drawing.Point(508, 12);
            this.m_cbParity.Name = "m_cbParity";
            this.m_cbParity.Size = new System.Drawing.Size(55, 20);
            this.m_cbParity.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "校验:";
            // 
            // m_btTogglePort
            // 
            this.m_btTogglePort.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btTogglePort.Location = new System.Drawing.Point(587, 5);
            this.m_btTogglePort.Name = "m_btTogglePort";
            this.m_btTogglePort.Size = new System.Drawing.Size(103, 33);
            this.m_btTogglePort.TabIndex = 10;
            this.m_btTogglePort.Text = "打开端口";
            this.m_btTogglePort.UseVisualStyleBackColor = true;
            this.m_btTogglePort.Click += new System.EventHandler(this.OnTogglePort);
            // 
            // timerLog
            // 
            this.timerLog.Enabled = true;
            this.timerLog.Tick += new System.EventHandler(this.FlushLog);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "目标角度:";
            // 
            // m_ActionTime
            // 
            this.m_ActionTime.Location = new System.Drawing.Point(260, 56);
            this.m_ActionTime.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_ActionTime.Name = "m_ActionTime";
            this.m_ActionTime.Size = new System.Drawing.Size(48, 21);
            this.m_ActionTime.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "动作时间:";
            // 
            // m_btnSetAngle
            // 
            this.m_btnSetAngle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSetAngle.Location = new System.Drawing.Point(431, 54);
            this.m_btnSetAngle.Name = "m_btnSetAngle";
            this.m_btnSetAngle.Size = new System.Drawing.Size(81, 25);
            this.m_btnSetAngle.TabIndex = 15;
            this.m_btnSetAngle.Text = "设置角度";
            this.m_btnSetAngle.UseVisualStyleBackColor = true;
            this.m_btnSetAngle.Click += new System.EventHandler(this.OnSetAngle);
            // 
            // m_ID
            // 
            this.m_ID.Location = new System.Drawing.Point(37, 56);
            this.m_ID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_ID.Name = "m_ID";
            this.m_ID.Size = new System.Drawing.Size(39, 21);
            this.m_ID.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "ID:";
            // 
            // m_TargetAngle
            // 
            this.m_TargetAngle.Location = new System.Drawing.Point(144, 56);
            this.m_TargetAngle.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.m_TargetAngle.Name = "m_TargetAngle";
            this.m_TargetAngle.Size = new System.Drawing.Size(48, 21);
            this.m_TargetAngle.TabIndex = 18;
            // 
            // m_btnSetAngle0
            // 
            this.m_btnSetAngle0.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSetAngle0.Location = new System.Drawing.Point(519, 54);
            this.m_btnSetAngle0.Name = "m_btnSetAngle0";
            this.m_btnSetAngle0.Size = new System.Drawing.Size(81, 25);
            this.m_btnSetAngle0.TabIndex = 19;
            this.m_btnSetAngle0.Text = "设置0度";
            this.m_btnSetAngle0.UseVisualStyleBackColor = true;
            this.m_btnSetAngle0.Click += new System.EventHandler(this.OnSetAngle0);
            // 
            // m_btnSetAngle240
            // 
            this.m_btnSetAngle240.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSetAngle240.Location = new System.Drawing.Point(609, 54);
            this.m_btnSetAngle240.Name = "m_btnSetAngle240";
            this.m_btnSetAngle240.Size = new System.Drawing.Size(81, 25);
            this.m_btnSetAngle240.TabIndex = 20;
            this.m_btnSetAngle240.Text = "设置240度";
            this.m_btnSetAngle240.UseVisualStyleBackColor = true;
            this.m_btnSetAngle240.Click += new System.EventHandler(this.OnSetAngle240);
            // 
            // m_btnSetAngle120
            // 
            this.m_btnSetAngle120.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSetAngle120.Location = new System.Drawing.Point(699, 54);
            this.m_btnSetAngle120.Name = "m_btnSetAngle120";
            this.m_btnSetAngle120.Size = new System.Drawing.Size(81, 25);
            this.m_btnSetAngle120.TabIndex = 21;
            this.m_btnSetAngle120.Text = "设置120度";
            this.m_btnSetAngle120.UseVisualStyleBackColor = true;
            this.m_btnSetAngle120.Click += new System.EventHandler(this.OnSetAngle120);
            // 
            // m_LockTime
            // 
            this.m_LockTime.Location = new System.Drawing.Point(377, 56);
            this.m_LockTime.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_LockTime.Name = "m_LockTime";
            this.m_LockTime.Size = new System.Drawing.Size(48, 21);
            this.m_LockTime.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "锁定时间:";
            // 
            // m_btnReadAngle
            // 
            this.m_btnReadAngle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnReadAngle.Location = new System.Drawing.Point(36, 125);
            this.m_btnReadAngle.Name = "m_btnReadAngle";
            this.m_btnReadAngle.Size = new System.Drawing.Size(81, 25);
            this.m_btnReadAngle.TabIndex = 24;
            this.m_btnReadAngle.Text = "读取角度";
            this.m_btnReadAngle.UseVisualStyleBackColor = true;
            this.m_btnReadAngle.Click += new System.EventHandler(this.OnReadAngle);
            // 
            // n_btnSetID
            // 
            this.n_btnSetID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.n_btnSetID.Location = new System.Drawing.Point(94, 90);
            this.n_btnSetID.Name = "n_btnSetID";
            this.n_btnSetID.Size = new System.Drawing.Size(81, 25);
            this.n_btnSetID.TabIndex = 25;
            this.n_btnSetID.Text = "设置ID";
            this.n_btnSetID.UseVisualStyleBackColor = true;
            this.n_btnSetID.Click += new System.EventHandler(this.OnSetID);
            // 
            // m_NewID
            // 
            this.m_NewID.Location = new System.Drawing.Point(49, 92);
            this.m_NewID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_NewID.Name = "m_NewID";
            this.m_NewID.Size = new System.Drawing.Size(39, 21);
            this.m_NewID.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "新ID:";
            // 
            // m_btnReadAngleOffset
            // 
            this.m_btnReadAngleOffset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnReadAngleOffset.Location = new System.Drawing.Point(143, 125);
            this.m_btnReadAngleOffset.Name = "m_btnReadAngleOffset";
            this.m_btnReadAngleOffset.Size = new System.Drawing.Size(107, 25);
            this.m_btnReadAngleOffset.TabIndex = 28;
            this.m_btnReadAngleOffset.Text = "读取角度偏移";
            this.m_btnReadAngleOffset.UseVisualStyleBackColor = true;
            this.m_btnReadAngleOffset.Click += new System.EventHandler(this.OnReadAngleOffset);
            // 
            // m_btnSetANgleOffset
            // 
            this.m_btnSetANgleOffset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSetANgleOffset.Location = new System.Drawing.Point(276, 125);
            this.m_btnSetANgleOffset.Name = "m_btnSetANgleOffset";
            this.m_btnSetANgleOffset.Size = new System.Drawing.Size(107, 25);
            this.m_btnSetANgleOffset.TabIndex = 29;
            this.m_btnSetANgleOffset.Text = "设置角度偏移";
            this.m_btnSetANgleOffset.UseVisualStyleBackColor = true;
            this.m_btnSetANgleOffset.Click += new System.EventHandler(this.OnSetAngleOffset);
            // 
            // m_btnClearOutput
            // 
            this.m_btnClearOutput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnClearOutput.Location = new System.Drawing.Point(699, 125);
            this.m_btnClearOutput.Name = "m_btnClearOutput";
            this.m_btnClearOutput.Size = new System.Drawing.Size(81, 25);
            this.m_btnClearOutput.TabIndex = 30;
            this.m_btnClearOutput.Text = "清空输出";
            this.m_btnClearOutput.UseVisualStyleBackColor = true;
            this.m_btnClearOutput.Click += new System.EventHandler(this.OnClearOutput);
            // 
            // m_btnServoDetect
            // 
            this.m_btnServoDetect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnServoDetect.Location = new System.Drawing.Point(587, 125);
            this.m_btnServoDetect.Name = "m_btnServoDetect";
            this.m_btnServoDetect.Size = new System.Drawing.Size(81, 25);
            this.m_btnServoDetect.TabIndex = 31;
            this.m_btnServoDetect.Text = "舵机检测";
            this.m_btnServoDetect.UseVisualStyleBackColor = true;
            this.m_btnServoDetect.Click += new System.EventHandler(this.m_btnServoDetect_Click);
            // 
            // timerDetect
            // 
            this.timerDetect.Interval = 500;
            this.timerDetect.Tick += new System.EventHandler(this.timerDetect_Tick);
            // 
            // m_btnStopDetect
            // 
            this.m_btnStopDetect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnStopDetect.Location = new System.Drawing.Point(482, 125);
            this.m_btnStopDetect.Name = "m_btnStopDetect";
            this.m_btnStopDetect.Size = new System.Drawing.Size(81, 25);
            this.m_btnStopDetect.TabIndex = 32;
            this.m_btnStopDetect.Text = "停止检测";
            this.m_btnStopDetect.UseVisualStyleBackColor = true;
            this.m_btnStopDetect.Click += new System.EventHandler(this.m_btnStopDetect_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_btnStopDetect);
            this.Controls.Add(this.m_btnServoDetect);
            this.Controls.Add(this.m_btnClearOutput);
            this.Controls.Add(this.m_btnSetANgleOffset);
            this.Controls.Add(this.m_btnReadAngleOffset);
            this.Controls.Add(this.m_NewID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.n_btnSetID);
            this.Controls.Add(this.m_btnReadAngle);
            this.Controls.Add(this.m_LockTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_btnSetAngle120);
            this.Controls.Add(this.m_btnSetAngle240);
            this.Controls.Add(this.m_btnSetAngle0);
            this.Controls.Add(this.m_TargetAngle);
            this.Controls.Add(this.m_ID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_btnSetAngle);
            this.Controls.Add(this.m_ActionTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_btTogglePort);
            this.Controls.Add(this.m_cbParity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cbStopBit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cbDataBit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cbBaudRates);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_rtLog);
            this.Controls.Add(this.m_cbComs);
            this.Name = "FormMain";
            this.Text = "舵机测试";
            ((System.ComponentModel.ISupportInitialize)(this.m_ActionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_TargetAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_LockTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NewID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cbComs;
        private System.Windows.Forms.RichTextBox m_rtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cbBaudRates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbDataBit;
        private System.Windows.Forms.ComboBox m_cbStopBit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox m_cbParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_btTogglePort;
        private System.Windows.Forms.Timer timerLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown m_ActionTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button m_btnSetAngle;
        private System.Windows.Forms.NumericUpDown m_ID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown m_TargetAngle;
        private System.Windows.Forms.Button m_btnSetAngle0;
        private System.Windows.Forms.Button m_btnSetAngle240;
        private System.Windows.Forms.Button m_btnSetAngle120;
        private System.Windows.Forms.NumericUpDown m_LockTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button m_btnReadAngle;
        private System.Windows.Forms.Button n_btnSetID;
        private System.Windows.Forms.NumericUpDown m_NewID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button m_btnReadAngleOffset;
        private System.Windows.Forms.Button m_btnSetANgleOffset;
        private System.Windows.Forms.Button m_btnClearOutput;
        private System.Windows.Forms.Button m_btnServoDetect;
        private System.Windows.Forms.Timer timerDetect;
        private System.Windows.Forms.Button m_btnStopDetect;
    }
}

