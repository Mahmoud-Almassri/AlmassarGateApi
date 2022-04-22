using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Claims;

namespace AlmassarGate.Domain.Models.Common
{
    public class AppConfiguration
    {
        private readonly string _systemLink = string.Empty;
        private readonly string _connectionString = string.Empty;
        private readonly string _Issuer = string.Empty;
        private readonly string _Audience = string.Empty;
        private readonly string _JWTKey = string.Empty;
        private readonly string _emailConfirmation = string.Empty;
        private readonly string _resetPassword = string.Empty;
        private readonly int? _LoggedInUserId = null;
        private readonly string _Email = string.Empty;
        private readonly string _password = string.Empty;
        private readonly string _adminUrl = string.Empty;
        private readonly int _pageZize = 0;
        private readonly IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

        public AppConfiguration()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            IConfigurationRoot root = configurationBuilder.Build();
            _Issuer = root.GetSection("Jwt").GetSection("Issuer").Value;
            _Audience = root.GetSection("Jwt").GetSection("Audience").Value;
            _JWTKey = root.GetSection("Jwt").GetSection("Key").Value;
            _connectionString = root.GetConnectionString("SqlConnection");
            _emailConfirmation = root.GetSection("EmailConfirmation").Value;
            _systemLink = root.GetSection("SystemLink").Value;
            _resetPassword = root.GetSection("EmailResetPassword").Value;
            _Email = root.GetSection("EmailSender").Value;
            _password = root.GetSection("EmailSenderPassword").Value;
            _pageZize = Convert.ToInt32(root.GetSection("PageSize").Value);
            _adminUrl = root.GetSection("AdminUrl").Value;
           
        }
        public string ConnectionString
        {
            get => _connectionString;
        } 
        public int PageSize
        {
            get => _pageZize;
        }
        public string AdminUrl
        {
            get => _adminUrl;
        }
        //public int LoggedInUserId
        //{
        //    get => _LoggedInUserId;
        //}
        public int? GetUserId()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId != null)
            return int.Parse(userId);
            return null;
        }
        public string Issuer
        {
            get => _Issuer;
        }
        public string EmailConfirmation
        {
            get => _emailConfirmation;
        }
        public string ResetPassword
        {
            get => _resetPassword;
        }
        public string SystemLink
        {
            get => _systemLink;
        }
        public string Email
        {
            get => _Email;
        }
        public string EmailPassword
        {
            get => _password;
        }

        public string Audience
        {
            get => _Audience;
        }
        public string JWTKey
        {
            get => _JWTKey;
        }

    }

}
