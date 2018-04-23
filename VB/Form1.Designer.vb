Imports Microsoft.VisualBasic
Imports System
Namespace Pivot_Reorder
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.splitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
			Me.pivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
			Me.pivotGridField1 = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.pivotGridField2 = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.pivotGridField3 = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.pivotGridField4 = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.pivotGridField5 = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.pivotGridField6 = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.pivotGridField7 = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.checkEdit7 = New DevExpress.XtraEditors.CheckEdit()
			Me.checkEdit6 = New DevExpress.XtraEditors.CheckEdit()
			Me.checkEdit5 = New DevExpress.XtraEditors.CheckEdit()
			Me.checkEdit4 = New DevExpress.XtraEditors.CheckEdit()
			Me.checkEdit3 = New DevExpress.XtraEditors.CheckEdit()
			Me.checkEdit1 = New DevExpress.XtraEditors.CheckEdit()
			Me.checkEdit2 = New DevExpress.XtraEditors.CheckEdit()
			Me.layoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
			Me.layoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.splitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.splitContainerControl1.SuspendLayout()
			CType(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.checkEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.checkEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.checkEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.checkEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.checkEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.checkEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' splitContainerControl1
			' 
			Me.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
			Me.splitContainerControl1.Location = New System.Drawing.Point(0, 0)
			Me.splitContainerControl1.Name = "splitContainerControl1"
			Me.splitContainerControl1.Panel1.Controls.Add(Me.pivotGridControl1)
			Me.splitContainerControl1.Panel1.Text = "Panel1"
			Me.splitContainerControl1.Panel2.Controls.Add(Me.layoutControl1)
			Me.splitContainerControl1.Panel2.Text = "Panel2"
			Me.splitContainerControl1.Size = New System.Drawing.Size(945, 474)
			Me.splitContainerControl1.SplitterPosition = 207
			Me.splitContainerControl1.TabIndex = 0
			Me.splitContainerControl1.Text = "splitContainerControl1"
			' 
			' pivotGridControl1
			' 
			Me.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.pivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() { Me.pivotGridField1, Me.pivotGridField2, Me.pivotGridField3, Me.pivotGridField4, Me.pivotGridField5, Me.pivotGridField6, Me.pivotGridField7})
			Me.pivotGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.pivotGridControl1.Name = "pivotGridControl1"
			Me.pivotGridControl1.OptionsSelection.MaxHeight = 0
			Me.pivotGridControl1.OptionsSelection.MaxWidth = 0
			Me.pivotGridControl1.OptionsSelection.MultiSelect = False
			Me.pivotGridControl1.Size = New System.Drawing.Size(733, 474)
			Me.pivotGridControl1.TabIndex = 0
			' 
			' pivotGridField1
			' 
			Me.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
			Me.pivotGridField1.AreaIndex = 0
			Me.pivotGridField1.FieldName = "Value"
			Me.pivotGridField1.Name = "pivotGridField1"
			' 
			' pivotGridField2
			' 
			Me.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.pivotGridField2.AreaIndex = 0
			Me.pivotGridField2.Caption = "Year"
			Me.pivotGridField2.FieldName = "Date"
			Me.pivotGridField2.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear
			Me.pivotGridField2.Name = "pivotGridField2"
			Me.pivotGridField2.UnboundFieldName = "pivotGridField2"
			' 
			' pivotGridField3
			' 
			Me.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.pivotGridField3.AreaIndex = 1
			Me.pivotGridField3.Caption = "Month"
			Me.pivotGridField3.FieldName = "Date"
			Me.pivotGridField3.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth
			Me.pivotGridField3.Name = "pivotGridField3"
			Me.pivotGridField3.UnboundFieldName = "pivotGridField3"
			' 
			' pivotGridField4
			' 
			Me.pivotGridField4.AreaIndex = 0
			Me.pivotGridField4.Caption = "Day"
			Me.pivotGridField4.FieldName = "Date"
			Me.pivotGridField4.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateDay
			Me.pivotGridField4.Name = "pivotGridField4"
			Me.pivotGridField4.UnboundFieldName = "pivotGridField4"
			' 
			' pivotGridField5
			' 
			Me.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.pivotGridField5.AreaIndex = 2
			Me.pivotGridField5.FieldName = "Name"
			Me.pivotGridField5.Name = "pivotGridField5"
			Me.pivotGridField5.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom
			' 
			' pivotGridField6
			' 
			Me.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.pivotGridField6.AreaIndex = 0
			Me.pivotGridField6.FieldName = "GroupL1"
			Me.pivotGridField6.Name = "pivotGridField6"
			Me.pivotGridField6.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom
			' 
			' pivotGridField7
			' 
			Me.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.pivotGridField7.AreaIndex = 1
			Me.pivotGridField7.FieldName = "GroupL2"
			Me.pivotGridField7.Name = "pivotGridField7"
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.checkEdit7)
			Me.layoutControl1.Controls.Add(Me.checkEdit6)
			Me.layoutControl1.Controls.Add(Me.checkEdit5)
			Me.layoutControl1.Controls.Add(Me.checkEdit4)
			Me.layoutControl1.Controls.Add(Me.checkEdit3)
			Me.layoutControl1.Controls.Add(Me.checkEdit1)
			Me.layoutControl1.Controls.Add(Me.checkEdit2)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.layoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlGroup2, Me.layoutControlGroup3})
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(999, 275, 250, 350)
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(207, 474)
			Me.layoutControl1.TabIndex = 2
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' checkEdit7
			' 
			Me.checkEdit7.EditValue = True
			Me.checkEdit7.Location = New System.Drawing.Point(24, 43)
			Me.checkEdit7.Name = "checkEdit7"
			Me.checkEdit7.Properties.Caption = "Allow Move Columns"
			Me.checkEdit7.Size = New System.Drawing.Size(159, 19)
			Me.checkEdit7.StyleController = Me.layoutControl1
			Me.checkEdit7.TabIndex = 7
'			Me.checkEdit7.CheckedChanged += New System.EventHandler(Me.checkEdit7_CheckedChanged);
			' 
			' checkEdit6
			' 
			Me.checkEdit6.EditValue = True
			Me.checkEdit6.Location = New System.Drawing.Point(24, 132)
			Me.checkEdit6.Name = "checkEdit6"
			Me.checkEdit6.Properties.Caption = "Allow Move Rows"
			Me.checkEdit6.Size = New System.Drawing.Size(159, 19)
			Me.checkEdit6.StyleController = Me.layoutControl1
			Me.checkEdit6.TabIndex = 6
'			Me.checkEdit6.CheckedChanged += New System.EventHandler(Me.checkEdit6_CheckedChanged);
			' 
			' checkEdit5
			' 
			Me.checkEdit5.EditValue = True
			Me.checkEdit5.Location = New System.Drawing.Point(24, 66)
			Me.checkEdit5.Name = "checkEdit5"
			Me.checkEdit5.Properties.Caption = "Allow Change Column Group"
			Me.checkEdit5.Size = New System.Drawing.Size(159, 19)
			Me.checkEdit5.StyleController = Me.layoutControl1
			Me.checkEdit5.TabIndex = 5
'			Me.checkEdit5.CheckedChanged += New System.EventHandler(Me.checkEdit5_CheckedChanged);
			' 
			' checkEdit4
			' 
			Me.checkEdit4.Location = New System.Drawing.Point(24, 66)
			Me.checkEdit4.Name = "checkEdit4"
			Me.checkEdit4.Properties.Caption = "Allow Change Column Group"
			Me.checkEdit4.Size = New System.Drawing.Size(207, 19)
			Me.checkEdit4.StyleController = Me.layoutControl1
			Me.checkEdit4.TabIndex = 5
			' 
			' checkEdit3
			' 
			Me.checkEdit3.EditValue = True
			Me.checkEdit3.Location = New System.Drawing.Point(24, 155)
			Me.checkEdit3.Name = "checkEdit3"
			Me.checkEdit3.Properties.Caption = "Allow Change Row Group"
			Me.checkEdit3.Size = New System.Drawing.Size(159, 19)
			Me.checkEdit3.StyleController = Me.layoutControl1
			Me.checkEdit3.TabIndex = 4
'			Me.checkEdit3.CheckedChanged += New System.EventHandler(Me.checkEdit3_CheckedChanged);
'			Me.checkEdit3.CheckStateChanged += New System.EventHandler(Me.checkEdit3_CheckStateChanged);
			' 
			' checkEdit1
			' 
			Me.checkEdit1.Location = New System.Drawing.Point(24, 132)
			Me.checkEdit1.Name = "checkEdit1"
			Me.checkEdit1.Properties.Caption = "Reorder Rows"
			Me.checkEdit1.Size = New System.Drawing.Size(207, 19)
			Me.checkEdit1.StyleController = Me.layoutControl1
			Me.checkEdit1.TabIndex = 0
			' 
			' checkEdit2
			' 
			Me.checkEdit2.Location = New System.Drawing.Point(24, 43)
			Me.checkEdit2.Name = "checkEdit2"
			Me.checkEdit2.Properties.Caption = "Reorder Columns"
			Me.checkEdit2.Size = New System.Drawing.Size(207, 19)
			Me.checkEdit2.StyleController = Me.layoutControl1
			Me.checkEdit2.TabIndex = 1
			' 
			' layoutControlGroup2
			' 
			Me.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2"
			Me.layoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1})
			Me.layoutControlGroup2.Location = New System.Drawing.Point(0, 89)
			Me.layoutControlGroup2.Name = "layoutControlGroup2"
			Me.layoutControlGroup2.Size = New System.Drawing.Size(235, 66)
			Me.layoutControlGroup2.Text = "layoutControlGroup2"
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.checkEdit1
			Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(211, 23)
			Me.layoutControlItem1.Text = "layoutControlItem1"
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem1.TextToControlDistance = 0
			Me.layoutControlItem1.TextVisible = False
			' 
			' layoutControlGroup3
			' 
			Me.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3"
			Me.layoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem2, Me.layoutControlItem4})
			Me.layoutControlGroup3.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup3.Name = "layoutControlGroup3"
			Me.layoutControlGroup3.Size = New System.Drawing.Size(235, 89)
			Me.layoutControlGroup3.Text = "layoutControlGroup3"
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.checkEdit2
			Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
			Me.layoutControlItem2.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(211, 23)
			Me.layoutControlItem2.Text = "layoutControlItem2"
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem2.TextToControlDistance = 0
			Me.layoutControlItem2.TextVisible = False
			' 
			' layoutControlItem4
			' 
			Me.layoutControlItem4.Control = Me.checkEdit4
			Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
			Me.layoutControlItem4.Location = New System.Drawing.Point(0, 23)
			Me.layoutControlItem4.Name = "layoutControlItem4"
			Me.layoutControlItem4.Size = New System.Drawing.Size(211, 23)
			Me.layoutControlItem4.Text = "layoutControlItem4"
			Me.layoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem4.TextToControlDistance = 0
			Me.layoutControlItem4.TextVisible = False
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.CustomizationFormText = "Root"
			Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
			Me.layoutControlGroup1.GroupBordersVisible = False
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.emptySpaceItem1, Me.layoutControlGroup4, Me.layoutControlGroup5})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "Root"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(207, 474)
			Me.layoutControlGroup1.Text = "Root"
			Me.layoutControlGroup1.TextVisible = False
			' 
			' emptySpaceItem1
			' 
			Me.emptySpaceItem1.AllowHotTrack = False
			Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
			Me.emptySpaceItem1.Location = New System.Drawing.Point(0, 178)
			Me.emptySpaceItem1.Name = "emptySpaceItem1"
			Me.emptySpaceItem1.Size = New System.Drawing.Size(187, 276)
			Me.emptySpaceItem1.Text = "emptySpaceItem1"
			Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
			' 
			' layoutControlGroup4
			' 
			Me.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4"
			Me.layoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem6, Me.layoutControlItem3})
			Me.layoutControlGroup4.Location = New System.Drawing.Point(0, 89)
			Me.layoutControlGroup4.Name = "layoutControlGroup4"
			Me.layoutControlGroup4.Size = New System.Drawing.Size(187, 89)
			Me.layoutControlGroup4.Text = "layoutControlGroup4"
			' 
			' layoutControlItem6
			' 
			Me.layoutControlItem6.Control = Me.checkEdit6
			Me.layoutControlItem6.CustomizationFormText = "layoutControlItem6"
			Me.layoutControlItem6.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem6.Name = "layoutControlItem6"
			Me.layoutControlItem6.Size = New System.Drawing.Size(163, 23)
			Me.layoutControlItem6.Text = "layoutControlItem6"
			Me.layoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem6.TextToControlDistance = 0
			Me.layoutControlItem6.TextVisible = False
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.checkEdit3
			Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
			Me.layoutControlItem3.Location = New System.Drawing.Point(0, 23)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(163, 23)
			Me.layoutControlItem3.Text = "layoutControlItem3"
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem3.TextToControlDistance = 0
			Me.layoutControlItem3.TextVisible = False
			' 
			' layoutControlGroup5
			' 
			Me.layoutControlGroup5.CustomizationFormText = "layoutControlGroup5"
			Me.layoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem5, Me.layoutControlItem7})
			Me.layoutControlGroup5.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup5.Name = "layoutControlGroup5"
			Me.layoutControlGroup5.Size = New System.Drawing.Size(187, 89)
			Me.layoutControlGroup5.Text = "layoutControlGroup5"
			' 
			' layoutControlItem5
			' 
			Me.layoutControlItem5.Control = Me.checkEdit5
			Me.layoutControlItem5.CustomizationFormText = "layoutControlItem5"
			Me.layoutControlItem5.Location = New System.Drawing.Point(0, 23)
			Me.layoutControlItem5.Name = "layoutControlItem5"
			Me.layoutControlItem5.Size = New System.Drawing.Size(163, 23)
			Me.layoutControlItem5.Text = "layoutControlItem5"
			Me.layoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem5.TextToControlDistance = 0
			Me.layoutControlItem5.TextVisible = False
			' 
			' layoutControlItem7
			' 
			Me.layoutControlItem7.Control = Me.checkEdit7
			Me.layoutControlItem7.CustomizationFormText = "layoutControlItem7"
			Me.layoutControlItem7.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem7.Name = "layoutControlItem7"
			Me.layoutControlItem7.Size = New System.Drawing.Size(163, 23)
			Me.layoutControlItem7.Text = "layoutControlItem7"
			Me.layoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem7.TextToControlDistance = 0
			Me.layoutControlItem7.TextVisible = False
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(945, 474)
			Me.Controls.Add(Me.splitContainerControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.splitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.splitContainerControl1.ResumeLayout(False)
			CType(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.checkEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.checkEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.checkEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.checkEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.checkEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.checkEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private splitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
		Private pivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private checkEdit4 As DevExpress.XtraEditors.CheckEdit
		Private WithEvents checkEdit3 As DevExpress.XtraEditors.CheckEdit
		Private checkEdit1 As DevExpress.XtraEditors.CheckEdit
		Private checkEdit2 As DevExpress.XtraEditors.CheckEdit
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
		Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
		Private pivotGridField1 As DevExpress.XtraPivotGrid.PivotGridField
		Private pivotGridField2 As DevExpress.XtraPivotGrid.PivotGridField
		Private pivotGridField3 As DevExpress.XtraPivotGrid.PivotGridField
		Private pivotGridField4 As DevExpress.XtraPivotGrid.PivotGridField
		Private pivotGridField5 As DevExpress.XtraPivotGrid.PivotGridField
		Private pivotGridField6 As DevExpress.XtraPivotGrid.PivotGridField
		Private pivotGridField7 As DevExpress.XtraPivotGrid.PivotGridField
		Private WithEvents checkEdit7 As DevExpress.XtraEditors.CheckEdit
		Private WithEvents checkEdit6 As DevExpress.XtraEditors.CheckEdit
		Private WithEvents checkEdit5 As DevExpress.XtraEditors.CheckEdit
		Private layoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
	End Class
End Namespace

