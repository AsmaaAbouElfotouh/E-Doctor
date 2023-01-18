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

#line 1 "SearchPatients.cshtml"
using EDSDoctorsApp.Resources;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "17.0.0.343")]
public partial class SearchPatients : SearchPatientsBase
{

#line hidden

#line 2 "SearchPatients.cshtml"
public EDSDoctorsApp.ViewModels.VMDoctors Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("<!DOCTYPE HTML>\n<html");

WriteLiteral(" lang=\"en\"");

WriteAttribute ("dir", " dir=\"", "\""

#line 5 "SearchPatients.cshtml"
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

WriteLiteral(" />\n    <title>eDoctor Patient - Search Results</title>\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute ("href", " href=\"", "\""

#line 12 "SearchPatients.cshtml"
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

WriteLiteral(" data-href=\"hybrid:");


#line 23 "SearchPatients.cshtml"
                            Write(Model.Search.LastView);


#line default
#line hidden
WriteLiteral("\"");

WriteLiteral(" data-back-button");

WriteLiteral(" class=\"header-icon header-icon-1 btnback\"");

WriteLiteral("><i");

WriteAttribute ("class", " class=\"", "\""
, Tuple.Create<string,object,bool> ("", "fas", true)
, Tuple.Create<string,object,bool> (" ", "fa-arrow-", true)

#line 23 "SearchPatients.cshtml"
                                                                                                    , Tuple.Create<string,object,bool> ("", AppResources.dir3

#line default
#line hidden
, false)
);
WriteLiteral("></i></a>\n            <a");

WriteLiteral(" href=\"hybrid:GotoHome\"");

WriteLiteral(" class=\"header-icon header-icon-4\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fas fa-home\"");

WriteLiteral("></i></a>\n\n        </div>\n        <div");

WriteLiteral(" class=\"page-content header-clear-medium mt-n4x \"");

WriteLiteral(">\n            <div");

WriteLiteral(" class=\"disabled\"");

WriteLiteral(">\n                <span");

WriteLiteral(" class=\"txtSpeciality\"");

WriteLiteral(">");


#line 29 "SearchPatients.cshtml"
                                       Write(Model.Search.Speciality);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtCountry\"");

WriteLiteral(">");


#line 30 "SearchPatients.cshtml"
                                    Write(Model.Search.Country);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtCity\"");

WriteLiteral(">");


#line 31 "SearchPatients.cshtml"
                                 Write(Model.Search.City);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtDistrict\"");

WriteLiteral(">");


#line 32 "SearchPatients.cshtml"
                                     Write(Model.Search.District);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtLang\"");

WriteLiteral(">");


#line 33 "SearchPatients.cshtml"
                                 Write(Model.Search.Lang);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtPage\"");

WriteLiteral(">");


#line 34 "SearchPatients.cshtml"
                                 Write(Model.Search.Page);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtSort\"");

WriteLiteral(">");


#line 35 "SearchPatients.cshtml"
                                 Write(Model.Search.Sort);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtCareerLvl\"");

WriteLiteral(">");


#line 36 "SearchPatients.cshtml"
                                      Write(Model.Search.CareerLevel);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtGender\"");

WriteLiteral(">");


#line 37 "SearchPatients.cshtml"
                                   Write(Model.Search.Gender);


#line default
#line hidden
WriteLiteral("</span>\n                <span");

WriteLiteral(" class=\"txtPGUID\"");

WriteLiteral(">");


#line 38 "SearchPatients.cshtml"
                                  Write(Model.Search.PGUID);


#line default
#line hidden
WriteLiteral("</span>\n            </div>\n            ");

WriteLiteral("\n            <div");

WriteLiteral(" class=\"card-style search-box search-header bg-theme me-3 ms-3\"");

WriteLiteral(">\n                <i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"search\"");

WriteAttribute ("value", " value=\"", "\""

#line 43 "SearchPatients.cshtml"
               , Tuple.Create<string,object,bool> ("", Model.Search.DoctorName

#line default
#line hidden
, false)
);
WriteLiteral(" class=\"search-box border-0 inpSearch font-14 SearchTxt\"");

WriteLiteral(" data-placeholder=\"");


#line 43 "SearchPatients.cshtml"
                                                                                                                                                     Write(AppResources.Search);


#line default
#line hidden
WriteLiteral("\"");

WriteLiteral(" data-search");

WriteLiteral(" onkeyup=\"Search(this)\"");

WriteLiteral(" data-value=\"");


#line 43 "SearchPatients.cshtml"
                                                                                                                                                                                                                          Write(Model.Search.DoctorName);


#line default
#line hidden
WriteLiteral("\"");

WriteLiteral(">\n                <a");

WriteLiteral(" data-menu=\"menu-sidebar-left-filter\"");

WriteLiteral(" class=\"color-highlight\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa-filter fas\"");

WriteLiteral("></i></a>\n            </div>\n\n");


#line 47 "SearchPatients.cshtml"
            

#line default
#line hidden

#line 47 "SearchPatients.cshtml"
             if (Model.Doctors.Count() != 0)
            {


#line default
#line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"DoctorsContent\"");

WriteLiteral(">\n");


#line 50 "SearchPatients.cshtml"
                    

#line default
#line hidden

#line 50 "SearchPatients.cshtml"
                     foreach (var Doctor in Model.Doctors)
                    {


#line default
#line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"content visitcards\"");

WriteLiteral(">\n                            <div");

WriteLiteral(" class=\"bg-theme rounded-sm mb-n5 ms-3 overflow-hidden under-slider-btn d-inline-" +
"block shadow-l text-center\"");

WriteLiteral(">\n                                <span");

WriteLiteral(" class=\"bg-orange-light font-10 d-block mb-2 px-3 line-height-xs py-1\"");

WriteLiteral(">");


#line 54 "SearchPatients.cshtml"
                                                                                                       Write(Doctor.NextAvailable.ToString("MMM"));


#line default
#line hidden
WriteLiteral("</span>\n                                <span");

WriteLiteral(" class=\"font-20 font-800 d-block mb-n3 line-height-s\"");

WriteLiteral(">");


#line 55 "SearchPatients.cshtml"
                                                                                      Write(Doctor.NextAvailable.ToString("dd"));


#line default
#line hidden
WriteLiteral("</span><br />\n                            </div>\n\n                            <di" +
"v");

WriteLiteral(" class=\"float-end mt-1 mb-n5 me-3 overflow-hidden under-slider-btn d-inline-block" +
" text-center\"");

WriteLiteral(">\n");


#line 59 "SearchPatients.cshtml"
                                

#line default
#line hidden

#line 59 "SearchPatients.cshtml"
                                 if (string.IsNullOrWhiteSpace(Doctor.UsersImageMIME))
                                {
                                    if (Doctor.ResourcesGender == "Male")
                                    {


#line default
#line hidden
WriteLiteral("                                        <img");

WriteLiteral(" src=\"Sticky/images/avatars/2s.png\"");

WriteLiteral(" style=\"width: 56px;height: 56px;\"");

WriteLiteral(" class=\"bg-highlight rounded-xl border-s border-highlight\"");

WriteLiteral(" data-src=\"\"");

WriteLiteral(">\n");


#line 64 "SearchPatients.cshtml"
                                    }
                                    else
                                    {


#line default
#line hidden
WriteLiteral("                                        <img");

WriteLiteral(" src=\"Sticky/images/avatars/10s.png\"");

WriteLiteral(" style=\"width:56px;height:56px;\"");

WriteLiteral(" class=\"bg-highlight rounded-xl border-s border-highlight\"");

WriteLiteral(" data-src=\"\"");

WriteLiteral(">\n");


#line 68 "SearchPatients.cshtml"

                                    }
                                }
                                else
                                {


#line default
#line hidden
WriteLiteral("                                    <img");

WriteLiteral(" src=\"\"");

WriteLiteral(" style=\"width:56px;height:56px;\"");

WriteLiteral(" class=\"bg-highlight rounded-xl Rimg border-s border-highlight\"");

WriteLiteral(" data-src=\"");


#line 73 "SearchPatients.cshtml"
                                                                                                                                                    Write(Doctor.UsersImage);


#line default
#line hidden
WriteLiteral("\"");

WriteLiteral(">\n");


#line 74 "SearchPatients.cshtml"
                                }


#line default
#line hidden
WriteLiteral("\n                            </div>\n\n                            <div");

WriteLiteral(" class=\"card card-style mx-0 mb-3\"");

WriteLiteral(" data-card-heightx=\"175\"");

WriteLiteral(">\n                                <div");

WriteLiteral(" class=\"card-bottomx mt-4 p-3\"");

WriteLiteral(">\n                                    <span");

WriteLiteral(" class=\"d-block mt-2 lh-sm color-black font-900 font-18\"");

WriteLiteral(">");


#line 80 "SearchPatients.cshtml"
                                                                                             Write(Doctor.ResourcesName);


#line default
#line hidden
WriteLiteral("</span>\n                                    <span");

WriteLiteral(" class=\"d-block lh-sm color-black font-600 font-14\"");

WriteLiteral(">");


#line 81 "SearchPatients.cshtml"
                                                                                        Write(Doctor.SpecialtiesName);


#line default
#line hidden
WriteLiteral("</span>\n                                    <span");

WriteLiteral(" class=\"d-block lh-sm color-black font-14\"");

WriteLiteral(">");


#line 82 "SearchPatients.cshtml"
                                                                               Write(Doctor.CareerLevelsName);


#line default
#line hidden
WriteLiteral("</span>\n                                    <span");

WriteLiteral(" class=\"d-block font-13 mb-n1\"");

WriteLiteral(">\n                                        <i");

WriteLiteral(" class=\"fa fa-map-marker pe-2\"");

WriteLiteral("></i>\n");

WriteLiteral("                                        ");


#line 85 "SearchPatients.cshtml"
                                   Write(Doctor.Address);


#line default
#line hidden
WriteLiteral("\n                                    </span>\n                                    " +
"<div");

WriteLiteral(" class=\"row mt-1 mb-1\"");

WriteLiteral(">\n                                        <div");

WriteLiteral(" class=\"col-12\"");

WriteLiteral(">\n                                            <a");

WriteLiteral(" href=\"\"");

WriteLiteral(" class=\"btn btn-s bg-orange-light btn-full rounded-sm text-uppercase font-800 rou" +
"nded-l font-14\"");

WriteLiteral(" data-SchedualData=\"hybrid:DoBookNearestSearchResults?RGUID=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                             Write(Doctor.ResourcesGUID);


#line default
#line hidden
WriteLiteral("&LGUID=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                         Write(Doctor.LocationsGUID);


#line default
#line hidden
WriteLiteral("&SID=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                   Write(Doctor.SchedulesID);


#line default
#line hidden
WriteLiteral("&DoctorName=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                  Write(Doctor.ResourcesName);


#line default
#line hidden
WriteLiteral("&Speciality=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                                                   Write(Doctor.SpecialtiesName);


#line default
#line hidden
WriteLiteral("&Career=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                                                                                  Write(Doctor.CareerLevelsName);


#line default
#line hidden
WriteLiteral("&Address=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                   Write(Doctor.Address);


#line default
#line hidden
WriteLiteral("&Start=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                         Write(Doctor.NextAvailable);


#line default
#line hidden
WriteLiteral("&End=");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                   Write(Doctor.End);


#line default
#line hidden
WriteLiteral("\"");

WriteLiteral(" onclick=\"BookNearest(this)\"");

WriteLiteral(">");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            Write(AppResources.BookNow);


#line default
#line hidden
WriteLiteral(" ");


#line 89 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  Write(Doctor.NextAvailable.ToString("dddd dd/MM/yyyy hh:mm tt"));


#line default
#line hidden
WriteLiteral("</a>\n                                        </div>\n                             " +
"       </div>\n                                    <div");

WriteLiteral(" class=\"row mt-1 mb-1\"");

WriteLiteral(">\n                                        <div");

WriteLiteral(" class=\"col-12\"");

WriteLiteral(">\n                                            <a");

WriteLiteral(" href=\"\"");

WriteLiteral(" class=\"btn btn-s btn-border border-highlight color-highlight btn-full rounded-sm" +
" text-uppercase font-800 rounded-l font-14\"");

WriteLiteral(" data-link=\"hybrid:GotoDoctorDetailsSearchResults?RGUID=");


#line 94 "SearchPatients.cshtml"
                                                                                                                                                                                                                                     Write(Doctor.ResourcesGUID);


#line default
#line hidden
WriteLiteral("&LGUID=");


#line 94 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                 Write(Doctor.LocationsGUID);


#line default
#line hidden
WriteLiteral("&IsFav=");


#line 94 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                             Write(Doctor.AddStatus);


#line default
#line hidden
WriteLiteral("\"");

WriteLiteral(" onclick=\"MoreInfo(this)\"");

WriteLiteral(">");


#line 94 "SearchPatients.cshtml"
                                                                                                                                                                                                                                                                                                                                         Write(AppResources.MoreInfo);


#line default
#line hidden
WriteLiteral("</a>\n                                        </div>\n\n                            " +
"        </div>\n                                </div>\n\n                         " +
"   </div>\n                        </div>\n");


#line 102 "SearchPatients.cshtml"
                    }


#line default
#line hidden
WriteLiteral("                </div>\n");


#line 104 "SearchPatients.cshtml"
                if (Model.Doctors.Count() >= 10)
                {


#line default
#line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\n                        <a");

WriteLiteral(" class=\"btn btn-s bg-highlight btn-full rounded-sm text-uppercase font-800 rounde" +
"d-l font-14 ShowMoreBtn\"");

WriteLiteral(" onclick=\"ShowMore()\"");

WriteLiteral(">");


#line 107 "SearchPatients.cshtml"
                                                                                                                                                    Write(AppResources.ShowMore);


#line default
#line hidden
WriteLiteral("</a>\n                    </div>\n");


#line 109 "SearchPatients.cshtml"
                }
            }


#line default
#line hidden
WriteLiteral("        </div>\n        <div");

WriteLiteral(" id=\"menu-sidebar-left-filter\"");

WriteLiteral(" class=\"bg-white menu menu-box-left\"");

WriteLiteral(" data-menu-width=\"250\"");

WriteLiteral(">\n            <div");

WriteLiteral(" class=\"me-3 ms-3 mt-4\"");

WriteLiteral(">\n                <span");

WriteLiteral(" class=\"text-uppercase font-900 font-11 color-orange-light\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-calendar pe-2\"");

WriteLiteral("></i>");


#line 114 "SearchPatients.cshtml"
                                                                                                               Write(AppResources.VisitDate);


#line default
#line hidden
WriteLiteral("</span>\n                <div");

WriteLiteral(" class=\"input-style input-style-active has-borders has-icon mb-4\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"date\"");

WriteLiteral(" style=\"background-color:white;-webkit-appearance: none;\"");

WriteLiteral(" id=\"VisitDateID\"");

WriteLiteral(" name=\"VisitDate\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" for=\"PatientsDOB\"");

WriteLiteral(" class=\"color-highlight font-14 mt-1\"");

WriteLiteral(">");


#line 117 "SearchPatients.cshtml"
                                                                                     Write(AppResources.Dateofbirth);


#line default
#line hidden
WriteLiteral("</label>\r\n                            <i");

WriteLiteral(" class=\"fa fa-times disabled invalid color-red-dark\"");

WriteLiteral("></i>\r\n                            <i");

WriteLiteral(" class=\"fa fa-check disabled valid color-green-dark\"");

WriteLiteral("></i>\r\n                            \r\n                        </div>\n             " +
"   <span");

WriteLiteral(" class=\"text-uppercase font-900 font-11 color-orange-light\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-transgender pe-2\"");

WriteLiteral("></i>");


#line 122 "SearchPatients.cshtml"
                                                                                                                  Write(AppResources.Gender);


#line default
#line hidden
WriteLiteral("</span>\n                <div");

WriteLiteral(" class=\"input-style has-borders no-icon mb-4\"");

WriteLiteral(">\n                    <label");

WriteLiteral(" for=\"form5\"");

WriteLiteral(" class=\"color-highlight\"");

WriteLiteral(">Select A Value</label>\n                    <select");

WriteLiteral(" id=\"form5\"");

WriteLiteral(" onchange=\"hybrid:DoSort?field=Date\"");

WriteLiteral(" name=\"LocationList\"");

WriteLiteral(" id=\"LocationListID\"");

WriteLiteral(" style=\"background-color:white;-webkit-appearance: none;\"");

WriteLiteral(">\n                        <option");

WriteLiteral(" value=\"default\"");

WriteLiteral(" disabled=\"\"");

WriteLiteral(" selected=\"\"");

WriteLiteral(">");


#line 126 "SearchPatients.cshtml"
                                                                   Write(AppResources.Gender);


#line default
#line hidden
WriteLiteral("</option>\n                        <option");

WriteLiteral(" value=\"Option 1\"");

WriteLiteral(">Male</option>\n                        <option");

WriteLiteral(" value=\"Option 2\"");

WriteLiteral(">Female</option>\n                    </select>\n                    <span><i");

WriteLiteral(" class=\"fa fa-chevron-down\"");

WriteLiteral("></i></span>\n                    <i");

WriteLiteral(" class=\"fa fa-check disabled valid color-green-dark\"");

WriteLiteral("></i>\n                    <i");

WriteLiteral(" class=\"fa fa-check disabled invalid color-red-dark\"");

WriteLiteral("></i>\n                    <em></em>\n                </div>\n            </div>\n   " +
"     </div>\n\n    </div>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/jquery-3.6.0.min.js\"");

WriteLiteral("></script>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/bootstrap.min.js\"");

WriteLiteral("></script>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/custom.js\"");

WriteLiteral("></script>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/plugins/Moment/moment-with-locales.min.js\"");

WriteLiteral("></script>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/EDS.js\"");

WriteLiteral("></script>\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/SearchResults.js\"");

WriteLiteral("></script>\n    <script>\n        var MoreInfoo=\"");


#line 146 "SearchPatients.cshtml"
                  Write(AppResources.MoreInfo);


#line default
#line hidden
WriteLiteral("\";\n        var BookNow=\"");


#line 147 "SearchPatients.cshtml"
                Write(AppResources.BookNow);


#line default
#line hidden
WriteLiteral("\";\n    </script>\n</body>\n</html>");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class SearchPatientsBase
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