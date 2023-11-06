Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Dim Conn As OdbcConnection
    Dim cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String

    Sub Connection()
        MyDB = "Driver={MySQL ODBC 8.1 ANSI Driver};Database=dbnama;server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""

        Call Connection()
        Da = New OdbcDataAdapter("select * from namatabel", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "namatabel")
        DataGridView1.DataSource = Ds.Tables("namatabel")
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Connection()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MessageBox.Show("Silahkan Mengisi data Secara Lengkap")
        Else
            Dim InputData As String = " Insert into namatabel value ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "')"
            cmd = New OdbcCommand(InputData, Conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Input Data Berhasil")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call Connection()
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MessageBox.Show("Silahkan Mengisi data Secara Lengkap")
        Else
            Dim DeleteData As String = "delete from namatabel where key='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(DeleteData, Conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Hapus Data Berhasil")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MessageBox.Show("Silahkan Mengisi data Secara Lengkap")
        Else
            Call Connection()
            Dim EditData As String = "update namatabel Set nama='" & TextBox2.Text & "',jekel='" & ComboBox1.Text & "',prodi='" & ComboBox2.Text & "',alamat='" & TextBox3.Text & "',nohp='" & TextBox4.Text & "' where nim='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EditData, Conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Edit Data Berhasil")
            Call KondisiAwal()
        End If

    End Sub
End Class
