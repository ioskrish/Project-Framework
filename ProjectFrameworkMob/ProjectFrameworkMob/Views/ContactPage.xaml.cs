using ProjectFrameworkCommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectFrameworkMob.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage(string Message = "")
        {
            InitializeComponent();
            FillSettings();
        }
        private void FillSettings()
        {
            lblAddress.Text = App.SettingsManagerObj.Contact.Address;
            lblSiteURL.Text = App.SettingsManagerObj.Contact.Site_URL;
            lblContactNo.Text = App.SettingsManagerObj.Contact.Contact_No;

        }
        private async void GetSettings_Clicked(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Getting Settings from Server..";

                AppContact Contact = await App.ApiServiceObj.GetContactInfo();

                lblAddress.Text = Contact.Address;
                lblSiteURL.Text = Contact.Site_URL;
                lblContactNo.Text = Contact.Contact_No;

                lblStatus.Text = "Success..";

            }
            catch (Exception Ex)
            {
                lblStatus.Text = "Failed..| " + Ex.Message;
            }

        }

        private async void UpdateSettings_Clicked(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Updating Settings to Server..";

                App.SettingsManagerObj.Contact.Address = lblAddress.Text;
                App.SettingsManagerObj.Contact.Site_URL = lblSiteURL.Text;
                App.SettingsManagerObj.Contact.Contact_No = lblContactNo.Text;

                bool bResult = await App.ApiServiceObj.UpdateContactInfo(App.SettingsManagerObj.Contact);

                if (bResult)
                {
                    App.SettingsManagerObj.SaveSettings();
                    lblStatus.Text = "Success..";
                }
                else
                {
                    lblStatus.Text = "Failed to Update..";
                }


            }
            catch (Exception Ex)
            {
                lblStatus.Text = "Failed..| " + Ex.Message;
            }


        }
        private async void Logout_Clicked(object sender, EventArgs e)
        {
            lblStatus.Text = "Logout from Application ...";

            App.SettingsManagerObj.UserID = -1;
            App.SettingsManagerObj.AuthenticationToken = "";
            App.SettingsManagerObj.EMail = "";
            App.SettingsManagerObj.SaveSettings();

            await Task.Delay(500);

            ((App)(App.Current)).RelaunchLoginForm();

        }
    }
}