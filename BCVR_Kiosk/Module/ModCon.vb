'Created on August 16, 2010
'Tan, Angelito S.

'Date update dec 12, 2010
Imports System.Data.OleDb
Module ModCon
    'Public fso As New filesystemobject
    'Public ParamDVFrom As New CrystalDecisions.Shared.ParameterDiscreteValue
    'Public ParamDVTo As New CrystalDecisions.Shared.ParameterDiscreteValue
    'Public ParamCompanyName As New CrystalDecisions.Shared.ParameterDiscreteValue
    'Public ParamCompanyLoc As New CrystalDecisions.Shared.ParameterDiscreteValue
    'Public ParamCompanyContact As New CrystalDecisions.Shared.ParameterDiscreteValue
    'Public ParamCompanyTIN As New CrystalDecisions.Shared.ParameterDiscreteValue
    'Public _USER As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public _USER As String
    'Public mReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public sqlDT As New DataTable
    Public sqlDTx As New DataTable
    Public openedFileStream As System.IO.Stream
    Public passedID
    'Public Const cnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=../database/SaleInv_DB.mdb"
    'Public Const cnString As String = "Provider=SQLNCLI10;Server=CPAT;Database=SaleInv_DB; Trusted_Connection=yes;"
    'Public Const cnString As String = "Provider=SQLNCLI10;Server=CPAT;Database=SaleInv_DB;Uid=sa; Pwd=angelito;"

    'Public Const cnstring As String = "Provider=SQLOLEDB;" & _
    '                                  "Data Source=;" & _
    '                                  "Network=CPAT;" & _
    '                                  "Initial Catalog=SaleInv_DB;" & _
    '                                  "User Id=sa;" & _
    '                                  "Password=angelito"
    '192.168.1.104;" & _'                           


    Public CnString2 As String

    'Public conn As OleDbConnection = New OleDbConnection(cnString)
    ' Public DataFileLock As New System.Threading.ReaderWriterLock

    Public sqlSTR As String
    Public Rpt_SqlStr As String
    Public pass As Boolean
    Public VAT As Double
    Public WOR As Double
    Public Retail As Double
    Public Govt As Double
    Public username As String
    Public xUser_ID As Integer
    Public xUser_Access As String
    Public Pending_ID As Integer
    Public Pending_QTY As Integer
    Public Pending_Item_ID As Integer
    Public dataBytes() As Byte
    Public xpass As Boolean
    Public howx As Integer
    Public xid(1) As Integer
    Public xlock As Boolean
    Public iMin As Integer
    Public tmpStr As String
    Public LOGID As Integer
    Public PreviousPage, NextPage As Integer
    Public i_Print As Integer
    Public CnString As String = "Provider=SQLOLEDB;Data Source=192.168.1.199; Network=192.168.1.199, 1433; Initial Catalog=SaleInv_DB; User Id =bcvr; Password='bcvr142630';"
    Public Function checkServer() As Boolean
        Try

            ReDim dataBytes(openedFileStream.Length - 1) 'Init 
            openedFileStream.Read(dataBytes, 0, openedFileStream.Length)
            openedFileStream.Close()
            tmpStr = System.Text.Encoding.Unicode.GetString(dataBytes)


            Dim sqlCon As New OleDbConnection
            sqlCon.ConnectionString = CnString
            sqlCon.Open()
            checkServer = True
            sqlCon.Close()
        Catch ex As Exception
            checkServer = False
        End Try
    End Function

    Public Function ExecuteSQLQuery(ByVal SQLQuery As String) As DataTable
        Try
            Dim sqlCon As New OleDbConnection(CnString)
            Dim sqlDA As New OleDbDataAdapter(SQLQuery, sqlCon)
            Dim sqlCB As New OleDbCommandBuilder(sqlDA)
            sqlDT.Reset() ' refresh 
            sqlDA.Fill(sqlDT)
        Catch ex As Exception
            'MsgBox("Error: " & ex.ToString)
            ' If Err.Number = 5 Then
            ' MsgBox("Invalid Database, Configure TCP/IP", MsgBoxStyle.Exclamation, "Sales and Inventory")
            ' Else
            MsgBox("Error : " & ex.Message)
            ' End If
            'MsgBox("Error No. " & Err.Number & " Invalid database or no database found !! Adjust settings first", MsgBoxStyle.Critical, "Sales And Inventory")
            'MsgBox(SQLQuery)
        End Try
        Return sqlDT
    End Function
    Public Sub FILLComboBox(ByVal sql As String, ByVal cb As ComboBox)
        Dim conn As OleDbConnection = New OleDbConnection(CnString)
        cb.Items.Clear()
        Try
            conn.Open()
            Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
            Dim rdr As OleDbDataReader = cmd.ExecuteReader
            While rdr.Read
                cb.Items.Add(rdr(0).ToString & " - " & rdr(1).ToString)
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox("Error:" & ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub FILLComboBox2(ByVal sql As String, ByVal cb As ComboBox)
        Dim conn As OleDbConnection = New OleDbConnection(CnString)
        cb.Items.Clear()
        Try
            conn.Open()
            Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
            Dim rdr As OleDbDataReader = cmd.ExecuteReader
            While rdr.Read
                cb.Items.Add(rdr(1).ToString)
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox("Error:" & ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Function DataSourceConnection_Report()
        If Split(tmpStr, ":")(4) = "1" Then
            'mReport.DataSourceConnections
            'mReport()
            'mReport.DataSourceConnections(0).SetConnection(Split(tmpStr, ":")(1), "SaleInv_DB", Split(tmpStr, ":")(2), Split(tmpStr, ":")(3))
            'mReport.DataSourceConnections(0).SetConnection(Split(tmpStr, ":")(1), "SaleInv_DB", False)
            ''MsgBox(Split(tmpStr, ":")(2) & "  " & Split(tmpStr, ":")(3))
            'mReport.DataSourceConnections(0).SetLogon(Split(tmpStr, ":")(2), Split(tmpStr, ":")(3))
        Else

            'mReport.DataSourceConnections(0).SetConnection(Split(tmpStr, ":")(1), "SaleInv_DB", True)
        End If
        'MsgBox(mReport.DataSourceConnections(0).ServerName.ToString)
        Return 0
    End Function

    Public Sub FormShow(ByVal frm As Form, ByVal formPassedID As String)
        passedID = formPassedID
        frm.ShowDialog()
    End Sub

    Public Sub FillListView(ByVal sqlData As DataTable, ByVal lvList As ListView, ByVal imageID As Integer)
        Dim i As Integer
        Dim j As Integer
        'lvList.Refresh()
        lvList.Clear()
        For i = 0 To sqlData.Columns.Count - 1
            lvList.Columns.Add(sqlData.Columns(i).ColumnName)
        Next i

        For i = 0 To sqlData.Rows.Count - 1
            lvList.Items.Add(sqlData.Rows(i).Item(0), imageID)
            For j = 1 To sqlData.Columns.Count - 1
                If Not IsDBNull(sqlData.Rows(i).Item(j)) Then
                    lvList.Items(i).SubItems.Add(sqlData.Rows(i).Item(j))
                Else
                    lvList.Items(i).SubItems.Add("")
                End If
            Next j
        Next i

        For i = 0 To sqlData.Columns.Count - 1
            'xsize = lvList.Width / sqlData.Columns.Count - 8
            'MsgBox(xsize)
            'If xsize > 1440 Then
            'lvList.Columns(i).Width = xsize
            lvList.Columns(i).Width = -2
            'Else
            '   lvList.Columns(i).Width = 2000
            'End If
            'lvList.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
        Next i
    End Sub
End Module
