Imports Microsoft.VisualBasic
Imports DevExpress.XtraPivotGrid
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Pivot_Reorder
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private helper As ReorderHelper
		Private Shared Function CreatePivotTable(ByVal RowCount As Integer) As DataTable
			Dim rnd As New Random()

			Dim tbl As New DataTable()
			tbl.Columns.Add("ID", GetType(Integer)).Unique = True
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("GroupL1", GetType(String))
			tbl.Columns.Add("GroupL2", GetType(String))
			tbl.Columns.Add("Value", GetType(Decimal))
			tbl.Columns.Add("Date", GetType(DateTime))

			tbl.PrimaryKey = New DataColumn() { tbl.Columns("ID") }
			For i As Integer = 0 To RowCount - 1
				Dim row As DataRow = tbl.Rows.Add(New Object() { i, String.Format("Name{0}", i Mod 27),String.Format("1 Level Group{0}", i Mod 3),String.Format("2 Level Group{0}", i Mod 9), rnd.Next(50), DateTime.Now.AddDays(rnd.Next(-300,300)) })

			Next i
			Return tbl
		End Function

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			pivotGridControl1.DataSource = CreatePivotTable(1000)
			helper = New ReorderHelper(pivotGridControl1)
			helper.AllowChangeColumnGroup = True
			helper.AllowChangeRowGroup = True
			helper.AllowDragColumn = True
			helper.AllowDragRow = True
		End Sub

		Private Sub checkEdit3_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEdit3.CheckStateChanged

		End Sub

		Private Sub checkEdit3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEdit3.CheckedChanged
			helper.AllowChangeRowGroup = checkEdit3.Checked
		End Sub

		Private Sub checkEdit7_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEdit7.CheckedChanged
			helper.AllowDragColumn = checkEdit7.Checked
		End Sub

		Private Sub checkEdit6_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEdit6.CheckedChanged
			helper.AllowDragRow = checkEdit6.Checked
		End Sub

		Private Sub checkEdit5_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEdit5.CheckedChanged
			helper.AllowChangeColumnGroup = checkEdit5.Checked
		End Sub


	End Class
End Namespace
