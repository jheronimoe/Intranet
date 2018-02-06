Imports System.Data.OleDb

Public Class Form1

    Dim con As New OleDbConnection


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        'ADD BUTTON

        Form2.Show()
        ClientInfoBindingSource.AddNew()
    End Sub

    Private Sub ClientInfoBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ClientInfoBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClientInfoDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ClientInfoDataSet.ClientInfo' table. You can move, or remove it, as needed.
        Me.ClientInfoTableAdapter.Fill(Me.ClientInfoDataSet.ClientInfo)

        'CODE: CONNECTION STRING TO ACCESS THE DATABASE FROM MS ACCESS TO VB.NET
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;
                                    Data Source=C:\Users\Patrick\Desktop\New folder\ClientInfo.accdb"


    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'SAVE
        Me.Validate()
        Me.ClientInfoBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClientInfoDataSet)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles ExitButton.Click
        Application.Exit()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        'DELETE BUTTON

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles EditButton.Click
        'EDIT BUTTON
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        'SEACRCH BUTTON

    End Sub

    Private Sub ClientInfoBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles ClientInfoBindingSource.CurrentChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'DATAGRID
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'SEARCH TXTBOX
        Dim dt As New DataTable
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        Dim da As New OleDbDataAdapter

        'da = New OleDbDataAdapter("Select * from ClientInfo where ID like '%" & TextBox1.Text & "%'", con)
        ' da = New OleDbDataAdapter("Select * from ClientInfo where ID like '%" & TextBox1.Text & "%' or Select * from ClientInfo where Last Name" , con)
        da = New OleDbDataAdapter("Select * from ClientInfo where ID like '%" & TextBox1.Text & "%' or
                                                         [Last Name] like '%" & TextBox1.Text & "%' or
                                                         [First Name] Like '%" & TextBox1.Text & "%'", con)

        da.Fill(dt)

        DataGridView1.DataSource = dt.DefaultView

        con.Close()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)
        'GROUPBOX "CLIENT INFO"
    End Sub


End Class
