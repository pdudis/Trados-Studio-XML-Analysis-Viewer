<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.OpenXMLButton = New System.Windows.Forms.Button()
        Me.MatrixView = New System.Windows.Forms.ListView()
        Me.matchCat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.segments = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.words = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.characters = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TargetLng = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumberOfFiles = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FileList = New System.Windows.Forms.Label()
        Me.FileListBox = New System.Windows.Forms.ListBox()
        Me.ExportHTMLButton = New System.Windows.Forms.Button()
        Me.ShowAnalysisFor = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.OpenSDLPPXButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.ReportOrigin = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.DonateButton = New System.Windows.Forms.Button()
        Me.ListBoxToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Divider = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OpenXMLButton
        '
        Me.OpenXMLButton.Location = New System.Drawing.Point(11, 365)
        Me.OpenXMLButton.Name = "OpenXMLButton"
        Me.OpenXMLButton.Size = New System.Drawing.Size(90, 23)
        Me.OpenXMLButton.TabIndex = 0
        Me.OpenXMLButton.Text = "Open XML File"
        Me.OpenXMLButton.UseVisualStyleBackColor = True
        '
        'MatrixView
        '
        Me.MatrixView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.matchCat, Me.segments, Me.words, Me.characters})
        Me.MatrixView.FullRowSelect = True
        Me.MatrixView.GridLines = True
        Me.MatrixView.Location = New System.Drawing.Point(11, 12)
        Me.MatrixView.Name = "MatrixView"
        Me.MatrixView.Size = New System.Drawing.Size(348, 347)
        Me.MatrixView.TabIndex = 1
        Me.MatrixView.TabStop = False
        Me.MatrixView.UseCompatibleStateImageBehavior = False
        Me.MatrixView.View = System.Windows.Forms.View.Details
        '
        'matchCat
        '
        Me.matchCat.Text = "Match Category"
        Me.matchCat.Width = 120
        '
        'segments
        '
        Me.segments.Text = "Segments"
        Me.segments.Width = 70
        '
        'words
        '
        Me.words.Text = "Words"
        Me.words.Width = 70
        '
        'characters
        '
        Me.characters.Text = "Characters"
        Me.characters.Width = 70
        '
        'TargetLng
        '
        Me.TargetLng.AutoSize = True
        Me.TargetLng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TargetLng.Location = New System.Drawing.Point(375, 60)
        Me.TargetLng.Name = "TargetLng"
        Me.TargetLng.Size = New System.Drawing.Size(108, 13)
        Me.TargetLng.TabIndex = 2
        Me.TargetLng.Text = "Target Language:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(482, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 3
        '
        'NumberOfFiles
        '
        Me.NumberOfFiles.AutoSize = True
        Me.NumberOfFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.NumberOfFiles.Location = New System.Drawing.Point(375, 82)
        Me.NumberOfFiles.Name = "NumberOfFiles"
        Me.NumberOfFiles.Size = New System.Drawing.Size(99, 13)
        Me.NumberOfFiles.TabIndex = 4
        Me.NumberOfFiles.Text = "Number of Files:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(473, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 5
        '
        'FileList
        '
        Me.FileList.AutoSize = True
        Me.FileList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.FileList.Location = New System.Drawing.Point(375, 113)
        Me.FileList.Name = "FileList"
        Me.FileList.Size = New System.Drawing.Size(55, 13)
        Me.FileList.TabIndex = 6
        Me.FileList.Text = "File List:"
        '
        'FileListBox
        '
        Me.FileListBox.FormattingEnabled = True
        Me.FileListBox.Location = New System.Drawing.Point(378, 134)
        Me.FileListBox.Name = "FileListBox"
        Me.FileListBox.Size = New System.Drawing.Size(354, 225)
        Me.FileListBox.TabIndex = 2
        Me.ListBoxToolTip.SetToolTip(Me.FileListBox, "Click on an entry to show" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "its analysis on the left.")
        '
        'ExportHTMLButton
        '
        Me.ExportHTMLButton.Location = New System.Drawing.Point(199, 365)
        Me.ExportHTMLButton.Name = "ExportHTMLButton"
        Me.ExportHTMLButton.Size = New System.Drawing.Size(90, 23)
        Me.ExportHTMLButton.TabIndex = 3
        Me.ExportHTMLButton.Text = "Export to HTML"
        Me.ExportHTMLButton.UseVisualStyleBackColor = True
        '
        'ShowAnalysisFor
        '
        Me.ShowAnalysisFor.AutoSize = True
        Me.ShowAnalysisFor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ShowAnalysisFor.Location = New System.Drawing.Point(375, 12)
        Me.ShowAnalysisFor.Name = "ShowAnalysisFor"
        Me.ShowAnalysisFor.Size = New System.Drawing.Size(127, 13)
        Me.ShowAnalysisFor.TabIndex = 9
        Me.ShowAnalysisFor.Text = "Showing analysis for:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(501, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 10
        '
        'OpenSDLPPXButton
        '
        Me.OpenSDLPPXButton.Location = New System.Drawing.Point(107, 365)
        Me.OpenSDLPPXButton.Name = "OpenSDLPPXButton"
        Me.OpenSDLPPXButton.Size = New System.Drawing.Size(86, 23)
        Me.OpenSDLPPXButton.TabIndex = 1
        Me.OpenSDLPPXButton.Text = "Open SDLPPX"
        Me.OpenSDLPPXButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'ReportOrigin
        '
        Me.ReportOrigin.AutoSize = True
        Me.ReportOrigin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ReportOrigin.Location = New System.Drawing.Point(375, 39)
        Me.ReportOrigin.Name = "ReportOrigin"
        Me.ReportOrigin.Size = New System.Drawing.Size(86, 13)
        Me.ReportOrigin.TabIndex = 12
        Me.ReportOrigin.Text = "Report Origin:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(458, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 13
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(657, 365)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(75, 23)
        Me.ExitButton.TabIndex = 6
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'AboutButton
        '
        Me.AboutButton.Location = New System.Drawing.Point(459, 365)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(75, 23)
        Me.AboutButton.TabIndex = 5
        Me.AboutButton.Text = "About"
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'DonateButton
        '
        Me.DonateButton.Location = New System.Drawing.Point(378, 365)
        Me.DonateButton.Name = "DonateButton"
        Me.DonateButton.Size = New System.Drawing.Size(75, 23)
        Me.DonateButton.TabIndex = 4
        Me.DonateButton.Tag = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=TRYWUN86YT4U" &
    "6"
        Me.DonateButton.Text = "Donate"
        Me.DonateButton.UseVisualStyleBackColor = True
        '
        'ListBoxToolTip
        '
        Me.ListBoxToolTip.AutomaticDelay = 200
        Me.ListBoxToolTip.AutoPopDelay = 5000
        Me.ListBoxToolTip.InitialDelay = 200
        Me.ListBoxToolTip.ReshowDelay = 40
        '
        'Divider
        '
        Me.Divider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Divider.Location = New System.Drawing.Point(378, 32)
        Me.Divider.Name = "Divider"
        Me.Divider.Size = New System.Drawing.Size(354, 2)
        Me.Divider.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(378, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(354, 2)
        Me.Label1.TabIndex = 15
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 397)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Divider)
        Me.Controls.Add(Me.DonateButton)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ReportOrigin)
        Me.Controls.Add(Me.OpenSDLPPXButton)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ShowAnalysisFor)
        Me.Controls.Add(Me.ExportHTMLButton)
        Me.Controls.Add(Me.FileListBox)
        Me.Controls.Add(Me.FileList)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumberOfFiles)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TargetLng)
        Me.Controls.Add(Me.MatrixView)
        Me.Controls.Add(Me.OpenXMLButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Trados Studio XML Analysis Viewer (v1.1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenXMLButton As Button
    Friend WithEvents MatrixView As ListView
    Friend WithEvents matchCat As ColumnHeader
    Friend WithEvents segments As ColumnHeader
    Friend WithEvents words As ColumnHeader
    Friend WithEvents characters As ColumnHeader
    Friend WithEvents TargetLng As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NumberOfFiles As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents FileList As Label
    Friend WithEvents FileListBox As ListBox
    Friend WithEvents ExportHTMLButton As Button
    Friend WithEvents ShowAnalysisFor As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents OpenSDLPPXButton As Button
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents ReportOrigin As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ExitButton As Button
    Friend WithEvents AboutButton As Button
    Friend WithEvents DonateButton As Button
    Friend WithEvents ListBoxToolTip As ToolTip
    Friend WithEvents Divider As Label
    Friend WithEvents Label1 As Label
End Class
