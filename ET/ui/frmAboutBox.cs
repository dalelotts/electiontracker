using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

<<<<<<< .mine
namespace edu.uwec.cs.cs355.group4.et.ui {
    internal sealed partial class AboutBox : Form {
        public AboutBox() {
=======
namespace edu.uwec.cs.cs355.group4.et.ui
{
    sealed partial class AboutBox : Form
    {
        public AboutBox()
        {
>>>>>>> .r61
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            Text = String.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

<<<<<<< .mine
        public static string AssemblyTitle {
            get {
=======
        public string AssemblyTitle
        {
            get
            {
>>>>>>> .r61
                // Get all Title attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

<<<<<<< .mine
        public static string AssemblyVersion {
=======
        public string AssemblyVersion
        {
>>>>>>> .r61
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

<<<<<<< .mine
        public static string AssemblyDescription {
            get {
=======
        public string AssemblyDescription
        {
            get
            {
>>>>>>> .r61
                // Get all Description attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

<<<<<<< .mine
        public static string AssemblyProduct {
            get {
=======
        public string AssemblyProduct
        {
            get
            {
>>>>>>> .r61
                // Get all Product attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

<<<<<<< .mine
        public static string AssemblyCopyright {
            get {
=======
        public string AssemblyCopyright
        {
            get
            {
>>>>>>> .r61
                // Get all Copyright attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

<<<<<<< .mine
        public static string AssemblyCompany {
            get {
=======
        public string AssemblyCompany
        {
            get
            {
>>>>>>> .r61
                // Get all Company attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private void okButton_Click(object sender, EventArgs e) {
            try
            {
                Dispose();
            }
            catch (Exception ex)
            {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex.ToString());
            }
        }
    }
}