using System;
using HackandCraft.Api;
using UFOStart.Api.Services.Messaging;
using UFOStart.Model;
using mandrill.net;

namespace UFOStart.Api.Controllers
{
    public class UserController : HackandCraftController
    {

        public string emailSignUp(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_email_signup");
                if (result.dbMessage == null)
                    Mail.enqueue(new WelcomeEmail(user.email,user.name));
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string connect(User user)
        {
            try
            {
                if (user.Profile[0].type == "XI" || user.Profile[0].type == "TW")
                {
                    result = new Result(){dbMessage ="User is logged but cant proceed without linkedin" };
                }
                
                else
                {
                    result = orm.execObject<Result>(user, user.Profile[0].type == "LI" ? "api.user_linkedin_connect" : "api.user_facebook_connect");
                    var myresult = (Result)result;
                    if (result.dbMessage == "NEWUSER")
                        Mail.enqueue(new WelcomeEmail(myresult.User.email, myresult.User.name));
                }
                
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string login(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_email_login");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        

    }
}
