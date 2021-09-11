using Application.Service.Contract;
using Application.Service.FactoryApplicationService;
using Application.Service.Masters;
using Application.Service.SurveyService;
using PMAY.Dto.SurveyForDto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PMAYProject.Controllers
{
    public class SurveyorController : Controller
    {
        private readonly IMastersService mastersService;
        private readonly ISurveyService surveyService;
        public SurveyorController()
        {
            mastersService = ApplicatonServiceFactory<MastersService>.Create();
            surveyService = ApplicatonServiceFactory<SurveysService>.Create();
        }
        // GET: Surveyor
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBeneficiary()
        {
            var masters = mastersService.WardNo();
            return View("~/Views/Surveyor/GetBeneficiary.cshtml", masters);
        }
        public ActionResult BeneficiaryDetail()
        {
            return View();
        }

        public ActionResult UploadGeoTagImg()
        {
            return View();
        }

        [HttpPost]
        [Route("GetBeneficiaryList")]
        public JsonResult GetBeneficiaryList()
        {
            List<BeneficiaryListforDto> beneficiaryFors = new List<BeneficiaryListforDto>();
            beneficiaryFors = surveyService.GetBeneficiaryList();
            return Json( beneficiaryFors, JsonRequestBehavior.AllowGet );
        }

        [HttpPost]
        [Route("BeneficiaryDetails")]
        public JsonResult B_Details(int Id)
        {
            string GridHtml = string.Empty;
            string URI = "http://" + urlpath() + "/Surveyor/BeneficiaryDetail";
            string myParameters = "Id=" + Id;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                GridHtml = wc.UploadString(URI, "Post", myParameters);

            }

            return Json(new { GridHtml, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public ActionResult BeneficiaryDetail(int Id)
        {
            DataTable dt = surveyService.BeneficiaryDetail(Id);
            ViewBag.details = dt;

            return View("~/Views/Surveyor/BeneficiaryDetail");

        }


        public string urlpath()
        {
            string url = "";

            if (Request.IsLocal)
            {
                url = "localhost:" + Request.Url.Port;
            }
            else
            {
                url = Request.Url.Host;
            }

            return url;
        }
    }
}