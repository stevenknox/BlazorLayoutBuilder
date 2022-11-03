using System.Text;

public class Layout
{
    public string Id { get; set; }
    public LayoutType Type { get; set; }
    public string Markup { get; set; }
    public static Layout Create() => new Layout();
    public static Layout AddContainer(params Layout[] layouts) => Layout.Create(LayoutType.Container).AddChildren(layouts);
    public static Layout AddRow(params Layout[] layouts) => Layout.Create(LayoutType.Row).AddChildren(layouts);
    public static Layout AddColumn(params Layout[] layouts) => Layout.Create(LayoutType.Column).AddChildren(layouts);
    public static Layout AddElement(string markup) => Layout.Create(LayoutType.Element).SetMarkup(markup);
    public static Layout AddButton(string markup) => Layout.Create(LayoutType.Element).SetMarkup($"<button class='btn btn-primary'>{markup}</button>");
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

public class TestLayout
{
    public static string Render()
    {
        return Layout.AddContainer(Layout.AddRow(
                                        Layout.AddColumn(
                                            Layout.AddButton("Click Me")), 
                                        Layout.AddColumn(
                                            Layout.AddElement("<h3>Hello World</h3>"))))
                        .Render();
    }

}