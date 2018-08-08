using EvolentTest.Models;
using EvolentTest.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvolentTest.Controllers
{
    public class ContactController : Controller
    {
        ContactBl contactBl = new ContactBl();
        /// <summary>
        /// It will fetch all the Contact information
        /// </summary>
        /// <returns></returns>
        // GET: Contact
        public ActionResult Index()
        {
            try
            {
                List<Contact> contactList = new List<Contact>();
                contactList = contactBl.GetContactList();
                if (contactList.Count > 0)
                {
                    return View("Index", contactList);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

                return Content(ex.Message.ToString());
            }

        }

        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Contact contactInformation = new Contact();
            contactInformation = contactBl.GetContactInformation(id);
            return View("Details",contactInformation);
        }

        public ActionResult Delete(int id)
        {

            contactBl.DeleteContactInformation(id);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Function will save the Contact Information
        /// </summary>
        /// <param name="modelContact">passing the complete model</param>
        /// <returns></returns>
        public ActionResult SaveContactDetails(Contact modelContact)
        {
            try
            {

          
            
            if (ModelState.IsValid)
            {
                contactBl.SaveContactDetails(modelContact);
                ViewBag.Message = "Record Save Successfully";
                 return RedirectToAction("Index");
            }
            else
            {
                return View("Details");
            }

            }
            catch (Exception ex)
            {

                return Content(ex.Message.ToString());
            }
        }
    }
}