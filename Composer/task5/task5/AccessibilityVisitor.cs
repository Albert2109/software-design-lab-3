using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class AccessibilityVisitor : ILightVisitor
    {
        public List<string> Issues { get; } = new List<string>();
        private int lastHeaderLevel = 0;

        public void Visit(LightTextNode text)
        {

        }

        public void Visit(LightElementNode elem)
        {
            switch (elem.TagName)
            {
                case "img":
                    HandleImage(elem);
                    break;
                case "video":
                case "audio":
                    HandleMedia(elem);
                    break;
                case "a":
                    HandleLink(elem);
                    break;
                case "h1":
                case "h2":
                case "h3":
                case "h4":
                case "h5":
                case "h6":
                    HandleHeader(elem);
                    break;
                case "p":
                    HandleParagraph(elem);
                    break;
                case "nav":
                    EnsureRole(elem, "navigation");
                    break;
                case "main":
                    EnsureRole(elem, "main");
                    break;
                case "form":
                    HandleForm(elem);
                    break;
                case "input":
                case "textarea":
                case "select":
                    HandleFormControl(elem);
                    break;
                case "button":
                    HandleButton(elem);
                    break;
                case "figure":
                    HandleFigure(elem);
                    break;
                case "table":
                    HandleTable(elem);
                    break;
            }
            foreach (var child in elem.Children.ToList())
                child.Accept(this);
        }

        private void HandleImage(LightElementNode img)
        {
            if (!img.Attributes.ContainsKey("alt"))
            {
                Issues.Add("[img] Missing alt attribute. Added default alt.");
                img.Attributes["alt"] = "Description of image";
            }
        }

        private void HandleMedia(LightElementNode media)
        {
            if (!media.Attributes.ContainsKey("aria-label") && !media.Attributes.ContainsKey("aria-labelledby"))
            {
                Issues.Add($"[{media.TagName}] Missing aria-label. Added placeholder.");
                media.Attributes["aria-label"] = media.TagName;
            }
        }

        private void HandleLink(LightElementNode link)
        {
            var text = link.InnerHTML.Trim();
            if (string.IsNullOrEmpty(text) || text.Equals("click here", StringComparison.OrdinalIgnoreCase))
            {
                Issues.Add("[a] Link text is non-descriptive. Enhanced text.");
                link.Children.Clear();
                link.Children.Add(new LightTextNode("Learn more"));
            }
        }

        private void HandleHeader(LightElementNode header)
        {
            int level = int.Parse(header.TagName.Substring(1));
            if (level - lastHeaderLevel > 1)
            {
                Issues.Add($"[{header.TagName}] Skipped header level. Adjusted to h{lastHeaderLevel + 1}.");
                header.Attributes["data-original"] = header.TagName;
                
            }
            lastHeaderLevel = level;
        }

        private void HandleParagraph(LightElementNode p)
        {
            var sentiment = p.InnerHTML.Contains("!") ? "😊" : "🤔";
            p.Children.Add(new LightTextNode(sentiment));
            Issues.Add($"[p] Added sentiment {sentiment}.");
        }

        private void HandleForm(LightElementNode form)
        {
            
            if (!form.Attributes.ContainsKey("aria-label") && !form.Attributes.ContainsKey("aria-labelledby"))
            {
                Issues.Add("[form] Missing accessible name. Added aria-label 'Form'.");
                form.Attributes["aria-label"] = "Form";
            }
        }

        private void HandleFormControl(LightElementNode control)
        {
            
            if (control.TagName == "input" && control.Attributes.TryGetValue("type", out var type) && type == "hidden")
                return;

           
            bool hasLabel = control.Attributes.ContainsKey("aria-label") || control.Attributes.ContainsKey("aria-labelledby");
            bool hasId = control.Attributes.ContainsKey("id");
            if (!hasLabel)
            {
                Issues.Add($"[{control.TagName}] Missing accessible name. Added aria-label '{control.TagName}'.");
                control.Attributes["aria-label"] = control.TagName;
            }
           
            if (!hasId)
            {
                var id = Guid.NewGuid().ToString();
                Issues.Add($"[{control.TagName}] Missing id. Added id '{id}'.");
                control.Attributes["id"] = id;
            }
        }

        private void HandleButton(LightElementNode button)
        {
            var text = button.InnerHTML.Trim();
            if (string.IsNullOrEmpty(text) && !button.Attributes.ContainsKey("aria-label"))
            {
                Issues.Add("[button] Empty button. Added aria-label 'Button'.");
                button.Attributes["aria-label"] = "Button";
            }
        }

        private void HandleFigure(LightElementNode figure)
        {
            
            bool hasCaption = figure.Children.OfType<LightElementNode>()
                .Any(c => c.TagName == "figcaption");
            if (!hasCaption)
            {
                Issues.Add("[figure] Missing figcaption. Added placeholder caption.");
                figure.Children.Add(new LightElementNode("figcaption")
                {
                    Children = { new LightTextNode("Figure description") }
                });
            }
        }

        private void HandleTable(LightElementNode table)
        {
           
            bool hasCaption = table.Children.OfType<LightElementNode>()
                .Any(c => c.TagName == "caption");
            bool hasLabel = table.Attributes.ContainsKey("aria-label");
            if (!hasCaption && !hasLabel)
            {
                Issues.Add("[table] Missing caption. Added default caption.");
                table.Children.Insert(0, new LightElementNode("caption")
                {
                    Children = { new LightTextNode("Table description") }
                });
            }
        }

        private void EnsureRole(LightElementNode elem, string role)
        {
            if (!elem.Attributes.ContainsKey("role"))
            {
                Issues.Add($"[{elem.TagName}] Added role='{role}'.");
                elem.Attributes["role"] = role;
            }
        }
    }
}
