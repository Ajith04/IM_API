using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models.AdminAuthModels;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace ITEC_API.Services
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly IAdminAuthRepo _iAdminAuthRepo;
        private readonly IConfiguration _configuration;

        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _port = 587;
        private readonly string _senderEmail = "sritharanajith04@gmail.com";
        private readonly string _senderPassword = "lgcd fjbr vedb xvll";

        public AdminAuthService(IAdminAuthRepo iAdminAuthRepo, IConfiguration iConfiguration)
        {
            _iAdminAuthRepo = iAdminAuthRepo;
            _configuration = iConfiguration;
        }

        public async Task<List<RoleResponse>> getAllRoles()
        {
            var roleList = new List<RoleResponse>();

            var roles = await _iAdminAuthRepo.getAllRoles();
            if(roles != null)
            {
                foreach(var role in roles)
                {
                    roleList.Add(new RoleResponse
                    {
                        RoleId = role.RoleId,
                        RoleName = role.RoleName,
                    });
                }
                return roleList;
            }
            else
            {
                return null;
            }
        }

        public async Task addAccount(RegisterAccounRequest registerAccounRequest)
        {

            var password = generateOTP();
            var account = new Account()
            {
                MailId = registerAccounRequest.Email,
                Password = password.ToString(),
                RoleId = registerAccounRequest.RoleId
            };

            await _iAdminAuthRepo.addAccount(account);
        }

        public async Task<List<AccounNameResponse>> getAllAccounts()
        {
            var accountList = new List<AccounNameResponse>();

            var allAccounts = await _iAdminAuthRepo.getAllAccounts();

            if(allAccounts != null)
            {
                foreach (var account in allAccounts)
                {
                    accountList.Add(new AccounNameResponse()
                    {
                        MailId = account.MailId
                    });
                }
                return accountList;
            }
            else
            {
                return null;
            }
        }

        public async Task addPassword(PasswordRequest passwordRequest)
        {
            var singleAccount = await _iAdminAuthRepo.getAccountByMailId(passwordRequest.MailId);
            var generatedOTP = generateOTP();
            var hashedOTP = BCrypt.Net.BCrypt.HashPassword(generatedOTP.ToString());

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ITEC Admin", _senderEmail));
            message.To.Add(new MailboxAddress("", passwordRequest.MailId));
            message.Subject = "Your OTP Code";
            message.Body = new TextPart("plain")
            {
                Text = $"Your OTP code is: {generatedOTP}"
            };

            using var client = new SmtpClient();
            client.Connect(_smtpServer, _port, false);
            client.Authenticate(_senderEmail, _senderPassword);
            client.Send(message);
            client.Disconnect(true);

            singleAccount.Password = hashedOTP;
             await _iAdminAuthRepo.addPassword(singleAccount);
        }

        public static int generateOTP(int length = 4)
        {
            var random = new Random();
            var otp = new StringBuilder(length);

            for(int i = 0; i < length; i++)
            {
                otp.Append(random.Next(1, 10));
            }
            return int.Parse(otp.ToString());
        }

        public async Task<TokenResponse> login(loginRequest loginRequest)
        {
            var singleRecord = await _iAdminAuthRepo.getAccountByMailId(loginRequest.MailId);

                if(BCrypt.Net.BCrypt.Verify(loginRequest.Otp, singleRecord.Password))
                {
                    var token = createToken(singleRecord);
                var tokenResponse = new TokenResponse()
                {
                    Token = token
                };
                    return tokenResponse;
                    
                }
                else
                {
                    return null;
                }



        }

        private string createToken(Account singleRecord)
        {
            var claimList = new List<Claim>();
            claimList.Add(new Claim("Id", singleRecord.AccountId.ToString()));
            claimList.Add(new Claim("Email", singleRecord.MailId.ToString()));
            claimList.Add(new Claim("Role", singleRecord.RoleId.ToString()));

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt: Issuer"],
                _configuration["Jwt: Audience"],
                claims: claimList,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}

