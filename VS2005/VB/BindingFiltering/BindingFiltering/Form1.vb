'---------------------------------------------------------------------
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Option Explicit On
Option Strict On

Imports System.ComponentModel
Imports System.Text

Public Class Form1

    Dim businessObjects As FilteredBindingList(Of Employee)

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        businessObjects = New FilteredBindingList(Of Employee)
        businessObjects.Add(New Employee("Haas", "Jonathan", 35000, New DateTime(2005, 12, 12)))
        businessObjects.Add(New Employee("Adams", "Ellen", 55000, New DateTime(2004, 1, 11)))
        businessObjects.Add(New Employee("Hanif", "Kerim", 45000, New DateTime(2003, 12, 4)))
        businessObjects.Add(New Employee("Akers", "Kim", 35600, New DateTime(2002, 12, 12)))
        businessObjects.Add(New Employee("Harris", "Phyllis", 60000, New DateTime(2004, 10, 10)))
        businessObjects.Add(New Employee("Andersen", "Elizabeth", 65000, New DateTime(2006, 4, 4)))
        businessObjects.Add(New Employee("Alberts", "Amy", 35000, New DateTime(2007, 2, 1)))
        businessObjects.Add(New Employee("Hamlin", "Jay", 38000, New DateTime(2004, 8, 8)))
        businessObjects.Add(New Employee("Hee", "Gordon", 50000, New DateTime(2004, 10, 12)))
        businessObjects.Add(New Employee("Penor", "Lori", 40000, New DateTime(2006, 12, 20)))
        businessObjects.Add(New Employee("Pfeiffer", "Michael", 49000, New DateTime(2002, 1, 29)))
        businessObjects.Add(New Employee("Perry", "Brian", 54000, New DateTime(2005, 9, 25)))
        businessObjects.Add(New Employee("Pan", "Mingda", 56000, New DateTime(2004, 10, 17)))
        businessObjects.Add(New Employee("Philips", "Carol", 65000, New DateTime(2005, 8, 14)))
        businessObjects.Add(New Employee("Pica", "Guido", 52000, New DateTime(2006, 6, 23)))
        businessObjects.Add(New Employee("Jean", "Virginie", 38000, New DateTime(2002, 5, 2)))
        businessObjects.Add(New Employee("Reiter", "Tsvi", 39000, New DateTime(2003, 4, 12)))

        BindingSource1.DataSource = businessObjects
        DataGridView1.DataSource = BindingSource1
        Dim objectProps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(businessObjects(0))
        Dim bindingSource2 As BindingSource = New BindingSource()
        Dim prop As PropertyDescriptor
        For Each prop In objectProps
            If (prop.PropertyType.GetInterface("IComparable", True) IsNot Nothing) Then
                bindingSource2.Add(prop.Name)
            End If
        Next
        ComboBox1.DataSource = bindingSource2
        ComboBox2.Items.AddRange(New String() {"<", "=", ">"})
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            BindingSource1.Filter = GetFilterString()
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message + " Try another filter expression.")
        End Try
    End Sub

    Public Function GetFilterString() As String
        Dim query As StringBuilder = New StringBuilder()
        If (ComboBox1.SelectedItem IsNot Nothing) Then
            query.Append(ComboBox1.SelectedItem.ToString())
        Else
            query.Append(ComboBox1.Text)
        End If
        If (ComboBox2.SelectedItem IsNot Nothing) Then
            query.Append(ComboBox2.SelectedItem.ToString())
        Else
            query.Append(ComboBox2.Text)
        End If
        query.Append("'" + TextBox1.Text + "'")
        Return query.ToString()
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        BindingSource1.RemoveFilter()
    End Sub
End Class
