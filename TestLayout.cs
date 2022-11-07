public class TestLayout
{
    public static string Render()
    {
        // return Layout.AddContainer(Layout.AddRow(
        //                                 Layout.AddColumn(
        //                                     Layout.AddButton("Click Me")), 
        //                                 Layout.AddColumn(
        //                                     Layout.AddElement("<h3>Hello World</h3>"))),
        //                             Layout.AddRow(Layout.AddColumn(Layout.AddButton("Im Green", "success")), Layout.AddColumn(Layout.AddButton("Scary", "danger")), Layout.AddColumn(Layout.AddAlert("This is class", "warning")))
        //                     )
                            
        //                 .Render();


        var rootContainer = Layout.AddContainer();
        var firstRow = Layout.AddRow();
        var firstCol = Layout.AddColumn();

        //my stuff
        var hello = Layout.AddButton("hey");
        var button = Layout.AddButton("hey", "success");
        var alert = Layout.AddAlert("hey", "success");
        var badge = Layout.AddBadge("Test", "danger");
        var card = Layout.AddCard("This is my main text", "My Card Title", "My Card Subtitle");
        var carousel = Layout.AddCarousel("https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AA13DhCz.img?w=800&h=415&q=60&m=2&f=jpg", "image1", "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AA13DhCz.img?w=800&h=415&q=60&m=2&f=jpg", "Image2", "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AA13DhCz.img?w=800&h=415&q=60&m=2&f=jpg", "Image 3");
        var buttongroup = Layout.AddButtonGroup("success", "button 1", "warning", "button 2", "danger", "button3");
        var collapse = Layout.AddCollapse("success", "Collapse Button", "This is my collapsed text");
        var dropdown = Layout.AddDropdownButton("My Droppdown", "secondary", "https://google.com", "Google", "https://bing.com", "Bing", "https://twitter.com", "Twitter");
        var listgroup = Layout.AddListGroup("Item 1", "Item 2", "Itrm 3", "Item 4", "Item 5");
        var modal = Layout.AddModal("mymodal", "Modal Title", "This is my modal body text", "Save Button", "Close Button");
        var progress = Layout.AddProgress("42", "0", "100");
        var buttontooltip = Layout.AddButtonToolTip("success", "This is my TT Text", "This is my button");

        rootContainer.AddChildren(firstRow);
        firstRow.AddChildren(firstCol);
        firstCol.AddChildren(hello);
        firstCol.AddChildren(button);
        firstCol.AddChildren(alert);
        firstCol.AddChildren(badge);
        firstCol.AddChildren(card);
        firstCol.AddChildren(carousel);
        firstCol.AddChildren(buttongroup);
        firstCol.AddChildren(collapse);
        firstCol.AddChildren(dropdown);
        firstCol.AddChildren(listgroup);
        firstCol.AddChildren(modal);
        firstCol.AddChildren(progress);
        firstCol.AddChildren(buttontooltip);


        return rootContainer.Render();

    }

}