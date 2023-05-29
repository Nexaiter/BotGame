namespace Game.Api.Common
{
    public record FullMessage
    (
        string? Title = null, string? Description = null,
            IEnumerable<(string Label, string Id)>? Buttons = null,
            IEnumerable<(string MenuId, string PlaceHolder, IEnumerable<(string Id, string Value)> options)>? Menus = null,
            IEnumerable<(string Name, string Value)>? Fields = null
    );
}
