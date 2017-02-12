'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016 Christopher Mackay

'    This program Is free software: you can redistribute it And/Or modify
'    it under the terms Of the GNU General Public License As published by
'    the Free Software Foundation, either version 3 Of the License, Or
'    (at your option) any later version.

'    This program Is distributed In the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty Of
'    MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE. See the
'    GNU General Public License For more details.

'    You should have received a copy Of the GNU General Public License
'    along with this program. If Not, see <http: //www.gnu.org/licenses/>.

Public Class clsTransaction

    'TYPE PROPERTY
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = Trim(value.Replace("'", "").Replace("_", "").Replace("%", ""))
        End Set
    End Property

    'CATEGORY PROPERTY
    Private _Category As String
    Public Property Category() As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            _Category = Trim(value.Replace("'", "").Replace("_", "").Replace("%", "").Replace(",", ""))
        End Set
    End Property

    'DATE PROPERTY
    Private _Date As Date
    Public Property TransDate() As Date
        Get
            Return _Date
        End Get
        Set(ByVal value As Date)
            _Date = value
        End Set
    End Property

    'PAYMENT PROPERTY
    Private _Payment As String
    Public Property Payment() As String
        Get
            Return _Payment
        End Get
        Set(ByVal value As String)
            _Payment = value
        End Set
    End Property

    'DEPOSIT PROPERTY
    Private _Deposit As String
    Public Property Deposit() As String
        Get
            Return _Deposit
        End Get
        Set(ByVal value As String)
            _Deposit = value
        End Set
    End Property

    'PAYEE PROPERTY
    Private _Payee As String
    Public Property Payee() As String
        Get
            Return _Payee
        End Get
        Set(ByVal value As String)
            _Payee = Trim(value.Replace("'", "").Replace("_", "").Replace("%", "").Replace(",", ""))
        End Set
    End Property

    'DESCRIPTION PROPERTY
    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = Trim(value.Replace("'", "").Replace("_", "").Replace("%", ""))
        End Set
    End Property

    'CLEARED PROPERTY
    Private _Cleared As Boolean
    Public Property Cleared() As Boolean
        Get
            Return _Cleared
        End Get
        Set(ByVal value As Boolean)
            _Cleared = value
        End Set
    End Property

    'RECEIPT PROPERTY
    Public _Receipt As String
    Public Property Receipt() As String
        Get
            Return _Receipt
        End Get
        Set(ByVal value As String)
            _Receipt = value
        End Set
    End Property

End Class
