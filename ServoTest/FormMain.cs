using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ServoTest
{
    public partial class FormMain : Form
    {
        protected class LOG_INFO
        {
            public string Content;
            public Color LogColor;
        };

        protected enum ServoCmd
        {
            None,
            SetAngle,
            Stop,
            ReadAngle,
            SetID,
            SetOffset,
            ReadOffset,
            ReadVersion,
        };

        protected const int READ_BUFFER_SIZE = 64 * 1024;


        protected SerialPort m_SerialPort = new SerialPort();
        protected List<LOG_INFO> m_LogBuffer = new List<LOG_INFO>();
        protected List<byte[]> m_ReadQueue = new List<byte[]>();
        protected byte[] m_ServoCmdBuffer = new byte[10];

        protected ServoCmd m_RecentCmd = ServoCmd.None;
        protected int m_CurServoDetectID = 0;
        public FormMain()
        {
            InitializeComponent();
            ShowComs();
            if (m_cbComs.Items.Count > 0)
            {
                m_cbComs.SelectedIndex = 0;
            }
            m_cbBaudRates.Text = "115200";
            m_cbDataBit.SelectedIndex = 0;
            m_cbStopBit.SelectedIndex = 0;
            m_cbParity.SelectedIndex = 0;

            m_SerialPort.ReadBufferSize = READ_BUFFER_SIZE;
            m_SerialPort.ReadTimeout = 500;
            m_SerialPort.WriteBufferSize = 64 * 1024;
            m_SerialPort.WriteTimeout = 500;
            m_SerialPort.ErrorReceived += OnSerialError;
            m_SerialPort.DataReceived += OnSerialData;
            m_SerialPort.PinChanged += OnSerialPinChanged;
        }

        protected void ShowComs()
        {
            m_cbComs.Items.Clear();
            m_cbComs.Items.AddRange(SerialPort.GetPortNames());

        }

        #region WndProc 重载WndProc，串口设备刷新方法
        //事件代码
        private const int WM_DEVICECHANGE = 0x219; //设备改变事件
        private const int DBT_DEVICEARRIVAL = 0x8000; //检测到新设备
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004; //移除设备
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);//调用父类方法，以确保其他功能正常
            switch (m.Msg)
            {
                case WM_DEVICECHANGE://设备改变事件
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL://检测到新设备                                        
                            {
                                string SelectedCom = m_cbComs.SelectedItem as string;
                                ShowComs();
                                if (!string.IsNullOrEmpty(SelectedCom))
                                {
                                    m_cbComs.SelectedIndex = m_cbComs.Items.IndexOf(SelectedCom);
                                }
                                else
                                {
                                    if (m_cbComs.Items.Count > 0)
                                    {
                                        m_cbComs.SelectedIndex = 0;
                                    }
                                }
                            }
                            break;

                        case DBT_DEVICEREMOVECOMPLETE://有设备移除
                            {
                                string SelectedCom = m_cbComs.SelectedItem as string;
                                ShowComs();
                                if (!string.IsNullOrEmpty(SelectedCom))
                                {
                                    if (m_cbComs.Items.Count > 0)
                                    {
                                        m_cbComs.SelectedIndex = m_cbComs.Items.IndexOf(SelectedCom);
                                        if (m_SerialPort.PortName == SelectedCom)
                                        {
                                            ClosePort();
                                        }
                                    }
                                    else
                                    {
                                        m_cbComs.SelectedIndex = -1;
                                        ClosePort();
                                    }
                                }
                            }
                            break;
                    }
                    break;
            }
        }
        #endregion
        protected void FlushLog(object sender, EventArgs e)
        {
            lock (m_LogBuffer)
            {
                while (m_LogBuffer.Count > 0)
                {
                    LOG_INFO Info = m_LogBuffer[0];
                    m_LogBuffer.RemoveAt(0);

                    m_rtLog.Select(m_rtLog.TextLength, 0);
                    m_rtLog.SelectionColor = Info.LogColor;
                    m_rtLog.SelectedText = Info.Content;
                    m_rtLog.ScrollToCaret();
                }
                
            }
            lock (m_ReadQueue)
            {
                while (m_ReadQueue.Count > 0)
                {
                    OnRecvData(m_ReadQueue[0]);
                    m_ReadQueue.RemoveAt(0);
                }
            }
        }
        protected void Log(string Content, Color TextColor)
        {
            LOG_INFO Info = new LOG_INFO();
            Info.Content = Content + "\r\n";
            Info.LogColor = TextColor;
            lock (m_LogBuffer)
            {
                m_LogBuffer.Add(Info);
            }

        }
        protected void Log(string Content)
        {
            Log(Content, Color.Black);
        }
        protected void ClosePort()
        {
            if (m_SerialPort.IsOpen)
            {
                m_SerialPort.Close();
            }
            Log($"{m_SerialPort.PortName}已关闭", Color.Orange);
            UpdateButton();
        }
        protected void OnTogglePort(object sender, EventArgs evt)
        {
            if (m_SerialPort.IsOpen)
            {
                m_SerialPort.Close();
                Log($"{m_SerialPort.PortName}已关闭", Color.Orange);
            }
            else
            {
                string ComName = m_cbComs.SelectedItem as string;
                if (string.IsNullOrEmpty(ComName))
                {
                    Log("请选择要打开的串口", Color.Red);
                    return;
                }
                int BaudRate = 0;
                if (!string.IsNullOrEmpty(m_cbBaudRates.Text))
                {
                    int.TryParse(m_cbBaudRates.Text as string, out BaudRate);
                }
                if (BaudRate <= 0)
                {
                    Log("请设置正确的波特率", Color.Red);
                    return;
                }

                m_SerialPort.PortName = ComName;
                m_SerialPort.BaudRate = BaudRate;
                switch (m_cbDataBit.SelectedIndex)
                {
                    case 0:
                        m_SerialPort.DataBits = 8;
                        break;
                    case 1:
                        m_SerialPort.DataBits = 7;
                        break;
                    case 2:
                        m_SerialPort.DataBits = 6;
                        break;
                    case 3:
                        m_SerialPort.DataBits = 5;
                        break;
                    default:
                        m_SerialPort.DataBits = 8;
                        break;
                }
                switch (m_cbStopBit.SelectedIndex)
                {
                    case 1:
                        m_SerialPort.StopBits = StopBits.OnePointFive;
                        break;
                    case 2:
                        m_SerialPort.StopBits = StopBits.Two;
                        break;
                    case 3:
                        m_SerialPort.StopBits = StopBits.None;
                        break;
                    default:
                        m_SerialPort.StopBits = StopBits.One;
                        break;
                }
                switch (m_cbParity.SelectedIndex)
                {
                    case 1:
                        m_SerialPort.Parity = Parity.Odd;
                        break;
                    case 2:
                        m_SerialPort.Parity = Parity.Even;
                        break;
                    case 3:
                        m_SerialPort.Parity = Parity.Mark;
                        break;
                    case 4:
                        m_SerialPort.Parity = Parity.Space;
                        break;
                    default:
                        m_SerialPort.Parity = Parity.None;
                        break;
                }
                try
                {
                    m_SerialPort.Open();
                    Log($"{m_SerialPort.PortName}已打开,波特率:{m_SerialPort.BaudRate}", Color.Orange);
                }
                catch (Exception e)
                {
                    Log($"打开串口失败：{e.Message}", Color.Red);
                }

            }
            UpdateButton();
        }

        protected void UpdateButton()
        {
            m_btTogglePort.Text = m_SerialPort.IsOpen ? "关闭端口" : "打开端口";
        }

        protected void OnSerialError(object sender, SerialErrorReceivedEventArgs e)
        {
            Log($"串口出错：{e.EventType}", Color.Red);
        }

        protected void OnSerialData(object sender, SerialDataReceivedEventArgs e)
        {
            if (m_SerialPort.BytesToRead > 0)
            {
                byte[] Data = new byte[m_SerialPort.BytesToRead];
                int Len = m_SerialPort.Read(Data, 0, Data.Length);
                lock (m_ReadQueue)
                {
                    m_ReadQueue.Add(Data);
                }
                if (Len != Data.Length)
                    Log($"缓冲区拥有的数据长度{Data.Length}和实际读取到的数据长度{Len}不一致", Color.Red);
            }
        }

        protected void OnSerialPinChanged(object sender, SerialPinChangedEventArgs e)
        {
            Log($"串口事件：{e.EventType}", Color.Orange);
        }

        protected bool CheckData(byte[] Data, byte Header1, byte Header2)
        {
            if (Data.Length == 10)
            {
                if (Data[0] == Header1 && Data[1] == Header2 && Data[9] == 0xED)
                {
                    if ((byte)(Data[2] + Data[3] + Data[4] + Data[5] + Data[6] + Data[7]) == Data[8])
                    {
                        return true;
                    }
                    else
                    {
                        Log("返回数据校验失败", Color.Red);
                    }
                }
                else
                {
                    Log("返回数据头尾错误", Color.Red);
                }
            }
            else
            {
                Log("返回数据长度错误", Color.Red);
            }
            return false;
        }
        protected void OnRecvData(byte[] Data)
        {
            Log($"收到数据：{BinToStr(Data, Data.Length)}", Color.Gray);
            switch (m_RecentCmd)
            {
                case ServoCmd.SetAngle:
                    if (Data.Length == 1)
                    {
                        if (Data[0] >= 0xAA)
                        {
                            int ID = Data[0] - 0xAA;
                            Log($"设置舵机角度成功，ID={ID}", Color.Orange);
                        }
                        else
                        {
                            Log("设置舵机角度失败", Color.Red);
                        }
                    }
                    else
                    {
                        Log("返回数据长度错误", Color.Red);
                    }
                    break;
                case ServoCmd.Stop:
                    break;
                case ServoCmd.ReadAngle:
                    if (CheckData(Data, 0xFA, 0xAF))
                    {
                        if (Data[3] == 0xAA)
                        {
                            int TargetAngle = (Data[4] << 8) | Data[5];
                            int CurAngle = (Data[6] << 8) | Data[7];
                            Log($"读取舵机{Data[2]}角度成功，当前角度{CurAngle}，目标角度{TargetAngle}", Color.Orange);
                        }
                        else
                        {
                            Log("读取舵机角度失败", Color.Red);
                        }
                    }
                    break;
                case ServoCmd.SetID:
                    if (CheckData(Data, 0xFA, 0xAF))
                    {
                        if (Data[3] == 0xAA)
                        {
                            Log($"舵机{Data[5]}的ID已被设置为{Data[2]}", Color.Orange);
                        }
                        else
                        {
                            Log("设置舵机ID失败", Color.Red);
                        }
                    }
                    break;
                case ServoCmd.SetOffset:
                    if (CheckData(Data, 0xFA, 0xAF))
                    {
                        if (Data[3] == 0xAA)
                        {
                            Log("设置舵机偏移成功", Color.Orange);
                        }
                        else
                        {
                            Log("设置舵机偏移失败", Color.Red);
                        }
                    }
                    break;
                case ServoCmd.ReadOffset:
                    if (CheckData(Data, 0xFA, 0xAF))
                    {
                        if (Data[3] == 0xAA)
                        {
                            short Offset = (short)((Data[6] << 8) | Data[7]);
                            Log($"舵机{Data[2]}的偏移为{Offset}", Color.Orange);
                        }
                        else
                        {
                            Log("读取舵机偏移失败", Color.Red);
                        }
                    }
                    break;
                case ServoCmd.ReadVersion:
                    if (CheckData(Data, 0xFC, 0xCF))
                    {
                        if (Data[3] == 0xAA)
                        {
                            Log($"舵机{Data[2]}的版本号为{Data[4]:X2}{Data[5]:X2}{Data[6]:X2}{Data[7]:X2}", Color.Orange);
                        }
                        else
                        {
                            Log("读取舵机版本号失败", Color.Red);
                        }
                    }
                    break;
            }
        }

        protected string BinToStr(byte[] BindData, int DataLen)
        {
            StringBuilder Str = new StringBuilder();
            for (int i = 0; i < DataLen; i++)
            {
                Str.Append($"{BindData[i]:X2} ");
            }
            return Str.ToString();
        }

        protected bool SendServoCmd(byte Header1, byte Header2, byte ID, byte Cmd, byte Param1, byte Param2, byte Param3, byte Param4)
        {
            if (m_SerialPort.IsOpen)
            {
                m_ServoCmdBuffer[0] = Header1;
                m_ServoCmdBuffer[1] = Header2;
                m_ServoCmdBuffer[2] = ID;
                m_ServoCmdBuffer[3] = Cmd;
                m_ServoCmdBuffer[4] = Param1;
                m_ServoCmdBuffer[5] = Param2;
                m_ServoCmdBuffer[6] = Param3;
                m_ServoCmdBuffer[7] = Param4;
                m_ServoCmdBuffer[8] = (byte)(ID + Cmd + Param1 + Param2 + Param3 + Param4);
                m_ServoCmdBuffer[9] = 0xED;
                m_SerialPort.Write(m_ServoCmdBuffer, 0, 10);
                Log($"已发送：{BinToStr(m_ServoCmdBuffer, 10)}", Color.Black);
                return true;
            }
            else
            {
                Log($"未打开端口", Color.Red);
            }
            return false;
        }

        protected bool SendAngleCmd(byte ID, byte Angle, byte ActionTime, ushort LockTime)
        {
            m_RecentCmd = ServoCmd.SetAngle;
            return SendServoCmd(0xFA, 0xAF, ID, 1, Angle, ActionTime, (byte)((LockTime >> 8) & 0xFF), (byte)(LockTime & 0xFF));
        }
        protected bool SendAngleQueryCmd(byte ID)
        {
            m_RecentCmd = ServoCmd.ReadAngle;
            return SendServoCmd(0xFA, 0xAF, ID, 02, 0, 0, 0, 0);
        }
        protected bool SendIDSetCmd(byte ID, byte NewID)
        {
            m_RecentCmd = ServoCmd.SetID;
            return SendServoCmd(0xFA, 0xAF, ID, 0xCD, 0, NewID, 0, 0);
        }
        protected bool SendAngleOffsetSetCmd(byte ID, ushort AngleOffset)
        {
            m_RecentCmd = ServoCmd.SetOffset;
            return SendServoCmd(0xFA, 0xAF, ID, 0xD2, 0, 0, (byte)((AngleOffset >> 8) & 0xFF), (byte)(AngleOffset & 0xFF));
        }
        protected bool SendAngleOffsetQueryCmd(byte ID)
        {
            m_RecentCmd = ServoCmd.ReadOffset;
            return SendServoCmd(0xFA, 0xAF, ID, 0xD4, 0, 0, 0, 0);
        }

        private void OnSetAngle(object sender, EventArgs e)
        {
            int ID = (int)m_ID.Value;
            int Angle = (int)m_TargetAngle.Value;
            int ActionTime = (int)m_ActionTime.Value;
            int LockTime = (int)m_LockTime.Value;
            if (ID < 0 || ID > 255)
            {
                Log($"ID错误，范围(0-255)", Color.Red);
                return;
            }
            if (Angle < 0 || Angle > 240)
            {
                Log($"角度错误，范围(0-240)", Color.Red);
                return;
            }
            if (ActionTime < 0 || ActionTime > 255)
            {
                Log($"动作时间错误，范围(0-255)", Color.Red);
                return;
            }
            SendAngleCmd((byte)ID, (byte)Angle, (byte)ActionTime, (ushort)LockTime);
            m_ID.Value = ID;
            m_TargetAngle.Value = Angle;
            m_ActionTime.Value = ActionTime;
        }

        private void OnSetAngle0(object sender, EventArgs e)
        {
            m_TargetAngle.Value = 0;
            OnSetAngle(sender, e);
        }

        private void OnSetAngle240(object sender, EventArgs e)
        {
            m_TargetAngle.Value = 240;
            OnSetAngle(sender, e);
        }

        private void OnSetAngle120(object sender, EventArgs e)
        {
            m_TargetAngle.Value = 120;
            OnSetAngle(sender, e);
        }

        private void OnReadAngle(object sender, EventArgs e)
        {
            int ID = (int)m_ID.Value;
            if (ID < 0 || ID > 255)
            {
                Log($"ID错误，范围(0-255)", Color.Red);
                return;
            }
            SendAngleQueryCmd((byte)ID);
        }

        private void OnSetID(object sender, EventArgs e)
        {
            int ID = (int)m_ID.Value;
            if (ID < 0 || ID > 255)
            {
                Log($"ID错误，范围(0-255)", Color.Red);
                return;
            }
            int NewID = (int)m_NewID.Value;
            if (NewID < 1 || NewID > 255)
            {
                Log($"新ID错误，范围(1-255)", Color.Red);
                return;
            }
            if (MessageBox.Show($"是否要将ID为[{ID}]的舵机ID设置为[{NewID}]", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SendIDSetCmd((byte)ID, (byte)NewID);
            }
        }

        private void OnReadAngleOffset(object sender, EventArgs e)
        {
            int ID = (int)m_ID.Value;
            if (ID < 1 || ID > 255)
            {
                Log($"ID错误，范围(1-255)", Color.Red);
                return;
            }
            SendAngleOffsetQueryCmd((byte)ID);
        }

        private void OnSetAngleOffset(object sender, EventArgs e)
        {
            int ID = (int)m_ID.Value;
            short Angle = (short)m_TargetAngle.Value;
            if (ID < 0 || ID > 255)
            {
                Log($"ID错误，范围(0-255)", Color.Red);
                return;
            }
            if (Angle < -90 || Angle > 90)
            {
                Log($"参数错误，范围(-90-90)", Color.Red);
                return;
            }
            SendAngleOffsetSetCmd((byte)ID, (ushort)Angle);
        }

        private void OnClearOutput(object sender, EventArgs e)
        {
            m_rtLog.Clear();
        }

        private void m_btnServoDetect_Click(object sender, EventArgs e)
        {
            m_CurServoDetectID = 1;
            timerDetect.Enabled = true;
            Log($"舵机检测开始", Color.Orange);
        }

        private void timerDetect_Tick(object sender, EventArgs e)
        {
            SendAngleQueryCmd((byte)m_CurServoDetectID);
            m_CurServoDetectID ++;
            if(m_CurServoDetectID>=256)
            {
                timerDetect.Enabled = false;
                Log($"舵机检测结束", Color.Orange);
            }
        }

        private void m_btnStopDetect_Click(object sender, EventArgs e)
        {
            timerDetect.Enabled = false;
            Log($"舵机检测结束", Color.Orange);
        }
    }
}

