Public Class StockReceived

    Private Sub StockReceived_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim player As New System.Media.SoundPlayer(My.Resources.receivedStocksSound)
        player.Play()

        sqlSTR = "select SuppName from TBL_Purchase_Order" & _
                            " inner join TBL_Suppliers on TBL_Suppliers.Supp_ID = TBL_Purchase_Order.Supp_ID" & _
                            " where TBL_Purchase_Order.Purchase_ID =" & passedID
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count > 0 Then
            Label1.Text = "Received Stocks from:" & vbCrLf & sqlDT.Rows(0)("SuppName")

            sqlSTR = "select CONCAT(Item_Name,' ',Catg_Name) as 'Received Stocks' from TBL_Purchase_Detail" & _
    " inner join TBL_Category_Item_File on TBL_Category_Item_File.Item_ID = TBL_Purchase_Detail.Item_ID" & _
    " inner join TBL_Purchase_Order on TBL_Purchase_Order.Purchase_ID = TBL_Purchase_Detail.Purchase_ID" & _
    " inner join TBL_Suppliers on TBL_Suppliers.Supp_ID = TBL_Purchase_Order.Supp_ID" & _
    " inner join TBL_Category_File on TBL_Category_File.Catg_ID = TBL_Category_Item_File.Catg_ID" & _
    "        where TBL_Purchase_Order.Purchase_ID = " & passedID & _
    " and SuppName not like '%BCVR%'" & _
    " GROUP BY CONCAT(Item_Name,' ',Catg_Name)" & _
    "order by CONCAT(Item_Name,' ',Catg_Name)"
            FillListView(ExecuteSQLQuery(sqlSTR), lstitems, 0)
            Timer2.Start()




        End If

        
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If lstitems.Items.Count > 0 Then
            lstitems.Items(0).Remove()
        Else
            Timer1.Stop()
            Timer2.Stop()
            Me.Close()
        End If



    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer1.Start()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class