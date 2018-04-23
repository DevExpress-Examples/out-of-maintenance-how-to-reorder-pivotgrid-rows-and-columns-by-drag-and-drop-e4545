using DevExpress.XtraPivotGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pivot_Reorder
{
    class ReorderHelper
    {
        PivotGridControl targetPivot;
        PivotGridControl TargetPivot { get { return targetPivot; } }
        public bool AllowChangeRowGroup { get; set; }
        public bool AllowChangeColumnGroup { get; set; }
        bool _allowDragRow;
        public bool AllowDragRow
        {
            get { return _allowDragRow; }
            set
            {
                if (_allowDragRow == value)
                    return;
                _allowDragRow = value;
                if (_allowDragRow)
                    InitRowsOrder();
            }
        }
        bool _allowDragColumn;
        public bool AllowDragColumn
        {
            get { return _allowDragColumn; }
            set
            {
                if (_allowDragColumn == value)
                    return;
                _allowDragColumn = value;
                if (_allowDragColumn)
                    InitColumnsOrder();
            }
        }


        public ReorderHelper(PivotGridControl pivot)
        {
            AllowChangeRowGroup = false;
            AllowChangeColumnGroup = false;
            AllowDragColumn = false;
            Attach(pivot);
        }
        public void Attach(PivotGridControl pivot)
        {
            if (targetPivot == pivot)
                return;
            else if (targetPivot != null)
                Detach(targetPivot);

            targetPivot = pivot;
            targetPivot.CustomFieldSort += targetPivot_CustomFieldSort;
            targetPivot.MouseMove += targetPivot_MouseMove;
            targetPivot.MouseUp += targetPivot_MouseUp;
            targetPivot.FieldAreaChanged += new PivotFieldEventHandler(targetPivot_FieldAreaChanged);
            targetPivot.CustomDrawFieldValue += targetPivot_CustomDrawFieldValue;
        }

        void targetPivot_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e)
        {
            if (onDrag)
            {
                //if (e.ValueType != PivotGridValueType.Value) return;
                //if(e.Field ==)
                if (e.Field == dragInfo.ValueInfo.Field && e.Bounds.Contains(dragInfo.HitPoint))
                {
                    e.Painter.DrawObject(e.Info);
                    e.Handled = true;
                    Rectangle rec = e.Info.CaptionRect;
                    e.Graphics.DrawRectangle(Pens.Blue, rec);
                    return;
                }
                if (TargetInfo != null && e.Field == TargetInfo.ValueInfo.Field && e.Bounds.Contains(TargetInfo.HitPoint))
                {
                    e.Painter.DrawObject(e.Info);
                    e.Handled = true;
                    Rectangle rec = e.Info.CaptionRect;
                    e.Graphics.DrawRectangle(Pens.Green, rec);
                    return;
                }
            }
            //throw new NotImplementedException();
        }

        void targetPivot_FieldAreaChanged(object sender, PivotFieldEventArgs e)
        {
            if ((e.Field.Area == PivotArea.ColumnArea && AllowDragColumn) || (e.Field.Area == PivotArea.RowArea && AllowDragRow))
                InitSingleFieldOrder(e.Field);
        }

        void InitRowsOrder()
        {
            foreach (PivotGridField field in targetPivot.GetFieldsByArea(PivotArea.RowArea))
            {
                InitSingleFieldOrder(field);
            }
        }
        void InitSingleFieldOrder(PivotGridField field)
        {
            object[] allowedValues = field.GetUniqueValues();
            //IEnumerable<object> sortedGroupValues = allowedValues.OrderBy(value => value.ToString());
            List<object> orderList = new List<object>();
            //foreach (object groupValue in sortedGroupValues)
            foreach (object groupValue in allowedValues)
            {
                orderList.Add(groupValue);
            }
            field.Tag = orderList;
            field.SortMode = PivotSortMode.Custom;
        }

        void RemoveSingleFieldOrder(PivotGridField field)
        {
            field.SortMode = PivotSortMode.Default;
        }

        void InitColumnsOrder()
        {
            foreach (PivotGridField field in targetPivot.GetFieldsByArea(PivotArea.ColumnArea))
            {
                InitSingleFieldOrder(field);
            }
        }
        public void Detach(PivotGridControl pivot)
        {
            foreach (PivotGridField field in targetPivot.Fields)
            {
                {
                    field.Tag = null;
                    field.SortMode = PivotSortMode.Default;
                }
            }

        }
        private void targetPivot_CustomFieldSort(object sender, DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs e)
        {
            if (AllowDragRow && e.Field.Area == PivotArea.RowArea)
            {
                List<object> orderlist = e.Field.Tag as List<object>;
                //Comparer comp = new Comparer;
                if (orderlist == null || orderlist.IndexOf(e.Value1) == -1 || orderlist.IndexOf(e.Value2) == -1)
                {
                    //e.Result = Comparer.DefaultInvariant.Compare(e.Value1, e.Value2);
                    //e.Handled = true;
                    return;
                }
                e.Result = Comparer.DefaultInvariant.Compare(orderlist.IndexOf(e.Value1), orderlist.IndexOf(e.Value2));
                e.Handled = true;
            }
            if (AllowDragColumn && e.Field.Area == PivotArea.ColumnArea)
            {
                List<object> orderlist = e.Field.Tag as List<object>;
                if (orderlist == null || orderlist.IndexOf(e.Value1) == -1 || orderlist.IndexOf(e.Value2) == -1)
                {
                    return;
                }
                e.Result = Comparer.DefaultInvariant.Compare(orderlist.IndexOf(e.Value1), orderlist.IndexOf(e.Value2));
                e.Handled = true;
            }
        }
        PivotGridHitInfo dragInfo;
        PivotGridHitInfo _targetInfo;
        PivotGridHitInfo TargetInfo
        {
            get { return _targetInfo; }
            set
            {
                _targetInfo = value;
            }
        }
        bool onDrag = false;
        private void targetPivot_MouseMove(object sender, MouseEventArgs e)
        {
            if (!onDrag)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    PivotGridHitInfo hi = targetPivot.CalcHitInfo(e.Location);
                    if (hi.HitTest == PivotGridHitTest.Value)
                    {
                        if ((AllowDragRow && hi.ValueInfo.Field.Area == PivotArea.RowArea) || (AllowDragColumn && hi.ValueInfo.Field.Area == PivotArea.ColumnArea))
                        {
                            dragInfo = hi;
                            onDrag = true;
                            targetPivot.FindForm().Cursor = Cursors.Hand;
                        }
                    }
                }
            }
            else
            {
                DragDropEffects allowedEffect = GetDragEffect(e.Location);
                if (allowedEffect == DragDropEffects.None)
                    targetPivot.FindForm().Cursor = Cursors.No;
                else
                    targetPivot.FindForm().Cursor = Cursors.Hand;


            }

        }

        private void targetPivot_MouseUp(object sender, MouseEventArgs e)
        {
            if (onDrag)
            {
                if (GetDragEffect(e.Location) == DragDropEffects.Move)
                {
                    PivotGridHitInfo hi = targetPivot.CalcHitInfo(e.Location);
                    if (hi.ValueInfo.Field == dragInfo.ValueInfo.Field)
                    {
                        (dragInfo.ValueInfo.Field.Tag as IList).Remove(dragInfo.ValueInfo.Value);
                        (dragInfo.ValueInfo.Field.Tag as IList).Insert((dragInfo.ValueInfo.Field.Tag as IList).IndexOf(hi.ValueInfo.Value), dragInfo.ValueInfo.Value);
                        //updateMemos();
                    }
                    if ((dragInfo.ValueInfo.Field.Area == PivotArea.RowArea && AllowChangeRowGroup) || (dragInfo.ValueInfo.Field.Area == PivotArea.ColumnArea && AllowChangeColumnGroup))
                    {
                        PivotDrillDownDataSource ds = null;
                        for (int i = 0; i < dragInfo.ValueInfo.Field.AreaIndex && i <= hi.ValueInfo.Field.AreaIndex; i++)
                        {
                            object targetFieldValue = hi.ValueInfo.GetFieldValue(targetPivot.GetFieldByArea(dragInfo.ValueInfo.Field.Area, i), hi.ValueInfo.MinIndex);
                            object dragFieldValue = dragInfo.ValueInfo.GetFieldValue(targetPivot.GetFieldByArea(dragInfo.ValueInfo.Field.Area, i), dragInfo.ValueInfo.MinIndex);
                            if (targetFieldValue != dragFieldValue)
                            {
                                if (ds == null)
                                    ds = dragInfo.ValueInfo.CreateDrillDownDataSource();
                                foreach (PivotDrillDownDataRow row in ds)
                                {
                                    ds.SetValue(row.Index, targetPivot.GetFieldByArea(dragInfo.ValueInfo.Field.Area, i), targetFieldValue);
                                }
                            }
                        }
                    }
                    targetPivot.RefreshData();
                }

                onDrag = false;
                targetPivot.FindForm().Cursor = Cursors.Default;
            }
        }

        DragDropEffects GetDragEffect(Point point)
        {
            PivotGridHitInfo hi = targetPivot.CalcHitInfo(point);
            PivotArea dragArea = dragInfo.ValueInfo.Field.Area;
            if (hi.HitTest != PivotGridHitTest.Value || hi.ValueInfo.Field == null || hi.ValueInfo.Field.Area != dragArea)
            {
                TargetInfo = null;
                return DragDropEffects.None;
            }
            if ((dragArea == PivotArea.ColumnArea && !AllowDragColumn) || (dragArea == PivotArea.RowArea && !AllowDragRow))
            {
                TargetInfo = null;
                return DragDropEffects.None;
            }
            //for the same group
            if (IsSameGroup(dragInfo.ValueInfo, hi.ValueInfo))
            {
                if (dragInfo.ValueInfo.Field != hi.ValueInfo.Field || dragInfo.ValueInfo.Value.Equals(hi.ValueInfo.Value))
                {
                    TargetInfo = null;
                    return DragDropEffects.None;
                }
                else
                {
                    TargetInfo = hi;
                    return DragDropEffects.Move;
                }
            }
            else //for different groups
            {
                if ((dragArea == PivotArea.RowArea && AllowChangeRowGroup) || (dragArea == PivotArea.ColumnArea && AllowChangeColumnGroup))
                {
                    TargetInfo = hi;
                    return DragDropEffects.Move;
                }
                else
                {
                    TargetInfo = null;
                    return DragDropEffects.None;
                }
            }
        }

        bool IsSameGroup(PivotFieldValueHitInfo dragInfo, PivotFieldValueHitInfo targetInfo)
        {
            if (dragInfo.Field.Area != targetInfo.Field.Area)
                return false;
            int minAreaIndex = Math.Min(dragInfo.Field.AreaIndex-1, targetInfo.Field.AreaIndex);
            for (int i = 0; i <= minAreaIndex; i++)
            {
                object field1GroupValue = dragInfo.GetFieldValue(targetPivot.GetFieldByArea(dragInfo.Field.Area, i), dragInfo.MinIndex);
                object field2GroupValue = targetInfo.GetFieldValue(targetPivot.GetFieldByArea(targetInfo.Field.Area, i), targetInfo.MinIndex);
                if (!field1GroupValue.Equals(field2GroupValue))
                {
                    return false;
                }
            }
            return true;
        }


    }
}
