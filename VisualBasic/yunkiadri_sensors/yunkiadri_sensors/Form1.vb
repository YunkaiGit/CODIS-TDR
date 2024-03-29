﻿Imports System.IO.Ports
Imports System.Runtime.CompilerServices
Public Class Form1
    Public ejex, ejey, ejez, ejee, ejeb, ejes As Long
    Dim copiado As String
    Dim indata As String
    Dim seleccionado As Integer
    Dim jocEnMarxa As Boolean = True
    Dim puertoSerialSensors As New SerialPort("COM5", 9600)
    Dim Matriu(100, 6) As Integer

    Private Sub Ini_matriu()
        For i = 0 To 99
            For j = 0 To 5
                Matriu(i, j) = 0
            Next j
        Next i
    End Sub

    Private Sub Cargar_matriu()

        Matriu(0, 0) = -10
        Matriu(0, 1) = -20
        Matriu(0, 2) = 8
        Matriu(0, 3) = 0
        Matriu(0, 4) = 0
        Matriu(0, 5) = 0

        Matriu(1, 0) = -10
        Matriu(1, 1) = -20
        Matriu(1, 2) = 8
        Matriu(1, 3) = 0
        Matriu(1, 4) = 0
        Matriu(1, 5) = 0

        Matriu(2, 0) = -10
        Matriu(2, 1) = -20
        Matriu(2, 2) = 8
        Matriu(2, 3) = 0
        Matriu(2, 4) = 0
        Matriu(2, 5) = 0

        Matriu(3, 0) = -30
        Matriu(3, 1) = -20
        Matriu(3, 2) = 8
        Matriu(3, 3) = 0
        Matriu(3, 4) = 0
        Matriu(3, 5) = 0

        Matriu(4, 0) = -30
        Matriu(4, 1) = -20
        Matriu(4, 2) = 8
        Matriu(4, 3) = 0
        Matriu(4, 4) = 0
        Matriu(4, 5) = 0

        Matriu(5, 0) = -30
        Matriu(5, 1) = -20
        Matriu(5, 2) = 2
        Matriu(5, 3) = 0
        Matriu(5, 4) = 0
        Matriu(5, 5) = 0

        Matriu(6, 0) = -17
        Matriu(6, 1) = -50
        Matriu(6, 2) = 4
        Matriu(6, 3) = 0
        Matriu(6, 4) = 0
        Matriu(6, 5) = 0

        Matriu(7, 0) = -17
        Matriu(7, 1) = -50
        Matriu(7, 2) = 4
        Matriu(7, 3) = 0
        Matriu(7, 4) = 0
        Matriu(7, 5) = 0

        Matriu(8, 0) = -17
        Matriu(8, 1) = -50
        Matriu(8, 2) = 4
        Matriu(8, 3) = 0
        Matriu(8, 4) = 0
        Matriu(8, 5) = 0

        'POSICIONS IMPORTANTS
        'MATRIU INICI(RESET)-OPTIMA
        Matriu(9, 0) = -20
        Matriu(9, 1) = -32
        Matriu(9, 2) = 4
        Matriu(9, 3) = 0
        Matriu(9, 4) = 0
        Matriu(9, 5) = 0
        'AGAFAR PEÇA (DES DE POSICIÓ OPTIMA)
        Matriu(10, 0) = 20
        Matriu(10, 1) = -2
        Matriu(10, 2) = 5
        Matriu(10, 3) = 0
        Matriu(10, 4) = 0
        Matriu(10, 5) = 0
        'TORNAR A LA POSICIÓ OPTIMA DESPRÉS D'AGAFAR PEÇA
        Matriu(11, 0) = -20
        Matriu(11, 1) = 2
        Matriu(11, 2) = -5
        Matriu(11, 3) = 0
        Matriu(11, 4) = 0
        Matriu(11, 5) = 0



        'MATRIUS DE TORNAR A LA POSICIÓ OPTIMA DESPRÉS DE POSAR LA PEÇA EN EL TAULER (CASELLA TAULER (0-8) + 12)
        'MATRIU 0 - OPTIMA
        Matriu(12, 0) = 15
        Matriu(12, 1) = 20
        Matriu(12, 2) = -8
        Matriu(12, 3) = 0
        Matriu(12, 4) = 0
        Matriu(12, 5) = 0
        'MATRIU 1 - OPTIMA
        Matriu(13, 0) = 15
        Matriu(13, 1) = 20
        Matriu(13, 2) = -8
        Matriu(13, 3) = 0
        Matriu(13, 4) = 0
        Matriu(13, 5) = 0
        'MATRIU 2 - OPTIMA
        Matriu(14, 0) = 15
        Matriu(14, 1) = 20
        Matriu(14, 2) = -8
        Matriu(14, 3) = 0
        Matriu(14, 4) = 4
        Matriu(14, 5) = 0
        'MATRIU 3 - OPTIMA
        Matriu(15, 0) = 15
        Matriu(15, 1) = 20
        Matriu(15, 2) = -8
        Matriu(15, 3) = 0
        Matriu(15, 4) = 0
        Matriu(15, 5) = 0
        'MATRIU 4 - OPTIMA
        Matriu(16, 0) = 15
        Matriu(16, 1) = 20
        Matriu(16, 2) = -8
        Matriu(16, 3) = 0
        Matriu(16, 4) = 0
        Matriu(16, 5) = 0
        'MATRIU 5 - OPTIMA
        Matriu(17, 0) = 15
        Matriu(17, 1) = 20
        Matriu(17, 2) = -8
        Matriu(17, 3) = 0
        Matriu(17, 4) = 0
        Matriu(17, 5) = 0
        'MATRIU 6 - OPTIMA
        Matriu(18, 0) = 15
        Matriu(18, 1) = 20
        Matriu(18, 2) = -8
        Matriu(18, 3) = 0
        Matriu(18, 4) = 0
        Matriu(18, 5) = 0
        'MATRIU 7 - OPTIMA
        Matriu(19, 0) = 15
        Matriu(19, 1) = 20
        Matriu(19, 2) = -8
        Matriu(19, 3) = 0
        Matriu(19, 4) = 0
        Matriu(19, 5) = 0
        'MATRIU 8 - OPTIMA
        Matriu(20, 0) = 15
        Matriu(20, 1) = 20
        Matriu(20, 2) = -8
        Matriu(20, 3) = 0
        Matriu(20, 4) = 0
        Matriu(20, 5) = 0

        'BAILE
        Matriu(21, 0) = 15
        Matriu(21, 1) = 20
        Matriu(21, 2) = -8
        Matriu(21, 3) = 0
        Matriu(21, 4) = 0
        Matriu(21, 5) = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        puertoSerialSensors.Open() ' Abre la conexión al puerto serial
        TimerSensors.Enabled = True ' Habilita el temporizador para leer datos periódicamente
        TimerSensors.Interval = 1000
        If jocEnMarxa Then
            InitializeGame()
        End If
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String
        ejex = 0
        ejey = 0
        ejez = 0
        ejee = 0
        ejes = 40
        ejeb = 0

        For Each port In ports
            cmb_ports.Items.Add(port)
        Next port
    End Sub
    Private Sub bloqueoinicial()
        ejez = 0
        ejex = 0
        ejey = 0
        WriteGCode("T0")
        Espera(100)
        WriteGCode("G1 X" & 1 & " Y" & 1 & " Z" & 1)
        Espera(200)
        WriteGCode("G1 X" & 0 & " Y" & 0 & " Z" & 0)
        Espera(200)
        'WriteGCode("T1")
        'WriteGCode("G1 E" & ejee)
        'WriteGCode("M280 P1 S" & ejes)
        'WriteGCode("T0")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ejex = ejex + NumericUpDown1.Value
        WriteGCode("G1 X" & ejex)
        actualizaposiciones()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ejey = ejey + NumericUpDown1.Value
        WriteGCode("G1 Y" & ejey)
        actualizaposiciones()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ejey = ejey - NumericUpDown1.Value
        WriteGCode("G1 Y" & ejey)
        actualizaposiciones()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ejez = ejez + NumericUpDown1.Value
        WriteGCode("G1 Z" & ejez)
        actualizaposiciones()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ejez = ejez - NumericUpDown1.Value
        WriteGCode("G1 Z" & ejez)
        actualizaposiciones()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ejes = ejes + NumericUpDown1.Value
        If ejes > 180 Then ejes = 180
        WriteGCode("M280 P1 S" & ejes)
        actualizaposiciones()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ejee = ejee + NumericUpDown1.Value
        WriteGCode("T0")
        System.Threading.Thread.Sleep(100)
        WriteGCode("G1 E" & ejee)
        actualizaposiciones()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ejee = ejee - NumericUpDown1.Value
        WriteGCode("T0")
        System.Threading.Thread.Sleep(100)
        WriteGCode("G1 E" & ejee)
        actualizaposiciones()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ejeb = ejeb + NumericUpDown1.Value
        WriteGCode("T1")
        System.Threading.Thread.Sleep(100)
        WriteGCode("G1 E" & ejeb)
        actualizaposiciones()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ejeb = ejeb - NumericUpDown1.Value
        WriteGCode("T1")
        System.Threading.Thread.Sleep(100)
        WriteGCode("G1 E" & ejeb)
        actualizaposiciones()
    End Sub


    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        ejes = ejes - NumericUpDown1.Value
        If ejes < 40 Then ejes = 40
        If ejes > 180 Then ejes = 180
        WriteGCode("M280 P1 S" & ejes)
        actualizaposiciones()
    End Sub


    Private Sub WriteGCode(ByVal gcode As String)
        'SerialPort1.Open()
        If Not SerialPort1.IsOpen Then
            Try
                SerialPort1.Open()
                'FlushPort()
            Catch ex As Exception
                MessageBox.Show("Puerto serial no encontrado!")
                Exit Sub
            End Try
        End If

        'FlushPort()
        SerialPort1.WriteLine(gcode)
        'ReadPortOK() ' 
    End Sub

    Private Sub writeline(ByVal linea As String)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ListBox1.Items.Add("G1 " & "X" & ejex & " Y" & ejey & " Z" & ejez & " E" & ejee & " B" & ejeb & " S" & ejes)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If ListBox1.SelectedIndex > -1 Then ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If MsgBox("DELETE ALL?", 1, "CONFIRMATION") = 1 Then
            ListBox1.Items.Clear()
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        ListBox1.Items.AddRange(IO.File.ReadAllLines(OpenFileDialog1.FileName))
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sb As New System.Text.StringBuilder()

            For Each o As Object In ListBox1.Items
                sb.AppendLine(o)
            Next

            System.IO.File.WriteAllText(SaveFileDialog1.FileName, sb.ToString())
        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If ListBox1.SelectedIndex > -1 Then copiado = ListBox1.Items(ListBox1.SelectedIndex)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        If copiado <> "" Then ListBox1.Items.Add(copiado)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If ListBox1.SelectedIndex > -1 Then ListBox1.Items(ListBox1.SelectedIndex) = "G1 " & "X" & ejex & " Y" & ejey & " Z" & ejez & " E" & ejee & " B" & ejeb & " S" & ejes
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_conectar.Click

        If Not SerialPort1.IsOpen Then
            SerialPort1.PortName = cmb_ports.SelectedItem
            SerialPort1.BaudRate = cmb_baud.SelectedItem
            'txt_comunicacion.Text = SerialPort1.PortName
            'txt_comunicacion.Text = txt_comunicacion.Text & SerialPort1.BaudRate
            Try
                SerialPort1.Open()

                btn_conectar.Text = "Desconectar"
                bloqueoinicial()


            Catch ex As Exception
                MessageBox.Show("Puerto serial no encontrado!")
                btn_conectar.Text = "Conectar"
                Exit Sub
            End Try
        Else
            Try
                SerialPort1.Close()
                btn_conectar.Text = "Conectar"

            Catch ex As Exception
                MessageBox.Show("Imposible cerrar la conexión!")
                btn_conectar.Text = "Desconectar"
                Exit Sub
            End Try

        End If
    End Sub



    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Dim instruccion As String
        instruccion = ListBox1.SelectedItem
        moveracoordenada(instruccion)

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        executeall()

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If MsgBox("¿You want reset axis values?", vbYesNo, "Confirm") = vbYes Then

            bloqueoinicial()
            actualizaposiciones()
            actualizaposiciones()
            bloqueoinicial()

        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        'WriteGCode(txt_comand.Text)
        'txt_comunicacion.Text = txt_comunicacion.Text & vbCrLf & "MI PC - " & txt_comand.Text
        actualizaposiciones()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ListBox1.SelectedIndex = seleccionado
        moveracoordenada(ListBox1.SelectedItem)
        If seleccionado < ListBox1.Items.Count Then seleccionado = seleccionado + 1
        Timer1.Enabled = False


        Try
            Dim i As Single = SerialPort1.ReadExisting
            ' LblSensor1.Text = i.ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        indata = SerialPort1.ReadExisting()
        txt_out(indata)
    End Sub
    Private Sub txt_out(ByVal s As String)

        'txt_comunicacion.Text = s

    End Sub

    Private Sub Executa_Tasca(Num As Integer)
        Cargar_matriu()
        ' WriteGCode("G1 X" & Matriu(Num, 0) & " Y" & Matriu(Num, 1) & " Z" & Matriu(Num, 2) & " E" & Matriu(Num, 3) & " B" & Matriu(Num, 4) & " S" & Matriu(Num, 5))
        'WriteGCode("G1 Z" & Matriu(Num, 2))
        '   WriteGCode("G1 Z" & 30)
        '  actualizaposiciones()
        ejex = ejex + Matriu(Num, 0)
        ejey = ejey + Matriu(Num, 1)
        ejez = ejez + Matriu(Num, 2)


        WriteGCode("G1 X" & ejex & " Y" & ejey & " Z" & ejez)
        ' WriteGCode("G1 Z" & ejez)
        actualizaposiciones()


    End Sub
    Private Sub ButtonT1_Click(sender As Object, e As EventArgs)
        Executa_Tasca(0)
    End Sub

    Private Sub ButtonT2_Click(sender As Object, e As EventArgs) Handles ButtonT2.Click
        Obre()
    End Sub

    Private Sub cmb_ports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ports.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ejex = ejex - NumericUpDown1.Value
        WriteGCode("G1 X" & ejex)
        actualizaposiciones()
    End Sub
    Public Sub Espera(Segundos As Double)
        Dim tfinal As Date
        Dim tcomienzo As Date

        tfinal = Date.Now.AddMilliseconds(Segundos)

        Do While tfinal > tcomienzo
            Application.DoEvents()
            tcomienzo = Date.Now
        Loop
    End Sub

    Private Sub executeall()
        ListBox1.Enabled = False
        Button1.Enabled = False
        ListBox1.SelectedItem = 0
        Dim movanterior As String = ""
        Dim pasosmax, maxx, maxy, maxz, maxe, esperamov As Integer
        For i = 0 To ListBox1.Items.Count - 1
            ListBox1.SelectedIndex = i
            Dim coord As String = ListBox1.SelectedItem
            If i > 0 Then
                movanterior = ListBox1.Items(ListBox1.SelectedIndex - 1)
            Else
                movanterior = ListBox1.SelectedItem
            End If
            Dim ejescoord_a() As String = Split(coord)
            Dim prox_a, proy_a, proz_a, proe_a, prob_a, pros_a As String
            Dim ejex_a, ejey_a, ejez_a, ejee_a, ejeb_a, ejes_a As Integer
            prox_a = ejescoord_a(1)
            proy_a = ejescoord_a(2)
            proz_a = ejescoord_a(3)
            proe_a = ejescoord_a(4)
            prob_a = ejescoord_a(5)
            pros_a = ejescoord_a(6)
            ejex_a = Int(prox_a.Substring(1, prox_a.Length - 1))
            ejey_a = Int(proy_a.Substring(1, proy_a.Length - 1))
            ejez_a = Int(proz_a.Substring(1, proz_a.Length - 1))
            ejee_a = Int(proe_a.Substring(1, proe_a.Length - 1))
            ejeb_a = Int(prob_a.Substring(1, prob_a.Length - 1))
            ejes_a = Int(pros_a.Substring(1, pros_a.Length - 1))

            If ejex > ejex_a Then maxx = Math.Abs(ejex - ejex_a) Else If ejex_a > ejex Then maxx = Math.Abs(ejex_a - ejex) Else If ejex_a = ejex Then maxx = 0
            If ejey > ejey_a Then maxy = Math.Abs(ejey - ejey_a) Else If ejey_a > ejey Then maxy = Math.Abs(ejey_a - ejey) Else If ejey_a = ejey Then maxy = 0
            If ejez > ejez_a Then maxz = Math.Abs(ejez - ejez_a) Else If ejez_a > ejez Then maxz = Math.Abs(ejez_a - ejex) Else If ejez_a = ejez Then maxz = 0
            If ejee > ejee_a Then maxe = Math.Abs(ejee - ejee_a) Else If ejee_a > ejee Then maxe = Math.Abs(ejee_a - ejee) Else If ejee_a = ejee Then maxe = 0
            pasosmax = Math.Max(maxx, maxy)
            pasosmax = Math.Max(pasosmax, maxz)
            pasosmax = Math.Max(pasosmax, maxe)
            esperamov = pasosmax * 50

            Dim ejescoord() As String = Split(coord)
            Dim prox, proy, proz, proe, prob, pros As String
            prox = ejescoord(1)
            proy = ejescoord(2)
            proz = ejescoord(3)
            proe = ejescoord(4)
            prob = ejescoord(5)
            pros = ejescoord(6)
            ejex = Int(prox.Substring(1, prox.Length - 1))
            ejey = Int(proy.Substring(1, proy.Length - 1))
            ejez = Int(proz.Substring(1, proz.Length - 1))
            ejee = Int(proe.Substring(1, proe.Length - 1))
            ejeb = Int(prob.Substring(1, prob.Length - 1))
            ejes = Int(pros.Substring(1, pros.Length - 1))
            actualizaposiciones()

            WriteGCode("T0")
            'System.Threading.Thread.Sleep(100)
            Espera(10)
            WriteGCode("G1 X" & ejex & " Y" & ejey & " Z" & ejez & " E" & ejee)
            'WriteGCode("G1 X" & ejex & " Y" & ejey & " Z" & ejez)
            'System.Threading.Thread.Sleep(100)
            'WriteGCode("G1 E" & ejee)
            'System.Threading.Thread.Sleep(50)
            'WriteGCode("T1")
            'System.Threading.Thread.Sleep(100)
            'WriteGCode("G1 E" & ejeb)
            'System.Threading.Thread.Sleep(9000)
            'txt_comunicacion.Text = txt_comunicacion.Text & Str(esperamov)
            If movanterior <> coord Then Espera(esperamov + 1500)
            WriteGCode("M280 P1 S" & ejes)
            'System.Threading.Thread.Sleep(50)
            Espera(300)
            'WriteGCode("T0")
        Next
        ListBox1.Enabled = True
        Button1.Enabled = True
    End Sub

    Private Sub moveracoordenada(coord As String)
        Dim ejescoord() As String = Split(coord)
        Dim prox, proy, proz, proe, prob, pros As String
        prox = ejescoord(1)
        proy = ejescoord(2)
        proz = ejescoord(3)
        proe = ejescoord(4)
        prob = ejescoord(5)
        pros = ejescoord(6)
        ejex = Int(prox.Substring(1, prox.Length - 1))
        ejey = Int(proy.Substring(1, proy.Length - 1))
        ejez = Int(proz.Substring(1, proz.Length - 1))
        ejee = Int(proe.Substring(1, proe.Length - 1))
        ejeb = Int(prob.Substring(1, prob.Length - 1))
        ejes = Int(pros.Substring(1, pros.Length - 1))
        actualizaposiciones()
        WriteGCode("T0")
        'System.Threading.Thread.Sleep(100)
        Espera(100)
        WriteGCode("G1 X" & ejex & " Y" & ejey & " Z" & ejez & " E" & ejee)
        'WriteGCode("G1 X" & ejex & " Y" & ejey & " Z" & ejez)
        'System.Threading.Thread.Sleep(100)
        'WriteGCode("G1 E" & ejee)
        'System.Threading.Thread.Sleep(50)
        'WriteGCode("T1")
        'System.Threading.Thread.Sleep(100)
        'WriteGCode("G1 E" & ejeb)
        'System.Threading.Thread.Sleep(9000)
        Espera(4000)
        WriteGCode("M280 P1 S" & ejes)
        'System.Threading.Thread.Sleep(50)
        Espera(50)
        WriteGCode("T0")
    End Sub

    Sub actualizaposiciones()
        lbl_posx.Text = ejex
        lbl_posy.Text = ejey
        lbl_posz.Text = ejez
        lbl_posa.Text = ejee
        lbl_posb.Text = ejeb
        lbl_poss.Text = ejes

    End Sub

    '3ER

    Dim currentPlayer As Integer = 1 ' 1 for Player X, -1 for Player O
    Dim board(2, 2) As Integer ' 3x3 game board
    Dim paneljuego As New Panel() ' Panel to hold the game board buttons
    Dim panelturno As New Panel() ' Panel to hold the reset button and player turn label
    Dim playerTurnLabel As New Label() ' Label to indicate player's turn
    Dim panelsupremo As New Panel()


    Private Sub InitializeGame()
        currentPlayer = 1

        ' Clear the text and reset font color of the buttons in panel1
        For Each button As Button In paneljuego.Controls.OfType(Of Button)()
            button.Text = ""
            button.ForeColor = Color.Black ' Reset font color to default
        Next


        ' Create panel1 to hold the game board buttons
        paneljuego.Size = New Size(150, 150)
        paneljuego.Location = New Point(50, 50)
        Me.Controls.Add(paneljuego)

        ' Create buttons and add them to panel1
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                board(i, j) = 0
                Dim myTupleConverted As Tuple(Of Integer, Integer) = New Tuple(Of Integer, Integer)(i, j)
                Dim numero As Integer = Valor_unidimensional(myTupleConverted)
                Dim button As New Button()
                button.Size = New Size(50, 50)
                button.Location = New Point(j * 50, i * 50)
                button.Tag = New Point(i, j)
                button.Font = New Font(button.Font.FontFamily, 18)
                button.Name = "Casella" & numero

                paneljuego.Controls.Add(button)
            Next
        Next

        ' Create panel2 to hold reset button and player turn label
        panelturno.Size = New Size(182, 302)
        panelturno.Location = New Point(250, 0)
        Me.Controls.Add(panelturno)


        panelsupremo.Size = New Size(423, 302)
        panelsupremo.Location = New Point(0, 0)
        panelsupremo.BackColor = Color.SlateGray
        Me.Controls.Add(panelsupremo)
        panelsupremo.Controls.Add(paneljuego)
        panelsupremo.Controls.Add(panelturno)
        PanelMega.Controls.Add(panelsupremo)

        ' Create reset button and add it to panel2
        Dim resetButton As New Button()
        resetButton.Text = "Reset"
        resetButton.Size = New Size(50, 20)
        resetButton.Location = New Point(0, 100)
        AddHandler resetButton.Click, AddressOf ResetButton_Click
        panelturno.Controls.Add(resetButton)

        ' Create player turn label and add it to panel2
        playerTurnLabel.Text = "Turn: X"
        playerTurnLabel.AutoSize = True
        playerTurnLabel.Location = New Point(0, 150)
        panelturno.Controls.Add(playerTurnLabel)
    End Sub

    Private Sub TimerSensors_Tick(sender As Object, e As EventArgs) Handles TimerSensors.Tick
        Dim datos As String = puertoSerialSensors.ReadLine()


        If Len(datos) > 2 Then

            Dim desxifrat() As String = datos.Split(",")
            If currentPlayer = 1 Then

                For i = 0 To UBound(desxifrat) - 1

                    'En el codi del tres en ratlla crearem un condicional per board(i), si board(desxifrat(i)) = '0' llavors board(desxifrat(i)) = currentPlayer i torn += 1

                    Dim numero As Integer = CInt(Val(desxifrat(i)))

                    Dim conjunt As Tuple(Of Integer, Integer) = Valor_bidimensional(numero)
                    If board(conjunt.Item1, conjunt.Item2) = 0 AndAlso Not CheckForWin(1) AndAlso Not CheckForWin(-1) AndAlso Not CheckForDraw() Then
                        board(conjunt.Item1, conjunt.Item2) = currentPlayer
                        Dim nomCasella = "Casella" & numero
                        Dim myButton As Button = CType(Me.Controls.Find(nomCasella, True).FirstOrDefault(), Button)
                        myButton.Text = "X"
                        currentPlayer *= -1 ' Switch player
                        UpdatePlayerTurnLabel()

                    End If

                Next

            End If

            If CheckForWin(1) Or CheckForWin(-1) Then
                ApplyWinningColor()
                'Executa ball 
                'InitializeGame()
                'ElseIf CheckForDraw() Then
                'Executa posició inici

                'MessageBox.Show("It's a draw!")



            ElseIf currentPlayer = -1 Then
                ' Computer player's turn (AI)
                Dim bestMove As Tuple(Of Integer, Integer) = GetBestMove()
                Dim millor_jugada As Integer = Valor_unidimensional(bestMove)

                If bestMove IsNot Nothing Then
                    board(bestMove.Item1, bestMove.Item2) = -1
                    currentPlayer *= -1 ' Switch player
                    WriteGCode("T1")
                    System.Threading.Thread.Sleep(100)
                    WriteGCode("G1 E" & 9)
                    ejex = ejex - 20
                    WriteGCode("G1 X" & ejex)
                    ejey = ejey - 32
                    WriteGCode("G1 Y" & ejey)
                    ejez = ejez + 4
                    WriteGCode("G1 Z" & ejez)

                    AgafaPeça(millor_jugada)
                    Executa_Tasca(millor_jugada)

                    Espera(6000)

                    Obre()
                    Executa_Tasca(millor_jugada + 12)

                    bloqueoinicial()
                    Espera(7000)
                    Gir(millor_jugada + 10)

                    UpdatePlayerTurnLabel()
                    If CheckForWin(1) Or CheckForWin(-1) Then
                        'Executa ball
                        jocEnMarxa = False
                        ApplyWinningColor()
                        MessageBox.Show($"Player O wins!")
                        'InitializeGame()
                    ElseIf CheckForDraw() Then
                        'Execita posició inici
                        jocEnMarxa = False
                        MessageBox.Show("It's a draw!")
                        'InitializeGame()
                    End If

                End If



            End If
        End If

    End Sub

    Private Function Valor_unidimensional(Conjunt As Tuple(Of Integer, Integer))

        Dim valor As Integer

        If Conjunt.Item1 + Conjunt.Item2 = 0 Then
            valor = 0
        ElseIf Conjunt.Item1 + Conjunt.Item2 = 1 Then
            If Conjunt.Item1 = 1 Then
                valor = 3
            Else
                valor = 1
            End If
        ElseIf Conjunt.Item1 + Conjunt.Item2 = 2 Then
            If Conjunt.Item1 = 2 Then
                valor = 6
            ElseIf Conjunt.Item2 = 2 Then
                valor = 2
            Else
                valor = 4
            End If
        ElseIf Conjunt.Item1 + Conjunt.Item2 = 3 Then
            If Conjunt.Item1 = 1 Then
                valor = 5
            Else
                valor = 7
            End If
        ElseIf Conjunt.Item1 + Conjunt.Item2 = 4 Then
            valor = 8

        End If

        Return valor

    End Function

    Private Function Valor_bidimensional(valor As Integer) As Tuple(Of Integer, Integer)

        Dim Conjunt As Tuple(Of Integer, Integer)

        Select Case valor
            Case 0
                Conjunt = New Tuple(Of Integer, Integer)(0, 0)
            Case 1
                Conjunt = New Tuple(Of Integer, Integer)(0, 1)
            Case 2
                Conjunt = New Tuple(Of Integer, Integer)(0, 2)
            Case 3
                Conjunt = New Tuple(Of Integer, Integer)(1, 0)
            Case 4
                Conjunt = New Tuple(Of Integer, Integer)(1, 1)
            Case 5
                Conjunt = New Tuple(Of Integer, Integer)(1, 2)
            Case 6
                Conjunt = New Tuple(Of Integer, Integer)(2, 0)
            Case 7
                Conjunt = New Tuple(Of Integer, Integer)(2, 1)
            Case 8
                Conjunt = New Tuple(Of Integer, Integer)(2, 2)
            Case Else
                ' Manejar otros valores (si es necesario)
                Conjunt = Nothing ' O establecer un valor predeterminado, depende de tu lógica
        End Select

        Return Conjunt

    End Function

    Private Sub ResetButton_Click(sender As Object, e As EventArgs)
        ' Handle reset button click event
        InitializeGame()
    End Sub

    Private Sub ApplyWinningColor()
        ' Change the font color of the winning row, column, or diagonal
        For i As Integer = 0 To 2
            If CheckRow(i) Then
                SetButtonColor(i, 0, Color.Red)
                SetButtonColor(i, 1, Color.Red)
                SetButtonColor(i, 2, Color.Red)
            End If

            If CheckColumn(i) Then
                SetButtonColor(0, i, Color.Red)
                SetButtonColor(1, i, Color.Red)
                SetButtonColor(2, i, Color.Red)
            End If
        Next

        If CheckDiagonal(0, 0, 1, 1, 2, 2) Then
            SetButtonColor(0, 0, Color.Red)
            SetButtonColor(1, 1, Color.Red)
            SetButtonColor(2, 2, Color.Red)
        End If

        If CheckDiagonal(0, 2, 1, 1, 2, 0) Then
            SetButtonColor(0, 2, Color.Red)
            SetButtonColor(1, 1, Color.Red)
            SetButtonColor(2, 0, Color.Red)
        End If
    End Sub

    Private Function CheckRow(row As Integer) As Boolean
        Return board(row, 0) = currentPlayer AndAlso board(row, 1) = currentPlayer AndAlso board(row, 2) = currentPlayer
    End Function

    Private Function CheckColumn(col As Integer) As Boolean
        Return board(0, col) = currentPlayer AndAlso board(1, col) = currentPlayer AndAlso board(2, col) = currentPlayer
    End Function

    Private Function CheckDiagonal(row1 As Integer, col1 As Integer, row2 As Integer, col2 As Integer, row3 As Integer, col3 As Integer) As Boolean
        Return board(row1, col1) = currentPlayer AndAlso board(row2, col2) = currentPlayer AndAlso board(row3, col3) = currentPlayer
    End Function

    Private Sub SetButtonColor(row As Integer, col As Integer, color As Color)
        ' Helper method to set the font color of a button at a specific row and column
        For Each control As Control In paneljuego.Controls
            If TypeOf control Is Button Then
                Dim button As Button = DirectCast(control, Button)
                Dim indices As Point = DirectCast(button.Tag, Point)
                If indices.X = row AndAlso indices.Y = col Then
                    button.ForeColor = color
                    Exit For
                End If
            End If
        Next
    End Sub



    Private Function CheckForWin(Player As Integer) As Boolean
        ' Check for a win in the current row, column, and diagonals
        For i As Integer = 0 To 2
            If (board(i, 0) = Player AndAlso board(i, 1) = Player AndAlso board(i, 2) = Player) OrElse
               (board(0, i) = Player AndAlso board(1, i) = Player AndAlso board(2, i) = Player) Then
                Return True
            End If
        Next

        Return (board(0, 0) = Player AndAlso board(1, 1) = Player AndAlso board(2, 2) = Player) OrElse
               (board(0, 2) = Player AndAlso board(1, 1) = Player AndAlso board(2, 0) = Player)
    End Function

    Private Sub Obre()
        WriteGCode("M280 P1 S" & 10)
        actualizaposiciones()
    End Sub

    Private Sub Tanca()
        WriteGCode("M280 P1 S" & 180)
        actualizaposiciones()
    End Sub

    Private Sub GiraEsquerra(valor As Integer)
        ejeb = ejeb + valor
        WriteGCode("T1")
        System.Threading.Thread.Sleep(100)
        WriteGCode("G1 E" & ejeb)
        actualizaposiciones()
    End Sub

    Private Sub GiraDreta(valor As Integer)
        ejeb = ejeb - valor
        WriteGCode("T1")
        System.Threading.Thread.Sleep(100)
        WriteGCode("G1 E" & ejeb)
        actualizaposiciones()
    End Sub

    Private Sub Gir(jugada As Integer)
        If jugada < 10 Then
            If jugada = 0 Or jugada = 3 Or jugada = 6 Then
                WriteGCode("T1")
                System.Threading.Thread.Sleep(100)
                WriteGCode("G1 E" & 4)
                actualizaposiciones()

            ElseIf jugada = 2 Or jugada = 5 Or jugada = 8 Then
                WriteGCode("T1")
                System.Threading.Thread.Sleep(100)
                WriteGCode("G1 E" & -1)
                actualizaposiciones()
            End If
        Else
            If jugada = 10 Or jugada = 13 Or jugada = 16 Then
                WriteGCode("T1")
                System.Threading.Thread.Sleep(100)
                WriteGCode("G1 E" & 0)
                actualizaposiciones()

            ElseIf jugada = 12 Or jugada = 15 Or jugada = 18 Then
                WriteGCode("T1")
                System.Threading.Thread.Sleep(100)
                WriteGCode("G1 E" & 0)
                actualizaposiciones()
            End If
        End If
    End Sub

    Private Sub AgafaPeça(jugada As Integer)
        WriteGCode("G1 Z" & 8)
        WriteGCode("G1 X" & -12)
        Espera(5000)
        Tanca()

        Espera(3000)
        bloqueoinicial()

        Espera(2000)
        WriteGCode("T1")
        System.Threading.Thread.Sleep(100)
        WriteGCode("G1 E" & 0)
        Gir(jugada)
        WriteGCode("G1 X" & -20)
        WriteGCode("G1 Y" & -32)
        WriteGCode("G1 Z" & 4)
        actualizaposiciones()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim mensaje As String = "Contenido de la matriz:" & vbCrLf
        For i As Integer = 0 To board.GetLength(0) - 1
            For j As Integer = 0 To board.GetLength(1) - 1
                mensaje &= board(i, j).ToString() & vbTab
            Next
            mensaje &= vbCrLf
        Next
        MessageBox.Show(mensaje)
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        WriteGCode("G1 X" & -20)
        WriteGCode("G1 Y" & -32)
        WriteGCode("G1 Z" & 4)
        Executa_Tasca(6)

    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Tanca()
    End Sub

    Private Function CheckForDraw() As Boolean
        ' Check for a draw (no empty cells left)
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                If board(i, j) = 0 Then
                    Return False ' Found an empty cell, game is not a draw
                End If
            Next
        Next
        Return True ' All cells are filled, game is a draw
    End Function

    Private Function GetButton(row As Integer, col As Integer) As Button
        ' Helper method to get the button at a specific row and column
        For Each control As Control In paneljuego.Controls
            If TypeOf control Is Button Then
                Dim button As Button = DirectCast(control, Button)
                Dim indices As Point = DirectCast(button.Tag, Point)
                If indices.X = row AndAlso indices.Y = col Then
                    Return button
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Function GetBestMove() As Tuple(Of Integer, Integer)
        Dim bestScore As Integer = -1
        Dim bestMove As Tuple(Of Integer, Integer) = Nothing

        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                If board(i, j) = 0 Then
                    ' Empty cell, try the move
                    board(i, j) = -1
                    Dim score As Integer = Minimax(board, 0, False)
                    board(i, j) = 0 ' Undo the move

                    If score > bestScore Then
                        bestScore = score
                        bestMove = New Tuple(Of Integer, Integer)(i, j)
                    End If
                End If
            Next
        Next

        Return bestMove
    End Function

    Private Function Minimax(board As Integer(,), depth As Integer, isMaximizing As Boolean) As Integer
        If CheckForWin(-1) Then
            Return 1
        ElseIf CheckForWin(1) Then
            Return -1

        ElseIf CheckForDraw() Then
            Return 0
        End If

        If isMaximizing Then
            Dim bestScore As Integer = -1
            For i As Integer = 0 To 2
                For j As Integer = 0 To 2
                    If board(i, j) = 0 Then
                        ' Empty cell, try the move
                        board(i, j) = -1
                        bestScore = Math.Max(bestScore, Minimax(board, depth + 1, False))
                        board(i, j) = 0 ' Undo the move
                    End If
                Next
            Next
            Return bestScore
        Else
            Dim bestScore As Integer = 1
            For i As Integer = 0 To 2
                For j As Integer = 0 To 2
                    If board(i, j) = 0 Then
                        ' Empty cell, try the move
                        board(i, j) = 1
                        bestScore = Math.Min(bestScore, Minimax(board, depth + 1, True))
                        board(i, j) = 0 ' Undo the move
                    End If
                Next
            Next
            Return bestScore
        End If
    End Function

    Private Sub UpdatePlayerTurnLabel()
        ' Update player turn label
        playerTurnLabel.Text = $"Turn: {(If(currentPlayer = 1, "X", "O"))}"
        Espera(500)
    End Sub



End Class