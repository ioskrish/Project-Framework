using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectFrameworkCommonLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectFramework.Web.API
{
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        [Route("GetContactInfo")]
        [HttpGet]
        public ActionResult GetContactInfo()
        {
            try
            {
                AppContact Contact = new AppContact();
                Contact.Address = "Mumbai | Maharashtra | India";
                Contact.Site_URL = "https://www.google.com";
                Contact.Contact_No = "7900192017";
                return Ok(Contact); ;
            }
            catch (Exception Ex)
            {
                return NotFound(Ex.Message);
            }

        }
        [Route("GetContactInfoEx")]
        [HttpGet]
        public ActionResult GetContactInfoEx(string Key)
        {
            try
            {
                string Value = "Key Value";

                return Ok(Value);
            }
            catch (Exception Ex)
            {
                return NotFound(Ex.Message);
            }

        }
        [Route("UpdateContactInfo")]
        [HttpPost]
        public ActionResult UpdateContactInfo(AppSettings Settings)
        {
            try
            {
                return Ok("Settings Updated Successfully");
            }
            catch (Exception Ex)
            {
                return NotFound(Ex.Message);
            }

        }
    }
}
