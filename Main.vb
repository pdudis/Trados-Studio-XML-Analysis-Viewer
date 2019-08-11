Imports System.IO
Imports System.Xml
Imports System.IO.Compression
Imports System.IO.Compression.FileSystem

Public Class Main

    Dim matchPerfect(2) As Integer
    Dim matchInContext(2) As Integer
    Dim matchExact(2) As Integer
    Dim matchCrossFileReps(2) As Integer
    Dim matchRepeated(2) As Integer
    Dim matchTotal(2) As Integer
    Dim matchNew(2) As Integer
    Dim matchFuzzy50(2) As Integer
    Dim matchFuzzy75(2) As Integer
    Dim matchFuzzy85(2) As Integer
    Dim matchFuzzy95(2) As Integer

    Dim myStream As Stream = Nothing
    Dim xmlReportFile As Stream = Nothing
    Dim xmlDoc As XmlDocument = New XmlDocument()
    Dim file As System.IO.StreamWriter
    Dim targetLang As String
    Dim elemList As XmlNodeList
    Dim saveFileDialog1 As New SaveFileDialog()
    Dim saveFileName As String
    Dim fNameOnly As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenXMLButton.Click

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Trados Studio XML Analysis File (*.xml) | *.xml"
        openFileDialog1.Title = "Open Trados Studio XML Analysis File"
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then

                    Label7.Text = "Totals"
                    fNameOnly = Path.GetFileName(openFileDialog1.FileName)
                    Label9.Text = fNameOnly
                    initMyApp(myStream)

                End If
            Catch Ex As Exception
                MessageBox.Show("Oops! This is embarassing…" & vbNewLine &
                                "Something went wrong while trying to get the XML file." & vbNewLine &
                                "This could be a random glitch, so try again. If this error" & vbNewLine &
                                "persists then something's wrong with the XML file.", "Guru Meditation",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error)
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles OpenSDLPPXButton.Click

        Dim openFileDialog2 As New OpenFileDialog()
        openFileDialog2.Filter = "Trados Studio Project Package File (*.sdlppx) | *.sdlppx"
        openFileDialog2.Title = "Open Trados Studio Project Package File"
        openFileDialog2.RestoreDirectory = True

        If openFileDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog2.OpenFile()
                Dim zipFileName As String = openFileDialog2.FileName
                If (myStream IsNot Nothing) Then
                    Using archive As ZipArchive = ZipFile.OpenRead(zipFileName)
                        For Each entry As ZipArchiveEntry In archive.Entries

                            If entry.FullName.Contains("Reports") Then
                                If entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) Then
                                    Dim zipXMLStream = entry.Open()
                                    Dim zipXMLStreamReader = New StreamReader(zipXMLStream)

                                    Label7.Text = "Totals"
                                    fNameOnly = Path.GetFileName(openFileDialog2.FileName)
                                    Label9.Text = fNameOnly
                                    initMyApp(zipXMLStreamReader.BaseStream)

                                End If
                            End If

                        Next

                    End Using

                End If
            Catch Ex As Exception
                MessageBox.Show("Oops! This is embarassing…" & vbNewLine &
                                "Something went wrong while trying to get the XML file" & vbNewLine &
                                "from the SDLPPX. Can you please rename the .sdlppx to .zip," & vbNewLine &
                                "extract it, and use the ‘Open XML File’ button to access the" & vbNewLine &
                                "XML file in the 'Reports' folder?", "Guru Meditation",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error)
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Function initMyApp(obtainedXMLFile As Stream)

        xmlDoc.Load(obtainedXMLFile)

        Me.MatrixView.Items.Clear()
        Me.FileListBox.Items.Clear()

        Dim targetLangNode = xmlDoc.DocumentElement.SelectSingleNode("//language")
        targetLang = targetLangNode.Attributes.ItemOf("name").InnerText
        Label2.Text = targetLang

        Dim root As XmlElement = xmlDoc.DocumentElement
        elemList = root.GetElementsByTagName("file")
        Label4.Text = elemList.Count

        'Add as first entry in the ListBox a string to represent the batchTotal stats
        FileListBox.Items.Add("*** Click this entry for Totals ***")

        'Iterate to get file names
        For Each fileNode As XmlNode In xmlDoc.DocumentElement.SelectNodes("//file")
            FileListBox.Items.Add(fileNode.Attributes.ItemOf("name").InnerText)
        Next

        prepareListView("batchTotal", "")

    End Function

    'nodeTypes:
    '- file -> /task/file/analyse/*
    '- batchTotal -> /task/batchTotal/analyse/*
    ' fileName: 
    '- empty ("") for batchTotal
    '- "<filename>" for file
    Function prepareListView(nodeType As String, fileName As String)
        Dim nodePath As String
        If nodeType = "batchTotal" Then
            nodePath = "/task/batchTotal/analyse/*"
            getAndPopulateListView(nodePath)
        ElseIf nodeType = "file" Then
            nodePath = "/task/file[@name=""" & fileName & """]/analyse/*"
            getAndPopulateListView(nodePath)
        End If
    End Function

    Function getAndPopulateListView(finalNodePath As String)

        For Each matchCatElem As XmlNode In xmlDoc.DocumentElement.SelectNodes(finalNodePath)

            If matchCatElem.Name = "perfect" Then
                matchPerfect(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchPerfect(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchPerfect(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "inContextExact" Then
                matchInContext(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchInContext(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchInContext(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "exact" Then
                matchExact(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchExact(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchExact(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "crossFileRepeated" Then
                matchCrossFileReps(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchCrossFileReps(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchCrossFileReps(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "repeated" Then
                matchRepeated(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchRepeated(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchRepeated(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "total" Then
                matchTotal(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchTotal(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchTotal(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "new" Then
                matchNew(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchNew(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchNew(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "fuzzy" Then
                If matchCatElem.Attributes.ItemOf("min").InnerText = "50" Then
                    matchFuzzy50(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                    matchFuzzy50(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                    matchFuzzy50(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
                ElseIf matchCatElem.Attributes.ItemOf("min").InnerText = "75" Then
                    matchFuzzy75(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                    matchFuzzy75(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                    matchFuzzy75(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
                ElseIf matchCatElem.Attributes.ItemOf("min").InnerText = "85" Then
                    matchFuzzy85(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                    matchFuzzy85(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                    matchFuzzy85(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
                ElseIf matchCatElem.Attributes.ItemOf("min").InnerText = "95" Then
                    matchFuzzy95(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                    matchFuzzy95(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                    matchFuzzy95(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
                End If
            End If

        Next

        Dim PerfectItems As String() = {matchPerfect(0), matchPerfect(1), matchPerfect(2)}
        Dim ContextItems As String() = {matchInContext(0), matchInContext(1), matchInContext(2)}
        Dim RepsItems As String() = {matchRepeated(0), matchRepeated(1), matchRepeated(2)}
        Dim CrossFileItems As String() = {matchCrossFileReps(0), matchCrossFileReps(1), matchCrossFileReps(2)}
        Dim Exact100Items As String() = {matchExact(0), matchExact(1), matchExact(2)}
        Dim Fuzzy95Items As String() = {matchFuzzy95(0), matchFuzzy95(1), matchFuzzy95(2)}
        Dim Fuzzy85Items As String() = {matchFuzzy85(0), matchFuzzy85(1), matchFuzzy85(2)}
        Dim Fuzzy75Items As String() = {matchFuzzy75(0), matchFuzzy75(1), matchFuzzy75(2)}
        Dim Fuzzy50Items As String() = {matchFuzzy50(0), matchFuzzy50(1), matchFuzzy50(2)}
        Dim NewItems As String() = {matchNew(0), matchNew(1), matchNew(2)}
        Dim BlankItems As String() = {"", "", ""}
        Dim TotalItems As String() = {matchTotal(0), matchTotal(1), matchTotal(2)}

        Me.MatrixView.View = View.Details
        Me.MatrixView.Items.Clear()

        Me.MatrixView.Items.Add("PerfectMatch").SubItems.AddRange(PerfectItems)
        Me.MatrixView.Items.Add("Context Match").SubItems.AddRange(ContextItems)
        Me.MatrixView.Items.Add("Repetitions").SubItems.AddRange(RepsItems)
        Me.MatrixView.Items.Add("Cross-file Repetitions").SubItems.AddRange(CrossFileItems)
        Me.MatrixView.Items.Add("100%").SubItems.AddRange(Exact100Items)
        Me.MatrixView.Items.Add("95% - 99%").SubItems.AddRange(Fuzzy95Items)
        Me.MatrixView.Items.Add("85% - 94%").SubItems.AddRange(Fuzzy85Items)
        Me.MatrixView.Items.Add("75% - 84%").SubItems.AddRange(Fuzzy75Items)
        Me.MatrixView.Items.Add("50% - 74%").SubItems.AddRange(Fuzzy50Items)
        Me.MatrixView.Items.Add("New").SubItems.AddRange(NewItems)
        Me.MatrixView.Items.Add("").SubItems.AddRange(BlankItems)
        Me.MatrixView.Items.Add("Total").SubItems.AddRange(TotalItems)
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MatrixView.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles TargetLng.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Function PrintReport()

        'Code goes here...

    End Function

    Function preparePrintView(nodeType As String, fileName As String)
        Dim nodePath As String
        If nodeType = "batchTotal" Then
            nodePath = "/task/batchTotal/analyse/*"
            getAndPopulatePrintView(nodePath, "Totals")
        ElseIf nodeType = "file" Then
            nodePath = "/task/file[@name=""" & fileName & """]/analyse/*"
            getAndPopulatePrintView(nodePath, fileName)
        End If
    End Function

    Function getAndPopulatePrintView(finalNodePath As String, fileNamePrint As String)

        For Each matchCatElem As XmlNode In xmlDoc.DocumentElement.SelectNodes(finalNodePath)

            If matchCatElem.Name = "perfect" Then
                matchPerfect(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchPerfect(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchPerfect(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "inContextExact" Then
                matchInContext(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchInContext(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchInContext(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "exact" Then
                matchExact(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchExact(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchExact(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "crossFileRepeated" Then
                matchCrossFileReps(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchCrossFileReps(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchCrossFileReps(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "repeated" Then
                matchRepeated(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchRepeated(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchRepeated(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "total" Then
                matchTotal(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchTotal(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchTotal(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "new" Then
                matchNew(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                matchNew(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                matchNew(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
            End If

            If matchCatElem.Name = "fuzzy" Then
                If matchCatElem.Attributes.ItemOf("min").InnerText = "50" Then
                    matchFuzzy50(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                    matchFuzzy50(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                    matchFuzzy50(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
                ElseIf matchCatElem.Attributes.ItemOf("min").InnerText = "75" Then
                    matchFuzzy75(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                    matchFuzzy75(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                    matchFuzzy75(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
                ElseIf matchCatElem.Attributes.ItemOf("min").InnerText = "85" Then
                    matchFuzzy85(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                    matchFuzzy85(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                    matchFuzzy85(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
                ElseIf matchCatElem.Attributes.ItemOf("min").InnerText = "95" Then
                    matchFuzzy95(0) = matchCatElem.Attributes.ItemOf("segments").InnerText
                    matchFuzzy95(1) = matchCatElem.Attributes.ItemOf("words").InnerText
                    matchFuzzy95(2) = matchCatElem.Attributes.ItemOf("characters").InnerText
                End If
            End If

        Next

        'HTML code goes here...

        file.WriteLine("<a name=""" & fileNamePrint & """><h3>" & fileNamePrint & "</h3></a>")
        file.WriteLine("<table>")
        file.WriteLine("<tr>")
        file.WriteLine("<th><b>Match Category</b></th>")
        file.WriteLine("<th><b>Segments</b></th>")
        file.WriteLine("<th><b>Words</b></th>")
        file.WriteLine("<th><b>Characters</b></th>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>PerfectMatch</b></td>")
        file.WriteLine("<td>" & matchPerfect(0) & "</td>")
        file.WriteLine("<td>" & matchPerfect(1) & "</td>")
        file.WriteLine("<td>" & matchPerfect(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>Context Match</b></td>")
        file.WriteLine("<td>" & matchInContext(0) & "</td>")
        file.WriteLine("<td>" & matchInContext(1) & "</td>")
        file.WriteLine("<td>" & matchInContext(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>Repetitions</b></td>")
        file.WriteLine("<td>" & matchRepeated(0) & "</td>")
        file.WriteLine("<td>" & matchRepeated(1) & "</td>")
        file.WriteLine("<td>" & matchRepeated(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>Cross-file Repetitions</b></td>")
        file.WriteLine("<td>" & matchCrossFileReps(0) & "</td>")
        file.WriteLine("<td>" & matchCrossFileReps(1) & "</td>")
        file.WriteLine("<td>" & matchCrossFileReps(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>100%</b></td>")
        file.WriteLine("<td>" & matchExact(0) & "</td>")
        file.WriteLine("<td>" & matchExact(1) & "</td>")
        file.WriteLine("<td>" & matchExact(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>95% - 99%</b></td>")
        file.WriteLine("<td>" & matchFuzzy95(0) & "</td>")
        file.WriteLine("<td>" & matchFuzzy95(1) & "</td>")
        file.WriteLine("<td>" & matchFuzzy95(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>85% - 94%</b></td>")
        file.WriteLine("<td>" & matchFuzzy85(0) & "</td>")
        file.WriteLine("<td>" & matchFuzzy85(1) & "</td>")
        file.WriteLine("<td>" & matchFuzzy85(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>75% - 84%</b></td>")
        file.WriteLine("<td>" & matchFuzzy75(0) & "</td>")
        file.WriteLine("<td>" & matchFuzzy75(1) & "</td>")
        file.WriteLine("<td>" & matchFuzzy75(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>50% - 74%</b></td>")
        file.WriteLine("<td>" & matchFuzzy50(0) & "</td>")
        file.WriteLine("<td>" & matchFuzzy50(1) & "</td>")
        file.WriteLine("<td>" & matchFuzzy50(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>New</b></td>")
        file.WriteLine("<td>" & matchNew(0) & "</td>")
        file.WriteLine("<td>" & matchNew(1) & "</td>")
        file.WriteLine("<td>" & matchNew(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("<tr>")
        file.WriteLine("<td><b>Total</b></td>")
        file.WriteLine("<td>" & matchTotal(0) & "</td>")
        file.WriteLine("<td>" & matchTotal(1) & "</td>")
        file.WriteLine("<td>" & matchTotal(2) & "</td>")
        file.WriteLine("</tr>")
        file.WriteLine("</table>")

    End Function

    Function openHTML()
        file.WriteLine("<!DOCTYPE html>")
        file.WriteLine("<html>")
        file.WriteLine("<body>")
        file.WriteLine("<h1>Analyze Files Report</h1>")

        Dim nowTimeStamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        file.WriteLine("<h4>Created on: " & nowTimeStamp & "</h4>")

        file.WriteLine("<p>Created with <b>Trados Studio XML Analysis Viewer v1.1</b></p>")

        file.WriteLine("<hr>")
        file.WriteLine("<p></p>")

        file.WriteLine("<h2>Summary</h2>")
        file.WriteLine("<p><b>Report Origin: </b>" & fNameOnly & "</p>")
        file.WriteLine("<p><b>Target Language: </b>" & targetLang & "</p>")
        file.WriteLine("<p><b>Files: </b>" & elemList.Count & "</p>")

        file.WriteLine("<b>File List: </b>")
        file.WriteLine("<ul>")
        For Each fileNode As XmlNode In xmlDoc.DocumentElement.SelectNodes("//file")
            Dim fileListPrint As String = fileNode.Attributes.ItemOf("name").InnerText
            file.WriteLine("<li><a href=""#" & fileListPrint & """ >" & fileListPrint & "</a></li>")
        Next
        file.WriteLine("</ul>")

        file.WriteLine("<hr>")
        file.WriteLine("<p></p>")

        file.WriteLine("<h2>Analysis</h2>")
        file.WriteLine("<p></p>")

        preparePrintView("batchTotal", "")

        file.WriteLine("<p></p>")

        For Each fileNode As XmlNode In xmlDoc.DocumentElement.SelectNodes("//file")
            Dim fileListPrint As String = fileNode.Attributes.ItemOf("name").InnerText
            preparePrintView("file", fileListPrint)
            file.WriteLine("<p></p>")
        Next

    End Function

    Function closeHTML()
        file.WriteLine("<hr>")
        file.WriteLine("<p>Created with <b>Trados Studio XML Analysis Viewer v1.1</b></p>")
        file.WriteLine("<p>Copyright (C) 2017-2019 <a href=""https://www.linkedin.com/in/pdudis/"">Petro Dudi</a><p>")
        file.WriteLine("</body>")
        file.WriteLine("</html>")
        file.Close()
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ExportHTMLButton.Click
        If Label9.Text <> "" Then
            'Call print function
            saveFileDialog1.Filter = "Analyze Files Report (*.html) | *.html"
            saveFileDialog1.Title = "Save Analyze Files Report"
            saveFileDialog1.RestoreDirectory = True

            saveFileDialog1.ShowDialog()
            If saveFileDialog1.FileName <> "" Then
                file = My.Computer.FileSystem.OpenTextFileWriter(saveFileDialog1.FileName, False)
                openHTML()
                closeHTML()


                MessageBox.Show("The Analyze Files Report was saved successfully!", "Export to HTML",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information)
            End If

        Else

            MessageBox.Show("Hey! No data to export...", "Export to HTML",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub listBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FileListBox.SelectedIndexChanged

        ' Get the currently selected item in the ListBox.
        Dim curItem As String

        Try
            curItem = FileListBox.SelectedItem.ToString()
        Catch Ex As Exception
            curItem = "*** Click this entry for Totals ***"
            Label7.Text = "Totals"
        End Try

        If curItem <> "*** Click this entry for Totals ***" Then
            Label7.Text = curItem 'NOTE!!! Create this label and place it on the top of the ListView object
            prepareListView("file", curItem)
        Else
            Label7.Text = "Totals" 'NOTE!!! Create this label and place it on the top of the ListView object
            prepareListView("batchTotal", "")
        End If

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles ReportOrigin.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Application.Exit()
    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub DonateButton_Click(sender As Object, e As EventArgs) Handles DonateButton.Click
        Process.Start(DonateButton.Tag.ToString)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles ShowAnalysisFor.Click

    End Sub
End Class
