using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HackandCraft.Api;
using LinkedIn;
using Model;
using StartupValue;
using UFOStart.Api.Services;
using UFOStart.Api.Services.Messaging;
using UFOStart.Model;
using mandrill.net;

namespace UFOStart.Api.Controllers.Web
{
    public class UserController : HackandCraftController
    {
        //This method is depriciated
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

        public string liLogin(User user)
        {
            try
            {
            
                result = orm.execObject<Result>(user, "api.user_linkedin_login");
                var myresult = (Result)result;
                
                //keping linkedin stuff updated with every login
                if (result.dbMessage == null)
                {      
                    //todo putting the threading back here will need testing but should be done at some point.
                    user.token = myresult.User.token;
                    //SaveLinkedInDetails.save(user);
                    //new UserStartupValue(myresult.User).save();
                    //new Task(() => SaveConnections.save(user)).Start(); 

                    //SaveConnections.save(user);
                }
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string liRegister(User user)
        {
            try
            {

                result = orm.execObject<Result>(user, "api.user_linkedin_register");
                var myresult = (Result)result;              
                if (result.dbMessage == null)
               {

                   Mail.enqueue(new WelcomeEmail(myresult.User.email, myresult.User.name));
                   user.token = myresult.User.token;
                   new Task(() => SaveLinkedInDetails.save(user)).Start();
                   new Task(() => new UserStartupValue(myresult.User).save()).Start();
                  // new Task(() => SaveConnections.save(user)).Start(); 
                    SaveConnections.save(user);
               }

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        
        
        
        //This method is depriciated
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
                    if (user.Profile[0].type == "LI")
                    {
                        user.token = myresult.User.token;
                        new Task(() => SaveLinkedInDetails.save(user)).Start();
                        new Task(() => new UserStartupValue(user).save()).Start();
                    }
                }
                
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        //This method is depriciated
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


        public string profile(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_profile");
                var myUser = ((Result) result).User;
               
                new Task(() => new UserStartupValue(myUser).save()).Start();

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string mini(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_profile_mini");

            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string info(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_info_set");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string slugAvailable(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_check_slug_available");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string friends(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_friends");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string friendsCompanies(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_friends_companies");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        

    }
}
