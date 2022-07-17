using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProjectFramework.Web.Models
{
    public class ContactViewModel : ViewModelBase
    {
        private BLL.ContactBLL ContactBLLObj = new BLL.ContactBLL();
        public string EnableMobAuth { get; set; }
        public bool IsChecked { get; set; }
        public ContactViewModel()
        {
            LoadSettings();
        }
        private void LoadSettings()
        {
            EnableMobAuth = ContactBLLObj.GetValue("EnableMobAuth");
            if (EnableMobAuth.ToLower() == "true")
            {
                IsChecked = true;
            }
            else
            {
                IsChecked = false;
            }
        }
        public bool UpdateSettings()
        {
            try
            {
                ContactBLLObj.SetValue("Address", Address);
                ContactBLLObj.SetValue("Site_URL", Site_URL);
                ContactBLLObj.SetValue("Contact_No", Contact_No);
                ContactBLLObj.SetValue("EnableMobAuth", EnableMobAuth);
                LoadSettings();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
