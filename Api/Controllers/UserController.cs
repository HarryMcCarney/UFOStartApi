using System;
using HackandCraft.Api;
using UFOStart.Model;

namespace UFOStart.Api.Controllers
{
    public class UserController : HackandCraftController
    {

        public string emailSignUp(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_email_signup");
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
                result = orm.execObject<Result>(user, user.Profile[0].type == "LI" ? "api.user_linkedin_connect" : "api.user_facebook_connect");
            
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
