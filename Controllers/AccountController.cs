//using Morphous.TokenAuth.TransferModels;
//using Orchard.Localization;
//using System;
//using System.Web.Http;
//using Orchard.Users.Services;
//using Orchard.Users.Models;
//using Orchard.Security;
//using Orchard;
//using Orchard.ContentManagement;

//namespace Morphous.TokenAuth.Controllers {
//    [Authorize]
//    public class AccountController : ApiController {
//        private readonly IMembershipService _membershipService;
//        private readonly IUserService _userService;
//        private readonly IOrchardServices _orchardServices;

//        public AccountController(
//            IMembershipService membershipService,
//            IUserService userService,
//            IOrchardServices orchardServices) {
//            _membershipService = membershipService;
//            _userService = userService;
//            _orchardServices = orchardServices;
//            T = NullLocalizer.Instance;
//        }

//        public Localizer T { get; set; }

//        public string Get() {
//            return "test";
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public IHttpActionResult Register(RegisterBindingModel model) {

//            var registrationSettings = _orchardServices.WorkContext.CurrentSite.As<RegistrationSettingsPart>();
//            if (!registrationSettings.UsersCanRegister) {
//                return NotFound();
//            }

//            if (model == null) {
//                return BadRequest();
//            }

//            if (!ModelState.IsValid) {
//                return BadRequest(ModelState);
//            }

//            if (!string.IsNullOrEmpty(model.Email)) {
//                if (!_userService.VerifyUserUnicity(model.Email, model.Email)) {
//                    AddModelError("NotUniqueUserName", T("User with that email already exists."));
//                    return BadRequest(ModelState);
//                }
//            }

//            var user = _membershipService.CreateUser(new CreateUserParams(model.Email, model.Password, model.Email, null, null, true));
//            if (user != null) {
//                return Ok();
//            }

//            return InternalServerError();
//        }

//        public void AddModelError(string key, LocalizedString errorMessage) {
//            ModelState.AddModelError(key, errorMessage.ToString());
//        }
//    }
//}
