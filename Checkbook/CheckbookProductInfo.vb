'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2018 Christopher Mackay

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

Module CheckbookProductInfo

    Private _Version As String = "1.6.0"
    Public ReadOnly Property Version() As String
        Get
            Return _Version
        End Get
    End Property

    Private _Changelog As String = "https://github.com/cmackay732/Checkbook/releases/tag/v1.6.0"
    Public ReadOnly Property Changelog() As String
        Get
            Return _Changelog
        End Get
    End Property

End Module
