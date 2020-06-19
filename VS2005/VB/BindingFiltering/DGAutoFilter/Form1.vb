'---------------------------------------------------------------------
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports DataGridViewAutoFilter
Imports BindingFiltering

Public Class Form1

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim employees As FilteredBindingList(Of Employee) = New FilteredBindingList(Of Employee)
        employees.Add(New Employee("Aaberg", "Jesper", 52000, New DateTime(2004, 1, 14)))
        employees.Add(New Employee("Haas", "Jonathan", 75000, New DateTime(2003, 2, 14)))
        employees.Add(New Employee("Adams", "Ellen", 52000, New DateTime(2006, 10, 16)))
        employees.Add(New Employee("Hanif", "Kerim", 60000, New DateTime(2005, 10, 4)))
        employees.Add(New Employee("Akers", "Kim", 55000, New DateTime(2004, 1, 14)))
        employees.Add(New Employee("Harris", "Phyllis", 66000, New DateTime(2007, 3, 10)))
        employees.Add(New Employee("Andersen", "Elizabeth", 55000, New DateTime(2003, 7, 10)))
        employees.Add(New Employee("Alberts", "Amy", 40000, New DateTime(2005, 7, 7)))
        employees.Add(New Employee("Hamlin", "Jay", 45000, New DateTime(2005, 8, 8)))
        employees.Add(New Employee("Hee", "Gordon", 35000, New DateTime(2004, 9, 9)))
        employees.Add(New Employee("Penor", "Lori", 52000, New DateTime(2004, 11, 11)))
        employees.Add(New Employee("Pfeiffer", "Michael", 51000, New DateTime(2006, 12, 12)))
        BindingSource1.DataSource = employees
        DataGridView1.DataSource = BindingSource1

        showAllLabel.Text = "Show &All"
        showAllLabel.Visible = False
        showAllLabel.IsLink = True
        showAllLabel.LinkBehavior = LinkBehavior.HoverUnderline
    End Sub

    Private Sub DataGridView1_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        Dim filterStatus As String = DataGridViewAutoFilterColumnHeaderCell _
            .GetFilterStatus(DataGridView1)
        If (String.IsNullOrEmpty(filterStatus)) Then
            showAllLabel.Visible = False
            filterStatusLabel.Visible = False
        Else
            showAllLabel.Visible = True
            filterStatusLabel.Visible = True
            filterStatusLabel.Text = filterStatus
        End If
    End Sub

    Private Sub showAllLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showAllLabel.Click
        DataGridViewAutoFilterTextBoxColumn.RemoveFilter(DataGridView1)
    End Sub

    Private Sub DataGridView1_BindingContextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.BindingContextChanged
        ' Continue only if the data source has been set.
        If (DataGridView1.DataSource Is Nothing) Then
            Return
        End If

        ' Add the AutoFilter header cell to each column.
        Dim col As DataGridViewColumn
        For Each col In DataGridView1.Columns
            col.HeaderCell = New _
                DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
        Next

        ' Resize the columns to fit their contents.
        DataGridView1.AutoResizeColumns()
    End Sub

End Class
