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

namespace EDSDoctorsApp.HtmlViews2
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 1 "patients.cshtml"
using EDSDoctorsApp.Resources;

#line default
#line hidden

#line 2 "patients.cshtml"
using EDSDoctorsApp;

#line default
#line hidden

#line 3 "patients.cshtml"
using Xamarin.Essentials;

#line default
#line hidden

#line 4 "patients.cshtml"
using EDSDoctorsApp.Helper.EMR;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "17.1.0.269")]
public partial class patients : patientsBase
{

#line hidden

#line 5 "patients.cshtml"
public (List<PatientVM>,int,List<KeyValuePair<string,string>>,string) Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("<!DOCTYPE HTML>\r\n<html");

WriteLiteral(" lang=\"en\"");

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

WriteLiteral("\r\n          content=\"width=device-width, initial-scale=1, minimum-scale=1, maximu" +
"m-scale=1, viewport-fit=cover\"");

WriteLiteral(" />\r\n    <title>eDoctor - patients</title>\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute ("href", " href=\"", "\""

#line 16 "patients.cshtml"
          , Tuple.Create<string,object,bool> ("", string.Concat("Sticky53/styles/bootstrap",AppResources.dir2,".css")

#line default
#line hidden
, false)
);
WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"Sticky53/fonts/css.css?family=Roboto:300,300i,400,400i,500,500i,700,700i,9" +
"00,900i|Source+Sans+Pro:300,300i,400,400i,600,600i,700,700i,900,900i&display=swa" +
"p\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" href=\"Sticky53/fonts/css/fontawesome-all.min.css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"Sticky/scripts/jquery-ui.min.css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"plugins/DateRangePicker/jquery.comiseo.daterangepicker.css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"manifest\"");

WriteLiteral(" href=\"_manifest.json\"");

WriteLiteral(" data-pwa-version=\"set_in_manifest_and_pwa_js\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"180x180\"");

WriteLiteral(" href=\"app/icons/icon-192x192.png\"");

WriteLiteral(">\r\n</head>\r\n\r\n<body");

WriteLiteral(" class=\"theme-light\"");

WriteLiteral(" data-highlight=\"highlight-red\"");

WriteLiteral(" data-gradient=\"body-default\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"preloader\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"spinner-border color-highlight\"");

WriteLiteral(" role=\"status\"");

WriteLiteral("></div>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"page\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"header header-fixed header-logo-center\"");

WriteLiteral(">\r\n            <p");

WriteLiteral(" class=\"header-title\"");

WriteLiteral(">Patients</p>\r\n            <a");

WriteLiteral(" href=\"hybrid:goback\"");

WriteLiteral(" data-back-button");

WriteLiteral(" class=\"header-icon header-icon-1\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fas fa-arrow-left\"");

WriteLiteral("></i></a>\r\n            <a");

WriteLiteral(" href=\"hybrid:GotoHome\"");

WriteLiteral(" class=\"header-icon header-icon-4\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fas fa-home\"");

WriteLiteral("></i></a>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"page-content header-clear-large\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"card mt-n4\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n                    <!--  -->\r\n                    <div");

WriteLiteral(" class=\"search-box bg-white rounded-xl bottom-0\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"border-0\"");

WriteLiteral(" placeholder=\"Search here..\"");

WriteLiteral(" id=\"PatientSearch\"");

WriteAttribute ("onkeyup", " onkeyup=\"", "\""
, Tuple.Create<string,object,bool> ("", "Search(this,", true)

#line 42 "patients.cshtml"
                                                                                         , Tuple.Create<string,object,bool> ("", App.LoadMorePatientsRequest

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", ",", true)

#line 42 "patients.cshtml"
                                                                                                                      , Tuple.Create<string,object,bool> ("", App.TotalPages

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", ",\'", true)

#line 42 "patients.cshtml"
                                                                                                                                       , Tuple.Create<string,object,bool> ("", SecureStorage.GetAsync("userToken").Result

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "\',\'PatientsPage\')", true)
);
WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"clear-search disabled mt-0 me-5\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-times color-red-dark\"");

WriteLiteral("></i>\r\n                        </a>\r\n\r\n                        <a");

WriteLiteral(" data-menu=\"menu-sidebar-left-1\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-filter color-dark-light font-12\"");

WriteLiteral("></i>\r\n                        </a>\r\n\r\n                    </div>\r\n              " +
"  </div>\r\n            </div>\r\n            <!-- Tabs content Group -->\r\n         " +
"   <div");

WriteLiteral(" class=\"\"");

WriteLiteral(" id=\"\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n                    <!--  -->\r\n                    <div");

WriteLiteral(" class=\"search-results disabled-search-listXX\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"list-group list-custom-large\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"PatientsContent\"");

WriteLiteral(">\r\n                                <!--  -->\r\n");


#line 62 "patients.cshtml"
                                

#line default
#line hidden

#line 62 "patients.cshtml"
                                 foreach (var Patient in Model.Item1)
                                {


#line default
#line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\"card card-style overflow-visible mt-5\"");

WriteLiteral(" style=\"margin:0\"");

WriteLiteral(" data-filter-item");

WriteLiteral(" data-filter-name=\"all\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"d-flex\"");

WriteLiteral(">\r\n\r\n                                                <div");

WriteLiteral(" class=\" d-inline-block mb-n5 ms-auto mt-n5 overflow-hidden rounded-sm text-cente" +
"r under-slider-btn\"");

WriteLiteral(">\r\n                                                    <h1");

WriteAttribute ("class", " class=\"", "\""
, Tuple.Create<string,object,bool> ("", "align-items-center", true)
, Tuple.Create<string,object,bool> (" ", "bg-", true)

#line 69 "patients.cshtml"
                                               , Tuple.Create<string,object,bool> ("", Patient.PatientsGender == "Male" ? "blue" : "pink"

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "-dark", true)
, Tuple.Create<string,object,bool> (" ", "d-flex", true)
, Tuple.Create<string,object,bool> (" ", "flex-column", true)
, Tuple.Create<string,object,bool> (" ", "font-20", true)
, Tuple.Create<string,object,bool> (" ", "justify-content-center", true)
, Tuple.Create<string,object,bool> (" ", "mt-1", true)
, Tuple.Create<string,object,bool> (" ", "rounded-circle", true)
);
WriteLiteral("\r\n                                                    style=\"width: 80px;height: " +
"80px;\"");

WriteLiteral(">\r\n                                                        <span");

WriteLiteral(" class=\"mt-4 font-18\"");

WriteLiteral(">");


#line 71 "patients.cshtml"
                                                                              Write(Patient.PatientsGender);


#line default
#line hidden
WriteLiteral("</span>\r\n                                                        <i");

WriteLiteral(" class=\"fa fa-mars mt-n4\"");

WriteLiteral("></i>\r\n                                                    </h1>\r\n               " +
"                                 </div>\r\n                                       " +
"     </div>\r\n                                            <div");

WriteLiteral(" class=\"row mb-0 mt-5\"");

WriteLiteral(">\r\n\r\n                                                <div");

WriteLiteral(" class=\"col\"");

WriteLiteral(">\r\n                                                    <h6");

WriteLiteral(" class=\"color-gray-dark mb-n3\"");

WriteLiteral(">");


#line 79 "patients.cshtml"
                                                                                 Write(Patient.PatientsMRNo);


#line default
#line hidden
WriteLiteral("</h6>\r\n                                                    <h4");

WriteLiteral(" class=\"color-dark-light font-700 font-22 text-truncate mt-3\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                        ");


#line 81 "patients.cshtml"
                                                   Write(Patient.PatientsName);


#line default
#line hidden
WriteLiteral("\r\n                                                    </h4>\r\n\r\n                  " +
"                                  <div");

WriteLiteral(" class=\"mt-n4\"");

WriteLiteral(">\r\n                                                        <span");

WriteLiteral(" class=\"me-3\"");

WriteLiteral(">\r\n                                                            <i");

WriteLiteral(" class=\"fa fa-clock\"");

WriteLiteral("></i>\r\n                                                            <span>");


#line 87 "patients.cshtml"
                                                             Write(Patient.Created);


#line default
#line hidden
WriteLiteral("</span>\r\n                                                        </span>\r\n       " +
"                                             </div>\r\n                           " +
"                         <div");

WriteLiteral(" class=\"mt-n4\"");

WriteLiteral(">\r\n                                                        <span");

WriteLiteral(" class=\"me-3\"");

WriteLiteral(">\r\n                                                            <p>");


#line 92 "patients.cshtml"
                                                          Write(Patient.PatientsAge);


#line default
#line hidden
WriteLiteral("</p>\r\n                                                        </span>\r\n          " +
"                                          </div>\r\n                              " +
"                      <div");

WriteLiteral(" class=\"mt-n4\"");

WriteLiteral(">\r\n                                                        <span");

WriteLiteral(" class=\"me-3\"");

WriteLiteral(">\r\n                                                            <p>");


#line 97 "patients.cshtml"
                                                          Write(Patient.PatientsNationality);


#line default
#line hidden
WriteLiteral("</p>\r\n                                                        </span>\r\n          " +
"                                          </div>\r\n                              " +
"                  </div>\r\n                                                <div");

WriteLiteral(" class=\"col-12 px-3\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\"d-flex flex-row gap-1 justify-content-end\"");

WriteLiteral(">\r\n                                                        <a");

WriteAttribute ("href", " href=\"", "\""
, Tuple.Create<string,object,bool> ("", "hybrid:gotopatientsemr?PatientID=", true)

#line 103 "patients.cshtml"
                                                           , Tuple.Create<string,object,bool> ("", Patient.PatientsAccountsID

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "&PatientName=", true)

#line 103 "patients.cshtml"
                                                                                                   , Tuple.Create<string,object,bool> ("", Patient.PatientsName

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "&PatientMRno=", true)

#line 103 "patients.cshtml"
                                                                                                                                     , Tuple.Create<string,object,bool> ("", Patient.PatientsMRNo

#line default
#line hidden
, false)
);
WriteLiteral("\r\n                                                       class=\"btn rounded-m bg-" +
"dark-dark font-700 text-uppercase line-height-sm\"");

WriteLiteral(@">Details</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
");


#line 110 "patients.cshtml"
                                }


#line default
#line hidden
WriteLiteral("                            </div>\r\n");


#line 112 "patients.cshtml"
                            

#line default
#line hidden

#line 112 "patients.cshtml"
                             if (App.TotalPages > 1)
                            {


#line default
#line hidden
WriteLiteral("                                <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" class=\"w-100 btn rounded-m bg-highlight font-700 text-uppercase line-height-sm\"");

WriteLiteral(" id=\"PatientsShowMoreBtn\"");

WriteAttribute ("onclick", " onclick=\"", "\""
, Tuple.Create<string,object,bool> ("", "GetResources(", true)

#line 115 "patients.cshtml"
                                                                                                                               , Tuple.Create<string,object,bool> ("", App.LoadMorePatientsRequest

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", ",", true)

#line 115 "patients.cshtml"
                                                                                                                                                            , Tuple.Create<string,object,bool> ("", App.TotalPages

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", ",\'", true)

#line 115 "patients.cshtml"
                                                                                                                                                                             , Tuple.Create<string,object,bool> ("", SecureStorage.GetAsync("userToken").Result

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "\',\'PatientsPage\',GetSearchTerm())", true)
);
WriteLiteral(">");


#line 115 "patients.cshtml"
                                                                                                                                                                                                                                                                                             Write(AppResources.ShowMore);


#line default
#line hidden
WriteLiteral("</a>\r\n                                </div>\r\n");


#line 117 "patients.cshtml"
                            }


#line default
#line hidden
WriteLiteral("                        </div>\r\n\r\n                        <!-- btn Load more -->\r" +
"\n                        ");

WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" id=\"PatientNoSearch\"");

WriteAttribute ("class", " class=\"", "\""
, Tuple.Create<string,object,bool> ("", "search-no-results", true)
, Tuple.Create<string,object,bool> (" ", new Action<System.IO.TextWriter> (__razor_attribute_value_writer => {

#line 132 "patients.cshtml"
                                                                    if (App.TotalPages > 0)
                     {


#line default
#line hidden
WriteLiteralTo(__razor_attribute_value_writer, "                ");

WriteLiteralTo(__razor_attribute_value_writer, "disabled");

WriteLiteralTo(__razor_attribute_value_writer, "\r\n");


#line 135 "patients.cshtml"
}

#line default
#line hidden
}), false)
, Tuple.Create<string,object,bool> (" ", "mt-4", true)
);
WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"card card-style\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(@">
                            <h1>No Results</h1>
                            <p>
                                No Records Found.
                            </p>
                        </div>
                    </div>
                </div>
            </div>




        </div>

        <!-- SideBar -->
        <div");

WriteLiteral(" id=\"menu-sidebar-left-1\"");

WriteLiteral(" class=\"bg-white menu menu-box-left d-flex flex-column\"");

WriteLiteral(" data-menu-width=\"310\"");

WriteLiteral(">\r\n\r\n            <div");

WriteLiteral(" class=\"me-3 ms-3\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"text-uppercase font-900 font-11 color-orange-dark\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-sort px-2 mt-4 pb-3\"");

WriteLiteral("></i>Sort by\r\n                </span>\r\n                <div");

WriteLiteral(" class=\"list-group list-custom-small list-icon-0 mt-5\"");

WriteLiteral(">\r\n\r\n                    <div");

WriteLiteral(" class=\"input-style no-borders has-icon validate-field mb-4\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"dateform\"");

WriteLiteral(" class=\"color-highlight mt-n3\"");

WriteLiteral(">Filter By Date</label>\r\n                        <input");

WriteLiteral(" id=\"dateform\"");

WriteLiteral(" type=\"date\"");

WriteLiteral(" ");


#line 163 "patients.cshtml"
                                                          if(string.IsNullOrWhiteSpace(Model.Item4)){


#line default
#line hidden
WriteLiteral("                        ");

WriteLiteral("value=\"");


#line 164 "patients.cshtml"
                                Write(DateTime.Now.ToString("yyyy-MM-dd"));


#line default
#line hidden
WriteLiteral("\"");

WriteLiteral("\r\n");


#line 165 "patients.cshtml"
}else{


#line default
#line hidden
WriteLiteral("                        ");

WriteLiteral("value=\"");


#line 166 "patients.cshtml"
                                Write(Model.Item4);


#line default
#line hidden
WriteLiteral("\"");

WriteLiteral("\r\n");


#line 167 "patients.cshtml"
}

#line default
#line hidden
WriteLiteral(" style=\"background-color:white\" onchange=\"dosortpatients(this.value)\">\r\n         " +
"               <span");

WriteLiteral(" class=\"mt-n5\"");

WriteLiteral(" style=\"width:8.75px;height:60%;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-down\"");

WriteLiteral("></i></span>\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"input-style no-borders has-icon validate-field mb-4\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"color-highlight \"");

WriteLiteral(">Filter By Gender</label>\r\n                        <select");

WriteLiteral(" id=\"\"");

WriteLiteral(" class=\"mt-3\"");

WriteLiteral(" style=\"background-color:white;-webkit-appearance: none\"");

WriteLiteral(" onchange=\"this.options[this.selectedIndex].value && (window.location = \'hybrid:d" +
"osortpatients?sortby=Gender&sort=\' + this.options[this.selectedIndex].value);\"");

WriteLiteral(">\r\n                            <option");

WriteLiteral(" value=\"default\"");

WriteLiteral(" hidden selected>Filter By Gender</option>\r\n");


#line 175 "patients.cshtml"
                            

#line default
#line hidden

#line 175 "patients.cshtml"
                             foreach (var status in Model.Item3)
                            {


#line default
#line hidden
WriteLiteral("                                <option");

WriteAttribute ("value", " value=\"", "\""
, Tuple.Create<string,object,bool> ("", "in", true)
, Tuple.Create<string,object,bool> (" ", "(\'", true)

#line 177 "patients.cshtml"
             , Tuple.Create<string,object,bool> ("", status.Key

#line default
#line hidden
, false)
, Tuple.Create<string,object,bool> ("", "\')", true)
);
WriteLiteral(">");


#line 177 "patients.cshtml"
                                                              Write(status.Value);


#line default
#line hidden
WriteLiteral("</option>\r\n");


#line 178 "patients.cshtml"
                            }


#line default
#line hidden
WriteLiteral("                        </select>\r\n                        <span");

WriteLiteral(" class=\"mt-n4\"");

WriteLiteral(" style=\"width:8.75px;height:60%;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-down\"");

WriteLiteral("></i></span>\r\n                    </div>\r\n\r\n                </div>\r\n            <" +
"/div>\r\n            <!-- Other Opt Sort -->\r\n            ");

WriteLiteral("\r\n            <!-- Save Setting -->\r\n            <div");

WriteLiteral(" class=\"me-3 ms-3 mt-auto pt-n2\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"text-uppercase font-900 font-11 color-orange-dark opacity-90\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-wrench px-2 mt-4 pb-3\"");

WriteLiteral("></i>Search Setting\r\n                </span>\r\n                <div");

WriteLiteral(" class=\"list-group list-custom-small list-icon-0\"");

WriteLiteral(">\r\n\r\n                    <a");

WriteLiteral(" data-trigger-switch=\"sidebar-12-switch-2\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa font-14 fa-circle color-green-dark\"");

WriteLiteral("></i>\r\n                        <span>Save current filter</span>\r\n                " +
"        <div");

WriteLiteral(" class=\"custom-control scale-switch ios-switch\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"ios-input\"");

WriteLiteral(" id=\"sidebar-12-switch-2\"");

WriteLiteral(" checked>\r\n                            <label");

WriteLiteral(" class=\"custom-control-label\"");

WriteLiteral(" for=\"sidebar-12-switch-2\"");

WriteLiteral("></label>\r\n                        </div>\r\n                        <i");

WriteLiteral(" class=\"fa fa-angle-right\"");

WriteLiteral("></i>\r\n                    </a>\r\n\r\n                </div>\r\n            </div>\r\n  " +
"      </div>\r\n\r\n        <!--  -->\r\n\r\n\r\n    </div>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky53/scripts/bootstrap.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky53/scripts/custom.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/SearchResults.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/EDS.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/jquery-3.6.0.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/scripts/jquery-ui.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"Sticky/plugins/Moment/Moment.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"plugins/DateRangePicker/jquery.comiseo.daterangepicker.js\"");

WriteLiteral(@"></script>
    <script>
        function dosortpatients(sender)
        {
            if (sender)
            window.location = 'hybrid:dosortpatients?sortby=Created&sort=Between \'' + sender + '\' AND \'' + new Date((new Date(sender).setDate(new Date(sender).getDate() + 1))).toISOString() + '\''
            else
            window.location = ""hybrid:dosortpatients"";
        }
    </script>
    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        function GetSearchTerm(){\r\n            return document.getElementById(" +
"\'PatientSearch\').value;\r\n        }\r\n    </script>\r\n</body>\r\n");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class patientsBase
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