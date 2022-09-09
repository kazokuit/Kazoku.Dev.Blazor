namespace Kazoku.Dev.Blazor.Models
{
    public class Link
    {

        public string Text { get; set; }
        public int Page { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Active { get; set; } = false;

        public Link(int page)
            : this(page, true) { }

        public Link(int page, bool enabled)
            : this(page, enabled, page.ToString()) { }

        public Link(int page, bool enabled, string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }
    }
}
