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

#line 2 "Login.cshtml"
using EDSDoctorsApp.Resources;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "17.0.0.343")]
public partial class Login : LoginBase
{

#line hidden

#line 1 "Login.cshtml"
public List<EDSDoctorsApp.Models.LanguagesModel> Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("\r\n<!DOCTYPE HTML>\r\n<html");

WriteLiteral(" lang=\"en\"");

WriteAttribute ("dir", " dir=\"", "\""

#line 5 "Login.cshtml"
, Tuple.Create<string,object,bool> ("", AppResources.dir

#line default
#line hidden
, false)
);
WriteLiteral(">\r\n\r\n<head>\r\n    <meta");

WriteLiteral(" http-equiv=\"Content-Type\"");

WriteLiteral(" content=\"text/html; charset=utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"apple-mobile-web-app-capable\"");

WriteLiteral(" content=\"yes\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"apple-mobile-web-app-status-bar-style\"");

WriteLiteral(" content=\"black-translucent\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, " +
"viewport-fit=cover\"");

WriteLiteral(" />\r\n    <title>eDoctor Patient - Login</title>\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute ("href", " href=\"", "\""

#line 13 "Login.cshtml"
          , Tuple.Create<string,object,bool> ("", string.Concat("Sticky/styles/bootstrap",AppResources.dir2,".css")

#line default
#line hidden
, false)
);
WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"Sticky/fonts/css.css?family=Roboto:300,300i,400,400i,500,500i,700,700i,900" +
",900i|Source+Sans+Pro:300,300i,400,400i,600,600i,700,700i,900,900i&display=swap\"" +
"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" href=\"Sticky/fonts/css/fontawesome-all.min.css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"manifest\"");

WriteLiteral(" href=\"_manifest.json\"");

WriteLiteral(" data-pwa-version=\"set_in_manifest_and_pwa_js\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"180x180\"");

WriteLiteral(" href=\"Sticky/app/icons/icon-192x192.png\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"Sticky/styles/highlights/highlight_dark.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n</head>\r\n<body");

WriteLiteral(" class=\"theme-light\"");

WriteLiteral(" data-highlight=\"highlight-dark\"");

WriteLiteral(" data-gradient=\"body-default\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"page\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"page-content pb-0 mt-25\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"card\"");

WriteLiteral(" data-card-height=\"cover\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"page-content header-clear-small\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"mt-5 card-style\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"content mt-4 mb-0\"");

WriteLiteral(">\r\n                            <h1");

WriteLiteral(" class=\"text-center font-900 font-40 text-uppercase mb-0\"");

WriteLiteral(">");


#line 27 "Login.cshtml"
                                                                                    Write(AppResources.login);


#line default
#line hidden
WriteLiteral("</h1>\r\n                            <p");

WriteLiteral(" class=\"bottom-0 text-center color-orange-light mt-2 font-14\"");

WriteLiteral(">");


#line 28 "Login.cshtml"
                                                                                       Write(AppResources.Loginfordoctorsbookingandmedicalfilemanagement);


#line default
#line hidden
WriteLiteral("</p>\r\n                            <form");

WriteLiteral(" action=\"hybrid:DoLogin\"");

WriteLiteral(" id=\"loginForm\"");

WriteLiteral(" onsubmit=\"\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"input-style no-borders has-icon validate-field mb-4\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"fa fa-at\"");

WriteLiteral("></i>\r\n                                    <input");

WriteLiteral(" type=\"email\"");

WriteLiteral(" name=\"email\"");

WriteLiteral(" title=\"XYZ\"");

WriteLiteral(" class=\"form-control validate-name font-14 \"");

WriteLiteral(" id=\"email\"");

WriteAttribute ("placeholder", " placeholder=\"", "\""

#line 32 "Login.cshtml"
                                                                                                              , Tuple.Create<string,object,bool> ("", AppResources.Email

#line default
#line hidden
, false)
);
WriteLiteral(" required");

WriteAttribute ("oninvalid", " oninvalid=\"", "\""
, Tuple.Create<string,object,bool> ("", "if", true)
, Tuple.Create<string,object,bool> (" ", "(this.validity.typeMismatch){this.setCustomValidity(\'", true)

#line 32 "Login.cshtml"
                                                                                                                                                                                                               , Tuple.Create<string,object,bool> ("", AppResources.validateEmail

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "\')};this.setCustomValidity(\'", true)

#line 32 "Login.cshtml"
                                                                                                                                                                                                                                                                      , Tuple.Create<string,object,bool> ("", AppResources.validateEmail

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "\')", true)
);
WriteLiteral(" oninput=\"this.setCustomValidity(\'\')\"");

WriteLiteral(" />\r\n                                    <label");

WriteLiteral(" for=\"email\"");

WriteLiteral(" class=\"color-highlight fw-bold font-14\"");

WriteLiteral(">");


#line 33 "Login.cshtml"
                                                                                          Write(AppResources.Email);


#line default
#line hidden
WriteLiteral("</label>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-times disabled invalid color-red-dark\"");

WriteLiteral("></i>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-check disabled valid color-green-dark\"");

WriteLiteral("></i>\r\n                                    <em>");


#line 36 "Login.cshtml"
                                   Write(AppResources.required);


#line default
#line hidden
WriteLiteral("</em>\r\n                                </div>\r\n                                <d" +
"iv");

WriteLiteral(" class=\"input-style no-borders has-icon validate-field mb-4\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"fa fa-lock\"");

WriteLiteral("></i>\r\n                                    <input");

WriteLiteral(" type=\"password\"");

WriteLiteral(" pattern=\"[A-Za-z0-9]{2}[A-Za-z0-9]*[ ]?[A-Za-z0-9]*\"");

WriteLiteral(" class=\"form-control validate-password font-14 \"");

WriteLiteral(" name=\"password\"");

WriteLiteral(" id=\"password\"");

WriteAttribute ("placeholder", " placeholder=\"", "\""

#line 40 "Login.cshtml"
                                                                                                                                                                    , Tuple.Create<string,object,bool> ("", AppResources.Password

#line default
#line hidden
, false)
);
WriteLiteral(" required");

WriteAttribute ("oninvalid", " oninvalid=\"", "\""
, Tuple.Create<string,object,bool> ("", "this.setCustomValidity(\'", true)

#line 40 "Login.cshtml"
                                                                                                                                                                                                                                        , Tuple.Create<string,object,bool> ("", AppResources.validatePassword

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "\')", true)
);
WriteLiteral(" oninput=\"this.setCustomValidity(\'\')\"");

WriteLiteral(" />\r\n                                    <label");

WriteLiteral(" for=\"password\"");

WriteLiteral(" class=\"color-highlight fw-bold font-14\"");

WriteLiteral(">");


#line 41 "Login.cshtml"
                                                                                             Write(AppResources.Password);


#line default
#line hidden
WriteLiteral("</label>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-times disabled invalid color-red-dark\"");

WriteLiteral("></i>\r\n                                    <i");

WriteLiteral(" class=\"fa fa-check disabled valid color-green-dark\"");

WriteLiteral("></i>\r\n                                    <em>");


#line 44 "Login.cshtml"
                                   Write(AppResources.required);


#line default
#line hidden
WriteLiteral("</em>\r\n                                </div>\r\n\r\n                                " +
"<button");

WriteLiteral(" id=\"submit-button\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" data-back-buttonx");

WriteLiteral(" class=\"btn btn-m btn-full mt-4 rounded-l shadow-xl bg-highlight text-uppercase\"");

WriteLiteral(">");


#line 47 "Login.cshtml"
                                                                                                                                                                      Write(AppResources.login);


#line default
#line hidden
WriteLiteral("</button>\r\n                            </form>\r\n                            <div");

WriteLiteral(" class=\"divider mt-4 mb-3\"");

WriteLiteral("></div>\r\n                            <div");

WriteLiteral(" class=\"d-flex\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"w-50 font-14 pb-2 pb-3 text-start\"");

WriteLiteral("><a");

WriteLiteral(" href=\"hybrid:GotoRegistration\"");

WriteLiteral(" class=\"color-orange-light CreateAccount\"");

WriteLiteral(">");


#line 51 "Login.cshtml"
                                                                                                                                                     Write(AppResources.CreateAccount);


#line default
#line hidden
WriteLiteral("</a></div>\r\n                                <div");

WriteLiteral(" class=\"w-50 font-14 pb-2 pb-3 text-end\"");

WriteLiteral("><a");

WriteLiteral(" onclick=\"ForgetPassword(this)\"");

WriteLiteral(" class=\"color-orange-light\"");

WriteLiteral(">");


#line 52 "Login.cshtml"
                                                                                                                                     Write(AppResources.ForgotCredentials);


#line default
#line hidden
WriteLiteral("</a></div>\r\n                            </div>\r\n                        </div>\r\n " +
"                   </div>\r\n                </div>\r\n            </div>\r\n        <" +
"/div>\r\n\r\n\r\n        <div");

WriteLiteral(" id=\"toast-main\"");

WriteLiteral(" class=\"toast toast-tiny toast-container toast-bottom bg-orange-light\"");

WriteLiteral(" data-bs-delay=\"2000\"");

WriteLiteral(" data-autohide=\"true\"");

WriteLiteral(">\r\n            ");

WriteLiteral("\r\n            <i");

WriteLiteral(" class=\"toast-message\"");

WriteLiteral("></i>\r\n        </div>\r\n    </div>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/jquery-3.6.0.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/bootstrap.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/custom.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/EDS.js\"");

WriteLiteral("></script>\r\n\r\n    <script>\r\n        function ForgetPassword(sender) {\r\n          " +
"          $(sender).attr(\"href\", \"hybrid:GotoForgotPassword?email=\" + $(\'#email\'" +
").val());\r\n                }</script>\r\n</body>\r\n</html>");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class LoginBase
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
