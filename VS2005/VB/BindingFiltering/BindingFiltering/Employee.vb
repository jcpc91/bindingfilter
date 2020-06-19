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

Public Class Employee

    Private lastNameValue As String
    Private firstNameValue As String
    Private salaryValue As Integer
    Private startDateValue As DateTime

    Public Sub New()
        Me.LastName = "Last Name"
        Me.FirstName = "First Name"
        Me.Salary = 40000
        Me.StartDate = DateTime.Today
    End Sub

    Public Sub New(ByVal lastName As String, ByVal firstName As String, _
    ByVal salary As Integer, ByVal startDate As DateTime)
        Me.LastName = lastName
        Me.FirstName = firstName
        Me.Salary = salary
        Me.StartDate = startDate
    End Sub

    Public Property LastName() As String
        Get
            Return lastNameValue
        End Get
        Set(ByVal value As String)
            lastNameValue = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return firstNameValue
        End Get
        Set(ByVal value As String)
            firstNameValue = value
        End Set
    End Property

    Public Property Salary() As Integer
        Get
            Return salaryValue
        End Get
        Set(ByVal value As Integer)
            salaryValue = value
        End Set
    End Property

    Public Property StartDate() As DateTime
        Get
            Return startDateValue
        End Get
        Set(ByVal value As DateTime)
            startDateValue = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return LastName + ", " + FirstName + vbCrLf + _
            "Salary:" + salaryValue.ToString() + vbCrLf + _
            "Start date:" + startDateValue.ToString()
    End Function

End Class
