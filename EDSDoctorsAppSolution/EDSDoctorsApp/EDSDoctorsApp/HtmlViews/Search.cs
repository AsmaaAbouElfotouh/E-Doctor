#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDSDoctorsApp.HtmlViews
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 1 "Search.cshtml"
using EDSDoctorsApp.Resources;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "17.1.0.329")]
public partial class Search : SearchBase
{

#line hidden

public override void Execute()
{
WriteLiteral("\n<!DOCTYPE HTML>\n<html");

WriteLiteral(" lang=\"en\"");

WriteAttribute ("dir", " dir=\"", "\""

#line 4 "Search.cshtml"
, Tuple.Create<string,object,bool> ("", AppResources.dir

#line default
#line hidden
, false)
);
WriteLiteral(">\n<head>\n    <meta");

WriteLiteral(" http-equiv=\"Content-Type\"");

WriteLiteral(" content=\"text/html; charset=utf-8\"");

WriteLiteral(" />\n    <meta");

WriteLiteral(" name=\"apple-mobile-web-app-capable\"");

WriteLiteral(" content=\"yes\"");

WriteLiteral(">\n    <meta");

WriteLiteral(" name=\"apple-mobile-web-app-status-bar-style\"");

WriteLiteral(" content=\"black-translucent\"");

WriteLiteral(">\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, " +
"viewport-fit=cover\"");

WriteLiteral(" />\n    <title>eDoctor Patient - Find A Doctor</title>\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute ("href", " href=\"", "\""

#line 11 "Search.cshtml"
          , Tuple.Create<string,object,bool> ("", string.Concat("Sticky/styles/bootstrap",AppResources.dir2,".css")

#line default
#line hidden
, false)
);
WriteLiteral(">\n    <link");

WriteLiteral(" href=\"Sticky/fonts/css.css?family=Roboto:300,300i,400,400i,500,500i,700,700i,900" +
",900i|Source+Sans+Pro:300,300i,400,400i,600,600i,700,700i,900,900i&display=swap\"" +
"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(">\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" href=\"Sticky/fonts/css/fontawesome-all.min.css\"");

WriteLiteral(">\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" href=\"Sticky/styles/highlights/highlight_orange.css\"");

WriteLiteral(">\n    <link");

WriteLiteral(" rel=\"manifest\"");

WriteLiteral(" href=\"_manifest.json\"");

WriteLiteral(" data-pwa-version=\"set_in_manifest_and_pwa_js\"");

WriteLiteral(">\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"180x180\"");

WriteLiteral(" href=\"Sticky/app/icons/icon-192x192.png\"");

WriteLiteral(">\n    <link");

WriteLiteral(" href=\"Sticky/styles/highlights/highlight_dark.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\n</head>\n<body");

WriteLiteral(" class=\"theme-light\"");

WriteLiteral(" data-highlight=\"highlight-dark\"");

WriteLiteral(" data-gradient=\"body-default\"");

WriteLiteral(">\n    <div");

WriteLiteral(" id=\"page\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"header header-fixed header-logo-center header-auto-showx\"");

WriteLiteral(">\n            <i");

WriteLiteral(" class=\"header-title\"");

WriteLiteral("><img");

WriteLiteral(" class=\"img-fluidx ps-3 pe-3\"");

WriteLiteral(" style=\"height:30px\"");

WriteLiteral(" src=\"Sticky/images/eDoctorGroupLight.png\"");

WriteLiteral("></i>\n            <a");

WriteLiteral(" href=\"hybrid:GotoHome\"");

WriteLiteral(" data-back-button");

WriteLiteral(" class=\"header-icon header-icon-1\"");

WriteLiteral("><i");

WriteAttribute ("class", " class=\"", "\""
, Tuple.Create<string,object,bool> ("", "fas", true)
, Tuple.Create<string,object,bool> (" ", "fa-arrow-", true)

#line 23 "Search.cshtml"
                                                                         , Tuple.Create<string,object,bool> ("", AppResources.dir3

#line default
#line hidden
, false)
);
WriteLiteral("></i></a>\n            ");

WriteLiteral("\n        </div>\n        <div");

WriteLiteral(" class=\"page-content header-clear-medium\"");

WriteLiteral(">\n            <div");

WriteLiteral(" class=\"card card-style\"");

WriteLiteral(">\n                <div");

WriteLiteral(" class=\"content my-0\"");

WriteLiteral(">\n                    <div");

WriteLiteral(" class=\"d-flex px-3 pb-0 notch-clear mt-4\"");

WriteLiteral(">\n                        <div");

WriteLiteral(" class=\"align-self-center\"");

WriteLiteral(">\n                            <h1");

WriteLiteral(" class=\"font-26 mb-n1\"");

WriteLiteral(">");


#line 31 "Search.cshtml"
                                                 Write(AppResources.FindADoctor);


#line default
#line hidden
WriteLiteral("</h1>\n                            <p");

WriteLiteral(" class=\"font-14 mb-0 opacity-70 fw-bold color-orange-light\"");

WriteLiteral(">");


#line 32 "Search.cshtml"
                                                                                     Write(AppResources.Alwayshereforyou);


#line default
#line hidden
WriteLiteral("</p>\n                        </div>\n                    </div>\n                  " +
"  <a");

WriteLiteral(" href=\"hybrid:GotoSearchSpecialty\"");

WriteLiteral(" onclick=\"LoaderShow();\"");

WriteLiteral(">\n                        <div");

WriteLiteral(" class=\"card card-style bg-highlight mt-4\"");

WriteLiteral(">\n                            <div");

WriteLiteral(" class=\"d-flex\"");

WriteLiteral(">\n                                <div");

WriteLiteral(" class=\"ps-2 ms-2 align-self-center\"");

WriteLiteral(">\n                                    <h1");

WriteLiteral(" class=\"pt-4 color-white\"");

WriteLiteral(">");


#line 39 "Search.cshtml"
                                                            Write(AppResources.FindBySpecialty);


#line default
#line hidden
WriteLiteral("</h1>\n                                    <p");

WriteLiteral(" class=\"font-14 color-white mt-n2 mb-4 opacity-70\"");

WriteLiteral(">");


#line 40 "Search.cshtml"
                                                                                    Write(AppResources.Findthenearestdoctorforyou);


#line default
#line hidden
WriteLiteral("</p>\n                                </div>\n                                <div");

WriteLiteral(" class=\"ms-auto me-3 align-self-center\"");

WriteLiteral(">\n                                    <i");

WriteLiteral(" class=\"fa fa-map-marker-alt color-white fa-2x mt-4 mb-4\"");

WriteLiteral("></i>\n                                </div>\n                            </div>\n " +
"                       </div>\n                    </a>\n                    <a");

WriteLiteral(" href=\"hybrid:GotoSearchName\"");

WriteLiteral(">\n                        <div");

WriteLiteral(" class=\"card card-style mt-4 bg-highlight\"");

WriteLiteral(">\n                            <div");

WriteLiteral(" class=\"d-flex\"");

WriteLiteral(">\n                                <div");

WriteLiteral(" class=\"ps-2 ms-2 align-self-center\"");

WriteLiteral(">\n                                    <h1");

WriteLiteral(" class=\"pt-4 color-white\"");

WriteLiteral(">");


#line 52 "Search.cshtml"
                                                            Write(AppResources.FindByName);


#line default
#line hidden
WriteLiteral("</h1>\n                                    <p");

WriteLiteral(" class=\"font-14 color-white mt-n2 mb-4 opacity-70\"");

WriteLiteral(">");


#line 53 "Search.cshtml"
                                                                                    Write(AppResources.Findthedocoryouarelookingfor);


#line default
#line hidden
WriteLiteral("</p>\n                                </div>\n                                <div");

WriteLiteral(" class=\"ms-auto me-3 align-self-center\"");

WriteLiteral(">\n                                    <i");

WriteLiteral(" class=\"fa fa-user-nurse color-white fa-2x mt-4 mb-4\"");

WriteLiteral("></i>\n                                </div>\n                            </div>\n " +
"                       </div>\n                    </a>\n                </div>\n  " +
"          </div>\n\n\n        </div>\n    </div>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/bootstrap.min.js\"");

WriteLiteral("></script>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/custom.js\"");

WriteLiteral("></script>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/EDS.js\"");

WriteLiteral("></script>\n\n</body>\n</html>");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class SearchBase
{

		// This field is OPTIONAL, but used by the default implementation of Generate, Write, WriteAttribute and WriteLiteral
		//
		System.IO.TextWriter __razor_writer;

		// This method is OPTIONAL
		//
		/// <summary>Executes the template and returns the output as a string.</summary>
		/// <returns>The template output.</returns>
		public string GenerateString ()
		{
			using (var sw = new System.IO.StringWriter ()) {
				Generate (sw);
				return sw.ToString ();
			}
		}

		// This method is OPTIONAL, you may choose to implement Write and WriteLiteral without use of __razor_writer
		// and provide another means of invoking Execute.
		//
		/// <summary>Executes the template, writing to the provided text writer.</summary>
		/// <param name="writer">The TextWriter to which to write the template output.</param>
		public void Generate (System.IO.TextWriter writer)
		{
			__razor_writer = writer;
			Execute ();
			__razor_writer = null;
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the template output without HTML escaping it.</summary>
		/// <param name="value">The literal value.</param>
		protected void WriteLiteral (string value)
		{
			__razor_writer.Write (value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the TextWriter without HTML escaping it.</summary>
		/// <param name="writer">The TextWriter to which to write the literal.</param>
		/// <param name="value">The literal value.</param>
		protected static void WriteLiteralTo (System.IO.TextWriter writer, string value)
		{
			writer.Write (value);
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a value to the template output, HTML escaping it if necessary.</summary>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected void Write (object value)
		{
			WriteTo (__razor_writer, value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes an object value to the TextWriter, HTML escaping it if necessary.</summary>
		/// <param name="writer">The TextWriter to which to write the value.</param>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected static void WriteTo (System.IO.TextWriter writer, object value)
		{
			if (value == null)
				return;

			var write = value as Action<System.IO.TextWriter>;
			if (write != null) {
				write (writer);
				return;
			}

			//NOTE: a more sophisticated implementation would write safe and pre-escaped values directly to the
			//instead of double-escaping. See System.Web.IHtmlString in ASP.NET 4.0 for an example of this.
			writer.Write(System.Net.WebUtility.HtmlEncode (value.ToString ()));
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to the template output.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		protected void WriteAttribute (string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			WriteAttributeTo (__razor_writer, name, prefix, suffix, values);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to a TextWriter.
		/// </summary>
		/// <param name="writer">The TextWriter to which to write the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		///<remarks>Used by Razor helpers to write attributes.</remarks>
		protected static void WriteAttributeTo (System.IO.TextWriter writer, string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			// this is based on System.Web.WebPages.WebPageExecutingBase
			// Copyright (c) Microsoft Open Technologies, Inc.
			// Licensed under the Apache License, Version 2.0
			if (values.Length == 0) {
				// Explicitly empty attribute, so write the prefix and suffix
				writer.Write (prefix);
				writer.Write (suffix);
				return;
			}

			bool first = true;
			bool wroteSomething = false;

			for (int i = 0; i < values.Length; i++) {
				Tuple<string,object,bool> attrVal = values [i];
				string attPrefix = attrVal.Item1;
				object value = attrVal.Item2;
				bool isLiteral = attrVal.Item3;

				if (value == null) {
					// Nothing to write
					continue;
				}

				// The special cases here are that the value we're writing might already be a string, or that the
				// value might be a bool. If the value is the bool 'true' we want to write the attribute name instead
				// of the string 'true'. If the value is the bool 'false' we don't want to write anything.
				//
				// Otherwise the value is another object (perhaps an IHtmlString), and we'll ask it to format itself.
				string stringValue;
				bool? boolValue = value as bool?;
				if (boolValue == true) {
					stringValue = name;
				} else if (boolValue == false) {
					continue;
				} else {
					stringValue = value as string;
				}

				if (first) {
					writer.Write (prefix);
					first = false;
				} else {
					writer.Write (attPrefix);
				}

				if (isLiteral) {
					writer.Write (stringValue ?? value);
				} else {
					WriteTo (writer, stringValue ?? value);
				}
				wroteSomething = true;
			}
			if (wroteSomething) {
				writer.Write (suffix);
			}
		}
		// This method is REQUIRED. The generated Razor subclass will override it with the generated code.
		//
		///<summary>Executes the template, writing output to the Write and WriteLiteral methods.</summary>.
		///<remarks>Not intended to be called directly. Call the Generate method instead.</remarks>
		public abstract void Execute ();

}
}
#pragma warning restore 1591
