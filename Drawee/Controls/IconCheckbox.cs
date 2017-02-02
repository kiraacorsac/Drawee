using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Binding;
using System.Collections;
using DotVVM.Framework.Hosting;

namespace Drawee.Controls
{
    public class IconCheckbox : CheckableControlBase
    {

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DotvvmProperty IconProperty
            = DotvvmProperty.Register<string, IconCheckbox>(c => c.Icon, "https://i.imgur.com/EHWNFi5.png");



        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DotvvmProperty NameProperty
            = DotvvmProperty.Register<string, IconCheckbox>(c => c.Name, null);


        protected override void RenderInputTag(IHtmlWriter writer)
        {
            writer.AddStyleAttribute("width", "150px");
            writer.AddStyleAttribute("height", "155px");
            writer.AddStyleAttribute("display", "inline-flex");
            writer.RenderBeginTag("div");

            RenderCheckbox(writer);
            RenderCheckboxPicture(writer);
            RenderNotPicked(writer);
            RenderPicked(writer);

            writer.RenderEndTag();
        }

        private void RenderCheckboxPicture(IHtmlWriter writer)
        {
            writer.AddKnockoutDataBind("attr", BuildKnockoutBidningLabelAttributes());
            writer.AddKnockoutDataBind("text", this, NameProperty, () =>
            {
                writer.AddAttribute("text", Name);
            });
            writer.RenderBeginTag("label");
            writer.RenderEndTag();
        }

        private void RenderCheckbox(IHtmlWriter writer)
        {

            RenderCheckedProperty(writer);
            writer.AddAttribute("class", "icon-checkbox");
            writer.AddAttribute("type", "checkbox");
            writer.AddStyleAttribute("display", "none");
            writer.AddKnockoutDataBind("attr", BuildKnockoutBindingsInputAttributes());
            writer.RenderSelfClosingTag("input");
        }

        private static void RenderNotPicked(IHtmlWriter writer)
        {
            writer.AddStyleAttribute("margin-left", "-23px");
            writer.AddStyleAttribute("margin-bottom", "100px");
            writer.AddStyleAttribute("width", "13px");
            writer.AddStyleAttribute("background-color", "#C44");
            writer.AddStyleAttribute("display", "inline-block");
            writer.RenderBeginTag("span");
            writer.RenderEndTag();
        }

        private void RenderPicked(IHtmlWriter writer)
        {
            writer.AddKnockoutDataBind("visible", GetValueBinding(CheckedProperty));
            writer.AddStyleAttribute("margin-left", "-13px");
            writer.AddStyleAttribute("margin-bottom", "100px");
            writer.AddStyleAttribute("width", "13px");
            writer.AddStyleAttribute("background-color", "#2E2");
            writer.AddStyleAttribute("color", "#2E2");
            writer.AddStyleAttribute("display", "inline-block");
            writer.RenderBeginTag("span");
            writer.RenderEndTag();
        }

        protected void RenderCheckedProperty(IHtmlWriter writer)
        {
            var checkedBinding = GetValueBinding(CheckedProperty);
            writer.AddKnockoutDataBind("checked", checkedBinding);
            writer.AddKnockoutDataBind("checkedValue", GetValueBinding(CheckedValueProperty));
        }


        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            base.AddAttributesToRender(writer, context);
        }

        private KnockoutBindingGroup BuildKnockoutBindingsInputAttributes()
        {
            var bindings = new KnockoutBindingGroup();

            bindings.Add("id", this, NameProperty, () =>
            {
                bindings.Add("id", Name, true);
            });

            return bindings;

        }

        private KnockoutBindingGroup BuildKnockoutBidningLabelAttributes()
        {
            var bindings = new KnockoutBindingGroup();
            bindings.Add("for", this, NameProperty, () =>
            {
                bindings.Add("for", Name);
            });
            bindings.Add("style",
                "'background-image:url(\"'+"
                + GetValueBinding(IconProperty).GetKnockoutBindingExpression()
                + "()"
                + "+'\");"
                + "color: black;"
                + "text-shadow: 2px 0 0 #fff, -2px 0 0 #fff, 0 2px 0 #fff, 0 -2px 0 #fff, 1px 1px #fff, -1px -1px 0 #fff, 1px -1px 0 #fff, -1px 1px 0 #fff;"
                + "width:150px;"
                + "height:150px;"
                + "display:inline-block;"
                + "background-size:150px, 150px'");
            return bindings;
        }



    }
}

