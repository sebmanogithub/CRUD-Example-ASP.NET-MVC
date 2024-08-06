using CRUDMVCApp.Data;
using CRUDMVCApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CRUDMVCApp.Controllers
{
    public class GadgetsController : Controller
    {
        // GET: Gadgets
        public ActionResult Index()
        {
            List<GadgetModel> gadgets = new List<GadgetModel>();
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgets = gadgetDAO.FetchAll();

            return View("Index", gadgets);
        }

        public ActionResult Details(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FetchOne(id);

            return View("Details", gadget);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult ProcessCreate(GadgetModel gadget)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.Create(gadget);

            return View("Details", gadget);
        }
    }
}