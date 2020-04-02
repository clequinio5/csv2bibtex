Imports System.IO

Public Class Main
    Dim CSV_PATH As String
    Dim LINES As New List(Of String)
    Dim BIB_FIELDS As New Dictionary(Of String, String)

    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        BIB_FIELDS.Add("---MANDATORY---", "#")
        BIB_FIELDS.Add("type", "article" & vbCrLf & "inproceedings" & vbCrLf & "conference" & vbCrLf & "poster" & vbCrLf & "presconf" & vbCrLf & "inbook" & vbCrLf & "book" & vbCrLf & "proceedings" & vbCrLf & "techreport" & vbCrLf & "manual" & vbCrLf & "patent" & vbCrLf & "phdthesis")
        BIB_FIELDS.Add("id", "*")
        BIB_FIELDS.Add("---STANDARD BIBTEX---", "#")
        BIB_FIELDS.Add("address", "")
        BIB_FIELDS.Add("abstract", "")
        BIB_FIELDS.Add("annote", "")
        BIB_FIELDS.Add("annotation", "")
        BIB_FIELDS.Add("author", "")
        BIB_FIELDS.Add("booktitle", "")
        BIB_FIELDS.Add("chapter", "")
        BIB_FIELDS.Add("crossref", "")
        BIB_FIELDS.Add("copyright", "")
        BIB_FIELDS.Add("doi", "")
        BIB_FIELDS.Add("edition", "")
        BIB_FIELDS.Add("editor", "")
        BIB_FIELDS.Add("eprint", "")
        BIB_FIELDS.Add("file", "")
        BIB_FIELDS.Add("howpublished", "")
        BIB_FIELDS.Add("institution", "")
        BIB_FIELDS.Add("issn", "")
        BIB_FIELDS.Add("issue", "")
        BIB_FIELDS.Add("journal", "")
        BIB_FIELDS.Add("journaltitle", "")
        BIB_FIELDS.Add("key", "")
        BIB_FIELDS.Add("keywords", "")
        BIB_FIELDS.Add("month", "")
        BIB_FIELDS.Add("note", "")
        BIB_FIELDS.Add("number", "")
        BIB_FIELDS.Add("organization", "")
        BIB_FIELDS.Add("pages", "")
        BIB_FIELDS.Add("pdf", "")
        BIB_FIELDS.Add("school", "")
        BIB_FIELDS.Add("series", "")
        BIB_FIELDS.Add("shorttitle", "")
        BIB_FIELDS.Add("title", "")
        BIB_FIELDS.Add("volume", "")
        BIB_FIELDS.Add("year", "")
        BIB_FIELDS.Add("---HAL SPECIFIC---", "#")
        BIB_FIELDS.Add("x-abstract_en", "")
        BIB_FIELDS.Add("x-abstract_fr", "")
        BIB_FIELDS.Add("x-anrproject_id", "")
        BIB_FIELDS.Add("x-audience", "")
        BIB_FIELDS.Add("x-city", "")
        BIB_FIELDS.Add("x-classification", "")
        BIB_FIELDS.Add("x-collaboration", "")
        BIB_FIELDS.Add("x-committee", "")
        BIB_FIELDS.Add("x-conferenceenddate", "")
        BIB_FIELDS.Add("x-conferenceorganizer", "")
        BIB_FIELDS.Add("x-conferencestartdate", "")
        BIB_FIELDS.Add("x-country", "")
        BIB_FIELDS.Add("x-director", "")
        BIB_FIELDS.Add("x-domain", "")
        BIB_FIELDS.Add("x-europeanproject_id", "")
        BIB_FIELDS.Add("x-filesource", "")
        BIB_FIELDS.Add("x-funding", "")
        BIB_FIELDS.Add("x-inria_degreetype", "")
        BIB_FIELDS.Add("x-inria_directoremail", "")
        BIB_FIELDS.Add("x-inria_presconftype", "")
        BIB_FIELDS.Add("x-invitedcommunication", "")
        BIB_FIELDS.Add("x-hal_journal_id", "")
        BIB_FIELDS.Add("x-keywords_en", "")
        BIB_FIELDS.Add("x-keywords_fr", "")
        BIB_FIELDS.Add("x-language", "")
        BIB_FIELDS.Add("x-licence", "")
        BIB_FIELDS.Add("x-localreference", "")
        BIB_FIELDS.Add("x-mesh", "")
        BIB_FIELDS.Add("x-onbehalof", "")
        BIB_FIELDS.Add("x-othertype", "")
        BIB_FIELDS.Add("x-peerreviewing", "")
        BIB_FIELDS.Add("x-popularlevel", "")
        BIB_FIELDS.Add("x-proceedings", "")
        BIB_FIELDS.Add("x-publicationlocation", "")
        BIB_FIELDS.Add("x-publisherlink", "")
        BIB_FIELDS.Add("x-reporttype", "")
        BIB_FIELDS.Add("x-serieseditor", "")
        BIB_FIELDS.Add("x-source", "")
        BIB_FIELDS.Add("x-subtitle", "")
        BIB_FIELDS.Add("x-title_en", "")
        BIB_FIELDS.Add("x-title_fr", "")
        BIB_FIELDS.Add("x-writingdate", "")


    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        OpenFileDialog1.Filter = "Fichiers csv (*.csv)|*.csv|Tous les fichiers|*.*"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            CSV_PATH = OpenFileDialog1.FileName
            LabelImport.Text = Path.GetFileName(CSV_PATH)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        FlowLayoutPanel1.Controls.Clear()

        Dim reader = File.OpenText(CSV_PATH)
        Dim line As String = Nothing
        While (reader.Peek() <> -1)
            line = reader.ReadLine()
            lines.Add(line)
        End While
        Dim fields() As String
        If CheckBox1.Checked Then
            fields = lines.Item(1).Split(TextBox1.Text)
        Else
            fields = lines.Item(0).Split(TextBox1.Text)
        End If
        For Each field As String In fields

            System.Console.WriteLine(field)

            Dim lbl As New Label
            lbl.Text = " = "
            lbl.AutoSize = True
            lbl.TextAlign = ContentAlignment.MiddleLeft

            Dim newLabel As New Label
            newLabel.Text = field
            newLabel.AutoSize = False
            newLabel.Size = New Size(100, 18)
            newLabel.TextAlign = ContentAlignment.MiddleLeft
            newLabel.AutoEllipsis = True

            Dim newComboBox As New ComboBox
            newComboBox.DrawMode = DrawMode.OwnerDrawFixed
            AddHandler newComboBox.DropDownClosed, New EventHandler(AddressOf Me.DropDownClosed)
            AddHandler newComboBox.MouseLeave, New EventHandler(AddressOf Me.DropDownLeave)
            AddHandler newComboBox.DrawItem, New DrawItemEventHandler(AddressOf Me.DrawItem)
            AddHandler newComboBox.Leave, New EventHandler(AddressOf Me.DropDownFocusLeave)

            For Each key As String In BIB_FIELDS.Keys
                newComboBox.Items.Add(key)
            Next

            Dim newPanel As New FlowLayoutPanel
            newPanel.AutoSize = True
            newPanel.Controls.Add(newComboBox)
            newPanel.Controls.Add(lbl)
            newPanel.Controls.Add(newLabel)

            FlowLayoutPanel1.Controls.Add(newPanel)

        Next


    End Sub

    Private Sub DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        Dim text As String = sender.GetItemText(sender.Items(e.Index))
        e.DrawBackground()

        Using br As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(text, e.Font, br, e.Bounds)
        End Using

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            Me.ToolTip1.Show(BIB_FIELDS.Item(text), sender, e.Bounds.Right, e.Bounds.Bottom)
        Else
            Me.toolTip1.Hide(sender)
        End If

        e.DrawFocusRectangle()
    End Sub
    Private Sub DropDownClosed(ByVal sender As Object, ByVal e As EventArgs)
        ToolTip1.Hide(sender)
    End Sub

    Private Sub DropDownLeave(ByVal sender As Object, ByVal e As EventArgs)
        ToolTip1.Hide(sender)
    End Sub

    Private Sub DropDownFocusLeave(ByVal sender As Object, ByVal e As EventArgs)
        Dim fields As New List(Of String)
        For i As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
            Dim flcontrol As Control = FlowLayoutPanel1.Controls(i)
            Dim panl As FlowLayoutPanel = flcontrol
            For Each ctr As Control In panl.Controls
                If TypeOf ctr Is ComboBox Then
                    Dim combo As ComboBox = ctr
                    fields.Add(combo.Text)
                End If
            Next
        Next
        RichTextBox1.Lines = fields.ToArray()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim fields As New Dictionary(Of String, Integer)

        For i As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
            Dim flcontrol As Control = FlowLayoutPanel1.Controls(i)
            Dim panl As FlowLayoutPanel = flcontrol
            For Each ctr As Control In panl.Controls
                If TypeOf ctr Is ComboBox Then
                    Dim combo As ComboBox = ctr
                    System.Console.WriteLine(combo.Text)
                    If combo.Text <> "" Then
                        fields.Add(combo.Text, i)
                    End If
                End If
            Next
        Next

        If fields.ContainsKey("id") And fields.ContainsKey("type") Then
            Dim bibs As New List(Of String)
            Dim start As Integer = 0
            If CheckBox1.Checked Then
                start = 1
            End If
            For i As Integer = start To LINES.Count - 1
                Try
                    Dim line As String = LINES(i)
                    Dim spl() As String = line.Split(TextBox1.Text)
                    Dim bib As String = "@" & spl(fields("type")) & "{" & spl(fields("id")) & "," & vbCrLf

                    Dim tab As New List(Of String)
                    For Each field As String In fields.Keys
                        If field <> "type" And field <> "id" Then
                            tab.Add(field & " = {" & spl(fields(field)) & "}")
                        End If
                    Next
                    bib = bib & String.Join("," & vbCrLf, tab.ToArray())
                    bib = bib & vbCrLf & "}"
                    bibs.Add(bib)
                Catch ex As Exception
                    System.Console.WriteLine("Error on csv line " & i)
                End Try
            Next

            SaveFileDialog1.Filter = "Bib Files (*.bib*)|*.bib"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, String.Join(vbCrLf & vbCrLf, bibs.ToArray()), True)
                MsgBox(bibs.Count & " csv lines successfully converted on " & LINES.Count & " initial csv lines.")
            End If

        Else
            MsgBox("You must at least map 'type' and 'id'")
        End If


    End Sub

    Private Sub RichTextBox1_Leave(sender As System.Object, e As System.EventArgs) Handles RichTextBox1.Leave
        Dim fields As String() = RichTextBox1.Lines
        For i As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
            If i > fields.Length - 1 Then
                Exit Sub
            End If
            Dim flcontrol As FlowLayoutPanel = FlowLayoutPanel1.Controls(i)
            For Each ctr As Control In flcontrol.Controls
                If TypeOf ctr Is ComboBox Then
                    Dim combo As ComboBox = ctr
                    combo.Text = fields(i)
                End If
            Next
        Next
    End Sub
End Class
