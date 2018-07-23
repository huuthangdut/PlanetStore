using AutoMapper;
using BotDetect.Web.Mvc;
using Planet.Common.Helper;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Services.Core;
using Planet.Web.Models;
using System;
using System.Web.Mvc;

namespace Planet.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IFeedbackService _feedbackService;
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IContactService contactService, IFeedbackService feedbackService, IUnitOfWork unitOfWork)
        {
            _contactService = contactService;
            _feedbackService = feedbackService;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var viewModel = new FeedbackViewModel
            {
                ContactInfo = Mapper.Map<ContactViewModel>(_contactService.GetDefaultContact())
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "ContactCaptcha", "Mã xác nhận không hợp lệ !")]
        public ActionResult SendFeedback(FeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ContactInfo = Mapper.Map<ContactViewModel>(_contactService.GetDefaultContact());

                return View("Index", model);
            }

            var feedback = Mapper.Map<Feedback>(model);

            feedback.DateCreated = DateTime.Now;

            _feedbackService.Add(feedback);
            _unitOfWork.Commit();

            TempData["SendFeedbackSuccessMsg"] =
                "Đã gửi phản hồi thành công. Chúng tôi sẽ tiếp nhận những phản hồi của bạn.";

            string mailContent = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/feedback.html"));
            mailContent = mailContent.Replace("{{Name}}", model.Name);
            mailContent = mailContent.Replace("{{Email}}", model.Email);
            mailContent = mailContent.Replace("{{Subject}}", model.Subject);
            mailContent = mailContent.Replace("{{Message}}", model.Message);

            MailHelper.SendMail(ConfigHelper.GetByKey("AdminEmail"), "Thông tin phản hồi từ khách hàng", mailContent);

            return RedirectToAction("Index");
        }
    }
}