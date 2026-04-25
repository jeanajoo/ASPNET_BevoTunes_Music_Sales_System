using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Net.Mail;

namespace G6_BevoTunes.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmailController : Controller
    {
        private readonly AppDbContext _context;

        public EmailController(AppDbContext context)
        {
            _context = context;
        }

        public static async Task SendEmailAsync(string toEmail, string subject, string body, string ccEmail = null)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("mis333ksp26group6@gmail.com", "vszkqzbwszwlhghd"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("mis333ksp26group6@gmail.com", "BevoTunes"),
                Subject = "Team 6:  " + subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add("mis333ksp26group6@gmail.com");

            foreach (var addr in toEmail.Split(',', ';', StringSplitOptions.RemoveEmptyEntries))
            {
                mail.To.Add(addr.Trim());
            }

            if (!string.IsNullOrWhiteSpace(ccEmail))
            {
                foreach (var addr in ccEmail.Split(',', ';', StringSplitOptions.RemoveEmptyEntries))
                {
                    mail.CC.Add(addr.Trim());
                }
            }

            await smtpClient.SendMailAsync(mail);
        }
    }
}
