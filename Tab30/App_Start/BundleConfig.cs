﻿using System.Web;
using System.Web.Optimization;

namespace Tab30
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
            "~/Scripts/DataTables/jquery.dataTables.js",
            "~/Scripts/DataTables/dataTables.bootstrap4.js",
            "~/Scripts/DataTables/dataTables.buttons.js",
            "~/Scripts/DataTables/buttons.html5.js",
            "~/Scripts/DataTables/JSZip/jszip.js",
            "~/Scripts/DataTables/pdfmake/pdfmake.js",
            "~/Scripts/DataTables/pdfmake/vfs_fonts.js",
            "~/Scripts/DataTables/buttons.bootstrap4.js",
            "~/Scripts/DataTables/Select/appjs/dataTables.select.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                "~/Scripts/select2.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/appcss").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/appcss").Include(
                      "~/Content/bootstrap-spacelab.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/DataTables/css/buttons.bootstrap4.css",
                      "~/Content/DataTables/Select/appcss/select.dataTables.css",
                      "~/Content/DataTables/Select/appcss/select.bootstrap4.css",
                      "~/Content/cssselect/select2.css",
                      "~/Content/site.css"));
        }
    }
}
