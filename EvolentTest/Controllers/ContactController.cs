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
        /// <summary>
        /// return the details view
        /// </summary>
        /// <returns></returns>
        public ActionResult Details()
        {
            return View();
        }
        /// <summary>
        /// Edit the particular contact information
        /// </summary>
        /// <param name="id"> contact unique id</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            try
            {
                Contact contactInformation = new Contact();
                contactInformation = contactBl.GetContactInformation(id);
                return View("Details", contactInformation);
            }
            catch (Exception ex)
            {

                return Content(ex.Message.ToString());
            }
           
        }
        /// <summary>
        /// Delete a particluar contact
        /// </summary>
        /// <param name="id">contact unique id</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {

            
            contactBl.DeleteContactInformation(id);
            return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return Content(ex.Message.ToString());
            }
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