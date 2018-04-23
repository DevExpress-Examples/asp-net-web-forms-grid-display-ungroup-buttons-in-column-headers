Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxHiddenField
Imports System.Web.UI.HtmlControls

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			TryCast(GridView1.Columns(2), GridViewDataColumn).GroupBy()

			CreateUnGroupButton()
		End If
	End Sub
	Protected Sub GridView1_BeforeGetCallbackResult(ByVal sender As Object, ByVal e As EventArgs)
		CreateUnGroupButton()
	End Sub

	Protected Sub CreateUnGroupButton()
	 For Each column As GridViewDataColumn In GridView1.DataColumns
			If column.GroupIndex <> -1 Then
				column.HeaderCaptionTemplate = New MyTemplate()
			End If
	 Next column
	End Sub


	Private Class MyTemplate
		Implements ITemplate
		Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			Dim gridContainer As GridViewHeaderTemplateContainer = CType(container, GridViewHeaderTemplateContainer)
			Dim fieldName As String = (TryCast(gridContainer.Column, GridViewDataColumn)).FieldName

			Dim caption As New Literal()
			caption.ID = "caption_" & gridContainer.ItemIndex.ToString()
			caption.Text = fieldName
			container.Controls.Add(caption)

			Dim image As New ASPxImage()
			image.ID = "unGroup_" & gridContainer.ItemIndex.ToString()
			image.ImageUrl = "~/Delete.png"
			image.ToolTip = "UnGroup column"
			container.Controls.Add(image)

			image.ClientSideEvents.Click = String.Format("function(s, e){{ gridView.UnGroup ('{0}'); }}", fieldName)
			image.ClientSideEvents.Init = "OnImageInit"
		End Sub
	End Class
End Class