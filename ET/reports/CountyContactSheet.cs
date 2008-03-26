using System;
using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.reports {
    public class CountyContactSheet : BaseReport<IList<County>> {

        public CountyContactSheet(IList<TreeViewFilter> filters) : base("County Contact Listing", false, filters) {}

        protected override bool performGenerate(IList<County> entity) {
            header.Add(CenterText("COUNTY CONTACT LISTING"));
            header.Add("");

            foreach (County county in entity) {
                body.Add("<KEEP_TOGETHER>");
                body.Add(county.Name);

                foreach (CountyPhoneNumber phoneNumber in county.PhoneNumbers) {
                    body.Add("   " + phoneNumber.Type.Name + ": (" + phoneNumber.AreaCode + ")" + phoneNumber.PhoneNumber + ((phoneNumber.Extension != "" && phoneNumber.Extension != null) ? ("(" + phoneNumber.Extension + ")") : ""));
                }
                foreach (CountyWebsite website in county.Websites) {
                    body.Add("   " + website.URL);
                }
                foreach (CountyAttribute attribute in county.Attributes) {
                    body.Add("   " + attribute.Type.Name + ": " + attribute.Value);
                }
                body.Add("");
                body.Add("</KEEP_TOGETHER>");
            }

            footer.Add(DateTime.Now.ToString());

            return true;
        }
    }
}