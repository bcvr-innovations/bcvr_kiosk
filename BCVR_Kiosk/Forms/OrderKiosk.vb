Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Media

Public Class OrderKiosk
    Dim startTime As DateTime
    Dim currentTime As DateTime

    Dim totalOrders As New Button
    Dim approvedOrders As New Button
    Dim pendingOrders As New Button
    Dim transferOrders As New Button

    Dim gpfs As New Button
    Dim ddsfs As New Button
    Dim dfgs1 As New Button
    Dim dfgs2 As New Button
    Dim dfs1 As New Button
    Dim dfs2 As New Button
    Dim dwrs As New Button
    Dim ts As New Button


    Private Sub OrderKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timer_clock.Interval = 1000 ' Set the interval to 1 second
        startTime = DateTime.Now ' Record the start time
        lblTime.Text = "Date: " & Date.Now.ToString("dddd, MMMM dd, yyyy") & "    Time: " & currentTime.ToString("h\:mm\:ss")
        'lblTime.Location = New Point(lblTime.Location.X + 210, lblTime.Location.Y)


        Dim PANEL_WIDTH As Integer = Me.Width() * 0.58
        Dim PANEL_HEIGHT As Integer = Me.Height() * 0.9
        FlowLayoutPanel1.Size = New Size(PANEL_WIDTH, PANEL_HEIGHT)
        FlowLayoutPanel2.Size = New Size(Me.Width() * 0.43, PANEL_HEIGHT)
        txt_auditTrail.Size = New Size(Me.Width(), txt_auditTrail.Height)
        FlowLayoutPanel1_Create()
        FlowLayoutPanel2_Create()
        FlowLayoutPanel2.Location = New Point(FlowLayoutPanel1.Location.X + FlowLayoutPanel1.Width, FlowLayoutPanel1.Location.Y)

        Initialize_Values()
        getAuditTrail()

        ' Start the timers
        timer_clock.Start()
        marquee.Start()
        audit_timer.Start()
        refresh_timer.Start()
        stockReceive_timer.Start()

        'Start reminder timers
        reminder_PendingOrders.Start()
        reminder_transferOrders.Start()
    End Sub

    Private Sub timer_clock_Tick(sender As Object, e As EventArgs) Handles timer_clock.Tick
        currentTime = DateTime.Now ' Get the current time
        lblTime.Text = "Date: " & Date.Now.ToString("dddd, MMMM dd, yyyy") & "    Time: " & currentTime.ToString("h\:mm\:ss")

    End Sub

    Private Sub Initialize_Values()
        'MsgBox(sqlDT.Rows(0)("Order_No_Count"))

        'Total Orders
        sqlSTR = "select count(Order_No) as 'Order_No_Count' from TBL_Orders " & _
               "where Order_Date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            totalOrders.Text = 0
        Else
            totalOrders.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'Approved Orders
        sqlSTR = "select count(Order_Status) as 'Order_No_Count' from TBL_Orders" & _
                " where Order_Date = '" & Date.Now & "'" & _
                " and Order_status = 'Approved' "
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            approvedOrders.Text = 0
        Else
            approvedOrders.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'Pending Orders
        sqlSTR = "select count(COALESCE(Order_Status, 'Pending')) as 'Order_No_Count' from TBL_Orders" & _
                " where COALESCE(Order_Status, 'Pending') = 'Pending'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            pendingOrders.Text = 0
        Else
            pendingOrders.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'Transfer Orders
        sqlSTR = "select count(Order_No) as 'Order_No_Count' from TBL_Orders" & _
                " where Client_Terms like '%Transfer%'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            transferOrders.Text = 0
        Else
            transferOrders.Text = sqlDT.Rows(0)("Order_No_Count")
        End If




        '-----Types of Order-----'

        'For GPFS
        sqlSTR = "select Count(Order_No) as Order_No_Count from TBL_Orders where Order_Type like '%GPFS%'" & _
                " and order_date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            gpfs.Text = 0
        Else
            gpfs.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'For DDSFS:

        sqlSTR = "select Count(Order_No) as Order_No_Count from TBL_Orders where Order_Type like '%DDSFS%'" & _
                " and order_date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            ddsfs.Text = 0
        Else
            ddsfs.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'For DFGS1:

        sqlSTR = "select Count(Order_No) as Order_No_Count from TBL_Orders where Order_Type like '%DFGS1%'" & _
                " and order_date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            dfgs1.Text = 0
        Else
            dfgs1.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'For DFGS2:

        sqlSTR = "select Count(Order_No) as Order_No_Count from TBL_Orders where Order_Type like '%DFGS2%'" & _
                " and order_date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            dfgs2.Text = 0
        Else
            dfgs2.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'For DFS1:

        sqlSTR = "select Count(Order_No) as Order_No_Count from TBL_Orders where Order_Type like '%DFS1%'" & _
                " and order_date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            dfs1.Text = 0
        Else
            dfs1.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'For DFS2:

        sqlSTR = "select Count(Order_No) as Order_No_Count from TBL_Orders where Order_Type like '%DFS2%'" & _
                " and order_date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            dfs2.Text = 0
        Else
            dfs2.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'For DWRS:

        sqlSTR = "select Count(Order_No) as Order_No_Count from TBL_Orders where Order_Type like '%DWRS%'" & _
                " and order_date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            dwrs.Text = 0
        Else
            dwrs.Text = sqlDT.Rows(0)("Order_No_Count")
        End If

        'For TS:

        sqlSTR = "select Count(Order_No) as Order_No_Count from TBL_Orders where Order_Type like '%TS - Transfer%'" & _
                " and order_date = '" & Date.Now & "'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count = 0 Then
            ts.Text = 0
        Else
            ts.Text = sqlDT.Rows(0)("Order_No_Count")
        End If



    End Sub

    Private Sub refresh_Tick(sender As Object, e As EventArgs) Handles refresh_timer.Tick
        Initialize_Values()
    End Sub

    Private Sub FlowLayoutPanel1_Create()
        totalOrders.ForeColor = Color.White
        totalOrders.Size = New Size(FlowLayoutPanel1.Width() / 2.02, FlowLayoutPanel1.Height() / 2.02)
        totalOrders.Font = New Font("Tahoma", totalOrders.Width() - 350, FontStyle.Bold)
        totalOrders.BackgroundImage = My.Resources.ResourceManager.GetObject("totalOrders")
        totalOrders.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel1.Controls.Add(totalOrders)

        approvedOrders.ForeColor = Color.White
        approvedOrders.Size = New Size(FlowLayoutPanel1.Width() / 2.02, FlowLayoutPanel1.Height() / 2.02)
        approvedOrders.Font = New Font("Tahoma", approvedOrders.Width() - 350, FontStyle.Bold)
        approvedOrders.BackgroundImage = My.Resources.ResourceManager.GetObject("approvedOrders")
        approvedOrders.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel1.Controls.Add(approvedOrders)

        pendingOrders.ForeColor = Color.White
        pendingOrders.Size = New Size(FlowLayoutPanel1.Width() / 2.02, FlowLayoutPanel1.Height() / 2.02)
        pendingOrders.Font = New Font("Tahoma", pendingOrders.Width() - 350, FontStyle.Bold)
        pendingOrders.BackgroundImage = My.Resources.ResourceManager.GetObject("pendingOrders")
        pendingOrders.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel1.Controls.Add(pendingOrders)

        transferOrders.ForeColor = Color.White
        transferOrders.Size = New Size(FlowLayoutPanel1.Width() / 2.02, FlowLayoutPanel1.Height() / 2.02)
        transferOrders.Font = New Font("Tahoma", transferOrders.Width() - 350, FontStyle.Bold)
        transferOrders.BackgroundImage = My.Resources.ResourceManager.GetObject("transferOrders")
        transferOrders.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel1.Controls.Add(transferOrders)
    End Sub

    Private Sub FlowLayoutPanel2_Create()
        gpfs.ForeColor = Color.White
        gpfs.Size = New Size(FlowLayoutPanel2.Width() / 2.12, FlowLayoutPanel2.Height() / 4.1)
        gpfs.Font = New Font("Tahoma", gpfs.Width() - 270, FontStyle.Bold)
        gpfs.BackgroundImage = My.Resources.ResourceManager.GetObject("gpfs")
        gpfs.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel2.Controls.Add(gpfs)

        ddsfs.ForeColor = Color.White
        ddsfs.Size = New Size(FlowLayoutPanel2.Width() / 2.12, FlowLayoutPanel2.Height() / 4.1)
        ddsfs.Font = New Font("Tahoma", ddsfs.Width() - 270, FontStyle.Bold)
        ddsfs.BackgroundImage = My.Resources.ResourceManager.GetObject("ddsfs")
        ddsfs.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel2.Controls.Add(ddsfs)

        dfgs1.ForeColor = Color.White
        dfgs1.Size = New Size(FlowLayoutPanel2.Width() / 2.12, FlowLayoutPanel2.Height() / 4.1)
        dfgs1.Font = New Font("Tahoma", dfgs1.Width() - 270, FontStyle.Bold)
        dfgs1.BackgroundImage = My.Resources.ResourceManager.GetObject("dfgs1")
        dfgs1.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel2.Controls.Add(dfgs1)

        dfgs2.ForeColor = Color.White
        dfgs2.Size = New Size(FlowLayoutPanel2.Width() / 2.12, FlowLayoutPanel2.Height() / 4.1)
        dfgs2.Font = New Font("Tahoma", dfgs2.Width() - 270, FontStyle.Bold)
        dfgs2.BackgroundImage = My.Resources.ResourceManager.GetObject("dfgs2")
        dfgs2.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel2.Controls.Add(dfgs2)

        dfs1.ForeColor = Color.White
        dfs1.Size = New Size(FlowLayoutPanel2.Width() / 2.12, FlowLayoutPanel2.Height() / 4.1)
        dfs1.Font = New Font("Tahoma", dfs1.Width() - 270, FontStyle.Bold)
        dfs1.BackgroundImage = My.Resources.ResourceManager.GetObject("dfs1")
        dfs1.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel2.Controls.Add(dfs1)

        dfs2.ForeColor = Color.White
        dfs2.Size = New Size(FlowLayoutPanel2.Width() / 2.12, FlowLayoutPanel2.Height() / 4.1)
        dfs2.Font = New Font("Tahoma", dfs2.Width() - 270, FontStyle.Bold)
        dfs2.BackgroundImage = My.Resources.ResourceManager.GetObject("dfs2")
        dfs2.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel2.Controls.Add(dfs2)

        dwrs.ForeColor = Color.White
        dwrs.Size = New Size(FlowLayoutPanel2.Width() / 2.12, FlowLayoutPanel2.Height() / 4.1)
        dwrs.Font = New Font("Tahoma", dwrs.Width() - 270, FontStyle.Bold)
        dwrs.BackgroundImage = My.Resources.ResourceManager.GetObject("dwrs")
        dwrs.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel2.Controls.Add(dwrs)

        ts.ForeColor = Color.White
        ts.Size = New Size(FlowLayoutPanel2.Width() / 2.12, FlowLayoutPanel2.Height() / 4.1)
        ts.Font = New Font("Tahoma", ts.Width() - 270, FontStyle.Bold)
        ts.BackgroundImage = My.Resources.ResourceManager.GetObject("ts")
        ts.BackgroundImageLayout = ImageLayout.Stretch
        FlowLayoutPanel2.Controls.Add(ts)

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles marquee.Tick
        Dim str As String = txt_auditTrail.Text
        txt_auditTrail.Text = str.Substring(1) & str(0)
    End Sub

    Private Sub getAuditTrail()
        sqlSTR = "select top 10 CONCAT(CONVERT(VARCHAR(8), CAST(timex as time), 100), ': ', UPPER(LEFT(Username, 1)) + SUBSTRING(Username, 2, LEN(Username)), ' ', Action) as auditTrail from TBL_Audit_Trail" & _
                " inner join TBL_Users on TBL_Users.User_ID = TBL_Audit_Trail.User_ID " & _
                " where date = '" & Date.Now & "' " & _
                " order by CAST(timex as time) desc"
        ExecuteSQLQuery(sqlSTR)
        Dim temp As String = ""
        For i = 0 To sqlDT.Rows.Count - 1
            temp = temp & sqlDT.Rows(i)("auditTrail") & " | " & vbCrLf
        Next
        txt_auditTrail.Text = temp
    End Sub

    Private Sub audit_timer_Tick(sender As Object, e As EventArgs) Handles audit_timer.Tick
        getAuditTrail()
    End Sub

    Private Sub stockReceive_timer_Tick(sender As Object, e As EventArgs) Handles stockReceive_timer.Tick
        sqlSTR = "select User_ID, timex, Action from TBL_Audit_Trail where date = '" & Date.Now & "' and Action like '%Approved/Received New Stocks%'"
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count > 0 Then

            For i = 0 To sqlDT.Rows.Count - 1
                Dim timeString As String = sqlDT.Rows(i)("timex")
                Dim format As String = "h:mm:ss tt"
                Dim time As DateTime = DateTime.ParseExact(timeString, format, CultureInfo.InvariantCulture)
                Dim purchase_id = Regex.Replace(sqlDT.Rows(i)("action").ToString(), "[^\d]", "")
                If time.AddMinutes(60) > DateTime.Now Then
                    sqlSTR = "select SuppName from TBL_Purchase_Order" & _
                            " inner join TBL_Suppliers on TBL_Suppliers.Supp_ID = TBL_Purchase_Order.Supp_ID" & _
                            " where TBL_Purchase_Order.Purchase_ID =" & purchase_id
                    ExecuteSQLQuery(sqlSTR)
                    If sqlDT.Rows(i)("SuppName").Contains("BCVR") Then
                        Exit Sub
                    Else
                        FormShow(StockReceived, purchase_id)
                    End If
                Else
                End If
            Next
        End If
    End Sub

    Private Sub reminder_PendingOrders_Tick(sender As Object, e As EventArgs) Handles reminder_PendingOrders.Tick
        If pendingOrders.Text > 2 Then
            Dim player As New System.Media.SoundPlayer(My.Resources.pendingOrderSound)
            player.Play()
            FormShow(Reminder, "Pending" & vbCrLf & "Orders")
        End If

    End Sub

    Private Sub reminder_transferOrders_Tick(sender As Object, e As EventArgs) Handles reminder_transferOrders.Tick
        If transferOrders.Text > 0 Then
            Dim player As New System.Media.SoundPlayer(My.Resources.transfersOrderSound)
            player.Play()
            FormShow(Reminder, "Transfer" & vbCrLf & "Orders")

        End If
    End Sub


End Class
