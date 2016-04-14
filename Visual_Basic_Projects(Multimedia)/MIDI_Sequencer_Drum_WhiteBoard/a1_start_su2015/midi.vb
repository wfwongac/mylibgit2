Option Explicit On
Imports System.IO
Public Class frmMidiPiano
    Inherits System.Windows.Forms.Form




#Region "Windows Form Designer generated code "
    Public Sub New()

        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private WithEvents vsbVolume As System.Windows.Forms.VScrollBar
    Public WithEvents _key_15 As System.Windows.Forms.CheckBox
    Public WithEvents _key_13 As System.Windows.Forms.CheckBox
    Public WithEvents _key_10 As System.Windows.Forms.CheckBox
    Public WithEvents _key_8 As System.Windows.Forms.CheckBox
    Public WithEvents _key_6 As System.Windows.Forms.CheckBox
    Public WithEvents _key_3 As System.Windows.Forms.CheckBox
    Public WithEvents _key_1 As System.Windows.Forms.CheckBox
    Public WithEvents _key_16 As System.Windows.Forms.CheckBox
    Public WithEvents _key_14 As System.Windows.Forms.CheckBox
    Public WithEvents _key_12 As System.Windows.Forms.CheckBox
    Public WithEvents _key_11 As System.Windows.Forms.CheckBox
    Public WithEvents _key_9 As System.Windows.Forms.CheckBox
    Public WithEvents _key_7 As System.Windows.Forms.CheckBox
    Public WithEvents _key_5 As System.Windows.Forms.CheckBox
    Public WithEvents _key_4 As System.Windows.Forms.CheckBox
    Public WithEvents _key_2 As System.Windows.Forms.CheckBox
    Public WithEvents _key_0 As System.Windows.Forms.CheckBox
    Private WithEvents lblVolume As System.Windows.Forms.Label
    Public WithEvents mnuDevice0 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice1 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice2 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice3 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice4 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice5 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice6 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice7 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice8 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice9 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice10 As System.Windows.Forms.MenuItem
    Public WithEvents mnuDevice As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel0 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel1 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel2 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel3 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel4 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel5 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel6 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel7 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel8 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel9 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel10 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel11 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel12 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel13 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel14 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel15 As System.Windows.Forms.MenuItem
    Public WithEvents mnuChannel As System.Windows.Forms.MenuItem
    Public WithEvents mnuBaseNote As System.Windows.Forms.MenuItem
    Public mnuMain As System.Windows.Forms.MainMenu
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private WithEvents btnPlay As System.Windows.Forms.Button
    Private WithEvents btnStop As System.Windows.Forms.Button
    Private WithEvents btnRecord As System.Windows.Forms.Button
    Private WithEvents btnRemoveSilence As System.Windows.Forms.Button
    Friend WithEvents tbSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents lblSeqSlow As System.Windows.Forms.Label
    Friend WithEvents lblSeqNormal As System.Windows.Forms.Label
    Friend WithEvents lblSeqFast As System.Windows.Forms.Label
    Friend WithEvents gbxInstrument As System.Windows.Forms.GroupBox
    Friend WithEvents tbBankMSB As System.Windows.Forms.TrackBar
    Friend WithEvents tbInstrument As System.Windows.Forms.TrackBar
    Friend WithEvents lblBankMSB As System.Windows.Forms.Label
    Friend WithEvents tmrSequencer As System.Windows.Forms.Timer
    Friend WithEvents tclMidiFunction As System.Windows.Forms.TabControl
    Friend WithEvents tabSequencer As System.Windows.Forms.TabPage
    Friend WithEvents tabDrumMachine As System.Windows.Forms.TabPage
    Friend WithEvents tabWhiteboard As System.Windows.Forms.TabPage
    Friend WithEvents gbxXAxis As System.Windows.Forms.GroupBox
    Friend WithEvents lblXValue As System.Windows.Forms.Label
    Friend WithEvents cboXTitle As System.Windows.Forms.ComboBox
    Friend WithEvents lblXTitle As System.Windows.Forms.Label
    Friend WithEvents lblXCaption As System.Windows.Forms.Label
    Friend WithEvents picWhiteboard As System.Windows.Forms.PictureBox
    Friend WithEvents gbxYAxis As System.Windows.Forms.GroupBox
    Friend WithEvents cboYTitle As System.Windows.Forms.ComboBox
    Friend WithEvents lblYTitle As System.Windows.Forms.Label
    Friend WithEvents lblYCaption As System.Windows.Forms.Label
    Friend WithEvents lblYValue As System.Windows.Forms.Label
    Public WithEvents btnDrumStop As System.Windows.Forms.Button
    Public WithEvents btnDrumStart As System.Windows.Forms.Button
    Public WithEvents picDrum As System.Windows.Forms.PictureBox
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Public WithEvents tmrDrumPlayback As System.Windows.Forms.Timer
    Friend WithEvents ChordMode As System.Windows.Forms.CheckBox
    Friend WithEvents ChordSelect As System.Windows.Forms.ComboBox
    Friend WithEvents btnAppend As System.Windows.Forms.Button
    Friend WithEvents isLoopMod As System.Windows.Forms.CheckBox
    Friend WithEvents tbPanning As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents vsbPitchBend As System.Windows.Forms.VScrollBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Drum1ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDelDrum As System.Windows.Forms.Button
    Friend WithEvents btnAddDrum As System.Windows.Forms.Button
    Friend WithEvents Drum2ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbDrumSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents btnBoxReversion As System.Windows.Forms.Button
    Friend WithEvents btnBoxInversion As System.Windows.Forms.Button
    Friend WithEvents btnRandSelect As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Drum5ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Drum4ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Drum3ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents btnSeqReset As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbPitchTrans As System.Windows.Forms.TrackBar
    Friend WithEvents btnAddSlot As System.Windows.Forms.Button
    Friend WithEvents btnDelSlot As System.Windows.Forms.Button
    Friend WithEvents mnuOpen As System.Windows.Forms.MenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblInstrument As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.vsbVolume = New System.Windows.Forms.VScrollBar()
        Me._key_15 = New System.Windows.Forms.CheckBox()
        Me._key_13 = New System.Windows.Forms.CheckBox()
        Me._key_10 = New System.Windows.Forms.CheckBox()
        Me._key_8 = New System.Windows.Forms.CheckBox()
        Me._key_6 = New System.Windows.Forms.CheckBox()
        Me._key_3 = New System.Windows.Forms.CheckBox()
        Me._key_1 = New System.Windows.Forms.CheckBox()
        Me._key_16 = New System.Windows.Forms.CheckBox()
        Me._key_14 = New System.Windows.Forms.CheckBox()
        Me._key_12 = New System.Windows.Forms.CheckBox()
        Me._key_11 = New System.Windows.Forms.CheckBox()
        Me._key_9 = New System.Windows.Forms.CheckBox()
        Me._key_7 = New System.Windows.Forms.CheckBox()
        Me._key_5 = New System.Windows.Forms.CheckBox()
        Me._key_4 = New System.Windows.Forms.CheckBox()
        Me._key_2 = New System.Windows.Forms.CheckBox()
        Me._key_0 = New System.Windows.Forms.CheckBox()
        Me.lblVolume = New System.Windows.Forms.Label()
        Me.mnuChannel0 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel1 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel2 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel3 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel4 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel5 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel6 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel7 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel8 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel9 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel10 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel11 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel12 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel13 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel14 = New System.Windows.Forms.MenuItem()
        Me.mnuChannel15 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice0 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice1 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice2 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice3 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice4 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice5 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice6 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice7 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice8 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice9 = New System.Windows.Forms.MenuItem()
        Me.mnuDevice10 = New System.Windows.Forms.MenuItem()
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuOpen = New System.Windows.Forms.MenuItem()
        Me.mnuDevice = New System.Windows.Forms.MenuItem()
        Me.mnuChannel = New System.Windows.Forms.MenuItem()
        Me.mnuBaseNote = New System.Windows.Forms.MenuItem()
        Me.lblSeqFast = New System.Windows.Forms.Label()
        Me.lblSeqNormal = New System.Windows.Forms.Label()
        Me.lblSeqSlow = New System.Windows.Forms.Label()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.btnRemoveSilence = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnRecord = New System.Windows.Forms.Button()
        Me.gbxInstrument = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbPanning = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbBankMSB = New System.Windows.Forms.TrackBar()
        Me.tbInstrument = New System.Windows.Forms.TrackBar()
        Me.lblBankMSB = New System.Windows.Forms.Label()
        Me.lblInstrument = New System.Windows.Forms.Label()
        Me.tmrSequencer = New System.Windows.Forms.Timer(Me.components)
        Me.tclMidiFunction = New System.Windows.Forms.TabControl()
        Me.tabSequencer = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbPitchTrans = New System.Windows.Forms.TrackBar()
        Me.btnSeqReset = New System.Windows.Forms.Button()
        Me.ChordSelect = New System.Windows.Forms.ComboBox()
        Me.isLoopMod = New System.Windows.Forms.CheckBox()
        Me.ChordMode = New System.Windows.Forms.CheckBox()
        Me.btnAppend = New System.Windows.Forms.Button()
        Me.tabWhiteboard = New System.Windows.Forms.TabPage()
        Me.gbxXAxis = New System.Windows.Forms.GroupBox()
        Me.lblXValue = New System.Windows.Forms.Label()
        Me.cboXTitle = New System.Windows.Forms.ComboBox()
        Me.lblXTitle = New System.Windows.Forms.Label()
        Me.lblXCaption = New System.Windows.Forms.Label()
        Me.picWhiteboard = New System.Windows.Forms.PictureBox()
        Me.gbxYAxis = New System.Windows.Forms.GroupBox()
        Me.cboYTitle = New System.Windows.Forms.ComboBox()
        Me.lblYTitle = New System.Windows.Forms.Label()
        Me.lblYCaption = New System.Windows.Forms.Label()
        Me.lblYValue = New System.Windows.Forms.Label()
        Me.tabDrumMachine = New System.Windows.Forms.TabPage()
        Me.btnDelSlot = New System.Windows.Forms.Button()
        Me.btnAddSlot = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Drum5ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Drum4ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Drum3ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbDrumSpeed = New System.Windows.Forms.TrackBar()
        Me.btnBoxReversion = New System.Windows.Forms.Button()
        Me.btnBoxInversion = New System.Windows.Forms.Button()
        Me.btnRandSelect = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnDelDrum = New System.Windows.Forms.Button()
        Me.btnAddDrum = New System.Windows.Forms.Button()
        Me.Drum2ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Drum1ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDrumStop = New System.Windows.Forms.Button()
        Me.btnDrumStart = New System.Windows.Forms.Button()
        Me.picDrum = New System.Windows.Forms.PictureBox()
        Me.tmrDrumPlayback = New System.Windows.Forms.Timer(Me.components)
        Me.vsbPitchBend = New System.Windows.Forms.VScrollBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxInstrument.SuspendLayout()
        CType(Me.tbPanning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbBankMSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbInstrument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tclMidiFunction.SuspendLayout()
        Me.tabSequencer.SuspendLayout()
        CType(Me.tbPitchTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabWhiteboard.SuspendLayout()
        Me.gbxXAxis.SuspendLayout()
        CType(Me.picWhiteboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxYAxis.SuspendLayout()
        Me.tabDrumMachine.SuspendLayout()
        CType(Me.tbDrumSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDrum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'vsbVolume
        '
        Me.vsbVolume.LargeChange = 1
        Me.vsbVolume.Location = New System.Drawing.Point(12, 25)
        Me.vsbVolume.Maximum = 127
        Me.vsbVolume.Name = "vsbVolume"
        Me.vsbVolume.Size = New System.Drawing.Size(50, 124)
        Me.vsbVolume.TabIndex = 17
        Me.vsbVolume.TabStop = True
        '
        '_key_15
        '
        Me._key_15.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_15.BackColor = System.Drawing.Color.Black
        Me._key_15.ForeColor = System.Drawing.Color.White
        Me._key_15.Location = New System.Drawing.Point(354, 12)
        Me._key_15.Name = "_key_15"
        Me._key_15.Size = New System.Drawing.Size(17, 84)
        Me._key_15.TabIndex = 16
        Me._key_15.Text = ";"
        Me._key_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_15.UseVisualStyleBackColor = False
        '
        '_key_13
        '
        Me._key_13.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_13.BackColor = System.Drawing.Color.Black
        Me._key_13.ForeColor = System.Drawing.Color.White
        Me._key_13.Location = New System.Drawing.Point(322, 12)
        Me._key_13.Name = "_key_13"
        Me._key_13.Size = New System.Drawing.Size(17, 84)
        Me._key_13.TabIndex = 15
        Me._key_13.Text = "L"
        Me._key_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_13.UseVisualStyleBackColor = False
        '
        '_key_10
        '
        Me._key_10.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_10.BackColor = System.Drawing.Color.Black
        Me._key_10.ForeColor = System.Drawing.Color.White
        Me._key_10.Location = New System.Drawing.Point(258, 12)
        Me._key_10.Name = "_key_10"
        Me._key_10.Size = New System.Drawing.Size(17, 84)
        Me._key_10.TabIndex = 14
        Me._key_10.Text = "J"
        Me._key_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_10.UseVisualStyleBackColor = False
        '
        '_key_8
        '
        Me._key_8.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_8.BackColor = System.Drawing.Color.Black
        Me._key_8.ForeColor = System.Drawing.Color.White
        Me._key_8.Location = New System.Drawing.Point(226, 12)
        Me._key_8.Name = "_key_8"
        Me._key_8.Size = New System.Drawing.Size(17, 84)
        Me._key_8.TabIndex = 13
        Me._key_8.Text = "H"
        Me._key_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_8.UseVisualStyleBackColor = False
        '
        '_key_6
        '
        Me._key_6.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_6.BackColor = System.Drawing.Color.Black
        Me._key_6.ForeColor = System.Drawing.Color.White
        Me._key_6.Location = New System.Drawing.Point(194, 12)
        Me._key_6.Name = "_key_6"
        Me._key_6.Size = New System.Drawing.Size(17, 84)
        Me._key_6.TabIndex = 12
        Me._key_6.Text = "G"
        Me._key_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_6.UseVisualStyleBackColor = False
        '
        '_key_3
        '
        Me._key_3.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_3.BackColor = System.Drawing.Color.Black
        Me._key_3.ForeColor = System.Drawing.Color.White
        Me._key_3.Location = New System.Drawing.Point(130, 12)
        Me._key_3.Name = "_key_3"
        Me._key_3.Size = New System.Drawing.Size(17, 84)
        Me._key_3.TabIndex = 11
        Me._key_3.Text = "D"
        Me._key_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_3.UseVisualStyleBackColor = False
        '
        '_key_1
        '
        Me._key_1.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_1.BackColor = System.Drawing.Color.Black
        Me._key_1.ForeColor = System.Drawing.Color.White
        Me._key_1.Location = New System.Drawing.Point(98, 12)
        Me._key_1.Name = "_key_1"
        Me._key_1.Size = New System.Drawing.Size(17, 84)
        Me._key_1.TabIndex = 10
        Me._key_1.Text = "S"
        Me._key_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_1.UseVisualStyleBackColor = False
        '
        '_key_16
        '
        Me._key_16.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_16.BackColor = System.Drawing.Color.White
        Me._key_16.ForeColor = System.Drawing.Color.Black
        Me._key_16.Location = New System.Drawing.Point(362, 12)
        Me._key_16.Name = "_key_16"
        Me._key_16.Size = New System.Drawing.Size(33, 137)
        Me._key_16.TabIndex = 9
        Me._key_16.Text = "/"
        Me._key_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_16.UseVisualStyleBackColor = False
        '
        '_key_14
        '
        Me._key_14.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_14.BackColor = System.Drawing.Color.White
        Me._key_14.ForeColor = System.Drawing.Color.Black
        Me._key_14.Location = New System.Drawing.Point(330, 12)
        Me._key_14.Name = "_key_14"
        Me._key_14.Size = New System.Drawing.Size(33, 137)
        Me._key_14.TabIndex = 8
        Me._key_14.Text = "."
        Me._key_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_14.UseVisualStyleBackColor = False
        '
        '_key_12
        '
        Me._key_12.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_12.BackColor = System.Drawing.Color.White
        Me._key_12.ForeColor = System.Drawing.Color.Black
        Me._key_12.Location = New System.Drawing.Point(298, 12)
        Me._key_12.Name = "_key_12"
        Me._key_12.Size = New System.Drawing.Size(33, 137)
        Me._key_12.TabIndex = 7
        Me._key_12.Text = ","
        Me._key_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_12.UseVisualStyleBackColor = False
        '
        '_key_11
        '
        Me._key_11.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_11.BackColor = System.Drawing.Color.White
        Me._key_11.ForeColor = System.Drawing.Color.Black
        Me._key_11.Location = New System.Drawing.Point(266, 12)
        Me._key_11.Name = "_key_11"
        Me._key_11.Size = New System.Drawing.Size(33, 137)
        Me._key_11.TabIndex = 6
        Me._key_11.Text = "M"
        Me._key_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_11.UseVisualStyleBackColor = False
        '
        '_key_9
        '
        Me._key_9.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_9.BackColor = System.Drawing.Color.White
        Me._key_9.ForeColor = System.Drawing.Color.Black
        Me._key_9.Location = New System.Drawing.Point(234, 12)
        Me._key_9.Name = "_key_9"
        Me._key_9.Size = New System.Drawing.Size(33, 137)
        Me._key_9.TabIndex = 5
        Me._key_9.Text = "N"
        Me._key_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_9.UseVisualStyleBackColor = False
        '
        '_key_7
        '
        Me._key_7.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_7.BackColor = System.Drawing.Color.White
        Me._key_7.ForeColor = System.Drawing.Color.Black
        Me._key_7.Location = New System.Drawing.Point(202, 12)
        Me._key_7.Name = "_key_7"
        Me._key_7.Size = New System.Drawing.Size(33, 137)
        Me._key_7.TabIndex = 4
        Me._key_7.Text = "B"
        Me._key_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_7.UseVisualStyleBackColor = False
        '
        '_key_5
        '
        Me._key_5.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_5.BackColor = System.Drawing.Color.White
        Me._key_5.ForeColor = System.Drawing.Color.Black
        Me._key_5.Location = New System.Drawing.Point(170, 12)
        Me._key_5.Name = "_key_5"
        Me._key_5.Size = New System.Drawing.Size(33, 137)
        Me._key_5.TabIndex = 3
        Me._key_5.Text = "V"
        Me._key_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_5.UseVisualStyleBackColor = False
        '
        '_key_4
        '
        Me._key_4.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_4.BackColor = System.Drawing.Color.White
        Me._key_4.ForeColor = System.Drawing.Color.Black
        Me._key_4.Location = New System.Drawing.Point(138, 12)
        Me._key_4.Name = "_key_4"
        Me._key_4.Size = New System.Drawing.Size(33, 137)
        Me._key_4.TabIndex = 2
        Me._key_4.Text = "C"
        Me._key_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_4.UseVisualStyleBackColor = False
        '
        '_key_2
        '
        Me._key_2.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_2.BackColor = System.Drawing.Color.White
        Me._key_2.ForeColor = System.Drawing.Color.Black
        Me._key_2.Location = New System.Drawing.Point(106, 12)
        Me._key_2.Name = "_key_2"
        Me._key_2.Size = New System.Drawing.Size(33, 137)
        Me._key_2.TabIndex = 1
        Me._key_2.Text = "X"
        Me._key_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_2.UseVisualStyleBackColor = False
        '
        '_key_0
        '
        Me._key_0.Appearance = System.Windows.Forms.Appearance.Button
        Me._key_0.BackColor = System.Drawing.Color.White
        Me._key_0.ForeColor = System.Drawing.Color.Black
        Me._key_0.Location = New System.Drawing.Point(74, 12)
        Me._key_0.Name = "_key_0"
        Me._key_0.Size = New System.Drawing.Size(33, 137)
        Me._key_0.TabIndex = 0
        Me._key_0.Text = "Z"
        Me._key_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me._key_0.UseVisualStyleBackColor = False
        '
        'lblVolume
        '
        Me.lblVolume.AutoSize = True
        Me.lblVolume.Location = New System.Drawing.Point(16, 12)
        Me.lblVolume.Name = "lblVolume"
        Me.lblVolume.Size = New System.Drawing.Size(42, 13)
        Me.lblVolume.TabIndex = 18
        Me.lblVolume.Text = "Volume"
        '
        'mnuChannel0
        '
        Me.mnuChannel0.Index = 0
        Me.mnuChannel0.Text = "1"
        '
        'mnuChannel1
        '
        Me.mnuChannel1.Index = 1
        Me.mnuChannel1.Text = "2"
        '
        'mnuChannel2
        '
        Me.mnuChannel2.Index = 2
        Me.mnuChannel2.Text = "3"
        '
        'mnuChannel3
        '
        Me.mnuChannel3.Index = 3
        Me.mnuChannel3.Text = "4"
        '
        'mnuChannel4
        '
        Me.mnuChannel4.Index = 4
        Me.mnuChannel4.Text = "5"
        '
        'mnuChannel5
        '
        Me.mnuChannel5.Index = 5
        Me.mnuChannel5.Text = "6"
        '
        'mnuChannel6
        '
        Me.mnuChannel6.Index = 6
        Me.mnuChannel6.Text = "7"
        '
        'mnuChannel7
        '
        Me.mnuChannel7.Index = 7
        Me.mnuChannel7.Text = "8"
        '
        'mnuChannel8
        '
        Me.mnuChannel8.Index = 8
        Me.mnuChannel8.Text = "9"
        '
        'mnuChannel9
        '
        Me.mnuChannel9.Index = 9
        Me.mnuChannel9.Text = "10"
        '
        'mnuChannel10
        '
        Me.mnuChannel10.Index = 10
        Me.mnuChannel10.Text = "11"
        '
        'mnuChannel11
        '
        Me.mnuChannel11.Index = 11
        Me.mnuChannel11.Text = "12"
        '
        'mnuChannel12
        '
        Me.mnuChannel12.Index = 12
        Me.mnuChannel12.Text = "13"
        '
        'mnuChannel13
        '
        Me.mnuChannel13.Index = 13
        Me.mnuChannel13.Text = "14"
        '
        'mnuChannel14
        '
        Me.mnuChannel14.Index = 14
        Me.mnuChannel14.Text = "15"
        '
        'mnuChannel15
        '
        Me.mnuChannel15.Index = 15
        Me.mnuChannel15.Text = "16"
        '
        'mnuDevice0
        '
        Me.mnuDevice0.Index = 0
        Me.mnuDevice0.Text = ""
        '
        'mnuDevice1
        '
        Me.mnuDevice1.Enabled = False
        Me.mnuDevice1.Index = 1
        Me.mnuDevice1.Text = ""
        Me.mnuDevice1.Visible = False
        '
        'mnuDevice2
        '
        Me.mnuDevice2.Enabled = False
        Me.mnuDevice2.Index = 2
        Me.mnuDevice2.Text = ""
        Me.mnuDevice2.Visible = False
        '
        'mnuDevice3
        '
        Me.mnuDevice3.Enabled = False
        Me.mnuDevice3.Index = 3
        Me.mnuDevice3.Text = ""
        Me.mnuDevice3.Visible = False
        '
        'mnuDevice4
        '
        Me.mnuDevice4.Enabled = False
        Me.mnuDevice4.Index = 4
        Me.mnuDevice4.Text = ""
        Me.mnuDevice4.Visible = False
        '
        'mnuDevice5
        '
        Me.mnuDevice5.Enabled = False
        Me.mnuDevice5.Index = 5
        Me.mnuDevice5.Text = ""
        Me.mnuDevice5.Visible = False
        '
        'mnuDevice6
        '
        Me.mnuDevice6.Enabled = False
        Me.mnuDevice6.Index = 6
        Me.mnuDevice6.Text = ""
        Me.mnuDevice6.Visible = False
        '
        'mnuDevice7
        '
        Me.mnuDevice7.Enabled = False
        Me.mnuDevice7.Index = 7
        Me.mnuDevice7.Text = ""
        Me.mnuDevice7.Visible = False
        '
        'mnuDevice8
        '
        Me.mnuDevice8.Enabled = False
        Me.mnuDevice8.Index = 8
        Me.mnuDevice8.Text = ""
        Me.mnuDevice8.Visible = False
        '
        'mnuDevice9
        '
        Me.mnuDevice9.Enabled = False
        Me.mnuDevice9.Index = 9
        Me.mnuDevice9.Text = ""
        Me.mnuDevice9.Visible = False
        '
        'mnuDevice10
        '
        Me.mnuDevice10.Enabled = False
        Me.mnuDevice10.Index = 10
        Me.mnuDevice10.Text = ""
        Me.mnuDevice10.Visible = False
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuDevice, Me.mnuChannel, Me.mnuBaseNote})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOpen})
        Me.mnuFile.Text = "Midi &File"
        '
        'mnuOpen
        '
        Me.mnuOpen.Index = 0
        Me.mnuOpen.Text = "&Open"
        '
        'mnuDevice
        '
        Me.mnuDevice.Index = 1
        Me.mnuDevice.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDevice0, Me.mnuDevice1, Me.mnuDevice2, Me.mnuDevice3, Me.mnuDevice4, Me.mnuDevice5, Me.mnuDevice6, Me.mnuDevice7, Me.mnuDevice8, Me.mnuDevice9, Me.mnuDevice10})
        Me.mnuDevice.Text = "Midi &Device"
        '
        'mnuChannel
        '
        Me.mnuChannel.Index = 2
        Me.mnuChannel.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuChannel0, Me.mnuChannel1, Me.mnuChannel2, Me.mnuChannel3, Me.mnuChannel4, Me.mnuChannel5, Me.mnuChannel6, Me.mnuChannel7, Me.mnuChannel8, Me.mnuChannel9, Me.mnuChannel10, Me.mnuChannel11, Me.mnuChannel12, Me.mnuChannel13, Me.mnuChannel14, Me.mnuChannel15})
        Me.mnuChannel.Text = "&Channel"
        '
        'mnuBaseNote
        '
        Me.mnuBaseNote.Index = 3
        Me.mnuBaseNote.Text = "&Base Note"
        '
        'lblSeqFast
        '
        Me.lblSeqFast.Location = New System.Drawing.Point(712, 45)
        Me.lblSeqFast.Name = "lblSeqFast"
        Me.lblSeqFast.Size = New System.Drawing.Size(34, 23)
        Me.lblSeqFast.TabIndex = 27
        Me.lblSeqFast.Text = "Fast"
        Me.lblSeqFast.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSeqNormal
        '
        Me.lblSeqNormal.Location = New System.Drawing.Point(622, 45)
        Me.lblSeqNormal.Name = "lblSeqNormal"
        Me.lblSeqNormal.Size = New System.Drawing.Size(50, 32)
        Me.lblSeqNormal.TabIndex = 26
        Me.lblSeqNormal.Text = "Normal Speed"
        Me.lblSeqNormal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSeqSlow
        '
        Me.lblSeqSlow.Location = New System.Drawing.Point(545, 45)
        Me.lblSeqSlow.Name = "lblSeqSlow"
        Me.lblSeqSlow.Size = New System.Drawing.Size(34, 23)
        Me.lblSeqSlow.TabIndex = 25
        Me.lblSeqSlow.Text = "Slow"
        '
        'tbSpeed
        '
        Me.tbSpeed.Location = New System.Drawing.Point(548, 12)
        Me.tbSpeed.Maximum = 9
        Me.tbSpeed.Minimum = -9
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(198, 45)
        Me.tbSpeed.TabIndex = 24
        '
        'btnRemoveSilence
        '
        Me.btnRemoveSilence.Location = New System.Drawing.Point(113, 52)
        Me.btnRemoveSilence.Name = "btnRemoveSilence"
        Me.btnRemoveSilence.Size = New System.Drawing.Size(95, 25)
        Me.btnRemoveSilence.TabIndex = 23
        Me.btnRemoveSilence.Text = "Remove Silence"
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(214, 12)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(95, 25)
        Me.btnPlay.TabIndex = 22
        Me.btnPlay.Text = "Play"
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(113, 12)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(95, 25)
        Me.btnStop.TabIndex = 21
        Me.btnStop.Text = "Stop"
        '
        'btnRecord
        '
        Me.btnRecord.Location = New System.Drawing.Point(12, 12)
        Me.btnRecord.Name = "btnRecord"
        Me.btnRecord.Size = New System.Drawing.Size(95, 25)
        Me.btnRecord.TabIndex = 20
        Me.btnRecord.Text = "Record"
        '
        'gbxInstrument
        '
        Me.gbxInstrument.Controls.Add(Me.Label3)
        Me.gbxInstrument.Controls.Add(Me.Label2)
        Me.gbxInstrument.Controls.Add(Me.tbPanning)
        Me.gbxInstrument.Controls.Add(Me.Label1)
        Me.gbxInstrument.Controls.Add(Me.tbBankMSB)
        Me.gbxInstrument.Controls.Add(Me.tbInstrument)
        Me.gbxInstrument.Controls.Add(Me.lblBankMSB)
        Me.gbxInstrument.Controls.Add(Me.lblInstrument)
        Me.gbxInstrument.Location = New System.Drawing.Point(474, 12)
        Me.gbxInstrument.Name = "gbxInstrument"
        Me.gbxInstrument.Size = New System.Drawing.Size(373, 145)
        Me.gbxInstrument.TabIndex = 22
        Me.gbxInstrument.TabStop = False
        Me.gbxInstrument.Text = "MIDI Instrument"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(328, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Right"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(82, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Left"
        '
        'tbPanning
        '
        Me.tbPanning.LargeChange = 2
        Me.tbPanning.Location = New System.Drawing.Point(75, 93)
        Me.tbPanning.Maximum = 127
        Me.tbPanning.Name = "tbPanning"
        Me.tbPanning.Size = New System.Drawing.Size(290, 45)
        Me.tbPanning.TabIndex = 27
        Me.tbPanning.Tag = ""
        Me.tbPanning.Value = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Panning:"
        '
        'tbBankMSB
        '
        Me.tbBankMSB.LargeChange = 2
        Me.tbBankMSB.Location = New System.Drawing.Point(75, 57)
        Me.tbBankMSB.Maximum = 8
        Me.tbBankMSB.Name = "tbBankMSB"
        Me.tbBankMSB.Size = New System.Drawing.Size(290, 45)
        Me.tbBankMSB.TabIndex = 3
        '
        'tbInstrument
        '
        Me.tbInstrument.Location = New System.Drawing.Point(75, 19)
        Me.tbInstrument.Maximum = 127
        Me.tbInstrument.Name = "tbInstrument"
        Me.tbInstrument.Size = New System.Drawing.Size(290, 45)
        Me.tbInstrument.TabIndex = 2
        '
        'lblBankMSB
        '
        Me.lblBankMSB.AutoSize = True
        Me.lblBankMSB.Location = New System.Drawing.Point(10, 64)
        Me.lblBankMSB.Name = "lblBankMSB"
        Me.lblBankMSB.Size = New System.Drawing.Size(61, 13)
        Me.lblBankMSB.TabIndex = 1
        Me.lblBankMSB.Text = "Bank MSB:"
        '
        'lblInstrument
        '
        Me.lblInstrument.AutoSize = True
        Me.lblInstrument.Location = New System.Drawing.Point(10, 25)
        Me.lblInstrument.Name = "lblInstrument"
        Me.lblInstrument.Size = New System.Drawing.Size(59, 13)
        Me.lblInstrument.TabIndex = 0
        Me.lblInstrument.Text = "Instrument:"
        '
        'tmrSequencer
        '
        '
        'tclMidiFunction
        '
        Me.tclMidiFunction.Controls.Add(Me.tabSequencer)
        Me.tclMidiFunction.Controls.Add(Me.tabWhiteboard)
        Me.tclMidiFunction.Controls.Add(Me.tabDrumMachine)
        Me.tclMidiFunction.Location = New System.Drawing.Point(12, 160)
        Me.tclMidiFunction.Name = "tclMidiFunction"
        Me.tclMidiFunction.SelectedIndex = 0
        Me.tclMidiFunction.Size = New System.Drawing.Size(942, 403)
        Me.tclMidiFunction.TabIndex = 23
        '
        'tabSequencer
        '
        Me.tabSequencer.Controls.Add(Me.Label16)
        Me.tabSequencer.Controls.Add(Me.Label15)
        Me.tabSequencer.Controls.Add(Me.Label14)
        Me.tabSequencer.Controls.Add(Me.tbPitchTrans)
        Me.tabSequencer.Controls.Add(Me.btnSeqReset)
        Me.tabSequencer.Controls.Add(Me.ChordSelect)
        Me.tabSequencer.Controls.Add(Me.isLoopMod)
        Me.tabSequencer.Controls.Add(Me.ChordMode)
        Me.tabSequencer.Controls.Add(Me.btnAppend)
        Me.tabSequencer.Controls.Add(Me.lblSeqFast)
        Me.tabSequencer.Controls.Add(Me.btnRecord)
        Me.tabSequencer.Controls.Add(Me.lblSeqNormal)
        Me.tabSequencer.Controls.Add(Me.btnStop)
        Me.tabSequencer.Controls.Add(Me.lblSeqSlow)
        Me.tabSequencer.Controls.Add(Me.btnPlay)
        Me.tabSequencer.Controls.Add(Me.tbSpeed)
        Me.tabSequencer.Controls.Add(Me.btnRemoveSilence)
        Me.tabSequencer.Location = New System.Drawing.Point(4, 22)
        Me.tabSequencer.Name = "tabSequencer"
        Me.tabSequencer.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSequencer.Size = New System.Drawing.Size(760, 318)
        Me.tabSequencer.TabIndex = 0
        Me.tabSequencer.Text = "MIDI Sequencer"
        Me.tabSequencer.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(611, 150)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 26)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "All Pitch" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Transpose"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(725, 150)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "+60"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(520, 150)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 13)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "-60"
        '
        'tbPitchTrans
        '
        Me.tbPitchTrans.Location = New System.Drawing.Point(522, 121)
        Me.tbPitchTrans.Maximum = 60
        Me.tbPitchTrans.Minimum = -60
        Me.tbPitchTrans.Name = "tbPitchTrans"
        Me.tbPitchTrans.Size = New System.Drawing.Size(224, 45)
        Me.tbPitchTrans.TabIndex = 31
        '
        'btnSeqReset
        '
        Me.btnSeqReset.BackColor = System.Drawing.Color.MediumAquamarine
        Me.btnSeqReset.Location = New System.Drawing.Point(12, 96)
        Me.btnSeqReset.Name = "btnSeqReset"
        Me.btnSeqReset.Size = New System.Drawing.Size(95, 25)
        Me.btnSeqReset.TabIndex = 30
        Me.btnSeqReset.Text = "Reset"
        Me.btnSeqReset.UseVisualStyleBackColor = False
        '
        'ChordSelect
        '
        Me.ChordSelect.Enabled = False
        Me.ChordSelect.FormattingEnabled = True
        Me.ChordSelect.Items.AddRange(New Object() {"Major Chord", "Minor Chord", "Dominant Chord", "Augmented 7th Chord"})
        Me.ChordSelect.Location = New System.Drawing.Point(391, 56)
        Me.ChordSelect.Name = "ChordSelect"
        Me.ChordSelect.Size = New System.Drawing.Size(121, 21)
        Me.ChordSelect.TabIndex = 25
        '
        'isLoopMod
        '
        Me.isLoopMod.AutoSize = True
        Me.isLoopMod.Location = New System.Drawing.Point(333, 23)
        Me.isLoopMod.Name = "isLoopMod"
        Me.isLoopMod.Size = New System.Drawing.Size(50, 17)
        Me.isLoopMod.TabIndex = 29
        Me.isLoopMod.TabStop = False
        Me.isLoopMod.Text = "Loop"
        Me.isLoopMod.UseVisualStyleBackColor = True
        '
        'ChordMode
        '
        Me.ChordMode.AutoSize = True
        Me.ChordMode.Location = New System.Drawing.Point(333, 58)
        Me.ChordMode.Name = "ChordMode"
        Me.ChordMode.Size = New System.Drawing.Size(54, 17)
        Me.ChordMode.TabIndex = 24
        Me.ChordMode.Text = "Chord"
        Me.ChordMode.UseVisualStyleBackColor = True
        '
        'btnAppend
        '
        Me.btnAppend.Location = New System.Drawing.Point(12, 52)
        Me.btnAppend.Name = "btnAppend"
        Me.btnAppend.Size = New System.Drawing.Size(95, 25)
        Me.btnAppend.TabIndex = 28
        Me.btnAppend.Text = "Append"
        Me.btnAppend.UseVisualStyleBackColor = True
        '
        'tabWhiteboard
        '
        Me.tabWhiteboard.Controls.Add(Me.gbxXAxis)
        Me.tabWhiteboard.Controls.Add(Me.picWhiteboard)
        Me.tabWhiteboard.Controls.Add(Me.gbxYAxis)
        Me.tabWhiteboard.Location = New System.Drawing.Point(4, 22)
        Me.tabWhiteboard.Name = "tabWhiteboard"
        Me.tabWhiteboard.Size = New System.Drawing.Size(760, 318)
        Me.tabWhiteboard.TabIndex = 2
        Me.tabWhiteboard.Text = "MIDI Whiteboard"
        Me.tabWhiteboard.UseVisualStyleBackColor = True
        '
        'gbxXAxis
        '
        Me.gbxXAxis.Controls.Add(Me.lblXValue)
        Me.gbxXAxis.Controls.Add(Me.cboXTitle)
        Me.gbxXAxis.Controls.Add(Me.lblXTitle)
        Me.gbxXAxis.Controls.Add(Me.lblXCaption)
        Me.gbxXAxis.Location = New System.Drawing.Point(324, 12)
        Me.gbxXAxis.Name = "gbxXAxis"
        Me.gbxXAxis.Size = New System.Drawing.Size(145, 80)
        Me.gbxXAxis.TabIndex = 40
        Me.gbxXAxis.TabStop = False
        Me.gbxXAxis.Text = "X - axis"
        '
        'lblXValue
        '
        Me.lblXValue.Location = New System.Drawing.Point(48, 24)
        Me.lblXValue.Name = "lblXValue"
        Me.lblXValue.Size = New System.Drawing.Size(48, 16)
        Me.lblXValue.TabIndex = 38
        '
        'cboXTitle
        '
        Me.cboXTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboXTitle.Items.AddRange(New Object() {"(none)", "instrument", "velocity", "pitch", "stereo position", "pitch bend"})
        Me.cboXTitle.Location = New System.Drawing.Point(40, 48)
        Me.cboXTitle.Name = "cboXTitle"
        Me.cboXTitle.Size = New System.Drawing.Size(96, 21)
        Me.cboXTitle.TabIndex = 37
        '
        'lblXTitle
        '
        Me.lblXTitle.Location = New System.Drawing.Point(8, 51)
        Me.lblXTitle.Name = "lblXTitle"
        Me.lblXTitle.Size = New System.Drawing.Size(32, 16)
        Me.lblXTitle.TabIndex = 36
        Me.lblXTitle.Text = "Title:"
        '
        'lblXCaption
        '
        Me.lblXCaption.Location = New System.Drawing.Point(8, 24)
        Me.lblXCaption.Name = "lblXCaption"
        Me.lblXCaption.Size = New System.Drawing.Size(40, 16)
        Me.lblXCaption.TabIndex = 0
        Me.lblXCaption.Text = "Value:"
        '
        'picWhiteboard
        '
        Me.picWhiteboard.BackColor = System.Drawing.Color.White
        Me.picWhiteboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picWhiteboard.Location = New System.Drawing.Point(12, 12)
        Me.picWhiteboard.Name = "picWhiteboard"
        Me.picWhiteboard.Size = New System.Drawing.Size(300, 300)
        Me.picWhiteboard.TabIndex = 39
        Me.picWhiteboard.TabStop = False
        '
        'gbxYAxis
        '
        Me.gbxYAxis.Controls.Add(Me.cboYTitle)
        Me.gbxYAxis.Controls.Add(Me.lblYTitle)
        Me.gbxYAxis.Controls.Add(Me.lblYCaption)
        Me.gbxYAxis.Controls.Add(Me.lblYValue)
        Me.gbxYAxis.Location = New System.Drawing.Point(324, 104)
        Me.gbxYAxis.Name = "gbxYAxis"
        Me.gbxYAxis.Size = New System.Drawing.Size(145, 80)
        Me.gbxYAxis.TabIndex = 41
        Me.gbxYAxis.TabStop = False
        Me.gbxYAxis.Text = "Y - axis"
        '
        'cboYTitle
        '
        Me.cboYTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYTitle.Items.AddRange(New Object() {"(none)", "instrument", "velocity", "pitch", "stereo position", "pitch bend"})
        Me.cboYTitle.Location = New System.Drawing.Point(40, 48)
        Me.cboYTitle.Name = "cboYTitle"
        Me.cboYTitle.Size = New System.Drawing.Size(96, 21)
        Me.cboYTitle.TabIndex = 37
        '
        'lblYTitle
        '
        Me.lblYTitle.Location = New System.Drawing.Point(8, 51)
        Me.lblYTitle.Name = "lblYTitle"
        Me.lblYTitle.Size = New System.Drawing.Size(32, 16)
        Me.lblYTitle.TabIndex = 36
        Me.lblYTitle.Text = "Title:"
        '
        'lblYCaption
        '
        Me.lblYCaption.Location = New System.Drawing.Point(8, 24)
        Me.lblYCaption.Name = "lblYCaption"
        Me.lblYCaption.Size = New System.Drawing.Size(40, 16)
        Me.lblYCaption.TabIndex = 0
        Me.lblYCaption.Text = "Value:"
        '
        'lblYValue
        '
        Me.lblYValue.Location = New System.Drawing.Point(48, 24)
        Me.lblYValue.Name = "lblYValue"
        Me.lblYValue.Size = New System.Drawing.Size(48, 16)
        Me.lblYValue.TabIndex = 39
        '
        'tabDrumMachine
        '
        Me.tabDrumMachine.Controls.Add(Me.Button1)
        Me.tabDrumMachine.Controls.Add(Me.btnDelSlot)
        Me.tabDrumMachine.Controls.Add(Me.btnAddSlot)
        Me.tabDrumMachine.Controls.Add(Me.Label13)
        Me.tabDrumMachine.Controls.Add(Me.Label12)
        Me.tabDrumMachine.Controls.Add(Me.Label11)
        Me.tabDrumMachine.Controls.Add(Me.Drum5ComboBox5)
        Me.tabDrumMachine.Controls.Add(Me.Drum4ComboBox4)
        Me.tabDrumMachine.Controls.Add(Me.Drum3ComboBox3)
        Me.tabDrumMachine.Controls.Add(Me.Label10)
        Me.tabDrumMachine.Controls.Add(Me.Label7)
        Me.tabDrumMachine.Controls.Add(Me.Label8)
        Me.tabDrumMachine.Controls.Add(Me.Label9)
        Me.tabDrumMachine.Controls.Add(Me.tbDrumSpeed)
        Me.tabDrumMachine.Controls.Add(Me.btnBoxReversion)
        Me.tabDrumMachine.Controls.Add(Me.btnBoxInversion)
        Me.tabDrumMachine.Controls.Add(Me.btnRandSelect)
        Me.tabDrumMachine.Controls.Add(Me.btnReset)
        Me.tabDrumMachine.Controls.Add(Me.btnDelDrum)
        Me.tabDrumMachine.Controls.Add(Me.btnAddDrum)
        Me.tabDrumMachine.Controls.Add(Me.Drum2ComboBox2)
        Me.tabDrumMachine.Controls.Add(Me.Label6)
        Me.tabDrumMachine.Controls.Add(Me.Drum1ComboBox1)
        Me.tabDrumMachine.Controls.Add(Me.Label5)
        Me.tabDrumMachine.Controls.Add(Me.btnDrumStop)
        Me.tabDrumMachine.Controls.Add(Me.btnDrumStart)
        Me.tabDrumMachine.Controls.Add(Me.picDrum)
        Me.tabDrumMachine.Location = New System.Drawing.Point(4, 22)
        Me.tabDrumMachine.Name = "tabDrumMachine"
        Me.tabDrumMachine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDrumMachine.Size = New System.Drawing.Size(934, 377)
        Me.tabDrumMachine.TabIndex = 1
        Me.tabDrumMachine.Text = "Drum Machine"
        Me.tabDrumMachine.UseVisualStyleBackColor = True
        '
        'btnDelSlot
        '
        Me.btnDelSlot.Location = New System.Drawing.Point(82, 338)
        Me.btnDelSlot.Name = "btnDelSlot"
        Me.btnDelSlot.Size = New System.Drawing.Size(58, 26)
        Me.btnDelSlot.TabIndex = 50
        Me.btnDelSlot.Text = "- Slot"
        Me.btnDelSlot.UseVisualStyleBackColor = True
        '
        'btnAddSlot
        '
        Me.btnAddSlot.Location = New System.Drawing.Point(82, 306)
        Me.btnAddSlot.Name = "btnAddSlot"
        Me.btnAddSlot.Size = New System.Drawing.Size(58, 25)
        Me.btnAddSlot.TabIndex = 49
        Me.btnAddSlot.Text = "+ Slot"
        Me.btnAddSlot.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 132)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Drum 5 :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Drum 4 :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Drum 3 :"
        '
        'Drum5ComboBox5
        '
        Me.Drum5ComboBox5.Enabled = False
        Me.Drum5ComboBox5.FormattingEnabled = True
        Me.Drum5ComboBox5.Items.AddRange(New Object() {"35 Acoustic Bass Drum", "36 Bass Drum 1", "37 Side Stick", "38 Acoustic Snare", "39 Hand Clap", "40 Electric Snare ", "41 Low Floor Tom", "42 Closed Hi-Hat", "43 High Floor Tom", "44 Pedal Hi-Hat  ", "45 Low Tom ", "46 Open Hi-Hat ", "47 Low-Mid Tom ", "48 Hi-Mid Tom ", "49 Crash Cymbal 1 ", "50 High Tom ", "51 Ride Cymbal 1 ", "52 Chinese Cymbal ", "53 Ride Bell ", "54 Tambourine ", "55 Splash Cymbal ", "56 Cowbell ", "57 Crash Cymbal 2 ", "58 Vibraslap ", "59 Ride Cymbal 2 ", "60 Hi Bongo", "61 Low Bongo", "62 Mute Hi Conga", "63 Open Hi Conga ", "64 Low Conga ", "65 High Timbale ", "66 Low Timbale  ", "67 High Agogo ", "68 Low Agogo ", "69 Cabasa ", "70 Maracas ", "71 Short Whistle ", "72 Long Whistle ", "73 Short Guiro ", "74 Long Guiro ", "75 Claves ", "76 Hi Wood Block ", "77 Low Wood Block ", "78 Mute Cuica ", "79 Open Cuica ", "80 Mute Triangle ", "81 Open Triangle "})
        Me.Drum5ComboBox5.Location = New System.Drawing.Point(58, 132)
        Me.Drum5ComboBox5.Name = "Drum5ComboBox5"
        Me.Drum5ComboBox5.Size = New System.Drawing.Size(121, 21)
        Me.Drum5ComboBox5.TabIndex = 45
        '
        'Drum4ComboBox4
        '
        Me.Drum4ComboBox4.Enabled = False
        Me.Drum4ComboBox4.FormattingEnabled = True
        Me.Drum4ComboBox4.Items.AddRange(New Object() {"35 Acoustic Bass Drum", "36 Bass Drum 1", "37 Side Stick", "38 Acoustic Snare", "39 Hand Clap", "40 Electric Snare ", "41 Low Floor Tom", "42 Closed Hi-Hat", "43 High Floor Tom", "44 Pedal Hi-Hat  ", "45 Low Tom ", "46 Open Hi-Hat ", "47 Low-Mid Tom ", "48 Hi-Mid Tom ", "49 Crash Cymbal 1 ", "50 High Tom ", "51 Ride Cymbal 1 ", "52 Chinese Cymbal ", "53 Ride Bell ", "54 Tambourine ", "55 Splash Cymbal ", "56 Cowbell ", "57 Crash Cymbal 2 ", "58 Vibraslap ", "59 Ride Cymbal 2 ", "60 Hi Bongo", "61 Low Bongo", "62 Mute Hi Conga", "63 Open Hi Conga ", "64 Low Conga ", "65 High Timbale ", "66 Low Timbale  ", "67 High Agogo ", "68 Low Agogo ", "69 Cabasa ", "70 Maracas ", "71 Short Whistle ", "72 Long Whistle ", "73 Short Guiro ", "74 Long Guiro ", "75 Claves ", "76 Hi Wood Block ", "77 Low Wood Block ", "78 Mute Cuica ", "79 Open Cuica ", "80 Mute Triangle ", "81 Open Triangle "})
        Me.Drum4ComboBox4.Location = New System.Drawing.Point(58, 106)
        Me.Drum4ComboBox4.Name = "Drum4ComboBox4"
        Me.Drum4ComboBox4.Size = New System.Drawing.Size(121, 21)
        Me.Drum4ComboBox4.TabIndex = 44
        '
        'Drum3ComboBox3
        '
        Me.Drum3ComboBox3.Enabled = False
        Me.Drum3ComboBox3.FormattingEnabled = True
        Me.Drum3ComboBox3.Items.AddRange(New Object() {"35 Acoustic Bass Drum", "36 Bass Drum 1", "37 Side Stick", "38 Acoustic Snare", "39 Hand Clap", "40 Electric Snare ", "41 Low Floor Tom", "42 Closed Hi-Hat", "43 High Floor Tom", "44 Pedal Hi-Hat  ", "45 Low Tom ", "46 Open Hi-Hat ", "47 Low-Mid Tom ", "48 Hi-Mid Tom ", "49 Crash Cymbal 1 ", "50 High Tom ", "51 Ride Cymbal 1 ", "52 Chinese Cymbal ", "53 Ride Bell ", "54 Tambourine ", "55 Splash Cymbal ", "56 Cowbell ", "57 Crash Cymbal 2 ", "58 Vibraslap ", "59 Ride Cymbal 2 ", "60 Hi Bongo", "61 Low Bongo", "62 Mute Hi Conga", "63 Open Hi Conga ", "64 Low Conga ", "65 High Timbale ", "66 Low Timbale  ", "67 High Agogo ", "68 Low Agogo ", "69 Cabasa ", "70 Maracas ", "71 Short Whistle ", "72 Long Whistle ", "73 Short Guiro ", "74 Long Guiro ", "75 Claves ", "76 Hi Wood Block ", "77 Low Wood Block ", "78 Mute Cuica ", "79 Open Cuica ", "80 Mute Triangle ", "81 Open Triangle "})
        Me.Drum3ComboBox3.Location = New System.Drawing.Point(58, 76)
        Me.Drum3ComboBox3.Name = "Drum3ComboBox3"
        Me.Drum3ComboBox3.Size = New System.Drawing.Size(121, 21)
        Me.Drum3ComboBox3.TabIndex = 43
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(481, 288)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Playback Speed"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(585, 258)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 23)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Fast"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(495, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 32)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Normal Speed"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(418, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 23)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Slow"
        '
        'tbDrumSpeed
        '
        Me.tbDrumSpeed.Location = New System.Drawing.Point(421, 225)
        Me.tbDrumSpeed.Maximum = 9
        Me.tbDrumSpeed.Minimum = -9
        Me.tbDrumSpeed.Name = "tbDrumSpeed"
        Me.tbDrumSpeed.Size = New System.Drawing.Size(198, 45)
        Me.tbDrumSpeed.TabIndex = 38
        '
        'btnBoxReversion
        '
        Me.btnBoxReversion.Location = New System.Drawing.Point(228, 291)
        Me.btnBoxReversion.Name = "btnBoxReversion"
        Me.btnBoxReversion.Size = New System.Drawing.Size(95, 25)
        Me.btnBoxReversion.TabIndex = 37
        Me.btnBoxReversion.Text = "Box Reversion"
        Me.btnBoxReversion.UseVisualStyleBackColor = True
        '
        'btnBoxInversion
        '
        Me.btnBoxInversion.Location = New System.Drawing.Point(228, 260)
        Me.btnBoxInversion.Name = "btnBoxInversion"
        Me.btnBoxInversion.Size = New System.Drawing.Size(95, 25)
        Me.btnBoxInversion.TabIndex = 36
        Me.btnBoxInversion.Text = "Box Inversion"
        Me.btnBoxInversion.UseVisualStyleBackColor = True
        '
        'btnRandSelect
        '
        Me.btnRandSelect.Location = New System.Drawing.Point(228, 321)
        Me.btnRandSelect.Name = "btnRandSelect"
        Me.btnRandSelect.Size = New System.Drawing.Size(95, 43)
        Me.btnRandSelect.TabIndex = 35
        Me.btnRandSelect.Text = "Randam Box Selection"
        Me.btnRandSelect.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(228, 222)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 34
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnDelDrum
        '
        Me.btnDelDrum.Location = New System.Drawing.Point(12, 339)
        Me.btnDelDrum.Name = "btnDelDrum"
        Me.btnDelDrum.Size = New System.Drawing.Size(58, 25)
        Me.btnDelDrum.TabIndex = 33
        Me.btnDelDrum.Text = "- Drum"
        Me.btnDelDrum.UseVisualStyleBackColor = True
        '
        'btnAddDrum
        '
        Me.btnAddDrum.Location = New System.Drawing.Point(12, 306)
        Me.btnAddDrum.Name = "btnAddDrum"
        Me.btnAddDrum.Size = New System.Drawing.Size(58, 25)
        Me.btnAddDrum.TabIndex = 32
        Me.btnAddDrum.Text = "+ Drum"
        Me.btnAddDrum.UseVisualStyleBackColor = True
        '
        'Drum2ComboBox2
        '
        Me.Drum2ComboBox2.FormattingEnabled = True
        Me.Drum2ComboBox2.Items.AddRange(New Object() {"35 Acoustic Bass Drum", "36 Bass Drum 1", "37 Side Stick", "38 Acoustic Snare", "39 Hand Clap", "40 Electric Snare ", "41 Low Floor Tom", "42 Closed Hi-Hat", "43 High Floor Tom", "44 Pedal Hi-Hat  ", "45 Low Tom ", "46 Open Hi-Hat ", "47 Low-Mid Tom ", "48 Hi-Mid Tom ", "49 Crash Cymbal 1 ", "50 High Tom ", "51 Ride Cymbal 1 ", "52 Chinese Cymbal ", "53 Ride Bell ", "54 Tambourine ", "55 Splash Cymbal ", "56 Cowbell ", "57 Crash Cymbal 2 ", "58 Vibraslap ", "59 Ride Cymbal 2 ", "60 Hi Bongo", "61 Low Bongo", "62 Mute Hi Conga", "63 Open Hi Conga ", "64 Low Conga ", "65 High Timbale ", "66 Low Timbale  ", "67 High Agogo ", "68 Low Agogo ", "69 Cabasa ", "70 Maracas ", "71 Short Whistle ", "72 Long Whistle ", "73 Short Guiro ", "74 Long Guiro ", "75 Claves ", "76 Hi Wood Block ", "77 Low Wood Block ", "78 Mute Cuica ", "79 Open Cuica ", "80 Mute Triangle ", "81 Open Triangle "})
        Me.Drum2ComboBox2.Location = New System.Drawing.Point(58, 45)
        Me.Drum2ComboBox2.Name = "Drum2ComboBox2"
        Me.Drum2ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.Drum2ComboBox2.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Drum 2 :"
        '
        'Drum1ComboBox1
        '
        Me.Drum1ComboBox1.FormattingEnabled = True
        Me.Drum1ComboBox1.Items.AddRange(New Object() {"35 Acoustic Bass Drum", "36 Bass Drum 1", "37 Side Stick", "38 Acoustic Snare", "39 Hand Clap", "40 Electric Snare ", "41 Low Floor Tom", "42 Closed Hi-Hat", "43 High Floor Tom", "44 Pedal Hi-Hat  ", "45 Low Tom ", "46 Open Hi-Hat ", "47 Low-Mid Tom ", "48 Hi-Mid Tom ", "49 Crash Cymbal 1 ", "50 High Tom ", "51 Ride Cymbal 1 ", "52 Chinese Cymbal ", "53 Ride Bell ", "54 Tambourine ", "55 Splash Cymbal ", "56 Cowbell ", "57 Crash Cymbal 2 ", "58 Vibraslap ", "59 Ride Cymbal 2 ", "60 Hi Bongo", "61 Low Bongo", "62 Mute Hi Conga", "63 Open Hi Conga ", "64 Low Conga ", "65 High Timbale ", "66 Low Timbale  ", "67 High Agogo ", "68 Low Agogo ", "69 Cabasa ", "70 Maracas ", "71 Short Whistle ", "72 Long Whistle ", "73 Short Guiro ", "74 Long Guiro ", "75 Claves ", "76 Hi Wood Block ", "77 Low Wood Block ", "78 Mute Cuica ", "79 Open Cuica ", "80 Mute Triangle ", "81 Open Triangle "})
        Me.Drum1ComboBox1.Location = New System.Drawing.Point(58, 19)
        Me.Drum1ComboBox1.Name = "Drum1ComboBox1"
        Me.Drum1ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.Drum1ComboBox1.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Drum 1 :"
        '
        'btnDrumStop
        '
        Me.btnDrumStop.Location = New System.Drawing.Point(12, 275)
        Me.btnDrumStop.Name = "btnDrumStop"
        Me.btnDrumStop.Size = New System.Drawing.Size(95, 25)
        Me.btnDrumStop.TabIndex = 27
        Me.btnDrumStop.Text = "Stop Drum"
        '
        'btnDrumStart
        '
        Me.btnDrumStart.Location = New System.Drawing.Point(12, 245)
        Me.btnDrumStart.Name = "btnDrumStart"
        Me.btnDrumStart.Size = New System.Drawing.Size(95, 25)
        Me.btnDrumStart.TabIndex = 26
        Me.btnDrumStart.Text = "Start Drum"
        '
        'picDrum
        '
        Me.picDrum.BackColor = System.Drawing.SystemColors.Window
        Me.picDrum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picDrum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picDrum.Location = New System.Drawing.Point(186, 26)
        Me.picDrum.Name = "picDrum"
        Me.picDrum.Size = New System.Drawing.Size(304, 40)
        Me.picDrum.TabIndex = 25
        Me.picDrum.TabStop = False
        '
        'tmrDrumPlayback
        '
        Me.tmrDrumPlayback.Interval = 250
        '
        'vsbPitchBend
        '
        Me.vsbPitchBend.LargeChange = 1
        Me.vsbPitchBend.Location = New System.Drawing.Point(407, 25)
        Me.vsbPitchBend.Maximum = 16383
        Me.vsbPitchBend.Name = "vsbPitchBend"
        Me.vsbPitchBend.Size = New System.Drawing.Size(50, 124)
        Me.vsbPitchBend.TabIndex = 24
        Me.vsbPitchBend.TabStop = True
        Me.vsbPitchBend.Value = 8192
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(405, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Pitch Bend"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(421, 321)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 34)
        Me.Button1.TabIndex = 51
        Me.Button1.Text = "Load Drum File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMidiPiano
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(966, 585)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.vsbPitchBend)
        Me.Controls.Add(Me.tclMidiFunction)
        Me.Controls.Add(Me.gbxInstrument)
        Me.Controls.Add(Me.vsbVolume)
        Me.Controls.Add(Me._key_15)
        Me.Controls.Add(Me._key_13)
        Me.Controls.Add(Me._key_10)
        Me.Controls.Add(Me._key_8)
        Me.Controls.Add(Me._key_6)
        Me.Controls.Add(Me._key_3)
        Me.Controls.Add(Me._key_1)
        Me.Controls.Add(Me._key_16)
        Me.Controls.Add(Me._key_14)
        Me.Controls.Add(Me._key_12)
        Me.Controls.Add(Me._key_11)
        Me.Controls.Add(Me._key_9)
        Me.Controls.Add(Me._key_7)
        Me.Controls.Add(Me._key_5)
        Me.Controls.Add(Me._key_4)
        Me.Controls.Add(Me._key_2)
        Me.Controls.Add(Me._key_0)
        Me.Controls.Add(Me.lblVolume)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(11, 49)
        Me.Menu = Me.mnuMain
        Me.Name = "frmMidiPiano"
        Me.Text = "VB Midi Piano"
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxInstrument.ResumeLayout(False)
        Me.gbxInstrument.PerformLayout()
        CType(Me.tbPanning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbBankMSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbInstrument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tclMidiFunction.ResumeLayout(False)
        Me.tabSequencer.ResumeLayout(False)
        Me.tabSequencer.PerformLayout()
        CType(Me.tbPitchTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabWhiteboard.ResumeLayout(False)
        Me.gbxXAxis.ResumeLayout(False)
        CType(Me.picWhiteboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxYAxis.ResumeLayout(False)
        Me.tabDrumMachine.ResumeLayout(False)
        Me.tabDrumMachine.PerformLayout()
        CType(Me.tbDrumSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDrum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Const INVALID_NOTE As Short = -1 ' Code for keyboard keys that we don't handle

    Dim numDevices As Integer ' number of midi output devices
    Dim curDevice As Integer ' current midi device
    Dim hmidi As Integer ' midi output handle
    Dim rc As Integer ' return code
    Dim midimsg As Integer ' midi output message buffer
    Dim channel As Short ' midi output channel
    Dim volume As Short ' midi volume
    Dim baseNote As Short ' the first note on our "piano"
    Dim playChord As Boolean = False
    Dim speed As Double = 1

    Dim key As CheckBoxArray ' an array of check box for keys
    Dim chan As MenuItemArray ' an array of menu item for channel
    Dim device As MenuItemArray ' an array of menu item for midi device

    ' for recording
    Dim isRecording As Boolean ' recording status
    Dim startTime As System.DateTime ' the time of starting recording
    Dim midiSequence As SequenceData ' store MIDI sequence
    Dim currentIndex As Integer ' store the current playing sequence index

    ' for MIDI whiteboard
    Dim lastMidiMessage As Integer = -1 ' previous MIDI message sent to the card
    Dim cbXselected As Short = 0 ' selection of the X axis
    Dim cbYselected As Short = 3 ' selection of the Y axis

    ' for drum machine
    Const DRUM_INSTRUMENT As Short = 2 ' Predefined number of drum instruments
    Const DRUM_SLOT As Short = 8 ' Predefined number of slots across the drum machine
    Dim drumSlot(DRUM_INSTRUMENT, DRUM_SLOT) As Boolean ' Slot On/Off for the drum machine
    Dim drumNumber(DRUM_INSTRUMENT) As Short ' The instrument for the drums
    Dim drumMessageSent(DRUM_INSTRUMENT) As Boolean ' True if a note-on midi message for a drum is sent

    Dim total_drum_instrument As Short = DRUM_INSTRUMENT
    Dim total_drum_slot As Short = DRUM_SLOT

    ' for Chord Mode 
    Dim playNote As Boolean = True

    Dim major_chord As Boolean = False
    Dim minior_chord As Boolean = False
    Dim dominant As Boolean = False
    Dim augmented As Boolean = False

    Dim isLoop As Boolean = False
    Dim isPitchTrans As Boolean = False



#Region "function initControlArray()"


    Public Sub initControlArray()
        ' initialize key checkboxarray (not generated by vb)
        key = New CheckBoxArray

        AddHandler _key_0.MouseDown, AddressOf key_MouseDown
        AddHandler _key_0.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_0)

        AddHandler _key_1.MouseDown, AddressOf key_MouseDown
        AddHandler _key_1.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_1)

        AddHandler _key_2.MouseDown, AddressOf key_MouseDown
        AddHandler _key_2.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_2)

        AddHandler _key_3.MouseDown, AddressOf key_MouseDown
        AddHandler _key_3.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_3)

        AddHandler _key_4.MouseDown, AddressOf key_MouseDown
        AddHandler _key_4.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_4)

        AddHandler _key_5.MouseDown, AddressOf key_MouseDown
        AddHandler _key_5.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_5)

        AddHandler _key_6.MouseDown, AddressOf key_MouseDown
        AddHandler _key_6.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_6)

        AddHandler _key_7.MouseDown, AddressOf key_MouseDown
        AddHandler _key_7.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_7)

        AddHandler _key_8.MouseDown, AddressOf key_MouseDown
        AddHandler _key_8.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_8)

        AddHandler _key_9.MouseDown, AddressOf key_MouseDown
        AddHandler _key_9.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_9)

        AddHandler _key_10.MouseDown, AddressOf key_MouseDown
        AddHandler _key_10.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_10)

        AddHandler _key_11.MouseDown, AddressOf key_MouseDown
        AddHandler _key_11.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_11)

        AddHandler _key_12.MouseDown, AddressOf key_MouseDown
        AddHandler _key_12.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_12)

        AddHandler _key_13.MouseDown, AddressOf key_MouseDown
        AddHandler _key_13.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_13)

        AddHandler _key_14.MouseDown, AddressOf key_MouseDown
        AddHandler _key_14.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_14)

        AddHandler _key_15.MouseDown, AddressOf key_MouseDown
        AddHandler _key_15.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_15)

        AddHandler _key_16.MouseDown, AddressOf key_MouseDown
        AddHandler _key_16.MouseUp, AddressOf key_MouseUp
        key.AddNewCheckBox(_key_16)

        ' initialize channel menuitemarray (not generated by vb)
        chan = New MenuItemArray
        AddHandler mnuChannel0.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel0)

        AddHandler mnuChannel1.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel1)

        AddHandler mnuChannel2.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel2)

        AddHandler mnuChannel3.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel3)

        AddHandler mnuChannel4.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel4)

        AddHandler mnuChannel5.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel5)

        AddHandler mnuChannel6.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel6)

        AddHandler mnuChannel7.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel7)

        AddHandler mnuChannel8.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel8)

        AddHandler mnuChannel9.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel9)

        AddHandler mnuChannel10.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel10)

        AddHandler mnuChannel11.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel11)

        AddHandler mnuChannel12.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel12)

        AddHandler mnuChannel13.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel13)

        AddHandler mnuChannel14.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel14)

        AddHandler mnuChannel15.Click, AddressOf chan_Click
        chan.AddNewMenuItem(mnuChannel15)

        ' initialize device menuitemarray (not generated by vb)
        device = New MenuItemArray

        AddHandler mnuDevice0.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice0)

        AddHandler mnuDevice1.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice1)

        AddHandler mnuDevice2.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice2)

        AddHandler mnuDevice3.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice3)

        AddHandler mnuDevice4.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice4)

        AddHandler mnuDevice5.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice5)

        AddHandler mnuDevice6.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice6)

        AddHandler mnuDevice7.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice7)

        AddHandler mnuDevice8.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice8)

        AddHandler mnuDevice9.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice9)

        AddHandler mnuDevice10.Click, AddressOf device_Click
        device.AddNewMenuItem(mnuDevice10)
    End Sub
#End Region

    ' Set the value for the starting note of the piano
    Public Sub base_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBaseNote.Click
        Dim s As String
        Dim i As Short
        s = InputBox("Enter the new base note for the keyboard (0 - 111)", "Base note", CStr(baseNote))
        If IsNumeric(s) Then
            i = CShort(s)
            If i >= 0 And i < 112 Then
                baseNote = i
            End If
        End If
    End Sub

    ' Select the midi output channel
    Public Sub chan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim index As Integer
        index = CType(sender, System.Windows.Forms.MenuItem).Index
        chan(channel).Checked = False
        channel = index
        chan(channel).Checked = True
    End Sub

    ' Open the midi device selected in the menu. The menu index equals the midi device number + 1.
    Public Sub device_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim index As Integer
        index = CType(sender, System.Windows.Forms.MenuItem).Index
        device(curDevice + 1).Checked = False
        device(index).Checked = True
        curDevice = index - 1
        rc = midiOutClose(hmidi)
        rc = midiOutOpen(hmidi, curDevice, 0, 0, 0)
        If rc <> 0 Then
            MessageBox.Show("Couldn't open midi out, rc = " & rc, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' If user presses a keyboard key, start the corresponding midi note
    Private Sub frmMidiPiano_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = e.KeyCode

        StartNote(NoteFromKey(KeyCode))
    End Sub

    ' If user lifts a keyboard key, stop the corresponding midi note
    Private Sub frmMidiPiano_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim KeyCode As Short = e.KeyCode

        StopNote(NoteFromKey(KeyCode))
    End Sub

    Private Sub frmMidiPiano_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim caps As MIDIOUTCAPS

        Try
            initControlArray()

            ' Set the first device as midi mapper
            device(0).Text = "MIDI Mapper"
            device(0).Visible = True
            device(0).Enabled = True

            ' Get the rest of the midi devices
            numDevices = midiOutGetNumDevs()
            For i = 0 To (numDevices - 1)
                midiOutGetDevCaps(i, caps, Len(caps))
                device(i + 1).Text = caps.szPname
                device(i + 1).Visible = True
                device(i + 1).Enabled = True
            Next

            ' Select the MIDI Mapper as the default device
            device_Click(device.Item(0), New System.EventArgs)

            ' Set the default channel
            channel = 0
            chan(channel).Checked = True

            ' Set the base note
            baseNote = 60

            ' Set volume range
            volume = 127
            vsbVolume.Value = vsbVolume.Maximum - volume

            midiSequence = Nothing
            isRecording = False

            cboXTitle.SelectedIndex = cbXselected
            cboYTitle.SelectedIndex = cbYselected

            drumNumber(1) = &H3C
            drumNumber(2) = &H3D

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmMidiPiano_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        ' Close current midi device
        rc = midiOutClose(hmidi)
    End Sub

    ' Start a note when user click on it
    Public Sub key_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim index As Integer
        index = CType(sender, System.Windows.Forms.CheckBox).Tag
        StartNote(index)
    End Sub

    ' Stop the note when user lifts the mouse button
    Public Sub key_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim index As Integer
        index = CType(sender, System.Windows.Forms.CheckBox).Tag
        StopNote(index)
    End Sub

    ' Press the button and send midi start event
    Private Sub StartNote(ByRef Index As Short)
        If Index = INVALID_NOTE Then
            Exit Sub
        End If
        If key(Index).CheckState = 1 Then
            Exit Sub
        End If

        key(Index).CheckState = System.Windows.Forms.CheckState.Checked
        midimsg = &H90 + ((baseNote + Index) * &H100) + (volume * &H10000) + channel
        sendMidiMsg(hmidi, midimsg)

        If playChord Then

            If major_chord Then
                midimsg = &H90 + ((baseNote + Index + 4) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H90 + ((baseNote + Index + 7) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
            End If

            If minior_chord Then
                midimsg = &H90 + ((baseNote + Index + 3) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H90 + ((baseNote + Index + 7) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
            End If

            If dominant Then
                midimsg = &H90 + ((baseNote + Index + 4) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H90 + ((baseNote + Index + 7) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H90 + ((baseNote + Index + 10) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
            End If

            If augmented Then
                midimsg = &H90 + ((baseNote + Index + 4) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H90 + ((baseNote + Index + 8) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H90 + ((baseNote + Index + 11) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
            End If

        End If

    End Sub

    ' Raise the button and send midi stop event
    Private Sub StopNote(ByRef Index As Short)
        If Index = INVALID_NOTE Then
            Exit Sub
        End If

        key(Index).CheckState = System.Windows.Forms.CheckState.Unchecked
        midimsg = &H80 + ((baseNote + Index) * &H100) + (volume * &H10000) + channel
        sendMidiMsg(hmidi, midimsg)

        If playChord Then

            If major_chord Then
                midimsg = &H80 + ((baseNote + Index + 4) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H80 + ((baseNote + Index + 7) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
            End If

            If minior_chord Then
                midimsg = &H80 + ((baseNote + Index + 3) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H80 + ((baseNote + Index + 7) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
            End If

            If dominant Then
                midimsg = &H80 + ((baseNote + Index + 4) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H80 + ((baseNote + Index + 7) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H80 + ((baseNote + Index + 10) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
            End If

            If augmented Then
                midimsg = &H80 + ((baseNote + Index + 4) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H80 + ((baseNote + Index + 8) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
                midimsg = &H80 + ((baseNote + Index + 11) * &H100) + (volume * &H10000) + channel
                midiOutShortMsg(hmidi, midimsg)
            End If

        End If
    End Sub

    ' Get the note corresponding to a keyboard key
    Private Function NoteFromKey(ByRef key As Short) As Short

        NoteFromKey = INVALID_NOTE

        Select Case key
            Case System.Windows.Forms.Keys.Z
                NoteFromKey = 0
            Case System.Windows.Forms.Keys.S
                NoteFromKey = 1
            Case System.Windows.Forms.Keys.X
                NoteFromKey = 2
            Case System.Windows.Forms.Keys.D
                NoteFromKey = 3
            Case System.Windows.Forms.Keys.C
                NoteFromKey = 4
            Case System.Windows.Forms.Keys.V
                NoteFromKey = 5
            Case System.Windows.Forms.Keys.G
                NoteFromKey = 6
            Case System.Windows.Forms.Keys.B
                NoteFromKey = 7
            Case System.Windows.Forms.Keys.H
                NoteFromKey = 8
            Case System.Windows.Forms.Keys.N
                NoteFromKey = 9
            Case System.Windows.Forms.Keys.J
                NoteFromKey = 10
            Case System.Windows.Forms.Keys.M
                NoteFromKey = 11
            Case 188 ' comma
                NoteFromKey = 12
            Case System.Windows.Forms.Keys.L
                NoteFromKey = 13
            Case 190 ' period
                NoteFromKey = 14
            Case 186 ' semicolon
                NoteFromKey = 15
            Case 191 ' forward slash
                NoteFromKey = 16
        End Select

    End Function

    ' Set the volume
    Private Sub vsbVolume_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vsbVolume.Scroll
        Select Case e.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                volume = vsbVolume.Maximum - e.NewValue
        End Select
    End Sub

    Private Sub tbPanning_Scroll(sender As System.Object, e As System.EventArgs) Handles tbPanning.Scroll
        midimsg = &HB0 + channel + (10 * &H100) + (tbPanning.Value * &H10000)
        sendMidiMsg(hmidi, midimsg)
    End Sub

    ' Change the instrument by sending a program change message
    Private Sub tbInstrument_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbInstrument.ValueChanged
        ' Send a program change message for the instrument
        midimsg = &HC0 + (tbInstrument.Value * &H100) + channel
        sendMidiMsg(hmidi, midimsg)
    End Sub

    Private Sub tbBankMSB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBankMSB.ValueChanged
        ' Send a control change message to change the bank
        midimsg = &HB0 + channel + (&H0 * &H100) + (tbBankMSB.Value * &H10000)
        sendMidiMsg(hmidi, midimsg)

        ' Resend a program change message for the instrument so that it comes into effect immediately
        midimsg = &HC0 + (tbInstrument.Value * &H100) + channel
        sendMidiMsg(hmidi, midimsg)
    End Sub

    Private Sub btnSeqReset_Click(sender As System.Object, e As System.EventArgs) Handles btnSeqReset.Click
        Dim i As Integer


        tbPanning.Value = 63
        tbInstrument.Value = 0
        tbBankMSB.Value = 0
        For i = 0 To 15
            ' All Note Off
            midimsg = &HB0 + i + (&H7B * &H100) + (&H0 * &H10000)
            sendMidiMsg(hmidi, midimsg)

            ' Reset stereo position to the centre
            midimsg = &HB0 + i + (10 * &H100) + (tbPanning.Value * &H10000)
            sendMidiMsg(hmidi, midimsg)

            ' Reset musical instrument to 0
            midimsg = &HC0 + i + (tbInstrument.Value * &H10000)
            sendMidiMsg(hmidi, midimsg)

            ' Reset bank to 0
            midimsg = &HB0 + i + (&H0 * &H100) + (tbBankMSB.Value * &H10000)
            sendMidiMsg(hmidi, midimsg)
        Next i

        ' Reset Volume
        vsbVolume.Value = 0

        ' Reset PlayBack Speed
        tbSpeed.Value = 0
    End Sub

    '======================================= MIDI sequencer ================


    ' Start recording MIDI sequence
    Private Sub btnRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecord.Click
        ' 2.1 Start recording a MIDI sequence
        ' Initialize the sequence data
        isRecording = True
        startTime = DateTime.Now

        midiSequence = Nothing
        midiSequence = New SequenceData

        ' Send the messages for the instrument so that the playback will match
        midimsg = &HC0 + channel + (tbInstrument.Value * &H100)
        sendMidiMsg(hmidi, midimsg)


        midimsg = &HB0 + channel + (&H0 * &H100) + (tbBankMSB.Value * &H10000)
        sendMidiMsg(hmidi, midimsg)

        ' -- Resend a program change message for the instrument so that it comes into effect immediately

        btnRecord.Enabled = False
        btnPlay.Enabled = False
        btnStop.Enabled = True
        btnRemoveSilence.Enabled = False
        btnAppend.Enabled = False

    End Sub

    Private Sub btnAppend_Click(sender As System.Object, e As System.EventArgs) Handles btnAppend.Click
        isRecording = True

        midimsg = &HC0 + channel + (tbInstrument.Value * &H100)
        sendMidiMsg(hmidi, midimsg)

        midimsg = &HB0 + channel + (&H0 * &H100) + (tbBankMSB.Value * &H10000)
        sendMidiMsg(hmidi, midimsg)

        btnRecord.Enabled = False
        btnPlay.Enabled = False
        btnStop.Enabled = True
        btnRemoveSilence.Enabled = False
        btnAppend.Enabled = False

    End Sub

    ' Stop recording MIDI sequence
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        ' 2.2 Stop recording a MIDI sequence
        ' Stop the recording
        isRecording = False
        tmrSequencer.Enabled = False

        ' 2.3 Play a MIDI sequence
        ' Stop the playback
        btnRecord.Enabled = True
        btnPlay.Enabled = True
        btnStop.Enabled = False
        btnRemoveSilence.Enabled = True
        btnAppend.Enabled = True

    End Sub

    ' Play the MIDI sequence recorded
    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        If midiSequence Is Nothing Then
            Exit Sub
        End If

        ' 2.3 Play a MIDI sequence
        currentIndex = 0    ' Store the current index of the MIDI msg
        ' Start the timer using the time of the first sequencer message data
        tmrSequencer.Interval = CInt(Math.Round(midiSequence.data(0).time.TotalMilliseconds * speed)) + 1
        tmrSequencer.Enabled = True

        btnRecord.Enabled = False
        btnPlay.Enabled = False
        btnStop.Enabled = True
        btnRemoveSilence.Enabled = False
        btnAppend.Enabled = False

    End Sub

    Private Sub tmrSequencer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSequencer.Tick
        ' 2.3 Play a MIDI sequence
        ' Stop the timer from running
        tmrSequencer.Enabled = False

        ' Consume all sequence data which is on time
        Dim currentTime As Double

        currentTime = midiSequence.data(currentIndex).time.TotalMilliseconds
        While currentTime >= midiSequence.data(currentIndex).time.TotalMilliseconds

            sendMidiMsg(hmidi, midiSequence.data(currentIndex).midiMsg)
            currentIndex += 1
            If currentIndex = midiSequence.dataLength Then
                Exit While
            End If
        End While

        ' Send the MIDI message of the current message and schedule the next one
        If currentIndex < midiSequence.dataLength Then
            tmrSequencer.Interval = CInt(Math.Round((midiSequence.data(currentIndex).time.TotalMilliseconds - currentTime) * speed)) + 1
            tmrSequencer.Enabled = True
        Else

            If isLoop Then
                currentIndex = 0
                ' ReStart the timer using the time of the first sequencer message data
                tmrSequencer.Interval = CInt(Math.Round(midiSequence.data(0).time.TotalMilliseconds * speed)) + 1
                tmrSequencer.Enabled = True
            End If


            btnRecord.Enabled = True
            btnPlay.Enabled = True
            btnStop.Enabled = True
            btnRemoveSilence.Enabled = True
            btnAppend.Enabled = False
        End If
    End Sub

    ' Send a MIDI message and store the message
    Private Sub sendMidiMsg(ByVal hMidiOut As Integer, ByVal dwMsg As Integer)
        ' Send a MIDI message

        If isPitchTrans And (dwMsg And &HF0) = &H90 Then
            dwMsg += tbPitchTrans.Value * &H100

            If dwMsg And (&HFF00) > (127 * &H100) Then
                dwMsg = dwMsg And &HFF00FF + (127 * &H100)
            End If
            If dwMsg And (&HFF00) < 0 Then
                dwMsg = dwMsg And &HFF00FF
            End If
        End If
        midiOutShortMsg(hMidiOut, dwMsg)

        ' 2.1 Start recording a MIDI sequence
        ' Store the message
        If isRecording Then
            midiSequence.AddSequenceData(dwMsg, DateTime.Now.Subtract(startTime))
        End If
    End Sub

    Private Sub tbSpeed_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSpeed.Scroll
        If tbSpeed.Value > 0 Then
            speed = 1 - tbSpeed.Value / 10.0
        Else
            speed = 1 - tbSpeed.Value / 10.0
        End If
    End Sub

    Private Sub btnRemoveSilence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSilence.Click
        If midiSequence Is Nothing Then
            Exit Sub
        End If

        ' 3.1 Remove silence at the start

        Dim i As Integer
        Dim NoteOnIndex As Integer
        Dim tempTime As System.TimeSpan
        For i = 0 To midiSequence.dataLength - 1
            If (midiSequence.data(i).midiMsg And &HF0) = &H90 Then
                NoteOnIndex = i
                tempTime = midiSequence.data(i).time
                Exit For

            End If
        Next i

        Dim k As Integer

        For k = 0 To midiSequence.dataLength - 1
            If k >= NoteOnIndex Then

                midiSequence.data(k).time = midiSequence.data(k).time.Subtract(tempTime)

            End If

        Next k


    End Sub



    Private Sub ChordMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChordMode.CheckedChanged
        If playNote = True Then
            playChord = True
            playNote = False
            ChordSelect.Enabled = True
        Else
            playChord = False
            playNote = True
            ChordSelect.Enabled = False
        End If

    End Sub

    Private Sub ChordSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChordSelect.SelectedIndexChanged

        Select Case ChordSelect.SelectedIndex
            Case 0
                major_chord = True
            Case 1
                minior_chord = True
            Case 2
                dominant = True
            Case 3
                augmented = True
        End Select

    End Sub


    Private Sub isLoopMod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isLoopMod.CheckedChanged
        isLoop = True

    End Sub



    '--------------------------------- WhiteBoard --------------------------



    Private Function sendMsgForWhiteboard(ByVal x As Double, ByVal y As Double) As Integer
        Dim pitch As Integer
        Dim lsb As Integer
        Dim msb As Integer


        ' Instrument is selected
        If cbXselected = 1 Or cbYselected = 1 Then

            ' ***** Add your code here
            tbInstrument.Value = IIf(cbXselected = 1, x * 127, y * 127)
            midimsg = &HC0 + channel + (tbInstrument.Value * &H100)
            midiOutShortMsg(hmidi, midimsg)

        End If

        ' Velocity is selected
        If cbXselected = 2 Or cbYselected = 2 Then

            ' ***** Add your code here
            volume = IIf(cbXselected = 2, x * 127, y * 127)
            vsbVolume.Value = 127 - volume

        End If

        ' Pitch is selected
        If cbXselected = 3 Or cbYselected = 3 Then

            ' ***** Add your code here
            pitch = IIf(cbXselected = 3, x * 127, y * 127)
            If lastMidiMessage <> -1 Then
                midimsg = lastMidiMessage And &HFFFFEF
                midiOutShortMsg(hmidi, midimsg)
            End If
            midimsg = &H90 + (pitch * &H100) + (volume * &H10000) + channel
            midiOutShortMsg(hmidi, midimsg)
            lastMidiMessage = midimsg

        End If

        ' stereo position is selected
        If cbXselected = 4 Or cbYselected = 4 Then
            tbPanning.Value = IIf(cbXselected = 4, x * 127, y * 127)

            midimsg = &HB0 + channel + (10 * &H100) + (tbPanning.Value * &H10000)
            midiOutShortMsg(hmidi, midimsg)

        End If

        ' pitch bend is selected
        If cbXselected = 5 Or cbYselected = 5 Then
            vsbPitchBend.Value = IIf(cbXselected = 5, x * 16383, y * 16383)

            lsb = vsbPitchBend.Value Mod 128
            msb = Math.Floor(vsbPitchBend.Value / 128)
            'Construct the MIDI message
            midimsg = &HE0 + channel + lsb * &H100 + msb * &H10000
            'Send the message to the card
            midiOutShortMsg(hmidi, midimsg)

        End If

    End Function

    Private Sub picWhiteboard_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picWhiteboard.MouseMove

        ' ***** Add your code here

        ' Check the range of the x and y values
        Dim x As Double, y As Double
        If Not e.Button = MouseButtons.Left Or
                e.X < 0 Or e.X > picWhiteboard.Width Or
                e.Y < 0 Or e.Y > picWhiteboard.Height Then
            Exit Sub
        End If

        ' Send MIDI messages based on the x and y range
        x = e.X / (picWhiteboard.Width - 1)
        y = e.Y / (picWhiteboard.Height - 1)

        ' Display the values in the x and y labels
        sendMsgForWhiteboard(x, y)

    End Sub

    Private Sub cboXTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboXTitle.SelectedIndexChanged
        If cboXTitle.SelectedIndex = cbYselected Then
            cboXTitle.SelectedIndex = cbXselected
        Else
            cbXselected = cboXTitle.SelectedIndex
        End If
    End Sub

    Private Sub cboYTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYTitle.SelectedIndexChanged
        If cboYTitle.SelectedIndex = cbXselected Then
            cboYTitle.SelectedIndex = cbYselected
        Else
            cbYselected = cboYTitle.SelectedIndex
        End If
    End Sub

    Private Sub picWhiteboard_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picWhiteboard.MouseDown

        ' ***** Add your code here
        picWhiteboard_MouseMove(sender, e)

    End Sub

    Private Sub picWhiteboard_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picWhiteboard.MouseUp

        ' ***** Add your code here
        If lastMidiMessage <> -1 Then
            midimsg = lastMidiMessage And &HFFFFEF
            midiOutShortMsg(hmidi, midimsg)
            lastMidiMessage = -1
        End If

    End Sub




    '-------------------------------------------------- DRUM ----------------------

    ' Draw the drum slots in a PictureBox (picDrum) in two rows
    Private Sub DrawDrumConfiguration(ByVal g As Graphics)
        Dim Slot, Drum As Short
        Dim X1, X2 As Single
        Dim Y1, Y2 As Single
        Dim Width, Height As Single

        ' The width and height of a slot in the drum machine
        Width = picDrum.ClientRectangle.Width / total_drum_slot     'TRY : change to tatal one
        Height = picDrum.ClientRectangle.Height / total_drum_instrument     'TRY : change to tatal one

        g.Clear(Color.White)

        'Create pens
        Dim blackBrush As New SolidBrush(Color.Black)
        Dim redPen As New Pen(Color.Red, 3)

        For Slot = 1 To total_drum_slot     'TRY : change to tatal one
            X1 = Width * (Slot - 1)
            X2 = Width * Slot

            For Drum = 1 To total_drum_instrument       'TRY : change to tatal one
                Y1 = Height * (Drum - 1)
                Y2 = Height * Drum

                ' Draw a black box if the slot is selected
                If drumSlot(Drum, Slot) Then
                    g.FillRectangle(blackBrush, X1, Y1, Width, Height)
                End If
            Next
            g.DrawLine(redPen, X1, 0, X1, (picDrum.ClientRectangle.Height))
        Next

        ' Draw the red separators between the slots
        For Drum = 1 To total_drum_instrument - 1           ' TRY  change to total one
            g.DrawLine(redPen, 0, Height * Drum, (picDrum.ClientRectangle.Width), Height * Drum)
        Next
    End Sub

    Private Sub picDrum_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picDrum.MouseDown
        Dim X As Single = e.X
        Dim Y As Single = e.Y
        Dim Drum, Slot As Short
        Dim Width, Height As Single

        Width = picDrum.ClientRectangle.Width / total_drum_slot       ' TRY : change to total_
        Height = picDrum.ClientRectangle.Height / total_drum_instrument       ' TRY : change to total_

        ' Determine the slot where the user has selected
        Slot = Math.Floor(X / Width) + 1
        Drum = Math.Floor(Y / Height) + 1

        ' Set/unset the drum slot
        drumSlot(Drum, Slot) = Not drumSlot(Drum, Slot)

        ' Redraw the drum machine
        DrawDrumConfiguration(picDrum.CreateGraphics())
    End Sub

    Private Sub tmrDrumPlayback_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDrumPlayback.Tick
        Static Slot As Short
        Static Slot_p As Short = 0
        Dim Drum As Short
        Dim X1, X2, Width As Single
        Dim bluePen As New Pen(Color.Blue, 3)
        Dim redPen As New Pen(Color.Red, 3)
        Dim g As Graphics = picDrum.CreateGraphics

        Width = picDrum.ClientRectangle.Width / total_drum_slot         ' TRY : change to total_

        X1 = Width * (Slot_p - 1)
        X2 = Width * (Slot - 1)


        'Draw the red line to overwrite the blue line

        ' *** Add your code here
        g.DrawLine(redPen, X1, 0, X1, (picDrum.ClientRectangle.Height))

        ' Initialize the slot number
        If Slot = 0 Then Slot = 1

        ' Start/Stop a drum for each row in the drum machine
        For Drum = 1 To total_drum_instrument                   ' TRY : change to total_
            If drumMessageSent(Drum) Then
                ' You need to stop any drum note already sent to
                ' the midi card by checking the variable DrumMessageSent

                ' *** Add your code here
                midimsg = &H89 + (drumNumber(Drum) * &H100) + (volume * &H10000)
                midiOutShortMsg(hmidi, midimsg)

            End If

            If drumSlot(Drum, Slot) Then
                ' Here, a drum slot is selected that means you have to
                ' start a midi note with the drum sound

                ' *** Add your code here
                midimsg = &H99 + (drumNumber(Drum) * &H100) + (volume * &H10000)
                midiOutShortMsg(hmidi, midimsg)

                drumMessageSent(Drum) = True
            Else
                drumMessageSent(Drum) = False
            End If
        Next


        'Draw the blue line

        ' *** Add your code here
        g.DrawLine(bluePen, X2, 0, X2, (picDrum.ClientRectangle.Height))

        'Save the current position
        Slot_p = Slot

        ' Increase the number by 1
        Slot = (Slot Mod total_drum_slot) + 1       ' TRY : change to total_
    End Sub

    ' Draw the drum machine
    Private Sub picDrum_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picDrum.Paint
        DrawDrumConfiguration(e.Graphics())
    End Sub

    Private Sub btnDrumstart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrumStart.Click
        ' start the drum timer
        tmrDrumPlayback.Enabled = True
    End Sub

    Private Sub btnDrumstop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrumStop.Click
        Dim Drum As Short

        'ReDraw the drum machine
        DrawDrumConfiguration(picDrum.CreateGraphics())

        ' stop the drum timer
        tmrDrumPlayback.Enabled = False

        ' You need to stop any drum note already sent to the midi card

        ' *** Add your code here
        For Drum = 1 To total_drum_instrument           ' TRY : change to total_
            If drumMessageSent(Drum) Then
                midimsg = &H89 + (drumNumber(Drum) * &H100) + (&H7F * &H10000)
                midiOutShortMsg(hmidi, midimsg)
            End If
        Next


    End Sub

    Private Sub picDisplay_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics = e.Graphics()

        g.Clear(Color.White)

        ' This code simply draws three rectangles on the picture box
        g.FillRectangle(Brushes.Black, 10, 10, 10, 2)
        g.FillRectangle(Brushes.Black, 20, 20, 10, 2)
        g.FillRectangle(Brushes.Black, 30, 30, 10, 2)
    End Sub

    ' ====================== LOAD MID File To midiSequencer

    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click

        Dim dlg As New OpenFileDialog
        Dim midiFile As MIDIFile
        Dim midiSequences() As SequenceData

        ' Ask for the MIDI file
        dlg.DefaultExt = "mid"
        dlg.Filter = "MIDI files (*.mid)|*.mid"
        dlg.Multiselect = False

        If dlg.ShowDialog() = DialogResult.OK Then
            ' Load the file into the MIDIFile structure
            midiFile = New MIDIFile(dlg.FileName)

            ' Convert the MIDI file into the SequenceData memory structure
            midiSequences = midiFile.ConvertToSequence()
            If midiSequences.Length > 0 Then
                ' Here the first track of the MIDI file is set into the sequencer memory
                midiSequence = midiSequences(0)
            End If
        End If
    End Sub



    Private Sub btnAddDrum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDrum.Click

        If total_drum_instrument < 5 Then
            picDrum.Height += 23
            total_drum_instrument += 1

            If total_drum_instrument > 2 Then
                Drum3ComboBox3.Enabled = True
                If total_drum_instrument > 3 Then
                    Drum4ComboBox4.Enabled = True
                    If total_drum_instrument > 4 Then
                        Drum5ComboBox5.Enabled = True
                    End If
                End If
            End If

            Dim tempdrumSlot(total_drum_instrument, total_drum_slot) As Boolean
            Dim tempdrumNumber(total_drum_instrument) As Short
            Dim tempdrumMessageSent(total_drum_instrument) As Boolean

            Dim i As Integer
            For i = 1 To total_drum_instrument - 1
                tempdrumNumber(i) = drumNumber(i)
                tempdrumMessageSent(i) = drumMessageSent(i)

                Dim j As Integer
                For j = 1 To total_drum_slot
                    tempdrumSlot(i, j) = drumSlot(i, j)
                Next j
            Next i

            ReDim drumSlot(total_drum_instrument, total_drum_slot)
            ReDim drumNumber(total_drum_instrument)
            ReDim drumMessageSent(total_drum_instrument)

            Dim k As Integer
            For k = 1 To total_drum_instrument - 1
                drumNumber(k) = tempdrumNumber(k)
                drumMessageSent(k) = tempdrumMessageSent(k)

                Dim j As Integer
                For j = 1 To total_drum_slot
                    drumSlot(k, j) = tempdrumSlot(k, j)
                Next j
            Next k

            Dim random As Random = New Random
            drumNumber(total_drum_instrument) = (random.Next Mod (81 - 35)) + 35

            ' Display the name in the ComboBox
            If total_drum_instrument = 5 Then
                Drum5ComboBox5.SelectedIndex = CInt(drumNumber(5) - 35)
            End If
            If total_drum_instrument = 4 Then
                Drum4ComboBox4.SelectedIndex = CInt(drumNumber(4) - 35)
            End If
            If total_drum_instrument = 3 Then
                Drum3ComboBox3.SelectedIndex = CInt(drumNumber(3) - 35)
            End If

            DrawDrumConfiguration(picDrum.CreateGraphics())
        End If

    End Sub


    Private Sub btnDelDrum_Click(sender As System.Object, e As System.EventArgs) Handles btnDelDrum.Click
        If total_drum_instrument > 2 Then
            picDrum.Height -= 23
            total_drum_instrument -= 1



            If total_drum_instrument < 5 Then
                Drum5ComboBox5.Enabled = False
                If total_drum_instrument < 4 Then
                    Drum4ComboBox4.Enabled = False
                    If total_drum_instrument < 3 Then
                        Drum3ComboBox3.Enabled = False
                    End If
                End If
            End If

            Dim tempdrumSlot(total_drum_instrument, total_drum_slot) As Boolean
            Dim tempdrumNumber(total_drum_instrument) As Short
            Dim tempdrumMessageSent(total_drum_instrument) As Boolean

            Dim i As Integer
            For i = 1 To total_drum_instrument
                tempdrumNumber(i) = drumNumber(i)
                tempdrumMessageSent(i) = drumMessageSent(i)

                Dim j As Integer
                For j = 1 To total_drum_slot
                    tempdrumSlot(i, j) = drumSlot(i, j)
                Next j
            Next i

            ReDim drumNumber(total_drum_instrument)
            ReDim drumMessageSent(total_drum_instrument)
            ReDim drumSlot(total_drum_instrument, total_drum_slot)

            Dim k As Integer
            For k = 1 To total_drum_instrument
                drumNumber(k) = tempdrumNumber(k)
                drumMessageSent(k) = tempdrumMessageSent(k)

                Dim j As Integer
                For j = 1 To total_drum_slot
                    drumSlot(k, j) = tempdrumSlot(k, j)
                Next j
            Next k

            DrawDrumConfiguration(picDrum.CreateGraphics())
        End If

    End Sub

    Private Sub btnAddSlot_Click(sender As System.Object, e As System.EventArgs) Handles btnAddSlot.Click
        If total_drum_slot < 16 Then
            total_drum_slot += 1
            picDrum.Width += 38

            Dim tempdrumSlot(total_drum_instrument, total_drum_slot) As Boolean
            Dim tempdrumNumber(total_drum_instrument) As Short
            Dim tempdrumMessageSent(total_drum_instrument) As Boolean

            Dim i As Integer
            For i = 1 To total_drum_instrument
                tempdrumNumber(i) = drumNumber(i)
                tempdrumMessageSent(i) = drumMessageSent(i)

                Dim j As Integer
                For j = 1 To total_drum_slot - 1
                    tempdrumSlot(i, j) = drumSlot(i, j)
                Next j
            Next i

            ReDim drumSlot(total_drum_instrument, total_drum_slot)
            ReDim drumNumber(total_drum_instrument)
            ReDim drumMessageSent(total_drum_instrument)

            Dim k As Integer
            For k = 1 To total_drum_instrument
                drumNumber(k) = tempdrumNumber(k)
                drumMessageSent(k) = tempdrumMessageSent(k)

                Dim j As Integer
                For j = 1 To total_drum_slot - 1
                    drumSlot(k, j) = tempdrumSlot(k, j)
                Next j
            Next k

            DrawDrumConfiguration(picDrum.CreateGraphics())
        End If
    End Sub

    Private Sub btnDelSlot_Click(sender As System.Object, e As System.EventArgs) Handles btnDelSlot.Click
        If total_drum_slot > 8 Then
            total_drum_slot -= 1
            picDrum.Width -= 38

            Dim tempdrumSlot(total_drum_instrument, total_drum_slot) As Boolean
            Dim tempdrumNumber(total_drum_instrument) As Short
            Dim tempdrumMessageSent(total_drum_instrument) As Boolean

            Dim i As Integer
            For i = 1 To total_drum_instrument
                tempdrumNumber(i) = drumNumber(i)
                tempdrumMessageSent(i) = drumMessageSent(i)

                Dim j As Integer
                For j = 1 To total_drum_slot
                    tempdrumSlot(i, j) = drumSlot(i, j)
                Next j
            Next i

            ReDim drumSlot(total_drum_instrument, total_drum_slot)
            ReDim drumNumber(total_drum_instrument)
            ReDim drumMessageSent(total_drum_instrument)

            Dim k As Integer
            For k = 1 To total_drum_instrument
                drumNumber(k) = tempdrumNumber(k)
                drumMessageSent(k) = tempdrumMessageSent(k)

                Dim j As Integer
                For j = 1 To total_drum_slot
                    drumSlot(k, j) = tempdrumSlot(k, j)
                Next j
            Next k

            DrawDrumConfiguration(picDrum.CreateGraphics())
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Dim i As Integer
        For i = 1 To total_drum_instrument
            Dim j As Integer
            For j = 1 To total_drum_slot
                drumSlot(i, j) = False
            Next j
        Next i

        Dim Drum As Short

        'ReDraw the drum machine
        DrawDrumConfiguration(picDrum.CreateGraphics())

        ' stop the drum timer
        tmrDrumPlayback.Enabled = False

        ' You need to stop any drum note already sent to the midi card
        For Drum = 1 To total_drum_instrument
            If drumMessageSent(Drum) Then
                midimsg = &H89 + (drumNumber(Drum) * &H100) + (&H7F * &H10000)
                midiOutShortMsg(hmidi, midimsg)
            End If

        Next Drum
    End Sub

    Private Sub btnBoxInversion_Click(sender As System.Object, e As System.EventArgs) Handles btnBoxInversion.Click
        Dim i As Integer
        For i = 1 To total_drum_instrument
            Dim j As Integer
            For j = 1 To total_drum_slot
                drumSlot(i, j) = Not drumSlot(i, j)
            Next j
        Next i
        DrawDrumConfiguration(picDrum.CreateGraphics())
    End Sub

    Private Sub btnBoxReversion_Click(sender As System.Object, e As System.EventArgs) Handles btnBoxReversion.Click
        Dim tempDrumSlot(DRUM_INSTRUMENT, DRUM_SLOT) As Boolean

        Dim i As Integer
        For i = 1 To total_drum_instrument
            Dim j As Integer
            For j = 1 To total_drum_slot
                tempDrumSlot(i, j) = drumSlot(i, j)
            Next j
        Next i

        Dim k As Integer
        For k = 1 To total_drum_instrument
            Dim j As Integer
            For j = 1 To total_drum_slot
                drumSlot(k, j) = tempDrumSlot(k, total_drum_slot + 1 - j)
            Next j
        Next k
        DrawDrumConfiguration(picDrum.CreateGraphics())
    End Sub

    Private Sub btnRandSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnRandSelect.Click
        Dim k As Integer
        For k = 1 To total_drum_instrument
            Dim j As Integer
            For j = 1 To total_drum_slot
                Dim random As Random = New Random

                drumSlot(k, j) = CInt(Rnd()) Mod 2
            Next j
        Next k
        DrawDrumConfiguration(picDrum.CreateGraphics())
    End Sub

    Private Sub tbDrumSpeed_Scroll(sender As System.Object, e As System.EventArgs) Handles tbDrumSpeed.Scroll
        If tbDrumSpeed.Value > 0 Then
            speed = 1 - tbDrumSpeed.Value / 10.0
        Else
            speed = 1 - tbDrumSpeed.Value / 10.0
        End If

        tmrDrumPlayback.Interval = 250 * speed
    End Sub


    Private Sub Drum1ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Drum1ComboBox1.SelectedIndexChanged
        drumNumber(1) = Drum1ComboBox1.SelectedIndex + 35
    End Sub

    Private Sub Drum2ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Drum2ComboBox2.SelectedIndexChanged
        drumNumber(2) = Drum2ComboBox2.SelectedIndex + 35
    End Sub

    Private Sub vsbPitchBend_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles vsbPitchBend.Scroll
        Dim lsb As Integer = (16383 - vsbPitchBend.Value) Mod 128
        Dim msb As Integer = Math.Floor((16383 - vsbPitchBend.Value) / 128)

        midimsg = &HE0 + channel + (lsb * &H100) + (msb * &H10000)
        midiOutShortMsg(hmidi, midimsg)

    End Sub

    Private Sub tbPitchTrans_Scroll(sender As System.Object, e As System.EventArgs) Handles tbPitchTrans.Scroll
        isPitchTrans = True
    End Sub

    Private Sub Drum3ComboBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Drum3ComboBox3.SelectedIndexChanged
        If total_drum_instrument > 2 Then
            Drum3ComboBox3.Enabled = True
            drumNumber(3) = Drum3ComboBox3.SelectedIndex + 35
        End If

    End Sub

    Private Sub Drum4ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Drum4ComboBox4.SelectedIndexChanged
        If total_drum_instrument > 3 Then
            Drum4ComboBox4.Enabled = True
            drumNumber(4) = Drum4ComboBox4.SelectedIndex + 35
        End If

    End Sub

    Private Sub Drum5ComboBox5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Drum5ComboBox5.SelectedIndexChanged
        If total_drum_instrument > 4 Then
            Drum5ComboBox5.Enabled = True
            drumNumber(5) = Drum5ComboBox5.SelectedIndex + 35
        End If

    End Sub




    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim sr As New StreamReader("rhythm.txt")
        Dim word As String = ""
        Dim words(16) As String
        Dim row As Integer = 1
        Dim isFirstLine As Boolean = True

        Do Until sr.Peek = -1
            

            If isFirstLine Then
                isFirstLine = False

                'grad one word at a time from the text file
                word = sr.ReadLine()

                'place word into array
                words = word.Split(" ")

                total_drum_instrument = words(0)
                picDrum.Height += 23 * (total_drum_instrument - 2)
                total_drum_slot = words(1)
                picDrum.Width += 38 * (total_drum_slot - 2)
                ReDim drumNumber(total_drum_instrument)
                ReDim drumMessageSent(total_drum_instrument)
                ReDim drumSlot(total_drum_instrument, total_drum_slot)

                DrawDrumConfiguration(picDrum.CreateGraphics())
            End If

            'grad one word at a time from the text file
            word = sr.ReadLine()
          
            'place word into array
            words = word.Split(" ")
           
            Dim index_line As Integer
            For index_line = 1 To total_drum_slot + 1
                If index_line = total_drum_slot + 1 Then
                    drumNumber(row) = CShort(words(index_line - 1))
                    Exit For
                End If
                drumSlot(row, index_line) = CBool(words(index_line - 1))
            Next index_line

                DrawDrumConfiguration(picDrum.CreateGraphics())

            row += 1
        Loop
        'DrawDrumConfiguration(picDrum.CreateGraphics())

    End Sub
End Class
