# ASPxGridView - How to create a header's button that allows ungrouping a column on a click


<p>This example demonstrates how to create a button inside the grid's header that allows ungrouping a column by a click.</p><p>We will use the HeaderCaption Template to add the UnGroup button to the column's header:</p><br />


```cs
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

```

<p> The OnImageInit function prevents the grid's sorting when a user clicks the UnGroup button:</p>

```js
function OnImageInit(s, e) {
	var element = s.GetMainElement();
	element.onmousedown = element.onmouseup = function (event) {
		event.cancelBubble = true;
		return false;
	};
}

```

<p> However, it is necessary to set a template only for grouped columns. For this, use the following code:<br />


```cs
    protected void CreateUnGroupButton() { 
     foreach (GridViewDataColumn column in GridView1.DataColumns) {
            if (column.GroupIndex != -1) {
                column.HeaderCaptionTemplate = new MyTemplate();
            }
        }
    }
```

 </p>

<br/>


