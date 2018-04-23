Imports Microsoft.VisualBasic
Imports DevExpress.XtraPivotGrid
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Pivot_Reorder
	Friend Class ReorderHelper
		Private targetPivot_Renamed As PivotGridControl
		Private ReadOnly Property TargetPivot() As PivotGridControl
			Get
				Return targetPivot_Renamed
			End Get
		End Property
		Private privateAllowChangeRowGroup As Boolean
		Public Property AllowChangeRowGroup() As Boolean
			Get
				Return privateAllowChangeRowGroup
			End Get
			Set(ByVal value As Boolean)
				privateAllowChangeRowGroup = value
			End Set
		End Property
		Private privateAllowChangeColumnGroup As Boolean
		Public Property AllowChangeColumnGroup() As Boolean
			Get
				Return privateAllowChangeColumnGroup
			End Get
			Set(ByVal value As Boolean)
				privateAllowChangeColumnGroup = value
			End Set
		End Property
		Private _allowDragRow As Boolean
		Public Property AllowDragRow() As Boolean
			Get
				Return _allowDragRow
			End Get
			Set(ByVal value As Boolean)
				If _allowDragRow = value Then
					Return
				End If
				_allowDragRow = value
				If _allowDragRow Then
					InitRowsOrder()
				End If
			End Set
		End Property
		Private _allowDragColumn As Boolean
		Public Property AllowDragColumn() As Boolean
			Get
				Return _allowDragColumn
			End Get
			Set(ByVal value As Boolean)
				If _allowDragColumn = value Then
					Return
				End If
				_allowDragColumn = value
				If _allowDragColumn Then
					InitColumnsOrder()
				End If
			End Set
		End Property


		Public Sub New(ByVal pivot As PivotGridControl)
			AllowChangeRowGroup = False
			AllowChangeColumnGroup = False
			AllowDragColumn = False
			Attach(pivot)
		End Sub
		Public Sub Attach(ByVal pivot As PivotGridControl)
			If targetPivot_Renamed Is pivot Then
				Return
			ElseIf targetPivot_Renamed IsNot Nothing Then
				Detach(targetPivot_Renamed)
			End If

			targetPivot_Renamed = pivot
			AddHandler targetPivot_Renamed.CustomFieldSort, AddressOf targetPivot_CustomFieldSort
			AddHandler targetPivot_Renamed.MouseMove, AddressOf targetPivot_MouseMove
			AddHandler targetPivot_Renamed.MouseUp, AddressOf targetPivot_MouseUp
			AddHandler targetPivot_Renamed.FieldAreaChanged, AddressOf targetPivot_FieldAreaChanged
			AddHandler targetPivot_Renamed.CustomDrawFieldValue, AddressOf targetPivot_CustomDrawFieldValue
		End Sub

		Private Sub targetPivot_CustomDrawFieldValue(ByVal sender As Object, ByVal e As PivotCustomDrawFieldValueEventArgs)
			If onDrag Then
				'if (e.ValueType != PivotGridValueType.Value) return;
				'if(e.Field ==)
                If e.Field Is dragInfo.ValueInfo.Field AndAlso e.Bounds.Contains(dragInfo.HitPoint) Then
                    e.Painter.DrawObject(e.Info)
                    e.Handled = True
                    Dim rec As Rectangle = e.Info.CaptionRect
                    e.Graphics.DrawRectangle(Pens.Blue, rec)
                    Return
                End If
                If TargetInfo IsNot Nothing AndAlso e.Field Is TargetInfo.ValueInfo.Field AndAlso e.Bounds.Contains(TargetInfo.HitPoint) Then
                    e.Painter.DrawObject(e.Info)
                    e.Handled = True
                    Dim rec As Rectangle = e.Info.CaptionRect
                    e.Graphics.DrawRectangle(Pens.Green, rec)
                    Return
                End If
			End If
			'throw new NotImplementedException();
		End Sub

		Private Sub targetPivot_FieldAreaChanged(ByVal sender As Object, ByVal e As PivotFieldEventArgs)
			If (e.Field.Area = PivotArea.ColumnArea AndAlso AllowDragColumn) OrElse (e.Field.Area = PivotArea.RowArea AndAlso AllowDragRow) Then
				InitSingleFieldOrder(e.Field)
			End If
		End Sub

		Private Sub InitRowsOrder()
			For Each field As PivotGridField In targetPivot_Renamed.GetFieldsByArea(PivotArea.RowArea)
				InitSingleFieldOrder(field)
			Next field
		End Sub
		Private Sub InitSingleFieldOrder(ByVal field As PivotGridField)
			Dim allowedValues() As Object = field.GetUniqueValues()
			'IEnumerable<object> sortedGroupValues = allowedValues.OrderBy(value => value.ToString());
			Dim orderList As New List(Of Object)()
			'foreach (object groupValue in sortedGroupValues)
			For Each groupValue As Object In allowedValues
				orderList.Add(groupValue)
			Next groupValue
			field.Tag = orderList
			field.SortMode = PivotSortMode.Custom
		End Sub

		Private Sub RemoveSingleFieldOrder(ByVal field As PivotGridField)
			field.SortMode = PivotSortMode.Default
		End Sub

		Private Sub InitColumnsOrder()
			For Each field As PivotGridField In targetPivot_Renamed.GetFieldsByArea(PivotArea.ColumnArea)
				InitSingleFieldOrder(field)
			Next field
		End Sub
		Public Sub Detach(ByVal pivot As PivotGridControl)
			For Each field As PivotGridField In targetPivot_Renamed.Fields
					field.Tag = Nothing
					field.SortMode = PivotSortMode.Default
			Next field

		End Sub
		Private Sub targetPivot_CustomFieldSort(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs)
			If AllowDragRow AndAlso e.Field.Area = PivotArea.RowArea Then
				Dim orderlist As List(Of Object) = TryCast(e.Field.Tag, List(Of Object))
				'Comparer comp = new Comparer;
				If orderlist Is Nothing OrElse orderlist.IndexOf(e.Value1) = -1 OrElse orderlist.IndexOf(e.Value2) = -1 Then
					'e.Result = Comparer.DefaultInvariant.Compare(e.Value1, e.Value2);
					'e.Handled = true;
					Return
				End If
				e.Result = Comparer.DefaultInvariant.Compare(orderlist.IndexOf(e.Value1), orderlist.IndexOf(e.Value2))
				e.Handled = True
			End If
			If AllowDragColumn AndAlso e.Field.Area = PivotArea.ColumnArea Then
				Dim orderlist As List(Of Object) = TryCast(e.Field.Tag, List(Of Object))
				If orderlist Is Nothing OrElse orderlist.IndexOf(e.Value1) = -1 OrElse orderlist.IndexOf(e.Value2) = -1 Then
					Return
				End If
				e.Result = Comparer.DefaultInvariant.Compare(orderlist.IndexOf(e.Value1), orderlist.IndexOf(e.Value2))
				e.Handled = True
			End If
		End Sub
		Private dragInfo As PivotGridHitInfo
		Private _targetInfo As PivotGridHitInfo
		Private Property TargetInfo() As PivotGridHitInfo
			Get
				Return _targetInfo
			End Get
			Set(ByVal value As PivotGridHitInfo)
				_targetInfo = value
			End Set
		End Property
		Private onDrag As Boolean = False
		Private Sub targetPivot_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			If (Not onDrag) Then
				If e.Button = System.Windows.Forms.MouseButtons.Left Then
					Dim hi As PivotGridHitInfo = targetPivot_Renamed.CalcHitInfo(e.Location)
					If hi.HitTest = PivotGridHitTest.Value Then
						If (AllowDragRow AndAlso hi.ValueInfo.Field.Area = PivotArea.RowArea) OrElse (AllowDragColumn AndAlso hi.ValueInfo.Field.Area = PivotArea.ColumnArea) Then
							dragInfo = hi
							onDrag = True
							targetPivot_Renamed.FindForm().Cursor = Cursors.Hand
						End If
					End If
				End If
			Else
				Dim allowedEffect As DragDropEffects = GetDragEffect(e.Location)
				If allowedEffect = DragDropEffects.None Then
					targetPivot_Renamed.FindForm().Cursor = Cursors.No
				Else
					targetPivot_Renamed.FindForm().Cursor = Cursors.Hand
				End If


			End If

		End Sub

		Private Sub targetPivot_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
			If onDrag Then
				If GetDragEffect(e.Location) = DragDropEffects.Move Then
					Dim hi As PivotGridHitInfo = targetPivot_Renamed.CalcHitInfo(e.Location)
                    If hi.ValueInfo.Field Is dragInfo.ValueInfo.Field Then
                        TryCast(dragInfo.ValueInfo.Field.Tag, IList).Remove(dragInfo.ValueInfo.Value)
                        TryCast(dragInfo.ValueInfo.Field.Tag, IList).Insert((TryCast(dragInfo.ValueInfo.Field.Tag, IList)).IndexOf(hi.ValueInfo.Value), dragInfo.ValueInfo.Value)
                        'updateMemos();
                    End If
					If (dragInfo.ValueInfo.Field.Area = PivotArea.RowArea AndAlso AllowChangeRowGroup) OrElse (dragInfo.ValueInfo.Field.Area = PivotArea.ColumnArea AndAlso AllowChangeColumnGroup) Then
						Dim ds As PivotDrillDownDataSource = Nothing
						Dim i As Integer = 0
						Do While i < dragInfo.ValueInfo.Field.AreaIndex AndAlso i <= hi.ValueInfo.Field.AreaIndex
							Dim targetFieldValue As Object = hi.ValueInfo.GetFieldValue(targetPivot_Renamed.GetFieldByArea(dragInfo.ValueInfo.Field.Area, i), hi.ValueInfo.MinIndex)
							Dim dragFieldValue As Object = dragInfo.ValueInfo.GetFieldValue(targetPivot_Renamed.GetFieldByArea(dragInfo.ValueInfo.Field.Area, i), dragInfo.ValueInfo.MinIndex)
							If targetFieldValue IsNot dragFieldValue Then
								If ds Is Nothing Then
									ds = dragInfo.ValueInfo.CreateDrillDownDataSource()
								End If
								For Each row As PivotDrillDownDataRow In ds
									ds.SetValue(row.Index, targetPivot_Renamed.GetFieldByArea(dragInfo.ValueInfo.Field.Area, i), targetFieldValue)
								Next row
							End If
							i += 1
						Loop
					End If
					targetPivot_Renamed.RefreshData()
				End If

				onDrag = False
				targetPivot_Renamed.FindForm().Cursor = Cursors.Default
			End If
		End Sub

		Private Function GetDragEffect(ByVal point As Point) As DragDropEffects
			Dim hi As PivotGridHitInfo = targetPivot_Renamed.CalcHitInfo(point)
			Dim dragArea As PivotArea = dragInfo.ValueInfo.Field.Area
			If hi.HitTest <> PivotGridHitTest.Value OrElse hi.ValueInfo.Field Is Nothing OrElse hi.ValueInfo.Field.Area <> dragArea Then
				TargetInfo = Nothing
				Return DragDropEffects.None
			End If
			If (dragArea = PivotArea.ColumnArea AndAlso (Not AllowDragColumn)) OrElse (dragArea = PivotArea.RowArea AndAlso (Not AllowDragRow)) Then
				TargetInfo = Nothing
				Return DragDropEffects.None
			End If
			'for the same group
			If IsSameGroup(dragInfo.ValueInfo, hi.ValueInfo) Then
                If dragInfo.ValueInfo.Field IsNot hi.ValueInfo.Field OrElse dragInfo.ValueInfo.Value.Equals(hi.ValueInfo.Value) Then
                    TargetInfo = Nothing
                    Return DragDropEffects.None
                Else
                    TargetInfo = hi
                    Return DragDropEffects.Move
                End If
			Else 'for different groups
				If (dragArea = PivotArea.RowArea AndAlso AllowChangeRowGroup) OrElse (dragArea = PivotArea.ColumnArea AndAlso AllowChangeColumnGroup) Then
					TargetInfo = hi
					Return DragDropEffects.Move
				Else
					TargetInfo = Nothing
					Return DragDropEffects.None
				End If
			End If
		End Function

		Private Function IsSameGroup(ByVal dragInfo As PivotFieldValueHitInfo, ByVal targetInfo As PivotFieldValueHitInfo) As Boolean
			If dragInfo.Field.Area <> targetInfo.Field.Area Then
				Return False
			End If
			Dim minAreaIndex As Integer = Math.Min(dragInfo.Field.AreaIndex-1, targetInfo.Field.AreaIndex)
			For i As Integer = 0 To minAreaIndex
				Dim field1GroupValue As Object = dragInfo.GetFieldValue(targetPivot_Renamed.GetFieldByArea(dragInfo.Field.Area, i), dragInfo.MinIndex)
				Dim field2GroupValue As Object = targetInfo.GetFieldValue(targetPivot_Renamed.GetFieldByArea(targetInfo.Field.Area, i), targetInfo.MinIndex)
				If (Not field1GroupValue.Equals(field2GroupValue)) Then
					Return False
				End If
			Next i
			Return True
		End Function


	End Class
End Namespace
