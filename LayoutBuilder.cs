using System.Text;

public class Layout
{
    public string Id { get; set; }
    public LayoutType Type { get; set; }
    public string Markup { get; set; }

    //public static Layout AddElement(string markup) => Layout.Create(LayoutType.Element).SetMarkup(markup);

    public static Layout Create() => new Layout();
    public static Layout AddContainer(params Layout[] layouts) => Layout.Create(LayoutType.Container).AddChildren(layouts);
    public static Layout AddRow(params Layout[] layouts) => Layout.Create(LayoutType.Row).AddChildren(layouts);
    public static Layout AddColumn(params Layout[] layouts) => Layout.Create(LayoutType.Column).AddChildren(layouts);
    public static Layout AddElement(string markup) => Layout.Create(LayoutType.Element).SetMarkup(markup);
    public static Layout AddButton(string markup) => Layout.Create(LayoutType.Element).SetMarkup($"<button class='btn btn-primary'>{markup}</button>");
    public static Layout AddButton(string markup, string color) => Layout.Create(LayoutType.Element).SetMarkup($"<button class='btn btn-{color}'>{markup}</button>");
    public static Layout AddAlert(string markup, string color) => Layout.Create(LayoutType.Element).SetMarkup($"<div class='alert alert-{color}' role='alert'>{markup}</div>");
    public static Layout AddBadge(string markup, string color) => Layout.Create(LayoutType.Element).SetMarkup($"<span class='badge bg-{color}'>{markup}</span>");
    public static Layout AddCard(string markup, string title, string subtitle) => Layout.Create(LayoutType.Element).SetMarkup ($"<div class='card'><div class='card-body'><h5 class='card-title'>{title}</h5><h6 class='card-subtitle mb-2 text-muted'>{subtitle}</h6><p class='card-text'>{markup}</p></div></div>");
    public static Layout AddCarousel(string image1, string image1alt, string image2, string image2alt, string image3, string image3alt) => Layout.Create(LayoutType.Element).SetMarkup ($"<div id='carouselExampleSlidesOnly' class='carousel slide' data-bs-ride='carousel'><div class='carousel-inner'><div class='carousel-item active'><img src='{image1}' class='d-block w-100' alt='{image1alt}'></div><div class='carousel-item'><img src='{image2}' class='d-block w-100' alt='{image2alt}'></div><div class='carousel-item'><img src='{image3}' class='d-block w-100' alt='{image3alt}'></div></div></div>");
    public static Layout AddButtonGroup(string button1color, string button1text, string button2color, string button2text, string button3color, string button3text) => Layout.Create(LayoutType.Element).SetMarkup ($"<div class='btn-group' role='group' aria-label='Basic example'><button type='button' class='btn btn-{button1color}'>{button1text}</button><button type='button' class='btn btn-{button2color}'>{button2text}</button><button type='button' class='btn btn-{button3color}'>{button3text}</button></div>");
    
    
    //Need to see why the AddCollapse isn't working. Come back to this.
    public static Layout AddCollapse(string color, string buttontext, string collapsetext) => Layout.Create(LayoutType.Element).SetMarkup ($"<button class='btn btn-{color}' type='button' data-toggle='collapse' data-target='#collapseExample' aria-expanded='false' aria-controls='collapseExample'>{buttontext}</button><div class='collapse' id='collapseExample'><div class='card card-body'>{collapsetext}</div></div>");

    //Need to see why the AddDropdown isn't working. Come back to this.
    public static Layout AddDropdownButton(string buttontext, string color, string item1url, string item1text, string item2url, string item2text, string item3url, string item3text) => Layout.Create(LayoutType.Element).SetMarkup($"<div class='dropdown'><button class='btn btn-{color} dropdown-toggle' type='button' id='dropdownMenuButton' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>{buttontext}</button><div class='dropdown-menu' aria-labelledby='dropdownMenuButton'><a class='dropdown-item' href='{item1url}'>{item1text}</a><a class='dropdown-item' href='{item2url}'>{item2text}</a><a class='dropdown-item' href='{item3url}'>{item3text}</a></div></div>");

    public static Layout AddListGroup(string item1text, string item2text, string item3text, string item4text, string item5text) => Layout.Create(LayoutType.Element).SetMarkup($"<ul class='list-group'><li class='list-group-item'>{item1text}</li><li class='list-group-item'>{item2text}</li><li class='list-group-item'>{item3text}</li><li class='list-group-item'>{item4text}</li><li class='list-group-item'>{item5text}</li></ul>");
    public static Layout AddModal(string modalid, string modaltitle, string modalbody, string savetext, string closetext) => Layout.Create(LayoutType.Element).SetMarkup($"<div class='modal' id='{modalid}' tabindex='-1' role='dialog'><div class='modal-dialog' role='document'><div class='modal-content'><div class='modal-header'><h5 class='modal-title'>{modaltitle}</h5><button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div><div class='modal-body'><p>{modalbody}</p></div><div class='modal-footer'><button type='button' class='btn btn-primary'>{savetext}</button><button type='button' class='btn btn-secondary' data-dismiss='modal'>{closetext}</button></div></div></div></div>");
    public static Layout AddProgress(string valuenow, string valuemin, string valuemax) => Layout.Create(LayoutType.Element).SetMarkup($"<div class='progress'><div class='progress-bar' role='progressbar' style='width: {valuenow}%'' aria-valuenow='{valuenow}' aria-valuemin='{valuemin}' aria-valuemax='{valuemax}'></div></div>");
    public static Layout AddButtonToolTip(string color, string tooltiptext, string buttontext) => Layout.Create(LayoutType.Element).SetMarkup($"<button type='button' class='btn btn-{color}' data-toggle='tooltip' data-placement='top' title='{tooltiptext}'>{buttontext}</button>");

    private Layout SetMarkup(string markup)
    {
       Markup = markup;
       return this;
    }

    public static Layout Create(LayoutType type) => new Layout{ Type = type };
    public static Layout Create(LayoutType Type, string id, LayoutSettings settings)
    {
        var layout = Layout.Create(Type);

        layout.Settings = settings ?? new();
        layout.Id = id;

        return layout;
    }
    public List<Layout> Children { get; set; } = new();

    public LayoutSettings Settings = new();

     public Layout AddChildren(params Layout[] layout)
    {
        Children.AddRange(layout);
        return this;
    }

    public string Render()
    {
       return Render(this);
    }

    private string Render(Layout childElement)
    {
        var str = "";

        switch (childElement.Type)
        {
            case LayoutType.Container: str = @$"<div class=""container"">" + RenderChildren(childElement.Children) + "</div>"; break;
            case LayoutType.Row: str = $@"<div class=""row"">" + RenderChildren(childElement.Children) + "</div>"; break;
            case LayoutType.Column: str = @"<div class=""col"">" + RenderChildren(childElement.Children) + "</div>"; break;
            case LayoutType.Element: str = @$"<div>{childElement.Markup}</div>"; break;
            default: break;
        }
        return str;
       
    }

      private string RenderChildren(List<Layout> elements)
    {
        var str = "";
        foreach (var childElement in elements)
        {
            str += Render(childElement);
        }
        return str;
    }
}

public class LayoutSettings
{
    public string Width { get; set; }
    public string Height { get; set; }
    public string Style { get; set; }
    public string Css { get; set; }
}

public enum LayoutType
{
    Container,
    Row,
    Column,
    Element,
    Empty
}
