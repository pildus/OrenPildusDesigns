using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataControl.Model;
using DataControl.Utils;
using DataControl.DataAccess;
using System.Net.Mail;

namespace DataControl.Utils
{
    // Handles User Login,Signup,Editing
    public static class UserActions
    {
        //Validate User input against the database info. - Success
        public static bool UserLogin(string email, string password, ref string err)
        {
            try //Verify if user exist in database according to the input mail address
            {
                using (var context = new OPDdbContext())
                {
                    var user = context.Users
                 .Single(b => b.EmailAddress == email);

                    var dbPass = user.Password; //Verify input encrypted password against database password

                    if (dbPass == ValidationControl.Encrypt_Password(password))
                    {
                        OrdersActions.PopulateShoppingCart(user, ref err);

                        Constants.SessionUser = user; //Session user holds the user object for the entire solution
                        
                        err = "Login successfull";
                        return true;
                    }
                    else
                    {
                        err = "Password not match";
                        return false;
                    }
                }
            }
            catch (Exception e) //no such user 
            {
                err = "No such user in database";
                Console.WriteLine(e.Message);
                return false;
            }
        }



        //Signing Up new user to database
        public static bool UserSignUp(string UserName,
        string FirstName,
        string LastName,
        string Password,
        string EmailAddress,
        bool IsAdmin,
        int UserType,
        ref string err)
        {
            if (ValidateFieldsForSignUp(UserName, FirstName, LastName, Password, EmailAddress))
            {
                using (var context = new OPDdbContext())
                {
                    try
                    {
                        //Verify is no such email address or username
                        if (!context.Users.Any(u => u.EmailAddress == EmailAddress || u.UserName == UserName))
                        {

                            var newUser = new User()
                            {
                                EmailAddress = EmailAddress,
                                FirstName = FirstName,
                                LastName = LastName,
                                Password = ValidationControl.Encrypt_Password(Password),
                                UserName = UserName,
                                User_UserTypeId = UserType
                            };

                            if (IsAdmin)
                            {
                                newUser.IsAdmin = true;
                                err = "Admin User added Successfully";
                            }
                            else
                                err = "User added Successfully";

                            context.Add<User>(newUser);
                            context.SaveChanges();
                            
                            return true;
                        }
                        else
                        {
                            if (context.Users.Any(u => u.EmailAddress == EmailAddress))
                                err = "Email address Already registered";
                            else
                                err = "Username is taken, choose a differetn one";

                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        err = "Error accessing database";
                        Console.WriteLine(e.Message);
                    }


                    return false;
                }
            }
            else
                err = "Fields data error";
            return false;
        }



        //Editing user details to database
        public static bool EditUser(int id,
        string FirstName,
        string LastName,
        bool IsAamin,
        ref string err
        )
        {
            if (ValidateFieldsForSignUp(FirstName, LastName))
            {
                using (var context = new OPDdbContext())
                {
                    try
                    {
                        var updateUser = context.Users.Single(u => u.UserID == id);

                        //Verify user exist
                        if (!(updateUser == null))
                        {
                            //updateUser.EmailAddress = EmailAddress;
                            updateUser.FirstName = FirstName;
                            updateUser.LastName = LastName;
                            updateUser.IsAdmin = IsAamin;
                            context.SaveChanges();
                            err = "Good. User updated";
                            return true;
                        }
                        else
                        {
                            err = "No such user";
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        err = "No user with this ID";
                        Console.WriteLine(e.Message);
                    }


                    return false;
                }
            }
            else
                err = "Fields data error";
            return false;
        }

        //Editing user password to database
        public static bool EditUser(int id,
        string password,
        ref string err
        )
        {
                using (var context = new OPDdbContext())
                {
                    try
                    {
                        var updateUser = context.Users.Single(u => u.UserID == id);

                        //Verify user exist
                        if (!(updateUser == null))
                        {
                        updateUser.Password = password;
                        context.SaveChanges();
                        err = "Password Sucessfully updated !";
                        }
                        else
                        {
                            err = "No such user";
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        err = "No user with this ID";
                        Console.WriteLine(e.Message);
                    }


                    return false;
                }
        }

        public static bool CreateUserType(string desc , ref string err)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    UserType ut = new UserType { UserTypeDescription = desc };
                    context.UserTypes.Add(ut);
                    context.SaveChanges();

                    err = "UserType created successfully";
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }





        #region privateValidationMethods
        // * Validating fields for signup
        private static bool ValidateFieldsForSignUp(string UserName,
        string FirstName,
        string LastName,
        string Password,
        string EmailAddress)
        {
            if (!ValidationControl.EmailValidation(EmailAddress) ||
                !ValidationControl.Validate_Password_Params(Password) ||
                FirstName == "" || LastName == "" || UserName == ""
                )
                return false;
            else
                return true;
        }


        // ** Validating fields for editing
        private static bool ValidateFieldsForSignUp(
        string FirstName,
        string LastName
                        )
        {
            if (FirstName == "" || LastName == "")
                return false;
            else
                return true;
        }

        #endregion
    }

}
