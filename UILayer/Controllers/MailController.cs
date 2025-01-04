using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using UILayer.DTO.MailDTO;

namespace UILayer.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailCreateDTO mailCreateDTO)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "projekursapi@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailCreateDTO.ReceiverEMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailCreateDTO.Message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailCreateDTO.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, true);
            client.Authenticate("projekursapi@gmail.com", "itcs zbby vbzk uugm");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Statistik");
        }
    }
}
