﻿using System;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace eMovietickets.Controllers
{
    public class SMTPController : Controller
    {
        // GET: SMTP
        [HttpGet]
        public ActionResult Mail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Mail(string to, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("anurudh.chauhan.07@gmail.com");
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("anurudh.chauhan.07@gmail.com", "ieyqebtejvizgidg");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                ViewBag.Message = "Mail sent successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
            }
            return View();
        }
    }
}