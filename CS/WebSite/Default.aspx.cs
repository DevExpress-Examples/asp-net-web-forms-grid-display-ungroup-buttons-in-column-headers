using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Web.UI.HtmlControls;

public partial class _Default: System.Web.UI.Page {

    protected void GridView1_DataBound(object sender, EventArgs e) {
        if (!IsPostBack) {
            (GridView1.Columns[2] as GridViewDataColumn).GroupBy();

            CreateUnGroupButton();
        }
    }
    protected void GridView1_BeforeGetCallbackResult(object sender, EventArgs e) {
        CreateUnGroupButton();
    }

    protected void CreateUnGroupButton() { 
     foreach (GridViewDataColumn column in GridView1.DataColumns) {
            if (column.GroupIndex != -1) {
                column.HeaderCaptionTemplate = new MyTemplate();
            }
        }
    }


    class MyTemplate: ITemplate {
        public void InstantiateIn(Control container) {
            GridViewHeaderTemplateContainer gridContainer = (GridViewHeaderTemplateContainer)container;
            string fieldName = (gridContainer.Column as GridViewDataColumn).FieldName;

            Literal caption = new Literal();
            caption.ID = "caption_" + gridContainer.ItemIndex.ToString();
            caption.Text = fieldName;
            container.Controls.Add(caption);

            ASPxImage image = new ASPxImage();
            image.ID = "unGroup_" + gridContainer.ItemIndex.ToString();
            image.ImageUrl = "~/Delete.png";
            image.ToolTip = "UnGroup column";
            container.Controls.Add(image);

            image.ClientSideEvents.Click = string.Format("function(s, e){{ gridView.UnGroup ('{0}'); }}", fieldName);
            image.ClientSideEvents.Init = "OnImageInit";
        }
    }
}